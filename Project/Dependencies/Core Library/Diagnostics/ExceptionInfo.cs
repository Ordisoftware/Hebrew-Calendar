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
    public object Sender { get { return _Sender; } }

    /// <summary>
    /// The sender.
    /// </summary>
    private object _Sender;

    /// <summary>
    /// Get the emitter.
    /// </summary>
    public string Emitter { get { return _Emitter; } }

    /// <summary>
    /// The emitter.
    /// </summary>
    private string _Emitter = "";

    /// <summary>
    /// Get the instance.
    /// </summary>
    public Exception Instance { get { return _Instance; } }

    /// <summary>
    /// The instance.
    /// </summary>
    private Exception _Instance;

    /// <summary>
    /// Get information describing the inner.
    /// </summary>
    public ExceptionInfo InnerInfo { get { return _InnerInfo; } }

    /// <summary>
    /// Information describing the inner.
    /// </summary>
    private ExceptionInfo _InnerInfo;

    /// <summary>
    /// Get the type text.
    /// </summary>
    public string TypeText { get { return _TypeText; } }

    /// <summary>
    /// The type text.
    /// </summary>
    private string _TypeText = "";

    /// <summary>
    /// Get the inherits from.
    /// </summary>
    public string InheritsFrom { get { return _InheritsFrom; } }

    /// <summary>
    /// The inherits from.
    /// </summary>
    private string _InheritsFrom = "";

    /// <summary>
    /// Get the name of the thread.
    /// </summary>
    public string ThreadName { get { return _ThreadName; } }

    /// <summary>
    /// Name of the thread.
    /// </summary>
    private string _ThreadName = "";

    /// <summary>
    /// Get the name of the assembly.
    /// </summary>
    public string AssemblyName { get { return _AssemblyName; } }

    /// <summary>
    /// Name of the assembly.
    /// </summary>
    private string _AssemblyName = "";

    /// <summary>
    /// Get the name of the module.
    /// </summary>
    public string ModuleName { get { return _ModuleName; } }

    /// <summary>
    /// Name of the module.
    /// </summary>
    private string _ModuleName = "";

    /// <summary>
    /// Get the namespace.
    /// </summary>
    public string Namespace { get { return _Namespace; } }

    /// <summary>
    /// The namespace.
    /// </summary>
    private string _Namespace = "";

    /// <summary>
    /// Get the filename of the file.
    /// </summary>
    public string FileName { get { return _FileName; } }

    /// <summary>
    /// Filename of the file.
    /// </summary>
    private string _FileName = "";

    /// <summary>
    /// Get the name of the class.
    /// </summary>
    public string ClassName { get { return _ClassName; } }

    /// <summary>
    /// Name of the class.
    /// </summary>
    private string _ClassName = "";

    /// <summary>
    /// Get the name of the method.
    /// </summary>
    public string MethodName { get { return MethodName; } }

    /// <summary>
    /// Name of the method.
    /// </summary>
    private string _MethodName = "";

    /// <summary>
    /// Get the line number.
    /// </summary>
    public int LineNumber { get { return _LineNumber; } }

    /// <summary>
    /// The line number.
    /// </summary>
    private int _LineNumber = 0;

    /// <summary>
    /// Get target site.
    /// </summary>
    public MethodBase TargetSite { get { return _TargetSite; } }

    /// <summary>
    /// Target site.
    /// </summary>
    private MethodBase _TargetSite;

    /// <summary>
    /// Get the message.
    /// </summary>
    public string Message { get { return _Message; } }

    /// <summary>
    /// The message.
    /// </summary>
    private string _Message = "";

    /// <summary>
    /// Get the full text.
    /// </summary>
    public string FullText { get { return _FullText; } }

    /// <summary>
    /// The full text.
    /// </summary>
    private string _FullText = "";

    /// <summary>
    /// Get the readable text.
    /// </summary>
    public string ReadableText { get { return _ReadableText; } }

    /// <summary>
    /// The readable text.
    /// </summary>
    private string _ReadableText = "";

    /// <summary>
    /// The readable text.
    /// </summary>
    // TODO use
    private string _SimpleText = "";

    /// <summary>
    /// Get the stack text.
    /// </summary>
    public string StackText { get { return _StackText; } }

    /// <summary>
    /// The stack text.
    /// </summary>
    private string _StackText = "";

    /// <summary>
    /// Get a list of stacks.
    /// </summary>
    public List<string> StackList { get { return _StackList; } }

    /// <summary>
    /// List of stacks.
    /// </summary>
    private List<string> _StackList = new List<string>();

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
        StackFrame sf = new StackFrame(skip, true);
        System.Reflection.MethodBase m = sf.GetMethod();
        return GetNameWithFullNamespace(m.DeclaringType) + "." + m.Name +
               " (" + Path.GetFileName(sf.GetFileName()) + " line " + sf.GetFileLineNumber() + ")";
      }
      catch
      { return ""; }
    }

    /// <summary>
    /// Extracts the inherits.
    /// </summary>
    private void ExtractInherits()
    {
      Type t = _Instance.GetType();
      _TypeText = t.ToString();
      t = t.BaseType;
      _InheritsFrom += t.ToString();
      while ( ( t = t.BaseType ) != null ) _InheritsFrom += " > " + t.ToString();
    }

    /// <summary>
    /// Extracts the stack.
    /// </summary>
    private void ExtractStack()
    {
      string s1 = "", s2 = "", s3 = "";
      int ln;
      bool b = false;
      if ( Diagnostics.Debugger.UseStack )
      {
        StackTrace stack = new StackTrace(_Instance, true);
        StackFrame[] sflist = stack.GetFrames();
        if ( sflist == null ) return;
        foreach ( StackFrame sf in sflist )
        {
          System.Reflection.MethodBase m = sf.GetMethod();
          s2 = m.DeclaringType.FullName;
          Type t = Type.GetType(s2);
          if ( t != typeof(Debugger) && t != typeof(ExceptionInfo) )
          {
            s3 = Path.GetFileName(sf.GetFileName());
            //if ( s3 == null && Debugger.StackOnlyProgram ) continue;
            ln = sf.GetFileLineNumber();
            if ( !b )
            {
              b = true;
              _AssemblyName = m.DeclaringType.Assembly.FullName;
              _ModuleName = m.DeclaringType.Module.Name;
              _Namespace = m.DeclaringType.Namespace;
              _ClassName = m.DeclaringType.Name;
              _MethodName = m.Name;
              _FileName = s3;
              _LineNumber = ln;
            }
            s2 += "." + m.Name;
            if ( ln != 0 )
            {
              s2 = s3 + " line " + ln + ": " + Environment.NewLine + s2 + Environment.NewLine;
              if ( s1 != "" ) s2 = Environment.NewLine + s2;
            }
            _StackList.Add(s2);
            if ( s1 != "" ) s1 += Environment.NewLine;
            s1 += s2;
          }
        }
        _StackText = s1;
      }
    }

    /// <summary>
    /// Initialises the text.
    /// </summary>
    private void InitText()
    {
      if ( Thread.CurrentThread.Name != null ) _ThreadName = Thread.CurrentThread.Name;
      else _ThreadName = "ID = " + Thread.CurrentThread.ManagedThreadId.ToString();
      if ( _ModuleName != null && _ModuleName != "" ) _TypeText += " in " + _ModuleName;
      try { _Message = _Instance.Message; }
      catch { _Message = "Relayed exception."; }

      string nl = Environment.NewLine;
      //int width = SystemSettings.Instance.LogWidth - 15;
      //int indent = SystemSettings.Instance.LogIndent;

      _FullText = "Thread: " + _ThreadName + nl
                + "Exception Type: " + nl
                + _TypeText + nl
                + "Error Message: " + nl
                + _Message;

      if ( Diagnostics.Debugger.UseStack )
        _FullText = _FullText + nl
                  + "StackList: " + nl
                  + _StackText;

      _ReadableText = _Message + nl + nl
                    + "  Module: " + _ModuleName + nl
                    + "  File: " + _FileName + nl
                    + "  Line: " + _LineNumber + nl
                    + "  Method: " + _Namespace + "." + _ClassName + "." + _MethodName + nl
                    + "  Type: " + _TypeText;

      _SimpleText = "";
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="sender">.</param>
    /// <param name="except">The except.</param>
    public ExceptionInfo(object sender, Exception except)
    {
      if ( except == null ) return;
      _Sender = sender;
      _Instance = except;
      _TargetSite = except.TargetSite;
      try
      {
        _Emitter = _Sender is Windows.Forms.ExceptionForm
                 ? ( (Windows.Forms.ExceptionForm)_Sender ).Text
                 : DisplayManager.MainForm != null
                   ? DisplayManager.MainForm.Text
                   : except.Source;
        ExtractInherits();
        try
        {
          ExtractStack();
        }
        finally
        {
          InitText();
        }
        if ( except.InnerException != null )
          _InnerInfo = new ExceptionInfo(sender, except.InnerException);
      }
      catch
      {
      }
    }

  }

}