using System;
using System.Drawing;

namespace Calendar.NET
{
    /// <summary>
    /// An enumeration of built-in recurring event frequencies
    /// </summary>
    public enum RecurringFrequencies
    {
        /// <summary>
        /// Indicates that the event is non recurring will occur only one time
        /// </summary>
        None = 0,
        /// <summary>
        /// Indicates that the event will occur every day
        /// </summary>
        Daily = 1,
        /// <summary>
        /// Indicates that the event will occur every week day (Mon - Fri)
        /// </summary>
        EveryWeekday = 2,
        /// <summary>
        /// Indicates that the event will occur every Mon, Wed and Fri
        /// </summary>
        EveryMonWedFri = 3,
        /// <summary>
        /// Indicates that the event will occur every Tuesday and Thursday
        /// </summary>
        EveryTueThurs = 4,
        /// <summary>
        /// Indicates that the event will occur every week
        /// </summary>
        Weekly = 5,
        /// <summary>
        /// Indicates that the event will occur every month
        /// </summary>
        Monthly = 6,
        /// <summary>
        /// Indicates that the event will occur once a year, on the month and day specified
        /// </summary>
        Yearly = 7,
        /// <summary>
        /// Indicates that the event will occur every weekend on Saturday and Sunday
        /// </summary>
        EveryWeekend = 8,
        /// <summary>
        /// Indicates that the recuring schedule of this event is unique
        /// </summary>
        Custom = 99
    }

    /// <summary>
    /// An interface for creating event types
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// The Date that the event occurs
        /// </summary>
        DateTime Date { get; set; }
        /// <summary>
        /// True if the event is enabled, otherwise false
        /// </summary>
        bool Enabled { get; set; }
        /// <summary>
        /// A value indicating how often the event occurs
        /// </summary>
        RecurringFrequencies RecurringFrequency { get; set; }
        /// <summary>
        /// The name of the event
        /// </summary>
        string EventText { get; set; }
        /// <summary>
        /// A value indicating the length of the event, in hours.
        /// </summary>
        float EventLengthInHours { get; set; }
        /// <summary>
        /// The color that the event show up in on the calendar
        /// </summary>
        Color EventColor { get; set; }
        /// <summary>
        /// The font describing the appearance of the event
        /// </summary>
        Font EventFont { get; set; }
        /// <summary>
        /// The text color of the event
        /// </summary>
        Color EventTextColor { get; set; }
        /// <summary>
        /// The ranking of the event that determines the order in which it is displayed on a particular day
        /// </summary>
        int Rank { get; set; }
        /// <summary>
        /// True if the time component of the date can be ignored
        /// </summary>
        bool IgnoreTimeComponent { get; set; }
        /// <summary>
        /// True if the event details cannot be modified
        /// </summary>
        bool ReadOnlyEvent { get; set; }
        /// <summary>
        /// True if a tooltip should be displayed when hovering over the event
        /// </summary>
        bool TooltipEnabled { get; set; }
        /// <summary>
        /// If this is a recurring event, set this to true to make the event show up only from the day specified forward
        /// </summary>
        bool ThisDayForwardOnly { get; set; }
        /// <summary>
        /// Set this to a custom function that will automatically determine if the event should be rendered on a given day.
        /// This is only executed if <see cref="RecurringFrequency"/> is set to custom.
        /// </summary>
        CustomRecurringFrequenciesHandler CustomRecurringFunction { get; set; }
        /// <summary>
        /// A function for cloning an event instance
        /// </summary>
        /// <returns>A cloned <see cref="IEvent"/></returns>
        IEvent Clone();
    }

    /// <summary>
    /// A delegate for creating custom recurring frequencies
    /// </summary>
    /// <param name="evnt">The <see cref="IEvent"/> in question</param>
    /// <param name="day">The day in question</param>
    /// <returns>Should return a boolean value that indicates if the event should be rendered on the day passed in</returns>
    public delegate bool CustomRecurringFrequenciesHandler(IEvent evnt, DateTime day);
}
