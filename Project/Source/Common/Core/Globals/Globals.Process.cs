/// <license>
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
/// <created> 2016-04 </created>
/// <edited> 2022-05 </edited>
namespace Ordisoftware.Core;

using Meziantou.Framework.Win32;

/// <summary>
/// Provides global variables.
/// </summary>
static public partial class Globals
{

  /// <summary>
  /// Indicates the application process name.
  /// </summary>
  static public string ProcessName
    => Path.GetFileNameWithoutExtension(Application.ExecutablePath);

  /// <summary>
  /// Indicates if the current process is in admin mode.
  /// </summary>
  static public bool IsCurrentProcessAdmin
  {
    get
    {
      using var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
      var principal = new System.Security.Principal.WindowsPrincipal(identity);
      return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
    }
  }

  /// <summary>
  /// Indicates if the current user is an admin.
  /// </summary>
  /// <remarks>
  /// See https://www.meziantou.net/check-if-the-current-user-is-an-administrator.htm
  /// </remarks>
  static public bool IsCurrentUserAdmin
  {
    get
    {
      using var token = AccessToken.OpenCurrentProcessToken(TokenAccessLevels.Query);
      if ( !isAdministrator(token) && token.GetElevationType() == TokenElevationType.Limited )
        using ( var linkedToken = token.GetLinkedToken() )
          return isAdministrator(linkedToken);
      else
        return false;
      //
      static bool isAdministrator(AccessToken accessToken)
      {
        var adminSid = SecurityIdentifier.FromWellKnown(WellKnownSidType.WinBuiltinAdministratorsSid);
        foreach ( var group in accessToken.EnumerateGroups() )
          if ( group.Attributes.HasFlag(GroupSidAttributes.SE_GROUP_ENABLED) && group.Sid == adminSid )
            return true;
        return false;
      }
    }
  }

  /// <summary>
  /// Indicates the application process ID.
  /// </summary>
  static public int ProcessId
    => Process.GetCurrentProcess().Id;

  /// <summary>
  /// Indicates the number of application running processes count.
  /// </summary>
  static public int ApplicationInstancesCount
    => Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length;

  /// <summary>
  /// Indicates running processes whose names starts with "AssemblyCompany.".
  /// </summary>
  static public IEnumerable<Process> SameCompanyRunningProcesses
    => Process.GetProcesses().Where(p => p.ProcessName.StartsWith($"{AssemblyCompany}.",
                                                                  StringComparison.CurrentCultureIgnoreCase));

  /// <summary>
  /// Indicates running processes whose names starts with "[AssemblyCompany]." not being this one.
  /// </summary>
  static public IEnumerable<Process> ConcurrentRunningProcesses
    => SameCompanyRunningProcesses.Where(p => p.Id != ProcessId);

  /// <summary>
  /// Indicates running processes being the same as this application not being this one.
  /// </summary>
  static public IEnumerable<Process> SameRunningProcessesNotThisOne
    => ConcurrentRunningProcesses.Where(p => p.ProcessName == ProcessName);

  /// <summary>
  /// Indicates if the executable has been generated in debug mode.
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
  /// Indicates if the running app is from dev folder else user installed.
  /// </summary>
  static public bool IsDevExecutable
    => Application.ExecutablePath.Contains(DebugDirectoryCombination)
       || Application.ExecutablePath.Contains(ReleaseDirectoryCombination);

  /// <summary>
  /// Indicates if the code is in design time
  /// </summary>
  public static bool IsDesignTime
    => LicenseManager.UsageMode == LicenseUsageMode.Designtime;

  /// <summary>
  /// Indicates if the code is executed from the IDE else from a running app.
  /// </summary>
  public static bool IsVisualStudioDesigner
    => ProcessName == "devenv";

}
