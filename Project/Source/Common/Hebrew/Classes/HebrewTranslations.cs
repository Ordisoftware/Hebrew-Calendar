/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2021 Olivier Rogier.
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
/// <edited> 2021-02 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  /// <summary>
  /// Provide localization helper.
  /// </summary>
  static public partial class HebrewTranslations
  {

    static public readonly TranslationsDictionary GrammarGuideTitle
      = new TranslationsDictionary
      {
        [Language.EN] = "Grammar guide",
        [Language.FR] = "Guide de grammaire"
      };

    static public readonly TranslationsDictionary MethodNoticeTitle
      = new TranslationsDictionary
      {
        [Language.EN] = "Lettriq analysis method notice",
        [Language.FR] = "Notice de la méthode d'analyse lettrique"
      };

    static public readonly TranslationsDictionary AskToDownload
      = new TranslationsDictionary
      {
        [Language.EN] = "Do you want to download it?",
        [Language.FR] = "Voulez-vous le télécharger ?"
      };

    static public readonly TranslationsDictionary AskToDownloadHebrewLetters
      = new TranslationsDictionary
      {
        [Language.EN] = $"Hebrew Letters not found." + Globals.NL +
                        SysTranslations.AskToCheckPreferences[Language.EN] + Globals.NL2 +
                        AskToDownload[Language.EN],

        [Language.FR] = $"Hebrew Letters n'a pas été trouvé." + Globals.NL +
                        SysTranslations.AskToCheckPreferences[Language.FR] + Globals.NL2 +
                        AskToDownload[Language.FR]
      };

    static public readonly TranslationsDictionary AskToDownloadHebrewWords
      = new TranslationsDictionary
      {
        [Language.EN] = "Hebrew Words not found." + Globals.NL +
                        SysTranslations.AskToCheckPreferences[Language.EN] + Globals.NL2 +
                        AskToDownload[Language.EN],

        [Language.FR] = "Hebrew Words n'a pas été trouvé." + Globals.NL +
                        SysTranslations.AskToCheckPreferences[Language.FR] + Globals.NL2 +
                        AskToDownload[Language.FR]
      };

    static public readonly TranslationsDictionary BoardExportFileName
      = new TranslationsDictionary
      {
        [Language.EN] = "Board {0}",
        [Language.FR] = "Board {0}"
      };

    static public readonly TranslationsDictionary ConfigureProviders
      = new TranslationsDictionary
      {
        [Language.EN] = "Configure providers",
        [Language.FR] = "Configurer les fournisseurs"
      };

    static public readonly TranslationsDictionary NoticeParashahTitle
      = new TranslationsDictionary
      {
        [Language.EN] = "Parashah notice",
        [Language.FR] = "Notice de la Parashah"
      };

    static public readonly TranslationsDictionary NoticeParashah
      = new TranslationsDictionary
      {
        [Language.EN] = "The study of the Weekly Torah portion begins at Sim'hat Torah with the Bereshit section on 22 Tishri in the Land of Israel, or on 23 in Mitsraïm and in the desert, that is on the last day of Sukot, or the next day." + Globals.NL2 +
                        "It ends with full reading on Shabat, or the next Shabat if Sim'hat Torah occurs on Shabat." + Globals.NL2 +
                        "The day after Shabat we move on to the next Parashah that we study during the week by reading comments, listening to conferences, learning about science, and examining letters, words and verses, to read it in full on Shabat." + Globals.NL2 +
                        "And so on from week to week to go through the Torah in a year to build a better future world for oneself, for one's family, for one's community, for one's country, for the Nations, and for the species, thanks to Pesa'h, Shavuot, Teru'ah, Kipurim, and Sukot.",
        [Language.FR] = "L'étude de la Parashah de la semaine débute à Sim'hat Torah avec la section Bereshit le 22 Tishri en Terre d'Israël, ou le 23 en Mitsraïm et dans le désert, soit le dernier jour de Soukot, ou le lendemain." + Globals.NL2 +
                        "Elle se termine par la lecture complète lors du Shabat, ou le Shabat suivant si Sim'hat Torah a lieu un Shabat." + Globals.NL2 +
                        "Le lendemain du Shabat on passe à la Parashah suivante qu'on étudie durant la semaine en lisant des commentaires, en écoutant des conférences, en s'informant sur les sciences, et en examinant les lettres, les mots et les versets, pour la lire en intégralité lors du Shabat." + Globals.NL2 +
                        "Et ainsi de suite de semaines en semaines afin de parcourir la Torah en un an pour de construire un monde futur meilleur pour soi, pour sa famille, pour sa communauté, pour son pays, pour les Nations, et pour l'espèce, grâce à Pessa'h, Shavouot, Terou'ah, Kipourim, et Soukot."
      };

    static public readonly TranslationsDictionary NoticeOnlineBibleprovider
      = new TranslationsDictionary
      {
        [Language.EN] = "Use the following tags to replace values:" + Globals.NL2 +
                        "%BOOKSB% : StudyBible.org book name" + Globals.NL +
                        "%BOOKBIBLEHUB% : BibleHub.org and SainteBible.com book name" + Globals.NL +
                        "%BOOKSEFARIA% : Sefaria.org book name" + Globals.NL +
                        "%BOOKCHABAD% : Chabad.org book name" + Globals.NL +
                        "%BOOKMM% : Mechon-Mamre.org book name" + Globals.NL +
                        "%BOOKDJEP% : Djep.hd.free.fr book name" + Globals.NL +
                        Globals.NL +
                        "%BOOKNUM% : Book number" + Globals.NL +
                        "%CHAPTERNUM% : Chapter number" + Globals.NL +
                        "%VERSENUM% : Verse number" + Globals.NL +
                        Globals.NL +
                        "%BOOKNUM#2% : Book number in two digits" + Globals.NL +
                        "%CHAPTERNUM#2% : Chapter number in two digits" + Globals.NL +
                        "%VERSENUM#2% : Verse number in two digits",

        [Language.FR] = "Utiliser les tags suivants pour remplacer les valeurs :" + Globals.NL2 +
                        "%BOOKSB% : Nom du livre StudyBible.org" + Globals.NL +
                        "%BOOKBIBLEHUB% : Nom du livre BibleHub.org et SainteBible.com" + Globals.NL +
                        "%BOOKSEFARIA% : Sefaria.org book name" + Globals.NL +
                        "%BOOKCHABAD% : Nom du livre Chabad.org" + Globals.NL +
                        "%BOOKMM% : Nom du livre Mechon-Mamre.org" + Globals.NL +
                        "%BOOKDJEP% : Nom du livre Djep.hd.free.fr" + Globals.NL +
                        Globals.NL +
                        "%BOOKNUM% : Numéro du livre" + Globals.NL +
                        "%CHAPTERNUM% : Numéro du chaptre" + Globals.NL +
                        "%VERSENUM% : Numéro du verset" + Globals.NL +
                        Globals.NL +
                        "%BOOKNUM#2% : Numéro du livre sur 2 digits" + Globals.NL +
                        "%CHAPTERNUM#2% : Numéro du chapitre sur 2 digits" + Globals.NL +
                        "%VERSENUM#2% : Numéro du verset sur 2 digits"
      };

  }

}
