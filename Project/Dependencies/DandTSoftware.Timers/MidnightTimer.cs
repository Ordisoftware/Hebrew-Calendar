namespace DandTSoftware.Timers;

using System;
using Timer = System.Timers.Timer;
using ElapsedEventArgs = System.Timers.ElapsedEventArgs;

/// <summary>
/// Midnight Timer Delegate for the event
/// </summary>
public delegate void TimeReachedEventHandler(DateTime Time);

/// <summary>
/// Provides the means to detect when midnight is reached.
/// </summary>
[SuppressMessage("Naming", "GCop201:Use camelCasing when declaring {0}", Justification = "<En attente>")]
[SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "<En attente>")]
public class MidnightTimer : IDisposable
{

  /// <summary>
  /// How many Minutes after midnight are added to the timer
  /// </summary>
  private readonly int MinutesAfterMidnight;

  /// <summary>
  /// For dispose pattern.
  /// </summary>
  private bool DisposedValue;

  /// <summary>
  /// Internal Timer
  /// </summary>
  private Timer Timer;

  /// <summary>
  /// Occurs whens midnight occurs, subscribe to this
  /// </summary>
  public event TimeReachedEventHandler TimeReached;


  /// <summary>
  /// Creates an instance of the Midnight Timer
  /// </summary>
  public MidnightTimer()
  {
  }

  /// <summary>
  /// Creates an instance of the Midnight Timer, which will fire after a set number of minutes after midnight
  /// </summary>
  public MidnightTimer(int minutesAfterMidnight) : this()
  {
    if ( minutesAfterMidnight < 0 || minutesAfterMidnight > 59 )
      throw new("Minuets after midnight is less than 0 or more than 60!");
    MinutesAfterMidnight = minutesAfterMidnight;
  }

  protected virtual void Dispose(bool disposing)
  {
    if ( !DisposedValue && disposing ) Stop();
    DisposedValue = true;
  }

  public void Dispose()
  {
    Dispose(true);
    GC.SuppressFinalize(this);
  }

  /// <summary>
  /// Starts the Timer to fire a certain amount of Minutes AFTER midnight, every night (based on server time).
  /// </summary>
  public void Start()
  {
    // Subtract the current time, from midnigh (tomorrow).
    // This will return a value, which will be used to set the Timer interval
    var ts = GetMidnight(MinutesAfterMidnight).Subtract(DateTime.Now);
    // We only want the Hours, Minuters and Seconds until midnight
    var tsMidnight = new TimeSpan(ts.Hours, ts.Minutes, ts.Seconds);
    Timer = new(tsMidnight.TotalMilliseconds);
    Timer.Elapsed += new(Timer_Elapsed);
    // Hook into when Windows Time changes - Thanks to Nicole1982 for the suggestion & BruceN for the help
    Microsoft.Win32.SystemEvents.TimeChanged += WindowsTimeChangeHandler;
    Timer.Start();
  }

  /// <summary>
  /// Stops the timer
  /// </summary>
  public void Stop()
  {
    if ( Timer is null ) return;
    Timer.Stop();
    Microsoft.Win32.SystemEvents.TimeChanged -= WindowsTimeChangeHandler;
  }

  /// <summary>
  /// Restarts the timer
  /// </summary>
  public void Restart()
  {
    Stop();
    Start();
  }

  /// <summary>
  /// Standard Event/Delegate handler, if its not null, fire the event
  /// </summary>
  private void OnTimeReached()
  {
    TimeReached?.Invoke(GetMidnight(MinutesAfterMidnight));
  }

  /// <summary>
  /// Handles Windows Time Changes which cause the timer to stop/start aka Reset
  /// </summary>
  private void WindowsTimeChangeHandler(object sender, EventArgs e)
  {
    // Please see https://connect.microsoft.com/VisualStudio/feedback/details/776003/systemevent-timechanged-is-fired-twice
    // The event is fired twice.. I assume 'once' for the change from the old system time and 'once' when the time has been changed.
    // i.e Event is fired when Systerm time has Changed and is Changing
    // Restart the timer -> note as above, this is called twice
    Restart();
  }

  /// <summary>
  /// Executes when the timer has elasped
  /// </summary>
  private void Timer_Elapsed(object sender, ElapsedEventArgs e)
  {
    Timer.Stop(); // swapped order thanks to Jeremy
    OnTimeReached(); // swapped order thanks to Jeremy
    Start();
  }

  /// <summary>
  /// Obtains a DateTime of Midngiht
  /// </summary>
  /// <param name="MinutesAfterMidnight">How many minuets after midnight to add?</param>
  static private DateTime GetMidnight(int MinutesAfterMidnight)
  {
    // Lets work out the next occuring midnight
    // Add 1 day and use hours 0, min 0 and second 0 (remember this is 24 hour time)
    // Thanks to Yashar for this code/fix
    var Tomorrow = DateTime.Now.AddDays(1);
    // Return a datetime for Tomorrow, but with how many minutes after midnight
    return new DateTime(Tomorrow.Year, Tomorrow.Month, Tomorrow.Day, 0, MinutesAfterMidnight, 0);
  }

}
