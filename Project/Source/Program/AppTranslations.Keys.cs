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
/// <created> 2016-04 </created>
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

    static public readonly TranslationsDictionary NoticeKeyboardShortcutsTitle
      = new TranslationsDictionary
      {
        [Language.EN] = "Keyboard shortcuts notice",
        [Language.FR] = "Notice des raccourcis clavier"
      };

    static public readonly TranslationsDictionary NoticeKeyboardShortcuts
      = new TranslationsDictionary
      {
        [Language.EN] = "F1 : Text report view" + Globals.NL +
                        "F2 : Month view" + Globals.NL +
                        "F3 : Database grid view" + Globals.NL +
                        "F4 : Next celebrations window" + Globals.NL +
                        "F5 : Search a celebration window" + Globals.NL +
                        "F6 : Search a moon month window" + Globals.NL +
                        "F7 : Search a gregorian month window" + Globals.NL +
                        "F8 (or Ctrl + N) : Navigation window" + Globals.NL +
                        "Ctrl + Tab : Next view" + Globals.NL +
                        "Shift + Ctrl + Tab : Previous view" + Globals.NL +
                        "Ctrl + T (or Numpad0) : Go to today" + Globals.NL +
                        "Ctrl + D : Search a day" + Globals.NL +
                        "Ctrl + S : Save current view to file" + Globals.NL +
                        "Ctrl + C : Copy current view to clipboard" + Globals.NL +
                        "Ctrl + P : Print current view" + Globals.NL +
                        "Shift + Ctrl + C : Copy the text report selection to clipboard" + Globals.NL +
                        "Alt + T : Show tools menu" + Globals.NL +
                        "Alt + L : Show web links menu" + Globals.NL +
                        "Alt + V : Show view menu" + Globals.NL +
                        "Alt + S : Show settings menu" + Globals.NL +
                        "Alt + I : Show information menu" + Globals.NL +
                        "Alt + E : Open export folder" + Globals.NL +
                        "Alt + C : Open windows calculator" + Globals.NL +
                        "Alt + D : Open windows date and time settings" + Globals.NL +
                        "Alt + M : Windows weather" + Globals.NL +
                        "Alt + W : Online weather" + Globals.NL +
                        "Alt + G : Generate calendar" + Globals.NL +
                        "Ctrl + F1 : Dates difference calculator" + Globals.NL +
                        "Ctrl + F2 : Celebrations board" + Globals.NL +
                        "Ctrl + F3 : New moons board" + Globals.NL +
                        "Ctrl + F4 : Lunar months board" + Globals.NL +
                        "Ctrl + F5 (or Atl + P) : Parashot board" + Globals.NL +
                        "Home : First month available in the database" + Globals.NL +
                        "End : Last month available in the database" + Globals.NL +
                        "Up (ou PageUp) : Previous year" + Globals.NL +
                        "Down (ou PageDown) : Next year" + Globals.NL +
                        "Left : Previous month" + Globals.NL +
                        "Right : Next month" + Globals.NL +
                        "Ctrl + Left : Previous month having a celebration" + Globals.NL +
                        "Ctrl + Right : Next month having a celebration" + Globals.NL +
                        "Ctrl + Home : First month available in the database having a celebration" + Globals.NL +
                        "Ctrl + End : Last month available in the databasehaving a celebration" + Globals.NL +
                        "F9 : Preferences" + Globals.NL +
                        "F10 : Log file window" + Globals.NL +
                        "F11 : Usage statistics window" + Globals.NL +
                        "F12 : About" + Globals.NL +
                        "Alt + F4 (ou Escape) : Close window" + Globals.NL +
                        "Ctrl + Alt + F4 : Exit application",

        [Language.FR] = "F1 : Vue du rapport textuel" + Globals.NL +
                        "F2 : Vue du mois" + Globals.NL +
                        "F3 : Vue de la grille de données" + Globals.NL +
                        "F4 : Fenêtre des prochaines célébrations" + Globals.NL +
                        "F5 : Fenêtre de recherche de célébration" + Globals.NL +
                        "F6 : Fenêtre de recherche de mois lunaire" + Globals.NL +
                        "F7 : Fenêtre de recherche de mois grégorien" + Globals.NL +
                        "F8 (ou Ctrl + N) : Fenêtre de navigation" + Globals.NL +
                        "Ctrl + Tab : Vue suivante" + Globals.NL +
                        "Maj + Ctrl + Tab : Vue précédente" + Globals.NL +
                        "Ctrl + T (ou Numpad0) : Aller à aujourd'hui" + Globals.NL +
                        "Ctrl + D : Chercher un jour" + Globals.NL +
                        "Ctrl + S : Sauvegarde la vue en cours dans un fichier" + Globals.NL +
                        "Ctrl + C : Copie la vue en cours dans le presse-papier" + Globals.NL +
                        "Ctrl + P : Imprime la vue en cours" + Globals.NL +
                        "Maj + Ctrl + C : Copie la sélection du rapport textuel dans le presse-papier" + Globals.NL +
                        "Alt + T : Montre le menu des outils" + Globals.NL +
                        "Alt + L : Montre le menu des liens web" + Globals.NL +
                        "Alt + V : Montre le menu des vues" + Globals.NL +
                        "Alt + S : Montre le menu des paramètres" + Globals.NL +
                        "Alt + I : Montre le menu des informations" + Globals.NL +
                        "Alt + E : Ouvre le dossier d'export" + Globals.NL +
                        "Alt + C : Ouvre la calculatrice Windows" + Globals.NL +
                        "Alt + D : Ouvre les paramètres de date et heure de Windows" + Globals.NL +
                        "Alt + M : Météo Windows" + Globals.NL +
                        "Alt + W : Météo en ligne" + Globals.NL +
                        "Alt + G : Génèrate le calendrier" + Globals.NL +
                        "Ctrl + F1 : Calculateur de différence de dates" + Globals.NL +
                        "Ctrl + F2 : Tableau des célébrations" + Globals.NL +
                        "Ctrl + F3 : Tableau des nouvelles lunes" + Globals.NL +
                        "Ctrl + F4 : Tableau des mois lunaires" + Globals.NL +
                        "Ctrl + F5 (ou Atl + P) : Tableau des parashot" + Globals.NL +
                        "Début : Premier mois disponible dans la base de données" + Globals.NL +
                        "Fin : Dernier mois disponible dans la base de données" + Globals.NL +
                        "Haut (ou PagePrec) : Année précédente" + Globals.NL +
                        "Bas (ou PageSuiv) : Année suivante" + Globals.NL +
                        "Gauche : Mois précédent" + Globals.NL +
                        "Droite : Mois suivant" + Globals.NL +
                        "Ctrl + Gauche : Mois précédent ayant une célébration" + Globals.NL +
                        "Ctrl + Droite : Mois suivant ayant une célébration" + Globals.NL +
                        "Ctrl + Début : Premier mois disponible dans la base de données ayant une célébration" + Globals.NL +
                        "Ctrl + Fin : Dernier mois disponible dans la base de données ayant une célébration" + Globals.NL +
                        "F9 : Préférences" + Globals.NL +
                        "F10 : Fenêtre du fichier log" + Globals.NL +
                        "F11 : Fenêtre des statistiques d'utilisation" + Globals.NL +
                        "F12 : A propos" + Globals.NL +
                        "Alt + F4 (ou Echap) : Ferme la fenêtre" + Globals.NL +
                        "Ctrl + Alt + F4 : Ferme l'application",
      };

  }

}
