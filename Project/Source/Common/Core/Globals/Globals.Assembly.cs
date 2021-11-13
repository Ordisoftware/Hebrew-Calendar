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
/// <created> 2016-04 </created>
/// <edited> 2020-12 </edited>
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide global variables.
  /// </summary>
  static partial class Globals
  {

    /// <summary>
    /// Get an attribute instance.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    static private T GetAttribute<T>() where T : Attribute
    {
      object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(T), false);
      return attributes.Length > 0 ? ( (T)attributes[0] ) : null;
    }

    /// <summary>
    /// Get the assembly title.
    /// </summary>
    static public string AssemblyTitle
    {
      get
      {
        var attribute = GetAttribute<AssemblyTitleAttribute>();
        if ( attribute != null )
          if ( attribute.Title != string.Empty )
            return attribute.Title;
        return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
      }
    }

    /// <summary>
    /// Get the assembly version.
    /// </summary>
    static public string AssemblyVersion
      => Assembly.GetExecutingAssembly().GetName().Version.ToString(2);

    /// <summary>
    /// Get the assembly title with version.
    /// </summary>
    static public string AssemblyTitleWithVersion
      => AssemblyTitle + " " + AssemblyVersion;

    /// <summary>
    /// Get information describing the assembly.
    /// </summary>
    static public string AssemblyDescription
      => GetAttribute<AssemblyDescriptionAttribute>().Description;

    /// <summary>
    /// Get the assembly product.
    /// </summary>
    static public string AssemblyProduct
      => GetAttribute<AssemblyProductAttribute>().Product;

    /// <summary>
    /// Get the assembly copyright.
    /// </summary>
    static public string AssemblyCopyright
      => GetAttribute<AssemblyCopyrightAttribute>().Copyright;

    /// <summary>
    /// Get the assembly company.
    /// </summary>
    static public string AssemblyCompany
      => GetAttribute<AssemblyCompanyAttribute>().Company;

    /// <summary>
    /// Get the assembly trademark.
    /// </summary>
    static public string AssemblyTrademark
      => GetAttribute<AssemblyTrademarkAttribute>().Trademark;

    /// <summary>
    /// Get the assembly GUID.
    /// </summary>
    static public string AssemblyGUID
      => GetAttribute<GuidAttribute>().Value;

    /// <summary>
    /// Get the assembly compiled DateTime.
    /// </summary>
    static public DateTime CompiledDateTime
      => Assembly.GetExecutingAssembly().GetLinkerTime();

  }

}
