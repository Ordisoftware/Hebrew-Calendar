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
/// <created> 2007-05 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Core;

using Serilog;
using Serilog.Formatting.Display;
using Serilog.Sinks.WinForms.Base;

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
static public partial class DebugManager
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
  /// Indicates default showing exception mode
  /// </summary>
  static public ShowExceptionMode DefaultShowExceptionMode { get; set; }
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
          try
          {
            Directory.Delete(Globals.OldTraceFolderPath, true);
          }
          catch
          {
          }
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
      try
      {
        TraceEnabledChanged?.Invoke(value);
      }
      catch
      {
      }
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
            Log.Logger = logconf.WriteTo.File(path: Globals.SinkFileRollingFilePatternPath,
                                              outputTemplate: Globals.SinkFileEventTemplate,
                                              fileSizeLimitBytes: Globals.SinkFileSizeLimitBytes,
                                              shared: SystemManager.AllowMultipleInstances,
                                              rollingInterval: Globals.SinkFileRollingInterval,
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
  static private bool _Enabled;

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
    Manage(ex, null, DefaultShowExceptionMode);
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
    Manage(ex, sender, DefaultShowExceptionMode);
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
    ManageInternal(sender, ex, DefaultShowExceptionMode);
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
    var eInfo = new ExceptionInfo(sender, ex);
    if ( !_Enabled )
    {
      if ( ex is not AbortException && show != ShowExceptionMode.None )
        ShowSimple(eInfo);
      return;
    }
    if ( ex is not AbortException )
      try
      {
        BeforeShowException?.Invoke(sender, eInfo, ref process);
      }
      catch ( Exception err )
      {
        if ( show != ShowExceptionMode.None )
          DisplayManager.ShowError($"Error on BeforeShowException :{Globals.NL2}{err.Message}");
      }
    if ( process )
    {
      Trace(LogTraceEvent.Exception, eInfo.FullText);
      if ( ex is not AbortException )
        switch ( show )
        {
          case ShowExceptionMode.None:
            break;
          case ShowExceptionMode.Message:
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            break;
          case ShowExceptionMode.Simple:
            ShowSimple(eInfo);
            break;
          case ShowExceptionMode.Advanced:
            ShowAdvanced(eInfo);
            break;
          default:
            throw new AdvNotImplementedException(show);
        }
    }
    if ( ex is not AbortException )
      try
      {
        AfterShowException?.Invoke(sender, eInfo, process);
      }
      catch ( Exception err )
      {
        if ( show != ShowExceptionMode.None )
          DisplayManager.ShowError($"Error on AfterShowException :{Globals.NL2}{err.Message}");
      }
  }

  /// <summary>
  /// Shows an exception with the exception form else a message box.
  /// </summary>
  /// <param name="eInfo">The exception information.</param>
  static private void ShowAdvanced(ExceptionInfo eInfo)
  {
    if ( eInfo.Instance is AbortException ) return;
    try
    {
      if ( SubstituteShowException is not null )
        SubstituteShowException.Invoke(eInfo.Sender, eInfo);
      else
        try
        {
          ExceptionForm.Run(eInfo);
        }
        catch
        {
          ShowSimple(eInfo);
        }
    }
    catch ( Exception ex )
    {
      ShowCrash(ex, eInfo);
    }
  }

  /// <summary>
  /// Shows an exception with a message box.
  /// </summary>
  /// <param name="eInfo">The exception information.</param>
  static private void ShowSimple(ExceptionInfo eInfo)
  {
    if ( eInfo.Instance is AbortException ) return;
    try
    {
      string message = SysTranslations.UnhandledException.GetLang(eInfo.Emitter,
                                                                  eInfo.ModuleName,
                                                                  eInfo.Instance.ToStringReadableWithInners());
      if ( UserCanTerminate )
        message += Globals.NL2 + SysTranslations.AskToContinueOrTerminate.GetLang();
      var goal = UserCanTerminate ? MessageBoxButtons.YesNo : MessageBoxButtons.OK;
      if ( DisplayManager.Show(message, goal, MessageBoxIcon.Error) == DialogResult.No )
        SystemManager.Terminate();
    }
    catch ( Exception ex )
    {
      ShowCrash(ex, eInfo);
    }
  }

  /// <summary>
  /// Shows a message when an error occurs on showing an exception.
  /// </summary>
  /// <param name="ex">The exception.</param>
  /// <param name="eInfo">The exception information.</param>
  static private void ShowCrash(Exception ex, ExceptionInfo eInfo)
  {
    try
    {
      string message = $"""
                        Error on displaying Exception :
                        
                        {eInfo?.Instance?.Message ?? "null"}

                        {"(" + ex.Message + ")"}
                        """;
      DisplayManager.ShowError(message);
    }
    catch ( Exception err )
    {
      MessageBox.Show($"DebugManager crash :{Globals.NL2}{err.Message}");
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
    return ex.Parse(sender, eInfo => eInfo.FullText);
  }

  /// <summary>
  /// Gets a readable formatted text of an exeption.
  /// </summary>
  /// <param name="ex">The exception to act on.</param>
  /// <param name="sender">The sender object</param>
  static public string ToStringFullText(this Exception ex, object sender = null)
  {
    return ex.Parse(sender, eInfo => eInfo.FullText);
  }

  /// <summary>
  /// Gets a readable formatted text of an exeption including inners.
  /// </summary>
  /// <param name="ex">The exception to act on.</param>
  /// <param name="sender">The sender object</param>
  static public string ToStringReadableWithInners(this Exception ex, object sender = null)
  {
    return ex.Parse(sender, eInfo => eInfo.ReadableText);
  }

  /// <summary>
  /// Parses an exception and all inners.
  /// </summary>
  /// <param name="ex">The exception to act on.</param>
  /// <param name="sender">The sender object</param>
  /// <param name="getText">The gettext iteration.</param>
  static private string Parse(this Exception ex, object sender, Func<ExceptionInfo, string> getText)
  {
    var eInfo = new ExceptionInfo(sender, ex);
    var list = new List<string> { getText(eInfo) };
    eInfo = eInfo.InnerInfo;
    while ( eInfo is not null )
    {
      list.Add($"[Inner] {getText(eInfo)}");
      eInfo = eInfo.InnerInfo;
    }
    return list.AsMultiDoubleLine();
  }

}
