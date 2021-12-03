/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2021 Olivier Rogier.
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
/// <edited> 2021-12 </edited>
namespace Ordisoftware.Core;

using SQLite;

public delegate void LoadingDataEventHandler(string caption);
public delegate void DataLoadedEventHandler(string caption);

/// <summary>
/// Provides SQLite database wrapper.
/// </summary>
abstract class SQLiteDatabase
{

  static public SQLiteDatabase Instance { get; protected set; }

  protected bool AutoLoadAllAtOpen { get; init; } = true;

  public string ConnectionString { get; }

  public bool Initialized { get; private set; }

  public bool Loaded { get; protected set; }

  public bool ClearListsOnCloseOrRelease { get; set; }

  protected readonly List<object> ModifiedObjects = new();

  public bool HasChanges => ModifiedObjects.Count > 0;

  public event Action<SQLiteDatabase, object> Modified;
  public event Action<SQLiteDatabase> Saved;

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
  }

  protected void CheckConnected()
  {
    if ( Connection == null ) throw new SQLiteException("Not connected.");
  }

  protected void CheckAccess(object table, string name)
  {
    if ( table == null ) throw new SQLiteException("Table is not loaded: " + name);
  }

  public virtual void Open()
  {
    CheckConnected();
    if ( Initialized ) return;
    UpgradeSchema();
    CreateTables();
    Vacuum();
    Initialized = true;
    if ( AutoLoadAllAtOpen ) LoadAll();
  }

  protected virtual void Vacuum() { }

  protected virtual void UpgradeSchema() { }

  protected abstract void CreateTables();

  public void Close()
  {
    if ( Connection == null ) return;
    Rollback();
    DoClose();
    Connection.Close();
    Connection = null;
  }

  protected abstract void DoClose();

  public void LoadAll()
  {
    CheckConnected();
    Rollback();
    DoLoadAll();
    Loaded = true;
    CreateDataIfNotExist();
    CreateBindingInstances();
  }

  protected abstract void DoLoadAll();

  protected virtual void CreateDataIfNotExist(bool reset = false) { }

  protected virtual void CreateBindingInstances() { }

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

}
