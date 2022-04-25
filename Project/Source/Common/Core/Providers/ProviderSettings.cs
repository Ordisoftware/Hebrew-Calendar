/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2022 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2021-09 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Core;

abstract class ProviderSettings
{

  protected string FilePath;

  protected ProviderSettings()
  {
    SetFilePath();
    Load();
  }

  abstract protected void SetFilePath();
  abstract protected void DoClear();
  abstract protected void DoLoad(string line);
  abstract protected void DoSave(StreamWriter stream);

  public void Load()
  {
    string line = string.Empty;
    try
    {
      if ( !File.Exists(FilePath) )
      {
        DisplayManager.ShowError(SysTranslations.FileNotFound.GetLang(FilePath));
        return;
      }
      DoClear();
      using var stream = File.OpenText(FilePath);
      while ( ( line = stream.ReadLine() ) is not null )
        if ( line.Trim().Length != 0 && !line.IsCommentedText() )
          DoLoad(line);
    }
    catch ( Exception ex )
    {
      DisplayManager.ShowError(SysTranslations.LoadFileError.GetLang(FilePath + Globals.NL2 + line, ex.Message));
    }
  }

  public void Save()
  {
    SystemManager.TryCatchManage(ShowExceptionMode.Simple, () =>
    {
      using var stream = File.CreateText(FilePath);
      DoSave(stream);
    });
  }

}
