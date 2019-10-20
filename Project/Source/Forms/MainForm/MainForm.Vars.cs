/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
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
/// <edited> 2019-10 </edited>
using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
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
      foreach ( TorahEventType value in Enum.GetValues(typeof(TorahEventType)) )
        Instance.LastCelebrationReminded.Add(value, null);
    }

    /// <summary>
    /// Indicate if the application is ready for the user.
    /// </summary>
    public bool IsReady { get; private set; }

    /// <summary>
    /// Indicate if generation is in progress.
    /// </summary>
    internal bool IsGenerating = false;

    /// <summary>
    /// Indicate if application can be closed.
    /// </summary>
    private bool AllowClose = false;

    /// <summary>
    /// INdicate last showned tooltip.
    /// </summary>
    private ToolTip LastToolTip = new ToolTip();

    private Point TrayIconMouse;

    private bool CanBallon = true;

    private bool NavigationTrayBallooned;

    private bool TimerErrorShown = false;

    internal Data.LunisolarCalendar.LunisolarDaysRow CurrentDay { get; private set; }

    internal int YearFirst;
    internal DateTime DateFirst;

    internal int YearLast;
    internal DateTime DateLast;

    private Dictionary<TorahEventType, bool> TorahEventRemindList
      = new Dictionary<TorahEventType, bool>();

    private Dictionary<TorahEventType, bool> TorahEventRemindDayList
      = new Dictionary<TorahEventType, bool>();

    private void InitRemindLists()
    {
      try
      {
        TorahEventRemindList.Clear();
        TorahEventRemindDayList.Clear();
        foreach ( TorahEventType type in Enum.GetValues(typeof(TorahEventType)) )
          if ( type != TorahEventType.None )
          {
            TorahEventRemindList.Add(type, (bool)Program.Settings["TorahEventRemind" + type.ToString()]);
            TorahEventRemindDayList.Add(type, (bool)Program.Settings["TorahEventRemindDay" + type.ToString()]);
          }
      }
      catch
      {
      }
    }

    internal readonly List<Form> RemindCelebrationForms
      = new List<Form>();

    internal readonly List<string> RemindCelebrationDates
      = new List<string>();

    internal readonly Dictionary<TorahEventType, DateTime?> LastCelebrationReminded
      = new Dictionary<TorahEventType, DateTime?>();

    internal readonly Dictionary<TorahEventType, ReminderForm> RemindCelebrationDayForms
      = new Dictionary<TorahEventType, ReminderForm>();

    internal DateTime? LastShabatReminded = null;

    internal ReminderForm ShabatForm;

    internal void ClearLists()
    {
      try
      {
        CelebrationsForm.Instance.Hide();
        NavigationForm.Instance.Hide();
        foreach ( Form form in RemindCelebrationForms.ToList() )
          form.Close();
        foreach ( Form form in RemindCelebrationDayForms.Values.ToList() )
          form.Close();
        if ( ShabatForm != null )
          ShabatForm.Close();
        LastShabatReminded = null;
        int min = Enum.GetValues(typeof(TorahEventType)).Cast<int>().Min();
        int max = Enum.GetValues(typeof(TorahEventType)).Cast<int>().Max();
        for ( int index = min; index < max; index++ )
          if ( LastCelebrationReminded.ContainsKey((TorahEventType)index) )
            LastCelebrationReminded[(TorahEventType)index] = null;
        RemindCelebrationDates.Clear();
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

  }

}
