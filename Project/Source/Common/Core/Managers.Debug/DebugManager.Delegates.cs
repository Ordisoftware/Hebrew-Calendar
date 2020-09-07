/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2020 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2007-05 </created>
/// <edited> 2020-08 </edited>
using System;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Delegate for trace file changed events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="filename">The new filename.</param>
  public delegate void TraceFileChanged(DebugManager.Listener sender, string filename);

  /// <summary>
  /// Delegate for handling before show exception events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="einfo">The einfo.</param>
  /// <param name="process">[in,out] The process.</param>
  public delegate void BeforeShowExceptionEventHandler(object sender, ExceptionInfo einfo, ref bool process);

  /// <summary>
  /// Delegate for handling after show exception events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="einfo">The einfo.</param>
  /// <param name="processed">true if processed.</param>
  public delegate void AfterShowExceptionEventHandler(object sender, ExceptionInfo einfo, bool processed);

  /// <summary>
  /// Delegate for handling SubstitureShowException events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="einfo">The einfo.</param>
  public delegate void SubstitureShowExceptionEventHandler(object sender, ExceptionInfo einfo);

}
