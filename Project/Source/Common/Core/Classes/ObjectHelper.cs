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
/// <created> 2007-05 </created>
/// <edited> 2012-02 </edited>
using System;

namespace Ordisoftware.Core
{

  static class ObjectHelper
  {

    /// <summary>
    /// Convert the type of a convertible object to another type.
    /// </summary>
    /// <typeparam name="T">Convertible generic type parameter.</typeparam>
    /// <param name="obj">The obj to act on.</param>
    /// <param name="returnDefaultOnError">True to return default value in case of error, else throw it.</param>
    /// <returns>
    /// The converted object.
    /// </returns>
    static public T ConvertTo<T>(this object obj, bool returnDefaultOnError = false)
    where T : IConvertible
    {
      try
      {
        return (T)Convert.ChangeType(obj, typeof(T));
      }
      catch
      {
        if ( returnDefaultOnError )
          return default;
        else
          throw;
      }
    }

  }

}
