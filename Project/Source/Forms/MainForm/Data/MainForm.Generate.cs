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
/// <created> 2016-04 </created>
/// <edited> 2021-09 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class MainForm
{

  /// <summary>
  /// Checks if the calendar must be generated again in it comes near the end.
  /// </summary>
  private string CheckRegenerateCalendar(bool auto = false, bool force = false, bool checkover = false)
  {
    try
    {
      if ( checkover && Settings.AutoRegenerate && YearsInterval > Settings.AutoGenerateYearsInternal )
        if ( Settings.AskRegenerateIfIntervalGreater )
        {
          string msg = AppTranslations.AskToRegenerate.GetLang(Settings.AutoGenerateYearsInternal, YearsInterval);
          DisplayManager.QueryYesNoCancel(msg,
          () => force = true,
          null,
          () => Settings.AskRegenerateIfIntervalGreater = false);
        }
      if ( force || DateTime.Today.Year >= YearLast - Program.GenerateIntervalPreviousYears )
        if ( force || auto || Settings.AutoRegenerate )
        {
          var interval = new YearsIntervalItem(Settings.AutoGenerateYearsInternal);
          int year = DateTime.Today.Year - Program.GenerateIntervalPreviousYears;
          int yearFirst = year - interval.YearsBefore;
          int yearLast = year + interval.YearsAfter - 1;
          return DoGenerate(new Tuple<int, int>(yearFirst, yearLast), EventArgs.Empty);
        }
        else
          ActionGenerate_Click(ActionGenerate, null);
    }
    catch ( Exception ex )
    {
      ex.Manage();
    }
    return null;
  }

  private string DoGenerate(object sender, EventArgs e)
  {
    try
    {
      if ( e != null ) TimerReminder.Enabled = false;
      MenuTray.Enabled = false;
      try
      {
        int yearFirst;
        int yearLast;
        if ( sender != null )
          if ( sender is Tuple<int, int> values )
          {
            yearFirst = values.Item1;
            yearLast = values.Item2;
          }
          else
          {
            if ( !SelectYearsForm.Run(e != null, out yearFirst, out yearLast) )
              return null;
          }
        else
        {
          yearFirst = YearFirst;
          yearLast = YearLast;
        }
        ClearLists();
        Text = Globals.AssemblyTitle;
        LabelSubTitleCalendar.Text = string.Empty;
        LabelSubTitleGPS.Text = string.Empty;
        LabelSubTitleOmer.Text = string.Empty;
        InitializeCurrentTimeZone();
        return CreateData(yearFirst, yearLast);
      }
      finally
      {
        MenuTray.Enabled = true;
        UpdateButtons();
        if ( e != null )
        {
          DateSelected = null;
          GoToDate(DateTime.Today);
          LoadMenuBookmarks(this);
          TimerReminder.Enabled = true;
          TimerReminder_Tick(null, null);
        }
        else
        if ( DateSelected.HasValue )
          if ( DateSelected < DateFirst || DateSelected > DateLast )
            DateSelected = null;
      }
    }
    catch ( Exception ex )
    {
      ex.Manage();
      return null;
    }
  }

}
