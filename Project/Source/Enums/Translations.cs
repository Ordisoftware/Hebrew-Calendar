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
/// <edited> 2020-03 </edited>
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

    static public readonly Dictionary<string, string> OmerMoon
      = new Dictionary<string, string>()
      {
        { "en", "The application uses by default moon omer for celebrations." + NewLine + NewLine +
                "If you use moon omer then celebrations dates will be calculated according to seasons and there will be an inversion between north and south hemispheres. In this case, a day is from one moon set to the next set." + NewLine + NewLine +
                "You can use traditionnals sun days by modifying the option in the reminder, hence celebrations will be same in north and south. In this case, a day is from one sun set to the next set." },
        { "fr", "L'application utilise par défaut un omer selon la lune pour les célébrations." + NewLine + NewLine +
                "Si vous utilisez le omer de la lune alors les dates des célébrations seront calculées selon les saisons et il y aura une inversion entre les hémisphères nord et sud. Dans ce cas, un jour est du coucher de la lune au suivant." + NewLine + NewLine +
                "Vous pouvez utiliser les jours solaires traditionnels en modifiant l'option dans le rappeleur, alors les célébrations seront les mêmes pour le nord et le sud. Dans ce cas, un jour est du coucher du soleil au suivant." }
      };

    static public readonly Dictionary<string, string> PersonalShabatNotice
      = new Dictionary<string, string>()
      {
        { "en", "The personal shabat of a maried or concubin or divorced man is the previous day of the birth. A son follows his father's shabat. The shabat of a woman is the shabat of her father or her husband or her concubin." + NewLine + NewLine +
                "So the man and the woman respect their mutual cycles. Indeed, during the period when the married or concubine or divorced woman is Nidah from the beginning to the end of the blood flow, her vital field is dissonant and the couple avoid touching each other (the virgin girl is not concerned as long as she had no relations through the openings of the begetting) to avoid to increase as well as to transmit this state to things and people (otherwise we follow the rules of the Torah about that)." + NewLine + NewLine +
                "If the man were born between midnight and the sunset, the shabat is the day before. Between sunset and midnight, the shabat is that day. This day is from previous day (or previous previous day) at sunset to this day (or previous day) at sunset." + NewLine + NewLine +
                "The day of the shabat goes from sunset on the previous calendar day to sunset of that day, with 3% of natural margin that to say about one hour." + NewLine + NewLine +
                "The day before, either the man keeps without going out and strengthens the couple during the shabat, or he goes out and lights up the couple for shabat, but on shabat he does not go out of his temple, and except in case of emergency we do not produce, transform and destroys nothing, we don't plan anything, we don't work, we don't cook, we don't shave, we don't cut, we don't make fire, we don't care about information, etc. But we can for example take part in sports, study science and play with children." + NewLine + NewLine +
                "If you prefer to use the traditional group shabat, select for example Saturday for Judaism, Sunday for Christianity or Friday for Islam."
                 },
        { "fr", "Le shabat personnel d'un homme marié ou concubin ou divorcé est la veille du jour de la naissance. Un fils suit le shabat de son père. Le shabat d'une femme est celui de son père ou de son mari ou de son concubin." + NewLine + NewLine +
                "Ainsi l'homme et la femme respectent leurs cycles mutuels. En effet, durant la période où la femme mariée ou concubine ou divorcée est Nidah du début à la fin de l'écoulement de sang, son champ vital est dissonant et le couple évite de se toucher (la fille vierge n'est pas concernée tant qu'elle n'a pas eu de rapports par les ouvertures de l'engendrement) tant pour ne pas augmenter que transmettre cet état aux choses et aux gens (sinon on suit les règles de la Torah à ce sujet)." + NewLine + NewLine +
                "Si l'homme est né entre minuit et le coucher du soleil, le shabat est la veille. Entre le coucher du soleil et minuit, le shabat est ce jour. Ce jour est de la veille (ou veille veille) au coucher à ce jour (ou veille) au coucher." + NewLine + NewLine +
                "Le jour du shabat va du coucher du soleil lors du jour calendaire précédent au coucher de ce jour, avec 3% de marge naturelle soit environ plus ou moins une heure." + NewLine + NewLine +
                "La veille, soit l'homme garde sans sortir et renforce le couple lors du shabat, soit il sort et illumine le couple pour shabat, mais à shabat il ne sort pas de son temple, et sauf cas d'urgence on ne produit, transforme et détruit rien, on ne planifie rien, on ne travaille pas, on ne cuisine pas, on ne rase pas, on ne coupe pas, on ne fait pas de feu, on ne s'interesse pas aux informations, etc. Mais on peut par exemple faire du sport, étudier la science et jouer avec les enfants." + NewLine + NewLine +
                "Si vous préférez utiliser le shabat de groupe traditionnel, sélectionnez par exemple le samedi pour le Judaïsme, le dimanche pour le Christianisme ou le vendredi pour l'Islam."
                 }
      };

    static public readonly Dictionary<string, string> AskToGenerateShabat
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
