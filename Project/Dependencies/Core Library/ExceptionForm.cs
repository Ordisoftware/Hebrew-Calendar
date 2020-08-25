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
using Microsoft.Win32;
using Ordisoftware.Core.Diagnostics;
using Ordisoftware.HebrewCommon;
using System.Management;

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
    private string ButtonStackText;

    /// <summary>
    /// Information describing the error.
    /// </summary>
    private ExceptionInfo ErrorInfo;

    /// <summary>
    /// Message describing the error.
    /// </summary>
    private List<string> ErrorMsg = new List<string>();

    /// <summary>
    /// Run the given einfo.
    /// </summary>
    static public void Run(ExceptionInfo einfo, bool isInner = false)
    {
      using ( ExceptionForm form = new ExceptionForm() )
      {
        form.printPreviewDialog.FindForm().WindowState = FormWindowState.Maximized;
        form.buttonViewLog.Visible = false; // SystemManager.Log.Active;
        form.buttonViewStack.Enabled = Debugger.UseStack;
        form.buttonViewInner.Enabled = einfo.InnerInfo != null;
        form.buttonTerminate.Enabled = Debugger.UserCanTerminate && !isInner;
        if ( isInner )
        {
          form.buttonPrint.Enabled = false;
          form.buttonSendMail.Enabled = false;
          form.buttonClose.Text = "OK";
        }
        form.textException.Text = einfo.TypeText;
        form.textMessage.Text = einfo.Message;
        form.labelInfo1.Text += einfo.Emitter + " " + Globals.AssemblyVersion;
        form.textStack.Text = /*"[Thread: " + einfo.ThreadName + "]"
                            + Environment.NewLine + Environment.NewLine
                            +*/ einfo.StackText;
        form.ErrorMsg.Add(form.textException.Text);
        form.ErrorMsg.Add(Environment.NewLine);
        form.ErrorMsg.Add(form.textMessage.Text);
        form.ErrorMsg.Add(Environment.NewLine);
        form.ErrorMsg.Add(form.textStack.Text);
        form.OriginalHeight = form.Height;
        form.ErrorInfo = einfo;
        form.ButtonStackText = form.buttonViewStack.Text;
        form.buttonViewStack.Text += " <<";
        if ( Debugger.AutoHideStack ) form.buttonViewStack_Click(form, null);
        if ( !Debugger.UseStack ) form.buttonViewStack_Click(form, null);
        form.BringToFront();
        form.ShowDialog();
      }
    }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ExceptionForm()
    {
      InitializeComponent();
      Icon = Globals.MainForm.Icon;
    }

    /// <summary>
    /// Height of the original.
    /// </summary>
    private int OriginalHeight;

    /// <summary>
    /// Event handler. Called by buttonViewStack for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void buttonViewStack_Click(object sender, EventArgs e)
    {
      if ( Height == OriginalHeight )
      { 
        Height = textStack.Top + 28; 
        buttonViewStack.Text = ButtonStackText + " >>";
      }
      else
      { 
        Height = OriginalHeight;
        buttonViewStack.Text = ButtonStackText + " <<";
      }
    }

    /// <summary>
    /// Event handler. Called by buttonViewInner for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void buttonViewInner_Click(object sender, EventArgs e)
    {
      Run(ErrorInfo.InnerInfo, true);
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
      foreach ( string s in ErrorMsg )
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
      if ( ErrorInfo == null ) return;
      try
      {
        TopMost = false;
        string NewLine = Environment.NewLine;
        string NewLine2 = NewLine + NewLine;
        string query = "&title=" + ErrorInfo.Instance.GetType().Name + " in " + Globals.AssemblyTitleWithVersion
                     + "&labels=type: bug"
                     + "&body=";
        string body = "## COMMENT" + NewLine2
                    + Globals.GitHubIssueComment.GetLang() + NewLine2
                    + "## ERROR : " + ErrorInfo.Instance.GetType().Name + NewLine2
                    + ErrorInfo.Message + NewLine2
                    + "#### _STACK_" + NewLine2
                    + ErrorInfo.StackText;
        ExceptionInfo inner = ErrorInfo.InnerInfo;
        while ( inner != null )
        {
          body = body + NewLine2
               + "## INNER : " + inner.Instance.GetType().Name + NewLine2
               + inner.Message + NewLine2
               + "#### _STACK_" + NewLine2
               + inner.StackText;
          inner = inner.InnerInfo;
        }
        try
        {
          var key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion");
          string nameOS = (string)key.GetValue("productName");
          body += NewLine2
                + "## SYSTEM" + NewLine2
                + nameOS + " " + ( Environment.Is64BitOperatingSystem ? "64-bits" : "32-bits" );
          ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
          ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
          ManagementObjectCollection results = searcher.Get();
          if ( results.Count > 0 )
          {
            var enumerator = results.GetEnumerator();
            if ( enumerator.MoveNext() )
            {
              var instance = enumerator.Current;
              body += NewLine
                    + "Total Visible Memory: " + ((ulong)instance["TotalVisibleMemorySize"] * 1024 ).FormatBytesSize() + NewLine
                    + "Free Physical Memory: " + ((ulong)instance["FreePhysicalMemory"] * 1024 ).FormatBytesSize() + NewLine;
            }
          }
        }
        catch
        {
        }
        query += body;
        query = query.Replace(" ", "%20")
                     .Replace("+", "%2B")
                     .Replace("#", "%23")
                     .Replace(NewLine, "%0A")
                     .Replace("%0A%0A%0A", "%0A");
        Shell.CreateGitHubIssue(query);
      }
      catch ( Exception ex )
      {
        DisplayManager.ShowError(ex.Message);
      }
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
      Environment.Exit(-1);
    }

  }

}