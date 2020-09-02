/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Originally developped for Ordisoftware Core Library.
/// Copyright 2004-2020 Olivier Rogier.
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
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Delegate for handling ShowException events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="einfo">The einfo.</param>
  public delegate void ShowExceptionEventHandler(object sender, ExceptionInfo einfo);

  /// <summary>
  /// Delegate for handling BeforeException events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="einfo">The einfo.</param>
  /// <param name="process">[in,out] The process.</param>
  public delegate void BeforeExceptionEventHandler(object sender, ExceptionInfo einfo, ref bool process);

  /// <summary>
  /// Delegate for handling OnException events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="einfo">The einfo.</param>
  public delegate void OnExceptionEventHandler(object sender, ExceptionInfo einfo);

  /// <summary>
  /// Delegate for handling AfterException events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="einfo">The einfo.</param>
  /// <param name="processed">true if processed.</param>
  public delegate void AfterExceptionEventHandler(object sender, ExceptionInfo einfo, bool processed);

  /// <summary>
  /// Provide exception management.
  /// </summary>
  /// <remarks>
  /// Showing/raising blocks all other threads if Exception occur in a thread 
  /// </remarks>
  /// <remarks> Using enter-Leave system : 
  ///                                                           
  /// void Function()                                          
  /// {                                                        
  /// try                                                    
  /// {                                                      
  ///   Debugger.Enter();                                     
  ///   DoSomething();                                                  
  ///   Debugger.Leave();                                     
  /// }                                                      
  /// catch (Exception e)                                    
  /// {                                                      
  ///   e.Manage(this, e, false);
  /// }                                                      
  /// }                                                          
  /// 
  /// </remarks>
  static public class ExceptionManager
  {

    /// <summary>
    /// Indicate before Exception event.
    /// </summary>
    static public event BeforeExceptionEventHandler BeforeException;

    /// <summary>
    /// Indicate after Exception event.
    /// </summary>
    static public event AfterExceptionEventHandler AfterException;

    /// <summary>
    /// Indicate on showing Exception handler.
    /// </summary>
    static public event OnExceptionEventHandler OnException;

    /// <summary>
    /// Indicate Exception show alternative handler.
    /// </summary>
    static public event ShowExceptionEventHandler DoShowException;

    // TODO properties with lock

    /// <summary>
    /// Indicate if stack infos are used.
    /// </summary>
    static public bool UseStack = true;

    /// <summary>
    /// Indicate if only the program stack is used.
    /// </summary>
    static public bool StackOnlyProgram = true;

    /// <summary>
    /// Indicate if a specialized form is used to show Exception.
    /// </summary>
    static public bool UseForm = true;

    /// <summary>
    /// Indicate if stack in specialized form is hidded by default.
    /// </summary>
    static public bool AutoHideStack = false;

    /// <summary>
    /// Indicate if Exception form show a terminate button.
    /// </summary>
    static public bool UserCanTerminate = true;

    /// <summary>
    /// Number of enters.
    /// </summary>
    static private int EnterCount = 0;

    /// <summary>
    /// The stack skip.
    /// </summary>
    static private int StackSkip = 1;

    /// <summary>
    /// The slocker.
    /// </summary>
    static private readonly object slocker = new object();

    /// <summary>
    /// Indicate if debugging is active.
    /// </summary>
    static public bool Active
    {
      get { return _Active; }
      set
      {
        if ( _Active == value ) return;
        if ( value )
        {
          AppDomain.CurrentDomain.UnhandledException += OnAppDomainException;
          Application.ThreadException += OnThreadException;
        }
        else
        {
          AppDomain.CurrentDomain.UnhandledException -= OnAppDomainException;
          Application.ThreadException -= OnThreadException;
        }
        _Active = value;
        EnterCount = 0;
        StackSkip = 1;
      }
    }

    /// <summary>
    /// The active.
    /// </summary>
    static private bool _Active = false;

    /// <summary>
    /// Handles the Exception delegate.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="ex">The ex.</param>
    private delegate void HandleExceptionDelegate(object sender, Exception ex);

    /// <summary>
    /// Start this instance.
    /// </summary>
    static public void Start() { Active = true; }

    /// <summary>
    /// Stops this instance.
    /// </summary>
    static public void Stop() { Active = false; }

    /// <summary>
    /// Raises the unhandled Exception event.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="args">Event information to send to registered event handlers.</param>
    static private void OnAppDomainException(object sender, UnhandledExceptionEventArgs args)
    {
      if ( args.ExceptionObject == null ) return;
      Handle(sender, (Exception)args.ExceptionObject);
    }

    /// <summary>
    /// Raises the thread Exception event.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="args">Event information to send to registered event handlers.</param>
    static private void OnThreadException(object sender, ThreadExceptionEventArgs args)
    {
      if ( args.Exception == null ) return;
      Handle(sender, args.Exception);
    }

    /// <summary>
    /// Manage an Exception with the debugger.
    /// </summary>
    /// <param name="ex">The Exception to act on.</param>
    /// <param name="show">true to show a message or false to hide it.</param>
    static public void Manage(this Exception ex, bool show = true)
    {
      Manage((object)null, ex, show);
    }

    /// <summary>
    /// Manage an Exception with the debugger.
    /// </summary>
    /// <param name="ex">The Exception to act on.</param>
    /// <param name="sender">Source of the event.</param>
    /// <param name="show">true to show a message or false to hide it.</param>
    static public void Manage(this Exception ex, object sender, bool show = true)
    {
      Manage(sender, ex, show);
    }

    /// <summary>
    /// Handle a throwned Exception.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="ex">The ex.</param>
    static public void Handle(object sender, Exception ex)
    {
      if ( ex is AbortException ) return;
      Process(sender, ex, true);
    }

    /// <summary>
    /// Define an enter function event.
    /// </summary>
    static public void Enter()
    {
      if ( !_Active ) return;
      lock ( slocker )
        EnterCount++;
    }

    /// <summary>
    /// Define a leave function event.
    /// </summary>
    static public void Leave()
    {
      if ( !_Active || EnterCount == 0 ) return;
      lock ( slocker )
        EnterCount--;
    }

    /// <summary>
    /// Leave internal.
    /// </summary>
    static private void LeaveInternal()
    {
      if ( !_Active || EnterCount == 0 ) return;
      lock ( slocker )
      {
        EnterCount--;
        StackSkip = 1;
      }
    }

    /// <summary>
    /// Indicate the full formatted text of an exeption.
    /// </summary>
    /// <returns>
    /// ex as a string.
    /// </returns>
    /// <param name="ex">The ex to act on.</param>
    static public string ToStringFull(this Exception ex)
    {
      return ex.Parse(einfo => einfo.FullText);
    }

    /// <summary>
    /// Indicate the readable text of an exeption.
    /// </summary>
    /// <returns>
    /// A string.
    /// </returns>
    /// <param name="ex">The ex to act on.</param>
    /// <param name="gettext">The gettext.</param>
    static private string Parse(this Exception ex, Func<ExceptionInfo, string> gettext)
    {
      var einfo = new ExceptionInfo(null, ex);
      var list = new List<string> { gettext(einfo) };
      einfo = einfo.InnerInfo;
      while ( einfo != null )
      {
        list.Add("[Inner] " + gettext(einfo));
        einfo = einfo.InnerInfo;
      }
      return AsMultipart(list, Globals.NL2);
    }

    static public string AsMultipart(this string list, string separator)
    {
      return list.Split(new string[] { Globals.NL }, StringSplitOptions.None).AsMultipart(separator);
    }

    static public string AsMultipart(this IEnumerable<string> list, string separator)
    {
      return AsMultipart(separator, list.Count(), i => list.ElementAt(i));
    }

    static private string AsMultipart(string separator, int count, Func<int, string> get)
    {
      if ( count == 0 ) return "";
      string res = get(0);
      for ( int i = 1; i < count; i++ )
        res = res + separator + get(i);
      return res;
    }

    /// <summary>
    /// Show Exception information.
    /// </summary>
    /// <param name="e">The Exception to process.</param>
    static public void Show(Exception e)
    {
      MessageBox.Show(e.ToStringFull());
    }

    /// <summary>
    /// Manage an Exception.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="ex">The ex.</param>
    /// <param name="doshow">true to doshow.</param>
    static public void Manage(object sender, Exception ex, bool doshow = true)
    {
      if ( ex is AbortException ) { LeaveInternal(); return; }
      lock ( slocker )
      {
        StackSkip++;
        Process(sender, ex, doshow);
        LeaveInternal();
      }
    }

    /// <summary>
    /// Process the Exception.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="ex">The ex.</param>
    /// <param name="doshow">true to doshow.</param>
    static private void Process(object sender, Exception ex, bool doshow)
    {
      lock ( slocker )
        try
        {
          bool b = true;
          var einfo = new ExceptionInfo(sender, ex);
          if ( !_Active )
          {
            ShowSimple(einfo);
            return;
          }
          if ( BeforeException != null )
            try
            {
              BeforeException(sender, einfo, ref b);
            }
            catch ( Exception err )
            {
              if ( doshow )
                DisplayManager.ShowError("Error on BeforeException:" + Globals.NL + err.Message);
            }
          if ( b && doshow )
            Show(einfo);
          if ( AfterException != null )
            try
            {
              AfterException(sender, einfo, b);
            }
            catch ( Exception err )
            {
              if ( doshow )
                DisplayManager.ShowError("Error on AfterException:" + Globals.NL + err.Message);
            }
        }
        catch ( Exception err )
        {
          try
          {
            string s = "Error on processing Exception." + Globals.NL2
                     + ( ex != null ? ex.Message + Globals.NL2 : "[null reference]" + Globals.NL2 )
                     + "(" + err.Message + ")";
            DisplayManager.ShowError(s);
          }
          catch
          {
            DisplayManager.ShowError(ex == null ? "Null Exception" : ex.ToString());
            Environment.Exit(-1); 
          }
        }
    }

    /// <summary>
    /// Shows the Exception.
    /// </summary>
    /// <param name="einfo">The einfo.</param>
    static private void Show(ExceptionInfo einfo)
    {
      if ( einfo.Instance is AbortException ) return;
      try
      {
        if ( OnException != null )
          try { OnException(einfo.Sender, einfo); }
          catch ( Exception err )
          {
            DisplayManager.ShowError("Error in OnException: " + Globals.NL + err.Message);
          }
        if ( DoShowException != null ) DoShowException(einfo.Sender, einfo);
        else
          if ( UseForm )
          try { ExceptionForm.Run(einfo); }
          catch { ShowSimple(einfo); }
        else ShowSimple(einfo);
      }
      catch ( Exception err )
      {
        try
        {
          string s = "Error on displaying Exception:" + Globals.NL;
          if ( einfo != null ) s += einfo.Instance.Message + Globals.NL;
          else s += "[null reference]" + Globals.NL;
          s += "(" + err.Message + ")";
          DisplayManager.ShowError(s);
        }
        catch
        {
          Environment.Exit(-1);
        }
      }
    }

    /// <summary>
    /// Shows the simple Exception.
    /// </summary>
    /// <param name="einfo">The einfo.</param>
    static private void ShowSimple(ExceptionInfo einfo)
    {
      if ( einfo.Instance is AbortException ) return;
      string s;
      try
      {
        s = "Unhandled Exception has occured in " + Path.GetFileName(Application.ExecutablePath) + Globals.NL2 +
            einfo.ReadableText + Globals.NL2 +
            "You can choose OK to continue or Cancel to terminate.";

        var goal = UserCanTerminate ? MessageBoxButtons.OKCancel : MessageBoxButtons.OK;
        var result = MessageBox.Show(s, einfo.Emitter, goal, MessageBoxIcon.Stop);
        if ( result == DialogResult.Cancel ) Environment.Exit(0);
      }
      catch ( Exception err )
      {
        try
        {
          s = "Error on displaying Exception :" + Globals.NL
            + ( einfo != null ? einfo.Instance.Message + Globals.NL : "[null reference]" + Globals.NL )
            + "(" + err.Message + ")";
          DisplayManager.ShowError(s);
        }
        catch
        {
          Environment.Exit(-1);
        }
      }
    }

  }

}
