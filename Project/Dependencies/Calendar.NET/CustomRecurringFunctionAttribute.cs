using System;

namespace CodeProjectCalendar.NET
{
  /// <summary>
  /// An attribute to mark Custom Recurring Functions
  /// </summary>
  [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
  public class CustomRecurringAttribute : Attribute
  {

    /// <summary>
    /// Returns the name of the custom recurring function
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Returns a description of the custom recurring function
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// CustomRecurringFunction Constructor
    /// </summary>
    /// <param name="name">The name of the function</param>
    /// <param name="description">A description of the function</param>
    public CustomRecurringAttribute(string name, string description)
    {
      Name = name;
      Description = description;
    }
    /// <summary>
    /// CustomRecurringFunction Constructor
    /// </summary>
    /// <param name="name">The name of the function</param>
    public CustomRecurringAttribute(string name)
    {
      Name = name;
      Description = "";
    }
  }
}
