/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2022 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2021-05 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Core;

using SQLite;

public delegate void LoadingDataEventHandler(string caption);
public delegate void DataLoadedEventHandler(string caption);

/// <summary>
/// Provides SQLite database wrapper.
/// </summary>
abstract class SQLiteDatabase
{

  protected bool AutoLoadAllAtOpen { get; init; } = true;

  public string ConnectionString { get; }

  public bool Initialized { get; private set; }

  public bool Loaded { get; protected set; }

  public bool ClearListsOnCloseOrRelease { get; set; }

  public bool BindingsEnabled { get; set; } = true;

  protected readonly List<object> ModifiedObjects = new();

  public bool HasChanges => ModifiedObjects.Count > 0;

  public event Action<SQLiteDatabase, object> Modified;

  public event Action<SQLiteDatabase> Saved;

  [SuppressMessage("Performance", "U2U1012:Parameter types should be specific", Justification = "Polymorphism needed")]
  [SuppressMessage("CodeQuality", "IDE0079:Retirer la suppression inutile", Justification = "N/A")]
  public void AddToModified(object instance)
  {
    if ( Loaded && !ModifiedObjects.Contains(instance) )
    {
      ModifiedObjects.Add(instance);
      Modified?.Invoke(this, instance);
    }
  }

  public SQLiteNetORM Connection
  {
    get => _Connection;
    private set => _Connection = value;
  }

  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP006:Implement IDisposable", Justification = "N/A")]
  [NonSerialized]
  private SQLiteNetORM _Connection;

  public bool IsInTransaction => Connection.IsInTransaction;

  public bool UseTransactionByDefault { get; set; } = true;

  public event LoadingDataEventHandler LoadingData;

  public event DataLoadedEventHandler DataLoaded;

  protected virtual void OnLoadingData(string caption)
  {
    LoadingData?.Invoke(caption);
  }

  protected virtual void OnDataLoaded(string caption)
  {
    DataLoaded?.Invoke(caption);
  }

  protected SQLiteDatabase(string connectionString)
  {
    if ( Globals.IsVisualStudioDesigner ) return;
    ConnectionString = connectionString;
    Connection = new SQLiteNetORM(ConnectionString);
    Connection.InitializeVersion();
  }

  protected void CheckConnected()
  {
    if ( Connection is null ) throw new SQLiteException("Not connected.");
  }

  [SuppressMessage("Performance", "U2U1012:Parameter types should be specific", Justification = "Polymorphism needed")]
  [SuppressMessage("CodeQuality", "IDE0079:Retirer la suppression inutile", Justification = "N/A")]
  protected void CheckAccess(object table, string name)
  {
    if ( table is null ) throw new SQLiteException("Table is not loaded: " + name);
  }

  public virtual void Open()
  {
    CheckConnected();
    if ( Initialized ) return;
    UpgradeSchema();
    CreateTables();
    Vacuum();
    Initialized = true;
    if ( AutoLoadAllAtOpen ) LoadAll(true);
  }

  protected virtual void Vacuum(bool force = false) { }

  protected virtual void UpgradeSchema() { }

  protected abstract void CreateTables();

  public void Close()
  {
    if ( Connection is null ) return;
    Rollback();
    DoClose();
    Connection.Close();
    Connection.Dispose();
    Connection = null;
    Loaded = false;
  }

  protected abstract void DoClose();

  public bool LoadAll(bool bindEvenIfDataCreated = true)
  {
    CheckConnected();
    Rollback();
    Loaded = false;
    DoLoadAll();
    Loaded = true;
    var result = CreateDataIfNotExist();
    if ( result && !bindEvenIfDataCreated ) return result;
    CreateBindingLists();
    return result;
  }

  protected abstract void DoLoadAll();

  protected abstract bool CreateDataIfNotExist(bool reset = false);

  protected abstract void CreateBindingLists();

  protected List<T> Load<T>(TableQuery<T> query)
  {
    var caption = typeof(T).Name;
    OnLoadingData(caption);
    var result = query.ToList();
    OnDataLoaded(caption);
    return result;
  }

  public void BeginTransaction()
  {
    CheckConnected();
    if ( !Connection.IsInTransaction )
      Connection.BeginTransaction();
  }

  public void Commit()
  {
    CheckConnected();
    if ( Connection.IsInTransaction )
      Connection.Commit();
  }

  public void Rollback()
  {
    CheckConnected();
    if ( Connection.IsInTransaction )
      Connection.Rollback();
  }

  public void SaveAll()
  {
    SaveAll(UseTransactionByDefault);
  }

  public void SaveAll(bool useTransaction)
  {
    CheckConnected();
    if ( !useTransaction )
    {
      DoSaveAll();
      Saved?.Invoke(this);
      return;
    }
    BeginTransaction();
    try
    {
      DoSaveAll();
      Connection.Commit();
      Saved?.Invoke(this);
    }
    catch
    {
      Rollback();
      throw;
    }
  }

  protected abstract void DoSaveAll();

  protected void ProcessTableUpgrade<TRow, TRowTemp>(
    string nameTable,
    string nameTableTemp,
    Action<TRowTemp, TRow> doCopy!!)
  where TRow : new()
  where TRowTemp : new()
  {
    if ( nameTable.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(nameTable));
    if ( nameTableTemp.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(nameTableTemp));
    if ( Connection.CheckTable(nameTableTemp) )
    {
      string error = SysTranslations.UpgradeDatabaseTempTableExists.GetLang(nameTableTemp);
      string question = SysTranslations.UpgradeDatabaseTableUserChoice.GetLang(error, nameTable, nameTableTemp);
      switch ( DisplayManager.QueryRetryIgnoreAbort(question) )
      {
        case DialogResult.Retry:
          Connection.RenameTableIfExists(nameTableTemp, nameTable);
          ProcessTableUpgrade(nameTable, nameTableTemp, doCopy);
          break;
        case DialogResult.Ignore:
          Connection.DropTableIfExists(nameTableTemp);
          break;
        case DialogResult.Abort:
          throw new SQLiteException(error);
      }
    }
    Connection.Execute("PRAGMA foreign_keys = 0;");
    try
    {
      Connection.RenameTableIfExists(nameTable, nameTableTemp);
      Connection.CreateTable<TRow>();
      var rows = Connection.Table<TRowTemp>();
      Connection.BeginTransaction();
      foreach ( var rowTemp in rows )
      {
        var rowNew = new TRow();
        doCopy(rowTemp, rowNew);
        Connection.Insert(rowNew);
      }
      Connection.Commit();
      Connection.DropTableIfExists(nameTableTemp);
    }
    finally
    {
      Connection.Execute("PRAGMA foreign_keys = 1;");
    }
  }

}