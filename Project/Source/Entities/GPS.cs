/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2022 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2019-10 </created>
/// <edited> 2020-12 </edited>
namespace Ordisoftware.Hebrew.Calendar;

class CityItem
{
  public string Name;
  public string Latitude;
  public string Longitude;
  public override string ToString() => Name;
}

[IgnoreFirst(1)]
[DelimitedRecord(",")]
class WorldCities
{
  [FieldQuoted] public string city;
  [FieldQuoted] public string city_ascii;
  [FieldQuoted] public string lat;
  [FieldQuoted] public string lng;
  [FieldQuoted] public string country;
  [FieldQuoted] public string iso2;
  [FieldQuoted] public string iso3;
  [FieldQuoted] public string admin_name;
  [FieldQuoted] public string capital;
  [FieldQuoted] public string population;
  [FieldQuoted] public string id;
}
