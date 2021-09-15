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
/// <created> 2021-03 </created>
/// <edited> 2021-03 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  static partial class OnlineParashot
  {

    static public readonly NullSafeDictionary<TorahBook, NullSafeList<string>> AishEN
      = new NullSafeDictionary<TorahBook, NullSafeList<string>>
      {
        [TorahBook.Bereshit] = new NullSafeList<string>
        {
          "43919122",
          "43919117",
          "43919112",
          "43919107",
          "43919102",
          "43919097",
          "43919087",
          "43919077",
          "43919062",
          "43919047",
          "43919042",
          "43919037"
        },
        [TorahBook.Shemot] = new NullSafeList<string>
        {
          "43919032",
          "43919027",
          "43919022",
          "43919017",
          "43919012",
          "43919007",
          "43919002",
          "43918997",
          "43918992",
          "43918987",
          "43918977"
        },
        [TorahBook.Vayiqra] = new NullSafeList<string>
        {
          "43918972",
          "43918967",
          "43918962",
          "43918957",
          "43918952",
          "43918947",
          "43918942",
          "43918937",
          "43918932",
          "43918927"
        },
        [TorahBook.Bamidbar] = new NullSafeList<string>
        {
          "43918922",
          "43918917",
          "43918912",
          "43918907",
          "43918902",
          "43918897",
          "43918892",
          "43918887",
          "43918882",
          "43918877"
        },
        [TorahBook.Devarim] = new NullSafeList<string>
        {
          "43918872",
          "43918867",
          "43918862",
          "43918857",
          "43918852",
          "43918842",
          "43918837",
          "43918832",
          "43918822",
          "43918817",
          "43918812"
        }
      };

  }

}
