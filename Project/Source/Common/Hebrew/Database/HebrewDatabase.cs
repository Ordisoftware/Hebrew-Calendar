/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2022 Olivier Rogier.
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
/// <edited> 2022-11 </edited>
namespace Ordisoftware.Hebrew;

partial class HebrewDatabase : SQLiteDatabase
{

  static public HebrewDatabase Instance { get; protected set; }

  static public bool HebrewNamesInUnicode { get; set; }
  static public bool ArabicNumeralReferences { get; set; }

  static HebrewDatabase()
  {
    Instance = new HebrewDatabase();
  }

  private HebrewDatabase() : base(Globals.CommonDatabaseFilePath)
  {
    AutoLoadAllAtOpen = false;
    Open();
  }

  protected override void DoClose()
  {
    ReleaseParashot();
    ReleaseLettriqs();
  }

  protected override void CreateTables()
  {
    Connection.CreateTable<Interlock>();
    Connection.CreateTable<Parashah>();
    Connection.CreateTable<TermHebrew>();
    Connection.CreateTable<TermLettriq>();
    Connection.CreateTable<TermAnalysis>();
  }

  protected override void DoLoadAll()
  {
    string message = SysTranslations.NotImplemented.GetLang($"{nameof(HebrewDatabase)}.{nameof(LoadAll)}");
    throw new NotSupportedException(message);
  }

  [SuppressMessage("Refactoring", "GCop638:Shorten this method by defining it as expression-bodied.", Justification = "Opinion")]
  [SuppressMessage("CodeQuality", "IDE0079:Retirer la suppression inutile", Justification = "N/A")]
  protected override bool CreateDataIfNotExist(bool reset = false)
  {
    // NOP
    return false;
  }

  [SuppressMessage("Refactoring", "GCop638:Shorten this method by defining it as expression-bodied.", Justification = "Opinion")]
  [SuppressMessage("CodeQuality", "IDE0079:Retirer la suppression inutile", Justification = "N/A")]
  protected override void CreateBindingLists()
  {
    // NOP
  }

  protected override void DoSaveAll()
  {
    string message = SysTranslations.NotImplemented.GetLang($"{nameof(HebrewDatabase)}.{nameof(DoSaveAll)}");
    throw new NotSupportedException(message);
  }

  protected override void UpgradeSchema()
  {
    base.UpgradeSchema();
    const string table = "ProcessLocks";
    if ( Connection.CheckTable(table) && Globals.ConcurrentRunningProcesses.Any() )
      Connection.DropTableIfExists(table);

    // TODO URGENT reconstruct parashot
    // versebegin -> ChapterAndVerseBegin
    // verseend -> ChapterAndVerseEnd
    // and split in ChapterBegin ChapterEnd VerseBegin VerseEnd
    // or remove columns and use factory

  }

}
