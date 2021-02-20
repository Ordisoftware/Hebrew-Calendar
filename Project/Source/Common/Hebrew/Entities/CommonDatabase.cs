/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2021 Olivier Rogier. 
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2021-02 </created>
/// <edited> 2021-02 </edited>
using System;
using System.Data;
using System.Data.Odbc;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew
{

  public partial class CommonDatabase
  {

    static public readonly CommonDatabase Instance = new CommonDatabase();

    //private OdbcConnection CommonLockFileConnection;

    private CommonDatabase()
    {
      CreateSchemaIfNotExists();
    }

    public DataTable ParashotTable { get; private set; }

    public void UseParashotTable()
    {
      if ( ParashotTable != null ) return;
      // TODO check if parashotinstance == 0
      // TODO incr parashotinstance
      // TODO use readonly if locked ?
      ParashotTable = new DataTable(ParashotTableName);
      using ( var connection = new OdbcConnection(Globals.CommonConnectionString) )
        try
        {
          connection.Open();
          var command = new OdbcCommand(ParashotSelectAll, connection);
          using ( var adapter = new OdbcDataAdapter(command) )
            adapter.Fill(ParashotTable);
        }
        finally
        {
          connection.Close();
        }
      CreateParashotDataIfNotExists(false);
    }

    public void DisposeParashotTable()
    {
      if ( ParashotTable == null ) return;
      ParashotTable.Dispose();
      ParashotTable = null;
      // TODO unlock parashotinstance
    }

    public void UpdateParashotTable()
    {
      if ( ParashotTable == null ) throw new ArgumentNullException(ParashotTableName);
      using ( var connection = new OdbcConnection(Globals.CommonConnectionString) )
      using ( var command = new OdbcCommand(ParashotSelectAll, connection) )
      using ( var adapter = new OdbcDataAdapter(command) )
      using ( var builder = new OdbcCommandBuilder(adapter) )
        try
        {
          adapter.Update(ParashotTable);
        }
        finally
        {
          connection.Close();
        }
    }

  }

}
