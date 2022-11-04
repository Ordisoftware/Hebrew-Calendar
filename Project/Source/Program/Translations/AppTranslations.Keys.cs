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
/// <created> 2016-04 </created>
/// <edited> 2022-04 </edited>
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
    [Language.EN] = "Ctrl + Tab : Next view" + Globals.NL +
                    "Shift + Ctrl + Tab : Previous view" + Globals.NL +
                    "F1 : Text report view" + Globals.NL +
                    "F2 : Monthly view" + Globals.NL +
                    "F3 : Database grid view" + Globals.NL +
                    "F4 : Next celebrations window" + Globals.NL +
                    "F5 : Search a celebration window" + Globals.NL +
                    "F6 : Search a moon month window" + Globals.NL +
                    "F7 : Search a gregorian month window" + Globals.NL +
                    "F8 (or Ctrl + N) : Navigation window" + Globals.NL +
                    "Ctrl + T (or Numpad0) : Go to today" + Globals.NL +
                    "Ctrl + B (or Decimal) : Go to selected day" + Globals.NL +
                    "Ctrl + D : Search a day" + Globals.NL +
                    "Ctrl + S : Save current view to file" + Globals.NL +
                    "Ctrl + C : Copy current view to clipboard" + Globals.NL +
                    "Ctrl + P : Print current view" + Globals.NL +
                    "Ctrl + Shift + C : Copy the text report selection to clipboard" + Globals.NL +
                    "Alt + V : View menu" + Globals.NL +
                    "Alt + T : Tools menu" + Globals.NL +
                    "Alt + L : Web links menu" + Globals.NL +
                    "Alt + I : Information menu" + Globals.NL +
                    "Alt + S : Settings menu" + Globals.NL +
                    "Alt + E : Export folder" + Globals.NL +
                    "Alt + C : Windows calculator" + Globals.NL +
                    "Alt + D : Windows date and time settings" + Globals.NL +
                    "Alt + M : Windows weather" + Globals.NL +
                    "Alt + W : Online weather" + Globals.NL +
                    "Alt + G : Generate calendar" + Globals.NL +
                    "Alt + P : Show online parashah menu" + Globals.NL +
                    "Ctrl + F1 : Parashot board" + Globals.NL +
                    "Ctrl + F2 : Celebration verses board" + Globals.NL +
                    "Ctrl + F3 : Celebrations board" + Globals.NL +
                    "Ctrl + F4 : New moons board" + Globals.NL +
                    "Ctrl + F5 : Lunar months board" + Globals.NL +
                    "Ctrl + Shift + D : Dates difference calculator" + Globals.NL +
                    "Home : First month available in the database" + Globals.NL +
                    "End : Last month available in the database" + Globals.NL +
                    "Up (ou PageUp) : Previous year" + Globals.NL +
                    "Down (ou PageDown) : Next year" + Globals.NL +
                    "Left : Previous month" + Globals.NL +
                    "Right : Next month" + Globals.NL +
                    "Ctrl + Left : Previous month having a celebration" + Globals.NL +
                    "Ctrl + Right : Next month having a celebration" + Globals.NL +
                    "Ctrl + Home : First month having a celebration" + Globals.NL +
                    "Ctrl + End : Last month having a celebration" + Globals.NL +
                    "Shit + Up : Semaine précédente" + Globals.NL +
                    "Shit + Down : Previous week" + Globals.NL +
                    "Shit + Left : Next week" + Globals.NL +
                    "Shit + Right : Next day" + Globals.NL +
                    "Add or Sub : Change active day" + Globals.NL +
                    "Shift + Click : Set active day" + Globals.NL +
                    "Ctrl + Click : Select day" + Globals.NL +
                    "F9 : Preferences" + Globals.NL +
                    "F10 : Log file window" + Globals.NL +
                    "F11 : Usage statistics window" + Globals.NL +
                    "F12 : About" + Globals.NL +
                    "Alt + F4 (ou Escape) : Close window" + Globals.NL +
                    "Ctrl + Alt + F4 : Exit application",

    [Language.FR] = "Ctrl + Tab : Vue suivante" + Globals.NL +
                    "Maj + Ctrl + Tab : Vue précédente" + Globals.NL +
                    "F1 : Vue du rapport textuel" + Globals.NL +
                    "F2 : Vue du mois" + Globals.NL +
                    "F3 : Vue de la grille de données" + Globals.NL +
                    "F4 : Fenêtre des prochaines célébrations" + Globals.NL +
                    "F5 : Fenêtre de recherche de célébration" + Globals.NL +
                    "F6 : Fenêtre de recherche de mois lunaire" + Globals.NL +
                    "F7 : Fenêtre de recherche de mois grégorien" + Globals.NL +
                    "F8 (ou Ctrl + N) : Fenêtre de navigation" + Globals.NL +
                    "Ctrl + T (ou Numpad0) : Aller à aujourd'hui" + Globals.NL +
                    "Ctrl + B (ou Décimal) : Aller au jour sélectionné" + Globals.NL +
                    "Ctrl + D : Chercher un jour" + Globals.NL +
                    "Ctrl + S : Sauvegarde la vue en cours dans un fichier" + Globals.NL +
                    "Ctrl + C : Copie la vue en cours dans le presse-papier" + Globals.NL +
                    "Ctrl + P : Imprime la vue en cours" + Globals.NL +
                    "Ctrl + Maj + C : Copie la sélection du rapport textuel dans le presse-papier" + Globals.NL +
                    "Alt + V : Menu des vues" + Globals.NL +
                    "Alt + T : Menu des outils" + Globals.NL +
                    "Alt + L : Menu des liens web" + Globals.NL +
                    "Alt + I : Menu des informations" + Globals.NL +
                    "Alt + S : Menu des paramètres" + Globals.NL +
                    "Alt + E : Dossier d'export" + Globals.NL +
                    "Alt + C : Calculatrice Windows" + Globals.NL +
                    "Alt + D : Paramètres de date et heure de Windows" + Globals.NL +
                    "Alt + M : Météo Windows" + Globals.NL +
                    "Alt + W : Météo en ligne" + Globals.NL +
                    "Alt + G : Génère le calendrier" + Globals.NL +
                    "Alt + P : Affiche le menu de la parashah en ligne" + Globals.NL +
                    "Ctrl + F1 : Tableau des parashot" + Globals.NL +
                    "Ctrl + F2 : Tableau des versets des célébrations" + Globals.NL +
                    "Ctrl + F3 : Tableau des célébrations" + Globals.NL +
                    "Ctrl + F4 : Tableau des nouvelles lunes" + Globals.NL +
                    "Ctrl + F5 : Tableau des mois lunaires" + Globals.NL +
                    "Ctrl + Maj + D : Calculateur de différence de dates" + Globals.NL +
                    "Début : Premier mois disponible dans la base de données" + Globals.NL +
                    "Fin : Dernier mois disponible dans la base de données" + Globals.NL +
                    "Haut (ou PagePrec) : Année précédente" + Globals.NL +
                    "Bas (ou PageSuiv) : Année suivante" + Globals.NL +
                    "Gauche : Mois précédent" + Globals.NL +
                    "Droite : Mois suivant" + Globals.NL +
                    "Ctrl + Gauche : Mois précédent ayant une célébration" + Globals.NL +
                    "Ctrl + Droite : Mois suivant ayant une célébration" + Globals.NL +
                    "Ctrl + Début : Premier mois ayant une célébration" + Globals.NL +
                    "Ctrl + Fin : Dernier mois ayant une célébration" + Globals.NL +
                    "Maj + Haut : Semaine précédente" + Globals.NL +
                    "Maj + Bas : Semaine suivante" + Globals.NL +
                    "Maj + Gauche : Jour précédent" + Globals.NL +
                    "Maj + Droite : Jour suivant" + Globals.NL +
                    "Plus ou Moins : Changer de jour actif" + Globals.NL +
                    "Maj + Clic : Définir jour actif" + Globals.NL +
                    "Ctrl + Clic : Sélectionner jour" + Globals.NL +
                    "F9 : Préférences" + Globals.NL +
                    "F10 : Fenêtre du fichier log" + Globals.NL +
                    "F11 : Fenêtre des statistiques d'utilisation" + Globals.NL +
                    "F12 : A propos" + Globals.NL +
                    "Alt + F4 (ou Échap) : Ferme la fenêtre" + Globals.NL +
                    "Ctrl + Alt + F4 : Ferme l'application",
  };

}
