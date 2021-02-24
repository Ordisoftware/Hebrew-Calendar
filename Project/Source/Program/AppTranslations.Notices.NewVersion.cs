/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2021 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2021-02 </created>
/// <edited> 2021-02 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// Localization strings.
  /// </summary>
  static public partial class AppTranslations
  {

    static public readonly NullSafeDictionary<string, TranslationsDictionary> NoticeNewFeatures
      = new NullSafeDictionary<string, TranslationsDictionary>
      {

        ["7.0"] = new TranslationsDictionary
        {
          [Language.EN] = "The application has been updated to show the Parashah of the week in the Shabat cases of the visual calendar and in the navigation window. " + Globals.NL2 +
                          "An editable Parashot board is available in the Tools menu." + Globals.NL2 +
                          "The visual calendar and navigation window show the intermediate days of week-long celebrations." + Globals.NL2 +
                          "The image of the Tray Icon changes during a Shabat day or celebration regardless of the reminders set." + Globals.NL2 +
                          "The web update check is not performed on a day off while the application is running." + Globals.NL2 +
                          "Boards are exportable as TXT files in addition to CSV and JSON." + Globals.NL2 +
                          "Added news in version in the Information menu." + Globals.NL2 +
                          "Modification and addition of web links and online providers for the study of words and verses of the Bible." + Globals.NL2 +
                          "Some improvements in appearance and function." + Globals.NL2 +
                          "The calendar is going to be regenerated.",

          [Language.FR] = "L'application a été mise à jour pour indiquer la Parashah de la semaine dans les cases Shabat du calendrier visuel et dans la fenêtre de navigation." + Globals.NL2 +
                          "Un tableau des Parashot modifiable est disponible dans le menu Outils." + Globals.NL2 +
                          "Le calendrier visuel et la fenêtre de navigation affichent les jours intermediaires des célébrations qui durent une semaine." + Globals.NL2 +
                          "L'image de la Tray Icon change durant un jour de Shabat ou de célébration quelque soient les rappels définits." + Globals.NL2 +
                          "La vérification de mise à jour en ligne n'est pas effectuée durant un jour de repos pendant l'exécution de l'application." + Globals.NL2 +
                          "Les tableaux sont exportables en fichiers TXT en plus de CSV et JSON." + Globals.NL2 +
                          "Ajout des nouveautés de version dans le menu Information." + Globals.NL2 +
                          "Modification et ajouts de liens web et de fournisseurs en ligne pour l'étude des mots et des versets de la Bible." + Globals.NL2 +
                          "Quelques améliorations d'aspect et de fonctionnement." + Globals.NL2 +
                          "Le calendrier va être régénéré."
        }

      };

  }

}
