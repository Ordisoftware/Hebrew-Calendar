/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// Project is registered at Depotnumerique.com (Agence des Depots Numeriques).
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

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide abort exception.
  /// </summary>
  [Serializable]
  public class AbortException : Exception
  {

    /// <summary>
    /// The msgcode.
    /// </summary>
    private const string msgcode = "ThreadAbort";

    /// <summary>
    /// The argname.
    /// </summary>
    private const string argname = "Message";

    /// <summary>
    /// Default constructor.
    /// </summary>
    public AbortException()
      : base(msgcode)
    {
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="message">The message.</param>
    public AbortException(string message)
      : base(msgcode)
    {
      Data.Add(argname, message);
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="inner">The inner.</param>
    public AbortException(string message, Exception inner)
      : base(msgcode, inner)
    {
      Data.Add(argname, message);
    }

  }

}
