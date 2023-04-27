/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2023 Olivier Rogier.
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
/// <edited> 2023-04 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Localization strings.
/// </summary>
static partial class AppTranslations
{

  static public readonly TranslationsDictionary PreviewFunctions = new()
  {
    [Language.EN] = "    • Lunar month names board" + Globals.NL +
                    "    • Web links edition" + Globals.NL +
                    "    • Dark theme",

    [Language.FR] = "    • Tableau des noms des mois lunaires" + Globals.NL +
                    "    • Edition des liens web" + Globals.NL +
                    "    • Theme sombre",
  };

  static public readonly NullSafeDictionary<string, TranslationsDictionary> NoticeNewFeatures = new()
  {

    //Template
    //["x.y"] = new TranslationsDictionary
    //{
    //  [Language.EN] = """

    //                  """,

    //  [Language.FR] = """

    //                  """,
    //},

    /*["x.y"] = new TranslationsDictionary
    {
      [Language.EN] = """
                      • Added lunar months board with hebrew names, meanings, lettriqs and tools.
                      • Added a command-line option to show the lunar months board.
                      • Some fixes and improvements.
                      """,

      [Language.FR] = """
                      • Ajout d'un tableau des mois lunaires avec noms hébreux, significations, lettriques et outils.
                      • Ajout d'une option de ligne de commande pour afficher la boite de description de la parashah hebdomadaire.
                      • Quelques améliorations et corrections.
                      """,
    },*/

    ["11.0"] = new TranslationsDictionary
    {
      [Language.EN] = """
                      • Added memos to date bookmarks.
                      • Added option to automatically sort date bookmarks.
                      • Added manage bookmarks menu item in Tools and Ctrl + B shortcut. 
                      • Added previous and next buttons to parashah description box.
                      • Added Accuweather.com provider.
                      """,

      [Language.FR] = """
                      • Ajout des mémos aux signets de date.
                      • Ajout d'une option pour trier automatiquement les signets de date.
                      • Ajout d'un élément de menu pour la gestion des signets dans les outils et le raccourci Ctrl + B.
                      • Ajout de boutons précédent et suivant à la boîte de description de parashah.
                      • Ajout du fournisseur Accuweather.com.
                      """,
    },

    ["10.x"] = new TranslationsDictionary
    {
      [Language.EN] = """
                      • Adar II was renamed in VeAdar.
                      • Added import settings button in city selection box on first start.
                      • Added verse references for Shabat in celebrations board.
                      • Added options for the data layout in the monthly view : to put the lunar date on a single line before the ephemeris, to display the book name with references of parashah, to set text alignment, and to insert separator between sections.
                      • Added options to select font names for texts in the monthly view.
                      • Added option to select data layout order and sections to show in the monthly view.
                      • Added option to set default online verses reader.
                      • Added option to center printed images on pages.
                      • Added options to display Hebrew names in Unicode chars or Latin transcription, and to keep Arabic numerals in case of Unicode.
                      • Divided study context menu into `Online texts` and `Online videos` in celebrations board.
                      • Improved web update checker security.
                      • Improved IPC interoperability security.
                      • Some fixes and improvements.
                      • Optimized and refactored code.
                      • Updated web links.
                      """,

      [Language.FR] = """
                      • Adar II a été renommé en VeAdar.
                      • Ajout d'un bouton d'importation des paramètres dans boite de sélection de la ville au premier démarrage.
                      • Ajout de références de versets pour le Shabat dans le tableau des célébrations.
                      • Ajout d'options pour la disposition des données dans la vue mensuelle : pour mettre la date lunaire sur une seule ligne avant les éphémérides, pour afficher le nom du livre avec les références de la parashah, pour définir l'alignement du texte et pour insérer un séparateur entre les sections.
                      • Ajout d'options pour afficher les noms hébreux en caractères Unicode ou en transcription latine, et pour conserver les chiffres arabes en cas d'Unicode.
                      • Ajout d'une option pour sélectionner les noms de police pour les textes dans la vue mensuelle
                      • Ajout d'une option pour sélectionner la disposition des données et les sections à afficher dans la vue mensuelle.
                      • Ajout d'une option pour définir le lecteur de versets en ligne par défaut.
                      • Ajout d'options pour centrer les images imprimées dans les pages.
                      • Division du menu contextuel d'étude `Textes en ligne` et `Vidéos en ligne` dans le tableau des célébrations.                      • Quelques correctifs et améliorations.
                      • Amélioration de la sécurité du vérificateur de mise à jour Web.
                      • Amélioration de la sécurité de l'interopérabilité IPC.
                      • Quelques corrections et améliorations.
                      • Code optimisé et refactorisé.
                      • Mise à jour des liens Web.
                      """,
    },

    ["9.x"] = new TranslationsDictionary
    {
      [Language.EN] = """ 
                      • Added mouse hover effect in monthly view.
                      • Added context menu for days in monthly view.
                      • Added bookmarks to context menu in monthly view.
                      • Added some options and colors for monthly view.
                      • Added option to show current celebration in the title bar.
                      • Added option to set active day by click in monthly view.
                      • Added option for double-click in visual month to set active or select.
                      • Added some keyboard shortcuts to change and select day in monthly view.
                      • Added celebration verses board and its command-line option.
                      • Added search next parashah from today in parashot board.
                      • Added search parashah text box in parashot board.
                      • Moved day of Shabat selection to the generation tab in the preferences.
                      • Improved export filenames for celebrations and new moons boards.
                      • Improved web links menus to display those in the current language to the top.
                      • The monthly view displays solar hours in case of sun omer.
                      • Fixed some check boxes in celebrations and new moons boards.
                      • Some fixes and improvements.
                      • Code optimized and refactored.
                      • Updated and reorganize web links.,
                      """,

      [Language.FR] = """ 
                      • Ajout d'un effet de survol de la souris dans la vue mensuelle.
                      • Ajout d'un menu contextuel des jours dans la vue mensuelle.
                      • Ajout des signets au menu contextuel dans la vue mensuelle.
                      • Ajout de quelques options et couleurs pour la vue mensuelle.
                      • Ajout d'une option pour afficher la célébration en cours dans la barre de titre.
                      • Ajout d'une option pour définir le jour actif pas un clic dans la vue mensuelle.
                      • Ajout d'une option pour choisir l'action pour le double-clic dans la vue mensuelle.
                      • Ajout de raccourcis clavier pour changer et sélectionner un jour dans la vue mensuelle.
                      • Ajout d'un tableau des versets des célébrations et de son option de ligne de commande.
                      • Ajout de la recherche de la prochaine parashah depuis aujourd'hui dans le tableau des parashot.
                      • Ajout d'une zone de texte de recherche de parashah dans le tableau des parashot.
                      • Déplacement du choix du jour du Shabat vers l'onglet de génération dans les préférences.
                      • Amélioration des noms de fichiers exportés par les tableaux des célébrations et des nouvelles lunes.
                      • Amélioration des menus de liens web pour afficher ceux dans la langue actuelle vers le haut.
                      • La vue mensuelle affiche les heures solaires en cas de omer du soleil.
                      • Correction de cases à cocher dans les tableaux des célébrations et des nouvelles lunes.
                      • Quelques corrections et améliorations.
                      • Code optimisé et refactorisé.
                      • Mise à jour et réorganisation des liens web.
                      """,
    },

    ["8.x"] = new TranslationsDictionary
    {
      [Language.EN] = """ 
                      • SQLite ODBC Driver is no more needed.
                      • Overall performances are optimized.
                      • Added copy to clipboard button in parashah description box.
                      • Added weekly parashah reminder.
                      • Added a command-line option to show the weekly parashah description box.
                      • Improved parashot titles and menus.
                      • Improved navigation window.
                      • Improved reminder boxes.
                      • Some fixes and improvements.,
                      """,

      [Language.FR] = """ 
                      • Le pilote SQLite ODBC n'est plus nécessaire.
                      • Les performances globales sont optimisées.
                      • Ajout d'un bouton copier dans le presse-papier pour la boite de description de parashah.
                      • Ajout d'un rappel de la parashah hebdomadaire.
                      • Ajout d'une option de ligne de commande pour afficher la boite de description de la parashah de la semaine.
                      • Amélioration des titres et des menus des parashot.
                      • Amélioration de la fenêtre de navigation.
                      • Amélioration des boites de rappel.
                      • Quelques corrections et améliorations.
                      """,
    },

    ["7.x"] = new TranslationsDictionary
    {
      [Language.EN] = """ 
                      • Added command-line options (see help FAQ).
                      • The reminder box has been improved.
                      • New editable parashot board.
                      • Parashah of the week is indicated for Shabat in visual calendar and in navigation window.
                      • Added the weekly parashah in the Shabat reminder box.
                      • Application title bar can show lunar today and weekly parashah.
                      • Visual calendar and navigation window indicates intermediate days of week-long celebrations.
                      • Image of the Tray Icon changes during a Shabat day or celebration regardless of reminder boxes.
                      • Web update check is not performed on a day off while the application is running.
                      • Fixed celebrations board showing moon times in the case of sun omer.
                      • Boards are exportable as TXT files in addition to CSV and JSON.
                      • Added keyboard shortcuts to navigate between months having celebrations.
                      • Added New in version in the Information menu.
                      • Update web links and Bible study providers.
                      • Some improvements in appearance and function.,
                      """,

      [Language.FR] = """ 
                      • Ajout d'options de ligne de commande (voir la FAQ de l'aide).
                      • Boite de rappel a été améliorée.
                      • Nouveau tableau des parashot modifiables
                      • Indication de la parashah de la semaine pour le Shabat dans le calendrier visuel et la fenêtre de navigation.
                      • Ajout de la parashah de la semaine dans la boite de rappel du Shabat.
                      • La barre de titre de l'application peut afficher la date lunaire d'aujourd'hui et la parashah hebdomadaire.
                      • Indication des jours intermédiaires pour les célébrations qui durent une semaine dans le calendrier visuel et la fenêtre de navigation.
                      • L'image de la Tray Icon change durant un jour de Shabat ou de célébration quelque soient les boites de rappel.
                      • La vérification de mise à jour en ligne n'est pas effectuée durant un jour de repos pendant l'exécution de l'application.
                      • Correction du tableau des célébrations qui indiquait les heures de la lune dans le cas du omer du soleil.
                      • Les tableaux sont exportables en fichiers TXT en plus de CSV et JSON.
                      • Ajout de raccourcis clavier pour naviguer entre les mois ayant des célébrations.
                      • Ajout des Nouveautés de version dans le menu Information.
                      • Mise à jour des liens web et fournisseurs d'étude de la Bible.
                      • Quelques améliorations d'aspect et de fonctionnement.
                      """,
    },

    ["6.x"] = new TranslationsDictionary
    {
      [Language.EN] = """ 
                      • Optimized monthly view painting speed.
                      • Added Windows global hot-key.
                      • Added celebrations board.
                      • Added new moons board.
                      • Added print preview for calendar export.
                      • Added links to local and online weather.
                      • Added backup and restore date bookmarks.
                      • Added export and import settings.
                      • Improved preferences.
                      • Update web links.
                      • Some improvements and fixes.,
                      """,

      [Language.FR] = """ 
                      • Vitesse de peinture du mois visuel optimisée.
                      • Ajout d'un raccourci de clavier global Windows.
                      • Ajout d'un tableau des célébrations.
                      • Ajout d'un tableau des nouvelles lunes.
                      • Ajout d'un aperçu avant impression pour l'exportation du calendrier.
                      • Ajout de liens vers la météo locale et en ligne.
                      • Ajout de la sauvegarde et restauration des signets de date.
                      • Ajout de l'exportation et importation des paramètres.
                      • Préférences améliorées.
                      • Mise à jour les liens web.
                      • Quelques améliorations et corrections.
                      """,
    },

    ["5.x"] = new TranslationsDictionary
    {
      [Language.EN] = """ 
                      • Remove the generate dialog box at first startup and auto-regenerate.
                      • Improved check update to securely download and auto-install.
                      • Improved keyboard shortcuts.
                      • Improved data generation speed by a half.
                      • Improved monthly view speed by a half.
                      • Improved tray icon menu.
                      • Improved preferences options.
                      • Improved dialogs.
                      • Added sounds.
                      • Added search Gregorian month window.
                      • New advanced export and printing dialog box.
                      • Rework of the preferences window design with more options.
                      • New usage statistics window.
                      • General improvement and some fixes.,
                      """,

      [Language.FR] = """ 
                      • Suppression de la boîte de dialogue de génération au premier démarrage et lors de la régénération automatiquement.
                      • Amélioration de la vérification de mise à jour pour télécharger et installer automatiquement de manière sécurisée.
                      • Amélioration des raccourcis clavier.
                      • Amélioration de moitié de la vitesse de génération des données.
                      • Amélioration de moitié de la vitesse d'affichage du mois visuel.
                      • Amélioration du menu de l'icône de la barre d'état.
                      • Amélioration des options de préférences.
                      • Amélioration des boites de dialogues.
                      • Ajout de sons.
                      • Ajout d'une fenêtre de recherche de mois grégorien.
                      • Nouvelle boîte de dialogue avancée d'exportation et d'impression.
                      • Refonte de la fenêtre des préférences avec ajout d'options.
                      • Nouvelle fenêtre de statistiques d'utilisation.
                      • Amélioration générale et quelques corrections.
                      """,
    },

    ["4.x"] = new TranslationsDictionary
    {
      [Language.EN] = """ 
                      • Improved startup configuration.
                      • Improved visual calendar.
                      • Improved preferences.
                      • Added celebrations and Shabat notices
                      • Added dates difference calculator.
                      • Added suspend reminder.
                      • Added tools menu.
                      • Added web links menu.
                      • Added debugger and logger.
                      • General improvement and some fixes.,
                      """,

      [Language.FR] = """ 
                      • Configuration de démarrage améliorée.
                      • Calendrier visuel amélioré.
                      • Préférences améliorées.
                      • Ajout des notices de célébrations et du Shabat
                      • Ajout d'un calculateur de différence de dates.
                      • Ajout d'un de la suspension des rappels.
                      • Ajout d'un menu outils.
                      • Ajout d'un menu liens Web.
                      • Ajout d'un débogueur et d'un logger
                      • Améliorations générales et quelques corrections.
                      """,
    },

    ["3.x"] = new TranslationsDictionary
    {
      [Language.EN] = """ 
                      • Improved speed.
                      • Improved Tray Icon.
                      • Improved reminder box.
                      • Celebration reminder in addition to Shabat.
                      • New window to search a celebration.
                      • New window to search a lunar month.
                      • Added colors for special days.
                      • Added auto-lock session during special days.
                      • Added world cities database to select GPS.
                      • Option to select sun or moon omer.
                      • Regenerate data if today is near the end.
                      • General improvement and some fixes.,
                      """,

      [Language.FR] = """ 
                      • Amélioration de la vitesse.
                      • Amélioration de l'icône de la barre d'état.
                      • Amélioration de la boîte de rappel.
                      • Rappel de célébration en plus du Shabat.
                      • Nouvelle fenêtre pour rechercher une célébration.
                      • Nouvelle fenêtre pour rechercher un mois lunaire.
                      • Ajout de couleurs pour des jours spéciaux.
                      • Ajout du verrouillage automatique de session pendant les jours spéciaux.
                      • Ajout la base de données des villes du monde pour sélectionner le GPS.
                      • Option pour sélectionner le soleil ou la lune omer.
                      • Régénération des données si aujourd'hui est proche de la fin.
                      • Amélioration générale et quelques corrections.
                      """,
    },

    ["2.x"] = new TranslationsDictionary
    {
      [Language.EN] = """ 
                      • Improve reminder system.
                      • Some improvements and fixes.,
                      """,

      [Language.FR] = """ 
                      • Amélioration du système de rappel.
                      • Quelques améliorations et corrections.,
                      """,
    },

    ["1.x"] = new TranslationsDictionary
    {
      [Language.EN] = """ 
                      • Initial release.
                      • Text report only, and then monthly view.
                      • Next celebrations windows.
                      • Day navigation windows.
                      • Shabat reminder.
                      • Basic preferences and GPS coordinates.,
                      """,

      [Language.FR] = """ 
                      • Version initiale
                      • Rapport texte seul, puis vue du mois visuel.
                      • Fenêtre des prochaines célébrations.
                      • Fenêtre de navigation par jour.
                      • Rappel de Shabat.
                      • Préférences de base et coordonnées GPS.
                      """,
    },

  };

}
