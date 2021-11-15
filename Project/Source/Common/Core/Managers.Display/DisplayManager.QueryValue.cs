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
/// <created> 2008-05 </created>
/// <edited> 2021-03 </edited>
using System;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide multithreaded messages output and messages box.
  /// </summary>
  static public partial class DisplayManager
  {

    /// <summary>
    /// Query a value.
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
    /// Query a value.
    /// </summary>
    /// <returns>
    /// The value.
    /// </returns>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="caption">The caption.</param>
    /// <param name="value">[in,out] The value.</param>
    /// <param name="validator">The validator.</param>
    static public InputValueResult QueryValue<T>(string caption, ref T value, Func<T, bool> validator)
      where T : IConvertible
    {
      return QueryValue(caption, ref value, false, validator);
    }

    /// <summary>
    /// Query a value.
    /// </summary>
    /// <returns>
    /// The value.
    /// </returns>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="caption">The caption.</param>
    /// <param name="value">[in,out] The value.</param>
    /// <param name="ispassword">true to ispassword.</param>
    static public InputValueResult QueryValue<T>(string caption, ref T value, bool ispassword)
      where T : IConvertible
    {
      return QueryValue(caption, ref value, ispassword, null);
    }

    /// <summary>
    /// Query a value.
    /// </summary>
    /// <returns>
    /// The value.
    /// </returns>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="caption">The caption.</param>
    /// <param name="value">[in,out] The value.</param>
    /// <param name="ispassword">true to ispassword.</param>
    /// <param name="validator">The validator.</param>
    static public InputValueResult QueryValue<T>(string caption, ref T value, bool ispassword, Func<T, bool> validator)
      where T : IConvertible
    {
      return QueryValue("ValueRequested", caption, ref value, ispassword, validator);
    }

    /// <summary>
    /// Query a value.
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
    /// Query a value.
    /// </summary>
    /// <returns>
    /// The value.
    /// </returns>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="title">The title.</param>
    /// <param name="caption">The caption.</param>
    /// <param name="value">[in,out] The value.</param>
    /// <param name="validator">The validator.</param>
    static public InputValueResult QueryValue<T>(string title, string caption, ref T value, Func<T, bool> validator)
      where T : IConvertible
    {
      return QueryValue(title, caption, ref value, false, validator);
    }

    /// <summary>
    /// Query a value.
    /// </summary>
    /// <returns>
    /// The value.
    /// </returns>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="title">The title.</param>
    /// <param name="caption">The caption.</param>
    /// <param name="value">[in,out] The value.</param>
    /// <param name="ispassword">true to ispassword.</param>
    static public InputValueResult QueryValue<T>(string title, string caption, ref T value, bool ispassword)
      where T : IConvertible
    {
      return QueryValue(title, caption, ref value, ispassword, null);
    }

    /// <summary>
    /// Query a value.
    /// </summary>
    /// <returns>
    /// The value.
    /// </returns>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="title">The title.</param>
    /// <param name="caption">The caption.</param>
    /// <param name="value">[in,out] The value.</param>
    /// <param name="ispassword">true to ispassword.</param>
    /// <param name="validator">The validator.</param>
    static public InputValueResult QueryValue<T>(string title, string caption, ref T value, bool ispassword, Func<T, bool> validator)
      where T : IConvertible
    {
      return QueryValueWinForms(title, caption, ref value, ispassword, validator);
    }

    /// <summary>
    /// Query a value.
    /// </summary>
    /// <returns>
    /// The value window forms.
    /// </returns>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="title">The title.</param>
    /// <param name="caption">The caption.</param>
    /// <param name="value">[in,out] The value.</param>
    /// <param name="ispassword">true to ispassword.</param>
    /// <param name="validator">The validator.</param>
    static private InputValueResult QueryValueWinForms<T>(string title, string caption, ref T value,
                                                          bool ispassword, Func<T, bool> validator)
      where T : IConvertible
    {
      var res = InputValueResult.Unchanged;
      T newvalue = value;
      try
      {
        Globals.MainForm.SyncUI(() => res = InputBox<T>.Run(title, caption, ref newvalue, ispassword, validator));
      }
      catch
      {
      }
      if ( res == InputValueResult.Modified ) value = newvalue;
      return res;
    }

  }

}
