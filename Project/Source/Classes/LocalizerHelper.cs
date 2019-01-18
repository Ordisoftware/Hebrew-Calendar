/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// Project is registered at Depotnumerique.com (Agence des Depots Numeriques).
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2016-04 </created>
/// <edited> 2019-01 </edited>
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Provide localization.
  /// </summary>
  static public class Localizer
  {

    /// <summary>
    /// Get the string translation.
    /// </summary>
    /// <param name="values">The dictionary containing langs>translations.</param>
    /// <returns></returns>
    static public string GetLang(this Dictionary<string, string> values)
    {
      string lang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
      if ( !values.ContainsKey(lang) ) lang = "en";
      return values[lang];
    }

    /// <summary>
    /// Get the string translation of an enum value.
    /// </summary>
    /// <typeparam name="T">The type that is an enum.</typeparam>
    /// <param name="values">The dictionary containing values>langs>translations.</param>
    /// <param name="value">The value to translate.</param>
    /// <returns></returns>
    static public string GetLang<T>(this Dictionary<T, Dictionary<string, string>> values, T value)
    {
      string lang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
      if ( !values[value].ContainsKey(lang) ) lang = "en";
      return values[value][lang];
    }

    static public readonly Dictionary<DayOfWeek, Dictionary<string, string>> DayOfWeekText
      = new Dictionary<DayOfWeek, Dictionary<string, string>>()
      {
        {
          DayOfWeek.Monday, new Dictionary<string, string>
          {
            { "en", "Monday" },
            { "fr", "Lundi" }
          }
        },
        {
          DayOfWeek.Tuesday, new Dictionary<string, string>
          {
            { "en", "Tuesday" },
            { "fr", "Mardi" }
          }
        },
        {
          DayOfWeek.Wednesday, new Dictionary<string, string>
          {
            { "en", "Wednesday" },
            { "fr", "Mercredi" }
          }
        },
        {
          DayOfWeek.Thursday, new Dictionary<string, string>
          {
            { "en", "Thursday" },
            { "fr", "Jeudi" }
          }
        },
        {
          DayOfWeek.Friday, new Dictionary<string, string>
          {
            { "en", "Friday" },
            { "fr", "Vendredi" }
          }
        },
        {
          DayOfWeek.Saturday, new Dictionary<string, string>
          {
            { "en", "Saturday" },
            { "fr", "Samedi" }
          }
        },
        {
          DayOfWeek.Sunday, new Dictionary<string, string>
          {
            { "en", "Sunday" },
            { "fr", "Dimanche" }
          }
        }
      };

    static public readonly Dictionary<bool, Dictionary<string, string>> HideRestoreText
      = new Dictionary<bool, Dictionary<string, string>>()
      {
        {
          true, new Dictionary<string, string>
          {
            { "en", "Hide" },
            { "fr", "Cacher" }
          }
        },
        {
          false, new Dictionary<string, string>
          {
            { "en", "Restore" },
            { "fr", "Restaurer" }
          }
        }
      };

    static public readonly Dictionary<string, string> ApplicationDescriptionText
      = new Dictionary<string, string>()
      {
        { "en", "A tool to generate a hebrew lunisolar calendar" },
        { "fr", "Un outil pour générer un calendrier luni-solaire hébraïque" }
      };

    static public readonly Dictionary<string, string> ExitApplicationText
      = new Dictionary<string, string>()
      {
        { "en", "Exit application?" },
        { "fr", "Quitter l'application ?" }
      };

    static public readonly Dictionary<string, string> SelectBirthdayText
      = new Dictionary<string, string>()
      {
        { "en", "Select birthday" },
        { "fr", "Date de naissance" }
      };

    static public readonly Dictionary<string, string> CantExitApplicationWhileGeneratingText
      = new Dictionary<string, string>()
      {
        { "en", "Can't close while generating." },
        { "fr", "Impossibme de quitter durant la génération." }
      };

    static public readonly Dictionary<string, string> GenerateCalendarText
      = new Dictionary<string, string>()
      {
        { "en", "Database is empty." + Environment.NewLine + Environment.NewLine +
                "Do you want to generate a calendar?" },
        { "fr", "La base de données est vide." + Environment.NewLine + Environment.NewLine +
                "Voulez-vous générer un calendrier ?" }
      };

    static public readonly Dictionary<string, string> StopGenerationText
      = new Dictionary<string, string>()
      {
        { "en", "Do you want to stop the generation process?" },
        { "fr", "Voulez-vous arrêter le processus de génération ?" }
      };

    static public readonly Dictionary<string, string> LoadingDataText
      = new Dictionary<string, string>()
      {
        { "en", "Loading data..." },
        { "fr", "Chargement des données..." }
      };

    static public readonly Dictionary<string, string> ProgressCreateDaysText
      = new Dictionary<string, string>()
      {
        { "en", "Populating days..." },
        { "fr", "Garnissage des jours..." }
      };

    static public readonly Dictionary<string, string> ProgressAnalyzeDaysText
      = new Dictionary<string, string>()
      {
        { "en", "Analyzing days..." },
        { "fr", "Analyse des jours..." }
      };

    static public readonly Dictionary<string, string> ProgressGenerateReportText
      = new Dictionary<string, string>()
      {
        { "en", "Generating report..." },
        { "fr", "Génération du rapport..." }
      };

    static public readonly Dictionary<string, string> RestoreWinPosText
      = new Dictionary<string, string>()
      {
        { "en", "This action will restore windows position." + Environment.NewLine + Environment.NewLine +
                "Are you sure you want to do this?" },
        { "fr", "Cette action va restaurer la position de la fenêtre"  + Environment.NewLine + Environment.NewLine +
                "Etes vous sûr de vouloir faire cela ?" }
      };

    static public readonly Dictionary<string, string> RegenerateCalendarText
      = new Dictionary<string, string>()
      {
        { "en", "Preferences changed." + Environment.NewLine + Environment.NewLine +
                "Do you want to generate the calendrier?" },
        { "fr", "Préférences changées." + Environment.NewLine + Environment.NewLine +
                "Voulez-vous générer le calendrier ?" }
      };

    static public readonly Dictionary<string, string> ReplaceCalendarText
      = new Dictionary<string, string>()
      {
        { "en", "The new calendar will replace the old." + Environment.NewLine + Environment.NewLine +
                "Do you want to continue?" },
        { "fr", "Le nouveau calendrier va remplacer l'ancien." + Environment.NewLine + Environment.NewLine +
                "Voulez-vous continuer ?" }
      };

  }

}
