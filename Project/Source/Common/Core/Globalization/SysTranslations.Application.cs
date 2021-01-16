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
/// <edited> 2020-12 </edited>
using System;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide localization helper.
  /// </summary>
  static public partial class SysTranslations
  {

    static public TranslationsDictionary ApplicationMustExit
    {
      get
      {
        if ( _ApplicationMustExit == null )
          _ApplicationMustExit = new TranslationsDictionary()
          {
            [Language.EN] = "The application must exit.",
            [Language.FR] = "L'application doit se fermer."
          };
        return _ApplicationMustExit;
      }
    }
    static private TranslationsDictionary _ApplicationMustExit;

    static public readonly TranslationsDictionary RestartRequired
      = new TranslationsDictionary()
      {
        [Language.EN] = "Application must be restarted",
        [Language.FR] = "L'application doit être redémarrée"
      };

    static public readonly TranslationsDictionary AboutBoxTitle
      = new TranslationsDictionary()
      {
        [Language.EN] = "About {0}",
        [Language.FR] = "À propos de {0}"
      };

    static public readonly TranslationsDictionary AboutBoxVersion
      = new TranslationsDictionary()
      {
        [Language.EN] = "Version {0}",
        [Language.FR] = "Version {0}"
      };

    static public readonly TranslationsDictionary PrivacyNoticeNoData
      = new TranslationsDictionary()
      {
        [Language.EN] = "This software doesn't collect any personal information about you, your computer and your network, unless it is specified by its features." + Globals.NL2 +
                        "However, it can collect for debugging purposes the type of processor and operating system as well as errors caused by the code, but these information are only stored locally and only transmitted upon conscious validations by the user." + Globals.NL2 +
                        "Links to external resources and websites are listed for informational purposes and they do not engage any responsibility.",
        [Language.FR] = "Ce logiciel ne collecte aucune information personnelle concernant vous-même, votre ordinateur et votre réseau, à moins que cela ne soit indiqué par ses fonctionnalités." + Globals.NL2 +
                        "Il peut cependant collecter à des fins de débogage le type de processeur et de système d'exploitation ainsi que les erreurs provoquées par le code, mais ces informations ne sont stockées localement et ne sont transmises que sur validations consciente de l'utilisateur." + Globals.NL2 +
                        "Les liens vers des ressources et sites internet externes sont indiqués à titre informatif et ils n'engagent pas de responsabilité.",
      };

    static public readonly TranslationsDictionary AskToExitApplication
      = new TranslationsDictionary()
      {
        [Language.EN] = "Exit application?",
        [Language.FR] = "Quitter l'application ?"
      };

    static public readonly TranslationsDictionary CantExitWhileGenerating
      = new TranslationsDictionary()
      {
        [Language.EN] = "Can't exit application while generating data.",
        [Language.FR] = "Impossible de quitter l'application durant la génération des données."
      };

    static public readonly TranslationsDictionary AskToShutdownComputer
      = new TranslationsDictionary()
      {
        [Language.EN] = "Shutdown the computer?",
        [Language.FR] = "Arrêter l'ordinateur ?"
      };

    static public readonly TranslationsDictionary AskToContinueOrTerminate
      = new TranslationsDictionary()
      {
        [Language.EN] = "You can choose Yes to continue or No to terminate.",
        [Language.FR] = "Vous pouvez choisir Oui pour continuer ou Non pour terminer."
      };

    static public readonly NullSafeDictionary<bool, TranslationsDictionary> HideRestoreCaption
      = new NullSafeDictionary<bool, TranslationsDictionary>
      {
        [true] = new TranslationsDictionary()
        {
          [Language.EN] = "Hide",
          [Language.FR] = "Cacher"
        },
        [false] = new TranslationsDictionary()
        {
          [Language.EN] = "Restore",
          [Language.FR] = "Restaurer"
        }
      };

    static public readonly NullSafeDictionary<ExportAction, TranslationsDictionary> ViewActionTitle
      = new NullSafeDictionary<ExportAction, TranslationsDictionary>
      {
        [ExportAction.SaveToFile] = new TranslationsDictionary()
        {
          [Language.EN] = "Save to file",
          [Language.FR] = "Sauver dans un fichier"
        },
        [ExportAction.CopyToClipboard] = new TranslationsDictionary()
        {
          [Language.EN] = "Copy to clipboard",
          [Language.FR] = "Copier dans le presse-papier"
        },
        [ExportAction.Print] = new TranslationsDictionary()
        {
          [Language.EN] = "Print",
          [Language.FR] = "Imprimer"
        }
      };

    static public readonly TranslationsDictionary ScreenshotDone
      = new TranslationsDictionary()
      {
        [Language.EN] = "The window has been copied to the clipboard.",
        [Language.FR] = "La fenêtre a été copié dans le presse-papier."
      };

    static public readonly TranslationsDictionary ViewSavedToFile
      = new TranslationsDictionary()
      {
        [Language.EN] = $"The view has been saved to :{Globals.NL2}{{0}}",
        [Language.FR] = $"La vue a été sauvée dans :{Globals.NL2}{{0}}",
      };

    static public readonly TranslationsDictionary ViewCopiedToClipboard
      = new TranslationsDictionary()
      {
        [Language.EN] = "The view has been copied to the clipboard.",
        [Language.FR] = "La vue a été copiée dans le presse-papier."
      };

    static public readonly TranslationsDictionary SelectionCopiedToClipboard
      = new TranslationsDictionary()
      {
        [Language.EN] = "The selection has been copied to the clipboard.",
        [Language.FR] = "La sélection a été copiée dans le presse-papier."
      };

    static public readonly TranslationsDictionary ViewPrinted
      = new TranslationsDictionary()
      {
        [Language.EN] = "The view has been printed.",
        [Language.FR] = "La vue a été imprimée."
      };

  }

}
