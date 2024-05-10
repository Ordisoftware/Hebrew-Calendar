using System;
using System.Drawing;

namespace CodeProjectCalendar.NET
{
  /// <summary>
  /// An event that defines a holiday
  /// </summary>
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP008:Don't assign member with injected and created disposables", Justification = "N/A")]
  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "<En attente>")]
  [SuppressMessage("Naming", "VSSpell001:Spell Check", Justification = "N/A")]
  public class HolidayEvent : IEvent
  {
    // ORDISOFTWARE MODIF BEGIN
    public string ToolTipText { get; set; }
    // ORDISOFTWARE MODIF END

    public int Rank
    {
      get;
      set;
    }

    public float EventLengthInHours
    {
      get;
      set;
    }

    public bool Enabled
    {
      get;
      set;
    }

    public CustomRecurringFrequenciesHandler CustomRecurringFunction
    {
      get;
      set;
    }

    public bool IgnoreTimeComponent
    {
      get;
      set;
    }

    public bool ReadOnlyEvent
    {
      get;
      set;
    }

    public DateTime Date
    {
      get;
      set;
    }

    public Color EventColor
    {
      get;
      set;
    }

    public Font EventFont
    {
      get;
      set;
    }

    public string EventText
    {
      get;
      set;
    }

    public Color EventTextColor
    {
      get;
      set;
    }

    public RecurringFrequencies RecurringFrequency
    {
      get;
      set;
    }

    public bool TooltipEnabled
    {
      get;
      set;
    }

    public bool ThisDayForwardOnly
    {
      get;
      set;
    }

    /// <summary>
    /// HolidayEvent Constructor
    /// </summary>
    public HolidayEvent()
    {
      EventColor = CustomColor.ArgentinianBlueDark;
      EventFont = new Font("Arial", 8, FontStyle.Bold);
      EventTextColor = Color.White;
      Rank = 1;
      EventLengthInHours = 24;
      ReadOnlyEvent = true;
      Enabled = true;
      IgnoreTimeComponent = true;
      TooltipEnabled = true;
      ThisDayForwardOnly = false;
      RecurringFrequency = RecurringFrequencies.None;
    }

    [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP003:Dispose previous before re-assigning", Justification = "N/A")]
    public IEvent Clone()
    {
      return new HolidayEvent
      {
        CustomRecurringFunction = CustomRecurringFunction,
        Date = Date,
        Enabled = Enabled,
        EventColor = EventColor,
        EventFont = EventFont,
        EventText = EventText,
        EventTextColor = EventTextColor,
        IgnoreTimeComponent = IgnoreTimeComponent,
        Rank = Rank,
        ReadOnlyEvent = ReadOnlyEvent,
        RecurringFrequency = RecurringFrequency,
        ThisDayForwardOnly = ThisDayForwardOnly,
        EventLengthInHours = EventLengthInHours,
        TooltipEnabled = TooltipEnabled
      };
    }
  }
}
