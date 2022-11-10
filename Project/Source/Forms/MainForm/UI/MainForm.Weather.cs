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
/// <created> 2021-01 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew.Calendar;

using Newtonsoft.Json.Linq;

partial class MainForm
{

  private void OpenOnlineWeather()
  {
    switch ( Settings.WeatherOnlineProvider )
    {
      case WeatherProvider.MeteoblueDotCom:
        DoOnlineWeatherMeteoBlueDotCom();
        break;
      case WeatherProvider.WeatherDotCom:
        DoOnlineWeatherWeatherDotCom();
        break;
      case WeatherProvider.MicrosoftNetworkDotCom:
        DoMicrosoftNetworkDotCom();
        break;
      default:
        throw new AdvNotImplementedException(Settings.WeatherOnlineProvider);
    }
  }

  static private class WeatherProviders
  {
    // Meteoblue
    public const string MeteoblueDotComQueryDay = "current";
    public const string MeteoblueDotComQueryWeek = "week";
    public const string MeteoblueDotComQuery = "https://www.meteoblue.com/server/search/query3?query=%LAT%%20%LON%";
    public const string MeteoblueDotComResult = "https://www.meteoblue.com/weather/%MODE%/%LOCATION%";
    // Weather
    public const string WeatherDotComQueryDay = "today";
    public const string WeatherDotComQueryWeek = "tenday";
    public const string WeatherDotComResult = "https://weather.com/%LANG%/weather/%MODE%/l/%LAT%,%LON%";
    // MSN
    public const string MicrosoftNetworkDotComResult = "https://a.msn.com/54/%LANG%/ct%LAT%,%LON%";
  }

  private void DoOnlineWeatherWeatherDotCom()
  {
    string cmd = WeatherProviders.WeatherDotComResult
                                 .Replace("%LANG%", Languages.CurrentCode)
                                 .Replace("%LAT%", Settings.GPSLatitude)
                                 .Replace("%LON%", Settings.GPSLongitude)
                                 .Replace("%MODE%", Settings.WeatherOnlineUseDay
                                                    ? WeatherProviders.WeatherDotComQueryDay
                                                    : WeatherProviders.WeatherDotComQueryWeek);
    SystemManager.RunShell(cmd);
  }

  private void DoOnlineWeatherMeteoBlueDotCom()
  {
    string server = new Uri(WeatherProviders.MeteoblueDotComResult).Host;
    string url = WeatherProviders.MeteoblueDotComQuery;
    url = url.Replace("%LAT%", Settings.GPSLatitude).Replace("%LON%", Settings.GPSLongitude);
    using var client = new WebClient();
    JObject data = null;
    string json = string.Empty;
    try
    {
      json = client.DownloadString(url);
      data = JObject.Parse(json);
    }
    catch ( Exception ex )
    {
      string msg = ex.Message;
      if ( ex.InnerException is not null )
        msg += Globals.NL2 + ex.InnerException.Message;
      msg += Globals.NL2 + url;
      if ( !string.IsNullOrEmpty(json) )
        msg += Globals.NL2 + json;
      DisplayManager.ShowError(AppTranslations.OnlineWeatherError.GetLang(server, msg));
      return;
    }
    string location = string.Empty;
    var results = data["results"];
    if ( results?.Any() == true )
      location = results[0]["url"]?.ToString();
    if ( !string.IsNullOrEmpty(location) )
    {
      string cmd = WeatherProviders.MeteoblueDotComResult
                                   .Replace("%LOCATION%", location)
                                   .Replace("%MODE%", Settings.WeatherOnlineUseDay
                                                      ? WeatherProviders.MeteoblueDotComQueryDay
                                                      : WeatherProviders.MeteoblueDotComQueryWeek);
      SystemManager.RunShell(cmd);
    }
    else
    {
      string msg = AppTranslations.OnlineWeatherLocationNotFound.GetLang();
      DisplayManager.ShowError(AppTranslations.OnlineWeatherError.GetLang(server, msg));
    }
  }

  private void DoMicrosoftNetworkDotCom()
  {
    string cmd = WeatherProviders.MicrosoftNetworkDotComResult
                                 .Replace("%LANG%", Thread.CurrentThread.CurrentCulture.ToString())
                                 .Replace("%LAT%", Settings.GPSLatitude)
                                 .Replace("%LON%", Settings.GPSLongitude);
    SystemManager.RunShell(cmd);
  }

}
