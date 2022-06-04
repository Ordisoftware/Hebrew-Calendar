/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2022 Olivier Rogier.
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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Localization strings.
/// </summary>
static partial class AppTranslations
{

  static public readonly NullSafeDictionary<string, TranslationsDictionary> NoticeNewFeatures = new()
  {

    /*["10.0"] = new TranslationsDictionary
    {
      [Language.EN] = "• Added lunar months board with hebrew names, meanings, lettriqs and tools." + Globals.NL +
                      "• Added a command-line option to show the lunar months board." + Globals.NL +
                      "• Some fixes and improvements.",

      [Language.FR] = "• Ajout d'un tableau des mois lunaires avec noms hébreux, significations, lettriques et outils." + Globals.NL +
                      "• Ajout d'une option de ligne de commande pour afficher la boite de description de la parashah hebdomadaire." + Globals.NL +
                      "• Quelques améliorations et corrections."
    },*/

    // TODO delete all 9.x without changing 9.x

    ["9.29"] = new TranslationsDictionary
    {
      [Language.EN] = "• Optimize populating monthly view and thus startup time." + Globals.NL +
                      "• Add open system calculator button in DatesDiffCalculator form." + Globals.NL +
                      "• Add parashah name in the title bar of description box." + Globals.NL +
                      "• Add menu for transcription guide in Tools menu and others windows." + Globals.NL +
                      "• Add menu for grammar guide in Tools and others windows." + Globals.NL +
                      "• Fix reset settings crashes the monthly view until restart." + Globals.NL +
                      "• Fix multiple parashah description boxes at the same time which only displays the first one opened until closed." + Globals.NL +
                      "• Fix save in parashot board causes a null exception in case of empty cells in the grid." + Globals.NL +
                      "• Fix intermediate day names of weekly celebrations in case of moonrise occurring the next day (moon omer)." + Globals.NL +
                      "• Fix disable reminder button not disabled if disabling is not allowed in preferences." + Globals.NL +
                      "• Improve transcriptions following a change to better distinguish between He, 'Het, H'ayin, T'et and Tav." + Globals.NL +
                      "• Some UI/UX improvements and fixes." + Globals.NL +
                      "• Reorganize and add some web links",

      [Language.FR] = "• Optimisation du remplissage de la vue mensuelle et donc du temps de démarrage." + Globals.NL +
                      "• Ajout d'un bouton pour ouvrir la calculatrice système dans le formulaire DatesDiffCalculator." + Globals.NL +
                      "• Ajout du nom de la parashah dans la barre de titre de la fenêtre de description." + Globals.NL +
                      "• Ajout d'un menu pour un guide de transcription dans le menu Outils et les autres fenêtres." + Globals.NL +
                      "• Ajout d'un menu pour un guide de grammaire dans le menu Outils et les autres fenêtres." + Globals.NL +
                      "• Correction de la réinitialisation des paramètres qui plante la vue mensuelle jusqu'au redémarrage." + Globals.NL +
                      "• Correction de plusieurs boîtes de description de parashah ouvertes en même temps qui n'affichent que la première ouverte jusqu'à la fermeture." + Globals.NL +
                      "• Correction de l'enregistrement dans le tableau des parashot qui provoque une null exception en cas de cellules vides dans la grille." + Globals.NL +
                      "• Correction des noms des jours intermédiaires des célébrations hebdomadaires en cas de lever de lune survenant le lendemain (omer de la lune)." + Globals.NL +
                      "• Correction du bouton de désactivation du rappeleur non désactivé si la désactivation n'est pas autorisée dans les préférences." + Globals.NL +
                      "• Amélioration les transcriptions suite à un changement pour mieux distinguer He, 'Het, H'ayin, T'et et Tav." + Globals.NL +
                      "• Quelques améliorations et corrections UI/UX." + Globals.NL +
                      "• Réorganiser et ajout des liens Web."
    },

    ["9.28"] = new TranslationsDictionary
    {
      [Language.EN] = "• Add current day change when cursor changes line in text report." + Globals.NL +
                      "• Improve lunar month names by adding English transcription in addition to French." + Globals.NL +
                      "• Improve context menu of monthly view by disabling empty bookmarks in the Go To menu item." + Globals.NL +
                      "• Improve the setting of the number of bookmarks by limiting it to the last index defined." + Globals.NL +
                      "• Improve bookmark import to automatically extend the length to match." + Globals.NL +
                      "• Fix copy weekly parashah to clipboard to remove empty lines at the end." + Globals.NL +
                      "• Some data generation improvements and fixes." + Globals.NL +
                      "• Some UI/UX improvements and fixes." + Globals.NL +
                      "• Some fixes." + Globals.NL +
                      "• Some optimizations." + Globals.NL +
                      "• Massive refactorings with new code analyzers." + Globals.NL +
                      "• Improve setup to select hebrew font version." + Globals.NL +
                      "• Update Aish web links for parashot study.",

      [Language.FR] = "• Ajout du changement de jour actuel lorsque le curseur change de ligne dans le rapport texte." + Globals.NL +
                      "• Amélioration des noms des mois lunaires en ajoutant la transcription en anglais en plus du français." + Globals.NL +
                      "• Amélioration du menu contextuel de la vue mensuelle en désactivant les signets vides dans l'élément de menu Aller." + Globals.NL +
                      "• Amélioration du paramétrage du nombre de signets en le limitant au dernier index défini." + Globals.NL +
                      "• Amélioration de l'importation des signets pour étendre automatiquement la longueur pour correspondre." + Globals.NL +
                      "• Correction de la copie de la parashah hebdomadaire dans le presse-papiers pour supprimer les lignes vides à la fin." + Globals.NL +
                      "• Quelques améliorations et corrections de la génération des données." + Globals.NL +
                      "• Quelques améliorations et corrections de l'UI/UX." + Globals.NL +
                      "• Quelques correctifs." + Globals.NL +
                      "• Quelques optimisations." + Globals.NL +
                      "• Refactorisations massive avec de nouveaux analyseurs de code." + Globals.NL +
                      "• Amélioration du setup pour sélectionner la version de la fonte hébreu." + Globals.NL +
                      "• Mise à jour des liens Web Aish pour l'étude parashot."
    },

    ["9.27"] = new TranslationsDictionary
    {
      [Language.EN] = "• Code refactoring." + Globals.NL +
                      "• Fix open navigation window from calendar's context menu." + Globals.NL +
                      "• Fix order of controls in generation tab of preferences." + Globals.NL +
                      "• Disable IPC intercom for non-administrator users." + Globals.NL +
                      "• Update web links with more resources on Loubavitch." + Globals.NL +
                      "• Update web links with several changes." + Globals.NL +
                      "• Update FAQ and Help." + Globals.NL +
                      "• Add Hebrew font version available on Fonts2u(can be manually installed).",

      [Language.FR] = "• Refactorisation du code." + Globals.NL +
                      "• Correction de l'ouverture de la fenêtre de navigation depuis le menu contextuel du calendrier." + Globals.NL +
                      "• Correction de l'ordre des contrôles dans l'onglet génération des préférences." + Globals.NL +
                      "• Désactivation de l'inter-com IPC pour les utilisateurs non administrateurs." + Globals.NL +
                      "• Mise à jour les liens Web avec plus de ressources sur Loubavitch." + Globals.NL +
                      "• Mise à jour les liens Web avec plusieurs modifications." + Globals.NL +
                      "• Mise à jour la FAQ et l'aide." + Globals.NL +
                      "• Ajout de la version de police Hebrew disponible sur Fonts2u (peut être installée manuellement)."
    },

    ["9.24"] = new TranslationsDictionary
    {
      [Language.EN] = "• Fix Tetsaveh hebrew name and lettriq: parashot board need to be restored or edited, see ParashotFactory.txt and Parashot-Lettriqs.txt in application's document folder.",

      [Language.FR] = "• Correction du nom hébreu de Tetsaveh et de la lettrique : le tableau des parashot doit être restaurée ou édité, voir ParashotFactory.txt et Parashot-Lettriqs.txt dans le dossier de documents de l'application."
    },

    ["9.x"] = new TranslationsDictionary
    {
      [Language.EN] = "• Added mouse hover effect in monthly view." + Globals.NL +
                      "• Added context menu for days in monthly view." + Globals.NL +
                      "• Added bookmarks to context menu in monthly view." + Globals.NL +
                      "• Added some options and colors for monthly view." + Globals.NL +
                      "• Added option to show current celebration in the title bar." + Globals.NL +
                      "• Added option to set active day by click in monthly view." + Globals.NL +
                      "• Added option for double-click in visual month to set active or select." + Globals.NL +
                      "• Added some keyboard shortcuts to change and select day in monthly view." + Globals.NL +
                      "• Added celebration verses board and its command-line option." + Globals.NL +
                      "• Added search next parashah from today in parashot board." + Globals.NL +
                      "• Moved day of shabat selection to the generation tab in the preferences." + Globals.NL +
                      "• Improved export filenames for celebrations and new moons boards." + Globals.NL +
                      "• Improved web links menus to display those in the current language to the top." + Globals.NL +
                      "• The monthly view displays solar hours in case of sun omer." + Globals.NL +
                      "• Fixed some check boxes in celebrations and new moons boards." + Globals.NL +
                      "• Some fixes and improvements." + Globals.NL +
                      "• Code optimized and refactored." + Globals.NL +
                      "• Updated and reorganize web links.",

      [Language.FR] = "• Ajout d'un effet de survol de la souris dans la vue mensuelle." + Globals.NL +
                      "• Ajout d'un menu contextuel des jours dans la vue mensuelle." + Globals.NL +
                      "• Ajout des signets au menu contextuel dans la vue mensuelle." + Globals.NL +
                      "• Ajout de quelques options et couleurs pour la vue mensuelle." + Globals.NL +
                      "• Ajout d'une option pour afficher la célébration en cours dans la barre de titre." + Globals.NL +
                      "• Ajout d'une option pour définir le jour actif pas un clic dans la vue mensuelle." + Globals.NL +
                      "• Ajout d'une option pour choisir l'action pour le double-clic dans la vue mensuelle." + Globals.NL +
                      "• Ajout de raccourcis clavier pour changer et sélectionner un jour dans la vue mensuelle." + Globals.NL +
                      "• Ajout d'un tableau des versets des célébrations et de son option de ligne de commande." + Globals.NL +
                      "• Ajout de la recherche de la prochaine parashah depuis aujourd'hui dans le tableau des parashot." + Globals.NL +
                      "• Déplacement du choix du jour du shabat vers l'onglet de génération dans les préférences." + Globals.NL +
                      "• Amélioration des noms de fichiers exportés par les tableaux des célébrations et des nouvelles lunes." + Globals.NL +
                      "• Amélioration des menus de liens web pour afficher ceux dans la langue actuelle vers le haut." + Globals.NL +
                      "• La vue mensuelle affiche les heures solaires en cas de omer du soleil." + Globals.NL +
                      "• Correction de cases à cocher dans les tableaux des célébrations et des nouvelles lunes." + Globals.NL +
                      "• Quelques corrections et améliorations." + Globals.NL +
                      "• Code optimisé et refactorisé." + Globals.NL +
                      "• Mise à jour et réorganisation des liens web."
    },

    ["8.x"] = new TranslationsDictionary
    {
      [Language.EN] = "• SQLite ODBC Driver is no more needed." + Globals.NL +
                      "• Overall performances are optimized." + Globals.NL +
                      "• Added copy to clipboard button in parashah description box." + Globals.NL +
                      "• Added weekly parashah reminder." + Globals.NL +
                      "• Added a command-line option to show the weekly parashah description box." + Globals.NL +
                      "• Improved parashot titles and menus." + Globals.NL +
                      "• Improved navigation window." + Globals.NL +
                      "• Improved reminder boxes." + Globals.NL +
                      "• Some fixes and improvements.",

      [Language.FR] = "• Le pilote SQLite ODBC n'est plus nécessaire." + Globals.NL +
                      "• Les performances globales sont optimisées." + Globals.NL +
                      "• Ajout d'un bouton copier dans le presse-papier pour la boite de description de parashah." + Globals.NL +
                      "• Ajout d'un rappel de la parashah hebdomadaire." + Globals.NL +
                      "• Ajout d'une option de ligne de commande pour afficher la boite de description de la parashah de la semaine." + Globals.NL +
                      "• Amélioration des titres et des menus des parashot." + Globals.NL +
                      "• Amélioration de la fenêtre de navigation." + Globals.NL +
                      "• Amélioration des boites de rappel." + Globals.NL +
                      "• Quelques corrections et améliorations."
    },

    ["7.x"] = new TranslationsDictionary
    {
      [Language.EN] = "• Added command-line options (see help FAQ)." + Globals.NL +
                      "• The reminder box has been improved." + Globals.NL +
                      "• New editable parashot board." + Globals.NL +
                      "• Parashah of the week is indicated for Shabat in visual calendar and in navigation window." + Globals.NL +
                      "• Added the weekly parashah in the Shabat reminder box." + Globals.NL +
                      "• Application title bar can show lunar today and weekly parashah." + Globals.NL +
                      "• Visual calendar and navigation window indicates intermediate days of week-long celebrations." + Globals.NL +
                      "• Image of the Tray Icon changes during a Shabat day or celebration regardless of reminder boxes." + Globals.NL +
                      "• Web update check is not performed on a day off while the application is running." + Globals.NL +
                      "• Fixed celebrations board showing moon times in the case of sun omer." + Globals.NL +
                      "• Boards are exportable as TXT files in addition to CSV and JSON." + Globals.NL +
                      "• Added keyboard shortcuts to navigate between months having celebrations." + Globals.NL +
                      "• Added New in version in the Information menu." + Globals.NL +
                      "• Update web links and Bible study providers." + Globals.NL +
                      "• Some improvements in appearance and function.",

      [Language.FR] = "• Ajout d'options de ligne de commande (voir la FAQ de l'aide)." + Globals.NL +
                      "• Boite de rappel a été améliorée." + Globals.NL +
                      "• Nouveau tableau des parashot modifiables" + Globals.NL +
                      "• Indication de la parashah de la semaine pour le Shabat dans le calendrier visuel et la fenêtre de navigation." + Globals.NL +
                      "• Ajout de la parashah de la semaine dans la boite de rappel du Shabat." + Globals.NL +
                      "• La barre de titre de l'application peut afficher la date lunaire d'aujourd'hui et la parashah hebdomadaire." + Globals.NL +
                      "• Indication des jours intermédiaires pour les célébrations qui durent une semaine dans le calendrier visuel et la fenêtre de navigation." + Globals.NL +
                      "• L'image de la Tray Icon change durant un jour de Shabat ou de célébration quelque soient les boites de rappel." + Globals.NL +
                      "• La vérification de mise à jour en ligne n'est pas effectuée durant un jour de repos pendant l'exécution de l'application." + Globals.NL +
                      "• Correction du tableau des célébrations qui indiquait les heures de la lune dans le cas du omer du soleil." + Globals.NL +
                      "• Les tableaux sont exportables en fichiers TXT en plus de CSV et JSON." + Globals.NL +
                      "• Ajout de raccourcis clavier pour naviguer entre les mois ayant des célébrations." + Globals.NL +
                      "• Ajout des Nouveautés de version dans le menu Information." + Globals.NL +
                      "• Mise à jour des liens web et fournisseurs d'étude de la Bible." + Globals.NL +
                      "• Quelques améliorations d'aspect et de fonctionnement."
    },

    ["6.x"] = new TranslationsDictionary
    {
      [Language.EN] = "• Optimized monthly view painting speed." + Globals.NL +
                      "• Added Windows global hot-key." + Globals.NL +
                      "• Added celebrations board." + Globals.NL +
                      "• Added new moons board." + Globals.NL +
                      "• Added print preview for calendar export." + Globals.NL +
                      "• Added links to local and online weather." + Globals.NL +
                      "• Added backup and restore date bookmarks." + Globals.NL +
                      "• Added export and import settings." + Globals.NL +
                      "• Improved preferences." + Globals.NL +
                      "• Update web links." + Globals.NL +
                      "• Some improvements and fixes.",

      [Language.FR] = "• Vitesse de peinture du mois visuel optimisée." + Globals.NL +
                      "• Ajout d'un raccourci de clavier global Windows." + Globals.NL +
                      "• Ajout d'un tableau des célébrations." + Globals.NL +
                      "• Ajout d'un tableau des nouvelles lunes." + Globals.NL +
                      "• Ajout d'un aperçu avant impression pour l'exportation du calendrier." + Globals.NL +
                      "• Ajout de liens vers la météo locale et en ligne." + Globals.NL +
                      "• Ajout de la sauvegarde et restauration des signets de date." + Globals.NL +
                      "• Ajout de l'exportation et importation des paramètres." + Globals.NL +
                      "• Préférences améliorées." + Globals.NL +
                      "• Mise à jour les liens web." + Globals.NL +
                      "• Quelques améliorations et corrections."
    },

    ["5.x"] = new TranslationsDictionary
    {
      [Language.EN] = "• Remove the generate dialog box at first startup and auto-regenerate." + Globals.NL +
                      "• Improved check update to securely download and auto-install." + Globals.NL +
                      "• Improved keyboard shortcuts." + Globals.NL +
                      "• Improved data generation speed by a half." + Globals.NL +
                      "• Improved monthly view speed by a half." + Globals.NL +
                      "• Improved tray icon menu." + Globals.NL +
                      "• Improved preferences options." + Globals.NL +
                      "• Improved dialogs." + Globals.NL +
                      "• Added sounds." + Globals.NL +
                      "• Added search Gregorian month window." + Globals.NL +
                      "• New advanced export and printing dialog box." + Globals.NL +
                      "• Rework of the preferences window design with more options." + Globals.NL +
                      "• New usage statistics window." + Globals.NL +
                      "• General improvement and some fixes.",

      [Language.FR] = "• Suppression de la boîte de dialogue de génération au premier démarrage et lors de la régénération automatiquement." + Globals.NL +
                      "• Amélioration de la vérification de mise à jour pour télécharger et installer automatiquement de manière sécurisée." + Globals.NL +
                      "• Amélioration des raccourcis clavier." + Globals.NL +
                      "• Amélioration de moitié de la vitesse de génération des données." + Globals.NL +
                      "• Amélioration de moitié de la vitesse d'affichage du mois visuel." + Globals.NL +
                      "• Amélioration du menu de l'icône de la barre d'état." + Globals.NL +
                      "• Amélioration des options de préférences." + Globals.NL +
                      "• Amélioration des boites de dialogues." + Globals.NL +
                      "• Ajout de sons." + Globals.NL +
                      "• Ajout d'une fenêtre de recherche de mois grégorien." + Globals.NL +
                      "• Nouvelle boîte de dialogue avancée d'exportation et d'impression." + Globals.NL +
                      "• Refonte de la fenêtre des préférences avec ajout d'options." + Globals.NL +
                      "• Nouvelle fenêtre de statistiques d'utilisation." + Globals.NL +
                      "• Amélioration générale et quelques corrections."
    },

    ["4.x"] = new TranslationsDictionary
    {
      [Language.EN] = "• Improved startup configuration." + Globals.NL +
                      "• Improved visual calendar." + Globals.NL +
                      "• Improved preferences." + Globals.NL +
                      "• Added celebrations and Shabat notices" + Globals.NL +
                      "• Added dates difference calculator." + Globals.NL +
                      "• Added suspend reminder." + Globals.NL +
                      "• Added tools menu." + Globals.NL +
                      "• Added web links menu." + Globals.NL +
                      "• Added debugger and logger." + Globals.NL +
                      "• General improvement and some fixes.",

      [Language.FR] = "• Configuration de démarrage améliorée." + Globals.NL +
                      "• Calendrier visuel amélioré." + Globals.NL +
                      "• Préférences améliorées." + Globals.NL +
                      "• Ajout des notices de célébrations et du Shabat" + Globals.NL +
                      "• Ajout d'un calculateur de différence de dates." + Globals.NL +
                      "• Ajout d'un de la suspension des rappels." + Globals.NL +
                      "• Ajout d'un menu outils." + Globals.NL +
                      "• Ajout d'un menu liens Web." + Globals.NL +
                      "• Ajout d'un débogueur et d'un logger" + Globals.NL +
                      "• Améliorations générales et quelques corrections."
    },

    ["3.x"] = new TranslationsDictionary
    {
      [Language.EN] = "• Improved speed." + Globals.NL +
                      "• Improved Tray Icon." + Globals.NL +
                      "• Improved reminder box." + Globals.NL +
                      "• Celebration reminder in addition to Shabat." + Globals.NL +
                      "• New window to search a celebration." + Globals.NL +
                      "• New window to search a lunar month." + Globals.NL +
                      "• Added colors for special days." + Globals.NL +
                      "• Added auto-lock session during special days." + Globals.NL +
                      "• Added world cities database to select GPS." + Globals.NL +
                      "• Option to select sun or moon omer." + Globals.NL +
                      "• Regenerate data if today is near the end." + Globals.NL +
                      "• General improvement and some fixes.",

      [Language.FR] = "• Amélioration de la vitesse." + Globals.NL +
                      "• Amélioration de l'icône de la barre d'état." + Globals.NL +
                      "• Amélioration de la boîte de rappel." + Globals.NL +
                      "• Rappel de célébration en plus du Shabat." + Globals.NL +
                      "• Nouvelle fenêtre pour rechercher une célébration." + Globals.NL +
                      "• Nouvelle fenêtre pour rechercher un mois lunaire." + Globals.NL +
                      "• Ajout de couleurs pour des jours spéciaux." + Globals.NL +
                      "• Ajout du verrouillage automatique de session pendant les jours spéciaux." + Globals.NL +
                      "• Ajout la base de données des villes du monde pour sélectionner le GPS." + Globals.NL +
                      "• Option pour sélectionner le soleil ou la lune omer." + Globals.NL +
                      "• Régénération des données si aujourd'hui est proche de la fin." + Globals.NL +
                      "• Amélioration générale et quelques corrections."
    },

    ["2.x"] = new TranslationsDictionary
    {
      [Language.EN] = "• Improve reminder system." + Globals.NL +
                      "• Some improvements and fixes.",

      [Language.FR] = "• Amélioration du système de rappel." + Globals.NL +
                      "• Quelques améliorations et corrections.",
    },

    ["1.x"] = new TranslationsDictionary
    {
      [Language.EN] = "• Initial release." + Globals.NL +
                      "• Text report only, and then monthly view." + Globals.NL +
                      "• Next celebrations windows." + Globals.NL +
                      "• Day navigation windows." + Globals.NL +
                      "• Shabat reminder." + Globals.NL +
                      "• Basic preferences and GPS coordinates.",

      [Language.FR] = "• Version initiale" + Globals.NL +
                      "• Rapport texte seul, puis vue du mois visuel." + Globals.NL +
                      "• Fenêtre des prochaines célébrations." + Globals.NL +
                      "• Fenêtre de navigation par jour." + Globals.NL +
                      "• Rappel de Shabat." + Globals.NL +
                      "• Préférences de base et coordonnées GPS."
    },

  };

}
