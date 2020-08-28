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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Supported languages enum.
  /// </summary>
  public enum Language
  {
    English,
    French
  }

  /// <summary>
  /// Indicate supported languages.
  /// </summary>
  static public class Languages
  {
    /// <summary>
    /// Indicate language names.
    /// </summary>
    static public readonly Dictionary<Language, string> Names
      = new Dictionary<Language, string>
      {
        { Language.English, "en" },
        { Language.French, "fr" }
      };
    /// <summary>
    /// Indicate english language code.
    /// </summary>
    static public readonly string EN = Names[Language.English];

    /// <summary>
    /// Indicate french language code.
    /// </summary>
    static public readonly string FR = Names[Language.French];

    /// <summary>
    /// Indicate default language code.
    /// </summary>
    static public readonly string Default = EN;

    /// <summary>
    /// Indicate current language.
    /// </summary>
    static public string Current
    {
      get
      {
        string lang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        if ( !Names.Values.Contains(lang) )
          lang = Default;
        return lang;
      }
    }

  }

}
