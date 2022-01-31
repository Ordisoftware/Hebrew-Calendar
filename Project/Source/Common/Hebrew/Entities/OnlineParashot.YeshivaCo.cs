/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2022 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2021-09 </created>
/// <edited> 2021-09 </edited>
namespace Ordisoftware.Hebrew;

static partial class OnlineParashot
{

  static public readonly NullSafeDictionary<TorahBook, NullSafeList<string>> YeshivaCo = new()
  {
    [TorahBook.Bereshit] = new NullSafeList<string>
    {
      "15",
      "16",
      "17",
      "18",
      "19",
      "20",
      "21",
      "22",
      "23",
      "24",
      "25",
      "70"
    },
    [TorahBook.Shemot] = new NullSafeList<string>
    {
      "26",
      "27",
      "28",
      "29",
      "30",
      "31",
      "32",
      "33",
      "34",
      "35",
      "36"
    },
    [TorahBook.Vayiqra] = new NullSafeList<string>
    {
      "37",
      "38",
      "39",
      "40",
      "41",
      "42",
      "43",
      "44",
      "45",
      "46"
    },
    [TorahBook.Bamidbar] = new NullSafeList<string>
    {
      "47",
      "48",
      "49",
      "50",
      "51",
      "52",
      "53",
      "54",
      "55",
      "56"
    },
    [TorahBook.Devarim] = new NullSafeList<string>
    {
      "57",
      "58",
      "59",
      "60",
      "61",
      "62",
      "63",
      "64",
      "65",
      "66",
      "67"
    }
  };

}
