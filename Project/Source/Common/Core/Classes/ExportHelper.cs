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
/// <created> 2020-12 </created>
/// <edited> 2021-01 </edited>
using System;
using System.Linq;
using EnumsNET;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide export helper.
  /// </summary>
  static public partial class ExportHelper
  {

    static public NullSafeOfStringDictionary<T> CreateExportTargets<T>(params T[] list)
      where T : struct, Enum
    {
      var result = new NullSafeOfStringDictionary<T>();
      foreach ( var value in Enums.GetValues<T>() )
        if ( list.Length == 0 || list.Contains(value) )
          result.Add(value, "." + value.ToString().ToLower());
      return result;
    }

    static public NullSafeOfStringDictionary<T> SetSupported<T>(this NullSafeOfStringDictionary<T> values, params T[] list)
      where T : struct, Enum
    {
      foreach ( var pair in values.Where(p => !list.Contains(p.Key)).ToList() )
        values.Remove(pair.Key);
      return values;
    }

    static public NullSafeOfStringDictionary<T> SetUnsupported<T>(this NullSafeOfStringDictionary<T> values, params T[] list)
      where T : struct, Enum
    {
      foreach ( var pair in values.Where(p => list.Contains(p.Key)).ToList() )
        values.Remove(pair.Key);
      return values;
    }

    static public string CreateFilters<T>(this NullSafeOfStringDictionary<T> values)
      where T : struct, Enum
    {
      string str = SysTranslations.FileExtensionFilter.GetLang();
      var list = values.Select(v => $"{string.Format(str, v.Key)}|*{v.Value}");
      return string.Join("|", list);
    }

  }

}
