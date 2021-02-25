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

  static partial class ParashotTable
  {

    static public readonly string TableName = nameof(ParashotTable).Replace("Table", string.Empty);

    static public DataTable DataTable { get; private set; }

    static private bool CreateDataMutex;

    static ParashotTable()
    {
      if ( Globals.IsVisualStudioDesigner ) return;
      LoadDefaults();
      CreateIfNotExists();
      for ( int index = 0; index < DefaultsAsList.Count; index++ )
        if ( DefaultsAsList[index].IsLinkedToNext )
          DefaultsAsList[index].Linked = DefaultsAsList[++index];
    }

    static public void LoadDefaults()
    {
      var query = from book in Defaults from parashah in book.Value select parashah;
      var linesTranslation = new NullSafeOfStringDictionary<string>();
      var linesLettriq = new NullSafeOfStringDictionary<string>();
      linesTranslation.LoadKeyValuePairs(HebrewGlobals.ParashotTranslationsFilePath, "=");
      linesLettriq.LoadKeyValuePairs(HebrewGlobals.ParashotLettriqsFilePath, "=");
      int index = 0;
      foreach ( Parashah item in query )
      {
        if ( index < linesTranslation.Count ) item.Translation = linesTranslation.Values.ElementAt(index).Trim();
        if ( index < linesLettriq.Count ) item.Lettriq = linesLettriq.Values.ElementAt(index).Trim();
        index++;
      }
    }

    static private void CreateIfNotExists()
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
                                    {nameof(Parashah.ID)} TEXT NOT NULL,
                                    {nameof(Parashah.Book)} INTEGER NOT NULL,
                                    {nameof(Parashah.Number)} INTEGER NOT NULL,
                                    {nameof(Parashah.Name)} TEXT DEFAULT '' NOT NULL,
                                    {nameof(Parashah.Hebrew)} TEXT DEFAULT '' NOT NULL,
                                    {nameof(Parashah.Unicode)} TEXT DEFAULT '' NOT NULL,
                                    {nameof(Parashah.VerseBegin)} TEXT DEFAULT '' NOT NULL,
                                    {nameof(Parashah.VerseEnd)} TEXT DEFAULT '' NOT NULL,
                                    {nameof(Parashah.IsLinkedToNext)} INTEGER DEFAULT 0 NOT NULL,
                                    {nameof(Parashah.Translation)} TEXT DEFAULT '' NOT NULL,
                                    {nameof(Parashah.Lettriq)} TEXT DEFAULT '' NOT NULL,
                                    {nameof(Parashah.Memo)} TEXT DEFAULT '' NOT NULL,
                                    PRIMARY KEY ({nameof(Parashah.ID)})
                                  )");
        }
      });
    }

    static public bool IsReadOnly()
    {
      return ProcessLocksTable.GetCount(TableName) > 1;
    }

    static public void Take()
    {
      if ( DataTable != null ) return;
      ProcessLocksTable.Lock(TableName);
      DataTable = new DataTable(TableName);
      string sql = "SELECT * FROM " + TableName;
      using ( var connection = new OdbcConnection(Globals.CommonConnectionString) )
      using ( var command = new OdbcCommand(sql, connection) )
      using ( var adapter = new OdbcDataAdapter(command) )
      {
        connection.Open();
        adapter.Fill(DataTable);
      }
      CreateDataIfNotExists();
    }

    static public void Release()
    {
      if ( DataTable == null ) return;
      DataTable.Dispose();
      DataTable = null;
      ProcessLocksTable.Unlock(TableName);
    }

    static public void Update()
    {
      if ( DataTable == null ) throw new ArgumentNullException(TableName);
      string sql = "SELECT * FROM " + TableName;
      using ( var connection = new OdbcConnection(Globals.CommonConnectionString) )
      using ( var command = new OdbcCommand(sql, connection) )
      using ( var adapter = new OdbcDataAdapter(command) )
      using ( var builder = new OdbcCommandBuilder(adapter) )
      {
        connection.Open();
        adapter.Update(DataTable);
      }
    }

    static public void CreateDataIfNotExists(bool reset = false)
    {
      if ( CreateDataMutex ) return;
      SystemManager.TryCatchManage(() =>
      {
        bool temp = Globals.IsReady;
        Globals.IsReady = false;
        CreateDataMutex = true;
        try
        {
          if ( !reset && DataTable.Rows.Count == 54 ) return;
          Release();
          string sql = "DELETE FROM " + TableName;
          using ( var connection = new OdbcConnection(Globals.CommonConnectionString) )
          using ( var command = new OdbcCommand(sql, connection) )
          {
            connection.Open();
            command.ExecuteNonQuery();
          }
          Take();
          var query = from book in Defaults
                      from parashah in book.Value
                      select parashah;
          foreach ( Parashah parashah in query.ToList() )
          {
            var row = DataTable.NewRow();
            row[nameof(Parashah.ID)] = parashah.ID;
            row[nameof(Parashah.Book)] = (int)parashah.Book + 1;
            row[nameof(Parashah.Number)] = parashah.Number;
            row[nameof(Parashah.Name)] = parashah.Name;
            row[nameof(Parashah.Hebrew)] = parashah.Hebrew;
            row[nameof(Parashah.Unicode)] = parashah.Unicode;
            row[nameof(Parashah.VerseBegin)] = parashah.VerseBegin;
            row[nameof(Parashah.VerseEnd)] = parashah.VerseEnd;
            row[nameof(Parashah.IsLinkedToNext)] = parashah.IsLinkedToNext;
            row[nameof(Parashah.Translation)] = parashah.Translation;
            row[nameof(Parashah.Lettriq)] = parashah.Lettriq;
            row[nameof(Parashah.Memo)] = string.Empty;
            DataTable.Rows.Add(row);
          }
          Update();
        }
        finally
        {
          CreateDataMutex = false;
          Globals.IsReady = temp;
        }
      });
    }

  }

}
