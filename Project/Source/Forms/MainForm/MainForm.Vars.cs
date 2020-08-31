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
/// <created> 2019-01 </created>
/// <edited> 2019-11 </edited>
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DandTSoftware.Timers;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private readonly Properties.Settings Settings = Program.Settings;

    /// <summary>
    /// Indicate if generation is in progress.
    /// </summary>
    public bool IsGenerating { get; private set; }

    /// <summary>
    /// Indicate last showned tooltip.
    /// </summary>
    private ToolTip LastToolTip = new ToolTip();

    private Point TrayIconMouse;

    private bool CanBallon = true;
    private bool NavigationTrayBallooned;

    private bool TimerMutex;

    private bool TimerErrorShown;

    private MidnightTimer TimerMidnight = new MidnightTimer();

    public TimeZoneInfo CurrentTimeZoneInfo { get; private set; }
    public float CurrentGPSLatitude { get; internal set; }
    public float CurrentGPSLongitude { get; internal set; }

    private void InitializeYearsInterval()
    {
      DateFirst = SQLiteDate.ToDateTime(DataSet.LunisolarDays.FirstOrDefault()?.Date ?? "");
      DateLast = SQLiteDate.ToDateTime(DataSet.LunisolarDays.LastOrDefault()?.Date ?? "");
      if ( DateFirst == DateTime.MinValue || DateLast == DateTime.MinValue || DateFirst >= DateLast )
        throw new ArgumentOutOfRangeException("DateFirst & DateLast in " + nameof(InitializeYearsInterval));
      YearFirst = DateFirst.Year;
      YearLast = DateLast.Year;
      YearsInterval = DateLast.Year - DateFirst.Year + 1;
      YearsIntervalArray = Enumerable.Range(DateFirst.Year, YearsInterval).ToArray();
    }

    public DateTime DateFirst { get; private set; }
    public DateTime DateLast { get; private set; }

    public int YearFirst { get; private set; }
    public int YearLast { get; private set; }
    public int YearsInterval { get; private set; }
    internal int[] YearsIntervalArray { get; private set; }

    public Data.DataSet.LunisolarDaysRow CurrentDay { get; private set; }

    private NullSafeDictionary<TorahEvent, bool> TorahEventRemindList
      = new NullSafeDictionary<TorahEvent, bool>();

    private NullSafeDictionary<TorahEvent, bool> TorahEventRemindDayList
      = new NullSafeDictionary<TorahEvent, bool>();

    internal readonly NullSafeList<Form> RemindCelebrationForms
      = new NullSafeList<Form>();

    internal readonly NullSafeStringList RemindCelebrationDates
      = new NullSafeStringList();

    internal readonly NullSafeDictionary<TorahEvent, DateTime?> LastCelebrationReminded
      = new NullSafeDictionary<TorahEvent, DateTime?>();

    internal readonly Dictionary<TorahEvent, ReminderForm> RemindCelebrationDayForms
      = new Dictionary<TorahEvent, ReminderForm>();

    internal DateTime? LastShabatReminded;

    internal ReminderForm ShabatForm;

    internal void ClearLists()
    {
      try
      {
        LockSessionForm.Instance?.Close();
        CelebrationsForm.Instance.Hide();
        NavigationForm.Instance.Hide();
        TorahEventRemindList.Clear();
        TorahEventRemindDayList.Clear();
        RemindCelebrationDates.Clear();
        foreach ( TorahEvent type in Enum.GetValues(typeof(TorahEvent)) )
          if ( type != TorahEvent.None )
          {
            TorahEventRemindList.Add(type, (bool)Settings["TorahEventRemind" + type.ToString()]);
            TorahEventRemindDayList.Add(type, (bool)Settings["TorahEventRemindDay" + type.ToString()]);
          }
        foreach ( Form form in RemindCelebrationForms.ToList() )
          form.Close();
        foreach ( Form form in RemindCelebrationDayForms.Values.ToList() )
          form.Close();
        if ( ShabatForm != null )
          ShabatForm.Close();
        LastShabatReminded = null;
        int min = Enum.GetValues(typeof(TorahEvent)).Cast<int>().Min();
        int max = Enum.GetValues(typeof(TorahEvent)).Cast<int>().Max();
        for ( int index = min; index <= max; index++ )
          if ( LastCelebrationReminded.ContainsKey((TorahEvent)index) )
            LastCelebrationReminded[(TorahEvent)index] = null;
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

  }

}
