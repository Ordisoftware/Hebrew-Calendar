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
/// <created> 2020-08 </created>
/// <edited> 2024-01 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides SQLite exception.
/// </summary>
[Serializable]
[SuppressMessage("Major Code Smell", "S3925:\"ISerializable\" should be implemented correctly", Justification = "<En attente>")]
public class AdvSQLiteException : System.Data.Common.DbException
{
  public AdvSQLiteException() { }
  public AdvSQLiteException(string message) : base(message) { }
  public AdvSQLiteException(string message, Exception innerException) : base(message, innerException) { }
  public AdvSQLiteException(SerializationInfo info, StreamingContext context) : base(info, context) { }
  public AdvSQLiteException(string message, int errorCode) : base(message, errorCode) { }
}
