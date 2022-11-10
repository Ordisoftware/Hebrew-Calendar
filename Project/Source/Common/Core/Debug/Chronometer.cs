/// <license>
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
/// <created> 2007-05 </created>
/// <edited> 2020-08 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides benchmark helper.
/// </summary>
static public class Chronometer
{

  /// <summary>
  /// Measures an action.
  /// </summary>
  static public Stopwatch Measure(Action action)
  {
    var chrono = new Stopwatch();
    chrono.Start();
    action();
    chrono.Stop();
    return chrono;
  }

  /// <summary>
  /// Measures an action repeated several times.
  /// </summary>
  static public long Measure(int count, Action action, Control control = null)
  {
    Cursor temp = null;
    var times = new long[count];
    if ( control is not null )
    {
      temp = control.Cursor;
      control.Cursor = Cursors.WaitCursor;
      control.SuspendLayout();
    }
    try
    {
      for ( int index = 0; index < count; index++ )
        times[index] = Measure(action).ElapsedMilliseconds;
    }
    finally
    {
      if ( control is not null )
      {
        control.ResumeLayout();
        control.Cursor = temp;
      }
    }
    return (long)times.Average();
  }

}
