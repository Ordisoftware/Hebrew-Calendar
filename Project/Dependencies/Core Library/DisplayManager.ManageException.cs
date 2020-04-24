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
/// <created> 2010-11 </created>
/// <edited> 2010-11 </edited>
using System;
using Ordisoftware.Core.Diagnostics;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide multithreaded messages output and messages box.
  /// </summary>
  static public partial class DisplayManager
  {

    /// <summary>
    /// Manage an exception with the debugger.
    /// </summary>
    /// <param name="ex">The exception to act on.</param>
    static public void Manage(this Exception ex)
    {
      Debugger.ManageException(null, ex);
    }

    /// <summary>
    /// Manage an exception with the debugger.
    /// </summary>
    /// <param name="ex">The exception to act on.</param>
    /// <param name="show">true to show a message or false to hide it.</param>
    static public void Manage(this Exception ex, bool show)
    {
      Debugger.ManageException(null, ex, show);
    }

    /// <summary>
    /// Manage an exception with the debugger.
    /// </summary>
    /// <param name="ex">The exception to act on.</param>
    /// <param name="sender">Source of the event.</param>
    static public void Manage(this Exception ex, object sender)
    {
      Debugger.ManageException(sender, ex);
    }

    /// <summary>
    /// Manage an exception with the debugger.
    /// </summary>
    /// <param name="ex">The exception to act on.</param>
    /// <param name="sender">Source of the event.</param>
    /// <param name="show">true to show a message or false to hide it.</param>
    static public void Manage(this Exception ex, object sender, bool show)
    {
      Debugger.ManageException(sender, ex, show);
    }
    
  }

}
