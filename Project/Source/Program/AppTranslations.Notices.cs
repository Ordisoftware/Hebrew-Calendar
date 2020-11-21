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
/// <edited> 2020-11 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// Localization strings.
  /// </summary>
  static public partial class AppTranslations
  {

    static public readonly TranslationsDictionary AutoGenerateIntervalNotice
      = new TranslationsDictionary
      {
        [Language.EN] = "A positive value generates the next years." + Globals.NL2 +
                        "A negative value generates the years before and after now.",

        [Language.FR] = "Une valeur positive permet de générer les prochaines années." + Globals.NL2 +
                        "Une valeur négative permet de générer les années avant et après maintenant."
      };

    static public readonly TranslationsDictionary NoticeMoonDayTextFormat
      = new TranslationsDictionary
      {
        [Language.EN] = "Use the following tags to replace values:" + Globals.NL2 +
                        "%MONTHNAME% : moon month name" + Globals.NL +
                        "%MONTHNUM% : moon month number" + Globals.NL +
                        "%DAYNUM% : moon day number",

        [Language.FR] = "Utiliser les tags suivants pour remplacer les valeurs :" + Globals.NL2 +
                        "%MONTHNAME% : nom du mois lunaire" + Globals.NL +
                        "%MONTHNUM% : numéro du mois lunaire" + Globals.NL +
                        "%DAYNUM% : numéro du jour lunaire"
      };

    static public readonly TranslationsDictionary NoticeShabatTitle
      = new TranslationsDictionary
      {
        [Language.EN] = "Shabat notice",
        [Language.FR] = "Notice du shabat"
      };

    static public readonly TranslationsDictionary NoticeShabat
      = new TranslationsDictionary
      {
        [Language.EN] = "The shabat is the \"day of rest\" where one do not work for a livelihood. Unless there is a vital emergency, the body, the emotions and the spirit are resting there. The study of the Torah is a privileged activity." + Globals.NL2 +
                        "The tradition attributes this day to Saturday. We can however think according to Béréshit 1.1 that in the case where the first day is the day of birth as a corollary to the fusion of the gametes then it takes place the day before: thus a person coming to the world on a Sunday will have his Shabat the Saturday. From Béréshit 1.5 and 1.16 as well as from Shémot 20.8 it can be deduced that it lasts from sunset on the eve of the calendar day to sunset on the same day. For example, for a person born in Paris, the Shabat of February 19, 2019 takes place from Friday 18 at 17:25 to Saturday at 17:25 approximately." + Globals.NL2 +
                        "The personal shabat of a maried or concubin or divorced man is the previous day of the birth. A son follows his father's shabat. The shabat of a woman is the shabat of her father or her husband or her concubin. So the man and the woman respect their mutual cycles. Indeed, during the period when the married or concubine or divorced woman is Nidah from the beginning to the end of the blood flow, her vital field is dissonant and the couple avoid touching each other (the virgin girl is not concerned as long as she had no relations through the openings of the begetting) to avoid to increase as well as to transmit this state to things and people (otherwise we follow the rules of the Torah about that)." + Globals.NL2 +
                        "If the man were born between midnight and the sunset, the shabat is the day before. Between sunset and midnight, the shabat is that day. This day is from previous day (or previous previous day) at sunset to this day (or previous day) at sunset. The day of the shabat goes from sunset on the previous calendar day to sunset of that day, with 3% of natural margin that to say about one hour. The day before, either the man keeps without going out and strengthens the couple during the shabat, or he goes out and lights up the couple for shabat, but on shabat he does not go out of his temple, and except in case of emergency we do not produce, transform and destroys nothing, we don't plan anything, we don't work, we don't cook, we don't shave, we don't cut, we don't make fire, we don't care about information, etc. But we can for example take part in sports, study science and play with children." + Globals.NL2 +
                        "If you prefer to use the traditional group shabat, select for example Saturday for Judaism, Sunday for Christianity or Friday for Islam.",

        [Language.FR] = "Le shabat est le \"jour du repos\" où l'on ne travaille pas pour obtenir un moyen de subsistance et où l'on exerce aucune activité créatrice. A moins d'une urgence vitale, on y repose le corps, les émotions et l'esprit. L'étude de la Torah y est une activité privilégiée." + Globals.NL2 +
                        "La tradition attribue ce jour au samedi. On peut cependant penser d'après Béréshit 1.1 que dans le cas où le premier jour est le jour de la naissance en tant que corolaire à la fusion des gamètes alors il a lieu la veille : ainsi une personne venue au monde un dimanche aura son Shabat le samedi. De Béréshit 1.5 et 1.16 ainsi que de Shémot 20.8 on peut déduire qu'il dure depuis le coucher du soleil la veille du jour calendaire au coucher du soleil de ce même jour. Par exemple, pour une personne née à Paris, le Shabat du 19 février 2019 a lieu du vendredi 18 à 17h25 au samedi à 17h25 environ." + Globals.NL2 +
                        "Le shabat personnel d'un homme marié ou concubin ou divorcé est la veille du jour de la naissance. Un fils suit le shabat de son père. Le shabat d'une femme est celui de son père ou de son mari ou de son concubin. Ainsi l'homme et la femme respectent leurs cycles mutuels. En effet, durant la période où la femme mariée ou concubine ou divorcée est Nidah du début à la fin de l'écoulement de sang, son champ vital est dissonant et le couple évite de se toucher (la fille vierge n'est pas concernée tant qu'elle n'a pas eu de rapports par les ouvertures de l'engendrement) tant pour ne pas augmenter que transmettre cet état aux choses et aux gens (sinon on suit les règles de la Torah à ce sujet)." + Globals.NL2 +
                        "Si l'homme est né entre minuit et le coucher du soleil, le shabat est la veille. Entre le coucher du soleil et minuit, le shabat est ce jour. Ce jour est de la veille (ou veille veille) au coucher à ce jour (ou veille) au coucher. Le jour du shabat va du coucher du soleil lors du jour calendaire précédent au coucher de ce jour, avec 3% de marge naturelle soit environ plus ou moins une heure. La veille, soit l'homme garde sans sortir et renforce le couple lors du shabat, soit il sort et illumine le couple pour shabat, mais à shabat il ne sort pas de son temple, et sauf cas d'urgence on ne produit, transforme et détruit rien, on ne planifie rien, on ne travaille pas, on ne cuisine pas, on ne rase pas, on ne coupe pas, on ne fait pas de feu, on ne s'interesse pas aux informations, etc. Mais on peut par exemple faire du sport, étudier la science et jouer avec les enfants." + Globals.NL2 +
                        "Si vous préférez utiliser le shabat de groupe traditionnel, sélectionnez par exemple le samedi pour le Judaïsme, le dimanche pour le Christianisme ou le vendredi pour l'Islam."
      };

    static public readonly TranslationsDictionary NoticeCelebrationsTitle
      = new TranslationsDictionary
      {
        [Language.EN] = "Celebrations notice",
        [Language.FR] = "Notice des célébrations"
      };

    static public readonly TranslationsDictionary NoticeCelebrations
      = new TranslationsDictionary
      {
        [Language.EN] = "The times of the Torah's celebrations are Pesa'h or Easter which is the liberation of illusions, Shavuot or Weeks which is the gift of knowledge, Teru'ah or Ringtone which is the joy of being freedom, Kipurim or Atonement which is the sorrows of losses, and Sukot or Tabernacles which is the construction of the future." + Globals.NL2 +
                        "These are important moments of the lunar year in the solar cycle whose purpose is to provide a benevolent evolution of consciousness by the knowledge of the laws of the universe and of life. The Torah says to count these days according to the moon, as opposed to Shabat which is counted according to the sun." + Globals.NL2 +
                        "The application uses by default moon omer for celebrations." + Globals.NL2 +
                        "If you use moon omer then celebrations dates will be calculated according to seasons and there will be an inversion between north and south hemispheres. In this case, a day is from one moon set to the next set." + Globals.NL2 +
                        "You can use traditionnals sun days by modifying the option in the reminder, hence celebrations will be same in north and south. In this case, a day is from one sun set to the next set.",

        [Language.FR] = "Les temps de célébration de la Torah sont Pessa'h ou Pâques qui est la libération des illusions, Shavouot ou Semaines qui est le don de la connaissance, Terou'ah ou Sonnerie qui est la joie d'être libéré, Kipourim ou Pénitence qui est les peines des pertes, et Soukot ou Cabanes qui est la construction du futur." + Globals.NL2 +
                        "Ce sont les moments importants de l'année lunaire au sein du cycle solaire dont la finalité est de procurer une évolution bienveillante de la conscience par la connaissance des lois de l'univers et de la vie. La Torah indique de compter ces jours selon la lune, par opposition au Shabat qui se compte selon le soleil." + Globals.NL2 +
                        "L'application utilise par défaut un omer selon la lune pour les célébrations." + Globals.NL2 +
                        "Si vous utilisez le omer de la lune alors les dates des célébrations seront calculées selon les saisons et il y aura une inversion entre les hémisphères nord et sud. Dans ce cas, un jour est du coucher de la lune au suivant." + Globals.NL2 +
                        "Vous pouvez utiliser les jours solaires traditionnels en modifiant l'option dans le rappeleur, alors les célébrations seront les mêmes pour le nord et le sud. Dans ce cas, un jour est du coucher du soleil au suivant."
      };


    static public readonly TranslationsDictionary DatesDiffNoticeTitle
      = new TranslationsDictionary
      {
        [Language.EN] = "Dates difference notice",
        [Language.FR] = "Notice de différence de dates"
      };

    static public readonly TranslationsDictionary DatesDiffNotice
      = new TranslationsDictionary
      {
        [Language.EN] = "The values shown include the current periods." + Globals.NL2 +
                        "The annual solar period begins on January 1." + Globals.NL +
                        "The monthly solar period is counted from the 1st day." + Globals.NL +
                        "The solar week is counted every 7 days from the smallest date." + Globals.NL2 +
                        "The lunar day goes from the setting of the moon to the next." + Globals.NL +
                        "A lunar month goes from the new moon to the next." + Globals.NL2 +
                        "Here are some examples." + Globals.NL2 +
                        "Two solar weeks indicate that 8 days or more but 14 or less have passed." + Globals.NL2 +
                        "Two solar months indicate that the oldest date is in a calendar month and the other is in the following month, regardless of the number of days between, i.e. the selected dates are at horse over two months." + Globals.NL2 +
                        "Two lunar months indicate that one moon has elapsed and that we are in the second." + Globals.NL2 +
                        "It is the same for the solar years." + Globals.NL2 +
                        "Regarding lunar days, the moon regularly jumps on a solar day which therefore happens to be straddling two lunar days, such as 08/10/2020 which is not counted because there is no sunrise. moon on that solar day.",

        [Language.FR] = "Les valeurs indiquées incluent les périodes en cours." + Globals.NL2 +
                        "La période solaire annuelle commence le 1er janvier." + Globals.NL +
                        "La période solaire mensuelle est comptée depuis le 1er jour." + Globals.NL +
                        "La semaine solaire est comptée tous les 7 jours depuis la plus petite date." + Globals.NL2 +
                        "Le jour lunaire va du coucher de la lune au suivant." + Globals.NL +
                        "Un mois lunaire va de la nouvelle lune à la suivante." + Globals.NL2 +
                        "Voici quelques exemples." + Globals.NL2 +
                        "Deux semaines solaires indiquent qu'il s'est écoulé 8 jours ou plus mais 14 ou moins." + Globals.NL2 +
                        "Deux mois solaires indiquent que la date la plus ancienne se trouve dans un mois calendaire et que l'autre se trouve dans le mois suivant, quel que soient le nombre de jours entre, c'est-à-dire que les dates sélectionnées sont à cheval sur deux mois." + Globals.NL2 +
                        "Deux mois lunaires indiquent qu'il s'est écoulé une lune et qu'on se trouve dans la deuxième." + Globals.NL2 +
                        "Il en est de même pour les années solaires." + Globals.NL2 +
                        "Concernant les jours lunaires, la lune saute régulièrement un jour solaire qui se trouve donc être à cheval entre deux jours lunaires, comme par exemple le 10/08/2020 qui n'est pas compté car il n'y a pas de lever de la lune ce jour solaire-là."
      };

    static public readonly TranslationsDictionary NoticeMoonMonthsTitle
      = new TranslationsDictionary
      {
        [Language.EN] = "Moon months notice",
        [Language.FR] = "Notice des mois lunaires"
      };

    static public readonly TranslationsDictionary NoticeMoonMonths
      = new TranslationsDictionary
      {
        [Language.EN] = "Rouge - azur ou pourpre = éclat de l'étincelle de feu = inspir | T(U)" + Globals.NL +
                        "Vert = air = action | A" + Globals.NL +
                        "Blanc = eau = expir | C" + Globals.NL +
                        "Jaune = terre = repos | G",

        [Language.FR] = "Rouge - azur ou pourpre = éclat de l'étincelle de feu = inspir | T(U)" + Globals.NL +
                        "Vert = air = action | A" + Globals.NL +
                        "Blanc = eau = expir | C" + Globals.NL +
                        "Jaune = terre = repos | G"
      };

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
                        Globals.NL +
                        "F4 : Next celebrations window" + Globals.NL +
                        "F5 : Search a celebration window" + Globals.NL +
                        "F6 : Search a moon month window" + Globals.NL +
                        "F7 : Search a gregorian month window" + Globals.NL +
                        "F9 : Navigation window (also Ctrl+N)" + Globals.NL +
                        Globals.NL +
                        "Ctrl+Tab : Next view" + Globals.NL +
                        "Shift+Ctrl+Tab : Previous view" + Globals.NL +
                        Globals.NL +
                        "Ctrl+T : Go to today (also Numpad0)" + Globals.NL +
                        "Ctrl+D : Search a day" + Globals.NL +
                        Globals.NL +
                        "Ctrl+C : Copy text report to clipboard" + Globals.NL +
                        "Ctrl+P : Print month view" + Globals.NL +
                        "Ctrl+S : Save text report to text file" + Globals.NL +
                        "Alt+S : Save text report to CSV file" + Globals.NL +
                        Globals.NL +
                        "Alt+C : Open windows calculator" + Globals.NL +
                        "Alt+T : Open windows date and time settings" + Globals.NL +
                        Globals.NL +
                        "Ctrl+F1 : Dates difference calculator" + Globals.NL +
                        "Ctrl+F2 : Generate calendar data" + Globals.NL +
                        Globals.NL +
                        "Ctrl+F11 : Current log window" + Globals.NL +
                        "Ctrl+F12 : Statistics window" + Globals.NL +
                        Globals.NL +
                        "Home : First month available in the database" + Globals.NL +
                        "End : Last month available in the database" + Globals.NL +
                        Globals.NL +
                        "Up : Previous year" + Globals.NL +
                        "Down : Next year" + Globals.NL +
                        "Left : Previous month" + Globals.NL +
                        "Right : Next month" + Globals.NL +
                        Globals.NL +
                        "F8 : Preferences" + Globals.NL +
                        "F11 : Help" + Globals.NL +
                        "F12 : About" + Globals.NL +
                        "Escape : Close window",

        [Language.FR] = "F1 : Vue du rapport textuel" + Globals.NL +
                        "F2 : Vue du mois" + Globals.NL +
                        "F3 : Vue de la grille de données" + Globals.NL +
                        Globals.NL +
                        "F4 : Fenêtre des prochaines célébrations" + Globals.NL +
                        "F5 : Fenêtre de recherche de célébration" + Globals.NL +
                        "F6 : Fenêtre de recherche de mois lunaire" + Globals.NL +
                        "F7 : Fenêtre de recherche de mois grégorien" + Globals.NL +
                        "F9 : Fenêtre de navigation (également Ctrl+N)" + Globals.NL +
                        Globals.NL +
                        "Ctrl+Tab : Vue suivante" + Globals.NL +
                        "Maj+Ctrl+Tab : Vue précédente" + Globals.NL +
                        Globals.NL +
                        "Ctrl+T : Aller à aujourd'hui (également Numpad0)" + Globals.NL +
                        "Ctrl+D : Chercher un jour" + Globals.NL +
                        Globals.NL +
                        "Ctrl+C : Copie le rapport dans le presse-papier" + Globals.NL +
                        "Ctrl+P : Imprime la vue par mois" + Globals.NL +
                        "Ctrl+S : Sauvegarde le rapport dans un fichier texte" + Globals.NL +
                        "Alt+S : Sauvegarde le rapport dans un fichier CSV" + Globals.NL +
                        Globals.NL +
                        "Alt+C : Ouvre la calculatrice Windows" + Globals.NL +
                        "Alt+T : Ouvre les paramètres de date et heure de Windows" + Globals.NL +
                        Globals.NL +
                        "Ctrl+F1 : Calculateur de différence de dates" + Globals.NL +
                        "Ctrl+F2 : Génère les données du calendrier" + Globals.NL +
                        Globals.NL +
                        "Ctrl+F11 : Fenêtre du log en cours" + Globals.NL +
                        "Ctrl+F12 : Fenêtre des statistiques" + Globals.NL +
                        Globals.NL +
                        "Début : Premier mois disponible dans la base de données" + Globals.NL +
                        "Fin : Dernier mois disponible dans la base de données" + Globals.NL +
                        Globals.NL +
                        "Haut : Année précédente" + Globals.NL +
                        "Bas : Année suivante" + Globals.NL +
                        "Gauche : Mois précédent" + Globals.NL +
                        "Droite : Mois suivant" + Globals.NL +
                        Globals.NL +
                        "F8 : Préférences" + Globals.NL +
                        "F11 : Aide" + Globals.NL +
                        "F12 : A propos" + Globals.NL +
                        "Echap : Ferme la fenêtre"
      };

  }

}
