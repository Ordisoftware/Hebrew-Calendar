﻿/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2023 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-12 </created>
/// <edited> 2023-01 </edited>
namespace Ordisoftware.Core;

using CommandLine;

/// <summary>
/// Provides system command line options.
/// </summary>
public class SystemCommandLine
{

  [Option("withpreview", Required = false, HelpText = "Enable preview functionalities.")]
  public bool WithPreview { get; set; } = Globals.IsDebugExecutable;

  [Option("nopreview", Required = false, HelpText = "Disable preview functionalities.")]
  public bool NoPreview { get; set; } = !Globals.IsDebugExecutable;

  public bool IsPreviewEnabled => Globals.IsDebugExecutable ? !NoPreview : WithPreview;

  [Option("reset", Required = false, HelpText = "Erase all application settings as well as those of old versions.")]
  public bool ResetSettings { get; set; }

  [Option("hide", Required = false, HelpText = "Start the application without showing the main form.")]
  public bool HideMainForm { get; set; }

  [Option("show", Required = false, HelpText = "Start the application and show the main form.")]
  public bool ShowMainForm { get; set; }

  [Option("lang", Required = false, HelpText = "Change the interface language.")]
  public string Language { get; set; }

  /// <summary>
  /// Checks if the app is in preview mode or not and display a notice if needed.
  /// </summary>
  static public void CheckPreviewNotice(ref bool previewModeNotified)
  {
    if ( CommonMenusControl.PreviewFunctions is null ) return;
    if ( !SystemManager.CommandLineOptions.IsPreviewEnabled || previewModeNotified ) return;
    string msg = SysTranslations.AskForPreviewMode.GetLang(CommonMenusControl.PreviewFunctions[Languages.Current]);
    if ( !DisplayManager.QueryYesNo(msg) )
    {
      SystemManager.CommandLineOptions.WithPreview = false;
      SystemManager.CommandLineOptions.NoPreview = true;
    }
    previewModeNotified = true;
  }

}
