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
/// <created> 2020-12 </created>
/// <edited> 2023-07 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides export helper.
/// </summary>
static public class ExportHelper
{

  /// <summary>
  /// Creates the export targets.
  /// </summary>
  static public NullSafeOfStringDictionary<T> CreateExportTargets<T>(params T[] list)
  where T : struct, Enum
  {
    var result = new NullSafeOfStringDictionary<T>();
    foreach ( var value in Enums.GetValues<T>() )
      if ( list.Length == 0 || list.Contains(value) )
        result.Add(value, $".{value.ToString().ToLower()}");
    return result;
  }

  /// <summary>
  /// Creates the filters for dialog boxes.
  /// </summary>
  static public string CreateFilters<T>(this NullSafeOfStringDictionary<T> values)
  where T : struct, Enum
  {
    string str = SysTranslations.FileExtensionFilter.GetLang();
    var list = values.Select(v => $"{string.Format(str, v.Key)}|*{v.Value}");
    return list.Join("|");
  }

  /// <summary>
  /// Sets the targets that are supported.
  /// </summary>
  [SuppressMessage("Performance", "U2U1203:Use foreach efficiently", Justification = "The collection is modified")]
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
  [SuppressMessage("Performance", "U2U1203:Use foreach efficiently", Justification = "The collection is modified")]
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
  /// <param name="comboBox">The combo box.</param>
  /// <param name="list">The list.</param>
  /// <param name="valueDefault">The default value.</param>
  static public void Fill<T>(this ComboBox comboBox, NullSafeOfStringDictionary<T> list, T valueDefault)
  where T : struct, Enum
  {
    foreach ( KeyValuePair<T, string> item in list )
    {
      int index = comboBox.Items.Add(item);
      if ( item.Key.Equals(valueDefault) )
        comboBox.SelectedIndex = index;
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
      _ => throw new AdvNotImplementedException(value),
    };
  }

  static public bool Run(this FileDialog dialog,
                         string filename,
                         DataExportTarget preferred,
                         NullSafeOfStringDictionary<DataExportTarget> board)
  {
    dialog.FileName = filename;
    for ( int index = 0; index < board.Count; index++ )
      if ( board.ElementAt(index).Key == preferred )
        dialog.FilterIndex = index + 1;
    return dialog.ShowDialog() == DialogResult.OK;
  }

}
