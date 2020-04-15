/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This program is free software: you can redistribute it and/or modify it under the terms of
/// the GNU Lesser General Public License (LGPL v3) as published by the Free Software Foundation,
/// either version 3 of the License, or (at your option) any later version.
/// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
/// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
/// See the GNU Lesser General Public License for more details.
/// You should have received a copy of the GNU General Public License along with this program.
/// If not, see www.gnu.org/licenses website.
/// </license>
/// <created> 2007-05 </created>
/// <edited> 2008-05 </edited>
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Ordisoftware.Core.Windows.Forms;

// TODO trace log proc : write thread name ? no : one log by thread ?
// TODO singleton & protected fields ?

namespace Ordisoftware.Core.Diagnostics
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
  /// Provide thread safe debug management. 
  /// </summary>
  /// <remarks>
  /// Showing/raising blocks all other threads if exception occur in a thread 
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

  /// <summary>
  /// Provide debugger.
  /// </summary>
  static public class Debugger
  {

    /// <summary>
    /// Indicate before exception event.
    /// </summary>
    static public event BeforeExceptionEventHandler BeforeException;

    /// <summary>
    /// Indicate after exception event.
    /// </summary>
    static public event AfterExceptionEventHandler AfterException;

    /// <summary>
    /// Indicate on showing exception handler.
    /// </summary>
    static public event OnExceptionEventHandler OnException;

    /// <summary>
    /// Indicate exception show alternative handler.
    /// </summary>
    static public event ShowExceptionEventHandler DoShowException;

    /// <summary>
    /// Indicate if stack infos are used.
    /// </summary>
    static public bool UseStack = true;

    /// <summary>
    /// Indicate if only the program stack is used.
    /// </summary>
    static public bool StackOnlyProgram = true;

    /// <summary>
    /// Indicate if a specialized form is used to show exception.
    /// </summary>
    static public bool UseForm = true;

    /// <summary>
    /// Indicate if stack in specialized form is hidded by default.
    /// </summary>
    /*static public bool AutoHideStack
    {
      get { return !SystemSettings.Instance.AlwaysShowStack; }
      set { SystemSettings.Instance.AlwaysShowStack = !value; }
    }*/

    /// <summary>
    /// Indicate if exception form show a terminate button.
    /// </summary>
    static public bool UserCanTerminate = true;

    /// <summary>
    /// The enter leave count skip.
    /// </summary>
    static private int _EnterLeaveCountSkip = 2;

    /// <summary>
    /// Number of enters.
    /// </summary>
    static private int _EnterCount = 0;

    /// <summary>
    /// The stack skip.
    /// </summary>
    static private int _StackSkip = 1;

    /// <summary>
    /// The slocker.
    /// </summary>
    static private volatile object slocker = new object();

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
          System.Windows.Forms.Application.ThreadException += OnThreadException;
        }
        else
        {
          AppDomain.CurrentDomain.UnhandledException -= OnAppDomainException;
          System.Windows.Forms.Application.ThreadException -= OnThreadException;
        }
        _Active = value;
        _EnterCount = 0;
        _StackSkip = 1;
      }
    }

    /// <summary>
    /// The active.
    /// </summary>
    static private bool _Active = false;

    /// <summary>
    /// Handles the exception delegate.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="except">The except.</param>
    private delegate void HandleExceptionDelegate(object sender, Exception except);

    /// <summary>
    /// Start this instance.
    /// </summary>
    static public void Start() { Active = true; }

    /// <summary>
    /// Stops this instance.
    /// </summary>
    static public void Stop() { Active = false; }

    /// <summary>
    /// Raises the unhandled exception event.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="args">Event information to send to registered event handlers.</param>
    static private void OnAppDomainException(object sender, UnhandledExceptionEventArgs args)
    {
      if ( args.ExceptionObject == null ) return;
      HandleException(sender, (Exception)args.ExceptionObject);
    }

    /// <summary>
    /// Raises the thread exception event.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="args">Event information to send to registered event handlers.</param>
    static private void OnThreadException(object sender, ThreadExceptionEventArgs args)
    {
      if ( args.Exception == null ) return;
      HandleException(sender, args.Exception);
    }

    /// <summary>
    /// Handle a throwned exception.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="except">The except.</param>
    static public void HandleException(object sender, Exception except)
    {
      if ( except is AbortException ) return;
      ProcessException(sender, except, true);
    }

    /// <summary>
    /// Define an enter function event.
    /// </summary>
    static public void Enter()
    {
      if ( !_Active ) return;
      //SystemManager.Log.Write(LogEventType.Enter, ExceptionInfo.GetCallerName(_EnterLeaveCountSkip));
      lock ( slocker ) _EnterCount++;
    }

    /// <summary>
    /// Define a leave function event.
    /// </summary>
    static public void Leave()
    {
      if ( !_Active || _EnterCount == 0 ) return;
      //SystemManager.Log.Write(LogEventType.Leave, ExceptionInfo.GetCallerName(_EnterLeaveCountSkip));
      lock ( slocker ) _EnterCount--;
    }

    /// <summary>
    /// Leave internal.
    /// </summary>
    static private void LeaveInternal()
    {
      if ( !_Active || _EnterCount == 0 ) return;
      //SystemManager.Log.Write(LogEventType.Leave, ExceptionInfo.GetCallerName(_EnterLeaveCountSkip + _StackSkip));
      lock ( slocker ) { _EnterCount--; _StackSkip = 1; }
    }

    /// <summary>
    /// Indicate the full formatted text of an exeption.
    /// </summary>
    /// <returns>
    /// except as a string.
    /// </returns>
    /// <param name="except">The except to act on.</param>
    static public string ToStringFull(this Exception except)
    {
      return except.ParseException((einfo) => { return einfo.FullText; });
    }

    /// <summary>
    /// Indicate the readable text of an exeption.
    /// </summary>
    /// <returns>
    /// A string.
    /// </returns>
    /// <param name="except">The except to act on.</param>
    /// <param name="gettext">The gettext.</param>
    static private string ParseException(this Exception except, Func<ExceptionInfo, string> gettext)
    {
      var einfo = new ExceptionInfo(null, except);
      List<string> list = new List<string>();
      list.Add(gettext(einfo));
      einfo = einfo.InnerInfo;
      while ( einfo != null )
      {
        list.Add("[Inner] " + gettext(einfo));
        einfo = einfo.InnerInfo;
      }
      return AsMultipart(list, Environment.NewLine + Environment.NewLine);
    }

    static public string AsMultipart(this string list, string separator)
    {
      return list.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).AsMultipart(separator);
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
        res = res + (/*res.EndsWith(separator) ? "test" : */separator ) + get(i);
      return res;
    }

    /// <summary>
    /// Show exception information.
    /// </summary>
    /// <param name="e">The Exception to process.</param>
    static public void ShowException(Exception e)
    {
      string s = e.ToStringFull();
      //try { SystemManager.Log.Write(LogEventType.Exception, s, true); }
      //catch { }
      //if ( SystemManager.Process.IsConsole ) 
        //Console.WriteLine(s);
      //else 
        System.Windows.Forms.MessageBox.Show(s);
    }

    /// <summary>
    /// Manage an exception.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="except">The except.</param>
    static public void ManageException(object sender, Exception except)
    {
      ManageException(sender, except, true);
    }

    /// <summary>
    /// Manage an exception.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="except">The except.</param>
    /// <param name="doshow">true to doshow.</param>
    static public void ManageException(object sender, Exception except, bool doshow)
    {
      if ( except is AbortException ) { LeaveInternal(); return; }
      lock ( slocker )
      {
        _StackSkip++;
        ProcessException(sender, except, doshow);
        LeaveInternal();
      }
    }

    /// <summary>
    /// Process the exception.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="except">The except.</param>
    /// <param name="doshow">true to doshow.</param>
    static private void ProcessException(object sender, Exception except, bool doshow)
    {
      string nl = Environment.NewLine;
      lock ( slocker )
        try
        {
          bool b = true;
          ExceptionInfo einfo = new ExceptionInfo(sender, except);
          //try { SystemManager.Log.Write(LogEventType.Exception, einfo.FullText, true); }
          //catch { }
          if ( !_Active ) { ShowSimpleException(einfo); return; }
          if ( BeforeException != null )
            try { BeforeException(sender, einfo, ref b); }
            catch ( Exception err )
            {
              if ( doshow ) 
                DisplayManager.Show("Error on BeforeException:" + nl + err.Message);
            }
          if ( b && doshow ) ShowException(einfo);
          if ( AfterException != null )
            try { AfterException(sender, einfo, b); }
            catch ( Exception err )
            {
              if ( doshow ) 
                DisplayManager.Show("Error on AfterException:" + nl + err.Message);
            }
        }
        catch ( Exception err )
        {
          try
          {
            string s = "Error on processing Exception." + nl + nl;
            if ( except != null ) s += except.Message + nl + nl;
            else s += "[null reference]" + nl + nl;
            s += "(" + err.Message + ")";
            DisplayManager.Show(s);
          }
          catch
          {
            MessageBox.Show(except == null ? "Null exception" : except.ToString());
            //Environment.Exit(0); 
          }
        }
    }

    /// <summary>
    /// Shows the exception.
    /// </summary>
    /// <param name="einfo">The einfo.</param>
    static private void ShowException(ExceptionInfo einfo)
    {
      if ( einfo.Instance is AbortException ) return;
      string nl = Environment.NewLine;
      try
      {
        if ( OnException != null )
          try { OnException(einfo.Sender, einfo); }
          catch ( Exception err )
          {
            DisplayManager.Show("Error in OnException: " + nl + err.Message);
          }
        if ( DoShowException != null ) DoShowException(einfo.Sender, einfo);
        else
          if ( UseForm )
            try { ExceptionForm.Run(einfo); }
            catch { ShowSimpleException(einfo); }
          else ShowSimpleException(einfo);
      }
      catch ( Exception err )
      {
        try
        {
          string s = "Error on displaying Exception:" + nl;
          if ( einfo != null ) s += einfo.Instance.Message + nl;
          else s += "[null reference]" + nl;
          s += "(" + err.Message + ")";
          DisplayManager.Show(s);
        }
        catch
        { Environment.Exit(0); }
      }
    }

    /// <summary>
    /// Shows the simple exception.
    /// </summary>
    /// <param name="einfo">The einfo.</param>
    static private void ShowSimpleException(ExceptionInfo einfo)
    {
      if ( einfo.Instance is AbortException ) return;
      string nl = Environment.NewLine;
      string s;
      try
      {
        s = "Unhandled exception has occured in " + /* TODO SystemManager.Process.FullExeName + */ nl + nl +
            einfo.ReadableText + nl + nl +
            "You can choose OK to continue or Cancel to terminate.";

        MessageBoxButtons but;
        if ( UserCanTerminate ) but = MessageBoxButtons.OKCancel;
        else but = MessageBoxButtons.OK;
        DialogResult result = MessageBox.Show(s, einfo.Emitter, but, MessageBoxIcon.Stop);
        if ( result == DialogResult.Cancel ) Environment.Exit(0); //SystemManager.Stop();
      }
      catch ( Exception err )
      {
        try
        {
          s = "Error on displaying Exception :" + nl;
          if ( einfo != null ) s += einfo.Instance.Message + nl;
          else s += "[null reference]" + nl;
          s += "(" + err.Message + ")";
          DisplayManager.Show(s);
        }
        catch
        { Environment.Exit(0); }
      }
    }

    /// <summary>
    /// Static constructor.
    /// </summary>
    static Debugger()
    {
      Active = true;
      //AppDomain.CurrentDomain.UnhandledException += OnAppDomainException;
      //System.Windows.Forms.Application.ThreadException += OnThreadException;
    }

  }

}
