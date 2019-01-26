﻿/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
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
/// <edited> 2016-04 </edited>
using System;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Indicate the location of a control.
  /// </summary>
  [Serializable]
  public enum ControlLocation
  {

    /// <summary>
    /// Loose position.
    /// </summary>
    Loose,

    /// <summary>
    /// Top-left corner.
    /// </summary>
    TopLeft,

    /// <summary>
    /// Top-right corner.
    /// </summary>
    TopRight,

    /// <summary>
    /// Bottom-left corner.
    /// </summary>
    BottomLeft,

    /// <summary>
    /// Bottom-right corner.
    /// </summary>
    BottomRight,

    /// <summary>
    /// Centered on the screen.
    /// </summary>
    Center

  }

}
