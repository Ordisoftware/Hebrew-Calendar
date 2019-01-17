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
/// <edited> 2012-02 </edited>
using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide functions to manipulate objects.
  /// </summary>
  static public partial class ObjectUtility
  {

    /// <summary>
    /// Convert a boolean to an integer.
    /// </summary>
    /// <param name="value">The value to act on.</param>
    /// <returns>
    /// value as an int.
    /// </returns>
    static public int ToInt(this bool value)
    {
      return value ? 1 : 0;
    }

    /// <summary>
    /// Convert an integer to boolean.
    /// </summary>
    /// <param name="value">The value to act on.</param>
    /// <returns>
    /// value as a boolean.
    /// </returns>
    static public bool ToBool(this int value)
    {
      return value == 0 ? false : true;
    }

    /// <summary>
    /// Swap two values.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="value1">[in,out] The first value.</param>
    /// <param name="value2">[in,out] The second value.</param>
    static public void Swap<T>(ref T value1, ref T value2)
    {
      T temp = value1;
      value1 = value2;
      value2 = temp;
    }

    /// <summary>
    /// Convert the type of a convertible object to another type.
    /// </summary>
    /// <typeparam name="T">Convertible generic type parameter.</typeparam>
    /// <param name="obj">The obj to act on.</param>
    /// <returns>
    /// The converted object.
    /// </returns>
    static public T ConvertTo<T>(this object obj) where T : IConvertible
    {
      return (T)Convert.ChangeType(obj, typeof(T));
    }

    /// <summary>
    /// Convert the type of a convertible object to another type.
    /// </summary>
    /// <typeparam name="T">Convertible generic type parameter.</typeparam>
    /// <param name="obj">The obj to act on.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>
    /// The converted object.
    /// </returns>
    static private T ConvertTo<T>(object obj, IFormatProvider provider) where T : IConvertible
    {
      return (T)Convert.ChangeType(obj, typeof(T), provider);
    }

    /// <summary>
    /// Do an indexed loop on an enumerable object.
    /// </summary>
    /// <typeparam name="T">Enumerable generic type parameter.</typeparam>
    /// <param name="list">The list to act on.</param>
    /// <param name="process">The process that take (index, item) and return true if continue or
    /// false to break.</param>
    static public void ForEach<T>(this IEnumerable<T> list, Func<int, T, bool> process)
    {
      int index = 0;
      foreach (T item in list) process(index++, item);
    }

    /// <summary>
    /// Indicate if a string is in a list.
    /// </summary>
    /// <typeparam name="T">Comparable generic type parameter.</typeparam>
    /// <param name="obj">The obj to act on.</param>
    /// <param name="list">The list to act on.</param>
    /// <returns>
    /// true if in list, false if not.
    /// </returns>
    static public bool IsInList<T>(this T obj, params T[] list) where T : IComparable<T>
    {
      foreach ( T value in list ) if ( obj.CompareTo(value) == 0 ) return true;
      return false;
    }

    /// <summary>
    /// Indicate if a value is in bounds.
    /// </summary>
    /// <typeparam name="T">Comparable generic type parameter.</typeparam>
    /// <param name="value">The value to act on.</param>
    /// <param name="min">The minimum.</param>
    /// <param name="max">The maximum.</param>
    /// <returns>
    /// true if in bound, false if not.
    /// </returns>
    static public bool IsInBound<T>(this T value, T min, T max) where T : IComparable
    {
      if ( min.CompareTo(max) > 0 ) Swap(ref min, ref max);
      return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
    }

    /// <summary>
    /// Set a value in bounds.
    /// </summary>
    /// <remarks>
    /// Value is not changed if min = max = default(T).
    /// </remarks>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="value">The value to act on.</param>
    /// <param name="min">The minimum.</param>
    /// <param name="max">The maximum.</param>
    /// <returns>
    /// A T.
    /// </returns>
    static public T SetInBound<T>(this T value, T min, T max) where T : IComparable
    {
      if ( min.CompareTo(max) == 0 && min.CompareTo(default(T)) == 0 ) return value;
      T res = value;
      if ( min.CompareTo(max) > 0 ) Swap(ref min, ref max);
      if ( value.CompareTo(min) < 0 ) res = min;
      if ( value.CompareTo(max) > 0 ) res = max;
      return res;
    }

    /// <summary>
    /// Indicate if a enum value is in a list.
    /// </summary>
    /// <param name="value">The value to act on.</param>
    /// <param name="list">The list to act on.</param>
    /// <returns>
    /// true if enum in list, false if not.
    /// </returns>
    static public bool IsEnumInList(this Enum value, params Enum[] list) //where T : IConvertible
    {
      switch ( value.GetTypeCode() )
      {
        case TypeCode.Byte:
          foreach ( Enum v in list )
            if ( Convert.ToByte(value) == Convert.ToByte(v) ) return true;
          break;
        case TypeCode.UInt16:
          foreach ( Enum v in list )
            if ( Convert.ToUInt16(value) == Convert.ToUInt16(v) ) return true;
          break;
        case TypeCode.UInt32:
          foreach ( Enum v in list )
            if ( Convert.ToUInt32(value) == Convert.ToUInt32(v) ) return true;
          break;
        case TypeCode.UInt64:
          foreach ( Enum v in list )
            if ( Convert.ToUInt64(value) == Convert.ToUInt64(v) ) return true;
          break;
        case TypeCode.SByte:
          foreach ( Enum v in list )
            if ( Convert.ToSByte(value) == Convert.ToSByte(v) ) return true;
          break;
        case TypeCode.Int16:
          foreach ( Enum v in list )
            if ( Convert.ToInt16(value) == Convert.ToInt16(v) ) return true;
          break;
        case TypeCode.Int32:
          foreach ( Enum v in list )
            if ( Convert.ToInt32(value) == Convert.ToInt32(v) ) return true;
          break;
        case TypeCode.Int64:
          foreach ( Enum v in list )
            if ( Convert.ToInt64(value) == Convert.ToInt64(v) ) return true;
          break;
        default:
          throw new NotImplementedException(value.GetTypeCode().ToString());
      }
      return false;
    }

    /// <summary>
    /// Indicate if a enum flag is set.
    /// </summary>
    /// <param name="value">The value to act on.</param>
    /// <param name="option">An enum constant representing the option option.</param>
    /// <returns>
    /// true if flag is set, false if not.
    /// </returns>
    static public bool HasFlag(this Enum value, Enum option)
    {
      switch ( value.GetTypeCode() )
      {
        case TypeCode.SByte:
          long sbval = Convert.ToSByte(value);
          long sbopt = Convert.ToSByte(option);
          return (sbval & sbopt) != 0;
        case TypeCode.Byte:
          ulong bval = Convert.ToByte(value);
          ulong bopt = Convert.ToByte(option);
          return (bval & bopt) != 0;
        case TypeCode.Int16:
          long sval = Convert.ToInt16(value);
          long sopt = Convert.ToInt16(option);
          return (sval & sopt) != 0;
        case TypeCode.Int32:
          long ival = Convert.ToInt32(value);
          long iopt = Convert.ToInt32(option);
          return (ival & iopt) != 0;
        case TypeCode.UInt16:
          ulong usval = Convert.ToUInt16(value);
          ulong usopt = Convert.ToUInt16(option);
          return (usval & usopt) != 0;
        case TypeCode.UInt32:
          ulong uival = Convert.ToUInt32(value);
          ulong uiopt = Convert.ToUInt32(option);
          return (uival & uiopt) != 0;
        case TypeCode.Int64:
          long lval = Convert.ToInt64(value);
          long lopt = Convert.ToInt64(option);
          return (lval & lopt) != 0;
        case TypeCode.UInt64:
          ulong ulval = Convert.ToUInt64(value);
          ulong ulopt = Convert.ToUInt64(option);
          return (ulval & ulopt) != 0;
        default:
          throw new NotImplementedException(value.GetTypeCode().ToString());
      }
    }

    /// <summary>
    /// Add an item to a list without duplicates.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="list">The list to act on.</param>
    /// <param name="item">The item.</param>
    static public void AddNoDuplicates<T>(this IList<T> list, T item)
    {
      if ( !list.Contains(item) ) list.Add(item);
    }

    /// <summary>
    /// Add a collection to a list without duplicates.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="list">The list to act on.</param>
    /// <param name="collection">The collection.</param>
    static public void AddRangeNoDuplicates<T>(this IList<T> list, IEnumerable<T> collection)
    {
      foreach ( T v in collection )
        if ( !list.Contains(v) ) list.Add(v);
    }

    /// <summary>
    /// An Array extension method that converts an array to a list.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="array">The array to act on.</param>
    /// <returns>
    /// array as a List&lt;T&gt;
    /// </returns>
    static public List<T> ToList<T>(this Array array)
    {
      return array.Cast<T>().ToList();
    }

    /// <summary>
    /// Create a new allocated list.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="count">Number of.</param>
    /// <returns>
    /// A List&lt;T&gt;
    /// </returns>
    static public List<T> NewAllocatedList<T>(int count) where T : new()
    {
      var result = new List<T>(count);
      for ( int i = 0; i < count; i++ ) result.Add(new T());
      return result;
    }

    /// <summary>
    /// Write all values of binding collection of a control.
    /// </summary>
    /// <param name="bindings">The bindings.</param>
    static public void WriteValues(this ControlBindingsCollection bindings)
    {
      foreach ( Binding binding in bindings ) 
        binding.WriteValue();
    }

  }

}
