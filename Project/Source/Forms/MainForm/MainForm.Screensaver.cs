/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2020 Olivier Rogier.
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
/// <edited> 2019-01 </edited>
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Ordisoftware.HebrewCalendar
{

  public partial class MainForm
  {

    private const int WM_SYSCOMMAND = 0x0112;
    private const int SC_SCREENSAVE = 0xF140;
    private const int SPI_GETSCREENSAVERRUNNING = 0x0072;

    [DllImport("user32.dll", SetLastError = true)]
    static extern bool SystemParametersInfo(int action, int param, ref int retval, int updini);

    [StructLayout(LayoutKind.Sequential)]
    private struct RECT
    {
      public int left;
      public int top;
      public int right;
      public int bottom;
    }

    [DllImport("user32.dll")]
    static private extern bool GetWindowRect(HandleRef hWnd, [In, Out] ref RECT rect);

    [DllImport("user32.dll")]
    static private extern IntPtr GetForegroundWindow();

    static private bool IsForegroundFullScreen()
    {
      return IsForegroundFullScreen(null);
    }

    static private bool IsForegroundFullScreen(Screen screen)
    {
      if ( screen == null ) screen = Screen.PrimaryScreen;
      RECT rect = new RECT();
      GetWindowRect(new HandleRef(null, GetForegroundWindow()), ref rect);
      return new Rectangle(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top)
                 .Contains(screen.Bounds);
    }

    private bool IsFullScreenOrScreensaver()
    {
      int active = 1;
      SystemParametersInfo(SPI_GETSCREENSAVERRUNNING, 0, ref active, 0);
      if ( active != 0 ) return true;
      if ( IsForegroundFullScreen() ) return true;
      return false;
    }

  }

}
