/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// Project is registered at Depotnumerique.com (Agence des Depots Numeriques).
/// This program is free software: you can redistribute it and/or modify it under the terms of
/// the GNU Lesser General Public License (LGPL v3) as published by the Free Software Foundation,
/// either version 3 of the License, or (at your option) any later version.
/// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
/// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
/// See the GNU Lesser General Public License for more details.
/// You should have received a copy of the GNU General Public License along with this program.
/// If not, see www.gnu.org/licenses website.
/// </license>
/// <created> 2011-12 </created>
/// <edited> 2012-10 </edited>
using System;
using System.Threading;
using System.Windows.Forms;
using WinApp = System.Windows.Forms.Application;
using WinForm = System.Windows.Forms.Form;

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
    /// Return main windows form else null.
    /// </summary>
    static public WinForm MainForm
    {
      get { return WinApp.OpenForms.Count > 0 ? WinApp.OpenForms[0] : WinForm.ActiveForm; }
    }

    static internal void Initialize()
    {
      MainThread = Thread.CurrentThread;
    }
    
    /// <summary>
    /// Run an action synchronized in the main form thread and wait for completion.
    /// </summary>
    /// <param name="action">The action.</param>
    static public void SyncMainUI(Action action)
    {
      MainForm.SyncUI(action, true);
    }

    /// <summary>
    /// Run an action synchronized in the main form thread and wait for completion.
    /// </summary>
    /// <param name="action">The action.</param>
    /// <param name="wait">true to wait.</param>
    static public void SyncMainUI(Action action, bool wait)
    {
      MainForm.SyncUI(action, wait);
    }

    /// <summary>
    /// Run an action synchronized in a winform control thread and wait for completion.
    /// </summary>
    /// <param name="control">The control to act on.</param>
    /// <param name="action">The action.</param>
    static public void SyncUI(this Control control, Action action)
    {
      control.SyncUI(action, true);
    }

    /// <summary>
    /// Run an action synchronized with the visual thread and wait for completion.
    /// </summary>
    /// <exception cref="ThreadInterruptedException">Thrown when a Thread Interrupted error
    /// condition occurs.</exception>
    /// <param name="control">The control to act on.</param>
    /// <param name="action">The action.</param>
    /// <param name="wait">true to wait.</param>
    static public void SyncUI(this Control control, Action action, bool wait)
    {
      if ( !Thread.CurrentThread.IsAlive ) throw new ThreadStateException();
      Exception exception = null;
      Semaphore semaphore = null;
      Action processAction = () =>
      {
        try { action(); }
        catch ( Exception except ) { exception = except; }
      };
      Action processActionWait = () =>
      {
        processAction();
        if ( semaphore != null ) semaphore.Release();
      };
      if ( control != null
        && control.InvokeRequired
        && Thread.CurrentThread != MainThread )
      {
        if ( wait ) semaphore = new Semaphore(0, 1);
        control.BeginInvoke(wait ? processActionWait : processAction);
        if ( semaphore != null ) semaphore.WaitOne();
      }
      else
        processAction();
      if ( exception != null ) throw exception;
    }

  }

}
