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
using System.Collections.Generic;
using Equin.ApplicationFramework;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  partial class HebrewDatabase : SQLiteDatabase
  {

    public List<TermHebrew> TermsHebrew { get; private set; }
    public List<TermLettriq> TermLettriqs { get; private set; }
    public List<TermAnalysis> TermAnalyzes { get; private set; }

    public BindingListView<TermHebrew> TermsHebrewAsBindingList { get; private set; }
    public BindingListView<TermLettriq> TermLettriqsAsBindingList { get; private set; }

    public List<TermHebrew> TakeLettriqs(bool reload = false)
    {
      CheckConnected();
      if ( !reload && TermsHebrew != null ) return TermsHebrew;
      Interlocks.Take(nameof(TermsHebrew));
      TermsHebrew = Load(Connection.Table<TermHebrew>());
      TermLettriqs = Load(Connection.Table<TermLettriq>());
      TermAnalyzes = Load(Connection.Table<TermAnalysis>());
      TermsHebrewAsBindingList = new BindingListView<TermHebrew>(TermsHebrew);
      TermLettriqsAsBindingList = new BindingListView<TermLettriq>(TermLettriqs);
      Instance.TermsHebrewAsBindingList.ApplySort(nameof(TermHebrew.Hebrew));
      Instance.TermLettriqsAsBindingList.ApplySort(nameof(TermLettriq.Sentence));
      return TermsHebrew;
    }

    public void ReleaseLettriqs()
    {
      if ( TermsHebrew == null && TermLettriqs == null && TermAnalyzes == null ) return;
      Interlocks.Release(nameof(TermsHebrew));
      if ( ClearListsOnCloseAndRelease )
      {
        TermAnalyzes?.Clear();
        TermLettriqs?.Clear();
        TermsHebrew?.Clear();
      }
      TermAnalyzes = null;
      TermLettriqs = null;
      TermsHebrew = null;
    }

    public void SaveLettriqs()
    {
      CheckConnected();
      CheckAccess(TermLettriqs, nameof(TermLettriqs));
      CheckAccess(TermsHebrew, nameof(TermsHebrew));
      CheckAccess(TermAnalyzes, nameof(TermAnalyzes));
      Connection.BeginTransaction();
      try
      {
        Connection.UpdateAll(TermsHebrew);
        Connection.UpdateAll(TermLettriqs);
        Connection.UpdateAll(TermAnalyzes);
        Connection.Commit();
      }
      catch
      {
        Connection.Rollback();
        throw;
      }
    }

    public void DeleteLettriqs()
    {
      CheckConnected();
      CheckAccess(TermLettriqs, nameof(TermLettriqs));
      CheckAccess(TermsHebrew, nameof(TermsHebrew));
      CheckAccess(TermAnalyzes, nameof(TermAnalyzes));
      Connection.DeleteAll<TermAnalysis>();
      Connection.DeleteAll<TermHebrew>();
      Connection.DeleteAll<TermLettriq>();
      TermAnalyzes.Clear();
      TermLettriqs.Clear();
      TermsHebrew.Clear();
    }

  }

}
