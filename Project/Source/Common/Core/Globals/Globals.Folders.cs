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
using System.Windows.Forms;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide global variables.
  /// </summary>
  static partial class Globals
  {

    /// <summary>
    /// Indicate Hebrew Common directory name.
    /// </summary>
    static public string HebrewCommonDirectoryName
      => "Hebrew Common";

    /// <summary>
    /// Indicate generated executable bin directory name.
    /// </summary>
    static public string BinDirectoryName
      => "Bin";

    /// <summary>
    /// Indicate generated executable bin\debug directory combination.
    /// </summary>
    static public string DebugDirectoryCombination
      => Path.Combine(BinDirectoryName, "Debug");

    /// <summary>
    /// Indicate generated executable bin\release directory combination.
    /// </summary>
    static public string ReleaseDirectoryCombination
      => Path.Combine(BinDirectoryName, "Release");

    /// <summary>
    /// Indicate the application executable file name.
    /// </summary>
    static public string ApplicationExeFileName
      => Path.GetFileNameWithoutExtension(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);

    /// <summary>
    /// Indicate the application full file name.
    /// </summary>
    static public string ApplicationFullFileName
      => ApplicationExeFileName.Replace(".", " ");

    /// <summary>
    /// Indicate the application startup regustry value in Run key.
    /// </summary>
    static public string ApplicationStartupRegistryValue
      => $"\"{Application.ExecutablePath}\" --hide";

    /// <summary>
    /// Indicate the root folder path of the application.
    /// </summary>
    static public string RootFolderPath
      => Directory.GetParent(Path.GetDirectoryName(Application.ExecutablePath
                                                              .Replace(DebugDirectoryCombination, BinDirectoryName)
                                                              .Replace(ReleaseDirectoryCombination, BinDirectoryName))).FullName;

    /// <summary>
    /// Indicate the application executable path.
    /// </summary>
    static public string ApplicationExePath
      => Application.StartupPath;

    /// <summary>
    /// Indicate the application system folder path.
    /// </summary>
    static public string SystemFolderPath
      => Path.Combine(RootFolderPath, "System");

    /// <summary>
    /// Indicate the application help folder path.
    /// </summary>
    static public string HelpFolderPath
      => Path.Combine(RootFolderPath, "Help");

    /// <summary>
    /// Indicate the application documents folder path.
    /// </summary>
    static public string DocumentsFolderPath
      => Path.Combine(RootFolderPath, "Documents");

    /// <summary>
    /// Indicate the application project folder path.
    /// </summary>
    static public string ProjectFolderPath
      => Path.Combine(RootFolderPath, "Project");

    /// <summary>
    /// Indicate the application source code folder path.
    /// </summary>
    static public string ProjectSourceFolderPath
      => Path.Combine(ProjectFolderPath, "Source");

    /// <summary>
    /// Indicate the project sounds folder path.
    /// </summary>
    static public string ProjectMediasFolderPath
      => Path.Combine(ProjectFolderPath, "Medias");

    /// <summary>
    /// Indicate the project icons folder path.
    /// </summary>
    static public string ProjectIconsFolderPath
      => Path.Combine(ProjectMediasFolderPath, "Icons");

    /// <summary>
    /// Indicate the project sounds folder path.
    /// </summary>
    static public string ProjectSoundsFolderPath
      => Path.Combine(ProjectMediasFolderPath, "Sounds");

    /// <summary>
    /// Indicate the application sounds folder.
    /// </summary>
    static public string ApplicationSoundsFolderPath
      => Path.Combine(RootFolderPath, "Sounds");

    /// <summary>
    /// Indicate the user applicationtrace folder path.
    /// </summary>
    static public string TraceFolderPath
      => Path.Combine(UserDataFolderPath, TraceDirectoryName);

    /// <summary>
    /// Indicate the user applicationdatabase folder path.
    /// </summary>
    static public string DatabaseFolderPath
      => UserDataFolderPath;

    /// <summary>
    /// Indicate the Windows media folder path.
    /// </summary>
    static public string WindowsMediaFolderPath
      => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Media");

    /// <summary>
    /// Indicate the user music folder path.
    /// </summary>
    static public string UserMusicFolderPath
      => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "Media");

    /// <summary>
    /// Indicate the user documents folder path.
    /// </summary>
    static public string UserDocumentsFolderPath
      => CreateSpecialFolderPath(Environment.SpecialFolder.MyDocuments, AssemblyTitle);

    /// <summary>
    /// Indicate the user data folder in local.
    /// </summary>
    static public string UserLocalDataFolderPath
      => CreateSpecialFolderPath(Environment.SpecialFolder.LocalApplicationData, string.Empty);

    /// <summary>
    /// Indicate the user data folder in roaming.
    /// </summary>
    static public string UserDataFolderPath
      => CreateSpecialFolderPath(Environment.SpecialFolder.ApplicationData, AssemblyTitle);

    /// <summary>
    /// Indicate the hebrew common data folder in roaming.
    /// </summary>
    static public string UserDataCommonFolderPath
      => CreateSpecialFolderPath(Environment.SpecialFolder.ApplicationData, HebrewCommonDirectoryName);

    /// <summary>
    /// Indicate the hebrew common data folder in program data.
    /// </summary>
    static public string ProgramDataFolderPath
      => CreateSpecialFolderPath(Environment.SpecialFolder.CommonApplicationData, HebrewCommonDirectoryName);

    /// <summary>
    /// Indicate a path for in a special folder path.
    /// </summary>
    static public string CreateSpecialFolderPath(Environment.SpecialFolder folder, string directory)
      => Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(folder),
                                                AssemblyCompany,
                                                directory)).FullName;

  }

}
