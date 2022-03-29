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
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Core;

using Serilog;
using Serilog.Formatting.Display;
using Serilog.Sinks.WinForms;

public delegate void DebugManagerHandler(bool value);

/// <summary>
/// Provides exception helper.
/// </summary>
/// <remarks>
/// <para>Using enter-Leave system :</para>
/// <para>
/// void Function()
/// {
///   try
///   {
///     DebugManager.Enter();
///     DoSomething();
///   }
///   finally
///   {
///     DebugManager.Leave();
///   }
/// }
/// </para>
/// <para>
/// void Function()
/// {
///   try
///   {
///     DebugManager.Enter();
///     DoSomething();
///     DebugManager.Leave();
///   }
///   catch (Exception ex)
///   {
///     e.Manage(this, ex, false); // The Leave() will be automatically called
///   }
/// }
/// </para>
/// </remarks>
static partial class DebugManager
{

  static public event DebugManagerHandler EnabledChanged;
  static public event DebugManagerHandler TraceEnabledChanged;

  /// <summary>
  /// Indicates before Exception event.
  /// </summary>
  static public event BeforeShowExceptionEventHandler BeforeShowException;

  /// <summary>
  /// Indicates after Exception event.
  /// </summary>
  static public event AfterShowExceptionEventHandler AfterShowException;

  /// <summary>
  /// Indicates Exception show alternative handler.
  /// </summary>
  static public event EventHandler<ExceptionInfo> SubstituteShowException;

  /// <summary>
  /// Indicates if stack infos are used.
  /// </summary>
  static public bool UseStack { get; set; } = true;

  /// <summary>
  /// Indicates if only the program stack is used.
  /// </summary>
  static public bool StackOnlyProgram { get; set; } = true;

  /// <summary>
  /// Indicates if stack in specialized form is hidded by default.
  /// </summary>
  //static public bool AutoHideStack { get; set; } = false;

  /// <summary>
  /// Indicates if Exception form show a terminate button.
  /// </summary>
  static public bool UserCanTerminate { get; set; } = true;

  /// <summary>
  /// Indicates if a specialized form is used to show Exception.
  /// </summary>
  static public ShowExceptionMode DeaultShowExceptionMode { get; set; }
    = ShowExceptionMode.Advanced;

  /// <summary>
  /// Indicates the trace listener.
  /// </summary>
  static public bool TraceEnabled
  {
    get => _TraceEnabled;
    set
    {
      if ( _TraceEnabled == value ) return;
      var isEnabled = _Enabled;
      Stop();
      if ( value )
      {
        if ( Directory.Exists(Globals.OldTraceFolderPath) )
          try { Directory.Delete(Globals.OldTraceFolderPath, true); } catch { }
        ClearTraces(true, false);
      }
      else
      {
        TraceForm?.Hide();
        TraceForm?.TextBoxCurrent.Clear();
        ClearTraces(true, true);
      }
      _TraceEnabled = value;
      Enabled = isEnabled;
      try { TraceEnabledChanged?.Invoke(value); } catch { }
    }
  }
  static private bool _TraceEnabled = false;


  /// <summary>
  /// Indicates if the debug manager is enabled or not.
  /// </summary>
  [SuppressMessage("Style", "GCop423:This condition was just checked on line {0}.", Justification = "Opinion")]
  static public bool Enabled
  {
    get => _Enabled;
    set
    {
      if ( _Enabled == value ) return;
      if ( value )
      {
        AppDomain.CurrentDomain.UnhandledException += OnAppDomainException;
        Application.ThreadException += OnThreadException;
        Application.ApplicationExit += Stop;
      }
      else
      {
        AppDomain.CurrentDomain.UnhandledException -= OnAppDomainException;
        Application.ThreadException -= OnThreadException;
        Application.ApplicationExit -= Stop;
      }
      if ( value )
      {
        _Enabled = true;
        if ( _TraceEnabled )
        {
          var logconf = new LoggerConfiguration();
          logconf.Enrich.With(new ProcessIdEnricher());
          logconf.Enrich.With(new ThreadIdEnricher());
          if ( Globals.TraceFileRollOverMode == TraceFileRollOverMode.Session )
          {
            string datetime = DateTime.Now.ToString(Globals.TraceSessionFileTemplate);
            string filePath = Globals.SinkFileNoRollingFilePatternPath.Replace(Globals.SinkFileNoRollingPatternPathDateTag,
                                                                               datetime);
            Log.Logger = logconf.WriteTo.File(filePath,
                                              outputTemplate: Globals.SinkFileEventTemplate,
                                              fileSizeLimitBytes: Globals.SinkFileSizeLimitBytes)
                                .WriteToSimpleAndRichTextBox(new MessageTemplateTextFormatter(Globals.SinkFileEventTemplate))
                                .CreateLogger();
          }
          else
            Log.Logger = logconf.WriteTo.File(Globals.SinkFileRollingFilePatternPath,
                                              shared: SystemManager.AllowMultipleInstances,
                                              outputTemplate: Globals.SinkFileEventTemplate,
                                              rollingInterval: Globals.SinkFileRollingInterval,
                                              fileSizeLimitBytes: Globals.SinkFileSizeLimitBytes,
                                              retainedFileCountLimit: Globals.SinkFileRetainedFileCountLimit)
                                .WriteToSimpleAndRichTextBox(new MessageTemplateTextFormatter(Globals.SinkFileEventTemplate))
                                .CreateLogger();
          WindFormsSink.SimpleTextBoxSink.OnLogReceived += TraceEventAdded;
          WriteHeader();
        }
      }
      else
      {
        if ( _TraceEnabled )
        {
          WriteFooter();
          Log.CloseAndFlush();
        }
        _Enabled = false;
        TraceForm?.Hide();
        TraceForm?.TextBoxCurrent.Clear();
      }
      EnabledChanged?.Invoke(value);
    }
  }

  /// <summary>
  /// Indicates if the debug manager is enabled or not.
  /// </summary>
  static private bool _Enabled = false;

  /// <summary>
  /// Starts the debug manager.
  /// </summary>
  static public void Start(object sender = null, EventArgs e = null)
  {
    Enabled = true;
  }

  /// <summary>
  /// Stops the debug manager.
  /// </summary>
  static public void Stop(object sender = null, EventArgs e = null)
  {
    Enabled = false;
  }

  /// <summary>
  /// Manages unhandled domain exception.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="args">Event information to send to registered event handlers.</param>
  static private void OnAppDomainException(object sender, UnhandledExceptionEventArgs args)
  {
    if ( args.ExceptionObject is null ) return;
    Handle(sender, (Exception)args.ExceptionObject);
  }

  /// <summary>
  /// Manages unhandled thread exception.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="args">Event information to send to registered event handlers.</param>
  static private void OnThreadException(object sender, ThreadExceptionEventArgs args)
  {
    if ( args.Exception is null ) return;
    Handle(sender, args.Exception);
  }

  /// <summary>
  /// Handles an exception.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="ex">The ex.</param>
  static private void Handle(object sender, Exception ex)
  {
    ManageInternal(sender, ex);
  }

  /// <summary>
  /// Manages an exception.
  /// </summary>
  /// <param name="ex">The Exception to act on.</param>
  static public void Manage(this Exception ex)
  {
    Manage(ex, null, DeaultShowExceptionMode);
  }

  /// <summary>
  /// Manages an exception.
  /// </summary>
  /// <param name="ex">The Exception to act on.</param>
  /// <param name="show">The show mode.</param>
  static public void Manage(this Exception ex, ShowExceptionMode show)
  {
    Manage(ex, null, show);
  }

  /// <summary>
  /// Manages an exception.
  /// </summary>
  /// <param name="ex">The Exception to act on.</param>
  /// <param name="sender">Source of the event.</param>
  [SuppressMessage("Performance", "U2U1012:Parameter types should be specific", Justification = "Polymorphism needed")]
  [SuppressMessage("CodeQuality", "IDE0079:Retirer la suppression inutile", Justification = "N/A")]
  static public void Manage(this Exception ex, object sender)
  {
    Manage(ex, sender, DeaultShowExceptionMode);
  }

  /// <summary>
  /// Manages an exception.
  /// </summary>
  /// <param name="ex">The Exception to act on.</param>
  /// <param name="sender">Source of the event.</param>
  /// <param name="show">The show mode.</param>
  static public void Manage(this Exception ex, object sender, ShowExceptionMode show)
  {
    if ( ex is not AbortException )
    {
      StackSkip++;
      ManageInternal(sender, ex, show);
    }
    LeaveInternal();
  }

  /// <summary>
  /// Manages an exception.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="ex">The ex.</param>
  static private void ManageInternal(object sender, Exception ex)
  {
    ManageInternal(sender, ex, DeaultShowExceptionMode);
  }

  /// <summary>
  /// Manages an exception.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="ex">The ex.</param>
  /// <param name="show">The show mode.</param>
  static private void ManageInternal(object sender, Exception ex, ShowExceptionMode show)
  {
    bool process = true;
    var einfo = new ExceptionInfo(sender, ex);
    if ( !_Enabled )
    {
      if ( ex is not AbortException && show != ShowExceptionMode.None )
        ShowSimple(einfo);
      return;
    }
    if ( ex is not AbortException )
      try
      {
        BeforeShowException?.Invoke(sender, einfo, ref process);
      }
      catch ( Exception err )
      {
        if ( show != ShowExceptionMode.None )
          DisplayManager.ShowError("Error on BeforeShowException :" + Globals.NL2 + err.Message);
      }
    if ( process )
    {
      Trace(LogTraceEvent.Exception, einfo.FullText);
      if ( ex is not AbortException )
        switch ( show )
        {
          case ShowExceptionMode.None:
            break;
          case ShowExceptionMode.Advanced:
            ShowAdvanced(einfo);
            break;
          case ShowExceptionMode.OnlyMessage:
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            break;
          default:
            ShowSimple(einfo);
            break;
        }
    }
    if ( ex is not AbortException )
      try
      {
        AfterShowException?.Invoke(sender, einfo, process);
      }
      catch ( Exception err )
      {
        if ( show != ShowExceptionMode.None )
          DisplayManager.ShowError("Error on AfterShowException :" + Globals.NL2 + err.Message);
      }
  }


  /// <summary>
  /// Shows an exception with the exception form else a message box.
  /// </summary>
  /// <param name="einfo">The exception information.</param>
  static private void ShowAdvanced(ExceptionInfo einfo)
  {
    if ( einfo.Instance is AbortException ) return;
    try
    {
      if ( SubstituteShowException is not null )
        SubstituteShowException.Invoke(einfo.Sender, einfo);
      else
        try
        {
          ExceptionForm.Run(einfo);
        }
        catch
        {
          ShowSimple(einfo);
        }
    }
    catch ( Exception ex )
    {
      ShowCrash(ex, einfo);
    }
  }

  /// <summary>
  /// Shows an exception with a message box.
  /// </summary>
  /// <param name="einfo">The exception information.</param>
  static private void ShowSimple(ExceptionInfo einfo)
  {
    if ( einfo.Instance is AbortException ) return;
    try
    {
      string message = SysTranslations.UnhandledException.GetLang(
        einfo.Emitter,
        einfo.ModuleName,
        einfo.Instance.ToStringReadableWithInners());
      if ( UserCanTerminate )
        message += Globals.NL2 + SysTranslations.AskToContinueOrTerminate.GetLang();
      var goal = UserCanTerminate ? MessageBoxButtons.YesNo : MessageBoxButtons.OK;
      if ( DisplayManager.Show(message, goal, MessageBoxIcon.Error) == DialogResult.No )
        SystemManager.Terminate();
    }
    catch ( Exception ex )
    {
      ShowCrash(ex, einfo);
    }
  }

  /// <summary>
  /// Shows a message when an error occurs on showing an exception.
  /// </summary>
  /// <param name="ex">The exception.</param>
  /// <param name="einfo">The exception information.</param>
  static private void ShowCrash(Exception ex, ExceptionInfo einfo)
  {
    try
    {
      string message = "Error on displaying Exception :" + Globals.NL2 +
                       ( einfo?.Instance?.Message ?? "null" ) + Globals.NL2 +
                       "(" + ex.Message + ")";
      DisplayManager.ShowError(message);
    }
    catch ( Exception err )
    {
      MessageBox.Show("DebugManager crash :" + Globals.NL2 + err.Message);
      SystemManager.Terminate();
    }
  }

  /// <summary>
  /// Gets a full formatted text of an exeption including inners.
  /// </summary>
  /// <param name="ex">The exception to act on.</param>
  /// <param name="sender">The sender object</param>
  static public string ToStringWithInners(this Exception ex, object sender = null)
  {
    return ex.Parse(sender, einfo => einfo.FullText);
  }

  /// <summary>
  /// Gets a readable formatted text of an exeption.
  /// </summary>
  /// <param name="ex">The exception to act on.</param>
  /// <param name="sender">The sender object</param>
  static public string ToStringFullText(this Exception ex, object sender = null)
  {
    return ex.Parse(sender, einfo => einfo.FullText);
  }

  /// <summary>
  /// Gets a readable formatted text of an exeption including inners.
  /// </summary>
  /// <param name="ex">The exception to act on.</param>
  /// <param name="sender">The sender object</param>
  static public string ToStringReadableWithInners(this Exception ex, object sender = null)
  {
    return ex.Parse(sender, einfo => einfo.ReadableText);
  }

  /// <summary>
  /// Parses an exception and all inners.
  /// </summary>
  /// <param name="ex">The exception to act on.</param>
  /// <param name="sender">The sender object</param>
  /// <param name="getText">The gettext iteration.</param>
  static private string Parse(this Exception ex, object sender, Func<ExceptionInfo, string> getText)
  {
    var einfo = new ExceptionInfo(sender, ex);
    var list = new List<string> { getText(einfo) };
    einfo = einfo.InnerInfo;
    while ( einfo is not null )
    {
      list.Add($"[Inner] {getText(einfo)}");
      einfo = einfo.InnerInfo;
    }
    return list.AsMultiDoubleLine();
  }

}
