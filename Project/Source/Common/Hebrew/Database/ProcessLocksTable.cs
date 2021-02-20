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
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Data.Odbc;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  static public class ProcessLocksTable
  {

    public const string TableName = "ProcessLocks";

    static ProcessLocksTable()
    {
      CreateProcessLocksSchemaIfNotExists();
    }

    static private void CreateProcessLocksSchemaIfNotExists()
    {
      SystemManager.TryCatchManage(() =>
      {
        SQLiteOdbcHelper.CreateOrUpdateDSN(Globals.CommonDatabaseOdbcDSN, Globals.CommonDatabaseFilePath, 0);
        using ( var connection = new OdbcConnection(Globals.CommonConnectionString) )
        {
          connection.Open();
          bool existed = connection.CheckTable(TableName,
                                               $@"CREATE TABLE {TableName}
                                                  (
                                                    ProcessID INTEGER NOT NULL,
                                                    Name TEXT NOT NULL
                                                  )");
        }
      });
    }

    static private void PurgeLocks()
    {
      string sql = $"SELECT ProcessID, count(ProcessID) FROM {TableName} GROUP BY ProcessID";
      using ( var connection = new OdbcConnection(Globals.CommonConnectionString) )
      using ( var command = new OdbcCommand(sql, connection) )
      {
        connection.Open();
        var reader = command.ExecuteReader();
        while ( reader.Read() )
        {
          int id = (int)reader["ProcessID"];
          if ( !Process.GetProcesses().Any(p => p.Id == id) )
          {
            string sqlDelete = $"DELETE FROM {TableName} WHERE ProcessID = (?)";
            using ( var commandDelete = new OdbcCommand(sqlDelete, connection) )
            {
              commandDelete.Parameters.Add("@ID", OdbcType.Int).Value = id;
              commandDelete.ExecuteNonQuery();
            }
          }
        }
      }
    }

    static private string GetLockName(string nameCommonTable = null)
    {
      if ( string.IsNullOrEmpty(nameCommonTable) )
        switch ( Globals.AssemblyGUID )
        {
          case "39d572b4-36da-4964-ba85-51bc5909c69b":
            return "CalendarInstances";
          case "e4e4c05b-71ed-42de-a2fa-345ae793a9ac":
            return "LettersInstances";
          case "9117fa5b-51de-481e-9cb1-65a606d6ca69":
            return "WordsInstances";
          default:
            throw new SystemException("Unknown application GUID: " + Globals.AssemblyTitle);
        }
      else
        switch ( nameCommonTable )
        {
          case ParashotTable.TableName:
            return "CommonParashotInstances";
          default:
            throw new SystemException("Unknown application GUID: " + Globals.AssemblyTitle);
        }
    }

    static public bool IsAlreadyLockedByCurrentProcess(string nameCommonTable = null)
    {
      string sql = $"SELECT Count(ProcessID) FROM {TableName} WHERE ProcessID = (?)";
      using ( var connection = new OdbcConnection(Globals.CommonConnectionString) )
      using ( var command = new OdbcCommand(sql, connection) )
      {
        connection.Open();
        command.Parameters.Add("@ID", OdbcType.Int).Value = Process.GetCurrentProcess().Id;
        return (int)command.ExecuteScalar() > 0;
      }
    }

    static public int GetLocks(string nameCommonTable)
    {
      string name = GetLockName(nameCommonTable);
      string sql = $"SELECT Count(Name) FROM {TableName} WHERE Name = (?)";
      using ( var connection = new OdbcConnection(Globals.CommonConnectionString) )
      using ( var command = new OdbcCommand(sql, connection) )
      {
        connection.Open();
        command.Parameters.Add("@Name", OdbcType.Text).Value = name;
        return (int)command.ExecuteScalar();
      }
    }

    static public List<string> GetOtherLockers(string nameCommonTable = null)
    {
      var dictionary = new Dictionary<string, int>();
      string name = GetLockName(nameCommonTable);
      string sql = $"SELECT ProcessID FROM {TableName} WHERE Name = (?)";
      using ( var connection = new OdbcConnection(Globals.CommonConnectionString) )
      using ( var command = new OdbcCommand(sql, connection) )
      {
        connection.Open();
        command.Parameters.Add("@Name", OdbcType.Text).Value = name;
        var reader = command.ExecuteReader();
        while ( reader.Read() )
        {
          int id = (int)reader["ProcessID"];
          if ( id == Process.GetCurrentProcess().Id ) continue;
          var process = Process.GetProcesses().FirstOrDefault(p => p.Id == id);
          string processName = process?.ProcessName ?? SysTranslations.UnknownSlot.GetLang(); 
          if ( dictionary.ContainsKey(processName) )
            dictionary[processName]++;
          else
            dictionary.Add(processName, 1);
        }
      }
      return dictionary.Select(pair => $"{pair.Key} ({pair.Value})").ToList();
    }

    static public void Lock(string nameCommonTable = null)
    {
      if ( IsAlreadyLockedByCurrentProcess(nameCommonTable) ) return;
      string name = GetLockName(nameCommonTable);
      string sql = $"INSERT INTO {TableName} VALUES (?, (?))";
      using ( var connection = new OdbcConnection(Globals.CommonConnectionString) )
      using ( var command = new OdbcCommand(sql, connection) )
      {
        connection.Open();
        command.Parameters.Add("@ID", OdbcType.Int).Value = Process.GetCurrentProcess().Id;
        command.Parameters.Add("@Name", OdbcType.Text).Value = name;
        command.ExecuteNonQuery();
      }
    }

    static public void Unlock(string nameCommonTable = null)
    {
      string name = GetLockName(nameCommonTable);
      if ( !IsAlreadyLockedByCurrentProcess(name) ) return;
      string sql = $"DELETE FROM {TableName} WHERE ProcessID = (?) AND Name = (?)";
      using ( var connection = new OdbcConnection(Globals.CommonConnectionString) )
      using ( var command = new OdbcCommand(sql, connection) )
      {
        connection.Open();
        command.Parameters.Add("@ID", OdbcType.Int).Value = Process.GetCurrentProcess().Id;
        command.Parameters.Add("@Name", OdbcType.Text).Value = name;
        command.ExecuteNonQuery();
      }
    }

  }

}
