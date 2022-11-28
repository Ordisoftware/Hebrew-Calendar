/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2022 Olivier Rogier.
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
/// <edited> 2022-08 </edited>
namespace Ordisoftware.Hebrew.Calendar;

using MoreLinq;

/// <summary>
/// Provides form to edit the preferences.
/// </summary>
/// <seealso cref="T:System.Windows.Forms.Form"/>
partial class PreferencesForm
{

  private void SetThemeLight()
  {
    EditCurrentDayForeColor.BackColor = Color.White;
    EditCurrentDayBackColor.BackColor = Color.Firebrick;
    EditCalendarColorActiveDay.BackColor = Color.LightSlateGray;
    EditSelectedDayBoxColor.BackColor = Color.Brown;
    EditCalendarColorHoverEffect.BackColor = Color.Silver;
    EditCalendarColorParashah.BackColor = Color.Indigo;
    EditCalendarColorTorahEvent.BackColor = Color.DarkRed;
    EditCalendarColorSeason.BackColor = Color.DarkGreen;
    EditCalendarColorMoon.BackColor = Color.DarkBlue;
    EditCalendarColorFullMoon.BackColor = CustomColor.VeryDarkGoldenrod;
    EditEventColorTorah.BackColor = CustomColor.VeryLightYellow;
    EditEventColorSeason.BackColor = CustomColor.HoneydewLight;
    EditEventColorShabat.BackColor = CustomColor.WhiteSmokeDark;
    EditEventColorMonth.BackColor = Color.AliceBlue;
    EditEventColorNext.BackColor = CustomColor.WhiteSmokeVeryDark;
    EditMonthViewBackColor.BackColor = Color.White;
    EditMonthViewTextColor.BackColor = Color.Black;
    EditMonthViewNoDaysBackColor.BackColor = CustomColor.WhiteSmokeVeryLight;
    MustRefreshMonthView = true;
  }

  private void SetThemeDark()
  {
    EditCurrentDayForeColor.BackColor = Color.White;
    EditCurrentDayBackColor.BackColor = CustomColor.RedDarker;
    EditCalendarColorActiveDay.BackColor = Color.LightGray;
    EditSelectedDayBoxColor.BackColor = CustomColor.RedDarker;
    EditCalendarColorHoverEffect.BackColor = Color.DarkGray;
    EditCalendarColorParashah.BackColor = Color.Plum;
    EditCalendarColorTorahEvent.BackColor = CustomColor.PlumLight;
    EditCalendarColorSeason.BackColor = CustomColor.ScreaminGreen;
    EditCalendarColorMoon.BackColor = CustomColor.ElectricBlue;
    EditCalendarColorFullMoon.BackColor = CustomColor.UnmellowYellowLight;
    EditEventColorTorah.BackColor = CustomColor.RifleGreenGolden;
    EditEventColorSeason.BackColor = CustomColor.VeryDarkGreen;
    EditEventColorShabat.BackColor = CustomColor.PurpleTaupeDark;
    EditEventColorMonth.BackColor = CustomColor.DarkMidnightBlue;
    EditEventColorNext.BackColor = CustomColor.BlackLight;
    EditMonthViewBackColor.BackColor = Color.Black;
    EditMonthViewTextColor.BackColor = Color.White;
    EditMonthViewNoDaysBackColor.BackColor = CustomColor.DimGrayDark;
    MustRefreshMonthView = true;
  }

  private void OpenTheme()
  {
    SystemManager.TryCatch(() => OpenThemeDialog.InitialDirectory = Settings.GetExportSettingsDirectory());
    if ( OpenThemeDialog.ShowDialog() != DialogResult.OK ) return;
    var items = new NullSafeOfStringDictionary<string>();
    if ( !items.LoadKeyValuePairs(OpenThemeDialog.FileName, "=") ) return;
    PanelCalendarColors.Controls.OfType<Panel>().ForEach(panel =>
    {
      string name = panel.Name.Substring(4);
      if ( items.TryGetValue(name, out var color) )
        panel.BackColor = ColorTranslator.FromHtml(color);
    });
    NavigationForm.Instance.PanelTop.BackColor = EditNavigateTopColor.BackColor;
    NavigationForm.Instance.PanelMiddle.BackColor = EditNavigateMiddleColor.BackColor;
    NavigationForm.Instance.PanelBottom.BackColor = EditNavigateBottomColor.BackColor;
    MainForm.Instance.TextReport.ForeColor = EditTextReportTextColor.BackColor;
    MainForm.Instance.TextReport.BackColor = EditTextReportBackColor.BackColor;
    MustRefreshMonthView = true;
  }

  private void SaveTheme()
  {
    SystemManager.TryCatch(() =>
    {
      SaveThemeDialog.InitialDirectory = Settings.GetExportSettingsDirectory();
      SaveThemeDialog.FileName = "Theme.ini";
    });
    if ( SaveThemeDialog.ShowDialog() != DialogResult.OK ) return;
    var items = new List<string>();
    PanelCalendarColors.Controls.OfType<Panel>().ForEach(panel => items.Add(makeLine(panel)));
    File.WriteAllLines(SaveThemeDialog.FileName, items);
    //
    static string makeLine(Panel panel)
    {
      return $"{panel.Name.Substring(4)}={ColorTranslator.ToHtml(panel.BackColor)}";
    }
  }

}
