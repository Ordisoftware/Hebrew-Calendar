using System;
using System.Linq;

namespace Ordisoftware.HebrewCalendar
{

  // From https://stackoverflow.com/questions/642542/how-to-get-next-or-previous-enum-value-in-c-sharp
  static public class EnumHelper
  {
      public static T Next<T>(this T v) where T : struct
      {
        return Enum.GetValues(v.GetType()).Cast<T>().Concat(new[] { default(T) })
               .SkipWhile(e => !v.Equals(e))
               .Skip(1)
               .First();
      }

      public static T Previous<T>(this T v) where T : struct
      {
        return Enum.GetValues(v.GetType()).Cast<T>().Concat(new[] { default(T) })
               .Reverse()
               .SkipWhile(e => !v.Equals(e))
               .Skip(1)
               .First();
      }

  }

}
