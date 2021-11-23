/// <license>
/// This file is part of Ordisoftware Hebrew Letters.
/// Copyright 2016-2021 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2021-05 </created>
/// <edited> 2021-08 </edited>
namespace Ordisoftware.Hebrew;

partial class HebrewDatabase : SQLiteDatabase
{

  static new public HebrewDatabase Instance { get; protected set; }

  static HebrewDatabase()
  {
    Instance = new HebrewDatabase();
    SQLiteDatabase.Instance = Instance;
  }

  private HebrewDatabase() : base(Globals.CommonDatabaseFilePath)
  {
    AutoLoadAllAtOpen = false;
    Open();
    CheckConnected();
  }

  protected override void DoClose()
  {
    ReleaseParashot();
    ReleaseLettriqs();
  }

  protected override void CreateTables()
  {
    CheckConnected();
    Connection.CreateTable<Interlock>();
    Connection.CreateTable<Parashah>();
    Connection.CreateTable<TermHebrew>();
    Connection.CreateTable<TermLettriq>();
    Connection.CreateTable<TermAnalysis>();
  }

  [SuppressMessage("General", "RCS1079:Throwing of new NotImplementedException.", Justification = "N/A")]
  public override void LoadAll()
  {
    string message = SysTranslations.NotImplemented.GetLang($"{nameof(HebrewDatabase)}.{nameof(LoadAll)}");
    throw new NotImplementedException(message);
  }

  [SuppressMessage("General", "RCS1079:Throwing of new NotImplementedException.", Justification = "N/A")]
  protected override void DoSaveAll()
  {
    string message = SysTranslations.NotImplemented.GetLang($"{nameof(HebrewDatabase)}.{nameof(DoSaveAll)}");
    throw new NotImplementedException(message);
  }

  protected override void UpgradeSchema()
  {
    base.UpgradeSchema();
    const string table = "ProcessLocks";
    if ( Connection.CheckTable(table) && Globals.ConcurrentRunningProcesses.Any() )
      Connection.DropTableIfExists(table);
  }

}
