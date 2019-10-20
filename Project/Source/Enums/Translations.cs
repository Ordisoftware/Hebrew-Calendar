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
/// <edited> 2019-10 </edited>
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
        { "en", "A tool to generate a hebrew lunisolar calendar and remind celebrations" },
        { "fr", "Un outil pour générer un calendrier luni-solaire hébraïque et rappeler les célébrations" }
      };

    static public readonly Dictionary<string, string> ExitApplication
      = new Dictionary<string, string>()
      {
        { "en", "Exit application?" },
        { "fr", "Quitter l'application ?" }
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

    static public readonly Dictionary<string, string> SelectBirthday
      = new Dictionary<string, string>()
      {
        { "en", "Birth day" },
        { "fr", "Date de naissance" }
      };

    static public readonly Dictionary<string, string> DateNotFound
      = new Dictionary<string, string>()
      {
        { "en", "Date not found in the database: {0}" },
        { "fr", "Date non trouvée dans la base de données : {0}" }
      };

    static public readonly Dictionary<string, string> CantExitApplicationWhileGenerating
      = new Dictionary<string, string>()
      {
        { "en", "Can't close while generating." },
        { "fr", "Impossible de quitter durant la génération." }
      };

    static public readonly Dictionary<string, string> StopGeneration
      = new Dictionary<string, string>()
      {
        { "en", "Do you want to stop the generation process?" },
        { "fr", "Voulez-vous arrêter le processus de génération ?" }
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
        { "fr", "Cette action va restaurer la position de la fenêtre"  + NewLine + NewLine +
                "Voulez-vous continuer ?" }
      };

    static public readonly Dictionary<string, string> RegenerateCalendar
      = new Dictionary<string, string>()
      {
        { "en", "Preferences changed." + NewLine + NewLine +
                "Do you want to generate the calendrier?" },
        { "fr", "Préférences changées." + NewLine + NewLine +
                "Voulez-vous générer le calendrier ?" }
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

    static public readonly Dictionary<string, string> OmerMoon
      = new Dictionary<string, string>()
      {
        { "en", "The application uses by default moon omer for" + NewLine +
                "celebrations." + NewLine + NewLine +
                "If you use moon omer then celebrations dates will" + NewLine +
                "be calculated according to seasons and there will" + NewLine +
                "be an inversion between north and south hemispheres." + NewLine + NewLine +
                "You can use traditionnals sun days by modifying" + NewLine +
                "the option in the reminder, hence celebrations" + NewLine +
                "will be same in north and south." },
        { "fr", "L'application utilise par défaut un omer selon la lune" + NewLine +
                "pour les célébrations." + NewLine + NewLine +
                "Si vous utilisez le omer de la lune alors les dates des" + NewLine +
                "célébrations seront calculées selon les saisons et il y" + NewLine +
                "aura une inversion entre les hémisphères nord et sud." + NewLine + NewLine +
                "Vous pouvez utiliser les jours solaires traditionnels" + NewLine +
                "en modifiant l'option dans le rappeleur, alors les" + NewLine +
                "célébrations seront les mêmes pour le nord et le sud." }
      };

    static public readonly Dictionary<string, string> SelectBirthDay
      = new Dictionary<string, string>()
      {
        { "en", "The personal shabat is the previous day of the birth." + NewLine + NewLine +
                "If you were born between midnight and the sunset," + NewLine +
                "your shabat is the day before." + NewLine + NewLine +
                "If you were born between sunset and midnight," + NewLine +
                "your shabat is that day." + NewLine + NewLine +
                "If you prefer to use the traditional group shabat," + NewLine +
                "select for example Saturday for Judaism, Sunday" + NewLine +
                "for Catholicism or Friday for Islam." + NewLine + NewLine + 
                "Do you want to setup the personal shabat?" },
        { "fr", "Le shabat personnel est la veille du jour de la naissance." + NewLine + NewLine +
                "Si vous êtes né entre minuit et le coucher du soleil, votre" + NewLine +
                "shabat est la veille." + NewLine + NewLine +
                "Si vous êtes né entre le coucher du soleil et minuit, votre" + NewLine +
                "shabat est ce jour." + NewLine + NewLine +
                "Si vous préférez utiliser le shabat de groupe traditionnel," + NewLine +
                "sélectionnez par exemple le samedi pour le Judaïsme, le" + NewLine +
                "dimanche pour le Christianisme ou le vendredi pour" + NewLine +
                "l'Islam" + NewLine + NewLine +
                "Voulez-vous configurer le shabat personnel ?" }
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

    static public readonly Dictionary<ReportFieldType, Dictionary<string, string>> CalendarField
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

    static public readonly Dictionary<SeasonChangeType, Dictionary<string, string>> SeasonEvent
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

    static public readonly Dictionary<TorahEventType, Dictionary<string, string>> TorahEvent
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
