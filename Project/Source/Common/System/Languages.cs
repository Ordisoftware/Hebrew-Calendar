/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2020 Olivier Rogier.
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
/// <edited> 2020-08 </edited>
using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Supported languages enum.
  /// </summary>
  public enum Language
  {
    NotDefined,
    English,
    French
  }

  /// <summary>
  /// Indicate supported languages.
  /// </summary>
  static public class Languages
  {

    /// <summary>
    /// Indicate language codes.
    /// </summary>
    static public readonly NullSafeOfStringDictionary<Language> Codes
      = new NullSafeOfStringDictionary<Language>
      {
        [Language.English] = "en",
        [Language.French] = "fr"
      };

    /// <summary>
    /// Indicate language codes.
    /// </summary>
    static public readonly NullSafeOfEnumDictionary<string, Language> Values;

    /// <summary>
    /// Indicate managed languages.
    /// </summary>
    static public readonly Language[] Managed;

    /// <summary>
    /// Indicate english language.
    /// </summary>
    static public readonly Language EN = Language.English;

    /// <summary>
    /// Indicate french language.
    /// </summary>
    static public readonly Language FR = Language.French;

    /// <summary>
    /// Indicate default language.
    /// </summary>
    static public readonly Language Default = EN;

    /// <summary>
    /// Indicate current language code.
    /// </summary>
    static public string CurrentCode => Codes[Current];

    /// <summary>
    /// Indicate current language.
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
        Managed = ( (Language[])Enum.GetValues(typeof(Language)) ).Skip(1).ToArray();
        Values = new NullSafeOfEnumDictionary<string, Language>(Codes.ToDictionary(x => x.Value, x => x.Key));
      }
      catch ( Exception ex )
      {
        string str = "Language exception" + Globals.NL2 +
                     "Please contact support.";
        var einfo = new ExceptionInfo(null, ex);
        if ( !einfo.ReadableText.IsNullOrEmpty() ) str += Globals.NL2 + einfo.ReadableText;
        DisplayManager.ShowAndTerminate(str);
      }
    }

  }

}
