using System;
using System.Collections.Generic;

namespace Ordisoftware.HebrewCommon
{

  public class NullSafeDictionary<TKey, TValue> : Dictionary<TKey, TValue> 
  {
    public new TValue this[TKey key]
    {
      get
      {
          return ContainsKey(key) ? base[key] : default(TValue);
      }
      set
      {
        if ( ContainsKey(key) )
          base[key] = value;
        else
          Add(key, value);
      }
    }
  }

}
