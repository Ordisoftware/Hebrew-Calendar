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
/// <edited> 2021-12 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Localization strings.
/// </summary>
static partial class AppTranslations
{

  static public string ToStringExport<T>(this Enum value, NullSafeDictionary<T, TranslationsDictionary> translations,
                                         bool forceEnglish = false)
  where T : Enum
  {
    return Program.Settings.ExportDataEnumsAsTranslations
           ? translations.GetLang((T)value, forceEnglish)
           : ( (T)value ).ToString();
  }

  static public readonly TranslationsDictionary ApplicationDescription = new()
  {
    [Language.EN] = "Hebrew lunisolar calendar generator with Shabat and celebrations reminder",
    [Language.FR] = "Générateur de calendrier luni-solaire hébraïque avec rappel du Shabat et des célébrations"
  };

  static public readonly TranslationsDictionary Subtitle = new()
  {
    [Language.EN] = "LUNISOLAR CALENDAR",
    [Language.FR] = "CALENDRIER LUNISOLAIRE"
  };

  static public readonly NullSafeDictionary<bool, TranslationsDictionary> MainFormSubTitleOmer = new()
  {
    [true] = new TranslationsDictionary
    {
      [Language.EN] = "Moon Omer",
      [Language.FR] = "Omer de la Lune"
    },
    [false] = new TranslationsDictionary
    {
      [Language.EN] = "Sun Omer",
      [Language.FR] = "Omer du Soleil"
    }
  };

  static public readonly TranslationsDictionary MainFormSubTitleSod = new()
  {
    [Language.EN] = "Sod Ha'ibur Omer",
    [Language.FR] = "Omer du Sod Ha'ibour"
  };

  static public readonly TranslationsDictionary AskToResetPreferences = new()
  {
    [Language.EN] = SysTranslations.ResetPreferences[Language.EN] + Globals.NL2 +
                    "GPS location, Shabat day and bookmarks will be kept." + Globals.NL2 +
                    SysTranslations.AskToContinue[Language.EN],

    [Language.FR] = SysTranslations.ResetPreferences[Language.FR] + Globals.NL2 +
                    "La position GPS, le jour du Shabat et les signets seront conservés." + Globals.NL2 +
                    SysTranslations.AskToContinue[Language.FR]
  };

  static public readonly TranslationsDictionary LoadingCitiesError = new()
  {
    [Language.EN] = "Error on loading the cities' GPS coordinates." + Globals.NL +
                    SysTranslations.ApplicationMustExit[Language.EN],

    [Language.FR] = "Impossible de charger les coordonnées GPS des villes." + Globals.NL +
                    SysTranslations.ApplicationMustExit[Language.EN]
  };

  static public readonly TranslationsDictionary ProgressCreateDays = new()
  {
    [Language.EN] = "Populating days...",
    [Language.FR] = "Garnissage des jours..."
  };

  static public readonly TranslationsDictionary ProgressAnalyzeDays = new()
  {
    [Language.EN] = "Analyzing days...",
    [Language.FR] = "Analyse des jours..."
  };

  static public readonly TranslationsDictionary ProgressGenerateReport = new()
  {
    [Language.EN] = "Generating report...",
    [Language.FR] = "Génération du rapport..."
  };

  static public readonly TranslationsDictionary ProgressFillMonths = new()
  {
    [Language.EN] = "Filling months...",
    [Language.FR] = "Remplissage des mois..."
  };

  static public readonly TranslationsDictionary AskToUseMoonOmer = new()
  {
    [Language.EN] = "Do you want to use the moon omer, else the sun?",
    [Language.FR] = "Voulez-vous utiliser le omer de la lune, sinon du soleil ?"
  };

  static public readonly TranslationsDictionary AskToSetupPersonalShabat = new()
  {
    [Language.EN] = "Do you want to setup the personal Shabat?",
    [Language.FR] = "Voulez-vous configurer le Shabat personnel ?"
  };

  static public readonly TranslationsDictionary AskToUseLastDayOfSukotForSimhatTorah = new()
  {
    [Language.EN] = "Do you want to use the last day of Sukot for Sim'hat Torah, otherwise outside?",
    [Language.FR] = "Voulez-vous utiliser le dernier jour de Soukot pour Sim'hat Torah, sinon en dehors ?"
  };

  static public readonly TranslationsDictionary WorldCitiesUpdated = new()
  {
    [Language.EN] = $"The World Cities Database has been updated.{Globals.NL2}Please re-validate the city.",
    [Language.FR] = $"La base de données des villes du monde a été mise à jour.{Globals.NL2}Veuillez à nouveau valider la ville."
  };

  static public readonly TranslationsDictionary DateNotFound = new()
  {
    [Language.EN] = "Date not found in the database: {0}",
    [Language.FR] = "Date non trouvée dans la base de données : {0}"
  };

  static public readonly TranslationsDictionary SelectBirthday = new()
  {
    [Language.EN] = "Birth day",
    [Language.FR] = "Jour de naissance"
  };

  static public readonly TranslationsDictionary OmerMoon = new()
  {
    [Language.EN] = "Count the days according to the moon",
    [Language.FR] = "Compte des jours selon la lune",
  };

  static public readonly TranslationsDictionary OmerSun = new()
  {
    [Language.EN] = "Count the days according to the sun",
    [Language.FR] = "Compte des jours selon le soleil",
  };

  static public readonly TranslationsDictionary Year = new()
  {
    [Language.EN] = "Year",
    [Language.FR] = "Année"
  };

  static public readonly TranslationsDictionary FirstDay = new()
  {
    [Language.EN] = "First day",
    [Language.FR] = "Premier jour"
  };

  static public readonly TranslationsDictionary LastDay = new()
  {
    [Language.EN] = "Last day",
    [Language.FR] = "Dernier jour"
  };

  static public readonly TranslationsDictionary NotSupportedYear = new()
  {
    [Language.EN] = "Year is not supported: {0}",
    [Language.FR] = "L'année n'est pas supportée : {0}"
  };

  static public readonly TranslationsDictionary PredefinedYearsIntervalAfter = new()
  {
    [Language.EN] = "{0} years from now",
    [Language.FR] = "{0} années à partir de maintenant"
  };

  static public readonly TranslationsDictionary PredefinedYearsIntervalBeforeAndAfter = new()
  {
    [Language.EN] = "{0} years before and after from now",
    [Language.FR] = "{0} années avant et après maintenant"
  };

  static public readonly TranslationsDictionary SoundTooLong = new()
  {
    [Language.EN] = "Duration must be less than {0} seconds: {1}.",
    [Language.FR] = "La durée doit être inférieure à {0} secondes: {1}."
  };

  static public readonly TranslationsDictionary OnlineWeatherError = new()
  {
    [Language.EN] = $"Error on getting data from {{0}}:{Globals.NL2}{{1}}",
    [Language.FR] = $"Erreur lors de la récupération des données depuis {{0}} :{Globals.NL2}{{1}}"
  };

  static public readonly TranslationsDictionary OnlineWeatherLocationNotFound = new()
  {
    [Language.EN] = "Coordinates not found.",
    [Language.FR] = "Coordonnées non trouvées."
  };

  static public readonly NullSafeDictionary<bool, TranslationsDictionary> BoardTimingsTitle = new()
  {
    {
      true,
      new TranslationsDictionary
      {
        [Language.EN] = "Days having the set",
        [Language.FR] = "Jours ayant le coucher"
      }
    },
    {
      false,
      new TranslationsDictionary
      {
        [Language.EN] = "Days having the rise",
        [Language.FR] = "Jours ayant le lever"
      }
    }
  };

  static public readonly NullSafeDictionary<bool, TranslationsDictionary> SetAllParashahOptions = new()
  {
    {
      true,
      new TranslationsDictionary
      {
        [Language.EN] = "Do you want to enable all parashah options?",
        [Language.FR] = "Voulez-vous activer toutes les options de parashah ?"
      }
    },
    {
      false,
      new TranslationsDictionary
      {
        [Language.EN] = "Do you want to disable all parashah options?",
        [Language.FR] = "Voulez-vous désactiver toutes les options de parashah ?"
      }
    }
  };

}
