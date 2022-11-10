/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2022 Olivier Rogier.
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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides web client with timeout.
/// </summary>
public class WebClientEx : WebClient
{

  static public int DefaultTimeOutSeconds { get; set; } = 5;

  public int TimeOutSeconds { get; set; }

  public WebClientEx(int timeOutSeconds = 0)
  {
    if ( timeOutSeconds <= 0 ) timeOutSeconds = DefaultTimeOutSeconds;
    TimeOutSeconds = timeOutSeconds;
  }

  protected override WebRequest GetWebRequest(Uri address)
  {
    var result = base.GetWebRequest(address);
    result.Timeout = TimeOutSeconds * 1000;
    return result;
  }

}
