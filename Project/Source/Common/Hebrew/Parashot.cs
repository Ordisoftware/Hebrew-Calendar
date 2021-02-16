/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2021 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https.//mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2021-02 </created>
/// <edited> 2021-02 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  static public class Parashot
  {

    static public readonly NullSafeDictionary<TorahBooks, NullSafeList<Parashah>> Items
      = new NullSafeDictionary<TorahBooks, NullSafeList<Parashah>>
      {
        [TorahBooks.Bereshit] = new NullSafeList<Parashah>
        {
          new Parashah(TorahBooks.Bereshit, "Bereshit", "בראשית", "1.1", "6.8"),
          new Parashah(TorahBooks.Bereshit, "Noa'h", "נח", "6.9", "11.32"),
          new Parashah(TorahBooks.Bereshit, "Lekh Lekha", "לך לך", "12.1", "17.27"),
          new Parashah(TorahBooks.Bereshit, "Vayera", "וירא", "18.1", "22.24"),
          new Parashah(TorahBooks.Bereshit, "Haye Sarah", "חיי שרה", "23.1", "25.18"),
          new Parashah(TorahBooks.Bereshit, "Toledot", "תולדות", "25.19", "28.9"),
          new Parashah(TorahBooks.Bereshit, "Vayetse", "ויצא", "28.10", "32.3"),
          new Parashah(TorahBooks.Bereshit, "Vayishla'h", "וישלח", "32.4", "36.43"),
          new Parashah(TorahBooks.Bereshit, "Vayeshev", "וישב", "37.1", "40.23"),
          new Parashah(TorahBooks.Bereshit, "Mikets", "מקץ", "41.1", "44.17"),
          new Parashah(TorahBooks.Bereshit, "Vayigash", "ויגש", "44.18", "47.27"),
          new Parashah(TorahBooks.Bereshit, "Vaye'hi", "ויחי", "47.28", "50.26")
        },
        [TorahBooks.Shemot] = new NullSafeList<Parashah>
        {
          new Parashah(TorahBooks.Shemot, "Shemot", "שמות", "1.1", "6.1"),
          new Parashah(TorahBooks.Shemot, "Vaera", "וארא", "6.2", "9.35"),
          new Parashah(TorahBooks.Shemot, "Bo", "בא", "10.1", "13.16"),
          new Parashah(TorahBooks.Shemot, "Beshala'h", "בשלח", "13.17", "17.16"),
          new Parashah(TorahBooks.Shemot, "Yitro", "יתרו", "18.1", "20.23"),
          new Parashah(TorahBooks.Shemot, "Mishpatim", "משפטים", "21.1", "24.18"),
          new Parashah(TorahBooks.Shemot, "Teroumah", "תרומה", "25.1", "27.19"),
          new Parashah(TorahBooks.Shemot, "Tetsave", "תצווה", "27.20", "30.10"),
          new Parashah(TorahBooks.Shemot, "Ki Tissa", "כי תשא", "30.11", "34.35", true),
          new Parashah(TorahBooks.Shemot, "Vayaqhel", "ויקהל", "35.1", "38.20"),
          new Parashah(TorahBooks.Shemot, "Peqoudei", "פקודי", "38.21", "40.38")
        },
        [TorahBooks.Vayiqra] = new NullSafeList<Parashah>
        {
          new Parashah(TorahBooks.Vayiqra, "Vayikra", "ויקרא", "1.1", "5.26"),
          new Parashah(TorahBooks.Vayiqra, "Tsav", "צו", "6.1", "8.36"),
          new Parashah(TorahBooks.Vayiqra, "Shemini", "שמיני", "9.1", "11.47", true),
          new Parashah(TorahBooks.Vayiqra, "Tazria", "תזריע", "12.1", "13.59"),
          new Parashah(TorahBooks.Vayiqra, "Metsora", "מצורע", "14.1", "15.33", true),
          new Parashah(TorahBooks.Vayiqra, "A'harei Mot", "אחרי מות", "16.1", "18.30"),
          new Parashah(TorahBooks.Vayiqra, "Kedoshim", "קדושים", "19.1", "20.27"),
          new Parashah(TorahBooks.Vayiqra, "Emor", "אמור", "21.1", "24.23", true),
          new Parashah(TorahBooks.Vayiqra, "Behar", "בהר", "25.1", "26.2"),
          new Parashah(TorahBooks.Vayiqra, "Be'houqotaï", "בחוקותי", "26.3", "27.34")
        },
        [TorahBooks.Bamidbar] = new NullSafeList<Parashah>
        {
          new Parashah(TorahBooks.Bamidbar, "Bamidbar", "במדבר", "1.1", "4.20"),
          new Parashah(TorahBooks.Bamidbar, "Nasso", "נשא", "4.21", "7.89"),
          new Parashah(TorahBooks.Bamidbar, "Beha'alot'kha", "בהעלותך", "8.1", "12.16"),
          new Parashah(TorahBooks.Bamidbar, "Shela'h lekha", "שלח לך", "13.1", "15.41"),
          new Parashah(TorahBooks.Bamidbar, "Kora'h", "קרח", "16.1", "18.32", true),
          new Parashah(TorahBooks.Bamidbar, "'Houkat", "חקת", "19.1", "22.1"),
          new Parashah(TorahBooks.Bamidbar, "Balaq", "בלק", "22.2", "25.9"),
          new Parashah(TorahBooks.Bamidbar, "Pin'has", "פנחס", "25.10", "30.1", true),
          new Parashah(TorahBooks.Bamidbar, "Matot", "מטות", "30.2", "32.42"),
          new Parashah(TorahBooks.Bamidbar, "Massei", "מסעי", "33.1", "36.13")
        },
        [TorahBooks.Devarim] = new NullSafeList<Parashah>
        {
          new Parashah(TorahBooks.Devarim, "Devarim", "דברים", "1.1", "3.22"),
          new Parashah(TorahBooks.Devarim, "Vaet'hanan", "ואתחנן", "3.23", "7.11"),
          new Parashah(TorahBooks.Devarim, "Eikev", "עקב", "7.12", "11.25"),
          new Parashah(TorahBooks.Devarim, "Reeh", "ראה", "11.26", "16.17"),
          new Parashah(TorahBooks.Devarim, "Shoftim", "שופטים", "16.18", "21.9"),
          new Parashah(TorahBooks.Devarim, "Ki Tetse", "כי תצא", "21.10", "25.19"),
          new Parashah(TorahBooks.Devarim, "Ki Tavo", "כי תבוא", "26.1", "29.8", true),
          new Parashah(TorahBooks.Devarim, "Nitsavim", "ניצבים", "29.9", "30.20"),
          new Parashah(TorahBooks.Devarim, "Vayelekh", "וילך", "31.1", "31.30"),
          new Parashah(TorahBooks.Devarim, "Haazinou", "האזינו", "32.1", "32.52"),
          new Parashah(TorahBooks.Devarim, "Vezot HaBerakha", "וזאת הברכה", "33.1", "34.12")
        }
      };

  }

}
