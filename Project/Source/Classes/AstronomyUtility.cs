/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
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
/// <edited> 2019-01 </edited>
using System;
using System.Xml;
using System.Globalization;
using Keith_Burnett_moonr2cs;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Provide sun and moon rise and set structure.
  /// </summary>
  public struct Ephemeris
  {
    public TimeSpan? Sunrise;
    public TimeSpan? Sunset;
    public TimeSpan? Moonrise;
    public TimeSpan? Moonset;
  }

  /// <summary>
  /// Provide astronomy utility.
  /// </summary>
  static public class AstronomyUtility
  {

    /// <summary>
    /// Indicate the japanese calendar instance.
    /// </summary>
    static public readonly VietnameseCalendar LunisolerCalendar 
      = new VietnameseCalendar();

    /// <summary>
    /// Indicate the SunMoon instance.
    /// </summary>
    static public readonly SunMoon SunMoon 
      = new SunMoon();

    /// <summary>
    /// Get the sun and moon ephemeris.
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>
    /// The ephemeris.
    /// </returns>
    static public Ephemeris GetSunMoonEphemeris(DateTime date)
    {
      TimeSpan? calcEphem(string str)
      {
        if ( str == "2400" ) str = "0000";
        return str != "----"
          ? new TimeSpan(Convert.ToInt32(str.Substring(0, 2)), Convert.ToInt32(str.Substring(2, 2)), 0)
          : new Nullable<TimeSpan>();
      }
      TimeZoneInfo timezoneinfo = null;
      var timezoneinfos = TimeZoneInfo.GetSystemTimeZones();
      foreach ( var item in timezoneinfos )
        if ( item.Id == Program.Settings.TimeZone )
          timezoneinfo = item;
      if ( timezoneinfo == null )
        throw new InvalidTimeZoneException();
      var timezone = timezoneinfo.BaseUtcOffset.Hours + ( timezoneinfo.IsDaylightSavingTime(date) ? 1 : 0 );
      var strEphem = SunMoon.Get(date.Year, date.Month, date.Day,
                                 (float)XmlConvert.ToDouble(Program.Settings.GPSLatitude),
                                 (float)XmlConvert.ToDouble(Program.Settings.GPSLongitude),
                                 timezone,
                                 1);
      TimeSpan? sunRiseTime = calcEphem(strEphem.Substring(10, 4));
      TimeSpan? sunSetTime = calcEphem(strEphem.Substring(15, 4));
      TimeSpan? moonRiseTime = calcEphem(strEphem.Substring(51, 4));
      TimeSpan? moonSetTime = calcEphem(strEphem.Substring(56, 4));
      return new Ephemeris()
      {
        Sunrise = sunRiseTime,
        Sunset = sunSetTime,
        Moonrise = moonRiseTime,
        Moonset = moonSetTime
      };
    }

    /// <summary>
    /// Get the moon phase type.
    /// </summary>
    /// <remarks>
    /// Adapted from http://jivebay.com/2008/09/07/calculating-the-moon-phase.
    /// </remarks>
    /// <param name="year">The year.</param>
    /// <param name="month">The month.</param>
    /// <param name="day">The day.</param>
    /// <returns>
    /// The moon phase.
    /// </returns>
    static public MoonPhaseType GetMoonPhase(int year, int month, int day)
    {
      if ( month < 3 ) { year--; month += 12; }
      month++;
      double julian = ( ( 365.25 * year ) + ( 30.6 * month ) + day - 694039.09 ) / 29.5305882;
      int result = (int)Math.Round(( julian - (int)julian ) * 8);
      return result > 7 ? MoonPhaseType.New : (MoonPhaseType)result;
    }

  }

}
