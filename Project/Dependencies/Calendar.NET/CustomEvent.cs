using System;
using System.Drawing;
using Ordisoftware.Hebrew.Calendar;

namespace CodeProjectCalendar.NET
{
  /// <summary>
  /// A custom or user-defined event
  /// </summary>
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP008:Don't assign member with injected and created disposables", Justification = "N/A")]
  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "<En attente>")]
  [SuppressMessage("Naming", "VSSpell001:Spell Check", Justification = "<En attente>")]
  public class CustomEvent : IEvent
  {
    // ORDISOFTWARE MODIF BEGIN
    public string ToolTipText { get; set; }
    public bool IsHebrew { get; set; }
    public bool IsSeparator => Section == CalendarSection.Separator;
    public CalendarSection Section { get; set; }
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
    /// CustomEvent Constructor
    /// </summary>
    public CustomEvent()
    {
      EventColor = CustomColor.CoralRedLight;
      EventFont = new Font("Arial", 8, FontStyle.Bold);
      EventTextColor = Color.White;
      Rank = 2;
      EventLengthInHours = 1.0f;
      ReadOnlyEvent = false;
      Enabled = true;
      IgnoreTimeComponent = false;
      TooltipEnabled = true;
      ThisDayForwardOnly = true;
      RecurringFrequency = RecurringFrequencies.None;
    }

    [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP003:Dispose previous before re-assigning", Justification = "N/A")]
    public IEvent Clone()
    {
      return new CustomEvent
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
