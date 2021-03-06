﻿/// <license>
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
/// <edited> 2021-07 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// Localization strings.
  /// </summary>
  static partial class AppTranslations
  {

    static public readonly TranslationsDictionary NoticeCelebrationsTitle
      = new TranslationsDictionary
      {
        [Language.EN] = "Celebrations notice",
        [Language.FR] = "Notice des célébrations"
      };

    static public readonly TranslationsDictionary NoticeCelebrations
      = new TranslationsDictionary
      {
        [Language.EN] = "The times of the Torah's celebrations are Pesa'h or Easter which is the liberation of illusions, Shavu'ot or Weeks which is the gift of knowledge, Teru'ah or Ringtone which is the joy of being freedom, Kipurim or Atonement which is the sorrows of losses, and Sukot or Tabernacles which is the construction of the future." + Globals.NL2 +
                        "These are important moments of the lunar year in the solar cycle whose purpose is to provide a benevolent evolution of consciousness by the knowledge of the laws of the universe and of life. The Torah says to count these days according to the moon, as opposed to Shabat which is counted according to the sun." + Globals.NL2 +
                        "The application uses by default moon omer for celebrations." + Globals.NL2 +
                        "If you use moon omer then celebrations dates will be calculated according to seasons and there will be an inversion between north and south hemispheres. In this case, a day is from one moon set to the next set." + Globals.NL2 +
                        "You can use traditionnals sun days by modifying the option in the reminder, hence celebrations will be same in north and south. In this case, a day is from one sun set to the next set.",

        [Language.FR] = "Les temps de célébration de la Torah sont Pessa'h ou Pâques qui est la libération des illusions, Shavou'ot ou Semaines qui est le don de la connaissance, Terou'ah ou Sonnerie qui est la joie d'être libéré, Kipourim ou Pénitence qui est les peines des pertes, et Soukot ou Cabanes qui est la construction du futur." + Globals.NL2 +
                        "Ce sont les moments importants de l'année lunaire au sein du cycle solaire dont la finalité est de procurer une évolution bienveillante de la conscience par la connaissance des lois de l'univers et de la vie. La Torah indique de compter ces jours selon la lune, par opposition au Shabat qui se compte selon le soleil." + Globals.NL2 +
                        "L'application utilise par défaut un omer selon la lune pour les célébrations." + Globals.NL2 +
                        "Si vous utilisez le omer de la lune alors les dates des célébrations seront calculées selon les saisons et il y aura une inversion entre les hémisphères nord et sud. Dans ce cas, un jour est du coucher de la lune au suivant." + Globals.NL2 +
                        "Vous pouvez utiliser les jours solaires traditionnels en modifiant l'option dans le rappeleur, alors les célébrations seront les mêmes pour le nord et le sud. Dans ce cas, un jour est du coucher du soleil au suivant."
      };

    static public readonly TranslationsDictionary NoticeShabatTitle
      = new TranslationsDictionary
      {
        [Language.EN] = "Shabat notice",
        [Language.FR] = "Notice du Shabat"
      };

    static public readonly TranslationsDictionary NoticeShabat
      = new TranslationsDictionary
      {
        [Language.EN] = "The Shabat is the \"day of rest\" where one do not work for a livelihood. Unless there is a vital emergency, the body, the emotions and the spirit are resting there. The study of the Torah is a privileged activity." + Globals.NL2 +
                        "The tradition attributes this day to Saturday. We can however think according to Béréshit 1.1 that in the case where the first day is the day of birth as a corollary to the fusion of the gametes then it takes place the day before: thus a person coming to the world on a Sunday will have his Shabat the Saturday. From Béréshit 1.5 and 1.16 as well as from Shémot 20.8 it can be deduced that it lasts from sunset on the eve of the calendar day to sunset on the same day. For example, for a person born in Paris, the Shabat of February 19, 2019 takes place from Friday 18 at 17:25 to Saturday at 17:25 approximately." + Globals.NL2 +
                        "The personal Shabat of a maried or concubin or divorced man is the previous day of the birth. A son follows his father's Shabat. The Shabat of a woman is the Shabat of her father or her husband or her concubin. So the man and the woman respect their mutual cycles. Indeed, during the period when the married or concubine or divorced woman is Nidah from the beginning to the end of the blood flow, her vital field is dissonant and the couple avoid touching each other (the virgin girl is not concerned as long as she had no relations through the openings of the begetting) to avoid to increase as well as to transmit this state to things and people (otherwise we follow the rules of the Torah about that)." + Globals.NL2 +
                        "If the man were born between midnight and the sunset, the Shabat is the day before. Between sunset and midnight, the Shabat is that day. This day is from previous day (or previous previous day) at sunset to this day (or previous day) at sunset. The day of the Shabat goes from sunset on the previous calendar day to sunset of that day, with 3% of natural margin that to say about one hour. The day before, either the man keeps without going out and strengthens the couple during the Shabat, or he goes out and lights up the couple for Shabat, but on Shabat he does not go out of his temple, and except in case of emergency we do not produce, transform and destroys nothing, we don't plan anything, we don't work, we don't cook, we don't shave, we don't cut, we don't make fire, we don't care about information, etc. But we can for example take part in sports, study science and play with children." + Globals.NL2 +
                        "If you prefer to use the traditional group Shabat, select for example Saturday for Judaism, Sunday for Christianity or Friday for Islam.",

        [Language.FR] = "Le Shabat est le \"jour du repos\" où l'on ne travaille pas pour obtenir un moyen de subsistance et où l'on exerce aucune activité créatrice. A moins d'une urgence vitale, on y repose le corps, les émotions et l'esprit. L'étude de la Torah y est une activité privilégiée." + Globals.NL2 +
                        "La tradition attribue ce jour au samedi. On peut cependant penser d'après Béréshit 1.1 que dans le cas où le premier jour est le jour de la naissance en tant que corolaire à la fusion des gamètes alors il a lieu la veille : ainsi une personne venue au monde un dimanche aura son Shabat le samedi. De Béréshit 1.5 et 1.16 ainsi que de Shémot 20.8 on peut déduire qu'il dure depuis le coucher du soleil la veille du jour calendaire au coucher du soleil de ce même jour. Par exemple, pour une personne née à Paris, le Shabat du 19 février 2019 a lieu du vendredi 18 à 17h25 au samedi à 17h25 environ." + Globals.NL2 +
                        "Le Shabat personnel d'un homme marié ou concubin ou divorcé est la veille du jour de la naissance. Un fils suit le Shabat de son père. Le Shabat d'une femme est celui de son père ou de son mari ou de son concubin. Ainsi l'homme et la femme respectent leurs cycles mutuels. En effet, durant la période où la femme mariée ou concubine ou divorcée est Nidah du début à la fin de l'écoulement de sang, son champ vital est dissonant et le couple évite de se toucher (la fille vierge n'est pas concernée tant qu'elle n'a pas eu de rapports par les ouvertures de l'engendrement) tant pour ne pas augmenter que transmettre cet état aux choses et aux gens (sinon on suit les règles de la Torah à ce sujet)." + Globals.NL2 +
                        "Si l'homme est né entre minuit et le coucher du soleil, le Shabat est la veille. Entre le coucher du soleil et minuit, le Shabat est ce jour. Ce jour est de la veille (ou veille veille) au coucher à ce jour (ou veille) au coucher. Le jour du Shabat va du coucher du soleil lors du jour calendaire précédent au coucher de ce jour, avec 3% de marge naturelle soit environ plus ou moins une heure. La veille, soit l'homme garde sans sortir et renforce le couple lors du Shabat, soit il sort et illumine le couple pour Shabat, mais à Shabat il ne sort pas de son temple, et sauf cas d'urgence on ne produit, transforme et détruit rien, on ne planifie rien, on ne travaille pas, on ne cuisine pas, on ne rase pas, on ne coupe pas, on ne fait pas de feu, on ne s'interesse pas aux informations, etc. Mais on peut par exemple faire du sport, étudier la science et jouer avec les enfants." + Globals.NL2 +
                        "Si vous préférez utiliser le Shabat de groupe traditionnel, sélectionnez par exemple le samedi pour le Judaïsme, le dimanche pour le Christianisme ou le vendredi pour l'Islam."
      };

    static public readonly TranslationsDictionary NoticeParashahTitle
      = new TranslationsDictionary
      {
        [Language.EN] = "Parashot notice",
        [Language.FR] = "Notice des Parashot"
      };

    static public readonly TranslationsDictionary NoticeParashah
      = new TranslationsDictionary
      {
        [Language.EN] = "The study of the Weekly Torah portion begins at Sim'hat Torah with the Bereshit section on 22 Tishri in the Land of Israel, or on 23 in Mitsraïm and in the desert, that is on the last day of Sukot, or the next day." + Globals.NL2 +
                        "It ends with full reading on Shabat, or the next Shabat if Sim'hat Torah occurs on Shabat. The day after Shabat we move on to the next Parashah that we study during the week by reading comments, listening to conferences, learning about science, and examining letters, words and verses, to read it in full on Shabat. And so on from week to week to go through the Torah in a year to build a better future world for oneself, for one's family, for one's community, for one's country, for the Nations, and for the species, thanks to Pesa'h, Shavu'ot, Teru'ah, Kipurim, and Sukot." + Globals.NL2 +
                        "Israël is the conceptual worldwide land of the righteous benevolent whose body+spirit, and therefore DNA, is to some notable extent free from ignorance and evil. Sim'hat Torah means \"Joy [bestowed by the] Torah\" and a Lettriq of Sim'hat is \"Sharing of the Service which Sustains the Matter\": it is therefore the joy resulting from the beneficial help of the Torah and those which follow the laws of the country where one lives and the Doctrine of YHVH which have for one and only fundamental purpose to protect the life and the goods of the people without harming even the wicked and the criminals." + Globals.NL2 +
                        "The number of Parashot is 54 that is to say נד which is the Power of the Student and that root means To pass from the malevolent world to that of the good." + Globals.NL2 +
                        "The generation of Parashot relating to Shabatot is not guaranteed to be traditional especially as the application generates dates, although based on the lunar cycle, which can sometimes vary a little from official calendars, especially if the moon omer is used and even more with the personal Shabat.",

        [Language.FR] = "L'étude de la Parashah de la semaine débute à Sim'hat Torah avec la section Bereshit le 22 Tishri en Terre d'Israël, ou le 23 en Mitsraïm et dans le désert, soit le dernier jour de Soukot, ou le lendemain. Elle se termine par la lecture complète lors du Shabat, ou le Shabat suivant si Sim'hat Torah a lieu un Shabat." + Globals.NL2 +
                        "Le lendemain du Shabat on passe à la Parashah suivante qu'on étudie durant la semaine en lisant des commentaires, en écoutant des conférences, en s'informant sur les sciences, et en examinant les lettres, les mots et les versets, pour la lire en intégralité lors du Shabat. Et ainsi de suite de semaines en semaines afin de parcourir la Torah en un an pour de construire un monde futur meilleur pour soi, pour sa famille, pour sa communauté, pour son pays, pour les Nations, et pour l'espèce, grâce à Pessa'h, Shavou'ot, Terou'ah, Kipourim, et Soukot." + Globals.NL2 +
                        "Israël est le pays conceptuel mondial des justes bienveillants dont le corps+esprit, et donc l'ADN, est dans une certaine mesure notable libéré de l'ignorance et du mal. Sim'hat Torah signifie \"Joie [prodiguée par la] Torah\" et une lettrique de Sim'hat est \"Partage du Service qui Soutien la Matière\" : c'est donc la joie résultant de l'aide bénéfique de la Torah et de ceux qui suivent les lois du pays où l'on vit et de la Doctrine de YHVH qui ont pour seul et unique but fondamental de protéger la vie et les biens des personnes sans nuire même aux méchants et aux criminels." + Globals.NL2 +
                        "Le nombre de Parashot est 54 soit נד qui est le Pouvoir de l'Étudiant et cette racine signifie Passer du monde malveillant à celui du bien." + Globals.NL2 +
                        "La génération des Parashot relatives aux Shabatot n'est pas garantie pour être traditionnelle d'autant que l'application génère des dates, quoi que basé sur le cycle lunaire, pouvant parfois un peu varier des calendriers officiels, surtout si on utilise le omer de la lune et encore plus avec le Shabat personnel."
      };

    static public readonly TranslationsDictionary NoticeExportInterval
      = new TranslationsDictionary
      {
        [Language.EN] = "The export goes from the start year to the end year, and for each year are taken into account the Gregorian months going from Nissan of this year to Adar of the next year.",
        [Language.FR] = "L'export va de l'année de début à l'année de fin, et pour chaque année sont pris en compte les mois grégoriens allant de Nissan cette année à Adar de l'année suivante."
      };

    static public readonly TranslationsDictionary NoticeHotKey
      = new TranslationsDictionary
      {
        [Language.EN] = "The application checks the availability of the combination with the operating system. If so, it is tested in case it is captured by another application, which will trigger its activation and it will be considered invalid.",
        [Language.FR] = "L'application vérifie la disponibilité de la combinaison auprès du système d'exploitation. Dans l'affirmative, elle est testé au cas où elle serait capturé par une autre application, ce qui déclenchera son activation et elle sera considérée comme invalide."
      };

    static public readonly TranslationsDictionary NoticeAutoGenerateInterval
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

    static public readonly TranslationsDictionary NoticeDatesDiffTitle
      = new TranslationsDictionary
      {
        [Language.EN] = "Dates difference notice",
        [Language.FR] = "Notice de différence de dates"
      };

    static public readonly TranslationsDictionary NoticeDatesDiff
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

    static public readonly TranslationsDictionary NoticeLunarMonthsTitle
      = new TranslationsDictionary
      {
        [Language.EN] = "Lunar months notice",
        [Language.FR] = "Notice des mois lunaires"
      };

    static public readonly TranslationsDictionary NoticeLunarMonths
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

  }

}
