/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words/Pi.
/// Copyright 2012-2025 Olivier Rogier.
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
/// <edited> 2021-10 </edited>
namespace Ordisoftware.Hebrew;

/// <summary>
/// Localization strings.
/// </summary>
static public partial class HebrewTranslations
{

  static public readonly TranslationsDictionary AskToDownload = new()
  {
    [Language.EN] = "Do you want to download it?",
    [Language.FR] = "Voulez-vous le télécharger ?"
  };

  static public readonly TranslationsDictionary AskToDownloadHebrewLetters = new()
  {
    [Language.EN] = "Hebrew Letters not found." + Globals.NL +
                    SysTranslations.AskToCheckPreferences[Language.EN] + Globals.NL2 +
                    AskToDownload[Language.EN],

    [Language.FR] = "Hebrew Letters n'a pas été trouvé." + Globals.NL +
                    SysTranslations.AskToCheckPreferences[Language.FR] + Globals.NL2 +
                    AskToDownload[Language.FR]
  };

  static public readonly TranslationsDictionary AskToDownloadHebrewWords = new()
  {
    [Language.EN] = "Hebrew Words not found." + Globals.NL +
                    SysTranslations.AskToCheckPreferences[Language.EN] + Globals.NL2 +
                    AskToDownload[Language.EN],

    [Language.FR] = "Hebrew Words n'a pas été trouvé." + Globals.NL +
                    SysTranslations.AskToCheckPreferences[Language.FR] + Globals.NL2 +
                    AskToDownload[Language.FR]
  };

  static public readonly TranslationsDictionary NoticeOnlineWordProvider = new()
  {
    [Language.EN] = "Use the following tags to replace values:" + Globals.NL2 +
                    "%WORD% : the Unicode value" + Globals.NL +
                    "%FIRSTLETTER% : first letter of the Unicode value",

    [Language.FR] = "Utiliser les tags suivants pour remplacer les valeurs :" + Globals.NL2 +
                    "%WORD% : la valeur Unicode" + Globals.NL +
                    "%FIRSTLETTER% : première lettre de la valeur Unicode"
  };

  static public readonly TranslationsDictionary NoticeOnlineBibleProvider = new()
  {
    [Language.EN] = "Use the following name tags to replace values:" + Globals.NL2 +
                    "%BOOKSB% : StudyBible.org book" + Globals.NL +
                    "%BOOKBIBLEHUB% : BibleHub.org and SainteBible.com book" + Globals.NL +
                    "%BOOKSEFARIA% : Sefaria.org book" + Globals.NL +
                    "%BOOKCHABAD% : Chabad.org book" + Globals.NL +
                    "%BOOKMM% : Mechon-Mamre.org book" + Globals.NL +
                    "%BOOKDJEP% : Djep.hd.free.fr book" + Globals.NL +
                    Globals.NL +
                    "%BOOKNUM% : Book number" + Globals.NL +
                    "%CHAPTERNUM% : Chapter number" + Globals.NL +
                    "%VERSENUM% : Verse number" + Globals.NL +
                    Globals.NL +
                    "%BOOKNUM#2% : Book number in two digits" + Globals.NL +
                    "%CHAPTERNUM#2% : Chapter number in two digits" + Globals.NL +
                    "%VERSENUM#2% : Verse number in two digits",

    [Language.FR] = "Utiliser les noms de tags suivants pour remplacer les valeurs :" + Globals.NL2 +
                    "%BOOKSB% : Livre StudyBible.org" + Globals.NL +
                    "%BOOKBIBLEHUB% : Livre BibleHub.org et SainteBible.com" + Globals.NL +
                    "%BOOKSEFARIA% : Livre Sefaria.org" + Globals.NL +
                    "%BOOKCHABAD% : Livre Chabad.org" + Globals.NL +
                    "%BOOKMM% : Livre Mechon-Mamre.org" + Globals.NL +
                    "%BOOKDJEP% : Livre Djep.hd.free.fr" + Globals.NL +
                    Globals.NL +
                    "%BOOKNUM% : Numéro du livre" + Globals.NL +
                    "%CHAPTERNUM% : Numéro du chapitre" + Globals.NL +
                    "%VERSENUM% : Numéro du verset" + Globals.NL +
                    Globals.NL +
                    "%BOOKNUM#2% : Numéro du livre sur 2 digits" + Globals.NL +
                    "%CHAPTERNUM#2% : Numéro du chapitre sur 2 digits" + Globals.NL +
                    "%VERSENUM#2% : Numéro du verset sur 2 digits"
  };

}
