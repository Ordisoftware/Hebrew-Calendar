/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2025 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2008-05 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides multi-threaded messages output and messages box.
/// </summary>
[SuppressMessage("Style", "GCop408:Flag or switch parameters (bool) should go after all non-optional parameters. If the boolean parameter is not a flag or switch, split the method into two different methods, each doing one thing.", Justification = "Opinion")]
static public partial class DisplayManager
{

  /// <summary>
  /// Queries a value.
  /// </summary>
  /// <returns>
  /// The value.
  /// </returns>
  /// <typeparam name="T">Generic type parameter.</typeparam>
  /// <param name="caption">The caption.</param>
  /// <param name="value">[in,out] The value.</param>
  static public InputValueResult QueryValue<T>(string caption, ref T value)
  where T : IConvertible
  {
    return QueryValue(caption, ref value, false);
  }

  /// <summary>
  /// Queries a value.
  /// </summary>
  /// <returns>
  /// The value.
  /// </returns>
  /// <typeparam name="T">Generic type parameter.</typeparam>
  /// <param name="caption">The caption.</param>
  /// <param name="value">[in,out] The value.</param>
  /// <param name="validation">The validation.</param>
  static public InputValueResult QueryValue<T>(string caption, ref T value, Func<T, bool> validation)
  where T : IConvertible
  {
    return QueryValue(caption, ref value, false, validation);
  }

  /// <summary>
  /// Queries a value.
  /// </summary>
  /// <returns>
  /// The value.
  /// </returns>
  /// <typeparam name="T">Generic type parameter.</typeparam>
  /// <param name="caption">The caption.</param>
  /// <param name="value">[in,out] The value.</param>
  /// <param name="isPassword">true to isPassword.</param>
  static public InputValueResult QueryValue<T>(string caption, ref T value, bool isPassword)
  where T : IConvertible
  {
    return QueryValue(caption, ref value, isPassword, null);
  }

  /// <summary>
  /// Queries a value.
  /// </summary>
  /// <returns>
  /// The value.
  /// </returns>
  /// <typeparam name="T">Generic type parameter.</typeparam>
  /// <param name="caption">The caption.</param>
  /// <param name="value">[in,out] The value.</param>
  /// <param name="isPassword">true to isPassword.</param>
  /// <param name="validation">The validation.</param>
  static public InputValueResult QueryValue<T>(string caption, ref T value, bool isPassword, Func<T, bool> validation)
  where T : IConvertible
  {
    return QueryValue("ValueRequested", caption, ref value, isPassword, validation);
  }

  /// <summary>
  /// Queries a value.
  /// </summary>
  /// <returns>
  /// The value.
  /// </returns>
  /// <typeparam name="T">Generic type parameter.</typeparam>
  /// <param name="title">The title.</param>
  /// <param name="caption">The caption.</param>
  /// <param name="value">[in,out] The value.</param>
  static public InputValueResult QueryValue<T>(string title, string caption, ref T value)
  where T : IConvertible
  {
    return QueryValue(title, caption, ref value, false);
  }

  /// <summary>
  /// Queries a value.
  /// </summary>
  /// <returns>
  /// The value.
  /// </returns>
  /// <typeparam name="T">Generic type parameter.</typeparam>
  /// <param name="title">The title.</param>
  /// <param name="caption">The caption.</param>
  /// <param name="value">[in,out] The value.</param>
  /// <param name="validation">The validation.</param>
  static public InputValueResult QueryValue<T>(string title, string caption, ref T value, Func<T, bool> validation)
  where T : IConvertible
  {
    return QueryValue(title, caption, ref value, false, validation);
  }

  /// <summary>
  /// Queries a value.
  /// </summary>
  /// <returns>
  /// The value.
  /// </returns>
  /// <typeparam name="T">Generic type parameter.</typeparam>
  /// <param name="title">The title.</param>
  /// <param name="caption">The caption.</param>
  /// <param name="value">[in,out] The value.</param>
  /// <param name="isPassword">true to isPassword.</param>
  static public InputValueResult QueryValue<T>(string title, string caption, ref T value, bool isPassword)
  where T : IConvertible
  {
    return QueryValue(title, caption, ref value, isPassword, null);
  }

  /// <summary>
  /// Queries a value.
  /// </summary>
  /// <returns>
  /// The value.
  /// </returns>
  /// <typeparam name="T">Generic type parameter.</typeparam>
  /// <param name="title">The title.</param>
  /// <param name="caption">The caption.</param>
  /// <param name="value">[in,out] The value.</param>
  /// <param name="isPassword">true to isPassword.</param>
  /// <param name="validation">The validation.</param>
  static public InputValueResult QueryValue<T>(string title, string caption, ref T value, bool isPassword, Func<T, bool> validation)
  where T : IConvertible
  {
    return QueryValueWinForms(title, caption, ref value, isPassword, validation);
  }

  /// <summary>
  /// Queries a value.
  /// </summary>
  /// <returns>
  /// The value window forms.
  /// </returns>
  /// <typeparam name="T">Generic type parameter.</typeparam>
  /// <param name="title">The title.</param>
  /// <param name="caption">The caption.</param>
  /// <param name="value">[in,out] The value.</param>
  /// <param name="isPassword">true to isPassword.</param>
  /// <param name="validation">The validation.</param>
  static private InputValueResult QueryValueWinForms<T>(
    string title,
    string caption,
    ref T value,
    bool isPassword,
    Func<T, bool> validation)
  where T : IConvertible
  {
    var res = InputValueResult.Unchanged;
    var newValue = value;
    try
    {
      Globals.MainForm.SyncUI(() => res = InputBox<T>.Run(title, caption, ref newValue, isPassword, validation));
    }
    catch ( Exception ex )
    {
      ex.Manage(ShowExceptionMode.None);
    }
    if ( res == InputValueResult.Modified ) value = newValue;
    return res;
  }

}
