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

using System.Net;
using System.Net.Mail;

/// <summary>
/// Provides exception form.
/// </summary>
partial class ExceptionForm : Form
{

  private const int BodyLengthLimit = 8000;

  private const int BodyLengthLimitQuarter = BodyLengthLimit / 4;

  /// <summary>
  /// Indicates the error information.
  /// </summary>
  private ExceptionInfo ErrorInfo;

  /// <summary>
  /// Indicates error messages.
  /// </summary>
  private readonly List<string> ErrorMessages = new();

  private bool IsInner;

  /// <summary>
  /// Runs the form.
  /// </summary>
  static public void Run(ExceptionInfo einfo, bool isInner = false)
  {
    using var form = new ExceptionForm { IsInner = isInner };
    form.PictureBox.Image = ShellIcons.Error;
    form.ActionViewLog.Enabled = DebugManager.TraceEnabled;
    form.ActionViewInner.Enabled = einfo.InnerInfo is not null;
    form.ActionTerminate.Enabled = DebugManager.UserCanTerminate && !isInner;
    if ( isInner )
    {
      form.ActionSendToGitHub.Enabled = false;
      form.ActionClose.Text = SysTranslations.NextException.GetLang();
    }
    form.EditType.Text = einfo.TypeText;
    form.EditMessage.Text = einfo.Message;
    form.LabelInfoProgram.Text += einfo.Emitter;
    form.EditStack.Text = einfo.StackText;
    form.ErrorMessages.Add(form.EditType.Text);
    form.ErrorMessages.Add(Globals.NL);
    form.ErrorMessages.Add(form.EditMessage.Text);
    form.ErrorMessages.Add(Globals.NL);
    form.ErrorMessages.Add(form.EditStack.Text);
    form.ErrorInfo = einfo;
    if ( !DebugManager.UseStack )
    {
      int deltaHeight = form.EditStack.Height + form.Padding.Bottom;
      form.MinimumSize = new Size(form.MinimumSize.Width, form.MinimumSize.Height - deltaHeight);
      form.Height -= deltaHeight;
      form.SizeGripStyle = SizeGripStyle.Hide;
      form.FormBorderStyle = FormBorderStyle.FixedSingle;
    }
    form.BringToFront();
    form.ShowDialog();
  }

  /// <summary>
  /// Default constructor.
  /// </summary>
  private ExceptionForm()
  {
    InitializeComponent();
    Icon = Globals.MainForm?.Icon;
  }

  /// <summary>
  /// Event handler. Called by ExceptionForm for shown events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ExceptionForm_Shown(object sender, EventArgs e)
  {
    if ( !IsInner ) DisplayManager.DoSound(MessageBoxIcon.Error);
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
  /// Event handler. Called by ActionViewLog for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionViewLog_Click(object sender, EventArgs e)
  {
    DebugManager.TraceForm.Popup();
  }

  /// <summary>
  /// Event handler. Called by ActionSendToGitHub for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionSendToGitHub_Click(object sender, EventArgs e)
  {
    if ( ErrorInfo is null ) return;
    SystemManager.TryCatchManage(() =>
    {
      var query = new StringBuilder(1024);
      query.Append("&title=").Append(ErrorInfo.Instance.GetType().Name).Append(" in ").Append(Globals.AssemblyTitleWithVersion);
      query.Append("&labels=type: bug");
      query.Append("&body=");
      query.Append(WebUtility.UrlEncode(CreateBody().ToString()));
      if ( query.Length > BodyLengthLimit )
        SystemManager.CreateGitHubIssue(query.ToString().Substring(0, BodyLengthLimit).TrimEnd('%'));
      else
        SystemManager.CreateGitHubIssue(query.ToString());
    });
  }

  /// <summary>
  /// Event handler. Called by ActionSendMail for click events.
  /// </summary>
  /// <param name="sender">Source of the event.</param>
  /// <param name="e">Event information.</param>
  private void ActionSendMail_Click(object sender, EventArgs e)
  {
    if ( ErrorInfo is null ) return;
    SystemManager.TryCatchManage(() =>
    {
      using var message = new MailMessage();
      message.To.Add(Globals.SupportEMail);
      message.Subject = $"[{Globals.AssemblyTitleWithVersion}] {ErrorInfo.Instance.GetType().Name}";
      string body = CreateBody().ToString();
      message.Body = body.Length > BodyLengthLimitQuarter ? body.Substring(0, BodyLengthLimitQuarter) : body;
      SystemManager.RunShell(message.ToUrl());
    });
  }

  /// <summary>
  /// Creates the body for send by mail or to GitHub.
  /// </summary>
  private StringBuilder CreateBody()
  {
    var body = new StringBuilder(1024);
    body.AppendLine("## COMMENT");
    body.AppendLine();
    body.AppendLine(SysTranslations.GitHubIssueComment.GetLang());
    body.AppendLine();
    body.AppendLine("## SYSTEM");
    body.AppendLine();
    body.AppendLine("```");
    body.AppendLine(SystemManager.Platform);
    body.Append("Total Memory: ").AppendLine(SystemManager.TotalVisibleMemory);
    body.Append("Free Memory: ").AppendLine(SystemManager.PhysicalMemoryFree);
    body.AppendLine("```");
    body.AppendLine();
    body.Append("## ERROR : ").AppendLine(ErrorInfo.Instance.GetType().Name);
    body.AppendLine();
    body.AppendLine(ErrorInfo.Message);
    body.AppendLine();
    body.AppendLine("#### _STACK_");
    body.AppendLine();
    body.AppendLine("```");
    body.AppendLine(ErrorInfo.StackText);
    body.AppendLine("```");
    var inner = ErrorInfo.InnerInfo;
    while ( inner is not null )
    {
      body.AppendLine();
      body.Append("## INNER : ").AppendLine(inner.Instance.GetType().Name);
      body.AppendLine();
      body.AppendLine(inner.Message);
      body.AppendLine();
      body.AppendLine("#### _STACK_");
      body.AppendLine();
      body.AppendLine("```");
      body.AppendLine(inner.StackText);
      body.AppendLine("```");
      inner = inner.InnerInfo;
    }
    body.AppendLine();
    body.AppendLine("## LOG");
    body.AppendLine();
    var lines = DebugManager.TraceForm
                            .TextBoxCurrent
                            .Lines
                            .Select(l => ( l.StartsWith("# ", StringComparison.Ordinal)
                                           ? l.Remove(0, 2)
                                           : l ).TrimStart())
                            .Where(l => !l.StartsWith("--", StringComparison.Ordinal))
                            .TakeLast(100);
    body.AppendLine("```");
    body.AppendLine(lines.AsMultiLine());
    body.AppendLine("```");
    return body;
  }

}

// https://codereview.stackexchange.com/questions/129594/c-helper-class-mailto#129600
public static class MailHelper
{

  public static string ToUrl(this MailMessage message)
    => $"mailto:?{Parameters(message).Join("&")}";

  static string Recipients(MailAddressCollection addresses)
    => ( from r in addresses select Uri.EscapeDataString(r.Address) ).Join(",");

  static IEnumerable<string> Parameters(MailMessage message)
  {
    if ( message.To.Count > 0 )
      yield return $"to={Recipients(message.To)}";
    if ( message.CC.Count > 0 )
      yield return $"cc={Recipients(message.CC)}";
    if ( message.Bcc.Count > 0 )
      yield return $"bcc={Recipients(message.Bcc)}";
    if ( !string.IsNullOrWhiteSpace(message.Subject) )
      yield return $"subject={Uri.EscapeDataString(message.Subject)}";
    if ( !string.IsNullOrWhiteSpace(message.Body) )
      yield return $"body={Uri.EscapeDataString(message.Body)}";
  }

}
