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
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using DandTSoftware.Timers;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    /// <summary>
    /// Indicate the singleton instance.
    /// </summary>
    static public readonly MainForm Instance;

    /// <summary>
    /// Static constructor.
    /// </summary>
    static MainForm()
    {
      Instance = new MainForm();
      foreach ( TorahEvent value in Enum.GetValues(typeof(TorahEvent)) )
        Instance.LastCelebrationReminded.Add(value, null);
    }

    /// <summary>
    /// Indicate if generation is in progress.
    /// </summary>
    internal bool IsGenerating;

    /// <summary>
    /// Indicate last showned tooltip.
    /// </summary>
    private ToolTip LastToolTip = new ToolTip();

    private Point TrayIconMouse;

    private bool CanBallon = true;

    private bool NavigationTrayBallooned;

    private bool TimerMutex;

    private bool TimerErrorShown;

    private MidnightTimer MidnightTimer = new MidnightTimer();

    internal TimeZoneInfo CurrentTimeZoneInfo;

    internal Data.DataSet.LunisolarDaysRow CurrentDay { get; private set; }

    internal int YearFirst { get; private set; }
    internal DateTime DateFirst { get; private set; }

    internal int YearLast { get; private set; }
    internal DateTime DateLast { get; private set; }

    private int ProgressCount;

    private Dictionary<TorahEvent, bool> TorahEventRemindList
      = new Dictionary<TorahEvent, bool>();

    private Dictionary<TorahEvent, bool> TorahEventRemindDayList
      = new Dictionary<TorahEvent, bool>();

    internal readonly List<Form> RemindCelebrationForms
      = new List<Form>();

    internal readonly List<string> RemindCelebrationDates
      = new List<string>();

    internal readonly Dictionary<TorahEvent, DateTime?> LastCelebrationReminded
      = new Dictionary<TorahEvent, DateTime?>();

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
            TorahEventRemindList.Add(type, (bool)Program.Settings["TorahEventRemind" + type.ToString()]);
            TorahEventRemindDayList.Add(type, (bool)Program.Settings["TorahEventRemindDay" + type.ToString()]);
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
