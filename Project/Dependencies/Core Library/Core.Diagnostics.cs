/*/// <license>
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
/// <edited> 2016-04 </edited>
using System;

namespace Ordisoftware.Core.Diagnostics
{

  static public class Debugger
  {

    static public void ManageException(Exception ex)
    {
      ManageException(null, ex, true);
    }

    static public void ManageException(object sender, Exception ex)
    {
      ManageException(sender, ex, true);
    }

    static public void ManageException(object sender, Exception ex, bool doshow)
    {
      string message = ex.Message;
      var exInner = ex.InnerException;
      while ( exInner != null )
      {
        message += Environment.NewLine + Environment.NewLine + ex.InnerException;
        exInner = exInner.InnerException;
      }
      if ( doshow ) DisplayManager.Show(message);
    }

  }

}
*/