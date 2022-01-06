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
/// <created> 2016-04 </created>
/// <edited> 2019-10 </edited>
namespace Ordisoftware.Hebrew.Calendar;

using Keith_Burnett_moonr2cs;

/// <summary>
/// Provides astronomy helper.
/// </summary>
static class AstronomyHelper
{

  /// <summary>
  /// Indicates the system lunisolar calendar instance.
  /// </summary>
  static public readonly VietnameseCalendar LunisolerCalendar = new();

  /// <summary>
  /// Indicates the SunMoon instance.
  /// </summary>
  static public readonly SunMoon SunMoon = new();

  /// <summary>
  /// Gets the moon phase type.
  /// </summary>
  /// <remarks>
  /// Adapted from http://jivebay.com/2008/09/07/calculating-the-moon-phase.
  /// </remarks>
  /// <param name="date">The date.</param>
  /// <returns>
  /// The moon phase.
  /// </returns>
  static public MoonPhase GetMoonPhase(this DateTime date)
  {
    int year = date.Year;
    int month = date.Month;
    int day = date.Day;
    if ( month < 3 )
    {
      year--;
      month += 12;
    }
    month++;
    double julian = ( ( 365.25 * year ) + ( 30.6 * month ) + day - 694039.09 ) / 29.5305882;
    int result = (int)Math.Round(( julian - (int)julian ) * 8);
    return result > 7 ? MoonPhase.New : (MoonPhase)result;
  }

  /// <summary>
  /// Gets the sun and moon ephemeris.
  /// </summary>
  /// <param name="date">The date.</param>
  /// <returns>
  /// The ephemeris.
  /// </returns>
  static public SunAndMoonRiseAndSet GetSunMoonEphemeris(this DateTime date)
  {
    static TimeSpan? calcEphem(string str)
    {
      if ( str == "2400" ) str = "0000";
      try
      {
        return str != "----" && str != "****" && str != "...."
               ? new TimeSpan(Convert.ToInt32(str.Substring(0, 2)), Convert.ToInt32(str.Substring(2, 2)), 0)
               : new TimeSpan?();
      }
      catch
      {
        return new TimeSpan?();
      }
    }
    if ( MainForm.Instance.CurrentTimeZoneInfo == null )
      throw new InvalidTimeZoneException();
    int timezone = MainForm.Instance.CurrentTimeZoneInfo.BaseUtcOffset.Hours +
                   ( MainForm.Instance.CurrentTimeZoneInfo.IsDaylightSavingTime(date.AddDays(1)) ? 1 : 0 );
    var strEphem = SunMoon.Get(date.Year, date.Month, date.Day,
                               MainForm.Instance.CurrentGPSLatitude,
                               MainForm.Instance.CurrentGPSLongitude,
                               timezone,
                               1);
    return new SunAndMoonRiseAndSet()
    {
      Sunrise = calcEphem(strEphem.Substring(10, 4)),
      Sunset = calcEphem(strEphem.Substring(15, 4)),
      Moonrise = calcEphem(strEphem.Substring(51, 4)),
      Moonset = calcEphem(strEphem.Substring(56, 4))
    };
  }

}
