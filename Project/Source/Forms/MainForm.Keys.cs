/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// Project is registered at Depotnumerique.com (Agence des Depots Numeriques).
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2016-04 </created>
/// <edited> 2016-04 </edited>
using System;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    /// <summary>
    /// Process the command key.
    /// </summary>
    /// <seealso cref="M:System.Windows.Forms.Form.ProcessCmdKey(Message@,Keys)"/>
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      switch ( keyData )
      {
        case Keys.Control | Keys.S:
          actionSaveReport.PerformClick();
          return true;
        case Keys.Control | Keys.E:
          actionExportCSV.PerformClick();
          return true;
        case Keys.Control | Keys.C:
          actionCopyReportToClipboard.PerformClick();
          return true;
        case Keys.Control | Keys.D:
          actionSearchDay.PerformClick();
          return true;
        case Keys.Escape:
          if ( IsGenerating )
          {
            if ( DisplayManager.QueryYesNo(LocalizerHelper.StopGenerationText.GetLang()) )
              IsGenerating = false;
          }
          else
          if ( editESCtoExit.Checked )
            Close();
          return true;
        case Keys.F1:
          actionHelp.PerformClick();
          return true;
        case Keys.F2:
          actionGenerate.PerformClick();
          return true;
        case Keys.F8:
          actionPreferences.PerformClick();
          return true;
        case Keys.F12:
          actionAbout.PerformClick();
          return true;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

  }

}
