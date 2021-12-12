/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2021 Olivier Rogier.
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
/// <edited> 2021-02 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides null safe of string dictionary.
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
/// Provides NullSafeOfStringDictionary helper.
/// </summary>
static class NullSafeOfStringDictionaryHelper
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
        if ( !line.StartsWith(";") && !line.StartsWith("//") )
        {
          var parts = line.SplitNoEmptyLines(separator);
          if ( parts.Length == 1 )
            list.Add(parts[0].Trim(), string.Empty);
          else
          if ( parts.Length == 2 )
            list.Add(parts[0].Trim(), parts[1].Trim());
          else
          if ( parts.Length > 2 )
            list.Add(parts[0].Trim(), string.Join(separator, parts.Skip(1)));
        }
      return true;
    }
    catch ( FileNotFoundException )
    {
      if ( showError )
        MessageBox.Show(SysTranslations.FileNotFound.GetLang(filePath),
                        Globals.AssemblyTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
      return false;
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

  static public bool SaveKeyValuePairs(this NullSafeOfStringDictionary<string> list,
                                       string filePath,
                                       string separator,
                                       bool showError = true)
  {
    using var stream = File.CreateText(filePath);
    try
    {
      foreach ( var item in list )
        if ( !item.Key.StartsWith(";") && !item.Key.StartsWith("//") )
          stream.WriteLine(item.Key + separator + item.Value);
        else
          stream.WriteLine(item.Key);
      stream.Close();
      return true;
    }
    catch ( FileNotFoundException )
    {
      if ( showError )
        MessageBox.Show(SysTranslations.FileNotFound.GetLang(filePath),
                        Globals.AssemblyTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
      return false;
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
