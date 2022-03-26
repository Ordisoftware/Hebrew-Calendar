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
/// <created> 2011-12 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides messages and questions with waiting user communication feedback as well as UI sync.
/// </summary>
static partial class DisplayManager
{

  /// <summary>
  /// Indicates main thread.
  /// </summary>
  static public Thread MainThread { get; private set; }

  /// <summary>
  /// Static constructor.
  /// </summary>
  static DisplayManager()
  {
    MainThread = Thread.CurrentThread;
  }

  public const int TaskbarWidthCheckTrigger = 250;

  /// <summary>
  /// Gets task bar anchor style.
  /// </summary>
  static public AnchorStyles GetTaskbarAnchorStyle()
  {
    var coordonates = StackMethods.GetTaskbarCoordonates();
    if ( coordonates.Left == 0 && coordonates.Top == 0 )
      if ( coordonates.Width > TaskbarWidthCheckTrigger )
        return AnchorStyles.Top;
      else
        return AnchorStyles.Left;
    else
    if ( coordonates.Width > TaskbarWidthCheckTrigger )
      return AnchorStyles.Bottom;
    else
      return AnchorStyles.Right;
  }

  /// <summary>
  /// Runs an action synchronized in the main form thread and wait for completion.
  /// </summary>
  /// <param name="action">The action.</param>
  /// <param name="wait">true to wait.</param>
  static public void SyncMainUI(Action action, bool wait = true)
  {
    Globals.MainForm.SyncUI(action, wait);
  }

  /// <summary>
  /// Runs an action synchronized with the visual thread and wait for completion.
  /// </summary>
  /// <Exception cref="ThreadInterruptedException">Thrown when a Thread Interrupted error
  /// condition occurs.</Exception>
  /// <param name="control">The control to act on.</param>
  /// <param name="action">The action.</param>
  /// <param name="wait">true to wait.</param>
  [SuppressMessage("Performance", "U2U1017:Initialized locals should be used", Justification = "Analysis error")]
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP001:Dispose created", Justification = "Done")]
  static public void SyncUI(this Control control, Action action, bool wait = true)
  {
    if ( control is null ) throw new ArgumentNullException(nameof(control));
    if ( !Thread.CurrentThread.IsAlive ) throw new ThreadStateException();
    Exception exception = null;
    SemaphoreSlim semaphore = null;
    var processAction = () =>
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
    var processActionWait = () =>
    {
      processAction();
      semaphore?.Release();
    };
    if ( Globals.IsReady && control.InvokeRequired && Thread.CurrentThread != MainThread )
    {
      if ( wait ) semaphore = new SemaphoreSlim(0, 1);
      control.BeginInvoke(wait ? processActionWait : processAction);
      if ( wait )
      {
        semaphore.Wait();
        semaphore.Dispose();
      }
    }
    else
      processAction();
    if ( exception is not null )
      throw exception;
  }

}
