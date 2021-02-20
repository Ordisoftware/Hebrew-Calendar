/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2021 Olivier Rogier. 
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2021-02 </created>
/// <edited> 2021-02 </edited>
using System;
using System.Linq;
using System.Data;
using System.Data.Odbc;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  static class ParashotTable
  {

    static public readonly string TableName = nameof(ParashotTable).Replace("Table", "");

    static public DataTable Instance { get; private set; }

    static private bool ParashotTableMutex;

    static ParashotTable()
    {
      CreateParashotSchemaIfNotExists();
    }

    static private void CreateParashotSchemaIfNotExists()
    {
      SystemManager.TryCatchManage(() =>
      {
        SQLiteOdbcHelper.CreateOrUpdateDSN(Globals.CommonDatabaseOdbcDSN, Globals.CommonDatabaseFilePath, 0);
        using ( var connection = new OdbcConnection(Globals.CommonConnectionString) )
        {
          connection.Open();
          connection.CheckTable(TableName,
                                $@"CREATE TABLE {TableName}
                                  (
                                    Book INTEGER NOT NULL,
                                    Number INTEGER NOT NULL,
                                    Name TEXT DEFAULT '' NOT NULL,
                                    Hebrew TEXT DEFAULT '' NOT NULL,
                                    Unicode TEXT DEFAULT '' NOT NULL,
                                    VerseBegin TEXT DEFAULT '' NOT NULL,
                                    VerseEnd TEXT DEFAULT '' NOT NULL,
                                    IsLinkedToNext INTEGER DEFAULT 0 NOT NULL,
                                    Translation TEXT DEFAULT '' NOT NULL,
                                    Lettriq TEXT DEFAULT '' NOT NULL,
                                    Memo TEXT DEFAULT '' NOT NULL,
                                    PRIMARY KEY (Book, Number)
                                  )");
        }
      });
    }

    static public void UseParashotTable()
    {
      if ( Instance != null ) return;
      ProcessLocksTable.Lock(TableName);
      Instance = new DataTable(TableName);
      string sql = "SELECT * FROM " + TableName;
      using ( var connection = new OdbcConnection(Globals.CommonConnectionString) )
      using ( var command = new OdbcCommand(sql, connection) )
      using ( var adapter = new OdbcDataAdapter(command) )
      {
        connection.Open();
        adapter.Fill(Instance);
      }
      CreateParashotDataIfNotExists();
    }

    static public bool IsParashotTableReadOnly(bool showmessage)
    {
      bool result = ProcessLocksTable.GetLocks(TableName) > 1;
      if ( result && showmessage )
        DisplayManager.Show("Table is in use by other processes: readonly mode." + Globals.NL +
                            "Try to check locks count to enable write mode." + Globals.NL2 +
                            string.Join(Environment.NewLine, ProcessLocksTable.GetOtherLockers(TableName)));
      return result;
    }

    static public void DisposeParashotTable()
    {
      if ( Instance == null ) return;
      Instance.Dispose();
      Instance = null;
      ProcessLocksTable.Unlock(TableName);
    }

    static public void UpdateParashotTable()
    {
      if ( Instance == null ) throw new ArgumentNullException(TableName);
      string sql = "SELECT * FROM " + TableName;
      using ( var connection = new OdbcConnection(Globals.CommonConnectionString) )
      using ( var command = new OdbcCommand(sql, connection) )
      using ( var adapter = new OdbcDataAdapter(command) )
      using ( var builder = new OdbcCommandBuilder(adapter) )
      {
        connection.Open();
        adapter.Update(Instance);
      }
    }

    static public void CreateParashotDataIfNotExists(bool reset = false)
    {
      if ( ParashotTableMutex ) return;
      SystemManager.TryCatchManage(() =>
      {
        bool temp = Globals.IsReady;
        Globals.IsReady = false;
        ParashotTableMutex = true;
        try
        {
          if ( !reset && Instance.Rows.Count == 54 ) return;
          DisposeParashotTable();
          string sql = "DELETE FROM " + TableName;
          using ( var connection = new OdbcConnection(Globals.CommonConnectionString) )
          using ( var command = new OdbcCommand(sql, connection) )
          {
            connection.Open();
            command.ExecuteNonQuery();
          }
          UseParashotTable();
          var query = from book in Parashah.Defaults
                      from parashah in book.Value
                      select parashah;
          foreach ( Parashah parashah in query.ToList() )
          {
            var row = Instance.NewRow();
            row[nameof(Parashah.Book)] = parashah.Book + 1;
            row[nameof(Parashah.Number)] = parashah.Number;
            row[nameof(Parashah.Name)] = parashah.Name;
            row[nameof(Parashah.Hebrew)] = parashah.Hebrew;
            row[nameof(Parashah.Unicode)] = parashah.Unicode;
            row[nameof(Parashah.VerseBegin)] = parashah.VerseBegin;
            row[nameof(Parashah.VerseEnd)] = parashah.VerseEnd;
            row[nameof(Parashah.IsLinkedToNext)] = parashah.IsLinkedToNext;
            row[nameof(Parashah.Translation)] = parashah.Translation;
            row[nameof(Parashah.Lettriq)] = parashah.Lettriq;
            row[nameof(Parashah.Memo)] = "";
            Instance.Rows.Add(row);
          }
          UpdateParashotTable();
        }
        finally
        {
          ParashotTableMutex = false;
          Globals.IsReady = temp;
        }
      });
    }

  }

}
