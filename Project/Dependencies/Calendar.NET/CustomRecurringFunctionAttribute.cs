using System;

namespace Calendar.NET
{
    /// <summary>
    /// An attribute to mark Custom Recurring Functions
    /// </summary>
    public class CustomRecurringFunction : Attribute
    {
        private readonly string _name;
        private readonly string _description;

        /// <summary>
        /// Returns the name of the custom recurring function
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Returns a description of the custom recurring function
        /// </summary>
        public string Description
        {
            get { return _description; }
        }

        /// <summary>
        /// CustomRecurringFunction Constructor
        /// </summary>
        /// <param name="name">The name of the function</param>
        /// <param name="description">A description of the function</param>
        public CustomRecurringFunction(string name, string description)
        {
            _name = name;
            _description = description;
        }
        /// <summary>
        /// CustomRecurringFunction Constructor
        /// </summary>
        /// <param name="name">The name of the function</param>
        public CustomRecurringFunction(string name)
        {
            _name = name;
            _description = "";
        }
    }
}
