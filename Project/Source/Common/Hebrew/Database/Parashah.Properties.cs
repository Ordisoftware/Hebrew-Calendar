/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2023 Olivier Rogier.
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
/// <edited> 2022-11 </edited>
namespace Ordisoftware.Hebrew;

using SQLite;

public partial class Parashah
{

  [PrimaryKey]
  public string ID { get; set; }

  public TorahBook Book { get; set; }
  public int Number { get; set; }

  public string VerseBegin { get; set; } // Obsolete : Moved to ReferenceBegin since v10.0
  public string VerseEnd { get; set; }   // Obsolete : Moved to ReferenceEnd since v10.0

  public string ReferenceBegin { get; set; }
  public string ReferenceEnd { get; set; }

  public int FirstChapter { get; set; }
  public int LastChapter { get; set; }
  public int FirstVerse { get; set; }
  public int LastVerse { get; set; }

  public string FullReferenceBegin => $"{(int)Book}.{ReferenceBegin}";
  public string FullReferenceEnd => $"{(int)Book}.{ReferenceEnd}";

  public string Name // Obsolete: Value comes from factory.
  {
    get => ParashotFactory.Instance.Get(ID)._Name;
    set
    {
      if ( _Name == value ) return;
      _Name = value;
    }
  }
  private string _Name = string.Empty;

  public string Unicode // Obsolete: Value comes from factory.
  {
    get => ParashotFactory.Instance.Get(ID)._Unicode;
    set
    {
      if ( _Unicode == value ) return;
      _Unicode = value;
    }
  }
  private string _Unicode = string.Empty;

  public string Hebrew // Obsolete: Value comes from factory.
  {
    get => ParashotFactory.Instance.Get(ID)._Hebrew;
    set
    {
      if ( _Hebrew == value ) return;
      _Hebrew = value;
    }
  }
  private string _Hebrew = string.Empty;

  public string Translation { get; set; }
  public string Lettriq { get; set; }

  public Parashah GetLinked(List<Parashah> owner = null)
  {
    if ( !IsLinkedToNext ) return null;
    if ( owner is not null ) return owner[owner.FindIndex(p => p.ID == ID) + 1];
    var list = ParashotFactory.Instance.All.ToList();
    return list[list.FindIndex(p => p.ID == ID) + 1];
  }

  public string Memo
  {
    get => _Memo;
    set
    {
      _Memo = value;
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HasMemo)));
    }
  }
  private string _Memo;

  public bool HasMemo => !Memo.IsNullOrEmpty();

  public bool IsLinkedToNext { get; set; }

}
