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
/// <edited> 2021-04 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides data file management.
/// </summary>
public abstract class DataFile
{

  /// <summary>
  /// Indicates source file path in application documents folder.
  /// </summary>
  public string FilePathDefault { get; }

  /// <summary>
  /// Indicates source file path in user data folder.
  /// </summary>
  public string FilePath { get; }

  /// <summary>
  /// Indicates if file not found error must be shown on load.
  /// </summary>
  public bool ShowFileNotFound { get; }

  /// <summary>
  /// Indicates if the list is configurable by using the user data folder.
  /// </summary>
  public bool Configurable { get; }

  /// <summary>
  /// Indicates the folder.
  /// </summary>
  public DataFileFolder Folder { get; }

  /// <summary>
  /// Constructor.
  /// </summary>
  protected DataFile(string filePath, bool showFileNotFound, bool configurable, DataFileFolder folder)
  {
    FilePathDefault = filePath ?? throw new ArgumentNullException(nameof(filePath));
    ShowFileNotFound = showFileNotFound;
    Configurable = configurable;
    Folder = folder;
    FilePath = folder switch
    {
      DataFileFolder.ApplicationDocuments => FilePathDefault,
      DataFileFolder.ProgramData => filePath.Replace(Globals.DocumentsFolderPath, Globals.ProgramDataFolderPath),
      DataFileFolder.UserHebrewCommon => filePath.Replace(Globals.DocumentsFolderPath, Globals.UserDataCommonFolderPath),
      DataFileFolder.UserApplication => filePath.Replace(Globals.DocumentsFolderPath, Globals.UserDataFolderPath),
      _ => throw new AdvancedNotImplementedException(folder),
    };
    ReLoad();
  }

  /// <summary>
  /// Loads or reload data from disk.
  /// </summary>
  protected abstract void DoReLoad(string filePath);

  /// <summary>
  /// Loads or reload data from disk.
  /// </summary>
  public void ReLoad(bool reset = false)
  {
    DoReLoad(CheckFile(reset));
  }

  /// <summary>
  /// Checks if file exists in user data folder.
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
          string msg = SysTranslations.CopyFileError.GetLang(filePath1, filePath2, ex.Message);
          DisplayManager.ShowError(msg);
          return string.Empty;
        }
      }
    return FilePath;
  }

}
