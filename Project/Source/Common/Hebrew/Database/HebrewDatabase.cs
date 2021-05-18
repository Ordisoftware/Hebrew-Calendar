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
using System.Linq;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  partial class HebrewDatabase : SQLiteDatabase
  {

    static new public HebrewDatabase Instance { get; protected set; }

    static HebrewDatabase()
    {
      Instance = new HebrewDatabase();
      SQLiteDatabase.Instance = Instance;
    }

    private HebrewDatabase() : base(Globals.CommonDatabaseFilePath)
    {
      Open();
      CheckConnected();
      Connection.CheckIntegrity();
      Connection.Vacuum(true);
    }

    protected override void DoClose()
    {
      ReleaseParashot();
      ReleaseLettriqs();
    }

    protected override void CreateTables()
    {
      CheckConnected();
      Connection.CreateTable<Interlock>();
      Connection.CreateTable<Parashah>();
      Connection.CreateTable<TermHebrew>();
      Connection.CreateTable<TermLettriq>();
    }

    public override void LoadAll()
    {
    }

    protected override void DoSaveAll()
    {
      throw new NotImplementedException();
    }

    protected override void UpgradeSchema()
    {
      base.UpgradeSchema();
      string table = "ProcessLocks";
      if ( Connection.CheckTable(table) )
        if ( Globals.ConcurrentRunningProcesses.Count() == 0)
          Connection.DropTableIfExists(table);
    }

  }

}
