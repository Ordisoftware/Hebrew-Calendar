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

  public partial class CommonDatabase
  {

    public const string ParashotTableName = "Parashot";
    public const string ParashotSelectAll = "select * from " + ParashotTableName;
    public const string ParashotDeleteAll = "delete from " + ParashotTableName;

    public DataTable ParashotTable { get; private set; }

    private bool ParashotTableMutex;

    private void CreateParashotSchemaIfNotExists()
    {
      SystemManager.TryCatchManage(() =>
      {
        SQLiteOdbcHelper.CreateOrUpdateDSN(Globals.CommonDatabaseOdbcDSN, Globals.CommonDatabaseFilePath, 0);
        using ( var connection = new OdbcConnection(Globals.CommonConnectionString) )
        {
          connection.Open();
          connection.CheckTable(ParashotTableName,
                                $@"CREATE TABLE {ParashotTableName}
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

    public void UseParashotTable()
    {
      if ( ParashotTable != null ) return;
      Lock(ParashotTableName);
      Lock(ParashotTableName);
      if ( GetLocks(ParashotTableName) != 1 )
        // TODO manage read only mode
        DisplayManager.Show("Table is in use by other processes: readonly mode." + Globals.NL +
                            "Try to check locks count to enable write mode." + Globals.NL2 +
                            string.Join(Environment.NewLine, GetOtherLockers(ParashotTableName)));
      ParashotTable = new DataTable(ParashotTableName);
      using ( var connection = new OdbcConnection(Globals.CommonConnectionString) )
      {
        connection.Open();
        var command = new OdbcCommand(ParashotSelectAll, connection);
        using ( var adapter = new OdbcDataAdapter(command) )
          adapter.Fill(ParashotTable);
      }
      CreateParashotDataIfNotExists(false);
    }

    public void DisposeParashotTable()
    {
      if ( ParashotTable == null ) return;
      ParashotTable.Dispose();
      ParashotTable = null;
      Unlock(ParashotTableName);
    }

    public void UpdateParashotTable()
    {
      if ( ParashotTable == null ) throw new ArgumentNullException(ParashotTableName);
      using ( var connection = new OdbcConnection(Globals.CommonConnectionString) )
      using ( var command = new OdbcCommand(ParashotSelectAll, connection) )
      using ( var adapter = new OdbcDataAdapter(command) )
      using ( var builder = new OdbcCommandBuilder(adapter) )
      {
        adapter.Update(ParashotTable);
      }
    }

    public void CreateParashotDataIfNotExists(bool reset)
    {
      if ( ParashotTableMutex ) return;
      SystemManager.TryCatchManage(() =>
      {
        bool temp = Globals.IsReady;
        Globals.IsReady = false;
        ParashotTableMutex = true;
        try
        {
          if ( !reset && ParashotTable.Rows.Count == 54 ) return;
          DisposeParashotTable();

          using ( var connection = new OdbcConnection(Globals.CommonConnectionString) )
          using ( var command = new OdbcCommand(ParashotDeleteAll, connection) )
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
            var row = ParashotTable.NewRow();
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
            ParashotTable.Rows.Add(row);
          }
          UpdateParashotTable();
        }
        finally
        {
          Globals.IsReady = temp;
          ParashotTableMutex = false;
        }
      });
    }

  }

}
