/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2021 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-09 </created>
/// <edited> 2021-05 </edited>
using System;
using System.IO;
using System.Linq;
using System.Net;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide SystemManager helper.
  /// </summary>
  static partial class SystemManager
  {

    /// <summary>
    /// Check the validity of the remote website SSL certificate.
    /// </summary>
    static public void CheckServerCertificate(string url)
    {
      Uri uri = new Uri(url);
      string id = Guid.NewGuid().ToString();
      var point = ServicePointManager.FindServicePoint(uri);
      var request = WebRequest.Create(uri);
      request.ConnectionGroupName = id;
      request.Timeout = WebClientEx.DefaultTimeOutSeconds * 1000;
      using ( var response = request.GetResponse() ) { }
      point.CloseConnectionGroup(id);
      if ( AuthorWebsiteSSLCertificate["Issuer"] != point.Certificate.Issuer
        || AuthorWebsiteSSLCertificate["Subject"] != point.Certificate.Subject
        /*|| AuthorWebsiteSSLCertificate["Serial"] != point.Certificate.GetSerialNumberString()
        || AuthorWebsiteSSLCertificate["PublicKey"] != point.Certificate.GetPublicKeyString()*/ )
      {
        string str1 = AuthorWebsiteSSLCertificate.Select(item => item.Key + " = " + item.Value).AsMultiLine();
        string str2 = "Issuer = " + point.Certificate.Issuer + Globals.NL +
                      "Subject = " + point.Certificate.Subject/* + Globals.NL +
                      "Serial = " + point.Certificate.GetSerialNumberString() + Globals.NL +
                      "PublicKey = " + point.Certificate.GetPublicKeyString()*/;
        string msg = SysTranslations.WrongSSLCertificate.GetLang(uri.Host, str1, str2);
        throw new UnauthorizedAccessException(msg);
      }
      if ( DateTime.Now < Convert.ToDateTime(point.Certificate.GetEffectiveDateString())
        || DateTime.Now > Convert.ToDateTime(point.Certificate.GetExpirationDateString()) )
      {
        string msg = SysTranslations.ExpiredSSLCertificate.GetLang(uri.Host,
                                                                   point.Certificate.GetEffectiveDateString(),
                                                                   point.Certificate.GetExpirationDateString());
        throw new UnauthorizedAccessException(msg);
      }
    }

    /// <summary>
    /// Indicate the application website SSL certificate information.
    /// </summary>
    static private NullSafeOfStringDictionary<string> AuthorWebsiteSSLCertificate
      = new NullSafeOfStringDictionary<string>();

    static public void LoadSSLCertificate()
    {
      if ( Globals.IsVisualStudioDesigner ) return;
      if ( File.Exists(Globals.ApplicationHomeSSLFilePath) )
        AuthorWebsiteSSLCertificate.LoadKeyValuePairs(Globals.ApplicationHomeSSLFilePath, "=>");
    }

  }

}
