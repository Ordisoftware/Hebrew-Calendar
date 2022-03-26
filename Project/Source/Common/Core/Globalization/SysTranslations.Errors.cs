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
/// <created> 2016-04 </created>
/// <edited> 2021-11 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Localization strings.
/// </summary>
static partial class SysTranslations
{

  static public TranslationsDictionary ContactSupport
  {
    get
    {
      return _ContactSupport ??= new TranslationsDictionary
      {
        [Language.EN] = "Please contact support.",
        [Language.FR] = "Veuillez contacter le support."
      };
    }
  }
  static private TranslationsDictionary _ContactSupport;

  static public readonly TranslationsDictionary AskToClearLogs = new()
  {
    [Language.EN] = "Do you want to delete all log files?",
    [Language.FR] = "Voulez-vous effacer tous les fichiers de log ?"
  };

  static public readonly TranslationsDictionary TraceLinesCount = new()
  {
    [Language.EN] = "{0} lines",
    [Language.FR] = "{0} lignes"
  };

  static public readonly TranslationsDictionary TraceFilesCount = new()
  {
    [Language.EN] = "{0} files",
    [Language.FR] = "{0} fichiers"
  };

  static public readonly TranslationsDictionary GitHubIssueComment = new()
  {
    [Language.EN] = "> Describe here what you did, what you expected and what happened.",
    [Language.FR] = "> Décrivez ici ce que vous avez fait, ce que vous attendiez et ce qui c'est passé."
  };

  static public readonly TranslationsDictionary UnhandledException = new()
  {
    [Language.EN] = "Unhandled Exception has occurred in {0}" + Globals.NL +
                    "<{1}>" + Globals.NL2 +
                    "{2}",

    [Language.FR] = "Exception non gérée dans {0}" + Globals.NL +
                    "<{1}>" + Globals.NL2 +
                    "{2}"
  };

  static public readonly TranslationsDictionary NextException = new()
  {
    [Language.EN] = "Next",
    [Language.FR] = "Suivante"
  };

  static public readonly TranslationsDictionary HotKeyUnregisterError = new()
  {
    [Language.EN] = "Error on unregistering the HotKey.",
    [Language.FR] = "Erreur à la libération du HotKey."
  };

  static public readonly TranslationsDictionary HotKeyRefusedBySystem = new()
  {
    [Language.EN] = "The HotKey combination is refused by the system.",
    [Language.FR] = "La combinaison du HotKey est refusé par le système."
  };

  static public readonly TranslationsDictionary HotKeyCapturedByAnotherApplication = new()
  {
    [Language.EN] = "The HotKey combination is captured by another application",
    [Language.FR] = "La combinaison du HotKey est capturée par une autre application"
  };

  static public readonly TranslationsDictionary LockSessionError = new()
  {
    [Language.EN] = $"Lock session error:{Globals.NL2}{{0}}",
    [Language.FR] = $"Erreur de verrouillage de la session :{Globals.NL2}{{0}}"
  };

  static public readonly TranslationsDictionary CallMethodError = new()
  {
    [Language.EN] = "Error in {0}.",
    [Language.FR] = "Erreur dans {0}.",
  };

  static public readonly TranslationsDictionary IndexOutOfRange = new()
  {
    [Language.EN] = "Index out of range in {0}: {1}" + Globals.NL2 +
                    "Must be between {2}} and {3}}.",

    [Language.FR] = "Index en dehors des limites dans {0}: {1}" + Globals.NL2 +
                    "Doit être entre {2} et {3}."
  };

  static public readonly TranslationsDictionary IndexCantBeNegative = new()
  {
    [Language.EN] = "Index can\'t be negative in {0}: {1}",
    [Language.FR] = "Index ne peut pas être négatif dans {0}: {1}"
  };

}
