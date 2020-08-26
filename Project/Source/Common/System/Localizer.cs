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
  /// Provide localization helper.
  /// </summary>
  static public partial class Localizer
  {

    /// <summary>
    /// Indicate supported languages names.
    /// </summary>
    static public readonly Dictionary<Language, string> LanguageNames
      = new Dictionary<Language, string>
      {
        { Language.English, "en" },
        { Language.French, "fr" }
      };

    /// <summary>
    /// Indicate english language code.
    /// </summary>
    static public readonly string EN = LanguageNames[Language.English];

    /// <summary>
    /// Indicate french language code.
    /// </summary>
    static public readonly string FR = LanguageNames[Language.French];

    /// <summary>
    /// Indicate new line.
    /// </summary>
    static public readonly string NL = Environment.NewLine;

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
        if ( !LanguageNames.Values.Contains(lang) )
          lang = Default;
        return lang;
      }
    }

    /// <summary>
    /// Get the string translation.
    /// </summary>
    /// <param name="values">The dictionary containing lang>translation.</param>
    static public string GetLang(this Dictionary<string, string> values)
    {
      return values != null && values.ContainsKey(Current) ? values[Current] : "";
    }

    /// <summary>
    /// Get the string translation.
    /// </summary>
    /// <param name="values">The dictionary containing lang>translation.</param>
    /// <param name="parameters">Parameters for the translated string.</param>
    static public string GetLang(this Dictionary<string, string> values, params object[] parameters)
    {
      return values != null ? string.Format(values.GetLang(), parameters) : "";
    }

    /// <summary>
    /// Get the string list translation.
    /// </summary>
    /// <param name="values">The dictionary containing lang>translations.</param>
    static public string[] GetLang(this Dictionary<string, string[]> values)
    {
      return values != null && values.ContainsKey(Current) ? values[Current] : new string[0];
    }

    /// <summary>
    /// Get the string translation.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    /// <param name="values">The dictionary containing value>lang>translation.</param>
    /// <param name="value">The value to translate.</param>
    static public string GetLang<T>(this Dictionary<T, Dictionary<string, string>> values, T value)
    {
      return values != null && values.ContainsKey(value)
             ? values[value] != null && values[value].ContainsKey(Current) ? values[value][Current] : ""
             : "";
    }

    /// <summary>
    /// Get the string translation.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    /// <param name="values">The dictionary containing lang>value>translation.</param>
    /// <param name="value">The value to translate.</param>
    static public string GetLang<T>(this Dictionary<string, Dictionary<T, string>> values, T value)
    {
      return values != null && values.ContainsKey(Current)
        ? values[Current] != null && values[Current].ContainsKey(value) ? values[Current][value] : ""
        : "";
    }

    /// <summary>
    /// Get the list translation.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    /// <param name="values">The dictionary containing lang>list.</param>
    static public List<T> GetLang<T>(this Dictionary<string, List<T>> values)
    {
      return values != null && values.ContainsKey(Current) ? values[Current] : null;
    }

    /// <summary>
    /// Remove diacritics signs.
    /// </summary>
    public static string RemoveDiacritics(this string text)
    {
      if ( string.IsNullOrEmpty(text) )
        return string.Empty;
      var normalizedString = text.Normalize(NormalizationForm.FormD);
      var stringBuilder = new StringBuilder();
      foreach ( var c in normalizedString )
        if ( CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark )
          stringBuilder.Append(c);
      return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }

  }

}
