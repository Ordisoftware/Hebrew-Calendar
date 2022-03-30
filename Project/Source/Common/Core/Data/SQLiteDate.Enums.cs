﻿/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2022 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2022-03 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Core;

public enum SQLiteDateDayTextOrder
{
  DayFirst,
  YearFirst
}

public enum SQLiteDateDayTextSeparator
{
  Point,
  Minus,
  Slash
}

public enum SQLiteDateHourTextSeparator
{
  Point,
  Minus,
  Colon
}

public enum SQLiteDateDayHourTextSeparator
{
  Space,
  At,
  Sharp,
  Vertical,
  Plus
}
