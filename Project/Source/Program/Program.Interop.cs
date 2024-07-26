/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2024 Olivier Rogier.
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
/// <edited> 2024-06 </edited>
namespace Ordisoftware.Hebrew.Calendar;

using System.IO.Pipes;

/// <summary>
/// Provides Program class.
/// </summary>
static partial class Program
{

  /// <summary>
  /// IPC requests.
  /// </summary>
  [SuppressMessage("CodeQuality", "IDE0079:Retirer la suppression inutile", Justification = "N/A")]
  [SuppressMessage("Vulnerability", "SEC0029:Insecure Deserialization", Justification = "N/A")]
  static void IPCRequests(IAsyncResult ar)
  {
    var server = ar.AsyncState as NamedPipeServerStream;
    try
    {
      server.EndWaitForConnection(ar);
      using var reader = new BinaryReader(server);
      string command = reader.ReadString();
      if ( command is null ) return;
      if ( !Globals.IsReady ) return;
      var lang = Settings.LanguageSelected;
      SystemManager.CheckCommandLineArguments<ApplicationCommandLine>(command.SplitKeepEmptyLines(" "), ref lang);
      var form = MainForm.Instance;
      var cmd = ApplicationCommandLine.Instance;
      if ( cmd is null ) return;
      Action action = null;
      if ( cmd.ShowMainForm ) action = () => form.MenuShowHide_Click(null, null);
      if ( cmd.HideMainForm ) action = form.ForceHideToTray;
      if ( cmd.Generate ) action = form.ActionGenerate.PerformClick;
      if ( cmd.ResetReminder ) action = form.ActionResetReminder.PerformClick;
      if ( cmd.OpenNavigation ) action = form.ActionNavigate.PerformClick;
      if ( cmd.OpenDatesDifference ) action = form.ActionCalculateDateDiff.PerformClick;
      if ( cmd.OpenCelebrationVersesBoard ) action = form.ActionShowCelebrationVersesBoard.PerformClick;
      if ( cmd.OpenCelebrationsBoard ) action = form.ActionShowCelebrationsBoard.PerformClick;
      if ( cmd.OpenNewMoonsBoard ) action = form.ActionShowNewMoonsBoard.PerformClick;
      if ( cmd.OpenParashotBoard ) action = form.ActionShowParashotBoard.PerformClick;
      if ( cmd.OpenWeeklyParashahBox ) action = form.ActionWeeklyParashahDescription.PerformClick;
      // TODO when ready : update
      if ( cmd.OpenLunarMonthsBoard ) action = SystemManager.CommandLineOptions.IsPreviewEnabled
                                               ? form.ActionShowLunarMonths.PerformClick
                                               : null;
      if ( action is not null ) SystemManager.TryCatch(() => form.ToolStrip.SyncUI(action));
    }
    catch ( EndOfStreamException ex )
    {
      ex.Manage(ShowExceptionMode.None);
    }
    catch ( Exception ex ) when ( ex is ObjectDisposedException || ex is IOException )
    {
      ex.Manage();
    }
    finally
    {
      server.Close();
      SystemManager.CreateIPCServer(IPCRequests);
    }
  }

  /// <summary>
  /// Processes command line options.
  /// </summary>
  static private void ProcessCommandLineOptions()
  {
    try
    {
      if ( SystemManager.CommandLineOptions is null ) return;
      if ( SystemManager.CommandLineOptions.ResetSettings )
      {
        SystemManager.CleanAllLocalAppSettingsFolders();
        CheckSettingsReset(true);
      }
      else
      if ( !Settings.FirstLaunch && SystemManager.CommandLineOptions.HideMainForm )
        Globals.ForceStartupHide = true;
    }
    catch ( Exception ex )
    {
      ex.Manage();
    }
  }

}
