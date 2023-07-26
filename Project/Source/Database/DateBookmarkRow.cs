/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
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
/// <created> 2023-06 </created>
/// <edited> 2023-07 </edited>
namespace Ordisoftware.Hebrew.Calendar;

using Ordisoftware.Hebrew.Calendar.Properties;
using SQLite;

[Serializable]
[Table("DateBookmarks")]
public partial class DateBookmarkRow
{

  static private readonly Properties.Settings Settings = Program.Settings;

  [PrimaryKey]
  public Guid ID { get; set; } = Guid.NewGuid();

  [NotNull]
  public DateTime Date { get; set; } = DateTime.Now;

  [NotNull]
  public string Memo { get; set; } = string.Empty;

  [NotNull]
  [Column("Color")]
  public int ColorAsInt { get; set; } = Settings.DateBookmarkDefaultTextColor.ToArgb();

  [Ignore]
  public Color Color
  {
    get => Color.FromArgb(ColorAsInt);
    set
    {
      int argb = value.ToArgb();
      if ( ColorAsInt == argb ) return;
      ColorAsInt = argb;
    }
  }

  public override string ToString()
  {
    return Memo.IsNullOrEmpty()
      ? Date.ToLongDateString()
      : $"{Date.ToLongDateString()} {Settings.DateBookmarkMemoPrefix}{Memo}{Settings.DateBookmarkMemoSuffix}";
  }

  public DateBookmarkRow()
  {
  }

  public DateBookmarkRow(DateTime date, string memo)
  {
    Date = date;
    Memo = memo;
  }

  public DateBookmarkRow(DateTime date, string memo, Color color)
  {
    Date = date;
    Memo = memo;
    Color = color;
  }

  public DateBookmarkRow(DateBookmarkRow item)
  {
    Date = item.Date;
    Memo = item.Memo;
    Color = item.Color;
  }

}
