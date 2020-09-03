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
/// <edited> 2020-08 </edited>
using System;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Localization strings.
  /// </summary>
  static public partial class Translations
  {

    static public readonly NullSafeOfStringDictionary<Language> ApplicationDescription
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Generate a hebrew lunisolar calendar with shabat and celebrations reminder",
        [Languages.FR] = "Génère un calendrier luni-solaire hébraïque avec rappel du shabat et des célébrations"
      };

    static public readonly NullSafeOfStringDictionary<Language> AskToResetPreferences
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = Localizer.ResetPreferences[Languages.EN] + Globals.NL2 +
                         "GPS location and shabat day will be keeped." + Globals.NL2 +
                         Localizer.AskToContinue[Languages.EN],

        [Languages.FR] = Localizer.ResetPreferences[Languages.FR] + Globals.NL2 +
                         "La position GPS et le jour du shabat seront conservés." + Globals.NL2 +
                         Localizer.AskToContinue[Languages.FR]
      };

    static public readonly NullSafeOfStringDictionary<Language> CantExitWhileGenerating
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Can't exit application while generating data.",

        [Languages.FR] = "Impossible de quitter l'application durant la génération des données."
      };

    static public readonly NullSafeOfStringDictionary<Language> LoadingCitiesError
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Error on loading the cities' GPS coordonates." + Globals.NL +
                         Localizer.ApplicationMustExit[Languages.EN],

        [Languages.FR] = "Impossible de charger les coordonnées GPS des villes." + Globals.NL +
                         Localizer.ApplicationMustExit[Languages.EN]
      };

    static public readonly NullSafeOfStringDictionary<Language> ProgressLoadingData
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Loading data...",
        [Languages.FR] = "Chargement des données..."
      };

    static public readonly NullSafeOfStringDictionary<Language> ProgressCreateDays
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Populating days...",
        [Languages.FR] = "Garnissage des jours..."
      };

    static public readonly NullSafeOfStringDictionary<Language> ProgressAnalyzeDays
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Analyzing days...",
        [Languages.FR] = "Analyse des jours..."
      };

    static public readonly NullSafeOfStringDictionary<Language> ProgressGenerateReport
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Generating report...",
        [Languages.FR] = "Génération du rapport..."
      };

    static public readonly NullSafeOfStringDictionary<Language> ProgressFillMonths
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Filling months...",
        [Languages.FR] = "Remplissage des mois..."
      };

    static public readonly NullSafeOfStringDictionary<Language> AskToUseMoonOmer
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Do you want to use the moon omer, else the sun?",
        [Languages.FR] = "Voulez-vous utiliser le omer de la lune, sinon du soleil ?"
      };

    static public readonly NullSafeOfStringDictionary<Language> AskToSetupPersonalShabat
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Do you want to setup the personal shabat?",
        [Languages.FR] = "Voulez-vous configurer le shabat personnel ?"
      };

    static public readonly NullSafeOfStringDictionary<Language> DateNotFound
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Date not found in the database: {0}",
        [Languages.FR] = "Date non trouvée dans la base de données : {0}"
      };

    static public readonly NullSafeOfStringDictionary<Language> SelectBirthday
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Birth day",
        [Languages.FR] = "Jour de naissance"
      };

    static public readonly NullSafeOfStringDictionary<Language> FirstDay
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "First day",
        [Languages.FR] = "Premier jour"
      };

    static public readonly NullSafeOfStringDictionary<Language> LastDay
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Last day",
        [Languages.FR] = "Dernier jour"
      };

    static public readonly NullSafeOfStringDictionary<Language> NotSupportedYear
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Year is not supported: {0}",
        [Languages.FR] = "L'année n'est pas supportée : {0}"
      };

    static public readonly NullSafeOfStringDictionary<Language> PredefinedYearsIntervalAfter
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "{0} years from now",
        [Languages.FR] = "{0} années à partir de maintenant"
      };

    static public readonly NullSafeOfStringDictionary<Language> PredefinedYearsIntervalBeforeAndAfter
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "{0} years before and after from now",
        [Languages.FR] = "{0} années avant et après maintenant"
      };

    static public readonly NullSafeOfStringDictionary<Language> FatalGenerateError
      = new NullSafeOfStringDictionary<Language>
      {
        [Languages.EN] = "Fatal error while generating data." + Globals.NL +
                         Localizer.ApplicationMustExit[Languages.EN] + Globals.NL +
                         Localizer.ContactSupport[Languages.EN] + Globals.NL2 +
                         "{0}",

        [Languages.FR] = "Erreur fatale lors de la génération des données." + Globals.NL +
                         Localizer.ApplicationMustExit[Languages.FR] + Globals.NL +
                         Localizer.ContactSupport[Languages.FR] + Globals.NL2 +
                         "{0}"
      };

  }

}