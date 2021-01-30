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
/// <created> 2011-12 </created>
/// <edited> 2021-01 </edited>
using System;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide multithreaded messages output and messages box.
  /// </summary>
  static public partial class DisplayManager
  {

    /// <summary>
    /// Indicate main thread.
    /// </summary>
    static public Thread MainThread { get; private set; }

    /// <summary>
    /// Static constructor.
    /// </summary>
    static DisplayManager()
    {
      MainThread = Thread.CurrentThread;
    }

    /// <summary>
    /// Get task bar coordonates.
    /// https://stackoverflow.com/questions/3677182/taskbar-location
    /// </summary>
    static public Rectangle GetTaskbarCoordonates()
    {
      var data = new NativeMethods.APPBARDATA();
      data.cbSize = Marshal.SizeOf(data);
      IntPtr retval = NativeMethods.SHAppBarMessage(NativeMethods.ABM_GETTASKBARPOS, ref data);
      if ( retval == IntPtr.Zero )
        throw new Win32Exception("Windows Taskbar Error in " + nameof(GetTaskbarCoordonates));
      return new Rectangle(data.rc.left, data.rc.top, data.rc.right - data.rc.left, data.rc.bottom - data.rc.top);
    }

    /// <summary>
    /// Get task bar anchor style.
    /// </summary>
    static public AnchorStyles GetTaskbarAnchorStyle()
    {
      var coordonates = GetTaskbarCoordonates();
      if ( coordonates.Left == 0 && coordonates.Top == 0 )
        if ( coordonates.Width > 250 )
          return AnchorStyles.Top;
        else
          return AnchorStyles.Left;
      else
      if ( coordonates.Width > 250 )
        return AnchorStyles.Bottom;
      else
        return AnchorStyles.Right;
    }

    /// <summary>
    /// Run an action synchronized in the main form thread and wait for completion.
    /// </summary>
    /// <param name="action">The action.</param>
    /// <param name="wait">true to wait.</param>
    static public void SyncMainUI(Action action, bool wait = true)
    {
      Globals.MainForm.SyncUI(action, wait);
    }

    /// <summary>
    /// Run an action synchronized with the visual thread and wait for completion.
    /// </summary>
    /// <Exception cref="ThreadInterruptedException">Thrown when a Thread Interrupted error
    /// condition occurs.</Exception>
    /// <param name="control">The control to act on.</param>
    /// <param name="action">The action.</param>
    /// <param name="wait">true to wait.</param>
    static public void SyncUI(this Control control, Action action, bool wait = true)
    {
      if ( control == null ) throw new ArgumentNullException(nameof(control));
      if ( !Thread.CurrentThread.IsAlive ) throw new ThreadStateException();
      Exception exception = null;
      Semaphore semaphore = null;
      Action processAction = () =>
      {
        try
        {
          action();
        }
        catch ( Exception ex )
        {
          exception = ex;
        }
      };
      Action processActionWait = () =>
      {
        processAction();
        semaphore?.Release();
      };
      if ( control != null
        && control.InvokeRequired
        && Thread.CurrentThread != MainThread )
      {
        if ( wait ) semaphore = new Semaphore(0, 1);
        control.BeginInvoke(wait ? processActionWait : processAction);
        semaphore?.WaitOne();
      }
      else
        processAction();
      if ( exception != null )
        throw exception;
    }

  }

}
