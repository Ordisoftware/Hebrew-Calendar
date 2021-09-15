/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2021 Olivier Rogier.
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
/// <edited> 2021-09 </edited>
using System;
using System.IO;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  abstract public class ProviderSettings
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
      if ( !File.Exists(FilePath) )
      {
        DisplayManager.ShowError(SysTranslations.FileNotFound.GetLang(FilePath));
        return;
      }
      DoClear();
      string line;
      using ( var stream = File.OpenText(FilePath) )
        while ( ( line = stream.ReadLine() ) != null )
          DoLoad(line);
    }

    public void Save()
    {
      using ( var stream = File.CreateText(FilePath) )
        DoSave(stream);
    }

  }

}
