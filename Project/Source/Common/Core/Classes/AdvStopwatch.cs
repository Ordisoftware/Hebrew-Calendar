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
/// <created> 2025-02 </created>
/// <edited> 2025-02 </edited>
namespace Ordisoftware.Core;

public class AdvStopwatch
{

  private readonly Stopwatch _Stopwatch = new();

  private TimeSpan _Offset;

  public void Reset()
  {
    _Offset = TimeSpan.Zero;
    _Stopwatch.Reset();
  }

  public void Restart()
  {
    _Offset = TimeSpan.Zero;
    _Stopwatch.Restart();
  }

  public void AddElapsed(TimeSpan additionalTime) => _Offset += additionalTime;

  public void Start() => _Stopwatch.Start();

  public void Stop() => _Stopwatch.Stop();

  public TimeSpan Elapsed => _Stopwatch.Elapsed + _Offset;

  public long ElapsedMilliseconds => Elapsed.Ticks / TimeSpan.TicksPerMillisecond;

  public long ElapsedTicks => Elapsed.Ticks;

  public bool IsRunning => _Stopwatch.IsRunning;

}