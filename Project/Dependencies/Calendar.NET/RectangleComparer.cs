using System.Collections.Generic;
using System.Drawing;

namespace CodeProjectCalendar.NET
{
  [SuppressMessage("Refactoring", "GCop638:Shorten this method by defining it as expression-bodied.", Justification = "<En attente>")]
  [SuppressMessage("Naming", "GCop204:Rename the variable '{0}' to something clear and meaningful.", Justification = "<En attente>")]
  public class RectangleComparer : IComparer<Rectangle>
  {
    public int Compare(Rectangle x, Rectangle y)
    {
      return x.Y.CompareTo(y.Y);
    }
  }
}
