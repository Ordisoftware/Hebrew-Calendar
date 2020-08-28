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
/// <edited> 2012-10 </edited>
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide exception information.
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
        StackFrame frame = new StackFrame(skip, true);
        MethodBase method = frame.GetMethod();
        return GetNameWithFullNamespace(method.DeclaringType) + "." + method.Name +
               " (" + Path.GetFileName(frame.GetFileName()) + " line " + frame.GetFileLineNumber() + ")";
      }
      catch
      { return ""; }
    }

    /// <summary>
    /// Extracts the inherits.
    /// </summary>
    private void ExtractInherits()
    {
      Type type = Instance.GetType();
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
      int line;
      bool first = false;
      string s1 = "", s2 = "", s3 = "";
      if ( Diagnostics.Debugger.UseStack )
      {
        StackTrace trace = new StackTrace(Instance, true);
        StackFrame[] frames = trace.GetFrames();
        if ( frames == null ) return;
        foreach ( StackFrame frame in frames )
        {
          MethodBase method = frame.GetMethod();
          s2 = method.DeclaringType.FullName;
          Type type = Type.GetType(s2);
          if ( type != typeof(Debugger) && type != typeof(ExceptionInfo) )
          {
            s3 = Path.GetFileName(frame.GetFileName());
            //if ( s3 == null && Debugger.StackOnlyProgram ) continue;
            line = frame.GetFileLineNumber();
            if ( !first )
            {
              first = true;
              AssemblyName = method.DeclaringType.Assembly.FullName;
              ModuleName = method.DeclaringType.Module.Name;
              Namespace = method.DeclaringType.Namespace;
              ClassName = method.DeclaringType.Name;
              MethodName = method.Name;
              FileName = s3;
              LineNumber = line;
            }
            s2 += "." + method.Name;
            if ( line != 0 )
            {
              s2 = s3 + " line " + line + ": " + Environment.NewLine + s2 + Environment.NewLine;
              if ( s1 != "" ) s2 = Environment.NewLine + s2;
            }
            StackList.Add(s2);
            if ( s1 != "" ) s1 += Environment.NewLine;
            s1 += s2;
          }
        }
        // TODO corriger pb saut de lignes => utiliser list
        StackText = s1.Replace(Environment.NewLine + Environment.NewLine + Environment.NewLine, Environment.NewLine + Environment.NewLine)
                       .TrimEnd(Environment.NewLine.ToCharArray());
      }
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
      catch { Message = "Relayed exception."; }

      //int width = SystemSettings.Instance.LogWidth - 15;
      //int indent = SystemSettings.Instance.LogIndent;

      FullText = "Thread: " + ThreadName + Environment.NewLine
               + "Exception Type: " + Environment.NewLine
               + TypeText + Environment.NewLine
               + "Error Message: " + Environment.NewLine
               + Message;

      if ( Diagnostics.Debugger.UseStack )
        FullText = FullText + Environment.NewLine
                 + "StackList: " + Environment.NewLine
                 + StackText;

      ReadableText = Message + Environment.NewLine + Environment.NewLine
                   + "  Module: " + ModuleName + Environment.NewLine
                   + "  File: " + FileName + Environment.NewLine
                   + "  Line: " + LineNumber + Environment.NewLine
                   + "  Method: " + Namespace + "." + ClassName + "." + MethodName + Environment.NewLine
                   + "  Type: " + TypeText;

      SingleLineText = ReadableText.Replace(Environment.NewLine + Environment.NewLine, " | ")
                                   .Replace(Environment.NewLine, " | ")
                                   .Replace("  ", "");
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="sender">.</param>
    /// <param name="ex">The except.</param>
    public ExceptionInfo(object sender, Exception ex)
    {
      if ( ex == null ) return;
      Sender = sender;
      Instance = ex;
      TargetSite = ex.TargetSite;
      try
      {
        Emitter = Sender is Windows.Forms.ExceptionForm
                  ? ( (Windows.Forms.ExceptionForm)Sender ).Text
                  : DisplayManager.MainForm != null
                    ? DisplayManager.MainForm.Text
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