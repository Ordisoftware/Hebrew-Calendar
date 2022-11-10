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
/// <created> 2016-04 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides global variables.
/// </summary>
static public partial class Globals
{

  static public TraceFileRollOverMode TraceFileRollOverMode { get; set; }
    = TraceFileRollOverMode.Session;

  static public Serilog.RollingInterval SinkFileRollingInterval { get; set; }
    = IsVisualStudioDesigner ? 0 : Serilog.RollingInterval.Day;

  static public int SinkFileRetainedFileCountLimit { get; set; }
    = DaysOfWeekCount;

  static public int SessionFileRetainedFileCountLimit { get; set; }
    = MaxFilesAllowed;

  static public int SinkFileSizeLimitBytes { get; set; }
    = 100 * 1024 * 1024;

  static public string SinkFileEventTemplate { get; set; }
    = "{Timestamp:yyyy-MM-dd HH:mm:ss} " +
      "P{ProcessId}:T{ThreadId} " +
      "{Message:lj}{NewLine}{Exception}";

  static public int SinkFileEventTemplateSize { get; set; }
    = "YYYY-MM-DD HH:MM:SS [P000000:T000000]".Length - 1;

  static private readonly string OldTraceDirectoryName = "Logs";

  static public string TraceDirectoryName { get; set; }
    = "Serilog";

  static public string TraceFileExtension { get; set; }
    = ".log";

  static public string TraceSessionFileTemplate { get; set; }
    = "yyyy-MM-dd@HH-mm-ss";

  static public string SinkFileCode { get; set; }
    = ApplicationGitHubCode + "-Trace-";

  static public string SinkFileFolderPath
    => Directory.CreateDirectory(Path.Combine(UserDataFolderPath, TraceDirectoryName)).FullName;

  static public string SinkFileNoRollingPatternPathDateTag { get; set; }
    = "%DATETIME%";

  static public string SinkFileNoRollingFilePatternPath
    => Path.Combine(SinkFileFolderPath, SinkFileCode) + SinkFileNoRollingPatternPathDateTag + TraceFileExtension;

  static public string SinkFileRollingFilePatternPath
    => Path.Combine(SinkFileFolderPath, SinkFileCode) + TraceFileExtension;

  static public string OldTraceFolderPath
    => Path.Combine(UserDataFolderPath, OldTraceDirectoryName);

  static public readonly Dictionary<LogTraceEvent, char> TraceSigns = new()
  {
    [LogTraceEvent.System] = ' ',
    [LogTraceEvent.Start] = '>',
    [LogTraceEvent.Stop] = '.',
    [LogTraceEvent.Enter] = '+',
    [LogTraceEvent.Leave] = '-',
    [LogTraceEvent.Completed] = ':',
    [LogTraceEvent.Message] = '#',
    [LogTraceEvent.Data] = '*',
    [LogTraceEvent.Error] = '!',
    [LogTraceEvent.Exception] = '!'
  };

}
