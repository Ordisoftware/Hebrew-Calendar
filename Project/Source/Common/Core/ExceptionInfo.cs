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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide Exception information.
  /// </summary>
  public class ExceptionInfo
  {

    /// <summary>
    /// Get the sender.
    /// </summary>
    public object Sender { get; private set; }

    /// <summary>
    /// Get the emitter.
    /// </summary>
    public string Emitter { get; private set; }

    /// <summary>
    /// Get the instance.
    /// </summary>
    public Exception Instance { get; private set; }

    /// <summary>
    /// Get information describing the inner.
    /// </summary>
    public ExceptionInfo InnerInfo { get; private set; }

    /// <summary>
    /// Get the type text.
    /// </summary>
    public string TypeText { get; private set; }

    /// <summary>
    /// Get the inherits from.
    /// </summary>
    public string InheritsFrom { get; private set; }

    /// <summary>
    /// Get the name of the thread.
    /// </summary>
    public string ThreadName { get; private set; }

    /// <summary>
    /// Get the name of the assembly.
    /// </summary>
    public string AssemblyName { get; private set; }

    /// <summary>
    /// Get the name of the module.
    /// </summary>
    public string ModuleName { get; private set; }

    /// <summary>
    /// Get the namespace.
    /// </summary>
    public string Namespace { get; private set; }

    /// <summary>
    /// Get the filename of the file.
    /// </summary>
    public string FileName { get; private set; }

    /// <summary>
    /// Get the name of the class.
    /// </summary>
    public string ClassName { get; private set; }

    /// <summary>
    /// Get the name of the method.
    /// </summary>
    public string MethodName { get; private set; }

    /// <summary>
    /// Get the line number.
    /// </summary>
    public int LineNumber { get; private set; }

    /// <summary>
    /// Get target site.
    /// </summary>
    public MethodBase TargetSite { get; private set; }

    /// <summary>
    /// Get the message.
    /// </summary>
    public string Message { get; private set; }

    /// <summary>
    /// Get the full text.
    /// </summary>
    public string FullText { get; private set; }

    /// <summary>
    /// Get the readable text.
    /// </summary>
    public string ReadableText { get; private set; }

    public string SingleLineText { get; private set; }

    /// <summary>
    /// Get the stack text.
    /// </summary>
    public string StackText { get; private set; }

    /// <summary>
    /// Get a list of stacks.
    /// </summary>
    public List<string> StackList { get; private set; } = new List<string>();

    /// <summary>
    /// Indicate the full namespaces.name of the type of an object.
    /// </summary>
    /// <returns>
    /// The name with full namespace.
    /// </returns>
    /// <param name="obj">The obj to act on.</param>
    static public string GetNameWithFullNamespace(object obj)
    {
      return obj == null ? "(null)" : GetNameWithFullNamespace(obj.GetType());
    }

    /// <summary>
    /// Indicate the full namespaces.name of a type.
    /// </summary>
    /// <returns>
    /// The name with full namespace.
    /// </returns>
    /// <param name="type">The type to act on.</param>
    static public string GetNameWithFullNamespace(Type type)
    {
      return type == null ? "(null)" : type.Namespace + "." + type.Name;
    }

    /// <summary>
    /// Get caller name.
    /// </summary>
    /// <returns>
    /// The caller name.
    /// </returns>
    /// <param name="skip">The skip.</param>
    static internal string GetCallerName(int skip)
    {
      try
      {
        var frame = new StackFrame(skip, true);
        var method = frame.GetMethod();
        return GetNameWithFullNamespace(method.DeclaringType) + "." + method.Name +
               " (" + Path.GetFileName(frame.GetFileName()) + " line " + frame.GetFileLineNumber() + ")";
      }
      catch
      {
        return "";
      }
    }

    /// <summary>
    /// Extracts the inherits.
    /// </summary>
    private void ExtractInherits()
    {
      var type = Instance.GetType();
      TypeText = type.ToString();
      type = type.BaseType;
      InheritsFrom += type.ToString();
      while ( ( type = type.BaseType ) != null )
        InheritsFrom += " > " + type.ToString();
    }

    /// <summary>
    /// Extracts the stack.
    /// </summary>
    private void ExtractStack()
    {
      if ( !Debugger.UseStack ) return;
      bool first = false;
      string part1 = "";
      string part2 = "";
      string part3 = "";
      var trace = new StackTrace(Instance, true);
      var frames = trace.GetFrames();
      if ( frames == null ) return;
      foreach ( var frame in frames )
      {
        var method = frame.GetMethod();
        part2 = method.DeclaringType.FullName;
        var type = Type.GetType(part2);
        if ( type != typeof(Debugger) && type != typeof(ExceptionInfo) )
        {
          part3 = Path.GetFileName(frame.GetFileName());
          //if ( part3 == null && Debugger.StackOnlyProgram ) continue;
          int line = frame.GetFileLineNumber();
          if ( !first )
          {
            first = true;
            AssemblyName = method.DeclaringType.Assembly.FullName;
            ModuleName = method.DeclaringType.Module.Name;
            Namespace = method.DeclaringType.Namespace;
            ClassName = method.DeclaringType.Name;
            MethodName = method.Name;
            FileName = part3;
            LineNumber = line;
          }
          part2 += "." + method.Name;
          if ( line != 0 )
          {
            part2 = $"{part3} line {line}: {Globals.NL}{part2}{Globals.NL}";
            if ( part1 != "" ) part2 = Globals.NL + part2;
          }
          StackList.Add(part2);
          if ( part1 != "" ) part1 += Globals.NL;
          part1 += part2;
        }
      }
      // TODO corriger pb saut de lignes => utiliser list
      StackText = part1.Replace(Globals.NL3, Globals.NL2).TrimEnd(Globals.NL.ToCharArray());
    }

    /// <summary>
    /// Initialises the text.
    /// </summary>
    private void InitText()
    {
      if ( Thread.CurrentThread.Name != null )
        ThreadName = Thread.CurrentThread.Name;
      else
        ThreadName = "ID = " + Thread.CurrentThread.ManagedThreadId.ToString();

      if ( ModuleName != null && ModuleName != "" )
        TypeText += " in " + ModuleName;

      try { Message = Instance.Message; }
      catch { Message = "Relayed Exception."; }

      FullText = "Thread: " + ThreadName + Globals.NL
               + "Exception Type: " + Globals.NL
               + TypeText + Globals.NL
               + "Error Message: " + Globals.NL
               + Message;

      if ( Debugger.UseStack )
        FullText = FullText + Globals.NL
                 + "StackList: " + Globals.NL
                 + StackText;

      ReadableText = Message + Globals.NL2
                   + "  Module: " + ModuleName + Globals.NL
                   + "  File: " + FileName + Globals.NL
                   + "  Line: " + LineNumber + Globals.NL
                   + "  Method: " + Namespace + "." + ClassName + "." + MethodName + Globals.NL
                   + "  Type: " + TypeText;

      SingleLineText = ReadableText.Replace(Globals.NL2, " | ")
                                   .Replace(Globals.NL, " | ")
                                   .Replace("  ", "");
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="sender">.</param>
    /// <param name="ex">The ex.</param>
    public ExceptionInfo(object sender, Exception ex)
    {
      if ( ex == null ) return;
      Sender = sender;
      Instance = ex;
      TargetSite = ex.TargetSite;
      try
      {
        Emitter = Sender is ExceptionForm
                  ? ( (ExceptionForm)Sender ).Text
                  : Globals.MainForm != null
                    ? Globals.MainForm.Text
                    : ex.Source;
        ExtractInherits();
        try
        {
          ExtractStack();
        }
        finally
        {
          InitText();
        }
        if ( ex.InnerException != null )
          InnerInfo = new ExceptionInfo(sender, ex.InnerException);
      }
      catch
      {
      }
    }

  }

}
