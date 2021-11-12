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
using System.Data;
using System.IO;
using System.Text;
using System.Linq;
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
                stream.WriteLine($"{column.ColumnName} = {row[column]}");
              stream.WriteLine();
            }
          break;
        case DataExportTarget.CSV:
          var options = new CsvOptions("String[,]", Globals.CSVSeparator, table.Rows.Count)
          {
            IncludeHeaderNames = true,
            DateFormat = "yyyy-MM-dd HH:mm",
            Encoding = Encoding.UTF8
          };
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
