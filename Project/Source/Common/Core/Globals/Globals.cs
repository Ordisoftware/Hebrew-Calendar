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
/// <edited> 2021-02 </edited>
using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Linq;

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

    /// <summary>
    /// Indicate bullet.
    /// </summary>
    static public readonly string Bullet = "•";

    /// <summary>
    /// Indicate list separator.
    /// </summary>
    static public readonly string ListSeparator = "-";

    /// <summary>
    /// Indicate if SSL certificate is preloaded.
    /// </summary>
    static public bool PreLoadSSLCertificate = true;

    /// <summary>
    /// Indicate if the application must go to tray icon at startup.
    /// </summary>
    static public bool ForceStartupHide;

    /// <summary>
    /// Indicate StopWatches.
    /// </summary>
    static public Stopwatch ChronoLoadApp = new Stopwatch();
    static public Stopwatch ChronoLoadData = new Stopwatch();
    static public Stopwatch ChronoCreateData = new Stopwatch();
    static public Stopwatch ChronoShowData = new Stopwatch();

    /// <summary>
    /// Indicate keyboard shortcuts notice form.
    /// </summary>
    static public ShowTextForm NoticeKeyboardShortcutsForm;

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
      get => _MainForm ?? ( Application.OpenForms.Count > 0 ? Application.OpenForms[0] : FormsHelper.GetActiveForm() );
      set => _MainForm = value;
    }
    static private Form _MainForm;

    /// <summary>
    /// Indicate brint to front application system hot key.
    /// </summary>
    static public readonly SystemHotKey BringToFrontApplicationHotKey
      = new SystemHotKey();

    /// <summary>
    /// Purge images from localized resource form code files.
    /// https://stackoverflow.com/questions/15340615/resx-form-icon-cascade-updates#42977949
    /// </summary>
    static private void PurgeResourceImages()
    {
      try
      {
        string path = ProjectFolderPath;
        string[] files = Directory.GetFiles(path, "*fr.resx", SearchOption.AllDirectories);
        foreach ( string file in files )
        {
          var xdoc = XDocument.Load(file);
          var elements = xdoc.Root.Elements("data");
          var items = elements.Where(item => ( (string)item.Attribute("name") ).Contains(".Image")).ToList();
          if ( items.Count > 0 )
          {
            if ( !IsExiting )
            {
              MessageBox.Show("Purge *fr.resx images and exit.", AssemblyTitle);
              IsExiting = true;
            }
            foreach ( var item in items )
              item.Remove();
            xdoc.Save(file);
          }
        }
      }
      catch ( Exception ex )
      {
        MessageBox.Show(ex.Message, AssemblyTitle);
        IsExiting = true;
      }
      if ( IsExiting )
        Environment.Exit(0);
    }

    /// <summary>
    /// Static constructor.
    /// </summary>
    static Globals()
    {
      #if DEBUG
      if ( !IsVisualStudioDesigner ) PurgeResourceImages();
      #endif
    }

  }

}
