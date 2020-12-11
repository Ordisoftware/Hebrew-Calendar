/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2020 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-08 </created>
/// <edited> 2020-12 </edited>
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide null safe of string dictionary.
  /// </summary>
  [Serializable]
  public class NullSafeOfStringDictionary<T> : Dictionary<T, string>
  {

    public NullSafeOfStringDictionary()
    {
    }

    public NullSafeOfStringDictionary(int capacity) : base(capacity)
    {
    }

    public NullSafeOfStringDictionary(IEqualityComparer<T> comparer) : base(comparer)
    {
    }

    public NullSafeOfStringDictionary(IDictionary<T, string> dictionary) : base(dictionary)
    {
    }

    public NullSafeOfStringDictionary(int capacity, IEqualityComparer<T> comparer) : base(capacity, comparer)
    {
    }

    public NullSafeOfStringDictionary(IDictionary<T, string> dictionary, IEqualityComparer<T> comparer) : base(dictionary, comparer)
    {
    }

    protected NullSafeOfStringDictionary(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public new string this[T key]
    {
      get
      {
        return ContainsKey(key) ? base[key] : null;
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

  /// <summary>
  /// Provide NullSafeOfStringDictionary helper.
  /// </summary>
  static public class NullSafeOfStringDictionaryHelper
  {
    static public bool LoadKeyValuePairs(this NullSafeOfStringDictionary<string> list,
                                         string filePath, 
                                         string separator, 
                                         bool showError = true)
    {
      try
      {
        list.Clear();
        foreach ( string line in File.ReadAllLines(filePath) )
        {
          var parts = line.SplitNoEmptyLines(separator);
          if ( parts.Length == 1 )
            list.Add(parts[0].Trim(), "");
          else
          if ( parts.Length == 2 )
            list.Add(parts[0].Trim(), parts[1].Trim());
          else
          if ( parts.Length > 2 )
            list.Add(parts[0].Trim(), parts.Skip(1).Select(v => v.Trim()).AsMultiSpace());
        }
        return true;
      }
      catch ( Exception ex )
      {
        if ( showError )
          MessageBox.Show(SysTranslations.LoadFileError.GetLang(filePath, ex.Message),
                          Globals.AssemblyTitle,
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Warning);
        return false;
      }
    }
  }

}
