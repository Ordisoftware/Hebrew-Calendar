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
/// <created> 2007-05 </created>
/// <edited> 2021-05 </edited>
using System;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Indicate show exception mode.
  /// </summary>
  public enum ShowExceptionMode
  {
    None,
    Simple,
    Advanced,
    OnlyMessage
  }

  /// <summary>
  /// Indicate trace file roll over mode.
  /// </summary>
  public enum TraceFileRollOverMode
  {
    Session,
    SinkFile
  }

  /// <summary>
  /// Provide log event enum.
  /// </summary>
  public enum LogTraceEvent
  {

    /// <summary>
    /// System event (no event level).
    /// </summary>
    System,

    /// <summary>
    /// Start process event.
    /// </summary>
    Start,

    /// <summary>
    /// Stop process event.
    /// </summary>
    Stop,

    /// <summary>
    /// Enter method event.
    /// </summary>
    Enter,

    /// <summary>
    /// Leave method event.
    /// </summary>
    Leave,

    /// <summary>
    /// Finished method event.
    /// </summary>
    Complete,

    /// <summary>
    /// Message event.
    /// </summary>
    Message,

    /// <summary>
    /// Data event.
    /// </summary>
    Data,

    /// <summary>
    /// Error event.
    /// </summary>
    Error,

    /// <summary>
    /// Excention event.
    /// </summary>
    Exception

  }

}
