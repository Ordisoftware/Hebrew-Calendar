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

    public const string OldTraceDirectoryName = "Logs";

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

    static public string SinkFileTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss} " +
                                             "P{ProcessId}:T{ThreadId} " +
                                             "{Message:lj}{NewLine}{Exception}";

    static public int SinkFileTemplateSize = "YYYY-MM-DD HH:MM:SS [P000000:T000000]".Length;

    /// <summary>
    /// Indicate the log/trace directory name.
    /// </summary>
    static public string SinkDirectoryName { get; set; }
      = "Serilog";

    /// <summary>
    /// Indicate the trace file extension.
    /// </summary>
    static public string SinkFileExtension { get; set; }
      = ".log";

    /// <summary>
    /// Indicate the trace file code.
    /// </summary>
    static public string SinkFileCode { get; set; }
      = ApplicationGitHubCode + "-Trace-";

    /// <summary>
    /// Indicate the user application trace folder path.
    /// </summary>
    static public string SinkFileFolderPath
      => Path.Combine(UserDataFolderPath, SinkDirectoryName);

    static public string OldTraceFolderPath
      => Path.Combine(UserDataFolderPath, OldTraceDirectoryName);

    /// <summary>
    /// Indicate the serilog sink file absolute full path and name pattern.
    /// </summary>
    static public string SinkFileNoRollingPatternPath
      => Path.Combine(SinkFileFolderPath, SinkFileCode) + "%DATETIME%" + SinkFileExtension;

    static public string SinkFileRollingPatternPath
      => Path.Combine(SinkFileFolderPath, SinkFileCode) + SinkFileExtension;

  }

}
