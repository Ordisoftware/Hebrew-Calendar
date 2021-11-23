using System;
using Timer = System.Timers.Timer;
using ElapsedEventArgs = System.Timers.ElapsedEventArgs;
using ElapsedEventHandler = System.Timers.ElapsedEventHandler;

namespace DandTSoftware.Timers
{
  /// <summary>
  /// Midnight Timer Delegate for the event
  /// </summary>
  /// <param name="Time"></param>
  public delegate void TimeReachedEventHandler(DateTime Time);

  /// <summary>
  /// Provides the means to detect when midnight is reached.
  /// </summary>
  public class MidnightTimer : IDisposable
  {
    #region Static variables
    /// <summary>
    /// Internal Timer
    /// </summary>
    private static Timer s_timer = null; // renamed from m_ to s_ to represent static

    /// <summary>
    /// How many Minutes after midnight are added to the timer
    /// </summary>
    private static int s_MinutesAfterMidnight = 0;

    /// <summary>
    /// Occurs whens midnight occurs, subscribe to this
    /// </summary>
    public event TimeReachedEventHandler TimeReached;
    #endregion

    #region Constructors
    /// <summary>
    /// Creates an instance of the Midnight Timer
    /// </summary>
    public MidnightTimer()
    {
    }

    /// <summary>
    /// Creates an instance of the Midnight Timer, which will fire after a set number of minutes after midnight
    /// </summary>
    /// <param name="MinutesAfterMidnight"></param>
    public MidnightTimer(int MinutesAfterMidnight) : this()
    {
      // Check if the supplied m is between 0 and 59 mins after midnight
      if ( ( MinutesAfterMidnight < 0 ) || ( MinutesAfterMidnight > 59 ) )
      {
        // if it is outside of this range, throw a exception
        throw new ArgumentException("Minuets after midnight is less than 0 or more than 60!");
      }
      else
      {
        // Set the internal value
        s_MinutesAfterMidnight = MinutesAfterMidnight;
      }
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// Starts the Timer to fire a certain amount of Minutes AFTER midnight, every night (based on server time).
    /// </summary>
    public void Start()
    {
      // Subtract the current time, from midnigh (tomorrow).
      // This will return a value, which will be used to set the Timer interval
      TimeSpan ts = this.GetMidnight(s_MinutesAfterMidnight).Subtract(DateTime.Now);

      // We only want the Hours, Minuters and Seconds until midnight
      TimeSpan tsMidnight = new TimeSpan(ts.Hours, ts.Minutes, ts.Seconds);

      // Create the Timer
      s_timer = new Timer(tsMidnight.TotalMilliseconds);

      // Set the event handler
      s_timer.Elapsed += new ElapsedEventHandler(this.timer_Elapsed);

      // Hook into when Windows Time changes - Thanks to Nicole1982 for the suggestion & BruceN for the help
      Microsoft.Win32.SystemEvents.TimeChanged += new EventHandler(this.WindowsTimeChangeHandler);

      // Start the timer
      s_timer.Start();
    }

    /// <summary>
    /// Stops the timer
    /// </summary>
    public void Stop()
    {
      // sanity checking
      if ( s_timer != null )
      {
        // Stop the orginal timer
        s_timer.Stop();

        // As this is a static event, clean it up
        Microsoft.Win32.SystemEvents.TimeChanged -= new EventHandler(WindowsTimeChangeHandler);
      }
    }

    /// <summary>
    /// Restarts the timer
    /// </summary>
    public void Restart()
    {
      // Stop the timer
      this.Stop();

      // (Re)Start
      this.Start();
    }
    #endregion

    #region Hanlders
    /// <summary>
    /// Standard Event/Delegate handler, if its not null, fire the event
    /// </summary>
    private void OnTimeReached()
    {
      if ( this.TimeReached != null ) // sanity checking
      {
        // Fire the event
        this.TimeReached(this.GetMidnight(s_MinutesAfterMidnight));
      }
    }

    /// <summary>
    /// Handles Windows Time Changes which cause the timer to stop/start aka Reset
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void WindowsTimeChangeHandler(object sender, EventArgs e)
    {
      // Please see https://connect.microsoft.com/VisualStudio/feedback/details/776003/systemevent-timechanged-is-fired-twice
      // The event is fired twice.. I assume 'once' for the change from the old system time and 'once' when the time has been changed.
      // i.e Event is fired when Systerm time has Changed and is Changing

      // Restart the timer -> note as above, this is called twice
      this.Restart();
    }

    /// <summary>
    /// Executes when the timer has elasped
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
      // Stop the orginal timer
      s_timer.Stop(); // swapped order thanks to Jeremy

      // now raise a event that the timer has elapsed
      OnTimeReached(); // swapped order thanks to Jeremy

      // reset the timer
      this.Start();
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Obtains a DateTime of Midngiht
    /// </summary>
    /// <param name="MinutesAfterMidnight">How many minuets after midnight to add?</param>
    /// <returns></returns>
    private DateTime GetMidnight(int MinutesAfterMidnight)
    {
      // Lets work out the next occuring midnight
      // Add 1 day and use hours 0, min 0 and second 0 (remember this is 24 hour time)

      // Thanks to Yashar for this code/fix
      DateTime Tomorrow = DateTime.Now.AddDays(1);

      // Return a datetime for Tomorrow, but with how many minutes after midnight
      return new DateTime(Tomorrow.Year, Tomorrow.Month, Tomorrow.Day, 0, MinutesAfterMidnight, 0);
    }
    #endregion

    #region Disposing
    /// <summary>
    /// Dispose of the timer (also stops the timer)
    /// </summary>
    public void Dispose()
    {
      // Pass to Stop to unsubscribe the event handler of Windows System Time Changes
      this.Stop();
    }
    #endregion
  }
}
