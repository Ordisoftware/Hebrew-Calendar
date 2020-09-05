/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2020 Olivier Rogier.
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
/// <edited> 2020-08 </edited>
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide global variables.
  /// </summary>
  static public partial class Globals
  {

    /// <summary>
    /// Indicate new line.
    /// </summary>
    static public readonly string NL = Environment.NewLine;
    static public readonly string NL2 = NL + NL;
    static public readonly string NL3 = NL2 + NL;
    static public readonly string NL4 = NL3 + NL;

    /// <summary>
    /// Indicate the application code (title without space).
    /// </summary>
    static public string ApplicationCode
      => AssemblyTitle.Replace(" ", "");

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

    /// Indicate if the running app is from dev folder else user installed.
    /// </summary>
    static public bool IsDevExecutable
      => Application.ExecutablePath.Contains(DebugDirectory) || Application.ExecutablePath.Contains(ReleaseDirectory);

    /// <summary>
    /// <summary>
    /// Indicate if the code is executed from the IDE else from a running app.
    /// </summary>
    public static bool IsDesignTime
      => System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime;

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
    /// Indicate the online search a word providers.
    /// </summary>
    static public OnlineProviders OnlineWordProviders { get; private set; }

    /// <summary>
    /// Indicate the online bible verse providers.
    /// </summary>
    static public OnlineProviders OnlineBibleProviders { get; private set; }

    /// <summary>
    /// Indicate the web links providers.
    /// </summary>
    static public List<OnlineProviders> WebLinksProviders { get; private set; }

    /// <summary>
    /// Create an online OnlineProviders instance.
    /// </summary>
    /// <param name="folder"></param>
    /// <param name="filename"></param>
    /// <returns></returns>
    static private OnlineProviders CreateOnlineProviders(DataFileFolder folder, string filename)
    {
      try
      {
        return new OnlineProviders(filename, true, IsDevExecutable, folder);
      }
      catch ( Exception ex )
      {
        DisplayManager.ShowError(Localizer.LoadFileError.GetLang(filename, ex.Message));
        return null;
      }
    }

    /// <summary>
    /// Static constructor.
    /// </summary>
    static Globals()
    {
      if ( IsDesignTime ) return;
      var folder = DataFileFolder.ApplicationDocuments;
      OnlineWordProviders = CreateOnlineProviders(folder, OnlineWordProvidersFileName);
      OnlineBibleProviders = CreateOnlineProviders(folder, OnlineBibleProvidersFileName);
      WebLinksProviders = new List<OnlineProviders>();
      if ( Directory.Exists(WebLinksFolderPath) )
        SystemManager.TryCatch(() =>
        {
          foreach ( var file in Directory.GetFiles(WebLinksFolderPath, "WebLinks*.txt") )
          {
            var item = CreateOnlineProviders(DataFileFolder.ApplicationDocuments, file);
            if ( item != null ) WebLinksProviders.Add(item);
          }
        });
    }

  }

}
