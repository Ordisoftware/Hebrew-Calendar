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
using System.Collections.Generic;
using System.ComponentModel;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  partial class HebrewDatabase : SQLiteDatabase
  {

    static new public HebrewDatabase Instance { get; protected set; }

    public readonly string ParashotTableName = nameof(Parashot);
    public readonly string ProcessLocksTableName = nameof(ProcessLocks);

    public List<Parashah> Parashot { get; private set; }

    public BindingList<Parashah> ParashotAsBindingList => new BindingList<Parashah>(Parashot);

    private bool ParashotFirstTake = true;

    static HebrewDatabase()
    {
      Instance = new HebrewDatabase();
      SQLiteDatabase.Instance = Instance;
    }

    private bool CreateDataMutex;

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
    }

    public override void LoadAll()
    {
    }

    protected override void DoSaveAll()
    {
      throw new NotImplementedException();
    }

    public override void DeleteAll()
    {
      Connection.DeleteAll<Parashah>();
      Parashot.Clear();
    }

    public bool IsParashotReadOnly()
    {
      return ProcessLocks.GetCount(ParashotTableName) > 1;
    }

    public List<Parashah> TakeParashot(bool reload = false)
    {
      if ( !reload && Parashot != null ) return Parashot;
      ProcessLocks.Lock(ParashotTableName);
      if ( ParashotFirstTake )
      {
        ParashotFactory.Reset();
        CreateParashotDataIfNotExist();
        ParashotFirstTake = false;
      }
      Parashot = Load(Connection.Table<Parashah>());
      return Parashot;
    }

    public void ReleaseParashot()
    {
      if ( Parashot == null ) return;
      Parashot.Clear();
      Parashot = null;
      ProcessLocks.Unlock(ParashotTableName);
    }

    public void SaveParashot()
    {
      Connection.BeginTransaction();
      try
      {
        Connection.UpdateAll(Parashot);
        Connection.Commit();
      }
      catch
      {
        Connection.Rollback();
        throw;
      }
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

    public void CreateParashotDataIfNotExist(bool reset = false)
    {
      if ( CreateDataMutex ) return;
      bool temp = Globals.IsReady;
      Globals.IsReady = false;
      CreateDataMutex = true;
      try
      {
        SystemManager.TryCatchManage(() =>
        {
          if ( !reset && Connection.GetRowsCount(ParashotTableName) == 54 ) return;
          Connection.BeginTransaction();
          try
          {
            DeleteAll();
            Connection.InsertAll(ParashotFactory.All.Select(p => p.Clone()));
            Connection.Commit();
          }
          catch
          {
            Connection.Rollback();
            throw;
          }
        });
      }
      finally
      {
        CreateDataMutex = false;
        Globals.IsReady = temp;
      }
    }

  }

}
