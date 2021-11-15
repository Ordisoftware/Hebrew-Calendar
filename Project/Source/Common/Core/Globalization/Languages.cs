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
/// <created> 2016-04 </created>
/// <edited> 2021-01 </edited>
using System;
using System.Linq;
using System.Globalization;
using EnumsNET;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Supported languages enum.
  /// </summary>
  public enum Language
  {
    None,
    EN,
    FR
  }

  /// <summary>
  /// Indicates supported languages.
  /// </summary>
  static class Languages
  {

    /// <summary>
    /// Indicates language codes.
    /// </summary>
    static public readonly NullSafeOfEnumDictionary<string, Language> Values;

    /// <summary>
    /// Indicates language codes.
    /// </summary>
    static public readonly NullSafeOfStringDictionary<Language> Codes;

    /// <summary>
    /// Indicates managed languages.
    /// </summary>
    static public readonly Language[] Managed;

    /// <summary>
    /// Indicates default language.
    /// </summary>
    static public readonly Language Default = Language.EN;

    /// <summary>
    /// Indicates current language code.
    /// </summary>
    static public string CurrentCode => Codes[Current];

    /// <summary>
    /// Indicates current language.
    /// </summary>
    static public Language Current
    {
      get
      {
        string lang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        var result = Values[lang];
        if ( !Managed.Contains(result) ) result = Default;
        return result;
      }
    }

    /// <summary>
    /// Static constructor.
    /// </summary>
    static Languages()
    {
      try
      {
        Managed = Enums.GetValues<Language>().Skip(1).ToArray();
        Codes = new NullSafeOfStringDictionary<Language>(Managed.ToDictionary(v => v, v => v.ToString().ToLower()));
        Values = new NullSafeOfEnumDictionary<string, Language>(Codes.ToDictionary(v => v.Value, v => v.Key));
      }
      catch ( Exception ex )
      {
        string str = "Exception in Language static class constructor." + Globals.NL2 +
                     "Please contact support.";
        var einfo = new ExceptionInfo(null, ex);
        if ( !einfo.ReadableText.IsNullOrEmpty() ) str += Globals.NL2 + einfo.ReadableText;
        DisplayManager.ShowAndTerminate(str);
      }
    }

  }

}
