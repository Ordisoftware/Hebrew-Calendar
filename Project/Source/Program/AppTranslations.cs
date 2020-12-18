/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2020 Olivier Rogier.
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
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// Localization strings.
  /// </summary>
  static public partial class AppTranslations
  {

    static public string ToStringExport<T>(this Enum value, NullSafeDictionary<T, TranslationsDictionary> translations) 
      where T : Enum
    {
      return Program.Settings.ExportDataEnumsAsTranslations ? translations.GetLang((T)value) : ( (T)value ).ToString();
    }

    static public readonly TranslationsDictionary ApplicationDescription
      = new TranslationsDictionary
      {
        [Language.EN] = "Generate a hebrew lunisolar calendar with shabat and celebrations reminder",
        [Language.FR] = "Génère un calendrier luni-solaire hébraïque avec rappel du shabat et des célébrations"
      };

    static public readonly TranslationsDictionary AskToResetPreferences
      = new TranslationsDictionary
      {
        [Language.EN] = SysTranslations.ResetPreferences[Language.EN] + Globals.NL2 +
                        "GPS location, shabat day and bookmarks will be keeped." + Globals.NL2 +
                        "The global shortcut will be effective the next application start." + Globals.NL2 +
                        SysTranslations.AskToContinue[Language.EN],

        [Language.FR] = SysTranslations.ResetPreferences[Language.FR] + Globals.NL2 +
                        "La position GPS, le jour du shabat et les signets seront conservés." + Globals.NL2 +
                        "Le raccourci global sera effectif au prochain démarrage de l'application." + Globals.NL2 +
                        SysTranslations.AskToContinue[Language.FR]
      };

    static public readonly TranslationsDictionary LoadingCitiesError
      = new TranslationsDictionary
      {
        [Language.EN] = "Error on loading the cities' GPS coordonates." + Globals.NL +
                        SysTranslations.ApplicationMustExit[Language.EN],

        [Language.FR] = "Impossible de charger les coordonnées GPS des villes." + Globals.NL +
                        SysTranslations.ApplicationMustExit[Language.EN]
      };

    static public readonly TranslationsDictionary ProgressCreateDays
      = new TranslationsDictionary
      {
        [Language.EN] = "Populating days...",
        [Language.FR] = "Garnissage des jours..."
      };

    static public readonly TranslationsDictionary ProgressAnalyzeDays
      = new TranslationsDictionary
      {
        [Language.EN] = "Analyzing days...",
        [Language.FR] = "Analyse des jours..."
      };

    static public readonly TranslationsDictionary ProgressGenerateReport
      = new TranslationsDictionary
      {
        [Language.EN] = "Generating report...",
        [Language.FR] = "Génération du rapport..."
      };

    static public readonly TranslationsDictionary ProgressFillMonths
      = new TranslationsDictionary
      {
        [Language.EN] = "Filling months...",
        [Language.FR] = "Remplissage des mois..."
      };

    static public readonly TranslationsDictionary AskToUseMoonOmer
      = new TranslationsDictionary
      {
        [Language.EN] = "Do you want to use the moon omer, else the sun?",
        [Language.FR] = "Voulez-vous utiliser le omer de la lune, sinon du soleil ?"
      };

    static public readonly TranslationsDictionary AskToSetupPersonalShabat
      = new TranslationsDictionary
      {
        [Language.EN] = "Do you want to setup the personal shabat?",
        [Language.FR] = "Voulez-vous configurer le shabat personnel ?"
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

    static public readonly TranslationsDictionary ViewPrinted
      = new TranslationsDictionary
      {
        [Language.EN] = "The view has been printed.",
        [Language.FR] = "La vue a été imprimée."
      };

    static public readonly TranslationsDictionary DateNotFound
      = new TranslationsDictionary
      {
        [Language.EN] = "Date not found in the database: {0}",
        [Language.FR] = "Date non trouvée dans la base de données : {0}"
      };

    static public readonly TranslationsDictionary SelectBirthday
      = new TranslationsDictionary
      {
        [Language.EN] = "Birth day",
        [Language.FR] = "Jour de naissance"
      };

    static public readonly TranslationsDictionary OmerMoon
      = new TranslationsDictionary
      {
        [Language.EN] = "Count the days according to the moon",
        [Language.FR] = "Compte des jours selon la lune",
      };

    static public readonly TranslationsDictionary OmerSun
      = new TranslationsDictionary
      {
        [Language.EN] = "Count the days according to the sun",
        [Language.FR] = "Compte des jours selon le soleil",
      };

    static public readonly TranslationsDictionary Year
      = new TranslationsDictionary
      {
        [Language.EN] = "Year",
        [Language.FR] = "Année"
      };

    static public readonly TranslationsDictionary FirstDay
      = new TranslationsDictionary
      {
        [Language.EN] = "First day",
        [Language.FR] = "Premier jour"
      };

    static public readonly TranslationsDictionary LastDay
      = new TranslationsDictionary
      {
        [Language.EN] = "Last day",
        [Language.FR] = "Dernier jour"
      };

    static public readonly TranslationsDictionary NotSupportedYear
      = new TranslationsDictionary
      {
        [Language.EN] = "Year is not supported: {0}",
        [Language.FR] = "L'année n'est pas supportée : {0}"
      };

    static public readonly TranslationsDictionary PredefinedYearsIntervalAfter
      = new TranslationsDictionary
      {
        [Language.EN] = "{0} years from now",
        [Language.FR] = "{0} années à partir de maintenant"
      };

    static public readonly TranslationsDictionary PredefinedYearsIntervalBeforeAndAfter
      = new TranslationsDictionary
      {
        [Language.EN] = "{0} years before and after from now",
        [Language.FR] = "{0} années avant et après maintenant"
      };

    static public readonly TranslationsDictionary SoundTooLong
      = new TranslationsDictionary
      {
        [Language.EN] = "Duration must be less than {0} seconds: {1}.",
        [Language.FR] = "La durée doit être inférieure à {0} secondes: {1}."
      };

  }

}