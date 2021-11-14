/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2021 Olivier Rogier.
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
/// <edited> 2020-08 </edited>
using System;
using System.Data.Common;
using System.Runtime.Serialization;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide SQLite exception.
  /// </summary>
  [Serializable]
  class SQLiteException : DbException
  {
    public SQLiteException() { }
    public SQLiteException(string message) : base(message) { }
    public SQLiteException(string message, Exception innerException) : base(message, innerException) { }
    public SQLiteException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    public SQLiteException(string message, int errorCode) : base(message, errorCode) { }
  }

}
