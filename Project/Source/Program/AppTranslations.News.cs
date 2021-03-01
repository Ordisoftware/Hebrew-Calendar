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
  static partial class AppTranslations
  {

    static public readonly NullSafeDictionary<string, TranslationsDictionary> NoticeNewFeatures
      = new NullSafeDictionary<string, TranslationsDictionary>
      {

        ["1.x"] = new TranslationsDictionary
        {
          [Language.EN] = "Initial release." + Globals.NL +
                          "Text report and visual month view." + Globals.NL +
                          "Next celebrations and day navigation windows." + Globals.NL +
                          "Shabat reminder." + Globals.NL +
                          "Basic preferences and GPS coordonates.",

          [Language.FR] = "Version initiale" + Globals.NL +
                          "Rapport texte et vue mensuelle." + Globals.NL +
                          "Fenêtre des prochaines célébrations et de navigation par jour." + Globals.NL +
                          "Rappel de Shabat." + Globals.NL +
                          "Préférences de base et coordonnées GPS.",
        },

        ["2.x"] = new TranslationsDictionary
        {
          [Language.EN] = "Improve reminder system." + Globals.NL +
                          "Some improvements and fixes.",

          [Language.FR] = "Amélioration du système de rappel." + Globals.NL +
                          "Quelques améliorations et corrections.",
        },

        ["3.x"] = new TranslationsDictionary
        {
          [Language.EN] = "Improved speed." + Globals.NL +
                          "Improved Tray Icon." + Globals.NL +
                          "Improved reminder box." + Globals.NL +
                          "Celebration reminder in addition to Shabat." + Globals.NL +
                          "New window to search a celebration." + Globals.NL +
                          "New window to search a lunar month." + Globals.NL +
                          "Added colors for special days." + Globals.NL +
                          "Added auto-lock session during special days." + Globals.NL +
                          "Added world cities database to select GPS." + Globals.NL +
                          "Option to select sun or moon omer." + Globals.NL +
                          "Regenerate data if today is near the end." + Globals.NL +
                          "General improvement and some fixes.",

          [Language.FR] = "Amélioration de la vitesse." + Globals.NL +
                          "Amélioration de l'icône de la barre d'état." + Globals.NL +
                          "Amélioration de la boîte de rappel." + Globals.NL +
                          "Rappel de célébration en plus du Shabat." + Globals.NL +
                          "Nouvelle fenêtre pour rechercher une célébration." + Globals.NL +
                          "Nouvelle fenêtre pour rechercher un mois lunaire." + Globals.NL +
                          "Ajout de couleurs pour des jours spéciaux." + Globals.NL +
                          "Ajout du verrouillage automatique de session pendant les jours spéciaux." + Globals.NL +
                          "Ajout la base de données des villes du monde pour sélectionner le GPS." + Globals.NL +
                          "Option pour sélectionner le soleil ou la lune omer." + Globals.NL +
                          "Régénération des données si aujourd'hui est proche de la fin." + Globals.NL +
                          "Amélioration générale et quelques corrections.",
        },

        ["4.x"] = new TranslationsDictionary
        {
          [Language.EN] = "Improved startup configuration." + Globals.NL +
                          "Improved visual calendar." + Globals.NL +
                          "Improved preferences." + Globals.NL +
                          "Added celebrations and Shabat notices" + Globals.NL +
                          "Added dates difference calculator." + Globals.NL +
                          "Added suspend reminder." + Globals.NL +
                          "Added tools menu." + Globals.NL +
                          "Added web links menu." + Globals.NL +
                          "Added debugger and logger." + Globals.NL +
                          "General improvement and some fixes.",

          [Language.FR] = "Configuration de démarrage améliorée." + Globals.NL +
                          "Calendrier visuel amélioré." + Globals.NL +
                          "Préférences améliorées." + Globals.NL +
                          "Ajout des notices de célébrations et de Shabat" + Globals.NL +
                          "Ajout d'un calculateur de différence de dates." + Globals.NL +
                          "Ajout d'un suspendeur des rappels." + Globals.NL +
                          "Ajout d'un menu outils." + Globals.NL +
                          "Ajout d'un menu liens Web." + Globals.NL +
                          "Ajout d'un débogueur et d'un logger" + Globals.NL +
                          "Améliorations générales et quelques corrections."
        },

        ["5.x"] = new TranslationsDictionary
        {
          [Language.EN] = "Remove the generate dialog box at first startup and auto-regenerate." + Globals.NL +
                          "Improved check update to securely download and auto-install." + Globals.NL +
                          "Improved keyboard shortcuts." + Globals.NL +
                          "Improved data generation speed by a half." + Globals.NL +
                          "Improved visual month view speed by a half." + Globals.NL +
                          "Improved tray icon menu." + Globals.NL +
                          "Improved preferences options." + Globals.NL +
                          "Improved dialogs." + Globals.NL +
                          "Added sounds." + Globals.NL +
                          "Added search gregorian month window." + Globals.NL +
                          "New advanced export and printing dialog box." + Globals.NL +
                          "Rework of the preferences window design with more options." + Globals.NL +
                          "New usage statistics window." + Globals.NL +
                          "General improvement and some fixes.",

          [Language.FR] = "Suppression de la boîte de dialogue de génération au premier démarrage et lors de la régénération automatiquement." + Globals.NL +
                          "Amélioration de la vérification de mise à jour pour télécharger et installer automatiquement de manière sécurisée." + Globals.NL +
                          "Amélioration des raccourcis clavier." + Globals.NL +
                          "Amélioration de moitié de la vitesse de génération des données." + Globals.NL +
                          "Amélioration de moitié de la vitesse d'affichage du mois visuel." + Globals.NL +
                          "Amélioration du menu de l'icônes de la barre d'état." + Globals.NL +
                          "Amélioration des options de préférences." + Globals.NL +
                          "Amélioration des boites de dialogues." + Globals.NL +
                          "Ajout de sons." + Globals.NL +
                          "Ajout d'une fenêtre de recherche de mois grégorien." + Globals.NL +
                          "Nouvelle boîte de dialogue avancée d'exportation et d'impression." + Globals.NL +
                          "Refonte de la fenêtre des préférences avec ajout d'options." + Globals.NL +
                          "Nouvelle fenêtre de statistiques d'utilisation." + Globals.NL +
                          "Amélioration générale et quelques corrections.",
        },

        ["6.x"] = new TranslationsDictionary
        {
          [Language.EN] = "Optimized visual month painting speed." + Globals.NL +
                          "Added Windows global hotkey." + Globals.NL +
                          "Added celebrations board." + Globals.NL +
                          "Added new moons board." + Globals.NL +
                          "Added print preview for calendar export." + Globals.NL +
                          "Added links to local and online weather." + Globals.NL +
                          "Added backup and restore date bookmarks." + Globals.NL +
                          "Added export and import settings." + Globals.NL +
                          "Improved preferences." + Globals.NL +
                          "Update web links." + Globals.NL +
                          "Some improvements and fixes.",

          [Language.FR] = "Vitesse de peinture du mois visuel optimisée." + Globals.NL +
                          "Ajout d'un raccourci de clavier global Windows." + Globals.NL +
                          "Ajout d'un tableau des célébrations." + Globals.NL +
                          "Ajout d'un tableau des nouvelles lunes." + Globals.NL +
                          "Ajout d'un aperçu avant impression pour l'exportation du calendrier." + Globals.NL +
                          "Ajout de liens vers la météo locale et en ligne." + Globals.NL +
                          "Ajout de la sauvegarde et restauration des signets de date." + Globals.NL +
                          "Ajout de l'exportation et importation des paramètres." + Globals.NL +
                          "Préférences améliorées." + Globals.NL +
                          "Mettre à jour les liens Web." + Globals.NL +
                          "Quelques améliorations et corrections.",
        },

        ["7.0"] = new TranslationsDictionary
        {
          [Language.EN] = "Added command-line options (see help FAQ)." + Globals.NL +
                          "The reminder box has been improved." + Globals.NL +
                          "New editable parashot board." + Globals.NL +
                          "Parashah of the week is indicated for Shabat in visual calendar and in navigation window." + Globals.NL +
                          "Application title bar can show lunar today and weekly parashah." + Globals.NL +
                          "Visual calendar and navigation window indicates intermediate days of week-long celebrations." + Globals.NL +
                          "Image of the Tray Icon changes during a Shabat day or celebration regardless of reminder boxes." + Globals.NL +
                          "Web update check is not performed on a day off while the application is running." + Globals.NL +
                          "Fixed celebrations board showing moon times in the case of sun omer." + Globals.NL +
                          "Boards are exportable as TXT files in addition to CSV and JSON." + Globals.NL +
                          "Added keyboard shortchuts to navigate between months having celebrations." + Globals.NL +
                          "Added New in version in the Information menu." + Globals.NL +
                          "Update web links and Bible study providers." + Globals.NL +
                          "Some improvements in appearance and function.",

          [Language.FR] = "Ajout d'options de ligne de commande (voir la FAQ de l'aide)." + Globals.NL +
                          "Boite de rappel a été améliorée." + Globals.NL +
                          "Nouveau tableau des parashot modifiables" + Globals.NL +
                          "Indication de la parashah de la semaine pour le Shabat dans le calendrier visuel et la fenêtre de navigation." + Globals.NL +
                          "La barre de titre de l'application peut afficher la date lunaire d'aujourd'hui et la parashah hebdomadaire." + Globals.NL +
                          "Indication des jours intermédiaires de célébration durnt qui durent une semaine dans le calendrier visuel et la fenêtre de navigation." + Globals.NL +
                          "L'image de la Tray Icon change durant un jour de Shabat ou de célébration quelque soient les boites de rappel." + Globals.NL +
                          "La vérification de mise à jour en ligne n'est pas effectuée durant un jour de repos pendant l'exécution de l'application." + Globals.NL +
                          "Correction du tableau des célébrations qui indiquait les heures de la lune dans le cas du omer du soleil." + Globals.NL +
                          "Les tableaux sont exportables en fichiers TXT en plus de CSV et JSON." + Globals.NL +
                          "Ajout de raccourcis clavier pour naviguer entre les mois ayant des célébrations." + Globals.NL +
                          "Ajout des Nouveautés de version dans le menu Information." + Globals.NL +
                          "Mise à jour des liens web et fournisseurs d'étude de la Bible." + Globals.NL +
                          "Quelques améliorations d'aspect et de fonctionnement."
        }

      };

  }

}
