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
/// <edited> 2021-04 </edited>
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Indicate supported data file format for export.
  /// </summary>
  public enum DataExportTarget
  {
    TXT,
    HTML,
    DOCX,
    CSV,
    JSON,
    XML
  }

  /// <summary>
  /// Indicate supported image file format for export.
  /// </summary>
  public enum ImageExportTarget
  {
    PNG,
    JPG,
    TIFF,
    BMP,
    GIF
  }

  static class ImageExportTargetHelper
  {

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

    static public ImageFormat GetFormat(this NullSafeOfStringDictionary<ImageExportTarget> list, string extension)
    {
      return list.FirstOrDefault(v => v.Value == extension).Key.GetFormat();
    }

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

}
