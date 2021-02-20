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
/// <created> 2021-02 </created>
/// <edited> 2021-02 </edited>
using System;
using System.IO;
using System.Linq;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  public partial class Parashah
  {

    static Parashah()
    {
      LoadTranslations();
    }

    static public void LoadTranslations()
    {
      var query = from book in Defaults
                  from parashah in book.Value
                  select parashah;
      var linesTranslation = new NullSafeOfStringDictionary<string>();
      var linesLettriq = new NullSafeOfStringDictionary<string>();
      linesTranslation.LoadKeyValuePairs(HebrewGlobals.ParashotTranslationsFilePath, " = ");
      linesLettriq.LoadKeyValuePairs(HebrewGlobals.ParashotLettriqsFilePath, " = ");
      int index = 0;
      foreach ( Parashah item in query )
      {
        if ( index < linesTranslation.Count ) item.Translation = linesTranslation.Values.ElementAt(index);
        if ( index < linesLettriq.Count ) item.Lettriq = linesLettriq.Values.ElementAt(index);
        index++;
      }
    }

    static public readonly NullSafeDictionary<TorahBooks, NullSafeList<Parashah>> Defaults
      = new NullSafeDictionary<TorahBooks, NullSafeList<Parashah>>
      {
        [TorahBooks.Bereshit] = new NullSafeList<Parashah>
        {
          new Parashah(TorahBooks.Bereshit, 01, "Bereshit", "בראשית", "1.1", "6.8"),
          new Parashah(TorahBooks.Bereshit, 02, "Noa'h", "נח", "6.9", "11.32"),
          new Parashah(TorahBooks.Bereshit, 03, "Lek Leka", "לך לך", "12.1", "17.27"),
          new Parashah(TorahBooks.Bereshit, 04, "Vayera", "וירא", "18.1", "22.24"),
          new Parashah(TorahBooks.Bereshit, 05, "Haye Sarah", "חיי שרה", "23.1", "25.18"),
          new Parashah(TorahBooks.Bereshit, 06, "Toledot", "תולדות", "25.19", "28.9"),
          new Parashah(TorahBooks.Bereshit, 07, "Vayetse", "ויצא", "28.10", "32.3"),
          new Parashah(TorahBooks.Bereshit, 08, "Vayishla'h", "וישלח", "32.4", "36.43"),
          new Parashah(TorahBooks.Bereshit, 09, "Vayeshev", "וישב", "37.1", "40.23"),
          new Parashah(TorahBooks.Bereshit, 10, "Mikets", "מקץ", "41.1", "44.17"),
          new Parashah(TorahBooks.Bereshit, 11, "Vayigash", "ויגש", "44.18", "47.27"),
          new Parashah(TorahBooks.Bereshit, 12, "Vaye'hi", "ויחי", "47.28", "50.26")
        },
        [TorahBooks.Shemot] = new NullSafeList<Parashah>
        {
          new Parashah(TorahBooks.Shemot, 01, "Shemot", "שמות", "1.1", "6.1"),
          new Parashah(TorahBooks.Shemot, 02, "Vaera", "וארא", "6.2", "9.35"),
          new Parashah(TorahBooks.Shemot, 03, "Bo", "בא", "10.1", "13.16"),
          new Parashah(TorahBooks.Shemot, 04, "Beshala'h", "בשלח", "13.17", "17.16"),
          new Parashah(TorahBooks.Shemot, 05, "Yitro", "יתרו", "18.1", "20.23"),
          new Parashah(TorahBooks.Shemot, 06, "Mishpatim", "משפטים", "21.1", "24.18"),
          new Parashah(TorahBooks.Shemot, 07, "Teroumah", "תרומה", "25.1", "27.19"),
          new Parashah(TorahBooks.Shemot, 08, "Tetsave", "תצווה", "27.20", "30.10"),
          new Parashah(TorahBooks.Shemot, 09, "Ki Tissa", "כי תשא", "30.11", "34.35"),
          new Parashah(TorahBooks.Shemot, 10, "Vayaqhel", "ויקהל", "35.1", "38.20", true),
          new Parashah(TorahBooks.Shemot, 11, "Peqoudei", "פקודי", "38.21", "40.38")
        },
        [TorahBooks.Vayiqra] = new NullSafeList<Parashah>
        {
          new Parashah(TorahBooks.Vayiqra, 01, "Vayikra", "ויקרא", "1.1", "5.26"),
          new Parashah(TorahBooks.Vayiqra, 02, "Tsav", "צו", "6.1", "8.36"),
          new Parashah(TorahBooks.Vayiqra, 03, "Shemini", "שמיני", "9.1", "11.47"),
          new Parashah(TorahBooks.Vayiqra, 04, "Tazria", "תזריע", "12.1", "13.59", true),
          new Parashah(TorahBooks.Vayiqra, 05, "Metsora", "מצורע", "14.1", "15.33"),
          new Parashah(TorahBooks.Vayiqra, 06, "A'harei Mot", "אחרי מות", "16.1", "18.30", true),
          new Parashah(TorahBooks.Vayiqra, 07, "Kedoshim", "קדושים", "19.1", "20.27"),
          new Parashah(TorahBooks.Vayiqra, 08, "Emor", "אמור", "21.1", "24.23"),
          new Parashah(TorahBooks.Vayiqra, 09, "Behar", "בהר", "25.1", "26.2", true),
          new Parashah(TorahBooks.Vayiqra, 10, "Be'houqotaï", "בחוקותי", "26.3", "27.34")
        },                                  
        [TorahBooks.Bamidbar] = new NullSafeList<Parashah>
        {
          new Parashah(TorahBooks.Bamidbar, 01, "Bamidbar", "במדבר", "1.1", "4.20"),
          new Parashah(TorahBooks.Bamidbar, 02, "Nasso", "נשא", "4.21", "7.89"),
          new Parashah(TorahBooks.Bamidbar, 03, "Beha'alotka", "בהעלותך", "8.1", "12.16"),
          new Parashah(TorahBooks.Bamidbar, 04, "Shela'h leka", "שלח לך", "13.1", "15.41"),
          new Parashah(TorahBooks.Bamidbar, 05, "Kora'h", "קרח", "16.1", "18.32"),
          new Parashah(TorahBooks.Bamidbar, 06, "'Houkat", "חקת", "19.1", "22.1", true),
          new Parashah(TorahBooks.Bamidbar, 07, "Balaq", "בלק", "22.2", "25.9"),
          new Parashah(TorahBooks.Bamidbar, 08, "Pin'has", "פנחס", "25.10", "30.1"),
          new Parashah(TorahBooks.Bamidbar, 09, "Matot", "מטות", "30.2", "32.42", true),
          new Parashah(TorahBooks.Bamidbar, 10, "Massei", "מסעי", "33.1", "36.13")
        },                                   
        [TorahBooks.Devarim] = new NullSafeList<Parashah>
        {
          new Parashah(TorahBooks.Devarim, 01, "Devarim", "דברים", "1.1", "3.22"),
          new Parashah(TorahBooks.Devarim, 02, "Vaet'hanan", "ואתחנן", "3.23", "7.11"),
          new Parashah(TorahBooks.Devarim, 03, "Eikev", "עקב", "7.12", "11.25"),
          new Parashah(TorahBooks.Devarim, 04, "Reeh", "ראה", "11.26", "16.17"),
          new Parashah(TorahBooks.Devarim, 05, "Shoftim", "שופטים", "16.18", "21.9"),
          new Parashah(TorahBooks.Devarim, 06, "Ki Tetse", "כי תצא", "21.10", "25.19"),
          new Parashah(TorahBooks.Devarim, 07, "Ki Tavo", "כי תבוא", "26.1", "29.8"),
          new Parashah(TorahBooks.Devarim, 08, "Nitsavim", "ניצבים", "29.9", "30.20", true),
          new Parashah(TorahBooks.Devarim, 09, "Vayelekh", "וילך", "31.1", "31.30"),
          new Parashah(TorahBooks.Devarim, 10, "Haazinou", "האזינו", "32.1", "32.52"),
          new Parashah(TorahBooks.Devarim, 11, "Vezot HaBerakah", "וזאת הברכה", "33.1", "34.12")
        }
      };

  }

}
