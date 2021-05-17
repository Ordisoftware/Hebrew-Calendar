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
/// <created> 2019-01 </created>
/// <edited> 2021-05 </edited>
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using FileHelpers;
using FileHelpers.Options;
using Newtonsoft.Json;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide DataTable helper.
  /// </summary>
  static partial class DataTableHelper
  {

    /// <summary>
    /// Convert a collection of T to a DataTable.
    /// https://stackoverflow.com/questions/4460654/best-practice-convert-linq-query-result-to-a-datatable-without-looping#31586395
    /// </summary>
    static public DataTable ToDataTable<T>(this IEnumerable<T> list, string name = "") where T : class
    {
      if ( list == null ) return null;
      var table = new DataTable();
      table.TableName = name;
      PropertyInfo[] columns = null;
      foreach ( T item in list )
      {
        if ( columns == null )
        {
          columns = item.GetType().GetProperties();
          foreach ( var column in columns )
          {
            var colType = column.PropertyType;
            if ( colType.IsGenericType && colType.GetGenericTypeDefinition() == typeof(Nullable<>) )
              colType = colType.GetGenericArguments()[0];
            table.Columns.Add(new DataColumn(column.Name, colType));
          }
        }
        var row = table.NewRow();
        foreach ( var column in columns )
          row[column.Name] = column.GetValue(item, null) ?? DBNull.Value;
        table.Rows.Add(row);
      }
      return table;
    }

    //https://stackoverflow.com/questions/6295161/how-to-build-a-datatable-from-a-datagridview#13344318
    static public DataTable ToDataTable(this DataGridView datagridview, string name = "", bool IgnoreHiddenColumns = false)
    {
      try
      {
        var table = new DataTable(name);
        foreach ( DataGridViewColumn column in datagridview.Columns )
        {
          if ( IgnoreHiddenColumns && !column.Visible ) continue;
          table.Columns.Add(column.Name, column.ValueType);
          table.Columns[column.Name].Caption = column.HeaderText;
        }
        foreach ( DataGridViewRow rowGrid in datagridview.Rows )
        {
          var rowTable = table.NewRow();
          foreach ( DataColumn column in table.Columns )
            rowTable[column.ColumnName] = rowGrid.Cells[column.ColumnName].Value;
          table.Rows.Add(rowTable);
        }
        return table;
      }
      catch { return null; }
    }

    /// <summary>
    /// Export a DataTable to a file depending its extension.
    /// </summary>
    static public void Export(this DataTable table, string filePath, NullSafeOfStringDictionary<DataExportTarget> targets)
    {
      string extension = Path.GetExtension(filePath);
      var selected = targets.First(p => p.Value == extension).Key;
      switch ( selected )
      {
        case DataExportTarget.TXT:
          using ( var stream = File.CreateText(filePath) )
            foreach ( DataRow row in table.Rows )
            {
              foreach ( DataColumn column in table.Columns )
                stream.WriteLine($"{column.ColumnName} = {row[column].ToString()}");
              stream.WriteLine();
            }
          break;
        case DataExportTarget.CSV:
          var options = new CsvOptions("String[,]", Globals.CSVSeparator, table.Rows.Count);
          options.IncludeHeaderNames = true;
          options.DateFormat = "yyyy-MM-dd HH:mm";
          options.Encoding = Encoding.UTF8;
          CsvEngine.DataTableToCsv(table, filePath, options);
          break;
        case DataExportTarget.JSON:
          var dataset = new DataSet(Globals.AssemblyTitle);
          dataset.Tables.Add(table);
          string lines = JsonConvert.SerializeObject(dataset, Formatting.Indented);
          File.WriteAllText(filePath, lines, Encoding.UTF8);
          dataset.Tables.Clear();
          dataset.Dispose();
          break;
        default:
          throw new AdvancedNotImplementedException(selected);
      }
    }

  }

}
