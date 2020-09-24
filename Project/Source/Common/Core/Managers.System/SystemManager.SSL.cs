/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2020 Olivier Rogier.
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
/// <edited> 2020-09 </edited>
using System;
using System.Linq;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide SystemManager helper.
  /// </summary>
  static public partial class SystemManager
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
      using ( var response = request.GetResponse() ) { }
      point.CloseConnectionGroup(id);
      if ( AuthorWebsiteSSLCertificate["Issuer"] != point.Certificate.Issuer
        || AuthorWebsiteSSLCertificate["Subject"] != point.Certificate.Subject
        || AuthorWebsiteSSLCertificate["Serial"] != point.Certificate.GetSerialNumberString()
        || AuthorWebsiteSSLCertificate["PublicKey"] != point.Certificate.GetPublicKeyString() )
      {
        string str1 = AuthorWebsiteSSLCertificate.Select(item => item.Key + " = " + item.Value).AsMultiLine();
        string str2 = "Issuer = " + point.Certificate.Issuer + Globals.NL +
                      "Subject = " + point.Certificate.Subject + Globals.NL +
                      "Serial = " + point.Certificate.GetSerialNumberString() + Globals.NL +
                      "PublicKey = " + point.Certificate.GetPublicKeyString();
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

    /// <summary>
    /// Static constructor.
    /// </summary>
    static SystemManager()
    {
      try
      {
        foreach ( string line in File.ReadAllLines(Globals.ApplicationHomeSSLFilePath) )
        {
          var parts = line.SplitNoEmptyLines(" => ");
          if ( parts.Length == 1 )
            AuthorWebsiteSSLCertificate.Add(parts[0], "");
          else
          if ( parts.Length == 2 )
            AuthorWebsiteSSLCertificate.Add(parts[0], parts[1]);
          else
          if ( parts.Length > 2 )
            AuthorWebsiteSSLCertificate.Add(parts[0], parts.Skip(1).AsMultiSpace());
        }
      }
      catch ( Exception ex )
      {
        MessageBox.Show(SysTranslations.LoadFileError.GetLang(Globals.ApplicationHomeSSLFilePath, ex.Message), 
                        Globals.AssemblyTitle, 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning);
      }
    }

  }

}
