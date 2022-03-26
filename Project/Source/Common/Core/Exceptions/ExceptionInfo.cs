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

/// <summary>
/// Provides exception information.
/// </summary>
[SuppressMessage("Minor Code Smell", "S1643:Strings should not be concatenated using '+' in a loop", Justification = "Opinion")]
class ExceptionInfo
{

  /// <summary>
  /// Indicates the sender.
  /// </summary>
  public object Sender { get; }

  /// <summary>
  /// Indicates the emitter.
  /// </summary>
  public string Emitter { get; }

  /// <summary>
  /// Indicates the instance.
  /// </summary>
  public Exception Instance { get; }

  /// <summary>
  /// Indicates the inner exception.
  /// </summary>
  public ExceptionInfo InnerInfo { get; }

  /// <summary>
  /// Indicates the type text.
  /// </summary>
  public string TypeText { get; private set; }

  /// <summary>
  /// Indicates the inherits from.
  /// </summary>
  public string InheritsFrom { get; private set; }

  /// <summary>
  /// Indicates the name of the thread.
  /// </summary>
  public string ThreadName { get; private set; }

  /// <summary>
  /// Indicates the name of the assembly.
  /// </summary>
  public string AssemblyName { get; private set; }

  /// <summary>
  /// Indicates the name of the module.
  /// </summary>
  public string ModuleName { get; private set; }

  /// <summary>
  /// Indicates the namespace.
  /// </summary>
  public string Namespace { get; private set; }

  /// <summary>
  /// Indicates the name of the class.
  /// </summary>
  public string ClassName { get; private set; }

  /// <summary>
  /// Indicates the name of the method.
  /// </summary>
  public string MethodName { get; private set; }

  /// <summary>
  /// Indicates the code line number.
  /// </summary>
  public int LineNumber { get; private set; }

  /// <summary>
  /// Indicates the code file name.
  /// </summary>
  public string FileName { get; private set; }

  /// <summary>
  /// Indicates the target site.
  /// </summary>
  public MethodBase TargetSite { get; }

  /// <summary>
  /// Indicates the message.
  /// </summary>
  public string Message { get; private set; }

  /// <summary>
  /// Indicates the full text.
  /// </summary>
  public string FullText { get; private set; }

  /// <summary>
  /// Indicates the readable text.
  /// </summary>
  public string ReadableText { get; private set; }

  /// <summary>
  /// Indicates the single line text.
  /// </summary>
  public string SingleLineText { get; private set; }

  /// <summary>
  /// Indicates the exception stack text.
  /// </summary>
  public string ExceptionStackText { get; private set; }

  /// <summary>
  /// Indicates the thread stack text.
  /// </summary>
  public string ThreadStackText { get; private set; }

  /// <summary>
  /// Indicates the full stack text.
  /// </summary>
  public string StackText { get; }

  /// <summary>
  /// Indicates the exception stack list.
  /// </summary>
  public List<string> ExceptionStackList { get; } = new List<string>();

  /// <summary>
  /// Indicates the thread stack list.
  /// </summary>
  public List<string> ThreadStackList { get; } = new List<string>();

  /// <summary>
  /// Indicates caller name.
  /// </summary>
  /// <returns>
  /// The caller name.
  /// </returns>
  /// <param name="skip">The skip.</param>
  static public string GetCallerName(int skip)
  {
    if ( !DebugManager.UseStack ) return string.Empty;
    string result = string.Empty;
    try
    {
      var frame = new StackFrame(skip, true);
      var method = frame.GetMethod();
      result = string.Format("{0}.{1} ({2} line {3})",
                             method.DeclaringType.FullName,
                             method.Name,
                             Path.GetFileName(frame.GetFileName()),
                             frame.GetFileLineNumber());
    }
    catch
    {
    }
    return result;
  }

  /// <summary>
  /// Extracts the inherits.
  /// </summary>
  private void ExtractInherits()
  {
    try
    {
      var type = Instance.GetType();
      TypeText = type.ToString();
      type = type.BaseType;
      InheritsFrom = type.ToString();
      while ( ( type = type.BaseType ) is not null )
        InheritsFrom += $" > {type}";
    }
    catch
    {
    }
  }

  /// <summary>
  /// Extracts the stack.
  /// </summary>
  private void ExtractStack(bool full)
  {
    try
    {
      if ( !DebugManager.UseStack ) return;
      var frames = full ? new StackTrace(true).GetFrames() : new StackTrace(Instance, true).GetFrames();
      if ( frames is null ) return;
      string result = string.Empty;
      string partMethod = string.Empty;
      string partFileName = string.Empty;
      bool first = true;
      foreach ( var frame in frames )
      {
        var method = frame.GetMethod();
        partMethod = method.DeclaringType.FullName;
        Type[] list = { typeof(DebugManager), typeof(ExceptionInfo) };
        if ( list.Contains(method.DeclaringType) )
          continue;
        string[] list2 = { nameof(SystemManager.TryCatchManage), nameof(SystemManager.TryCatch) };
        if ( method.DeclaringType == typeof(SystemManager) && list2.Contains(method.Name) )
          continue;
        partFileName = Path.GetFileName(frame.GetFileName());
        if ( partFileName.IsNullOrEmpty() && DebugManager.StackOnlyProgram )
          continue;
        int line = frame.GetFileLineNumber();
        if ( first && !full )
        {
          first = false;
          AssemblyName = method.DeclaringType.Assembly.FullName;
          ModuleName = method.DeclaringType.Module.Name;
          Namespace = method.DeclaringType.Namespace;
          ClassName = method.DeclaringType.Name;
          MethodName = method.Name;
          FileName = partFileName;
          LineNumber = line;
        }
        partMethod += $".{method.Name}";
        if ( line != 0 )
        {
          partMethod = $"{partFileName} line {line}:{Globals.NL}{partMethod}{Globals.NL}";
          if ( result.Length != 0 ) partMethod = Globals.NL + partMethod;
        }
        if ( result.Length != 0 ) result += Globals.NL;
        result += partMethod;
        ( full ? ThreadStackList : ExceptionStackList ).Add(partMethod.SplitNoEmptyLines().AsMultiSpace());
      }
      if ( full )
        ThreadStackText += result.Replace(Globals.NL3, Globals.NL2).TrimEnd(Globals.NL.ToCharArray());
      else
        ExceptionStackText += result.Replace(Globals.NL3, Globals.NL2).TrimEnd(Globals.NL.ToCharArray());
    }
    catch
    {
    }
  }

  /// <summary>
  /// Initializes the texts.
  /// </summary>
  private void InitializeTexts()
  {
    try
    {
      ThreadName = Thread.CurrentThread.Name.IsNullOrEmpty()
                   ? Thread.CurrentThread.ManagedThreadId == 1
                     ? "Main"
                     : "ID = " + Thread.CurrentThread.ManagedThreadId.ToString()
                   : Thread.CurrentThread.Name;

      try
      {
        Message = Instance.Message;
      }
      catch
      {
        Message = "Relayed Exception.";
      }

      FullText = "Exception: " + TypeText + Globals.NL +
                 "Module: " + ModuleName + Globals.NL +
                 "Thread: " + ThreadName + Globals.NL +
                 "Message: " + Globals.NL +
                 Message.Indent(DebugManager.MarginSize);

      try
      {
        if ( DebugManager.UseStack )
          FullText += Globals.NL +
                      "Stack Exception: " + Globals.NL +
                      ExceptionStackList.AsMultiLine().Indent(DebugManager.MarginSize) + Globals.NL +
                      "Stack Thread: " + Globals.NL +
                      ThreadStackList.AsMultiLine().Indent(DebugManager.MarginSize);
      }
      catch
      {
      }

      ReadableText = Message + Globals.NL2 +
                     "Type: " + TypeText + Globals.NL +
                     "Module: " + ModuleName + Globals.NL +
                     "Thread: " + ThreadName;

      if ( DebugManager.UseStack )
        ReadableText += Globals.NL +
                        "File: " + FileName + Globals.NL +
                        "Method: " + Namespace + "." + ClassName + "." + MethodName + Globals.NL +
                        "Line: " + LineNumber;

      SingleLineText = ReadableText.Replace(Globals.NL2, " | ")
                                   .Replace(Globals.NL, " | ")
                                   .Replace("  ", string.Empty);
    }
    catch
    {
    }
  }

  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="sender">.</param>
  /// <param name="ex">The ex.</param>
  public ExceptionInfo(object sender, Exception ex)
  {
    if ( ex is null ) return;
    Sender = sender;
    Instance = ex;
    TargetSite = ex.TargetSite;
    try
    {
      Emitter = Globals.AssemblyTitleWithVersion;
      ExtractInherits();
      try
      {
        ExtractStack(false);
        ExtractStack(true);
        StackText = "---------- EXCEPTION STACK ----------" + Globals.NL2 +
                    ExceptionStackText + Globals.NL2 +
                    "---------- THREAD STACK -------------" + Globals.NL2 +
                    ThreadStackText;
      }
      finally
      {
        InitializeTexts();
      }
      if ( ex.InnerException is not null )
        InnerInfo = new ExceptionInfo(sender, ex.InnerException);
    }
    catch
    {
    }
  }

}
