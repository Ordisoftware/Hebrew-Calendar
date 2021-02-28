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
/// <created> 2020-12 </created>
/// <edited> 2021-02 </edited>
using System;
using CommandLine;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class ApplicationCommandLine : SystemCommandLine
  {

    static public ApplicationCommandLine Instance
      => SystemManager.CommandLineOptions as ApplicationCommandLine;

    [Option("generate", Required = false, HelpText = "Generate the data of the calendar.")]
    public bool Generate { get; set; }

    [Option("diffdates", Required = false, HelpText = "Open diff dates calculator.")]
    public bool OpenDiffDates { get; set; }

    [Option("celebrations", Required = false, HelpText = "Open celebrations board.")]
    public bool OpenCelebrationsBoard { get; set; }

    [Option("newmoons", Required = false, HelpText = "Open new moons board.")]
    public bool OpenNewMoonsBoard { get; set; }

    // TODO enable when ready and update keys and faq
    //[Option("lunarmonths", Required = false, HelpText = "Open lunar months board.")]
    //public bool OpenLunarMonthsBoard { get; set; }

    [Option("parashot", Required = false, HelpText = "Open parashot board.")]
    public bool OpenParashotBoard { get; set; }

  }

}
