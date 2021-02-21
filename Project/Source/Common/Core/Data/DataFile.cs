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
/// <created> 2020-04 </created>
/// <edited> 2020-04 </edited>
using System;
using System.IO;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide data file management.
  /// </summary>
  public abstract class DataFile
  {

    /// <summary>
    /// Indicate source file path in application documents folder.
    /// </summary>
    public string FilePathDefault { get; private set; }

    /// <summary>
    /// Indicate source file path in user data folder.
    /// </summary>
    public string FilePath { get; private set; }

    /// <summary>
    /// Indicate if file not found error must be shown on load.
    /// </summary>
    public bool ShowFileNotFound { get; private set; }

    /// <summary>
    /// Indicate if the list is configurable by using the user data folder.
    /// </summary>
    public bool Configurable { get; private set; }

    /// <summary>
    /// Indicate the folder.
    /// </summary>
    public DataFileFolder Folder { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    public DataFile(string filePath, bool showFileNotFound, bool configurable, DataFileFolder folder)
    {
      ShowFileNotFound = showFileNotFound;
      Configurable = configurable;
      FilePathDefault = filePath;
      Folder = folder;
      switch ( folder )
      {
        case DataFileFolder.ApplicationDocuments:
          FilePath = FilePathDefault;
          break;
        case DataFileFolder.ProgramData:
          FilePath = filePath.Replace(Globals.DocumentsFolderPath, Globals.ProgramDataFolderPath);
          break;
        case DataFileFolder.UserHebrewCommon:
          FilePath = filePath.Replace(Globals.DocumentsFolderPath, Globals.UserDataCommonFolderPath);
          break;
        case DataFileFolder.UserApplication:
          FilePath = filePath.Replace(Globals.DocumentsFolderPath, Globals.UserDataFolderPath);
          break;
        default:
          throw new NotImplementedExceptionEx(folder);
      }
      ReLoad();
    }

    /// <summary>
    /// Load or reload data from disk.
    /// </summary>
    protected abstract void DoReLoad(string filePath);

    /// <summary>
    /// Load or reload data from disk.
    /// </summary>
    public void ReLoad(bool reset = false)
    {
      DoReLoad(CheckFile(reset));
    }

    /// <summary>
    /// Check if file exists in user data folder.
    /// </summary>
    /// <param name="reset">True if must be reseted from application documents folder.</param>
    protected string CheckFile(bool reset)
    {
      if ( reset || !File.Exists(FilePath) )
        if ( !File.Exists(FilePathDefault) )
        {
          if ( ShowFileNotFound )
            DisplayManager.ShowError(SysTranslations.FileNotFound.GetLang(FilePathDefault));
          return string.Empty;
        }
        else
        if ( FilePath != FilePathDefault )
        {
          string folder = Path.GetDirectoryName(FilePath);
          if ( !Directory.Exists(folder) )
            Directory.CreateDirectory(folder);
          string filePath1 = SysTranslations.UndefinedSlot.GetLang();
          string filePath2 = SysTranslations.UndefinedSlot.GetLang();
          try
          {
            filePath1 = FilePathDefault;
            filePath2 = FilePath;
            File.Copy(filePath1, filePath2, true);
          }
          catch ( Exception ex )
          {
            string msg = SysTranslations.LoadFileError.GetLang(filePath1, filePath2, ex.Message);
            DisplayManager.ShowError(msg);
            return string.Empty;
          }
        }
      return FilePath;
    }

  }

}
