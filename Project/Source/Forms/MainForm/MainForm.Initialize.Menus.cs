﻿/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
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
/// <created> 2016-04 </created>
/// <edited> 2021-09 </edited>
using System;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  /// <summary>
  /// Provide application's main form.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  partial class MainForm
  {

    /// <summary>
    /// Create system information menu items.
    /// </summary>
    public void CreateSystemInformationMenu()
    {
      CommonMenusControl.CreateInstance(ToolStrip,
                                        ref ActionInformation,
                                        AppTranslations.NoticeNewFeatures,
                                        ActionAbout_Click,
                                        ActionWebCheckUpdate_Click,
                                        ActionViewLog_Click,
                                        ActionViewStats_Click);
      InitializeSpecialMenus();
    }

    /// <summary>
    /// Initialize special menus (web links, tray icon and suspend).
    /// </summary>
    public void InitializeSpecialMenus()
    {
      ActionStudyOnline.InitializeFromProviders(HebrewGlobals.WebProvidersParashah, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        var weekParashah = ApplicationDatabase.Instance.GetWeeklyParashah();
        if ( weekParashah.Factory == null ) return;
        HebrewTools.OpenParashahProvider((string)menuitem.Tag,
                                         weekParashah.Factory,
                                         weekParashah.Day.HasLinkedParashah);
      });
      ContextMenuDayParashahStudy.InitializeFromProviders(HebrewGlobals.WebProvidersParashah, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        var weekParashah = ParashotFactory.Instance.Get(ContextMenuDayCurrentEvent.GetParashahReadingDay()?.ParashahID);
        if ( weekParashah == null ) return;
        HebrewTools.OpenParashahProvider((string)menuitem.Tag,
                                         weekParashah,
                                         ContextMenuDayCurrentEvent.HasLinkedParashah);
      });
      ActionOpenVerseOnline.InitializeFromProviders(HebrewGlobals.WebProvidersBible, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        var weekParashah = ApplicationDatabase.Instance.GetWeeklyParashah();
        if ( weekParashah.Factory == null ) return;
        string verse = $"{(int)weekParashah.Factory.Book}.{weekParashah.Factory.VerseBegin}";
        HebrewTools.OpenBibleProvider((string)menuitem.Tag, verse);
      });
      ContextMenuDayParashahRead.InitializeFromProviders(HebrewGlobals.WebProvidersBible, (sender, e) =>
      {
        var menuitem = (ToolStripMenuItem)sender;
        var weekParashah = ParashotFactory.Instance.Get(ContextMenuDayCurrentEvent.GetParashahReadingDay()?.ParashahID);
        if ( weekParashah == null ) return;
        string verse = $"{(int)weekParashah.Book}.{weekParashah.VerseBegin}";
        HebrewTools.OpenBibleProvider((string)menuitem.Tag, verse);
      });
      CommonMenusControl.Instance.ActionViewStats.Enabled = Settings.UsageStatisticsEnabled;
      CommonMenusControl.Instance.ActionViewLog.Enabled = DebugManager.TraceEnabled;
      ActionWebLinks.Visible = Settings.WebLinksMenuEnabled;
      ActionLocalWeather.Visible = Settings.WeatherMenuItemsEnabled;
      ActionOnlineWeather.Visible = Settings.WeatherMenuItemsEnabled;
      SeparatorMenuWeather.Visible = Settings.WeatherMenuItemsEnabled;
      ActionWebLinks.Enabled = Settings.WebLinksMenuEnabled;
      ActionLocalWeather.Enabled = Settings.WeatherMenuItemsEnabled;
      ActionOnlineWeather.Enabled = Settings.WeatherMenuItemsEnabled;
      SeparatorMenuWeather.Enabled = Settings.WeatherMenuItemsEnabled;
      var isVisible = Settings.WeatherMenuItemsEnabled ? (int?)null : int.MinValue;
      ActionLocalWeather.Tag = isVisible;
      ActionOnlineWeather.Tag = isVisible;
      SeparatorMenuWeather.Tag = isVisible;
      MenuWebLinks.Visible = Settings.WebLinksMenuEnabled;
      MenuWebLinks.Enabled = Settings.WebLinksMenuEnabled;
      if ( Settings.WebLinksMenuEnabled )
      {
        ActionWebLinks.InitializeFromWebLinks(InitializeSpecialMenus);
        ActionWebLinks.DuplicateTo(MenuWebLinks);
      }
      ActionTools.DuplicateTo(MenuTools);
      ActionInformation.DuplicateTo(MenuInformation);
      if ( !Settings.AllowSuspendReminder && ActionEnableReminder.Enabled )
        ActionEnableReminder.PerformClick();
      ActionDisableReminder.Enabled = Settings.AllowSuspendReminder;
      MenuDisableReminder.Enabled = Settings.AllowSuspendReminder;
    }

  }

}
