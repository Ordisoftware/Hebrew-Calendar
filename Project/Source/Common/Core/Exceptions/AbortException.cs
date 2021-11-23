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
/// <created> 2007-05 </created>
/// <edited> 2021-04 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides abort exception.
/// </summary>
[Serializable]
public class AbortException : Exception
{

  /// <summary>
  /// The msgcode.
  /// </summary>
  private const string msgcode = "ThreadAbort";

  /// <summary>
  /// The argname.
  /// </summary>
  private const string argname = "Message";

  /// <summary>
  /// Default constructor.
  /// </summary>
  public AbortException()
  : base(msgcode)
  {
  }

  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="message">The message.</param>
  public AbortException(string message)
  : base(msgcode)
  {
    Data.Add(argname, message);
  }

  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="message">The message.</param>
  /// <param name="innerException">The inner exception.</param>
  public AbortException(string message, Exception innerException)
  : base(msgcode, innerException)
  {
    Data.Add(argname, message);
  }

  /// <summary>
  /// Constructor.
  /// </summary>
  protected AbortException(SerializationInfo info, StreamingContext context) : base(info, context)
  {
  }

}
