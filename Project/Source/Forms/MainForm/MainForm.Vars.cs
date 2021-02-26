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
/// <created> 2019-01 </created>
/// <edited> 2021-01 </edited>
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DandTSoftware.Timers;
using MoreLinq;
using Ordisoftware.Core;
using LunisolarDaysRow = Ordisoftware.Hebrew.Calendar.Data.DataSet.LunisolarDaysRow;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class MainForm
  {

    private readonly Properties.Settings Settings = Program.Settings;

    private ToolTip LastToolTip = new ToolTip();

    private Icon TrayIconPause;
    private Icon TrayIconDefault;
    private Icon TrayIconEvent;
    private Point TrayIconMouse;

    private bool TrayIconCanBallon = true;
    private bool IsTrayBallooned;

    private bool TimerMutex;
    private bool TimerErrorShown;

    private MidnightTimer TimerMidnight = new MidnightTimer();

    private DateTime? LastVacuum = null;

    public float CurrentGPSLatitude { get; set; }
    public float CurrentGPSLongitude { get; set; }
    public TimeZoneInfo CurrentTimeZoneInfo { get; private set; }

    public DateTime DateFirst { get; private set; }
    public DateTime DateLast { get; private set; }
    public int YearFirst { get; private set; }
    public int YearLast { get; private set; }
    public int YearsInterval { get; private set; }
    public int[] YearsIntervalArray { get; private set; }

    public LunisolarDaysRow CurrentDay { get; private set; }

    public int CurrentDayYear
      => SQLiteDate.ToDateTime(CurrentDay?.Date ?? null).Year;

    private LunisolarDaysRow TodayDay
      => DataSet.LunisolarDays.FindByDate(SQLiteDate.ToString(DateTime.Today));

    private Parashah GetWeeklyParashah
      => ParashotTable.GetDefaultByID(TodayDay?.GetParashahReadingDay()?.ParashahID) ?? null;

    private Dictionary<TorahEvent, bool> TorahEventRemindList
      = new Dictionary<TorahEvent, bool>();

    private Dictionary<TorahEvent, bool> TorahEventRemindDayList
      = new Dictionary<TorahEvent, bool>();

    internal readonly NullSafeList<ReminderForm> RemindCelebrationForms
      = new NullSafeList<ReminderForm>();

    private readonly NullSafeStringList RemindCelebrationDates
      = new NullSafeStringList();

    private readonly Dictionary<TorahEvent, DateTime?> LastCelebrationReminded
      = new Dictionary<TorahEvent, DateTime?>();

    internal readonly Dictionary<TorahEvent, ReminderForm> RemindCelebrationDayForms
      = new Dictionary<TorahEvent, ReminderForm>();

    public DateTime? LastShabatReminded;
    internal ReminderForm ShabatForm;

    public void ClearLists()
    {
      SystemManager.TryCatchManage(() =>
      {
        TrayIcon.Icon = TrayIconDefault;
        Application.OpenForms.ToList().FirstOrDefault(f => f is EditDateBookmarksForm)?.Close();
        ParashotForm.Instance?.Close();
        CelebrationsBoardForm.Instance?.Close();
        NewMoonsBoardForm.Instance?.Close();
        TorahEventRemindList.Clear();
        TorahEventRemindDayList.Clear();
        RemindCelebrationDates.Clear();
        LastShabatReminded = null;
        ShabatForm?.Close();
        LockSessionForm.Instance?.Close();
        CurrentDay = null;
        foreach ( Form form in RemindCelebrationForms.ToList() ) form.Close();
        foreach ( Form form in RemindCelebrationDayForms.Values.ToList() ) form.Close();
        foreach ( var value in TorahCelebrations.Values )
        {
            TorahEventRemindList.Add(value, (bool)Settings["TorahEventRemind" + value.ToString()]);
            TorahEventRemindDayList.Add(value, (bool)Settings["TorahEventRemindDay" + value.ToString()]);
            LastCelebrationReminded[value] = null;
          }
      });
    }

  }

}
