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
/// <edited> 2021-07 </edited>
using System;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Localization strings.
  /// </summary>
  static partial class SysTranslations
  {

    static public readonly TranslationsDictionary UpgradeCommonDatabaseRequired
      = new TranslationsDictionary
      {
        [Language.EN] = "One or more common tables must be updated:" + Globals.NL2 +
                        "     {0}" + Globals.NL2 +
                        "Once the operation is done you will have to check the web update for other Torah applications, either automatically by launching them without worrying about the error message concerning them and click on continue, or by downloading them manually from the Internet for more ease or in case of problem. If no new version is available, all is well.",

        [Language.FR] = "Une ou plusieurs tables communes doivent être mise à jour :" + Globals.NL2 +
                        "     {0} " + Globals.NL2 +
                        "Une fois l'opération effectuée vous devrez vérifier la mise à jour web pour les autres applications de Torah, soit automatiquement en les lançant sans vous inquiéter du message d'erreur les concernant et cliquer sur continuer, soit en les téléchargeant manuellement depuis Internet pour plus de simplicité ou en cas de problème. Si aucune nouvelle version n'est disponible, tout va bien."
      };

    static public readonly TranslationsDictionary CloseApplicationsRequired
      = new TranslationsDictionary
      {
        [Language.EN] = "{0}" + Globals.NL2 +
                        "This or these applications must be closed:" + Globals.NL2 +
                        "{1}" + Globals.NL2 +
                        "Do you want to try to close them automatically?",

        [Language.FR] = "{0}" + Globals.NL2 +
                        "Cette ou ces applications doivent être fermées :" + Globals.NL2 +
                        "{1}" + Globals.NL2 +
                        "Voulez-vous tenter de les fermer automatiquement ?"
      };

    static public readonly TranslationsDictionary NoticeNewFeaturesTitle
      = new TranslationsDictionary
      {
        [Language.EN] = "New features in version {0}",
        [Language.FR] = "Nouvelles fonctionnalités de la version {0}"
      };

    static public TranslationsDictionary ApplicationMustExit
    {
      get
      {
        if ( _ApplicationMustExit == null )
          _ApplicationMustExit = new TranslationsDictionary
          {
            [Language.EN] = "The application must exit.",
            [Language.FR] = "L'application doit se fermer."
          };
        return _ApplicationMustExit;
      }
    }
    static private TranslationsDictionary _ApplicationMustExit;

    static public readonly TranslationsDictionary ApplicationMustExitContactSupport
      = new TranslationsDictionary
      {
        [Language.EN] = ApplicationMustExit[Language.EN] + Globals.NL2 + ContactSupport[Language.EN],
        [Language.FR] = ApplicationMustExit[Language.FR] + Globals.NL2 + ContactSupport[Language.FR]
      };

    static public readonly TranslationsDictionary RestartRequired
      = new TranslationsDictionary
      {
        [Language.EN] = "Application must be restarted",
        [Language.FR] = "L'application doit être redémarrée"
      };

    static public readonly TranslationsDictionary AboutBoxTitle
      = new TranslationsDictionary
      {
        [Language.EN] = "About {0}",
        [Language.FR] = "À propos de {0}"
      };

    static public readonly TranslationsDictionary AboutBoxVersion
      = new TranslationsDictionary
      {
        [Language.EN] = "Version {0}",
        [Language.FR] = "Version {0}"
      };

    static public readonly TranslationsDictionary CheckUpdate
      = new TranslationsDictionary
      {
        [Language.EN] = "{0} Check Update",
        [Language.FR] = "Mise à jour de {0}"
      };

    static public readonly TranslationsDictionary CheckInternetConnection
      = new TranslationsDictionary
      {
        [Language.EN] = "Please check the Internet connection.",
        [Language.FR] = "Veuillez vérifier la connexion internet."
      };

    static public readonly TranslationsDictionary NoticePrivacyNoData
      = new TranslationsDictionary
      {
        [Language.EN] = "This software doesn't collect any personal information about you, your computer and your network, unless it is specified by its features." + Globals.NL2 +
                        "However, it can collect for debugging purposes the type of processor and operating system as well as errors caused by the code, but these information are only stored locally and only transmitted upon conscious validations by the user." + Globals.NL2 +
                        "Links to external resources and websites are listed for informational purposes and they do not engage any responsibility.",
        [Language.FR] = "Ce logiciel ne collecte aucune information personnelle concernant vous-même, votre ordinateur et votre réseau, à moins que cela ne soit indiqué par ses fonctionnalités." + Globals.NL2 +
                        "Il peut cependant collecter à des fins de débogage le type de processeur et de système d'exploitation ainsi que les erreurs provoquées par le code, mais ces informations ne sont stockées localement et ne sont transmises que sur validations consciente de l'utilisateur." + Globals.NL2 +
                        "Les liens vers des ressources et sites internet externes sont indiqués à titre informatif et ils n'engagent pas de responsabilité.",
      };

    static public readonly TranslationsDictionary AskToExitApplication
      = new TranslationsDictionary
      {
        [Language.EN] = "Exit application?",
        [Language.FR] = "Quitter l'application ?"
      };

    static public readonly TranslationsDictionary CantExitWhileGenerating
      = new TranslationsDictionary
      {
        [Language.EN] = "Can't exit application while generating data.",
        [Language.FR] = "Impossible de quitter l'application durant la génération des données."
      };

    static public readonly TranslationsDictionary AskToShutdownComputer
      = new TranslationsDictionary
      {
        [Language.EN] = "All application will be closed and unsaved works lost." + Globals.NL2 +
                        "Shutdown the computer?",
        [Language.FR] = "Toutes les applications seront fermées et les travaux non sauvés perdus." + Globals.NL2 +
                        "Arrêter l'ordinateur ?"
      };

    static public readonly TranslationsDictionary AskToContinueOrTerminate
      = new TranslationsDictionary
      {
        [Language.EN] = "You can choose Yes to continue or No to terminate.",
        [Language.FR] = "Vous pouvez choisir Oui pour continuer ou Non pour terminer."
      };

    static public readonly NullSafeDictionary<bool, TranslationsDictionary> HideRestoreCaption
      = new NullSafeDictionary<bool, TranslationsDictionary>
      {
        [true] = new TranslationsDictionary
        {
          [Language.EN] = "Hide",
          [Language.FR] = "Cacher"
        },
        [false] = new TranslationsDictionary
        {
          [Language.EN] = "Restore",
          [Language.FR] = "Restaurer"
        }
      };

    static public readonly NullSafeDictionary<ExportAction, TranslationsDictionary> ViewActionTitle
      = new NullSafeDictionary<ExportAction, TranslationsDictionary>
      {
        [ExportAction.SaveToFile] = new TranslationsDictionary
        {
          [Language.EN] = "Save to file",
          [Language.FR] = "Sauver dans un fichier"
        },
        [ExportAction.CopyToClipboard] = new TranslationsDictionary
        {
          [Language.EN] = "Copy to clipboard",
          [Language.FR] = "Copier dans le presse-papier"
        },
        [ExportAction.Print] = new TranslationsDictionary
        {
          [Language.EN] = "Print",
          [Language.FR] = "Imprimer"
        }
      };

    static public readonly TranslationsDictionary ScreenshotDone
      = new TranslationsDictionary
      {
        [Language.EN] = "The window has been copied to the clipboard.",
        [Language.FR] = "La fenêtre a été copié dans le presse-papier."
      };

    static public readonly TranslationsDictionary DataCopiedToClipboard
      = new TranslationsDictionary
      {
        [Language.EN] = "Data have been copied to the clipboard.",
        [Language.FR] = "Les données ont été copiées dans le presse-papier."
      };

    static public readonly TranslationsDictionary ViewSavedToFile
      = new TranslationsDictionary
      {
        [Language.EN] = $"The view has been saved to :{Globals.NL2}{{0}}",
        [Language.FR] = $"La vue a été sauvée dans :{Globals.NL2}{{0}}",
      };

    static public readonly TranslationsDictionary ViewCopiedToClipboard
      = new TranslationsDictionary
      {
        [Language.EN] = "The view has been copied to the clipboard.",
        [Language.FR] = "La vue a été copiée dans le presse-papier."
      };

    static public readonly TranslationsDictionary SelectionCopiedToClipboard
      = new TranslationsDictionary
      {
        [Language.EN] = "The selection has been copied to the clipboard.",
        [Language.FR] = "La sélection a été copiée dans le presse-papier."
      };

    static public readonly TranslationsDictionary ViewPrinted
      = new TranslationsDictionary
      {
        [Language.EN] = "The view has been printed.",
        [Language.FR] = "La vue a été imprimée."
      };

    static public readonly NullSafeDictionary<ControlLocation, TranslationsDictionary> ControlLocationText
      = new NullSafeDictionary<ControlLocation, TranslationsDictionary>
      {
        [ControlLocation.BottomLeft] = new TranslationsDictionary
        {
          [Language.EN] = "Bottom left",
          [Language.FR] = "Bas gauche"
        },
        [ControlLocation.BottomRight] = new TranslationsDictionary
        {
          [Language.EN] = "Bottom right",
          [Language.FR] = "Bas droit"
        },
        [ControlLocation.Center] = new TranslationsDictionary
        {
          [Language.EN] = "Center",
          [Language.FR] = "Centre"
        },
        [ControlLocation.Fixed] = new TranslationsDictionary
        {
          [Language.EN] = "Fixed",
          [Language.FR] = "Fixé"
        },
        [ControlLocation.Loose] = new TranslationsDictionary
        {
          [Language.EN] = "Loose",
          [Language.FR] = "Libre"
        },
        [ControlLocation.TopLeft] = new TranslationsDictionary
        {
          [Language.EN] = "Top left",
          [Language.FR] = "Haut gauche"
        },
        [ControlLocation.TopRight] = new TranslationsDictionary
        {
          [Language.EN] = "Top right",
          [Language.FR] = "Haut droit"
        }
      };

    static public readonly NullSafeDictionary<PowerActions, TranslationsDictionary> PowerActionText
      = new NullSafeDictionary<PowerActions, TranslationsDictionary>
      {
        [PowerActions.Hibernate] = new TranslationsDictionary
        {
          [Language.EN] = "Hibernate",
          [Language.FR] = "Hiberner"
        },
        [PowerActions.LockSession] = new TranslationsDictionary
        {
          [Language.EN] = "Lock",
          [Language.FR] = "Verrouiller"
        },
        [PowerActions.Shutdown] = new TranslationsDictionary
        {
          [Language.EN] = "Shutdown",
          [Language.FR] = "Éteindre"
        },
        [PowerActions.StandBy] = new TranslationsDictionary
        {
          [Language.EN] = "Standby",
          [Language.FR] = "Veille"
        }
      };

  }

}
