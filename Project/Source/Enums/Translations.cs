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
/// <edited> 2020-04 </edited>
using System;
using System.Collections.Generic;

namespace Ordisoftware.HebrewCalendar
{

  static public class Translations
  {

    static public readonly string NewLine = Environment.NewLine;

    static public readonly Dictionary<string, string> AboutBoxTitle
      = new Dictionary<string, string>()
      {
        { "en", "About {0}" },
        { "fr", "À propos de {0}" }
      };

    static public readonly Dictionary<string, string> AboutBoxVersion
      = new Dictionary<string, string>()
      {
        { "en", "Version {0}" },
        { "fr", "Version {0}" }
      };

    static public readonly Dictionary<string, string> ApplicationDescription
      = new Dictionary<string, string>()
      {
        { "en", "Generate a hebrew lunisolar calendar with shabat and celebrations reminder" },
        { "fr", "Génère un calendrier luni-solaire hébraïque avec rappel du shabat et des célébrations" }
      };

    static public readonly Dictionary<string, string> ExitApplication
      = new Dictionary<string, string>()
      {
        { "en", "Exit application?" },
        { "fr", "Quitter l'application ?" }
      };

    static public readonly Dictionary<string, string> ShutdownComputer
      = new Dictionary<string, string>()
      {
        { "en", "Shutdown the computer?" },
        { "fr", "Arrêter l'ordinateur ?" }
      };

    static public readonly Dictionary<string, string> LockSessionError
      = new Dictionary<string, string>()
      {
        { "en", "Shutdown the computer?" },
        { "fr", "Arrêter l'ordinateur ?" }
      };

    static public readonly Dictionary<string, string> CantExitApplicationWhileGenerating
      = new Dictionary<string, string>()
      {
        { "en", "Lock Session Error: {0}" },
        { "fr", "Erreur de verrouillage de session : {0}" }
      };

    static public readonly Dictionary<string, string> NoNewVersionAvailable
      = new Dictionary<string, string>()
      {
        { "en", "There is no new version available." },
        { "fr", "Il n'y a pas de nouvelle version de disponible." }
      };

    static public readonly Dictionary<string, string> NewVersionAvailable
      = new Dictionary<string, string>()
      {
        { "en", "A newer version is available : {0}" },
        { "fr", "Une nouvelle version est disponible : {0}" }
      };

    static public readonly Dictionary<string, string> AskDownloadNewVersion
      = new Dictionary<string, string>()
      {
        { "en", "Do you want to open the download page?" },
        { "fr", "Voulez-vous ouvrir la page de téléchargement ?" }
      };

    static public readonly Dictionary<string, string> DateNotFound
      = new Dictionary<string, string>()
      {
        { "en", "Date not found in the database: {0}" },
        { "fr", "Date non trouvée dans la base de données : {0}" }
      };

    static public readonly Dictionary<string, string> LoadingData
      = new Dictionary<string, string>()
      {
        { "en", "Loading data..." },
        { "fr", "Chargement des données..." }
      };

    static public readonly Dictionary<string, string> ProgressCreateDays
      = new Dictionary<string, string>()
      {
        { "en", "Populating days..." },
        { "fr", "Garnissage des jours..." }
      };

    static public readonly Dictionary<string, string> ProgressAnalyzeDays
      = new Dictionary<string, string>()
      {
        { "en", "Analyzing days..." },
        { "fr", "Analyse des jours..." }
      };

    static public readonly Dictionary<string, string> ProgressGenerateReport
      = new Dictionary<string, string>()
      {
        { "en", "Generating report..." },
        { "fr", "Génération du rapport..." }
      };

    static public readonly Dictionary<string, string> ProgressFillMonths
      = new Dictionary<string, string>()
      {
        { "en", "Filling months..." },
        { "fr", "Remplissage des mois..." }
      };

    static public readonly Dictionary<string, string> SelectBirthday
      = new Dictionary<string, string>()
      {
        { "en", "Birth day" },
        { "fr", "Date de naissance" }
      };

    static public readonly Dictionary<string, string> DiffDatesFirst
      = new Dictionary<string, string>()
      {
        { "en", "First day" },
        { "fr", "Premièr jour" }
      };

    static public readonly Dictionary<string, string> DiffDatesLast
      = new Dictionary<string, string>()
      {
        { "en", "Last day" },
        { "fr", "Dernier jour" }
      };

    static public readonly Dictionary<string, string> DiffDatesSolarCount
      = new Dictionary<string, string>()
      {
        { "en", "Solar days count: {0}" },
        { "fr", "Nombre de jours solaires : {0}" }
      };

    static public readonly Dictionary<string, string> DiffDatesMoonCount
      = new Dictionary<string, string>()
      {
        { "en", "Moon days count: {0}" },
        { "fr", "Nombre de jours lunaires : {0}" }
      };

    static public readonly Dictionary<string, string> DiffDatesMoonOutOfRange
      = new Dictionary<string, string>()
      {
        { "en", "Moon days count: out of range ({0} - {1})" },
        { "fr", "Nombre de jours lunaires : hors limites ({0} - {1})" }
      };

    static public readonly Dictionary<string, string> BigCalendar
      = new Dictionary<string, string>()
      {
        { "en", "Generate a calendar for more than {0} years" + NewLine +
                "is not recommanded." + NewLine + NewLine +
                "Do you want to continue?" },
        { "fr", "Générer un calendrier pour plus de {0} ans" + NewLine +
                "n'est pas recommandé." + NewLine + NewLine +
                "Voulez-vous continuer ?" }
      };

    static public readonly Dictionary<string, string> RestoreWinPos
      = new Dictionary<string, string>()
      {
        { "en", "This action will restore windows position." + NewLine + NewLine +
                "Do you want to continue?" },
        { "fr", "Cette action va restaurer la position de la fenêtre."  + NewLine + NewLine +
                "Voulez-vous continuer ?" }
      };

    static public readonly Dictionary<string, string> ResetPreferences
      = new Dictionary<string, string>()
      {
        { "en", "Preferences will be reseted to their default values." + NewLine +
                "GPS location and shabat day will be keeped." + NewLine + NewLine +
                "Do you want to continue?" },
        { "fr", "Les préférences vont être réinitialisées à leurs valeurs par défaut." + NewLine +
                "La position GPS et le jour du shabat seront conservés." + NewLine + NewLine +
                "Voulez-vous continuer ?" }
      };

    static public readonly Dictionary<string, string> HebrewLettersNotFound
      = new Dictionary<string, string>()
      {
        { "en", "Hebrew Letters not found." + NewLine +
                "Check preferences." + NewLine + NewLine +
                "Do you want to download it?" },
        { "fr", "Hebrew Letters n'a pas été trouvé." + NewLine +
                "Vérifiez les préférences." + NewLine + NewLine +
                "Voulez-vous le télécharger ?" }
      };

    static public readonly Dictionary<string, string> AskToSetupPersonalShabat
      = new Dictionary<string, string>()
      {
        { "en", "Do you want to setup the personal shabat?" },
        { "fr", "Voulez-vous configurer le shabat personnel ?" }
      };

    static public readonly Dictionary<bool, Dictionary<string, string>> HideRestore
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

    static public readonly Dictionary<string, string> Today
      = new Dictionary<string, string>()
      {
        { "en", "Today" },
        { "fr", "Aujourd'hui" }
      };

    static public readonly Dictionary<string, string> NavigationDay
      = new Dictionary<string, string>()
      {
        { "en", "Day #" },
        { "fr", "Jour #" }
      };

    static public readonly Dictionary<DayOfWeek, Dictionary<string, string>> DayOfWeek
      = new Dictionary<DayOfWeek, Dictionary<string, string>>()
      {
        {
          System.DayOfWeek.Monday, new Dictionary<string, string>
          {
            { "en", "Monday" },
            { "fr", "Lundi" }
          }
        },
        {
          System.DayOfWeek.Tuesday, new Dictionary<string, string>
          {
            { "en", "Tuesday" },
            { "fr", "Mardi" }
          }
        },
        {
          System.DayOfWeek.Wednesday, new Dictionary<string, string>
          {
            { "en", "Wednesday" },
            { "fr", "Mercredi" }
          }
        },
        {
          System.DayOfWeek.Thursday, new Dictionary<string, string>
          {
            { "en", "Thursday" },
            { "fr", "Jeudi" }
          }
        },
        {
          System.DayOfWeek.Friday, new Dictionary<string, string>
          {
            { "en", "Friday" },
            { "fr", "Vendredi" }
          }
        },
        {
          System.DayOfWeek.Saturday, new Dictionary<string, string>
          {
            { "en", "Saturday" },
            { "fr", "Samedi" }
          }
        },
        {
          System.DayOfWeek.Sunday, new Dictionary<string, string>
          {
            { "en", "Sunday" },
            { "fr", "Dimanche" }
          }
        }
      };

    static public readonly Dictionary<MoonPhaseType, Dictionary<string, string>> MoonPhase
      = new Dictionary<MoonPhaseType, Dictionary<string, string>>()
      {
        {
          MoonPhaseType.New, new Dictionary<string, string>
          {
            { "en", "New moon" },
            { "fr", "Nouvelle lune" }
          }
        },
        {
          MoonPhaseType.WaxingCrescent, new Dictionary<string, string>
          {
            { "en", "Waxing crescent" },
            { "fr", "Premier croissant" }
          }
        },
        {
          MoonPhaseType.FirstQuarter, new Dictionary<string, string>
          {
            { "en", "First quarter" },
            { "fr", "Premier quartier" }
          }
        },
        {
          MoonPhaseType.WaxingGibbous, new Dictionary<string, string>
          {
            { "en", "Waxing gibbous" },
            { "fr", "Gibbeuse croissante" }
          }
        },
        {
          MoonPhaseType.Full, new Dictionary<string, string>
          {
            { "en", "Full moon" },
            { "fr", "Pleine lune" }
          }
        },
        {
          MoonPhaseType.WaningGibbous, new Dictionary<string, string>
          {
            { "en", "Waning gibbous" },
            { "fr", "Gibbeuse décroissante" }
          }
        },
        {
          MoonPhaseType.LastQuarter, new Dictionary<string, string>
          {
            { "en", "Last quarter" },
            { "fr", "Dernier quartier" }
          }
        },
        {
          MoonPhaseType.WaningCrescent, new Dictionary<string, string>
          {
            { "en", "Waning crescent" },
            { "fr", "Dernier croissant" }
          }
        }
      };

    static public readonly Dictionary<EphemerisType, Dictionary<string, string>> Ephemeris
      = new Dictionary<EphemerisType, Dictionary<string, string>>()
      {
        {
          EphemerisType.Rise, new Dictionary<string, string>
          {
            { "en", "R: " },
            { "fr", "L: " }
          }
        },
        {
          EphemerisType.Set, new Dictionary<string, string>
          {
            { "en", "S: " },
            { "fr", "C: " }
          }
        },
        {
          EphemerisType.SummerHour, new Dictionary<string, string>
          {
            { "en", "(S)" },
            { "fr", "(E)" }
          }
        },
        {
          EphemerisType.WinterHour, new Dictionary<string, string>
          {
            { "en", "(W)" },
            { "fr", "(H)" }
          }
        }
      };

    static public readonly Dictionary<ReportField, Dictionary<string, string>> CalendarField
      = new Dictionary<ReportField, Dictionary<string, string>>()
      {
        {
          ReportField.Date, new Dictionary<string, string>
          {
            { "en", "Date" },
            { "fr", "Date" }
          }
        },
        {
          ReportField.Month, new Dictionary<string, string>
          {
            { "en", "Month" },
            { "fr", "Mois" }
          }
        },
        {
          ReportField.Sun, new Dictionary<string, string>
          {
            { "en", "Sun" },
            { "fr", "Soleil" }
          }
        },
        {
          ReportField.Moon, new Dictionary<string, string>
          {
            { "en", "Moon" },
            { "fr", "Lune" }
          }
        },
        {
          ReportField.Events, new Dictionary<string, string>
          {
            { "en", "Events" },
            { "fr", "Évènements" }
          }
        }
      };

    static public readonly Dictionary<SeasonChange, Dictionary<string, string>> SeasonEvent
      = new Dictionary<SeasonChange, Dictionary<string, string>>()
      {
        {
          SeasonChange.None, new Dictionary<string, string>
          {
            { "en", "" },
            { "fr", "" }
          }
        },
        {
          SeasonChange.SpringEquinox, new Dictionary<string, string>
          {
            { "en", "Spring equinox" },
            { "fr", "Equinoxe de printemps" }
          }
        },
        {
          SeasonChange.SummerSolstice, new Dictionary<string, string>
          {
            { "en", "Summer solstice" },
            { "fr", "Solstice d'été" }
          }
        },
        {
          SeasonChange.AutumnEquinox, new Dictionary<string, string>
          {
            { "en", "Autumn equinox" },
            { "fr", "Equinoxe d'automne" }
          }
        },
        {
          SeasonChange.WinterSolstice, new Dictionary<string, string>
          {
            { "en", "Winter solstice" },
            { "fr", "Solstice d'hiver" }
          }
        }
      };

    static public readonly Dictionary<TorahEvent, Dictionary<string, string>> TorahEvent
      = new Dictionary<TorahEvent, Dictionary<string, string>>()
      {
        {
          HebrewCalendar.TorahEvent.None, new Dictionary<string, string>
          {
            { "en", "" },
            { "fr", "" }
          }
        },
        {
          HebrewCalendar.TorahEvent.NewYearD1, new Dictionary<string, string>
          {
            { "en", "New year" },
            { "fr", "Début de l'année" }
          }
        },
        {
          HebrewCalendar.TorahEvent.NewYearD10, new Dictionary<string, string>
          {
            { "en", "Set aside lamb" },
            { "fr", "Réserver agneau" }
          }
        },
        {
          HebrewCalendar.TorahEvent.PessahD1, new Dictionary<string, string>
          {
            { "en", "Pessa'h start" },
            { "fr", "Début de Pessah" }
          }
        },
        {
          HebrewCalendar.TorahEvent.PessahD7, new Dictionary<string, string>
          {
            { "en", "Pessa'h end" },
            { "fr", "Fin de Pessah" }
          }
        },
        {
          HebrewCalendar.TorahEvent.ChavouotDiet, new Dictionary<string, string>
          {
            { "en", "Chavouot diet" },
            { "fr", "Régime de Chavouot" }
          }
        },
        {
          HebrewCalendar.TorahEvent.Chavouot1, new Dictionary<string, string>
          {
            { "en", "Chavouot lamb" },
            { "fr", "Agneau de Chavouot" }
          }
        },
        {
          HebrewCalendar.TorahEvent.Chavouot2, new Dictionary<string, string>
          {
            { "en", "Chavouot end" },
            { "fr", "Fin de Chavouot" }
          }
        },
        {
          HebrewCalendar.TorahEvent.YomTerouah, new Dictionary<string, string>
          {
            { "en", "Yom Terou'ah" },
            { "fr", "Yom Terou'ah" }
          }
        },
        {
          HebrewCalendar.TorahEvent.YomHaKipourim, new Dictionary<string, string>
          {
            { "en", "Yom HaKipourim" },
            { "fr", "Yom HaKipourim" }
          }
        },
        {
          HebrewCalendar.TorahEvent.SoukotD1, new Dictionary<string, string>
          {
            { "en", "Soukot start" },
            { "fr", "Début de Soukot" }
          }
        },
        {
          HebrewCalendar.TorahEvent.SoukotD8, new Dictionary<string, string>
          {
            { "en", "Soukot end" },
            { "fr", "Fin de Soukot" }
          }
        }
      };

  }

}
