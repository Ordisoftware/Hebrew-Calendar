/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2024 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-08 </created>
/// <edited> 2021-11 </edited>
namespace Ordisoftware.Core;

using System.Runtime.InteropServices;

using static Ordisoftware.Core.NativeMethods;

/// <summary>
/// Provides shell icons for message boxes.
/// </summary>
static public class ShellIcons
{
  static public readonly Bitmap Warning;
  static public readonly Bitmap Error;
  static public readonly Bitmap Information;
  static public readonly Bitmap Question;
  static ShellIcons()
  {
    var sii = new SHSTOCKICONINFO { cbSize = (uint)Marshal.SizeOf<SHSTOCKICONINFO>() };
    Information = process(SHSTOCKICONID.SIID_INFO);
    Question = process(SHSTOCKICONID.SIID_HELP);
    Warning = process(SHSTOCKICONID.SIID_WARNING);
    Error = process(SHSTOCKICONID.SIID_ERROR);
    //
    Bitmap process(SHSTOCKICONID id)
    {
      Marshal.ThrowExceptionForHR(SHGetStockIconInfo(id, SHGSI.SHGSI_ICON, ref sii));
      return Icon.FromHandle(sii.hIcon).ToBitmap();
    }
  }

}
