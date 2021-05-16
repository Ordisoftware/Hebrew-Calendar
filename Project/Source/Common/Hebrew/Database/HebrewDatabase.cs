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

using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  partial class HebrewDatabase : SQLiteDatabase
  {

    static new public HebrewDatabase Instance { get; protected set; }

    public readonly string ProcessLocksTableName = nameof(ProcessLocks);


    static HebrewDatabase()
    {
      Instance = new HebrewDatabase();
      SQLiteDatabase.Instance = Instance;
    }

    private HebrewDatabase() : base(Globals.CommonDatabaseFilePath)
    {
      Open();
      Connection.CheckIntegrity();
      Connection.Vacuum();
    }

    protected override void CreateTables()
    {
      Connection.CreateTable<ProcessLock>();
      Connection.CreateTable<Parashah>();
      Connection.CreateTable<HebrewWord>();
      Connection.CreateTable<Lettriq>();
    }

    public override void LoadAll()
    {
    }

    protected override void DoSaveAll()
    {
      throw new NotImplementedException();
    }

    public override void UpgradeSchema()
    {
      if ( Connection.CheckTable(ProcessLocksTableName) )
        if ( !Connection.CheckColumn(ProcessLocksTableName, "ID") )
        {
          var msg = SysTranslations.UpgradeCommonDatabaseRequired.GetLang(ProcessLocksTableName);
          SystemManager.CloseRunningApplications(msg);
          ProcessLocksUpgrade.AddID(Connection);
        }
    }

  }

}
