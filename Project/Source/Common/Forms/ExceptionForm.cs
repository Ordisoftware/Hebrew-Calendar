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
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide exception form.
  /// </summary>
  public partial class ExceptionForm : Form
  {

    /// <summary>
    /// Indicate the button stack text.
    /// </summary>
    private string StackText;

    /// <summary>
    /// Indicate the error information.
    /// </summary>
    private ExceptionInfo ErrorInfo;

    /// <summary>
    /// Indicates error messages.
    /// </summary>
    private readonly List<string> ErrorMessages = new List<string>();

    /// <summary>
    /// Indicate the original form height.
    /// </summary>
    private int OriginalHeight;

    static public readonly NullSafeStringDictionary NextException
      = new NullSafeStringDictionary()
      {
        { Languages.EN, "Next" },
        { Languages.FR, "Suivante" }
      };

    /// <summary>
    /// Run the form.
    /// </summary>
    static public void Run(ExceptionInfo einfo, bool isInner = false)
    {
      using ( var form = new ExceptionForm() )
      {
        form.ActionViewStack.Enabled = Debugger.UseStack;
        form.ActionViewInner.Enabled = einfo.InnerInfo != null;
        form.ActionTerminate.Enabled = Debugger.UserCanTerminate && !isInner;
        if ( isInner )
        {
          form.ActionSend.Enabled = false;
          form.ActionClose.Text = NextException.GetLang();
        }
        form.TextException.Text = einfo.TypeText;
        form.TextMessage.Text = einfo.Message;
        form.LabelInfo1.Text += einfo.Emitter + " " + Globals.AssemblyVersion;
        form.TextStack.Text = einfo.StackText;
        form.ErrorMessages.Add(form.TextException.Text);
        form.ErrorMessages.Add(Globals.NL);
        form.ErrorMessages.Add(form.TextMessage.Text);
        form.ErrorMessages.Add(Globals.NL);
        form.ErrorMessages.Add(form.TextStack.Text);
        form.OriginalHeight = form.Height;
        form.ErrorInfo = einfo;
        form.StackText = form.ActionViewStack.Text;
        form.ActionViewStack.Text += " <<";
        if ( Debugger.AutoHideStack ) form.ActionViewStack_Click(form, null);
        if ( !Debugger.UseStack ) form.ActionViewStack_Click(form, null);
        form.BringToFront();
        form.ShowDialog();
      }
    }

    /// <summary>
    /// Default constructor.
    /// </summary>
    private ExceptionForm()
    {
      InitializeComponent();
      Icon = Globals.MainForm.Icon;
    }

    /// <summary>
    /// Event handler. Called by ActionTerminate for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionTerminate_Click(object sender, EventArgs e)
    {
      Environment.Exit(-1);
    }

    /// <summary>
    /// Event handler. Called by ActionViewInner for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionViewInner_Click(object sender, EventArgs e)
    {
      Run(ErrorInfo.InnerInfo, true);
    }

    /// <summary>
    /// Event handler. Called by ActionViewStack for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionViewStack_Click(object sender, EventArgs e)
    {
      if ( Height == OriginalHeight )
      {
        Height = TextStack.Top + 35;
        ActionViewStack.Text = StackText + " >>";
      }
      else
      {
        Height = OriginalHeight;
        ActionViewStack.Text = StackText + " <<";
      }
    }

    /// <summary>
    /// Event handler. Called by ActionSend for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionSend_Click(object sender, EventArgs e)
    {
      if ( ErrorInfo == null ) return;
      try
      {
        TopMost = false;
        var query = new StringBuilder();
        var body = new StringBuilder();
        // Query header
        query.Append("&title=" + ErrorInfo.Instance.GetType().Name + " in " + Globals.AssemblyTitleWithVersion);
        query.Append("&labels=type: bug");
        query.Append("&body=");
        // Query body
        body.AppendLine("## COMMENT");
        body.AppendLine();
        body.AppendLine(Localizer.GitHubIssueComment.GetLang());
        body.AppendLine();
        body.AppendLine("## SYSTEM");
        body.AppendLine();
        body.AppendLine(SystemHelper.Platform);
        body.AppendLine("Total Visible Memory: " + SystemHelper.TotalVisibleMemory);
        body.AppendLine("Free Physical Memory: " + SystemHelper.PhysicalMemoryFree);
        body.AppendLine();
        body.AppendLine("## ERROR : " + ErrorInfo.Instance.GetType().Name);
        body.AppendLine();
        body.AppendLine(ErrorInfo.Message);
        body.AppendLine();
        body.AppendLine("#### _STACK_");
        body.AppendLine();
        body.Append(ErrorInfo.StackText);
        ExceptionInfo inner = ErrorInfo.InnerInfo;
        while ( inner != null )
        {
          body.AppendLine();
          body.AppendLine();
          body.AppendLine("## INNER : " + inner.Instance.GetType().Name);
          body.AppendLine();
          body.AppendLine(inner.Message);
          body.AppendLine();
          body.AppendLine("#### _STACK_");
          body.AppendLine();
          body.Append(inner.StackText);
          inner = inner.InnerInfo;
        }
        // Send
        query.Append(System.Net.WebUtility.UrlEncode(body.ToString()));
        if ( query.Length > 8000 )
          Shell.CreateGitHubIssue(query.ToString().Substring(0, 8000));
        else
          Shell.CreateGitHubIssue(query.ToString());
      }
      catch ( Exception ex )
      {
        DisplayManager.ShowError(ex.Message);
      }
    }

  }

}
