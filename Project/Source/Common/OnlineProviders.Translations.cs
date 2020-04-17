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
/// <created> 2020-03 </created>
/// <edited> 2020-04 </edited>
using System;
using System.Collections.Generic;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Online providers list.
  /// </summary>
  public partial class OnlineProviders
  {

    static private readonly Dictionary<string, string> FileNotFound
      = new Dictionary<string, string>()
      {
        { "en", "File not found: {0}" },
        { "fr", "Fichier non trouvé : {0}" }
      };

    static private readonly Dictionary<string, string> ErrorMsg
      = new Dictionary<string, string>()
      {
        { "en", "Error in {0}" + Environment.NewLine + Environment.NewLine +
                "Line n° {1]" + Environment.NewLine + Environment.NewLine +
                "{2}" },
        { "fr", "Erreur dans {0}" + Environment.NewLine + Environment.NewLine +
                "Ligne n° {1]" + Environment.NewLine + Environment.NewLine +
                "{2}" }
      };

    static private readonly Dictionary<string, string> AskToOpenAllLinks
      = new Dictionary<string, string>()
      {
        { "en", "Do you want to open all \"{0]\" links?" },
        { "fr", "Voulez-vous ouvrir tous les liens de \"{0}\" ?" }
      };

  }

}