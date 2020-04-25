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
/// <created> 2020-04 </created>
/// <edited> 2020-04 </edited>
using System;
using System.IO;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCommon
{

  public abstract class DataFile
  {

    /// <summary>
    /// Indicate source filename in application documents folder.
    /// </summary>
    public string FilenameDefault { get; private set; }

    /// <summary>
    /// Indicate source filename in user data folder.
    /// </summary>
    public string FilenameUser { get; private set; }

    /// <summary>
    /// Indicate if file not found error must be shown on load.
    /// </summary>
    public bool ShowFileNotFound { get; private set; }

    /// <summary>
    /// Indicate if the list is configurable by using the user data folder.
    /// </summary>
    public bool Configurable { get; private set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    public DataFile(string filename, bool configurable, bool showFileNotFound)
    {
      ShowFileNotFound = showFileNotFound;
      Configurable = configurable;
      FilenameDefault = filename;
      FilenameUser = filename.Replace(Globals.DocumentsFolderPath, Globals.UserDataFolderPath);
      ReLoad();
    }

    public void ReLoad(bool reset = false)
    {
      DoReLoad(CheckFile(reset));
    }

    /// <summary>
    /// Load or reload data from disk.
    /// </summary>
    /// <param name="reset">True if must be reseted from application documents folder.</param>
    protected abstract void DoReLoad(string filename);

    /// <summary>
    /// Check if file exists in user data folder.
    /// </summary>
    /// <param name="reset">True if must be reseted from application documents folder.</param>
    protected string CheckFile(bool reset)
    {
      if ( !Configurable ) return FilenameDefault;
      if ( reset || !File.Exists(FilenameUser) )
        if ( !File.Exists(FilenameDefault) )
        {
          if ( ShowFileNotFound )
            DisplayManager.ShowError(Globals.FileNotFound.GetLang(FilenameDefault));
          return "";
        }
        else
        {
          string folder = Path.GetDirectoryName(FilenameUser);
          if ( !Directory.Exists(folder) )
            Directory.CreateDirectory(folder);
          try
          {
            File.Copy(FilenameDefault, FilenameUser, true);
          }
          catch ( Exception ex )
          {
            ex.Manage();
            return "";
          }
        }
      return FilenameUser;
    }

  }

}