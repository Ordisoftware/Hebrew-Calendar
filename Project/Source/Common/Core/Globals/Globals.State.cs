/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2025 Olivier Rogier.
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
/// <edited> 2024-01 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides global variables.
/// </summary>
static public partial class Globals
{

  /// <summary>
  /// Indicates the process start date and time.
  /// </summary>
  static public readonly DateTime StartDateTime = DateTime.Now;

  /// <summary>
  /// Indicates the application settings.
  /// </summary>
  static public System.Configuration.ApplicationSettingsBase Settings { get; set; }

  /// <summary>
  /// Indicates if database has been upgraded.
  /// </summary>
  static public bool IsSettingsUpgraded { get; set; }

  /// <summary>
  /// Indicates if database has been upgraded.
  /// </summary>
  static public bool IsDatabaseUpgraded { get; set; }

  /// <summary>
  /// Indicates if the application is in loading data stage.
  /// </summary>
  static public bool IsLoadingData { get; set; }

  /// <summary>
  /// Indicates if the application is in loading or rendering or generating data stage.
  /// </summary>
  static public bool IsProcessingData => IsLoadingData || IsRendering || IsGenerating;

  /// <summary>
  /// Indicates if the application is ready to interact with the user or do its purpose.
  /// </summary>
  static public bool IsReady { get; set; }

  /// <summary>
  /// Indicates if data are read only.
  /// </summary>
  static public bool IsReadOnly { get; set; }

  /// <summary>
  /// Indicates if data is being generated.
  /// </summary>
  static public bool IsGenerating { get; set; }

  /// <summary>
  /// Indicates if data is being rendered.
  /// </summary>
  static public bool IsRendering { get; set; }

  /// <summary>
  /// Indicates if data is being processed.
  /// </summary>
  static public bool IsInBatch { get; set; }

  /// <summary>
  /// Indicates if data is being printed.
  /// </summary>
  static public bool IsPrinting { get; set; }

  /// <summary>
  /// Indicates if the windows session is ending.
  /// </summary>
  static public bool IsSessionEnding { get; set; }

  /// <summary>
  /// Indicates if the application is exiting.
  /// </summary>
  static public bool IsExiting { get; set; }

  /// <summary>
  /// Indicates if the application can be closed.
  /// </summary>
  static public bool AllowClose { get; set; } = true;

  /// <summary>
  /// Indicates if current processing must be paused.
  /// </summary>
  static public bool PauseRequired { get; set; }

  /// <summary>
  /// Indicates if current processing must be canceled.
  /// </summary>
  static public bool CancelRequired { get; set; }

}
