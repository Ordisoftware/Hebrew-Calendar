/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// Project is registered at Depotnumerique.com (Agence des Depots Numeriques).
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2018-11 </created>
/// <edited> 2019-01 </edited>
using System;
using System.Drawing;
using Ordisoftware.Core;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Form for viewing the tray icon.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  public partial class TrayIconForm : Form
  {

    /// <summary>
    /// The instance.
    /// </summary>
    static internal TrayIconForm Instance { get; private set; }

    /// <summary>
    /// Indicates the singleton instance.
    /// </summary>
    static TrayIconForm()
    {
      Instance = new TrayIconForm();
    }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public TrayIconForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      TrayIcon.Icon = Icon;
      Visible = false;
      Text = AboutBox.Instance.AssemblyTitle;
      SystemEvents.SessionEnding += SessionEnding;
      Form form = new Form();
      form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      form.ShowInTaskbar = false;
      Owner = form;
    }

    /// <summary>
    /// Event handler. Called by TrayIconForm for load events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void TrayIconForm_Load(object sender, EventArgs e)
    {
      MenuShowHide.Image = Icon.ToBitmap();
      try
      {
        MenuShowHide_Click(null, null);
        if ( MainForm.Instance.lunisolarCalendar.LunisolarDays.Count > 0 )
          MenuShowHide_Click(null, null);
        else
        if ( DisplayManager.QueryYesNo("Database is empty." + Environment.NewLine + 
                                       "Do you want to generate a calendar?") )
          MainForm.Instance.actionGenerate.PerformClick();
        else
          MenuShowHide_Click(null, null);
      }
      catch ( Exception except )
      {
        MessageBox.Show(except.Message);
      }
    }

    /// <summary>
    /// Event handler. Called by TrayIconForm for form closed events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Form closed event information.</param>
    private void TrayIconForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      Program.Settings.Store();
    }

    /// <summary>
    /// Session ending.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Session ending event information.</param>
    private void SessionEnding(object sender, SessionEndingEventArgs e)
    {
      Close();
    }

    /// <summary>
    /// Event handler. Called by MenuExit for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void MenuExit_Click(object sender, EventArgs e)
    {
      if ( Program.Settings.ConfirmClosing && !DisplayManager.QueryYesNo("Exit application ?") ) return;
      Close();
    }

    /// <summary>
    /// Event handler. Called by MenuAbout for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void MenuAbout_Click(object sender, EventArgs e)
    {
      if ( AboutBox.Instance.Visible )
        AboutBox.Instance.BringToFront();
      else
        AboutBox.Instance.ShowDialog();
    }

    /// <summary>
    /// Event handler. Called by MenuShowHide for click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void MenuShowHide_Click(object sender, EventArgs e)
    {
      var form = MainForm.Instance;
      if ( !form.Visible )
      {
        form.Visible = true;
        form.WindowState = Program.Settings.MainFormState;
        form.ShowInTaskbar = true;
      }
      else
      if ( form.WindowState == FormWindowState.Minimized )
        form.WindowState = Program.Settings.MainFormState;
      else
      {
        Program.Settings.MainFormState = form.WindowState;
        form.WindowState = FormWindowState.Minimized;
        form.Visible = false;
        form.ShowInTaskbar = false;
      }
      MenuShowHide.Text = form.Visible ? "Hide" : "Restore";
    }

    /// <summary>
    /// Event handler. Called by TrayIcon for mouse click events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Mouse event information.</param>
    private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
    {
      if ( e.Button != MouseButtons.Left ) return;
      var form = ShowDayForm.Instance;
      if ( !form.Visible )
      {
        try
        {
          form.Date = DateTime.Now;
          form.Visible = true;
          form.BringToFront();
        }
        catch
        {
        }
      }
      else
      {
        form.Visible = false;
        form.ShowInTaskbar = false;
      }
    }

  }

}
