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

  static public class Notices
  {

    static public readonly string NewLine = Environment.NewLine;

    static public readonly Dictionary<string, string> ShabatTitle
      = new Dictionary<string, string>()
      {
        { "en", "Shabat notice" },
        { "fr", "Notice du shabat" }
      };

    static public readonly Dictionary<string, string> ShabatText
      = new Dictionary<string, string>()
      {
        { "en", "The shabat is the \"day of rest\" where one do not work for a livelihood. Unless there is a vital emergency, the body, the emotions and the spirit are resting there. The study of the Torah is a privileged activity." + NewLine + NewLine +
                "The tradition attributes this day to Saturday. We can however think according to Béréshit 1.1 that in the case where the first day is the day of birth as a corollary to the fusion of the gametes then it takes place the day before: thus a person coming to the world on a Sunday will have his Shabat the Saturday. From Béréshit 1.5 and 1.16 as well as from Shémot 20.8 it can be deduced that it lasts from sunset on the eve of the calendar day to sunset on the same day. For example, for a person born in Paris, the Shabat of February 19, 2019 takes place from Friday 18 at 17:25 to Saturday at 17:25 approximately." + NewLine + NewLine +
                "The personal shabat of a maried or concubin or divorced man is the previous day of the birth. A son follows his father's shabat. The shabat of a woman is the shabat of her father or her husband or her concubin." + NewLine + NewLine +
                "So the man and the woman respect their mutual cycles. Indeed, during the period when the married or concubine or divorced woman is Nidah from the beginning to the end of the blood flow, her vital field is dissonant and the couple avoid touching each other (the virgin girl is not concerned as long as she had no relations through the openings of the begetting) to avoid to increase as well as to transmit this state to things and people (otherwise we follow the rules of the Torah about that)." + NewLine + NewLine +
                "If the man were born between midnight and the sunset, the shabat is the day before. Between sunset and midnight, the shabat is that day. This day is from previous day (or previous previous day) at sunset to this day (or previous day) at sunset." + NewLine + NewLine +
                "The day of the shabat goes from sunset on the previous calendar day to sunset of that day, with 3% of natural margin that to say about one hour." + NewLine + NewLine +
                "The day before, either the man keeps without going out and strengthens the couple during the shabat, or he goes out and lights up the couple for shabat, but on shabat he does not go out of his temple, and except in case of emergency we do not produce, transform and destroys nothing, we don't plan anything, we don't work, we don't cook, we don't shave, we don't cut, we don't make fire, we don't care about information, etc. But we can for example take part in sports, study science and play with children." + NewLine + NewLine +
                "If you prefer to use the traditional group shabat, select for example Saturday for Judaism, Sunday for Christianity or Friday for Islam."
        },
        { "fr", "Le shabat est le \"jour du repos\" où l'on ne travaille pas pour obtenir un moyen de subsistance et où l'on exerce aucune activité créatrice. A moins d'une urgence vitale, on y repose le corps, les émotions et l'esprit. L'étude de la Torah y est une activité privilégiée." + NewLine + NewLine +
                "La tradition attribue ce jour au samedi. On peut cependant penser d'après Béréshit 1.1 que dans le cas où le premier jour est le jour de la naissance en tant que corolaire à la fusion des gamètes alors il a lieu la veille : ainsi une personne venue au monde un dimanche aura son Shabat le samedi. De Béréshit 1.5 et 1.16 ainsi que de Shémot 20.8 on peut déduire qu'il dure depuis le coucher du soleil la veille du jour calendaire au coucher du soleil de ce même jour. Par exemple, pour une personne née à Paris, le Shabat du 19 février 2019 a lieu du vendredi 18 à 17h25 au samedi à 17h25 environ." + NewLine + NewLine +
                "Le shabat personnel d'un homme marié ou concubin ou divorcé est la veille du jour de la naissance. Un fils suit le shabat de son père. Le shabat d'une femme est celui de son père ou de son mari ou de son concubin." + NewLine + NewLine +
                "Ainsi l'homme et la femme respectent leurs cycles mutuels. En effet, durant la période où la femme mariée ou concubine ou divorcée est Nidah du début à la fin de l'écoulement de sang, son champ vital est dissonant et le couple évite de se toucher (la fille vierge n'est pas concernée tant qu'elle n'a pas eu de rapports par les ouvertures de l'engendrement) tant pour ne pas augmenter que transmettre cet état aux choses et aux gens (sinon on suit les règles de la Torah à ce sujet)." + NewLine + NewLine +
                "Si l'homme est né entre minuit et le coucher du soleil, le shabat est la veille. Entre le coucher du soleil et minuit, le shabat est ce jour. Ce jour est de la veille (ou veille veille) au coucher à ce jour (ou veille) au coucher." + NewLine + NewLine +
                "Le jour du shabat va du coucher du soleil lors du jour calendaire précédent au coucher de ce jour, avec 3% de marge naturelle soit environ plus ou moins une heure." + NewLine + NewLine +
                "La veille, soit l'homme garde sans sortir et renforce le couple lors du shabat, soit il sort et illumine le couple pour shabat, mais à shabat il ne sort pas de son temple, et sauf cas d'urgence on ne produit, transforme et détruit rien, on ne planifie rien, on ne travaille pas, on ne cuisine pas, on ne rase pas, on ne coupe pas, on ne fait pas de feu, on ne s'interesse pas aux informations, etc. Mais on peut par exemple faire du sport, étudier la science et jouer avec les enfants." + NewLine + NewLine +
                "Si vous préférez utiliser le shabat de groupe traditionnel, sélectionnez par exemple le samedi pour le Judaïsme, le dimanche pour le Christianisme ou le vendredi pour l'Islam."
        }
      };

    static public readonly Dictionary<string, string> CelebrationsTitle
      = new Dictionary<string, string>()
      {
        { "en", "Celebrations notice" },
        { "fr", "Notice des célébrations" }
      };

    static public readonly Dictionary<string, string> CelebrationsText
      = new Dictionary<string, string>()
      {
        { "en", "The times of the Torah's celebrations are Pesa'h or Easter which is the liberation of illusions, Shavuot or Weeks which is the gift of knowledge, Teruah or Ringtone which is the joy of being freedom, Kipurim or Atonement which is the sorrows of losses, and Sukot or Tabernacles which is the construction of the future." + NewLine + NewLine +
                "These are important moments of the lunar year in the solar cycle whose purpose is to provide a benevolent evolution of consciousness by the knowledge of the laws of the universe and of life. The Torah says to count these days according to the moon, as opposed to Shabat which is counted according to the sun." + NewLine + NewLine +
                "The application uses by default moon omer for celebrations." + NewLine + NewLine +
                "If you use moon omer then celebrations dates will be calculated according to seasons and there will be an inversion between north and south hemispheres. In this case, a day is from one moon set to the next set." + NewLine + NewLine +
                "You can use traditionnals sun days by modifying the option in the reminder, hence celebrations will be same in north and south. In this case, a day is from one sun set to the next set." },
        { "fr", "Les temps de célébration de la Torah sont Pessa'h ou Pâques qui est la libération des illusions, Shavouot ou Semaines qui est le don de la connaissance, Terouah ou Sonnerie qui est la joie d'être libéré, Kipourim ou Pénitence qui est les peines des pertes, et Soukot ou Cabanes qui est la construction du futur." + NewLine + NewLine +
                "Ce sont les moments importants de l'année lunaire au sein du cycle solaire dont la finalité est de procurer une évolution bienveillante de la conscience par la connaissance des lois de l'univers et de la vie. La Torah indique de compter ces jours selon la lune, par opposition au Shabat qui se compte selon le soleil." + NewLine + NewLine +
                "L'application utilise par défaut un omer selon la lune pour les célébrations." + NewLine + NewLine +
                "Si vous utilisez le omer de la lune alors les dates des célébrations seront calculées selon les saisons et il y aura une inversion entre les hémisphères nord et sud. Dans ce cas, un jour est du coucher de la lune au suivant." + NewLine + NewLine +
                "Vous pouvez utiliser les jours solaires traditionnels en modifiant l'option dans le rappeleur, alors les célébrations seront les mêmes pour le nord et le sud. Dans ce cas, un jour est du coucher du soleil au suivant." }
      };

  }

}
