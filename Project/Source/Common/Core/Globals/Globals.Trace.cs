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
/// <edited> 2021-05 </edited>
using System;
using System.IO;
using Serilog;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide global variables.
  /// </summary>
  static partial class Globals
  {

    static public TraceFileRollOverMode TraceFileRollOverMode { get; set; }
      = TraceFileRollOverMode.Session;

    static public RollingInterval SinkFileRollingInterval { get; set; }
      = IsVisualStudioDesigner ? 0 : RollingInterval.Day;

    static public int SinkFileRetainedFileCountLimit { get; set; }
      = 7;

    static public int SessionFileRetainedFileCountLimit { get; set; }
      = 20;

    static public int SinkFileSizeLimitBytes { get; set; }
      = 100 * 1024 * 1024;

    static public string SinkFileEventTemplate
      = "{Timestamp:yyyy-MM-dd HH:mm:ss} " +
        "P{ProcessId}:T{ThreadId} " +
        "{Message:lj}{NewLine}{Exception}";

    static public int SinkFileEventTemplateSize
      = "YYYY-MM-DD HH:MM:SS [P000000:T000000]".Length;

    static public string TraceDirectoryName { get; set; }
      = "Serilog";

    static public string TraceFileExtension { get; set; }
      = ".log";

    static public string TraceSessionFileTemplate
      = "yyyy-MM-dd@HH-mm-ss";

    static public string SinkFileCode { get; set; }
      = ApplicationGitHubCode + "-Trace-";

    static public string SinkFileFolderPath
      => Directory.CreateDirectory(Path.Combine(UserDataFolderPath, TraceDirectoryName)).FullName;

    static public string SinkFileNoRollingPatternPathDateTag
      = "%DATETIME%";

    static public string SinkFileNoRollingFilePatternPath
      => Path.Combine(SinkFileFolderPath, SinkFileCode) + SinkFileNoRollingPatternPathDateTag + TraceFileExtension;

    static public string SinkFileRollingFilePatternPath
      => Path.Combine(SinkFileFolderPath, SinkFileCode) + TraceFileExtension;

    static public string OldTraceFolderPath
      => Path.Combine(UserDataFolderPath, OldTraceDirectoryName);

    public const string OldTraceDirectoryName = "Logs";

  }

}
