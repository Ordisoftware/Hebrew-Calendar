/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2023 Olivier Rogier.
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
/// <edited> 2021-11 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides log event enum.
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
  /// Finished processing event.
  /// </summary>
  Completed,

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
  /// Exception event.
  /// </summary>
  Exception

}
