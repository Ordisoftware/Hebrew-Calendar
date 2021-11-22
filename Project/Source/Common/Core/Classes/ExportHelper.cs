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
/// <edited> 2021-11 </edited>
namespace Ordisoftware.Core;

using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using EnumsNET;

/// <summary>
/// Provides export helper.
/// </summary>
static class ExportHelper
{

  /// <summary>
  /// Creates the export targets.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  static public NullSafeOfStringDictionary<T> CreateExportTargets<T>(params T[] list)
  where T : struct, Enum
  {
    var result = new NullSafeOfStringDictionary<T>();
    foreach ( var value in Enums.GetValues<T>() )
      if ( list.Length == 0 || list.Contains(value) )
        result.Add(value, "." + value.ToString().ToLower());
    return result;
  }

  /// <summary>
  /// Creates the filters for dialog boxes.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  static public string CreateFilters<T>(this NullSafeOfStringDictionary<T> values)
  where T : struct, Enum
  {
    string str = SysTranslations.FileExtensionFilter.GetLang();
    var list = values.Select(v => $"{string.Format(str, v.Key)}|*{v.Value}");
    return string.Join("|", list);
  }

  /// <summary>
  /// Sets the targets that are supported.
  /// </summary>
  static public NullSafeOfStringDictionary<T> SetSupported<T>(this NullSafeOfStringDictionary<T> values,
                                                              params T[] list)
  where T : struct, Enum
  {
    foreach ( var pair in values.Where(p => !list.Contains(p.Key)).ToList() )
      values.Remove(pair.Key);
    return values;
  }

  /// <summary>
  /// Sets the targets that are not supported.
  /// </summary>
  static public NullSafeOfStringDictionary<T> SetUnsupported<T>(this NullSafeOfStringDictionary<T> values,
                                                                params T[] list)
  where T : struct, Enum
  {
    foreach ( var pair in values.Where(p => list.Contains(p.Key)).ToList() )
      values.Remove(pair.Key);
    return values;
  }

  /// <summary>
  /// Fills a combo box with the specified list of targets.
  /// </summary>
  /// <param name="combobox">The combobox.</param>
  /// <param name="list">The list.</param>
  /// <param name="valueDefault">The default value.</param>
  static public void Fill<T>(this ComboBox combobox, NullSafeOfStringDictionary<T> list, T valueDefault)
  where T : struct, Enum
  {
    foreach ( KeyValuePair<T, string> item in list )
    {
      int index = combobox.Items.Add(item);
      if ( item.Key.Equals(valueDefault) )
        combobox.SelectedIndex = index;
    }
  }

  /// <summary>
  /// Gets the image format from a string extension.
  /// </summary>
  /// <param name="list">The list.</param>
  /// <param name="extension">The extension.</param>
  static public ImageFormat GetFormat(this NullSafeOfStringDictionary<ImageExportTarget> list, string extension)
  {
    return list.FirstOrDefault(v => v.Value == extension).Key.GetFormat();
  }

  /// <summary>
  /// Gets the image format from an enum value.
  /// </summary>
  /// <param name="value">The value.</param>
  static public ImageFormat GetFormat(this ImageExportTarget value)
  {
    return value switch
    {
      ImageExportTarget.PNG => ImageFormat.Png,
      ImageExportTarget.JPG => ImageFormat.Jpeg,
      ImageExportTarget.TIFF => ImageFormat.Tiff,
      ImageExportTarget.BMP => ImageFormat.Bmp,
      ImageExportTarget.GIF => ImageFormat.Gif,
      _ => throw new AdvancedNotImplementedException(value),
    };
  }

}
