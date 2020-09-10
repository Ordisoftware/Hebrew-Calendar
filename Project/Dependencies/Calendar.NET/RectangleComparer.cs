using System.Collections.Generic;
using System.Drawing;

namespace CodeProjectCalendar.NET
{
    public class RectangleComparer : IComparer<Rectangle>
    {
        public int Compare(Rectangle x, Rectangle y)
        {
            return x.Y.CompareTo(y.Y);
        }
    }
}
