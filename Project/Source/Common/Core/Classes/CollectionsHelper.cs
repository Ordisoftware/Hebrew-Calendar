/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2024 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2021-09 </created>
/// <edited> 2024-11 </edited>
namespace Ordisoftware.Core;

static public class CollectionsHelper
{

  static public List<List<T>> Split<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
  {
    var slices = new List<List<T>> { new() };
    foreach ( var item in collection )
    {
      slices[slices.Count - 1].Add(item);
      if ( predicate(item) )
        slices.Add([]);
    }
    return slices;
  }

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
  /// Gets an IEnumerable<typeparamref name="T"/> from a ListBox.Items collection.
  /// </summary>
  /// <typeparam name="T">Generic type parameter.</typeparam>
  /// <param name="collection">The collection.</param>
  static public IEnumerable<T> AsIEnumerable<T>(this ListBox.ObjectCollection collection)
  {
    foreach ( T item in collection )
      yield return item;
  }

  /// <summary>
  /// Gets an IEnumerable<typeparamref name="T"/> from a CheckedListBox.Items collection.
  /// </summary>
  /// <typeparam name="T">Generic type parameter.</typeparam>
  /// <param name="collection">The collection.</param>
  static public IEnumerable<T> AsIEnumerable<T>(this CheckedListBox.ObjectCollection collection)
  {
    foreach ( T item in collection )
      yield return item;
  }

  /// <summary>
  /// Gets an IEnumerable&lt;ListViewItem&gt; from a ListView.ListViewItemCollection collection.
  /// </summary>
  /// <param name="collection">The collection.</param>
  static public IEnumerable<ListViewItem> AsIEnumerable(this ListView.ListViewItemCollection collection)
  {
    foreach ( ListViewItem item in collection )
      yield return item;
  }

  /// <summary>
  /// Gets an IEnumerable<DataGridViewRow/> from a DataGridView.DataGridViewRowCollection.
  /// </summary>
  /// <param name="collection">The collection.</param>
  static public IEnumerable<DataGridViewRow> AsIEnumerable(this DataGridViewRowCollection collection)
  {
    foreach ( DataGridViewRow item in collection )
      yield return item;
  }

}
