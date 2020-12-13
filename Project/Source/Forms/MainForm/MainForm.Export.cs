/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2020 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2016-04 </created>
/// <edited> 2020-12 </edited>
using System;
using System.Linq;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class MainForm
  {

    private void DoExport(ExportAction action,
                          NullSafeDictionary<ViewMode, Func<int?, int?, bool>> process,
                          Action<ViewMode> after)
    {
      var available = ViewMode.None;
      var view = Settings.CurrentView;
      foreach ( var item in process.Where(p => p.Value != null) )
        available |= item.Key;
      var result = SelectExportTargetForm.Run(action, ref view, available);
      if ( !result.isOk ) return;
      if ( process[view] == null )
        throw new NotImplementedExceptionEx(Settings.CurrentView.ToStringFull());
      bool done = result.year2 > result.year1
                  ? process[view].Invoke(result.year1, result.year2)
                  : process[view].Invoke(result.year2, result.year1);
      if ( done ) after?.Invoke(view);
    }

  }

}
