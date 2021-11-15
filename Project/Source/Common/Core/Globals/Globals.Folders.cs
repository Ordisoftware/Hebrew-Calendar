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
/// <edited> 2021-08 </edited>
using System;
using System.IO;
using System.Windows.Forms;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provides global variables.
  /// </summary>
  static partial class Globals
  {

    /// <summary>
    /// Indicates Hebrew Common directory name.
    /// </summary>
    static public string HebrewCommonDirectoryName
      => "Hebrew Common";

    /// <summary>
    /// Indicates generated executable bin directory name.
    /// </summary>
    static public string BinDirectoryName
      => "Bin";

    /// <summary>
    /// Indicates generated executable bin\debug directory combination.
    /// </summary>
    static public string DebugDirectoryCombination
      => Path.Combine(BinDirectoryName, "Debug");

    /// <summary>
    /// Indicates generated executable bin\release directory combination.
    /// </summary>
    static public string ReleaseDirectoryCombination
      => Path.Combine(BinDirectoryName, "Release");

    /// <summary>
    /// Indicates the application executable file path.
    /// </summary>
    static public string ApplicationExeFullPath
      => System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;

    /// <summary>
    /// Indicates the application executable file name.
    /// </summary>
    static public string ApplicationExeFileName
      => Path.GetFileNameWithoutExtension(ApplicationExeFullPath);

    /// <summary>
    /// Indicates the application full file name.
    /// </summary>
    static public string ApplicationFullFileName
      => ApplicationExeFileName.Replace(".", " ");

    /// <summary>
    /// Indicates the application startup regustry value in Run key.
    /// </summary>
    static public string ApplicationStartupRegistryValue
      => $"\"{Application.ExecutablePath}\" --hide";

    /// <summary>
    /// Indicates the root folder path of the application.
    /// </summary>
    static public string RootFolderPath
      => Directory.GetParent(Path.GetDirectoryName(Application.ExecutablePath
                                                              .Replace(DebugDirectoryCombination, BinDirectoryName)
                                                              .Replace(ReleaseDirectoryCombination, BinDirectoryName))).FullName;

    /// <summary>
    /// Indicates the application executable path.
    /// </summary>
    static public string ApplicationExePath
      => Application.StartupPath;

    /// <summary>
    /// Indicates the application system folder path.
    /// </summary>
    static public string SystemFolderPath
      => Path.Combine(RootFolderPath, "System");

    /// <summary>
    /// Indicates the application help folder path.
    /// </summary>
    static public string HelpFolderPath
      => Path.Combine(RootFolderPath, "Help");

    /// <summary>
    /// Indicates the application documents folder path.
    /// </summary>
    static public string DocumentsFolderPath
      => Path.Combine(RootFolderPath, "Documents");

    /// <summary>
    /// Indicates the application project folder path.
    /// </summary>
    static public string ProjectFolderPath
      => Path.Combine(RootFolderPath, "Project");

    /// <summary>
    /// Indicates the application source code folder path.
    /// </summary>
    static public string ProjectSourceFolderPath
      => Path.Combine(ProjectFolderPath, "Source");

    /// <summary>
    /// Indicates the project sounds folder path.
    /// </summary>
    static public string ProjectMediasFolderPath
      => Path.Combine(ProjectFolderPath, "Medias");

    /// <summary>
    /// Indicates the project icons folder path.
    /// </summary>
    static public string ProjectIconsFolderPath
      => Path.Combine(ProjectMediasFolderPath, "Icons");

    /// <summary>
    /// Indicates the project sounds folder path.
    /// </summary>
    static public string ProjectSoundsFolderPath
      => Path.Combine(ProjectMediasFolderPath, "Sounds");

    /// <summary>
    /// Indicates the application sounds folder.
    /// </summary>
    static public string ApplicationSoundsFolderPath
      => Path.Combine(RootFolderPath, "Sounds");

    /// <summary>
    /// Indicates the user applicationdatabase folder path.
    /// </summary>
    static public string DatabaseFolderPath
      => UserDataFolderPath;

    /// <summary>
    /// Indicates the company program files folder path.
    /// </summary>
    static public string CompanyProgramFilesFolderPath
      => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), AssemblyCompany);

    /// <summary>
    /// Indicates the Windows media folder path.
    /// </summary>
    static public string WindowsMediaFolderPath
      => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Media");

    /// <summary>
    /// Indicates the user music folder path.
    /// </summary>
    static public string UserMusicFolderPath
      => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "Media");

    /// <summary>
    /// Indicates the user documents folder path.
    /// </summary>
    static public string UserDocumentsFolderPath
      => CreateSpecialFolderPath(Environment.SpecialFolder.MyDocuments, AssemblyTitle);

    /// <summary>
    /// Indicates the user data folder in local.
    /// </summary>
    static public string UserLocalDataFolderPath
      => CreateSpecialFolderPath(Environment.SpecialFolder.LocalApplicationData, string.Empty);

    /// <summary>
    /// Indicates the user data folder in roaming.
    /// </summary>
    static public string UserDataFolderPath
      => CreateSpecialFolderPath(Environment.SpecialFolder.ApplicationData, AssemblyTitle);

    /// <summary>
    /// Indicates the hebrew common data folder in roaming.
    /// </summary>
    static public string UserDataCommonFolderPath
      => CreateSpecialFolderPath(Environment.SpecialFolder.ApplicationData, HebrewCommonDirectoryName);

    /// <summary>
    /// Indicates the hebrew common data folder in program data.
    /// </summary>
    static public string ProgramDataFolderPath
      => CreateSpecialFolderPath(Environment.SpecialFolder.CommonApplicationData, HebrewCommonDirectoryName);

    /// <summary>
    /// Indicates a path for in a special folder path.
    /// </summary>
    static public string CreateSpecialFolderPath(Environment.SpecialFolder folder, string directory)
      => Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(folder),
                                                AssemblyCompany,
                                                directory)).FullName;

  }

}
