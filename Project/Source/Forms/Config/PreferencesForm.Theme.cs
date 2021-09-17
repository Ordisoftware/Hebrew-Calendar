﻿/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
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
/// <created> 2020-12 </created>
/// <edited> 2021-09 </edited>
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// Provide form to edit the preferences.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  partial class PreferencesForm
  {

    private void SetThemeLight()
    {
      EditCurrentDayForeColor.BackColor = Color.White;
      EditCurrentDayBackColor.BackColor = Color.FromArgb(200, 0, 0);
      EditSelectedDayColor.BackColor = Color.FromArgb(200, 0, 0);
      EditCalendarColorParashah.BackColor = Color.Indigo;
      EditCalendarColorTorahEvent.BackColor = Color.DarkRed;
      EditCalendarColorSeason.BackColor = Color.DarkGreen;
      EditCalendarColorMoon.BackColor = Color.DarkBlue;
      EditCalendarColorFullMoon.BackColor = Color.FromArgb(150, 100, 0);
      EditEventColorTorah.BackColor = Color.FromArgb(255, 255, 230);
      EditEventColorSeason.BackColor = Color.FromArgb(245, 255, 240);
      EditEventColorShabat.BackColor = Color.FromArgb(243, 243, 243);
      EditEventColorMonth.BackColor = Color.AliceBlue;
      EditEventColorNext.BackColor = Color.FromArgb(240, 240, 240);
      EditMonthViewBackColor.BackColor = Color.White;
      EditMonthViewTextColor.BackColor = Color.Black;
      EditMonthViewNoDaysBackColor.BackColor = Color.FromArgb(250, 250, 250);
      MustRefreshMonthView = true;
    }

    private void SetThemeDark()
    {
      EditCurrentDayForeColor.BackColor = Color.White;
      EditCurrentDayBackColor.BackColor = Color.FromArgb(200, 0, 0);
      EditSelectedDayColor.BackColor = Color.FromArgb(200, 0, 0);
      EditCalendarColorParashah.BackColor = Color.Plum;
      EditCalendarColorTorahEvent.BackColor = Color.FromArgb(250, 190, 255);
      EditCalendarColorSeason.BackColor = Color.FromArgb(128, 255, 128);
      EditCalendarColorMoon.BackColor = Color.FromArgb(128, 255, 255);
      EditCalendarColorFullMoon.BackColor = Color.FromArgb(255, 255, 128);
      EditEventColorTorah.BackColor = Color.FromArgb(70, 70, 40);
      EditEventColorSeason.BackColor = Color.FromArgb(0, 64, 0);
      EditEventColorShabat.BackColor = Color.FromArgb(60, 50, 60);
      EditEventColorMonth.BackColor = Color.FromArgb(0, 50, 100);
      EditEventColorNext.BackColor = Color.FromArgb(20, 20, 20);
      EditMonthViewBackColor.BackColor = Color.Black;
      EditMonthViewTextColor.BackColor = Color.White;
      EditMonthViewNoDaysBackColor.BackColor = Color.FromArgb(80, 80, 80);
      MustRefreshMonthView = true;
    }

    private void OpenTheme()
    {
      SystemManager.TryCatch(() =>
      {
        OpenThemeDialog.InitialDirectory = Settings.GetExportDirectory();
      });
      if ( OpenThemeDialog.ShowDialog() != DialogResult.OK ) return;
      var items = new NullSafeOfStringDictionary<string>();
      if ( !items.LoadKeyValuePairs(OpenThemeDialog.FileName, "=") ) return;
      PanelCalendarColors.Controls.OfType<Panel>().ToList().ForEach(panel =>
      {
        string name = panel.Name.Substring(4);
        if ( items.ContainsKey(name) )
          panel.BackColor = ColorTranslator.FromHtml(items[name]);
      });
      NavigationForm.Instance.PanelTop.BackColor = EditNavigateTopColor.BackColor;
      NavigationForm.Instance.PanelMiddle.BackColor = EditNavigateMiddleColor.BackColor;
      NavigationForm.Instance.PanelBottom.BackColor = EditNavigateBottomColor.BackColor;
      MainForm.Instance.CalendarText.ForeColor = EditTextReportTextColor.BackColor;
      MainForm.Instance.CalendarText.BackColor = EditTextReportBackColor.BackColor;
      MustRefreshMonthView = true;
    }

    private void SaveTheme()
    {
      SystemManager.TryCatch(() =>
      {
        SaveThemeDialog.InitialDirectory = Settings.GetExportDirectory();
        SaveThemeDialog.FileName = "Theme.ini";
      });
      if ( SaveThemeDialog.ShowDialog() != DialogResult.OK ) return;
      var items = new List<string>();
      PanelCalendarColors.Controls.OfType<Panel>().ToList().ForEach(panel =>
      {
        items.Add(panel.Name.Substring(4) + "=" + ColorTranslator.ToHtml(panel.BackColor));
      });
      File.WriteAllLines(SaveThemeDialog.FileName, items);
    }

  }

}
