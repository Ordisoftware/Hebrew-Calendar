/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2022 Olivier Rogier.
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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew;

static public class Interlocks
{

  static public readonly string TableName = nameof(Interlocks);

  static private SQLiteNetORM Connection => HebrewDatabase.Instance.Connection;

  [SuppressMessage("Performance", "U2U1212:Capture intermediate results in lambda expressions", Justification = "N/A")]
  static private void Purge()
  {
    string sql = $"SELECT ProcessID, count(ProcessID) FROM {TableName} GROUP BY ProcessID";
    var processes = Process.GetProcesses();
    foreach ( var item in Connection.Query<Interlock>(sql).Where(item => !processes.Any(p => p.Id == item.ProcessID)) )
      Connection.Execute($"DELETE FROM {TableName} WHERE ProcessID = (?)", item.ProcessID);
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
    Connection.Insert(item);
  }

  static public void Release(string name = null)
  {
    if ( !IsLockedByCurrentProcess(name) ) return;
    string sql = $"DELETE FROM {TableName} WHERE ProcessID = (?)";
    Connection.Execute(sql, Globals.ProcessId);
  }

  static public bool IsLockedByCurrentProcess(string name = null)
  {
    name = Convert(name);
    string sql = $"SELECT Count(ProcessID) FROM {TableName} WHERE ProcessID = (?) AND Name = (?)";
    return Connection.ExecuteScalar<long>(sql, Globals.ProcessId, name) > 0;
  }

  static public bool IsReadOnly
    => GetCount() > 1;

  static public long GetCount(string name = null)
  {
    name = Convert(name);
    string sql = $"SELECT Count(Name) FROM {TableName} WHERE Name = (?)";
    return Connection.ExecuteScalar<long>(sql, name);
  }

  [SuppressMessage("Performance", "U2U1209:Use dictionaries efficiently", Justification = "N/A")]
  [SuppressMessage("Performance", "CA1854:Préférer la méthode 'IDictionary.TryGetValue(TKey, out TValue)'", Justification = "N/A")]
  static public List<string> GetLockers(string name = null)
  {
    name = Convert(name);
    string sql = $"SELECT ProcessID FROM {TableName} WHERE Name = (?)";
    var dictionary = new Dictionary<string, int>();
    var processes = Process.GetProcesses();
    var list = from item in Connection.Query<Interlock>(sql, name).Where(item => item.ProcessID != Globals.ProcessId)
               let process = Array.Find(processes, p => p.Id == item.ProcessID)
               select process?.ProcessName ?? $"PID {item.ProcessID}";
    foreach ( var item in list )
      if ( dictionary.ContainsKey(item) )
        dictionary[item]++;
      else
        dictionary.Add(item, 1);
    return dictionary.Select(pair => $"{pair.Key} ({pair.Value})").ToList();
  }

}
