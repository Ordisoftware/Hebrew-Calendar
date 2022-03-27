/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2022 Olivier Rogier.
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
namespace Ordisoftware.Hebrew.Calendar;

partial class ApplicationDatabase : SQLiteDatabase
{

  public (LunisolarDay Day, Parashah Factory) GetWeeklyParashah()
  {
    var today = Program.Settings.TorahEventsCountAsMoon ? GetDayMoon(DateTime.Now) : GetDaySun(DateTime.Now);
    if ( today is null ) return (today, null);
    if ( today.LunarMonth == TorahCelebrationSettings.PessahMonth )
      if ( today.TorahEvent == TorahCelebrationDay.PessahD1 || today.TorahEvent == TorahCelebrationDay.PessahD7 )
        return (today, null);
      else
      if ( today.GetWeekLongCelebrationIntermediateDay().Event != TorahCelebration.None )
        return (today, null);
    if ( today.LunarMonth == TorahCelebrationSettings.YomsMonth )
      if ( today.TorahEvent == TorahCelebrationDay.YomTerouah || today.TorahEvent == TorahCelebrationDay.YomHaKipourim )
        return (today, null);
      else
      {
        var (Event, Index, _) = today.GetWeekLongCelebrationIntermediateDay();
        if ( Event == TorahCelebration.Soukot )
          if ( Index < 8 || ( Index == 8 && Program.Settings.UseSimhatTorahOutside ) )
            return (today, null);
      }
    if ( Program.Settings.TorahEventsCountAsMoon ) today = GetDaySun(DateTime.Now);
    today = today?.GetParashahReadingDay();
    return (today, ParashotFactory.Instance.Get(today?.ParashahID));
  }

  public bool ShowWeeklyParashahDescription()
  {
    if ( MainForm.UserParashot is null ) return false;
    var (Day, Factory) = GetWeeklyParashah();
    if ( Factory is null ) return false;
    return MainForm.UserParashot.ShowDescription(Factory, Day.HasLinkedParashah, () => ParashotForm.Run(Factory));
  }

}

partial class LunisolarDay
{

  private const int SearchParashahInterval = 14;

  public string GetParashahText(bool withBookAndRefIfRequired)
  {
    if ( ParashahID.IsNullOrEmpty() ) return string.Empty;
    var parashah = ParashotFactory.Instance.Get(ParashahID);
    return parashah is not null
      ? parashah.ToStringShort(withBookAndRefIfRequired, HasLinkedParashah)
      : SysTranslations.UndefinedSlot.GetLang();
  }

  public LunisolarDay GetParashahReadingDay()
  {
    LunisolarDay result = null;
    var shabatDay = (DayOfWeek)Program.Settings.ShabatDay;
    int indexStart = Table.IndexOf(this);
    int indexEnd = Math.Min(indexStart + SearchParashahInterval, Table.Count);
    for ( int index = indexStart; index < indexEnd; index++ )
    {
      var row = Table[index];
      if ( row.Date.DayOfWeek == shabatDay )
      {
        result = row;
        break;
      }
    }
    return result?.ParashahID.IsNullOrEmpty() != false ? null : result;
  }

}
