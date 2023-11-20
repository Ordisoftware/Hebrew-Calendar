/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2023 Olivier Rogier.
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
/// <edited> 2023-07 </edited>
namespace Ordisoftware.Hebrew.Calendar;

using CodeProjectCalendar.NET;
using DandTSoftware.Timers;

public partial class MainForm
{

  // Active>SpecialDay:
  // true, true  = TrayIconEvent
  // true, false = TrayIconDefault
  // false, true  = TrayIconEventPause
  // false, false = TrayIconDefaultPause
  static private readonly Dictionary<bool, NullSafeDictionary<bool, Icon>> TrayIcons = new()
  {
    { true, new NullSafeDictionary<bool, Icon>() },
    { false, new NullSafeDictionary<bool, Icon>() }
  };

  static private readonly Properties.Settings Settings = Program.Settings;

  static private HebrewDatabase HebrewDatabase => HebrewDatabase.Instance;

  static private ApplicationDatabase DBApp => ApplicationDatabase.Instance;

  static private List<LunisolarDayRow> LunisolarDays => DBApp.LunisolarDays;

  static private List<DateBookmarkRow> Bookmarks => DBApp.DateBookmarks;

  static internal List<Parashah> UserParashot { get; set; } = [];

  static internal Dictionary<DateTime, CustomEvent[]> CalendarEventsGrouped { get; private set; }

  private readonly ToolTip LastToolTip = new();

  private Point TrayIconMouse;

  private bool TrayIconCanBallon = true;
  private bool IsTrayBallooned;

  private bool TimerMutex;
  private bool TimerErrorShown;

  private bool IsReminderPaused;

  private readonly MidnightTimer TimerMidnight = new();

  public float CurrentGPSLatitude { get; set; }
  public float CurrentGPSLongitude { get; set; }
  public TimeZoneInfo CurrentTimeZoneInfo { get; private set; }

  public DateTime DateFirst { get; private set; }
  public DateTime DateLast { get; private set; }
  public int YearFirst { get; private set; }
  public int YearLast { get; private set; }
  public int YearsInterval { get; private set; }
  public int[] YearsIntervalArray { get; private set; }

  public LunisolarDayRow CurrentDay { get; private set; }

  public int CurrentDayYear => CurrentDay?.Date.Year ?? 0;

  private DateTime? _DateSelected;
  public DateTime? DateSelected
  {
    get => _DateSelected;
    private set
    {
      if ( _DateSelected == value ) return;
      _DateSelected = value == DateTime.Today ? null : value;
      if ( Settings.CurrentView == ViewMode.Month )
        MonthlyCalendar.Refresh();
    }
  }

  private LunisolarDayRow ContextMenuDayCurrentEvent;

  private readonly Dictionary<TorahCelebrationDay, bool> TorahEventRemindList = [];

  private readonly Dictionary<TorahCelebrationDay, bool> TorahEventRemindDayList = [];

  internal readonly NullSafeList<ReminderForm> RemindCelebrationForms = [];

  private readonly List<DateTime> RemindCelebrationDates = [];

  private readonly Dictionary<TorahCelebrationDay, DateTime?> LastCelebrationReminded = [];

  internal readonly Dictionary<TorahCelebrationDay, ReminderForm> RemindCelebrationDayForms = [];

  private DateTime? LastShabatReminded;

  internal ReminderForm ShabatForm;

  [SuppressMessage("Performance", "U2U1203:Use foreach efficiently", Justification = "The collection is modified")]
  [SuppressMessage("Performance", "U2U1210:Do not materialize an IEnumerable<T> unnecessarily", Justification = "N/A")]
  public void ClearLists()
  {
    if ( Globals.IsExiting ) return;
    SystemManager.TryCatchManage(() =>
    {
      Text = Globals.AssemblyTitle;
      TrayIcon.Icon = TrayIcons[!IsReminderPaused][Settings.TrayIconUseSpecialDayIcon && IsSpecialDay];
      Application.OpenForms.GetAll(f => f is ManageBookmarksForm)?.ToList().ForEach(f => f.Close());
      NoticesForm.Instance?.Close();
      ParashotForm.Instance?.Close();
      CelebrationsBoardForm.Instance?.Close();
      CelebrationVersesBoardForm.Instance?.Close();
      NewMoonsBoardForm.Instance?.Close();
      NextCelebrationsForm.Instance?.Hide();
      TorahEventRemindList?.Clear();
      TorahEventRemindDayList?.Clear();
      RemindCelebrationDates?.Clear();
      LastShabatReminded = null;
      ShabatForm?.Close();
      LockSessionForm.Instance?.Close();
      CurrentDay = null;
      foreach ( var form in RemindCelebrationForms.ToList() ) form.Close();
      foreach ( var form in RemindCelebrationDayForms.Values.ToList() ) form.Close();
      foreach ( var value in TorahCelebrationSettings.ManagedEvents )
      {
        TorahEventRemindList.Add(value, (bool)Settings[PreferencesForm.TorahEventRemindPrefix + value]);
        TorahEventRemindDayList.Add(value, (bool)Settings[PreferencesForm.TorahEventRemindDayPrefix + value]);
        LastCelebrationReminded[value] = null;
      }
    });
  }

}
