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
/// <edited> 2012-12 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides object helper.
/// </summary>
static class ObjectHelper
{

  /// <summary>
  /// Gets an IEnumerable<typeparamref name="T"/> from a ComboBox.Items collection.
  /// </summary>
  /// <typeparam name="T">Generic type parameter.</typeparam>
  /// <param name="collection">The collection.</param>
  static public IEnumerable<T> AsIEnumerable<T>(this ComboBox.ObjectCollection collection)
  {
    foreach ( T item in collection )
      yield return item;
  }

  /// <summary>
  /// Converts the type of a convertible object to another type.
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
    catch when ( returnDefaultOnError )
    {
      return default;
    }
  }

  /// <summary>
  /// A bool extension method that determine if one is true and some others not.
  /// </summary>
  /// <param name="first">The first to act on.</param>
  /// <param name="others">A variable-length parameters list containing others.</param>
  /// <returns>
  /// True if it succeeds, false if it fails.
  /// </returns>
  static public bool CheckIfOneIsTrueAndSomeOthersNot(this bool first, params bool[] others)
  {
    return CheckIfOneIsTrueAndSomeOthersNot(( new bool[] { first } ).Concat(others).ToArray());
  }

  /// <summary>
  /// A bool extension method that determine if one is true and some others not.
  /// </summary>
  /// <param name="values">A variable-length parameters list containing values.</param>
  /// <returns>
  /// True if it succeeds, false if it fails.
  /// </returns>
  static public bool CheckIfOneIsTrueAndSomeOthersNot(params bool[] values)
  {
    bool firstIsTrue = values[0];
    bool result = firstIsTrue ^ values[1];
    if ( values.Length > 2 )
      for ( int index = 2; index < values.Length; index++ )
        result = result || ( firstIsTrue ^ values[index] );
    return result;
  }

}
