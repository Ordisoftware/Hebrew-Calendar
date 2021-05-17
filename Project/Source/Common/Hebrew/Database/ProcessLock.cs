/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2016-2021 Olivier Rogier.
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
/// <edited> 2021-05 </edited>
using System;
using SQLite;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  [Table("ProcessLocks")]
  public class ProcessLock : ProcessLock_No_ID
  {
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
  }

  public class ProcessLock_No_ID
  {
    public int ProcessID { get; set; }
    public string Name { get; set; }
  }

  static class ProcessLocksUpgrade
  {
    static public void AddID(SQLiteNetORM connection)
    {
      connection.Execute($@"PRAGMA foreign_keys = 0;");
      connection.DropTableIfExists(nameof(ProcessLock_No_ID));
      connection.RenameTableIfExists(nameof(ProcessLocks), nameof(ProcessLock_No_ID));
      connection.CreateTable<ProcessLock>();
      var rows = connection.Table<ProcessLock_No_ID>();
      connection.BeginTransaction();
      int index = 1;
      foreach ( var row in rows )
        connection.Insert(new ProcessLock { ID = index++, Name = row.Name, ProcessID = row.ProcessID });
      connection.Commit();
      connection.DropTableIfExists(nameof(ProcessLock_No_ID));
      connection.Execute($@"PRAGMA foreign_keys = 1;");
    }
  }

}
