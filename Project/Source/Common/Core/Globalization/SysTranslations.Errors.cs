/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2020 Olivier Rogier.
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
/// <edited> 2020-09 </edited>
using System;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide localization helper.
  /// </summary>
  static public partial class SysTranslations
  {

    static public TranslationsDictionary ContactSupport
    {
      get
      {
        if ( _ContactSupport == null )
          _ContactSupport = new TranslationsDictionary
          {
            [Language.EN] = "Please contact support.",
            [Language.FR] = "Veuillez contacter le support."
          };
        return _ContactSupport;
      }
    }
    static private TranslationsDictionary _ContactSupport;

    static public readonly TranslationsDictionary AskToClearLogs
      = new TranslationsDictionary
      {
        [Language.EN] = "Do you want to delete all log files?",
        [Language.FR] = "Voulez-vous effacer tous les fichiers de log ?"
      };

    static public readonly TranslationsDictionary TraceLinesCount
      = new TranslationsDictionary
      {
        [Language.EN] = "{0} lines",
        [Language.FR] = "{0} lignes"
      };

    static public readonly TranslationsDictionary GitHubIssueComment
      = new TranslationsDictionary
      {
        [Language.EN] = "> Describe here what you did, what you expected and what happened.",
        [Language.FR] = "> Décrivez ici ce que vous avez fait, ce que vous attendiez et ce qui c'est passé."
      };

    static public readonly TranslationsDictionary UnhandledException
      = new TranslationsDictionary
      {
        [Language.EN] = "Unhandled Exception has occured in {0}" + Globals.NL +
                        "<{1}>" + Globals.NL2 +
                        "{2}",

        [Language.FR] = "Exception non gérée dans {0}" + Globals.NL +
                        "<{1}>" + Globals.NL2 +
                        "{2}"
      };

    static public readonly TranslationsDictionary NextException
      = new TranslationsDictionary
      {
        [Language.EN] = "Next",
        [Language.FR] = "Suivante"
      };

    static public readonly TranslationsDictionary LockSessionError
      = new TranslationsDictionary
      {
        [Language.EN] = $"Lock session error:{Globals.NL2}{{0}}",
        [Language.FR] = $"Erreur de vérouillage de la session :{Globals.NL2}{{0}}"
      };

    static public readonly TranslationsDictionary CallMethodError
      = new TranslationsDictionary
      {
        [Language.EN] = "Error in {0}.",
        [Language.FR] = "Erreur dans {0}.",
      };

    static public readonly TranslationsDictionary IndexOutOfRange
      = new TranslationsDictionary
      {
        [Language.EN] = "Index out of range in {0}: {1}" + Globals.NL2 +
                        "Must be between {2}} and {3}}.",

        [Language.FR] = "Index en dehors des limites dans {0}: {1}" + Globals.NL2 +
                        "Doit être entre {2} et {3}."
      };

    static public readonly TranslationsDictionary IndexCantBeNegative
      = new TranslationsDictionary
      {
        [Language.EN] = "Index can''t be negative in {0}: {1}",
        [Language.FR] = "Index ne peut pas être négatif dans {0}: {1}"
      };

  }

}
