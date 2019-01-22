/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This program is free software: you can redistribute it and/or modify it under the terms of
/// the GNU Lesser General Public License (LGPL v3) as published by the Free Software Foundation,
/// either version 3 of the License, or (at your option) any later version.
/// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
/// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
/// See the GNU Lesser General Public License for more details.
/// You should have received a copy of the GNU General Public License along with this program.
/// If not, see www.gnu.org/licenses website.
/// </license>
/// <created> 2007-05 </created>
/// <edited> 2007-05 </edited>
using System;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide system manager and application information and control.
  /// </summary>
  static public partial class SystemManager
  {

    /// <summary>
    /// Add "http://" to a string if it does not start with http:// or https://.
    /// </summary>
    /// <param name="link">The link.</param>
    /// <returns>
    /// The browsable link.
    /// </returns>
    static public string MakeWebLink(string link)
    {
      if ( !link.StartsWith("http://") && !link.StartsWith("https://") ) 
        link = "http://" + link;
      return link;
    }

    /// <summary>
    /// Open a web link.
    /// </summary>
    /// <param name="link">The link.</param>
    static public void OpenWebLink(string link)
    {
      System.Diagnostics.Process.Start(MakeWebLink(link));
    }

    /// <summary>
    /// Add "mailto:" to a string if it does not start with "mailto:".
    /// </summary>
    /// <param name="link">The link.</param>
    /// <returns>
    /// The openable mail link.
    /// </returns>
    static public string MakeMailLink(string link)
    {
      if ( !link.StartsWith("mailto:") ) 
        link = "mailto:" + link;
      return link;
    }

    /// <summary>
    /// Open a mail link.
    /// </summary>
    /// <param name="link">The mail address.</param>
    static public void OpenMailLink(string link)
    {
      System.Diagnostics.Process.Start(MakeMailLink(link));
    }

  }

}
