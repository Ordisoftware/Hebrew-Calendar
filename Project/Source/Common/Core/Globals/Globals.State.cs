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
/// <created> 2016-04 </created>
/// <edited> 2021-09 </edited>
using System;
using System.Configuration;

namespace Ordisoftware.Core
{

  public enum ApplicationState
  {
  }

  /// <summary>
  /// Provide global variables.
  /// </summary>
  static partial class Globals
  {

    /// <summary>
    /// Indicate the process start date and time.
    /// </summary>
    static public readonly DateTime StartDateTime = DateTime.Now;

    /// <summary>
    /// Indicate the application settings.
    /// </summary>
    static public ApplicationSettingsBase Settings { get; set; }

    /// <summary>
    /// Indicate if database has been upgraded.
    /// </summary>
    static public bool IsSettingsUpgraded { get; set; }

    /// <summary>
    /// Indicate if database has been upgraded.
    /// </summary>
    static public bool IsDatabaseUpgraded { get; set; }

    /// <summary>
    /// Indicate if the application is in loading data stage.
    /// </summary>
    static public bool IsLoadingData { get; set; }

    /// <summary>
    /// Indicate if the application is ready to interact with the user or do its purpose.
    /// </summary>
    static public bool IsReady { get; set; }

    /// <summary>
    /// Indicate if data are read only.
    /// </summary>
    static public bool IsReadOnly { get; set; }

    /// <summary>
    /// Indicate if data is being generated.
    /// </summary>
    static public bool IsGenerating { get; set; }

    /// <summary>
    /// Indicate if data is being printed.
    /// </summary>
    static public bool IsPrinting { get; set; }

    /// <summary>
    /// Indicate if current processing must be cancelled.
    /// </summary>
    static public bool CancelRequired { get; set; }

    /// <summary>
    /// Indicate if the windows session is ending.
    /// </summary>
    static public bool IsSessionEnding { get; set; }

    /// <summary>
    /// Indicate if the application is exiting.
    /// </summary>
    static public bool IsExiting { get; set; }

    /// <summary>
    /// Indicate if the application can be closed.
    /// </summary>
    static public bool AllowClose { get; set; } = true;

  }

}
