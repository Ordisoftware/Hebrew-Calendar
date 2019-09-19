/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
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
/// <edited> 2019-09 </edited>
using System;
using System.Collections.Generic;

namespace Ordisoftware.HebrewCalendar
{

  static public class Translations
  {

    static public readonly string NewLine = Environment.NewLine;

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

    static public readonly Dictionary<string, string> TodayText
      = new Dictionary<string, string>()
      {
        { "en", "Today" },
        { "fr", "Aujourd'hui" }
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

    static public readonly Dictionary<string, string> CheckUpdateNoNewText
      = new Dictionary<string, string>()
      {
        { "en", "There is no new version available." },
        { "fr", "Il n'y a pas de nouvelle version de disponible." }
      };

    static public readonly Dictionary<string, string> CheckUpdateResultText
      = new Dictionary<string, string>()
      {
        { "en", "A newer version is available : " },
        { "fr", "Une nouvelle version est disponible : " }
      };

    static public readonly Dictionary<string, string> CheckUpdateAskDownloadText
      = new Dictionary<string, string>()
      {
        { "en", "Do you want to open the download page?" },
        { "fr", "Voulez-vous ouvrir la page de téléchargement ?" }
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
        { "fr", "Impossible de quitter durant la génération." }
      };

    static public readonly Dictionary<string, string> GenerateCalendarText
      = new Dictionary<string, string>()
      {
        { "en", "Database is empty." + NewLine + NewLine +
                "Do you want to generate a calendar?" },
        { "fr", "La base de données est vide." + NewLine + NewLine +
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

    static public readonly Dictionary<string, string> ProgressFillMonthsText
      = new Dictionary<string, string>()
      {
        { "en", "Filling months..." },
        { "fr", "Remplissage des mois..." }
      };

    static public readonly Dictionary<string, string> RestoreWinPosText
      = new Dictionary<string, string>()
      {
        { "en", "This action will restore windows position." + NewLine + NewLine +
                "Do you want to continue?" },
        { "fr", "Cette action va restaurer la position de la fenêtre"  + NewLine + NewLine +
                "Voulez-vous continuer ?" }
      };

    static public readonly Dictionary<string, string> RegenerateCalendarText
      = new Dictionary<string, string>()
      {
        { "en", "Preferences changed." + NewLine + NewLine +
                "Do you want to generate the calendrier?" },
        { "fr", "Préférences changées." + NewLine + NewLine +
                "Voulez-vous générer le calendrier ?" }
      };

    static public readonly Dictionary<string, string> ReplaceCalendarText
      = new Dictionary<string, string>()
      {
        { "en", "The new calendar will replace the old." + NewLine + NewLine +
                "Do you want to continue?" },
        { "fr", "Le nouveau calendrier va remplacer l'ancien." + NewLine + NewLine +
                "Voulez-vous continuer ?" }
      };

    static public readonly Dictionary<string, string> NavigationDayText
      = new Dictionary<string, string>()
      {
        { "en", "Day #" },
        { "fr", "Jour #" }
      };

    static public readonly Dictionary<MoonPhaseType, Dictionary<string, string>> MoonPhaseText
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

    static public readonly Dictionary<EphemerisType, Dictionary<string, string>> EphemerisText
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

    static public readonly Dictionary<ReportFieldType, Dictionary<string, string>> CalendarFieldText
      = new Dictionary<ReportFieldType, Dictionary<string, string>>()
      {
        {
          ReportFieldType.Date, new Dictionary<string, string>
          {
            { "en", "Date" },
            { "fr", "Date" }
          }
        },
        {
          ReportFieldType.Month, new Dictionary<string, string>
          {
            { "en", "Month" },
            { "fr", "Mois" }
          }
        },
        {
          ReportFieldType.Sun, new Dictionary<string, string>
          {
            { "en", "Sun" },
            { "fr", "Soleil" }
          }
        },
        {
          ReportFieldType.Moon, new Dictionary<string, string>
          {
            { "en", "Moon" },
            { "fr", "Lune" }
          }
        },
        {
          ReportFieldType.Events, new Dictionary<string, string>
          {
            { "en", "Events" },
            { "fr", "Évènements" }
          }
        }
      };

    static public readonly string[] BabylonianHebrewMonthText =
    {
      "",
      "Nissan", "Iyar", "Sivan", "Tamouz", "Av", "Eloul",
      "Tishri", "Heshvan", "Kislev", "Tevet", "Chevat", "Adar",
      "Adar II"
    };

    static public readonly Dictionary<SeasonChangeType, Dictionary<string, string>> SeasonEventText
      = new Dictionary<SeasonChangeType, Dictionary<string, string>>()
      {
        {
          SeasonChangeType.None, new Dictionary<string, string>
          {
            { "en", "" },
            { "fr", "" }
          }
        },
        {
          SeasonChangeType.SpringEquinox, new Dictionary<string, string>
          {
            { "en", "Spring equinox" },
            { "fr", "Equinoxe de printemps" }
          }
        },
        {
          SeasonChangeType.SummerSolstice, new Dictionary<string, string>
          {
            { "en", "Summer solstice" },
            { "fr", "Solstice d'été" }
          }
        },
        {
          SeasonChangeType.AutumnEquinox, new Dictionary<string, string>
          {
            { "en", "Autumn equinox" },
            { "fr", "Equinoxe d'automne" }
          }
        },
        {
          SeasonChangeType.WinterSolstice, new Dictionary<string, string>
          {
            { "en", "Winter solstice" },
            { "fr", "Solstice d'hiver" }
          }
        }
      };

    static public readonly Dictionary<TorahEventType, Dictionary<string, string>> TorahEventText
      = new Dictionary<TorahEventType, Dictionary<string, string>>()
      {
        {
          TorahEventType.None, new Dictionary<string, string>
          {
            { "en", "" },
            { "fr", "" }
          }
        },
        {
          TorahEventType.NewYearD1, new Dictionary<string, string>
          {
            { "en", "New year" },
            { "fr", "Début de l'année" }
          }
        },
        {
          TorahEventType.NewYearD10, new Dictionary<string, string>
          {
            { "en", "Set aside lamb" },
            { "fr", "Réserver agneau" }
          }
        },
        {
          TorahEventType.PessahD1, new Dictionary<string, string>
          {
            { "en", "Pessa'h start" },
            { "fr", "Début de Pessah" }
          }
        },
        {
          TorahEventType.PessahD7, new Dictionary<string, string>
          {
            { "en", "Pessa'h end" },
            { "fr", "Fin de Pessah" }
          }
        },
        {
          TorahEventType.ChavouotDiet, new Dictionary<string, string>
          {
            { "en", "Chavouot diet" },
            { "fr", "Régime de Chavouot" }
          }
        },
        {
          TorahEventType.Chavouot1, new Dictionary<string, string>
          {
            { "en", "Chavouot lamb" },
            { "fr", "Agneau de Chavouot" }
          }
        },
        {
          TorahEventType.Chavouot2, new Dictionary<string, string>
          {
            { "en", "Chavouot end" },
            { "fr", "Fin de Chavouot" }
          }
        },
        {
          TorahEventType.YomTerouah, new Dictionary<string, string>
          {
            { "en", "Yom Terou'ah" },
            { "fr", "Yom Terou'ah" }
          }
        },
        {
          TorahEventType.YomHaKipourim, new Dictionary<string, string>
          {
            { "en", "Yom HaKipourim" },
            { "fr", "Yom HaKipourim" }
          }
        },
        {
          TorahEventType.SoukotD1, new Dictionary<string, string>
          {
            { "en", "Soukot start" },
            { "fr", "Début de Soukot" }
          }
        },
        {
          TorahEventType.SoukotD8, new Dictionary<string, string>
          {
            { "en", "Soukot end" },
            { "fr", "Fin de Soukot" }
          }
        }
      };

  }

}
