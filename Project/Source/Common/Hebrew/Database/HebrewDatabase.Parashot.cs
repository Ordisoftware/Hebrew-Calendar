/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2025 Olivier Rogier.
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
/// <edited> 2021-11 </edited>
namespace Ordisoftware.Hebrew;

public partial class HebrewDatabase : SQLiteDatabase
{

  public readonly string ParashotTableName = nameof(Parashot);

  public List<Parashah> Parashot { get; private set; }

  public BindingList<Parashah> ParashotAsBindingList { get; private set; }

  private bool CreateParashotDataMutex;
  private bool ParashotFirstTake = true;

  public bool IsParashotReadOnly()
  {
    CheckConnected();
    return Interlocks.GetCount(ParashotTableName) > 1;
  }

  public List<Parashah> TakeParashot(bool reload = false)
  {
    CheckConnected();
    if ( !reload && Parashot is not null ) return Parashot;
    Interlocks.Take(ParashotTableName);
    if ( ParashotFirstTake )
    {
      ParashotFactory.Instance.Reset();
      ParashotFirstTake = false;
    }
    return CreateParashotDataIfNotExistAndLoad();
  }

  public void ReleaseParashot()
  {
    if ( Parashot is null ) return;
    Interlocks.Release(ParashotTableName);
    if ( ClearListsOnCloseOrRelease ) Parashot.Clear();
    Parashot = null;
  }

  private List<Parashah> LoadParashot()
  {
    Parashot = Load(Connection.Table<Parashah>());
    if ( IsParashotUpgradedV10 )
    {
      foreach ( Parashah item in Parashot )
      {
        item.ReferenceBegin = item.VerseBegin;
        item.ReferenceEnd = item.VerseEnd;
        item.InitializeReferences();
      }
      SaveParashot();
      IsParashotUpgradedV10 = false;
    }
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

  public void DeleteParashot(bool noCheckAccess = false)
  {
    CheckConnected();
    if ( !noCheckAccess ) CheckAccess(Parashot, nameof(Parashot));
    Connection.DeleteAll<Parashah>();
    Parashot?.Clear();
  }

  public List<Parashah> CreateParashotDataIfNotExistAndLoad(
    bool reset = false,
    bool noText = false,
    bool keepMemo = false)
  {
    CheckConnected();
    if ( CreateParashotDataMutex )
      throw new SystemException($"{nameof(CreateParashotDataIfNotExistAndLoad)} is already running.");
    bool temp = Globals.IsReady;
    Globals.IsReady = false;
    CreateParashotDataMutex = true;
    try
    {
      if ( reset || Connection.CountRows(ParashotTableName) != ParashotFactory.Instance.All.Count() )
        SystemManager.TryCatchManage(() =>
        {
          Connection.BeginTransaction();
          try
          {
            var memos = keepMemo ? new List<string>() : null;
            memos?.AddRange(Parashot.Select(p => p.Memo));
            DeleteParashot(true);
            var list = ParashotFactory.Instance.All.Select(p => p.Clone()).Cast<Parashah>().ToList();
            if ( noText )
              list.ForEach(p =>
              {
                p.Translation = string.Empty;
                p.Lettriq = string.Empty;
                p.Memo = string.Empty;
              });
            if ( memos is not null )
              for ( int index = 0; index < list.Count && index < memos.Count; index++ )
                list[index].Memo = memos[index];
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
