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
/// <edited> 2021-05 </edited>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Data;
using Ordisoftware.Core;
using static Ordisoftware.Hebrew.HebrewDatabase;

namespace Ordisoftware.Hebrew
{

  static class Interlocks
  {

    static public readonly string TableName = nameof(Interlocks);

    static private void Purge()
    {
      string sql = $"SELECT ProcessID, count(ProcessID) FROM {TableName} GROUP BY ProcessID";
      foreach ( var item in Instance.Connection.Query<Interlock>(sql) )
      {
        if ( Process.GetProcesses().Any(p => p.Id == item.ProcessID) ) continue;
        sql = $"DELETE FROM {TableName} WHERE ProcessID = (?)";
        Instance.Connection.Execute(sql, item.ProcessID);
      }
    }

    static private string Convert(string name = null)
    {
      Purge();
      return name.IsNullOrEmpty() ? Globals.ApplicationCode : name;
    }

    static public void Take(string name = null)
    {
      if ( IsLockedByCurrentProcess(name) ) return;
      name = Convert(name);
      var item = new Interlock { ProcessID = Globals.ProcessId, Name = name };
      Instance.Connection.Insert(item);
    }

    static public void Release(string name = null)
    {
      if ( !IsLockedByCurrentProcess(name) ) return;
      name = Convert(name);
      string sql = $"DELETE FROM {TableName} WHERE ProcessID = (?)";
      Instance.Connection.Execute(sql, Globals.ProcessId);
    }

    static public bool IsLockedByCurrentProcess(string name = null)
    {
      name = Convert(name);
      string sql = $"SELECT Count(ProcessID) FROM {TableName} WHERE ProcessID = (?) AND Name = (?)";
      return Instance.Connection.ExecuteScalar<long>(sql, Globals.ProcessId, name) > 0;
    }

    static public bool IsReadOnly(string name = null)
    {
      return GetCount() > 1;
    }

    static public long GetCount(string name = null)
    {
      name = Convert(name);
      string sql = $"SELECT Count(Name) FROM {TableName} WHERE Name = (?)";
      return Instance.Connection.ExecuteScalar<long>(sql, name);
    }

    static public List<string> GetLockers(string name = null)
    {
      name = Convert(name);
      string sql = $"SELECT ProcessID FROM {TableName} WHERE Name = (?)";
      var dictionary = new Dictionary<string, int>();
      foreach ( var item in Instance.Connection.Query<Interlock>(sql, name) )
      {
        var id = item.ProcessID;
        if ( id == Globals.ProcessId ) continue;
        var process = Process.GetProcesses().FirstOrDefault(p => p.Id == id);
        string processName = process?.ProcessName ?? "PID " + id;
        if ( dictionary.ContainsKey(processName) )
          dictionary[processName]++;
        else
          dictionary.Add(processName, 1);
      }
      return dictionary.Select(pair => $"{pair.Key} ({pair.Value})").ToList();
    }

  }

}
