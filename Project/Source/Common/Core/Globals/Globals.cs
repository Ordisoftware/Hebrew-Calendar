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
/// <edited> 2021-11 </edited>
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide global variables.
  /// </summary>
  static partial class Globals
  {

    /// <summary>
    /// Indicate new line.
    /// </summary>
    static public readonly string NL = Environment.NewLine;
    static public readonly string NL2 = NL + NL;
    static public readonly string NL3 = NL2 + NL;
    static public readonly string NL4 = NL3 + NL;
    static public readonly string NL5 = NL4 + NL;

    /// <summary>
    /// Indicate bullet.
    /// </summary>
    static public string Bullet { get; set; } = "•";

    /// <summary>
    /// Indicate list separator.
    /// </summary>
    static public string ListSeparator { get; set; } = "-";

    /// <summary>
    /// Indicate CSV separator.
    /// </summary>
    static public char CSVSeparator { get; set; } = ';';

    /// <summary>
    /// Indicate if SSL certificate is preloaded.
    /// </summary>
    static public bool PreLoadSSLCertificate { get; set; } = true;

    /// <summary>
    /// Indicate if the application must go to tray icon at startup.
    /// </summary>
    static public bool ForceStartupHide { get; set; }

    /// <summary>
    /// Indicate StopWatches.
    /// </summary>
    static public readonly Stopwatch ChronoStartingApp = new();
    static public readonly Stopwatch ChronoTranslate = new();
    static public readonly Stopwatch ChronoLoadData = new();
    static public readonly Stopwatch ChronoCreateData = new();
    static public readonly Stopwatch ChronoShowData = new();

    /// <summary>
    /// Indicate keyboard shortcuts notice form.
    /// </summary>
    static public ShowTextForm NoticeKeyboardShortcutsForm { get; internal set; }

    /// <summary>
    /// Indicate the application code (title without space).
    /// </summary>
    static public string ApplicationCode
      => AssemblyTitle.Replace(" ", string.Empty);

    /// <summary>
    /// Indicate the application GitHub code (title with '-' instead of space.
    /// </summary>
    static public string ApplicationGitHubCode
      => AssemblyTitle.Replace(" ", "-");

    /// <summary>
    /// Indicate the application process name.
    /// </summary>
    static public string ProcessName
      => Path.GetFileNameWithoutExtension(Application.ExecutablePath);

    /// <summary>
    /// Indicate the application process ID.
    /// </summary>
    static public int ProcessId
      => Process.GetCurrentProcess().Id;

    /// <summary>
    /// Indicate the number of application running processes count.
    /// </summary>
    static public int ApplicationInstancesCount
      => Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length;

    /// <summary>
    /// Indicate running processes whose names starts with "AssemblyCompany.".
    /// </summary>
    static public IEnumerable<Process> SameCompanyRunningProcesses
      => Process.GetProcesses().Where(p => p.ProcessName.StartsWith(AssemblyCompany + "."));

    /// <summary>
    /// Indicate running processes whose names starts with "[AssemblyCompany]." not being this one.
    /// </summary>
    static public IEnumerable<Process> ConcurrentRunningProcesses
      => SameCompanyRunningProcesses.Where(p => p.Id != ProcessId);

    /// <summary>
    /// Indicate running processes being the same as this application not being this one.
    /// </summary>
    static public IEnumerable<Process> SameRunningProcessesNotThisOne
      => ConcurrentRunningProcesses.Where(p => p.ProcessName == ProcessName);

    /// <summary>
    /// Indicate if the executable has been generated in debug mode.
    /// </summary>
    static public bool IsDebugExecutable
    {
      get
      {
        bool isDebug = false;
        CheckDebugExecutable(ref isDebug);
        return isDebug;
      }
    }

    [Conditional("DEBUG")]
    static private void CheckDebugExecutable(ref bool isDebug)
      => isDebug = true;

    /// <summary>
    /// Indicate if the running app is from dev folder else user installed.
    /// </summary>
    static public bool IsDevExecutable
      => Application.ExecutablePath.Contains(DebugDirectoryCombination)
      || Application.ExecutablePath.Contains(ReleaseDirectoryCombination);

    /// <summary>
    /// Indicate if the code is in design time
    /// </summary>
    public static bool IsDesignTime
      => System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime;

    /// <summary>
    /// Indicate if the code is executed from the IDE else from a running app.
    /// </summary>
    public static bool IsVisualStudioDesigner
      => ProcessName == "devenv";

    /// <summary>
    /// Indicate the main form.
    /// </summary>
    static public Form MainForm
    {
      get => _MainForm ?? ( Application.OpenForms.Count > 0 ? Application.OpenForms[0] : Form.ActiveForm );
      set => _MainForm = value;
    }
    static private Form _MainForm;

    /// <summary>
    /// Indicate brint to front application system hot key.
    /// </summary>
    static public readonly SystemHotKey BringToFrontApplicationHotKey = new();

    /// <summary>
    /// Static constructor.
    /// </summary>
    static Globals()
    {
#if DEBUG
      if ( !IsVisualStudioDesigner )
      {
        bool conditional = IsExiting;
        StackMethods.PurgeResourceImages(AssemblyTitle, ProjectFolderPath, ref conditional);
        IsExiting = conditional;
      }
#endif
    }

  }

}
