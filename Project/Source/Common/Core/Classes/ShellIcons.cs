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
/// <created> 2020-08 </created>
/// <edited> 2021-01 </edited>
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Ordisoftware.Core
{

  static class ShellIcons
  {
    static public readonly Bitmap Warning;
    static public readonly Bitmap Error;
    static public readonly Bitmap Information;
    static public readonly Bitmap Question;

    static ShellIcons()
    {
      var sii = new NativeMethods.SHSTOCKICONINFO();
      sii.cbSize = (UInt32)Marshal.SizeOf(typeof(NativeMethods.SHSTOCKICONINFO));
      Marshal.ThrowExceptionForHR(NativeMethods.SHGetStockIconInfo(NativeMethods.SHSTOCKICONID.SIID_INFO, NativeMethods.SHGSI.SHGSI_ICON, ref sii));
      Information = Icon.FromHandle(sii.hIcon).ToBitmap();
      Marshal.ThrowExceptionForHR(NativeMethods.SHGetStockIconInfo(NativeMethods.SHSTOCKICONID.SIID_HELP, NativeMethods.SHGSI.SHGSI_ICON, ref sii));
      Question = Icon.FromHandle(sii.hIcon).ToBitmap();
      Marshal.ThrowExceptionForHR(NativeMethods.SHGetStockIconInfo(NativeMethods.SHSTOCKICONID.SIID_WARNING, NativeMethods.SHGSI.SHGSI_ICON, ref sii));
      Warning = Icon.FromHandle(sii.hIcon).ToBitmap();
      Marshal.ThrowExceptionForHR(NativeMethods.SHGetStockIconInfo(NativeMethods.SHSTOCKICONID.SIID_ERROR, NativeMethods.SHGSI.SHGSI_ICON, ref sii));
      Error = Icon.FromHandle(sii.hIcon).ToBitmap();
    }

  }

}
