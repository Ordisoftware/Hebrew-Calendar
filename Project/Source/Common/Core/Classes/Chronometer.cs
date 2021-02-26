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
/// <edited> 2020-08 </edited>
using System;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide benchmark helper.
  /// </summary>
  static partial class Chronometer
  {

    /// <summary>
    /// Measure an action.
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
    /// Measure an action reapeted several times.
    /// </summary>
    static public long Measure(int count, Action action, Control control = null)
    {
      Cursor temp = null;
      var times = new long[count];
      if ( control != null )
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
        if ( control != null )
        {
          control.ResumeLayout();
          control.Cursor = temp;
        }
      }
      return (long)times.Average();
    }

  }

}
