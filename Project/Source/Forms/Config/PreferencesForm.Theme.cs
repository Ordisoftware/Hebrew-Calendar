/// <license>
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
/// <edited> 2020-12 </edited>
using System;
using System.Collections.Generic;
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
  public partial class PreferencesForm
  {

    private void SetThemeLight()
    {
      EditCurrentDayForeColor.BackColor = Color.White;
      EditCurrentDayBackColor.BackColor = Color.FromArgb(200, 0, 0);
      EditCalendarColorTorahEvent.BackColor = Color.DarkRed;
      EditCalendarColorSeason.BackColor = Color.DarkGreen;
      EditCalendarColorMoon.BackColor = Color.DarkBlue;
      EditCalendarColorFullMoon.BackColor = Color.FromArgb(150, 100, 0);
      EditEventColorTorah.BackColor = Color.FromArgb(255, 255, 230);
      EditEventColorSeason.BackColor = Color.FromArgb(245, 255, 240);
      EditEventColorShabat.BackColor = Color.FromArgb(243, 243, 243);
      EditEventColorMonth.BackColor = Color.AliceBlue;
      EditEventColorNext.BackColor = Color.WhiteSmoke;
      EditCalendarColorEmpty.BackColor = Color.White;
      EditCalendarColorDefaultText.BackColor = Color.Black;
      EditCalendarColorNoDay.BackColor = Color.FromArgb(250, 250, 250);
      MustRefreshMonthView = true;
    }

    private void SetThemeDark()
    {
      EditCurrentDayForeColor.BackColor = Color.White;
      EditCurrentDayBackColor.BackColor = Color.FromArgb(200, 0, 0);
      EditCalendarColorTorahEvent.BackColor = Color.FromArgb(250, 190, 255);
      EditCalendarColorSeason.BackColor = Color.FromArgb(128, 255, 128);
      EditCalendarColorMoon.BackColor = Color.FromArgb(128, 255, 255);
      EditCalendarColorFullMoon.BackColor = Color.FromArgb(255, 255, 128);
      EditEventColorTorah.BackColor = Color.FromArgb(70, 70, 40);
      EditEventColorSeason.BackColor = Color.FromArgb(0, 64, 0);
      EditEventColorShabat.BackColor = Color.FromArgb(60, 50, 60);
      EditEventColorMonth.BackColor = Color.FromArgb(0, 50, 100);
      EditEventColorNext.BackColor = Color.FromArgb(20, 20, 20);
      EditCalendarColorEmpty.BackColor = Color.Black;
      EditCalendarColorDefaultText.BackColor = Color.White;
      EditCalendarColorNoDay.BackColor = Color.FromArgb(80, 80, 80);
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
      EditCalendarColorDefaultText.BackColor = ColorTranslator.FromHtml(items["MonthViewTextColor"]);
      EditCalendarColorEmpty.BackColor = ColorTranslator.FromHtml(items["MonthViewBackColor"]);
      EditCalendarColorNoDay.BackColor = ColorTranslator.FromHtml(items["MonthViewNoDaysBackColor"]);
      EditCurrentDayForeColor.BackColor = ColorTranslator.FromHtml(items["CurrentDayForeColor"]);
      EditCurrentDayBackColor.BackColor = ColorTranslator.FromHtml(items["CurrentDayBackColor"]);
      EditCalendarColorTorahEvent.BackColor = ColorTranslator.FromHtml(items["CalendarColorTorahEvent"]);
      EditCalendarColorSeason.BackColor = ColorTranslator.FromHtml(items["CalendarColorSeason"]);
      EditCalendarColorMoon.BackColor = ColorTranslator.FromHtml(items["CalendarColorMoon"]);
      EditCalendarColorFullMoon.BackColor = ColorTranslator.FromHtml(items["CalendarColorFullMoon"]);
      EditEventColorTorah.BackColor = ColorTranslator.FromHtml(items["EventColorTorah"]);
      EditEventColorSeason.BackColor = ColorTranslator.FromHtml(items["EventColorSeason"]);
      EditEventColorShabat.BackColor = ColorTranslator.FromHtml(items["EventColorShabat"]);
      EditEventColorMonth.BackColor = ColorTranslator.FromHtml(items["EventColorMonth"]);
      EditEventColorNext.BackColor = ColorTranslator.FromHtml(items["EventColorNext"]);
      EditNavigateTopColor.BackColor = ColorTranslator.FromHtml(items["NavigateTopColor"]);
      EditNavigateMiddleColor.BackColor = ColorTranslator.FromHtml(items["NavigateMiddleColor"]);
      EditNavigateBottomColor.BackColor = ColorTranslator.FromHtml(items["NavigateBottomColor"]);
      EditTextColor.BackColor = ColorTranslator.FromHtml(items["TextColor"]);
      EditTextBackground.BackColor = ColorTranslator.FromHtml(items["TextBackground "]);
      NavigationForm.Instance.PanelTop.BackColor = EditNavigateTopColor.BackColor;
      NavigationForm.Instance.PanelMiddle.BackColor = EditNavigateMiddleColor.BackColor;
      NavigationForm.Instance.PanelBottom.BackColor = EditNavigateBottomColor.BackColor;
      MainForm.Instance.CalendarText.ForeColor = EditTextColor.BackColor;
      MainForm.Instance.CalendarText.BackColor = EditTextBackground.BackColor;
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
      items.Add("MonthViewTextColor=" + ColorTranslator.ToHtml(EditCalendarColorDefaultText.BackColor));
      items.Add("MonthViewBackColor=" + ColorTranslator.ToHtml(EditCalendarColorEmpty.BackColor));
      items.Add("MonthViewNoDaysBackColor=" + ColorTranslator.ToHtml(EditCalendarColorNoDay.BackColor));
      items.Add("CurrentDayForeColor=" + ColorTranslator.ToHtml(EditCurrentDayForeColor.BackColor));
      items.Add("CurrentDayBackColor=" + ColorTranslator.ToHtml(EditCurrentDayBackColor.BackColor));
      items.Add("CalendarColorTorahEvent=" + ColorTranslator.ToHtml(EditCalendarColorTorahEvent.BackColor));
      items.Add("CalendarColorSeason=" + ColorTranslator.ToHtml(EditCalendarColorSeason.BackColor));
      items.Add("CalendarColorMoon=" + ColorTranslator.ToHtml(EditCalendarColorMoon.BackColor));
      items.Add("CalendarColorFullMoon=" + ColorTranslator.ToHtml(EditCalendarColorFullMoon.BackColor));
      items.Add("EventColorTorah=" + ColorTranslator.ToHtml(EditEventColorTorah.BackColor));
      items.Add("EventColorSeason=" + ColorTranslator.ToHtml(EditEventColorSeason.BackColor));
      items.Add("EventColorShabat=" + ColorTranslator.ToHtml(EditEventColorShabat.BackColor));
      items.Add("EventColorMonth=" + ColorTranslator.ToHtml(EditEventColorMonth.BackColor));
      items.Add("EventColorNext=" + ColorTranslator.ToHtml(EditEventColorNext.BackColor));
      items.Add("NavigateTopColor=" + ColorTranslator.ToHtml(EditNavigateTopColor.BackColor));
      items.Add("NavigateMiddleColor=" + ColorTranslator.ToHtml(EditNavigateMiddleColor.BackColor));
      items.Add("NavigateBottomColor=" + ColorTranslator.ToHtml(EditNavigateBottomColor.BackColor));
      items.Add("TextColor=" + ColorTranslator.ToHtml(EditTextColor.BackColor));
      items.Add("TextBackground=" + ColorTranslator.ToHtml(EditTextBackground.BackColor));
      File.WriteAllLines(SaveThemeDialog.FileName, items);
    }


  }

}
