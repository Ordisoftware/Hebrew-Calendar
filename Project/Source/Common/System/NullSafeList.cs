using System;
using System.Linq;
using System.Collections.Generic;

namespace Ordisoftware.HebrewCommon
{

  // TODO Test

  public class NullSafeList<T> : List<T>
  {
    public new T this[int index]
    {
      get
      {
        return index >= 0 && index < Count ? base[index] : default(T);
      }
      set
      {
        if ( index >= 0 && index < Count )
          base[index] = value;
        else
        {
          Capacity = index + 1;
          AddRange(Enumerable.Repeat(default(T), index + 1 - Count));
          base[index] = value;
        }
      }
    }
  }

}
