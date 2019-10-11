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
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

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

    private Dictionary<TorahEventType, bool> TorahEventRemindList
      = new Dictionary<TorahEventType, bool>();

    private Dictionary<TorahEventType, bool> TorahEventDayRemindList
      = new Dictionary<TorahEventType, bool>();

    private void InitRemindLists()
    {
      TorahEventRemindList.Clear();
      TorahEventDayRemindList.Clear();
      foreach ( TorahEventType type in Enum.GetValues(typeof(TorahEventType)) )
        if ( type != TorahEventType.None )
          try
          {
            TorahEventRemindList.Add(type, (bool)Program.Settings["TorahEventRemind" + type.ToString()]);
            TorahEventDayRemindList.Add(type, (bool)Program.Settings["TorahEventDayRemind" + type.ToString()]);
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
      int min = Enum.GetValues(typeof(TorahEventType)).Cast<int>().Min();
      int max = Enum.GetValues(typeof(TorahEventType)).Cast<int>().Max();
      foreach ( Form item in RemindCelebrationForms.ToList() )
        item.Close();
      RemindCelebrationDates.Clear();
      for ( int index = min; index < max; index++ )
        if ( LastCelebrationReminded.ContainsKey((TorahEventType)index) )
          LastCelebrationReminded[(TorahEventType)index] = null;
      for ( int index = min; index < max; index++ )
        if ( RemindCelebrationDayForms.ContainsKey((TorahEventType)index) )
          RemindCelebrationDayForms[(TorahEventType)index].Close();
      RemindCelebrationDayForms.Clear();
      LastShabatReminded = null;
      if ( ShabatForm != null )
      {
        ShabatForm.Close();
        ShabatForm = null;
      }
    }

  }

}
