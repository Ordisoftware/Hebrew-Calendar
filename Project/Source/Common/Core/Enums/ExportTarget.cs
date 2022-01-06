/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2022 Olivier Rogier.
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
namespace Ordisoftware.Core;

/// <summary>
/// Indicates supported data file format for export.
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
/// Indicates supported image file format for export.
/// </summary>
public enum ImageExportTarget
{
  PNG,
  JPG,
  TIFF,
  BMP,
  GIF
}
