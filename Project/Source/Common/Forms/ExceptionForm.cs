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
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Indicate the original form height.
    /// </summary>
    private int OriginalHeight;

    /// <summary>
    /// Indicates error messages.
    /// </summary>
    private readonly List<string> ErrorMessages 
      = new List<string>();

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
        form.ActionViewStack.Enabled = DebugManager.UseStack;
        form.ActionViewInner.Enabled = einfo.InnerInfo != null;
        form.ActionTerminate.Enabled = DebugManager.UserCanTerminate && !isInner;
        if ( isInner )
        {
          form.ActionSendToGitHub.Enabled = false;
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
        if ( DebugManager.AutoHideStack ) form.ActionViewStack_Click(form, null);
        if ( !DebugManager.UseStack ) form.ActionViewStack_Click(form, null);
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
      SystemManager.Terminate();
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
    /// Event handler. Called by ActionViewLog for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionViewLog_Click(object sender, EventArgs e)
    {
      DebugManager.TraceForm.Show();
      DebugManager.TraceForm.BringToFront();
    }

    /// <summary>
    /// Event handler. Called by ActionSend for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void ActionSendToGitHub_Click(object sender, EventArgs e)
    {
      if ( ErrorInfo == null ) return;
      SystemManager.TryCatchManage(() =>
      {
        var query = new StringBuilder();
        query.Append("&title=" + ErrorInfo.Instance.GetType().Name + " in " + Globals.AssemblyTitleWithVersion);
        query.Append("&labels=type: bug");
        query.Append("&body=");
        query.Append(WebUtility.UrlEncode(CreateBody().ToString()));
        if ( query.Length > 8000 )
          SystemManager.CreateGitHubIssue(query.ToString().Substring(0, 8000).TrimEnd('%'));
        else
          SystemManager.CreateGitHubIssue(query.ToString());
      });
    }

    private void ActionSendMail_Click(object sender, EventArgs e)
    {
      if ( ErrorInfo == null ) return;
      SystemManager.TryCatchManage(() =>
      {
        var message = new MailMessage();
        message.To.Add(Globals.SupportEMail);
        message.Subject = $"[{Globals.AssemblyTitleWithVersion}] {ErrorInfo.Instance.GetType().Name}";
        string body = CreateBody().ToString();
        if ( body.Length > 2000 )
          message.Body = body.ToString().Substring(0, 2000);
        else
          message.Body = body.ToString();
        string query = message.ToUrl();
        SystemManager.RunShell(query.ToString());
      });
    }

    private StringBuilder CreateBody()
    {
      var body = new StringBuilder();
      body.AppendLine("## COMMENT");
      body.AppendLine();
      body.AppendLine(Localizer.GitHubIssueComment.GetLang());
      body.AppendLine();
      body.AppendLine("## SYSTEM");
      body.AppendLine();
      body.AppendLine(SystemManager.Platform);
      body.AppendLine("Total Visible Memory: " + SystemManager.TotalVisibleMemory);
      body.AppendLine("Free Physical Memory: " + SystemManager.PhysicalMemoryFree);
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
      body.AppendLine();
      body.AppendLine();
      body.AppendLine("## LOG");
      body.AppendLine();
      string text = DebugManager.TraceForm.TextBox.Text;
      if (text == "") ;
      var lines1 = text.Split();
      var lines2 = lines1.Where(l => { l = l.Trim(); return l != "" && !l.StartsWith("# ") && !l.StartsWith("--"); });
      body.Append(lines2.AsMultispace());
      return body;
    }

  }

  // https://codereview.stackexchange.com/questions/129594/c-helper-class-mailto#129600
  public static class MailHelper
  {

    public static string ToUrl(this MailMessage message)
      => "mailto:?" + Parameters(message).Join("&");

    static string Recipients(MailAddressCollection addresses)
      => (from r in addresses select Uri.EscapeDataString(r.Address)).Join(",");

    static IEnumerable<string> Parameters(MailMessage message)
    {
      if ( message.To.Any() )
        yield return "to=" + Recipients(message.To);
      if ( message.CC.Any() )
        yield return "cc=" + Recipients(message.CC);
      if ( message.Bcc.Any() )
        yield return "bcc=" + Recipients(message.Bcc);
      if ( !string.IsNullOrWhiteSpace(message.Subject) )
        yield return "subject=" + Uri.EscapeDataString(message.Subject);
      if ( !string.IsNullOrWhiteSpace(message.Body) )
        yield return "body=" + Uri.EscapeDataString(message.Body);
    }

  }

}
