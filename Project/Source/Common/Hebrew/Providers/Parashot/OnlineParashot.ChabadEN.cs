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
/// <created> 2021-03 </created>
/// <edited> 2021-03 </edited>
namespace Ordisoftware.Hebrew;

static public partial class OnlineParashot
{

  static public readonly NullSafeDictionary<TorahBook, NullSafeList<string>> ChabadEN = new()
  {
    [TorahBook.Bereshit] = new NullSafeList<string>
    {
      "778",
      "9168",
      "9169",
      "9170",
      "9171",
      "9172",
      "9173",
      "15554",
      "15555",
      "15556",
      "15557",
      "15558"
    },
    [TorahBook.Shemot] = new NullSafeList<string>
    {
      "15559",
      "15560",
      "15561",
      "15562",
      "15563",
      "15564",
      "15565",
      "15566",
      "15567",
      "15568",
      "15570"
    },
    [TorahBook.Vayiqra] = new NullSafeList<string>
    {
      "15574",
      "15575",
      "15576",
      "15577",
      "15579",
      "15580",
      "15582",
      "15583",
      "15584",
      "15586"
    },
    [TorahBook.Bamidbar] = new NullSafeList<string>
    {
      "36466",
      "39589",
      "36744",
      "45586",
      "45591",
      "45612",
      "45614",
      "45615",
      "52598",
      "52600"
    },
    [TorahBook.Devarim] = new NullSafeList<string>
    {
      "36232",
      "36233",
      "36234",
      "36235",
      "36236",
      "36237",
      "36238",
      "36239",
      "36240",
      "36241",
      "36242"
    }
  };

}
