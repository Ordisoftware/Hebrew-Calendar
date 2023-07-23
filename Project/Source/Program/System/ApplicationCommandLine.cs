/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2023 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-12 </created>
/// <edited> 2021-08 </edited>
namespace Ordisoftware.Hebrew.Calendar;

using CommandLine;

class ApplicationCommandLine : SystemCommandLine
{

  static public ApplicationCommandLine Instance
    => SystemManager.CommandLineOptions as ApplicationCommandLine;

  [Option("appstats", Required = false, HelpText = "Show application's statistics.")]
  public bool AppStats { get; set; }

  [Option("generate", Required = false, HelpText = "Generate calendar.")]
  public bool Generate { get; set; }

  [Option("resetreminder", Required = false, HelpText = "Reset reminder.")]
  public bool ResetReminder { get; set; }

  [Option("navigate", Required = false, HelpText = "Open navigation window.")]
  public bool OpenNavigation { get; set; }

  [Option("diffdates", Required = false, HelpText = "Open dates difference calculator.")]
  public bool OpenDatesDifference { get; set; }

  [Option("celebrationverses", Required = false, HelpText = "Open celebration verses board.")]
  public bool OpenCelebrationVersesBoard { get; set; }

  [Option("celebrations", Required = false, HelpText = "Open celebrations board.")]
  public bool OpenCelebrationsBoard { get; set; }

  [Option("newmoons", Required = false, HelpText = "Open new moons board.")]
  public bool OpenNewMoonsBoard { get; set; }

  [Option("parashot", Required = false, HelpText = "Open parashot board.")]
  public bool OpenParashotBoard { get; set; }

  [Option("parashah", Required = false, HelpText = "Open weekly parashah description box.")]
  public bool OpenWeeklyParashahBox { get; set; }

  [Option("lunarmonths", Required = false, HelpText = "Open lunar months board.")]
  public bool OpenLunarMonthsBoard { get; set; }

}
