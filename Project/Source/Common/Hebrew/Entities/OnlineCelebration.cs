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
/// <created> 2021-09 </created>
/// <edited> 2021-09 </edited>
using System;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  static partial class OnlineCelebration
  {

    static public readonly NullSafeDictionary<TorahCelebration, string> WikipediaEN
      = new NullSafeDictionary<TorahCelebration, string>
      {
        [TorahCelebration.Pessah] = "Passover",
        [TorahCelebration.Chavouot] = "Shavuot",
        [TorahCelebration.YomTerouah] = "Rosh_Hashanah",
        [TorahCelebration.YomHaKipourim] = "Yom_Kippur",
        [TorahCelebration.Soukot] = "Sukkot"
      };

    static public readonly NullSafeDictionary<TorahCelebration, string> WikipediaFR
      = new NullSafeDictionary<TorahCelebration, string>
      {
        [TorahCelebration.Pessah] = "Pessa'h",
        [TorahCelebration.Chavouot] = "Chavouot",
        [TorahCelebration.YomTerouah] = "Roch_Hachana",
        [TorahCelebration.YomHaKipourim] = "Yom_Kippour",
        [TorahCelebration.Soukot] = "Souccot"
      };

    static public readonly NullSafeDictionary<TorahCelebration, string> TorahOrg
      = new NullSafeDictionary<TorahCelebration, string>
      {
        [TorahCelebration.Pessah] = "passover",
        [TorahCelebration.Chavouot] = "shavuos",
        [TorahCelebration.YomTerouah] = "rosh-hashana",
        [TorahCelebration.YomHaKipourim] = "yom-kippur",
        [TorahCelebration.Soukot] = "sukkot"
      };

    static public readonly NullSafeDictionary<TorahCelebration, string> TrueTorahJews
      = new NullSafeDictionary<TorahCelebration, string>
      {
        [TorahCelebration.Pessah] = "pesach",
        [TorahCelebration.Chavouot] = "Shavuos",
        [TorahCelebration.YomTerouah] = "rosh",
        [TorahCelebration.YomHaKipourim] = "yomkippur",
        [TorahCelebration.Soukot] = "succos"
      };

    static public readonly NullSafeDictionary<TorahCelebration, string> TorahBox
      = new NullSafeDictionary<TorahCelebration, string>
      {
        [TorahCelebration.Pessah] = "pessah",
        [TorahCelebration.Chavouot] = "chavouot",
        [TorahCelebration.YomTerouah] = "roch-hachana",
        [TorahCelebration.YomHaKipourim] = "yom-kippour",
        [TorahCelebration.Soukot] = "souccot"
      };

    static public readonly NullSafeDictionary<TorahCelebration, string> _5
      = new NullSafeDictionary<TorahCelebration, string>
      {
        [TorahCelebration.Pessah] = "",
        [TorahCelebration.Chavouot] = "",
        [TorahCelebration.YomTerouah] = "",
        [TorahCelebration.YomHaKipourim] = "",
        [TorahCelebration.Soukot] = ""
      };

    static public readonly NullSafeDictionary<TorahCelebration, string> _6
      = new NullSafeDictionary<TorahCelebration, string>
      {
        [TorahCelebration.Pessah] = "",
        [TorahCelebration.Chavouot] = "",
        [TorahCelebration.YomTerouah] = "",
        [TorahCelebration.YomHaKipourim] = "",
        [TorahCelebration.Soukot] = ""
      };

    static public readonly NullSafeDictionary<TorahCelebration, string> _7
      = new NullSafeDictionary<TorahCelebration, string>
      {
        [TorahCelebration.Pessah] = "",
        [TorahCelebration.Chavouot] = "",
        [TorahCelebration.YomTerouah] = "",
        [TorahCelebration.YomHaKipourim] = "",
        [TorahCelebration.Soukot] = ""
      };

    static public readonly NullSafeDictionary<TorahCelebration, string> _8
      = new NullSafeDictionary<TorahCelebration, string>
      {
        [TorahCelebration.Pessah] = "",
        [TorahCelebration.Chavouot] = "",
        [TorahCelebration.YomTerouah] = "",
        [TorahCelebration.YomHaKipourim] = "",
        [TorahCelebration.Soukot] = ""
      };

    static public readonly NullSafeDictionary<TorahCelebration, string> _9
      = new NullSafeDictionary<TorahCelebration, string>
      {
        [TorahCelebration.Pessah] = "",
        [TorahCelebration.Chavouot] = "",
        [TorahCelebration.YomTerouah] = "",
        [TorahCelebration.YomHaKipourim] = "",
        [TorahCelebration.Soukot] = ""
      };

    static public readonly NullSafeDictionary<TorahCelebration, string> _Template
      = new NullSafeDictionary<TorahCelebration, string>
      {
        [TorahCelebration.Pessah] = "",
        [TorahCelebration.Chavouot] = "",
        [TorahCelebration.YomTerouah] = "",
        [TorahCelebration.YomHaKipourim] = "",
        [TorahCelebration.Soukot] = ""
      };

  }

}
