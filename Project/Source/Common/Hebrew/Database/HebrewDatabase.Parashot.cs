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

    public readonly string ParashotTableName = nameof(Parashot);

    public List<Parashah> Parashot { get; private set; }

    public BindingList<Parashah> ParashotAsBindingList { get; private set; }

    private bool CreateParashotDataMutex;
    private bool ParashotFirstTake = true;

    public bool IsParashotReadOnly()
    {
      CheckConnected();
      return ProcessLocks.GetCount(ParashotTableName) > 1;
    }

    public List<Parashah> TakeParashot(bool reload = false)
    {
      CheckConnected();
      if ( !reload && Parashot != null ) return Parashot;
      ProcessLocks.Lock(ParashotTableName);
      if ( ParashotFirstTake )
      {
        ParashotFactory.Reset();
        ParashotFirstTake = false;
      }
      return CreateParashotDataIfNotExistAndLoad();
    }

    public void ReleaseParashot()
    {
      if ( Parashot == null ) return;
      ProcessLocks.Unlock(ParashotTableName);
      if ( ClearListsOnCloseAndRelease ) Parashot.Clear();
      Parashot = null;
    }

    private List<Parashah> LoadParashot()
    {
      Parashot = Load(Connection.Table<Parashah>());
      ParashotAsBindingList = new BindingList<Parashah>(Parashot);
      return Parashot;
    }

    public void SaveParashot()
    {
      CheckConnected();
      CheckAccess(Parashot, nameof(Parashot));
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

    public void DeleteParashot(bool nocheckaccess = false)
    {
      CheckConnected();
      if ( !nocheckaccess ) CheckAccess(Parashot, nameof(Parashot));
      Connection.DeleteAll<Parashah>();
      Parashot?.Clear();
    }

    public List<Parashah> CreateParashotDataIfNotExistAndLoad(bool reset = false, bool notext = false)
    {
      CheckConnected();
      if ( CreateParashotDataMutex )
        throw new SystemException($"{nameof(CreateParashotDataIfNotExistAndLoad)} is already running.");
      bool temp = Globals.IsReady;
      Globals.IsReady = false;
      CreateParashotDataMutex = true;
      try
      {
        if ( reset || Connection.GetRowsCount(ParashotTableName) != 54 )
          SystemManager.TryCatchManage(() =>
          {
            Connection.BeginTransaction();
            try
            {
              DeleteParashot(true);
              var list = ParashotFactory.All.Select(p => p.Clone()).Cast<Parashah>().ToList();
              if ( notext ) list.ForEach(p => { p.Translation = ""; p.Lettriq = ""; p.Memo = ""; });
              Connection.InsertAll(list);
              Connection.Commit();
            }
            catch
            {
              Connection.Rollback();
              throw;
            }
          });
        return LoadParashot();
      }
      finally
      {
        CreateParashotDataMutex = false;
        Globals.IsReady = temp;
      }
    }

  }

}
