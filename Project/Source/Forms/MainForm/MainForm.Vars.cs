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
/// <edited> 2021-07 </edited>
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DandTSoftware.Timers;
using MoreLinq;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class MainForm
  {

    // Active>SpecialDay:
    // true, true  = TrayIconEvent
    // true, false = TrayIconDefault
    // false, true  = TrayIconEventPause
    // false, false = TrayIconDefaultPause
    static private Dictionary<bool, NullSafeDictionary<bool, Icon>> TrayIcons
      = new Dictionary<bool, NullSafeDictionary<bool, Icon>>()
      {
        { true, new NullSafeDictionary<bool, Icon>() },
        { false, new NullSafeDictionary<bool, Icon>() }
      };

    static private readonly Properties.Settings Settings = Program.Settings;

    static private List<LunisolarDay> LunisolarDays => ApplicationDatabase.Instance.LunisolarDays;

    static internal List<Parashah> UserParashot { get; set; } = new List<Parashah>();

    private ToolTip LastToolTip = new ToolTip();

    private Point TrayIconMouse;

    private bool TrayIconCanBallon = true;
    private bool IsTrayBallooned;

    private bool TimerMutex;
    private bool TimerErrorShown;

    private bool IsReminderPaused;

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

    public LunisolarDay CurrentDay { get; private set; }

    public int CurrentDayYear
      => CurrentDay?.Date.Year ?? 0;

    private Dictionary<TorahEvent, bool> TorahEventRemindList
      = new Dictionary<TorahEvent, bool>();

    private Dictionary<TorahEvent, bool> TorahEventRemindDayList
      = new Dictionary<TorahEvent, bool>();

    internal readonly NullSafeList<ReminderForm> RemindCelebrationForms
      = new NullSafeList<ReminderForm>();

    private readonly List<DateTime> RemindCelebrationDates
      = new List<DateTime>();

    private readonly Dictionary<TorahEvent, DateTime?> LastCelebrationReminded
      = new Dictionary<TorahEvent, DateTime?>();

    internal readonly Dictionary<TorahEvent, ReminderForm> RemindCelebrationDayForms
      = new Dictionary<TorahEvent, ReminderForm>();

    private DateTime? LastShabatReminded;
    internal ReminderForm ShabatForm = null;

    public void ClearLists()
    {
      SystemManager.TryCatchManage(() =>
      {
        Text = Globals.AssemblyTitle;
        TrayIcon.Icon = TrayIcons[!IsReminderPaused][Settings.TrayIconUseSpecialDayIcon && IsSpecialDay];
        Application.OpenForms.GetAll().FirstOrDefault(f => f is EditDateBookmarksForm)?.Close();
        ParashotForm.Instance?.Close();
        CelebrationsBoardForm.Instance?.Close();
        NewMoonsBoardForm.Instance?.Close();
        NextCelebrationsForm.Instance?.Hide();
        TorahEventRemindList.Clear();
        TorahEventRemindDayList.Clear();
        RemindCelebrationDates.Clear();
        LastShabatReminded = null;
        ShabatForm?.Close();
        LockSessionForm.Instance?.Close();
        CurrentDay = null;
        foreach ( Form form in RemindCelebrationForms.ToList() ) form.Close();
        foreach ( Form form in RemindCelebrationDayForms.Values.ToList() ) form.Close();
        foreach ( var value in TorahCelebrations.MajorEvents )
        {
          TorahEventRemindList.Add(value, (bool)Settings["TorahEventRemind" + value.ToString()]);
          TorahEventRemindDayList.Add(value, (bool)Settings["TorahEventRemindDay" + value.ToString()]);
          LastCelebrationReminded[value] = null;
        }
      });
    }

  }

}
