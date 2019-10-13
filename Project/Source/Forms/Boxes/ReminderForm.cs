/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2019 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2019-01 </created>
/// <edited> 2019-10 </edited>
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCalendar
{

  public partial class ReminderForm : Form
  {

    static ReminderForm()
    {
      foreach ( TorahEventType value in Enum.GetValues(typeof(TorahEventType)) )
        if ( !MainForm.Instance.LastCelebrationReminded.ContainsKey(value))
          MainForm.Instance.LastCelebrationReminded.Add(value, null);
    }

    static public void Run(Data.LunisolarCalendar.LunisolarDaysRow row, 
                           bool isShabat, 
                           TorahEventType torahevent,
                           DateTime? date1,
                           DateTime? date2,
                           string time1, 
                           string time2)
    {
      ReminderForm form = null;
      if ( isShabat && MainForm.Instance.ShabatForm != null )
      {
        Flash(MainForm.Instance.ShabatForm);
        return;
      }
      else
      if ( torahevent != TorahEventType.None )
      {
        if ( MainForm.Instance.RemindCelebrationDayForms.ContainsKey(torahevent) )
        {
          Flash(MainForm.Instance.RemindCelebrationDayForms[torahevent]);
          return;
        }
      }
      else
      {
        foreach ( var item in MainForm.Instance.RemindCelebrationDayForms )
          if ( (string)item.Value.Tag == row.Date )
            return;
        foreach ( var item in MainForm.Instance.RemindCelebrationForms )
          if ( (string)item.Tag == row.Date )
          {
            Flash(item);
            return;
          }
      }
      form = new ReminderForm();
      var date = SQLiteUtility.GetDate(row.Date);
      form.LabelNextCelebrationText.Text = !isShabat
                                         ? Translations.TorahEvent.GetLang((TorahEventType)row.TorahEvents)
                                         : "Shabat";
      form.LabelNextCelebrationDate.Text = date.ToLongDateString();
      if ( date1 != null)
        form.LabelHours.Text = Translations.DayOfWeek.GetLang(date1.Value.DayOfWeek) + " "
                             + time1 + " ➜ "
                             + Translations.DayOfWeek.GetLang(date2.Value.DayOfWeek) + " "
                             + time2;
      form.LabelNextCelebrationDate.Tag = date;
      int left = SystemInformation.WorkingArea.Left;
      int top = SystemInformation.WorkingArea.Top;
      int width = SystemInformation.WorkingArea.Width;
      int height = SystemInformation.WorkingArea.Height;
      form.Location = new Point(left + width - form.Width, top + height - form.Height);
      form.Tag = row.Date;
      form.Text = " " + form.LabelNextCelebrationText.Text;
      form.IsShabat = isShabat;
      if ( isShabat )
        MainForm.Instance.ShabatForm = form;
      else
      if ( torahevent != TorahEventType.None )
      {
        foreach ( var item in MainForm.Instance.RemindCelebrationForms.ToList() )
          if ( (string)item.Tag == row.Date )
          {
            item.Close();
            break;
          }
        MainForm.Instance.RemindCelebrationDayForms.Add(torahevent, form);
      }
      else
        MainForm.Instance.RemindCelebrationForms.Add(form);
      form.Show();
      form.BringToFront();
      Application.DoEvents();
      BringMainForm();
    }

    static private void BringMainForm()
    {
      if ( MainForm.Instance.Visible )
      {
        MainForm.Instance.Focus();
        MainForm.Instance.BringToFront();
      }
    }

    static private void Flash(Form form)
    {
      form.Hide();
      System.Threading.Thread.Sleep(500);
      form.Show();
      form.BringToFront();
      BringMainForm();
    }

    protected override bool ShowWithoutActivation { get { return true; } }

    private bool IsShabat;

    private ReminderForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
      ShowInTaskbar = Program.Settings.ShowReminderInTaskBar;
    }

    private void ReminderForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      if ( IsShabat )
        MainForm.Instance.ShabatForm = null;
      else
      {
        MainForm.Instance.RemindCelebrationForms.Remove(this);
        var key = MainForm.Instance.RemindCelebrationDayForms.FirstOrDefault(x => x.Value == this).Key;
        MainForm.Instance.RemindCelebrationDayForms.Remove(key);
      }
      SetFormsLocation();
    }

    private void ButtonClose_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void LabelNextCelebrationDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if ( LabelNextCelebrationDate.Tag == null ) return;
      if ( !MainForm.Instance.Visible ) MainForm.Instance.MenuShowHide.PerformClick();
      NavigationForm.Instance.Date = (DateTime)LabelNextCelebrationDate.Tag;
      Close();
    }

    private void PictureBox_Click(object sender, EventArgs e)
    {
      LabelNextCelebrationDate_LinkClicked(LabelNextCelebrationDate, null);
    }

    private void ReminderForm_Shown(object sender, EventArgs e)
    {
      SetFormsLocation();
    }

    private void SetFormsLocation()
    {
      var list = new List<ReminderForm>();
      if ( MainForm.Instance.ShabatForm != null )
        list.Add(MainForm.Instance.ShabatForm);
      foreach ( var item in MainForm.Instance.RemindCelebrationDayForms )
        list.Add(item.Value);
      foreach ( ReminderForm item in MainForm.Instance.RemindCelebrationForms )
        list.Add(item);
      int dy = 0;
      int y = SystemInformation.WorkingArea.Top + SystemInformation.WorkingArea.Height;
      foreach ( var item in list.OrderBy(f => f.Tag) )
      {
        item.Location = new Point(item.Left, y - item.Height - dy);
        dy += item.Height;
      }

    }
  }

}
