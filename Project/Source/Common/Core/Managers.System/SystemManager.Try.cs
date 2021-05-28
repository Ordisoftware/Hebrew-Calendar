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
/// <edited> 2021-05 </edited>
using System;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide system manager.
  /// </summary>
  static partial class SystemManager
  {

    /// <summary>
    /// Call an action without raising exceptions.
    /// </summary>
    static public bool TryCatch(Action action)
    {
      try
      {
        action();
        return true;
      }
      catch ( Exception ex )
      {
        ex.Manage(ShowExceptionMode.None);
        return false;
      }
    }

    /// <summary>
    /// Call an action without raising exceptions.
    /// </summary>
    static public bool TryCatchManage(Action action)
    {
      try
      {
        action();
        return true;
      }
      catch ( Exception ex )
      {
        ex.Manage();
        return false;
      }
    }

    /// <summary>
    /// Call an action without raising exceptions.
    /// </summary>
    static public bool TryCatchManage(ShowExceptionMode mode, Action action)
    {
      try
      {
        action();
        return true;
      }
      catch ( Exception ex )
      {
        ex.Manage(mode);
        return false;
      }
    }


  }

}
