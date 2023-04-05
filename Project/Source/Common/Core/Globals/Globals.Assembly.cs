/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2023 Olivier Rogier.
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
/// Provides global variables.
/// </summary>
static public partial class Globals
{

  /// <summary>
  /// Gets an attribute instance.
  /// </summary>
  static private T GetAttribute<T>() where T : Attribute
  {
    var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(T), false);
    return attributes.Length > 0
      ? (T)attributes[0]
      : null;
  }

  /// <summary>
  /// Gets the assembly title.
  /// </summary>
  static public string AssemblyTitle
  {
    get
    {
      var attribute = GetAttribute<AssemblyTitleAttribute>();
      return attribute is not null && attribute.Title.Length != 0
        ? attribute.Title
        : Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
    }
  }

  /// <summary>
  /// Gets the assembly version.
  /// </summary>
  static public string AssemblyVersion
    => Assembly.GetExecutingAssembly().GetName().Version.ToString(2);

  /// <summary>
  /// Gets the assembly title with version.
  /// </summary>
  static public string AssemblyTitleWithVersion
    => $"{AssemblyTitle} {AssemblyVersion}";

  /// <summary>
  /// Gets information describing the assembly.
  /// </summary>
  static public string AssemblyDescription
    => GetAttribute<AssemblyDescriptionAttribute>()?.Description ?? string.Empty;

  /// <summary>
  /// Gets the assembly product.
  /// </summary>
  static public string AssemblyProduct
    => GetAttribute<AssemblyProductAttribute>()?.Product ?? string.Empty;

  /// <summary>
  /// Gets the assembly copyright.
  /// </summary>
  static public string AssemblyCopyright
    => GetAttribute<AssemblyCopyrightAttribute>()?.Copyright ?? string.Empty;

  /// <summary>
  /// Gets the assembly company.
  /// </summary>
  static public string AssemblyCompany
    => GetAttribute<AssemblyCompanyAttribute>()?.Company ?? string.Empty;

  /// <summary>
  /// Gets the assembly trademark.
  /// </summary>
  static public string AssemblyTrademark
    => GetAttribute<AssemblyTrademarkAttribute>()?.Trademark ?? string.Empty;

  /// <summary>
  /// Gets the assembly GUID.
  /// </summary>
  static public string AssemblyGUID
    => GetAttribute<GuidAttribute>()?.Value ?? string.Empty;

  /// <summary>
  /// Gets the assembly compiled DateTime.
  /// </summary>
  static public DateTime CompiledDateTime
    => Assembly.GetExecutingAssembly().GetLinkerTime();

}
