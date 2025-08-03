/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2025 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2025-01 </created>
/// <edited> 2025-01 </edited>
namespace Ordisoftware.Core;

public enum SQLitePageSize
{
  _00512 = 512,
  _01024 = 1024,
  _02048 = 2048,
  _04096 = 4096,
  _08192 = 8192,
  _16384 = 16384,
  _32768 = 32768,
  _65536 = 65536
}

public enum SQLiteLockingMode
{
  NORMAL, EXCLUSIVE
}

public enum SQLiteTempStoreMode
{
  DEFAULT, FILE, MEMORY
}

public enum SQLiteSynchronousMode
{
  OFF, NORMAL, FULL, EXTRA
}

public enum SQLiteJournalMode
{
  DELETE, TRUNCATE, PERSIST, MEMORY, WAL, OFF
}
