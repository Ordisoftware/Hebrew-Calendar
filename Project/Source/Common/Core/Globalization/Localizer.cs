﻿/// <license>
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
/// <edited> 2021-02 </edited>
using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

namespace Ordisoftware.Core
{

  [Serializable]
  partial class TranslationsDictionary : NullSafeOfStringDictionary<Language>
  {
    public TranslationsDictionary() : base()
    {
    }
    protected TranslationsDictionary(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
  }

  /// <summary>
  /// Provide localization helper.
  /// </summary>
  static class Localizer
  {

    private const string ERR = "<Not translated>";

    /// <summary>
    /// Get the string translation.
    /// </summary>
    /// <param name="values">The dictionary containing lang>translation.</param>
    static public string GetLang(this TranslationsDictionary values)
    {
      return values?[Languages.Current] ?? values?[Languages.Default] ?? ERR;
    }

    /// <summary>
    /// Get the string translation.
    /// </summary>
    /// <param name="values">The dictionary containing lang>translation.</param>
    /// <param name="parameters">Parameters for the translated string.</param>
    static public string GetLang(this TranslationsDictionary values, params object[] parameters)
    {
      return string.Format(values?.GetLang(), parameters) ?? ERR + " " + string.Join(",", parameters);
    }

    /// <summary>
    /// Get the string translation.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    /// <param name="values">The dictionary containing value>lang>translation.</param>
    /// <param name="value">The value to translate.</param>
    /// <param name="forceEnglish">True to force get in english.</param>
    static public string GetLang<T>(this NullSafeDictionary<T, TranslationsDictionary> values, T value, bool forceEnglish = false)
    {
      var lang = forceEnglish ? Language.EN : Languages.Current;
      return values?[value]?[lang] ?? values?[value]?[Languages.Default] ?? ERR;
    }

    /// <summary>
    /// Get the list translation.
    /// </summary>
    /// <param name="values">The dictionary containing lang>list.</param>
    static public NullSafeStringList GetLang(this NullSafeDictionary<Language, NullSafeStringList> values)
    {
      return values?[Languages.Current] ?? values?[Languages.Default] ?? new NullSafeStringList();
    }

    /// <summary>
    /// Get the list translation.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    /// <param name="values">The dictionary containing lang>list.</param>
    static public NullSafeList<T> GetLang<T>(this NullSafeDictionary<Language, NullSafeList<T>> values)
      where T : class
    {
      return values?[Languages.Current] ?? values?[Languages.Default] ?? new NullSafeList<T>();
    }

    /// <summary>
    /// Get the string list translation.
    /// </summary>
    /// <param name="values">The dictionary containing lang>translations.</param>
    static public string[] GetLang(this NullSafeDictionary<Language, string[]> values)
    {
      return values?[Languages.Current] ?? values?[Languages.Default] ?? new string[1] { ERR };
    }

    /// <summary>
    /// Get the string translation.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    /// <param name="values">The dictionary containing lang>value>translation.</param>
    /// <param name="value">The value to translate.</param>
    static public string GetLang<T>(this NullSafeDictionary<Language, NullSafeOfStringDictionary<T>> values, T value)
      where T : Enum
    {
      return values?[Languages.Current]?[value] ?? values?[Languages.Default]?[value] ?? ERR;
    }

    /// <summary>
    /// Remove diacritics signs.
    /// </summary>
    public static string RemoveDiacritics(this string str)
    {
      if ( str.IsNullOrEmpty() ) return str;
      var normalized = str.Normalize(NormalizationForm.FormD);
      var builder = new StringBuilder();
      foreach ( var c in normalized )
        if ( CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark )
          builder.Append(c);
      return builder.ToString().Normalize(NormalizationForm.FormC);
    }

  }

}
