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
/// <created> 2009-08 </created>
/// <edited> 2009-08 </edited>
using System;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provides input value box result.
  /// </summary>
  public enum InputValueResult
  {

    /// <summary>
    /// Input is cancelled.
    /// </summary>
    Cancelled,

    /// <summary>
    /// Value is unchanged.
    /// </summary>
    Unchanged,

    /// <summary>
    /// Value is modified.
    /// </summary>
    Modified,

  };

}