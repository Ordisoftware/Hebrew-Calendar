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
/// <created> 2016-04 </created>
/// <edited> 2023-07 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Localization strings.
/// </summary>
static partial class AppTranslations
{

  static public readonly TranslationsDictionary NoticeKeyboardShortcutsTitle = new()
  {
    [Language.EN] = "Keyboard shortcuts notice",
    [Language.FR] = "Notice des raccourcis clavier"
  };

  static public readonly TranslationsDictionary NoticeKeyboardShortcuts = new()
  {
    [Language.EN] = """
                    Ctrl + Tab : Next view
                    Shift + Ctrl + Tab : Previous view
                    F1 : Text report view
                    F2 : Monthly view
                    F3 : Database grid view
                    F4 : Next celebrations window
                    F5 : Search a celebration window
                    F6 : Search a moon month window
                    F7 : Search a gregorian month window
                    F8 (or Ctrl + N) : Navigation window
                    Ctrl + T (or Numpad0) : Go to today
                    Ctrl + B (or Decimal) : Go to selected day
                    Ctrl + D : Search a day
                    Ctrl + S : Save current view to file
                    Ctrl + C : Copy current view to clipboard
                    Ctrl + P : Print current view
                    Ctrl + Shift + C : Copy the text report selection to clipboard
                    Alt + V : View menu
                    Alt + T : Tools menu
                    Alt + L : Web links menu
                    Alt + I : Information menu
                    Alt + S : Settings menu
                    Alt + E : Export folder
                    Alt + C : Windows calculator
                    Alt + D : Windows date and time settings
                    Alt + M : Windows weather
                    Alt + W : Online weather
                    Alt + G : Generate calendar
                    Alt + P : Show online parashah menu
                    Alt + B : Manage bookmarks
                    Alt + N : Notice window
                    Ctrl + F1 : Parashot board
                    Ctrl + F2 : Celebration verses board
                    Ctrl + F3 : Celebrations board
                    Ctrl + F4 : New moons board
                    Ctrl + F5 : Lunar months board
                    Ctrl + Shift + D : Dates difference calculator
                    Home : First month available in the database
                    End : Last month available in the database
                    Up (ou PageUp) : Previous year
                    Down (ou PageDown) : Next year
                    Left : Previous month
                    Right : Next month
                    Ctrl + Left : Previous month having a celebration
                    Ctrl + Right : Next month having a celebration
                    Ctrl + Home : First month having a celebration
                    Ctrl + End : Last month having a celebration
                    Shit + Up : Semaine précédente
                    Shit + Down : Previous week
                    Shit + Left : Next week
                    Shit + Right : Next day
                    Alt + Left : Previous lunar month
                    Alt + Right : Next lunar month
                    Alt + Up (or PageUp) : Previous lunar year
                    Alt + Down (or PageDown) : Next lunar year
                    Add or Sub : Change active day
                    Shift + Click : Set active day
                    Ctrl + Click : Select day
                    F9 : Preferences
                    F10 : Log file window
                    F11 : Usage statistics window
                    F12 : About
                    Alt + F4 (ou Escape) : Close window
                    Ctrl + Alt + F4 : Exit application
                    """,

    [Language.FR] = """
                    Ctrl + Tab : Vue suivante
                    Maj + Ctrl + Tab : Vue précédente
                    F1 : Vue du rapport textuel
                    F2 : Vue du mois
                    F3 : Vue de la grille de données
                    F4 : Fenêtre des prochaines célébrations
                    F5 : Fenêtre de recherche de célébration
                    F6 : Fenêtre de recherche de mois lunaire
                    F7 : Fenêtre de recherche de mois grégorien
                    F8 (ou Ctrl + N) : Fenêtre de navigation
                    Ctrl + T (ou Numpad0) : Aller à aujourd'hui
                    Ctrl + B (ou Décimal) : Aller au jour sélectionné
                    Ctrl + D : Chercher un jour
                    Ctrl + S : Sauvegarde la vue en cours dans un fichier
                    Ctrl + C : Copie la vue en cours dans le presse-papier
                    Ctrl + P : Imprime la vue en cours
                    Ctrl + Maj + C : Copie la sélection du rapport textuel dans le presse-papier
                    Alt + V : Menu des vues
                    Alt + T : Menu des outils
                    Alt + L : Menu des liens web
                    Alt + I : Menu des informations
                    Alt + S : Menu des paramètres
                    Alt + E : Dossier d'export
                    Alt + C : Calculatrice Windows
                    Alt + D : Paramètres de date et heure de Windows
                    Alt + M : Météo Windows
                    Alt + W : Météo en ligne
                    Alt + G : Génère le calendrier
                    Alt + P : Affiche le menu de la parashah en ligne
                    Alt + B : Gérer les favoris
                    Alt + N : Fenêtre des notices
                    Ctrl + F1 : Tableau des parashot
                    Ctrl + F2 : Tableau des versets des célébrations
                    Ctrl + F3 : Tableau des célébrations
                    Ctrl + F4 : Tableau des nouvelles lunes
                    Ctrl + F5 : Tableau des mois lunaires
                    Ctrl + Maj + D : Calculateur de différence de dates
                    Début : Premier mois disponible dans la base de données
                    Fin : Dernier mois disponible dans la base de données
                    Haut (ou PagePrec) : Année précédente
                    Bas (ou PageSuiv) : Année suivante
                    Gauche : Mois précédent
                    Droite : Mois suivant
                    Ctrl + Gauche : Mois précédent ayant une célébration
                    Ctrl + Droite : Mois suivant ayant une célébration
                    Ctrl + Début : Premier mois ayant une célébration
                    Ctrl + Fin : Dernier mois ayant une célébration
                    Maj + Haut : Semaine précédente
                    Maj + Bas : Semaine suivante
                    Maj + Gauche : Jour précédent
                    Maj + Droite : Jour suivant
                    Alt + Gauche : Mois lunaire précédent
                    Alt + Droite : Mois lunaire suivant
                    Alt + Haut (or PagePrec) : Année lunaire précédente
                    Alt + bas (or PageSuiv) : Année lunaire suivante
                    Plus ou Moins : Changer de jour actif
                    Maj + Clic : Définir jour actif
                    Ctrl + Clic : Sélectionner jour
                    F9 : Préférences
                    F10 : Fenêtre du fichier log
                    F11 : Fenêtre des statistiques d'utilisation
                    F12 : A propos
                    Alt + F4 (ou Échap) : Ferme la fenêtre
                    Ctrl + Alt + F4 : Ferme l'application
                    """,
  };

}
