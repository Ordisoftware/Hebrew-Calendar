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
/// <created> 2021-02 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew;

class ParashotFactory : ProviderSettings
{

  static public readonly ParashotFactory Instance = new();

  public readonly NullSafeDictionary<TorahBook, NullSafeList<Parashah>> Items = new();

  public IEnumerable<Parashah> All => Items.SelectMany(item => item.Value);

  public Parashah Get(string id)
    => All.FirstOrDefault(p => p.ID == id);

  protected override void SetFilePath()
    => FilePath = HebrewGlobals.ParashotFactoryFilePath;

  protected override void DoClear()
    => Items.Clear();

  protected override void DoLoad(string line)
  {
    var pair = line.Split(':');
    if ( pair.Length < 2 ) return;
    var book = Enums.Parse<TorahBook>(pair[0].Trim());
    if ( Items[book] is null ) Items[book] = new NullSafeList<Parashah>();
    var items = pair[1].Split('-');
    if ( items.Length != 6 ) return;
    Items[book].Add(new Parashah(book,
                                 int.Parse(items[0].Trim()),
                                 items[2].Trim(),
                                 items[1].Trim(),
                                 items[3].Trim(),
                                 items[4].Trim(),
                                 bool.Parse(items[5].Trim())));
  }

  protected override void DoSave(StreamWriter stream)
  {
    foreach ( var kvp in Items )
      foreach ( var item in kvp.Value )
        stream.WriteLine($"{kvp.Key} : {item.Number} - {item.Unicode} - {item.Name} - {item.VerseBegin} - {item.VerseEnd} - {item.IsLinkedToNext}");
  }

  public void Reset()
  {
    var query = from book in Items from parashah in book.Value select parashah;
    var linesTranslation = new NullSafeOfStringDictionary<string>();
    var linesLettriq = new NullSafeOfStringDictionary<string>();
    linesTranslation.LoadKeyValuePairs(HebrewGlobals.ParashotTranslationsFilePath, "=");
    linesLettriq.LoadKeyValuePairs(HebrewGlobals.ParashotLettriqsFilePath, "=");
    int index = 0;
    foreach ( Parashah item in query )
    {
      if ( index < linesTranslation.Count )
      {
        item.Name = linesTranslation.Keys.ElementAt(index).Trim();
        item.Translation = linesTranslation.Values.ElementAt(index).Trim();
      }
      if ( index < linesLettriq.Count ) item.Lettriq = linesLettriq.Values.ElementAt(index).Trim();
      index++;
    }
  }

}
