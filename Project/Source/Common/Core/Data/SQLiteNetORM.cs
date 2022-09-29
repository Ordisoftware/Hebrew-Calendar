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
/// <created> 2019-01 </created>
/// <edited> 2022-06 </edited>
namespace Ordisoftware.Core;

using SQLite;

/// <summary>
/// Provides specialized SQLiteConnection.
/// </summary>
public class SQLiteNetORM : SQLiteConnection
{

  /// <summary>
  /// Indicates the database engine name and version.
  /// </summary>
  static public string EngineNameAndVersion { get; private set; }
    = SysTranslations.NonthingSlot.GetLang().TrimFirstLast().Titleize();

  /// <summary>
  /// Indicates the provider name.
  /// </summary>
  static public string ProviderName { get; private set; }
    = SysTranslations.NonthingSlot.GetLang().TrimFirstLast().Titleize();

  static public int DefaultOptimizeDaysInterval { get; set; } = Globals.DaysOfWeekCount;

  public SQLiteNetORM(SQLiteConnectionString connectionString) : base(connectionString) { }

  public SQLiteNetORM(string databasePath, bool storeDateTimeAsTicks = true) : base(databasePath, storeDateTimeAsTicks) { }

  public SQLiteNetORM(string databasePath, SQLiteOpenFlags openFlags, bool storeDateTimeAsTicks = true) : base(databasePath, openFlags, storeDateTimeAsTicks) { }

  /// <summary>
  /// Gets a single line of a string.
  /// </summary>
  public string UnformatSQL(string sql)
  {
    return sql.SplitNoEmptyLines().Select(line => line.Trim()).AsMultiSpace();
  }

  /// <summary>
  /// Returns true if only one instance of the process is running else false.
  /// </summary>
  /// <param name="silent">True if no message is shown else shown.</param>
  public bool CheckProcessConcurency(bool silent = false)
  {
    var list = Process.GetProcessesByName(Globals.ProcessName);
    bool valid = list.Length == 1;
    if ( !valid && !silent )
      DisplayManager.ShowWarning(SysTranslations.DatabaseNoProcessConcurrency.GetLang());
    return valid;
  }

  /// <summary>
  /// Gets the version of the engine.
  /// </summary>
  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "<En attente>")]
  public void InitializeVersion()
  {
    ProviderName = this?.GetType().Name ?? SysTranslations.ErrorSlot.GetLang();
    int vernum = this?.LibVersionNumber ?? -1;
    if ( vernum == -1 )
      EngineNameAndVersion = SysTranslations.UnknownSlot.GetLang();
    else
    {
      string version = vernum.ToString();
      string build = int.Parse(new string(version.TakeLast(3).ToArray())).ToString();
      string minor = int.Parse(new string(version.SkipLast(3).TakeLast(3).ToArray())).ToString();
      string major = int.Parse(new string(version.SkipLast(6).ToArray())).ToString();
      EngineNameAndVersion = $"SQLite {major}.{minor}.{build}";
    }
  }

  /// <summary>
  /// Creates a SQL command.
  /// </summary>
  public SQLiteCommand CreateCommand() => new(this);

  /// <summary>
  /// Creates a SQL command.
  /// </summary>
  /// <param name="sql">The query.</param>
  public SQLiteCommand CreateCommand(string sql) => new(this) { CommandText = sql };

  /// <summary>
  /// Optimizes the database.
  /// </summary>
  /// <param name="lastdone">The last done date.</param>
  /// <param name="interval">Days interval to check.</param>
  /// <param name="force">True to force check.</param>
  /// <returns>The new date if done else lastdone.</returns>
  public DateTime Optimize(DateTime lastdone, int interval = -1, bool force = false)
  {
    if ( interval == -1 ) interval = DefaultOptimizeDaysInterval;
    if ( force || lastdone.AddDays(interval) < DateTime.Now )
    {
      CheckIntegrity();
      Vacuum();
      lastdone = DateTime.Now;
    }
    return lastdone;
  }

  /// <summary>
  /// Checks the database integrity.
  /// </summary>
  public void CheckIntegrity()
  {
    SystemManager.TryCatchManage(() =>
    {
      string result = ExecuteScalar<string>("SELECT integrity_check FROM pragma_integrity_check()");
      if ( result != "ok" )
      {
        throw new SQLiteException(result);
      }
    });
  }

  /// <summary>
  /// Does the database Vacuum.
  /// </summary>
  public void Vacuum()
  {
    try
    {
      Execute("VACUUM");
    }
    catch ( Exception ex )
    {
      throw new SQLiteException(SysTranslations.DatabaseVacuumError.GetLang(), ex);
    }
  }

  /// <summary>
  /// Drops a table if exists.
  /// </summary>
  public void DropTableIfExists(string table)
  {
    if ( table.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(table));
    try
    {
      Execute($"DROP TABLE IF EXISTS [{table}]");
    }
    catch ( Exception ex )
    {
      throw new SQLiteException(SysTranslations.DBDropTableError.GetLang(table), ex);
    }
  }

  /// <summary>
  /// Renames a table if exists.
  /// </summary>
  /// <param name="tableOldName">Old name.</param>
  /// <param name="tableNewName">New name.</param>
  public void RenameTableIfExists(string tableOldName, string tableNewName)
  {
    if ( tableOldName.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(tableOldName));
    if ( tableNewName.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(tableNewName));
    try
    {
      Execute($"ALTER TABLE IF EXISTS [{tableOldName}] RENAME TO [{tableNewName}];");
    }
    catch ( Exception ex )
    {
      throw new SQLiteException(SysTranslations.DBRenameTableError.GetLang(tableOldName, tableNewName), ex);
    }
  }

  /// <summary>
  /// Renames a column if exists.
  /// </summary>
  /// <param name="tableName">Table name.</param>
  /// <param name="columnOldName">Old name.</param>
  /// <param name="columnNewName">New name.</param>
  public void RenameColumnIfExists(string tableName, string columnOldName, string columnNewName)
  {
    if ( tableName.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(tableName));
    if ( columnOldName.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(columnOldName));
    if ( columnNewName.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(columnNewName));
    try
    {
      if ( CheckColumn(tableName, columnOldName) )
        Execute($"ALTER TABLE [{tableName}] RENAME COLUMN [{columnOldName}] TO [{columnNewName}];");
    }
    catch ( Exception ex )
    {
      throw new SQLiteException(SysTranslations.DBRenameTableError.GetLang(tableName, columnOldName, columnNewName), ex);
    }
  }

  /// <summary>
  /// Checks if a table exists and create it if not.
  /// </summary>
  /// <param name="table">The table name.</param>
  /// <param name="sql">The sql query to create the table, can be empty to only check.</param>
  /// <returns>True if the table exists else false even if created.</returns>
  public bool CheckTable(string table, string sql = "")
  {
    try
    {
      if ( table.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(table));
      const string sqlSelect = "SELECT count(*) FROM sqlite_master WHERE type = 'table' AND name = ?";
      if ( ExecuteScalar<long>(sqlSelect, table) != 0 ) return true;
      if ( !sql.IsNullOrEmpty() )
        try
        {
          CreateCommand(sql).ExecuteNonQuery();
        }
        catch ( Exception ex )
        {
          throw new SQLiteException(SysTranslations.DBCreateTableError.GetLang(table, UnformatSQL(sql)), ex);
        }
    }
    catch ( Exception ex )
    {
      throw new SQLiteException($"Error in {nameof(CheckTable)}", ex);
    }
    return false;
  }

  /// <summary>
  /// Checks if a index exists and create it if not.
  /// </summary>
  /// <param name="index">The index name.</param>
  /// <param name="sql">The sql query to create the table, can be empty to only check.</param>
  /// <returns>True if the index exists else false even if created.</returns>
  public bool CheckIndex(string index, string sql = "")
  {
    try
    {
      if ( index.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(index));
      const string sqlCheck = "SELECT count(*) FROM sqlite_master WHERE type = 'index' AND name = ?";
      if ( ExecuteScalar<long>(sqlCheck, index) != 0 ) return true;
      if ( !sql.IsNullOrEmpty() )
        try
        {
          Execute(sql);
        }
        catch ( Exception ex )
        {
          throw new SQLiteException(SysTranslations.DBCreateIndexError.GetLang(index, UnformatSQL(sql)), ex);
        }
    }
    catch ( Exception ex )
    {
      throw new SQLiteException($"Error in {nameof(CheckIndex)}", ex);
    }
    return false;
  }

  /// <summary>
  /// Checks if a column of a table exists and create it if not.
  /// </summary>
  /// <remarks>
  /// The existence of the table is not checked.
  /// </remarks>
  /// <param name="table">The table name.</param>
  /// <param name="column">The column name.</param>
  /// <param name="sql">The sql query to create the column, can be empty to only check</param>
  /// <returns>True if the column exists else false even if created.</returns>
  public bool CheckColumn(string table, string column, string sql = "")
  {
    try
    {
      if ( table.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(table));
      if ( column.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(column));
      const string sqlCheck = "SELECT COUNT(*) AS CNTREC FROM pragma_table_info(?) WHERE name = ?";
      if ( ExecuteScalar<long>(sqlCheck, table, column) > 0 ) return true;
      if ( !sql.IsNullOrEmpty() )
        try
        {
          sql = sql.Replace("%TABLE%", table).Replace("%COLUMN%", column);
          Execute(sql);
        }
        catch ( Exception ex )
        {
          throw new SQLiteException(SysTranslations.DBCreateColumnError.GetLang(UnformatSQL(sql)), ex);
        }
    }
    catch ( Exception ex )
    {
      throw new SQLiteException($"Error in {nameof(CheckColumn)}", ex);
    }
    return false;
  }

  /// <summary>
  /// Checks if a column of a table exists and create it if not.
  /// </summary>
  /// <remarks>
  /// The existence of the table is not checked.
  /// </remarks>
  /// <param name="table">The table name.</param>
  /// <param name="column">The column name.</param>
  /// <param name="type">The type of the column.</param>
  /// <param name="valueDefault">The default value.</param>
  /// <param name="valueNotNull">Indicate if not null.</param>
  /// <param name="isPrimary">Indicate if primary key.</param>
  /// <param name="isAutoInc">INdicate if auto inc.</param>
  /// <returns>True if the column exists else false even if created.</returns>
  public bool CheckColumn(string table,
                          string column,
                          string type,
                          string valueDefault,
                          bool valueNotNull,
                          bool isPrimary = false,
                          bool isAutoInc = false)
  {
    if ( table.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(table));
    if ( column.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(column));
    if ( type.IsNullOrEmpty() ) throw new ArgumentNullException(nameof(type));
    if ( !valueDefault.IsNullOrEmpty() ) valueDefault = " DEFAULT " + valueDefault;
    if ( valueNotNull ) valueDefault += " NOT NULL";
    string primary = isPrimary ? "PRIMARY KEY" : string.Empty;
    if ( isAutoInc ) primary += " AUTOINCREMENT ";
    string sql = $"ALTER TABLE %TABLE% ADD COLUMN %COLUMN% {type} {primary} {valueDefault}";
    return CheckColumn(table, column, sql);
  }

  /// <summary>
  /// Gets the number of rows in a table.
  /// </summary>
  /// <param name="table">The table name.</param>
  public long CountRows(string table)
  {
    try
    {
      return ExecuteScalar<long>($"SELECT count(*) FROM [{table}]");
    }
    catch ( Exception ex )
    {
      throw new SQLiteException($"Error in {nameof(CountRows)}", ex);
    }
  }

}
