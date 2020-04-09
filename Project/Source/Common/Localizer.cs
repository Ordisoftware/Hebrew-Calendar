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
/// <edited> 2020-04 </edited>
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide localization helper.
  /// </summary>
  static public class Localizer
  {

    /// <summary>
    /// Indicate managed languages list.
    /// </summary>
    static public readonly string[] AvailableLanguages = { "en", "fr" };

    /// <summary>
    /// Indicate default language.
    /// </summary>
    static public readonly string DefaultLanguage = "en";

    /// <summary>
    /// Indicate current language.
    /// </summary>
    static public string Language
    {
      get
      {
        string lang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        if ( !AvailableLanguages.Contains(lang) )
          lang = DefaultLanguage;
        return lang;
      }
    }

    /// <summary>
    /// Get the string translation.
    /// </summary>
    /// <param name="values">The dictionary containing langs>translations.</param>
    /// <returns></returns>
    static public string GetLang(this Dictionary<string, string> values)
    {
      return values[Language];
    }

    /// <summary>
    /// Get the string translation.
    /// </summary>
    /// <param name="values">The dictionary containing langs>translations.</param>
    /// <returns></returns>
    static public string GetLang(this Dictionary<string, string> values, params object[] parameters)
    {
      return string.Format(values.GetLang(), parameters);
    }

    /// <summary>
    /// Get the string list translation.
    /// </summary>
    /// <param name="values">The dictionary containing langs>translations.</param>
    /// <returns></returns>
    static public string[] GetLang(this Dictionary<string, string[]> values)
    {
      return values[Language];
    }

    /// <summary>
    /// Get the string translation.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    /// <param name="values">The dictionary containing values>langs>translations.</param>
    /// <param name="value">The value to translate.</param>
    /// <returns></returns>
    static public string GetLang<T>(this Dictionary<T, Dictionary<string, string>> values, T value)
    {
      return values[value][Language];
    }

    /// <summary>
    /// Get the string translation.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    /// <param name="values">The dictionary containing langs>values>translations.</param>
    /// <param name="value">The value to translate.</param>
    /// <returns></returns>
    static public string GetLang<T>(this Dictionary<string, Dictionary<T, string>> values, T value)
    {
      return values[Language][value];
    }

    /// <summary>
    /// Remove diacritics letters.
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
