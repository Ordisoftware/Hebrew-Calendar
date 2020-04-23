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
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Ordisoftware.Core.Diagnostics;
using Ordisoftware.HebrewCommon;

namespace Ordisoftware.Core.Windows.Forms
{

  /// <summary>
  /// Provide exception visualisation.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  internal partial class ExceptionForm : Form
  {

    /// <summary>
    /// The button stack text.
    /// </summary>
    private string _ButtonStackText;

    /// <summary>
    /// Information describing the error.
    /// </summary>
    private ExceptionInfo _ErrorInfo;

    /// <summary>
    /// Message describing the error.
    /// </summary>
    private List<string> _ErrorMsg = new List<string>();

    /// <summary>
    /// Run the given einfo.
    /// </summary>
    /// <param name="einfo">The einfo.</param>
    static public void Run(ExceptionInfo einfo, bool isInner = false)
    {
      using ( ExceptionForm f = new ExceptionForm() )
      {
        //f.Text = einfo.Emitter + " has caused an error";
        f.printPreviewDialog.FindForm().WindowState = FormWindowState.Maximized;
        f.buttonViewLog.Visible = false; // SystemManager.Log.Active;
        f.buttonViewStack.Enabled = Debugger.UseStack;
        f.buttonViewInner.Enabled = einfo.InnerInfo != null;
        f.buttonTerminate.Enabled = Debugger.UserCanTerminate && !isInner;
        if ( isInner )
        {
          f.buttonPrint.Enabled = false;
          f.buttonSendMail.Enabled = false;
          f.buttonClose.Text = "Ok";
        }
        f.textException.Text = einfo.TypeText;
        f.textMessage.Text = einfo.Message;
        f.labelInfo1.Text += einfo.Emitter + " " + Globals.AssemblyVersion;
        f.textStack.Text = /*"[Thread: " + einfo.ThreadName + "]"
                         + Environment.NewLine + Environment.NewLine
                         +*/ einfo.StackText;
        f._ErrorMsg.Add(f.textException.Text);
        f._ErrorMsg.Add(Environment.NewLine);
        f._ErrorMsg.Add(f.textMessage.Text);
        f._ErrorMsg.Add(Environment.NewLine);
        f._ErrorMsg.Add(f.textStack.Text);
        f._OriginalHeight = f.Height;
        f._ErrorInfo = einfo;
        f._ButtonStackText = f.buttonViewStack.Text;
        f.buttonViewStack.Text += " <<";
        //if ( Diagnostics.Debugger.AutoHideStack ) f.buttonViewStack_Click(f, null);
        if ( !Diagnostics.Debugger.UseStack ) f.buttonViewStack_Click(f, null);
        f.BringToFront();
        f.ShowDialog();
      }
    }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ExceptionForm()
    {
      InitializeComponent();
      Icon = HebrewCommon.Globals.MainForm.Icon;
    }

    /// <summary>
    /// Height of the original.
    /// </summary>
    private int _OriginalHeight;

    /// <summary>
    /// Event handler. Called by buttonViewStack for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void buttonViewStack_Click(object sender, EventArgs e)
    {
      if ( Height == _OriginalHeight )
      { 
        Height = textStack.Top + 28; 
        buttonViewStack.Text = _ButtonStackText + " >>";
      }
      else
      { 
        Height = _OriginalHeight;
        buttonViewStack.Text = _ButtonStackText + " <<";
      }
    }

    /// <summary>
    /// Event handler. Called by buttonViewInner for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void buttonViewInner_Click(object sender, EventArgs e)
    {
      ExceptionForm.Run(_ErrorInfo.InnerInfo, true);
    }

    /// <summary>
    /// Event handler. Called by buttonViewLog for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void buttonViewLog_Click(object sender, EventArgs e)
    {
      /*Invoke(new Action<Logger, bool>((log, b) => LogForm.Run(log, b)),
             new object[] { SystemManager.Log, true });*/
    }

    /// <summary>
    /// Event handler. Called by buttonPrint for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void buttonPrint_Click(object sender, EventArgs e)
    {
      Hide();
      try
      {
        DialogResult res;
        //if ( SystemManager.Process.IsControlled ) res = printPreviewDialog.ShowDialog();
        //else res = printDialog.ShowDialog();
        res = printPreviewDialog.ShowDialog();
        if ( res == DialogResult.OK ) printDocument.Print();
      }
      finally
      {
        Show();
      }
    }

    /// <summary>
    /// Event handler. Called by printDocument for print page events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Print page event information.</param>
    private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
    {
      Font font1 = new Font("Arial", 12, FontStyle.Bold | FontStyle.Underline);
      Font font2 = new Font("Arial", 12, FontStyle.Regular);
      int x = 50, y = 50;
      string msg = "Error report for application : " + HebrewCommon.Globals.AssemblyTitle;
      e.Graphics.DrawString(msg, font1, Brushes.Black, x, y);
      y = y + (int)( font1.Height * 3 );
      foreach ( string s in _ErrorMsg )
      {
        e.Graphics.DrawString(s, font2, Brushes.Black, x, y);
        y = y + (int)( font2.Height * 1.5 );
      }
    }

    /// <summary>
    /// Event handler. Called by buttonSendMail for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void buttonSendMail_Click(object sender, EventArgs e)
    {
      if ( _ErrorInfo == null ) return;
      TopMost = false;
      string query = "&title=" + _ErrorInfo.Instance.GetType().Name + " in " + Globals.AssemblyTitleWithVersion
                   + "&labels=type: bug"
                   + "&body=";
      string body = "## USER COMMENT" + Environment.NewLine + Environment.NewLine
                  + "Describe here what you did, what you expected and what happened." + Environment.NewLine + Environment.NewLine
                  + "## ERROR : " + _ErrorInfo.Instance.GetType().Name + Environment.NewLine + Environment.NewLine
                  + _ErrorInfo.Message + Environment.NewLine + Environment.NewLine
                  + "#### _STACK_" + Environment.NewLine + Environment.NewLine
                  + _ErrorInfo.StackText;
      ExceptionInfo inner = _ErrorInfo.InnerInfo;
      while ( inner != null )
      {
        body = body + Environment.NewLine + Environment.NewLine
             + "## INNER : " + inner.Instance.GetType().Name + Environment.NewLine + Environment.NewLine
             + inner.Message + Environment.NewLine + Environment.NewLine
             + "#### _STACK_" + Environment.NewLine + Environment.NewLine
             + inner.StackText;
        inner = inner.InnerInfo;
      }
      query += body;
      query = query.Replace(" ", "%20").Replace("+", "%2B").Replace("#", "%23").Replace(Environment.NewLine, "%0A");
      SystemHelper.OpenGitHibIssuesPage(query);
      /*string email = SystemManager.User.UserMail;
      if ( email.IsNullOrEmpty() )
        if ( DisplayManager.QueryValue("User email", ref email) == InputValueResult.Cancelled)
          return;
      var files = FileTool.Exists(SystemManager.Log.Filename)
                  ? new string[] { SystemManager.Log.Filename }
                  : null;
      if ( Net.NetUtility.SendMail(email,
                                   SystemManager.Assembly.HelpMail,
                                   SystemManager.Assembly.MailSubject, 
                                   StringUtility.AsMultiline(_ErrorMsg), 
                                   false, files) )
        DisplayManager.Show("Message has been sent.");*/
    }

    /// <summary>
    /// Event handler. Called by buttonTerminate for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void buttonTerminate_Click(object sender, EventArgs e)
    {
      //SystemManager.Abort();
      Environment.Exit(0);
    }

  }

}