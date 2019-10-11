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
/// <edited> 2019-08 </edited>
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ordisoftware.HebrewCalendar
{

  public partial class ReminderForm : Form
  {

    static internal readonly List<Form> RemindCelebrationForms = new List<Form>();

    static internal readonly List<string> RemindCelebrationDates = new List<string>();

    static internal readonly Dictionary<TorahEventType, DateTime?> LastCelebrationReminded
      = new Dictionary<TorahEventType, DateTime?>();

    static internal readonly Dictionary<TorahEventType, ReminderForm> RemindCelebrationDayForms
      = new Dictionary<TorahEventType, ReminderForm>();

    static internal DateTime? LastShabatReminded = null;

    static internal ReminderForm ShabatForm;

    static internal void ClearLists()
    {
      int min = Enum.GetValues(typeof(TorahEventType)).Cast<int>().Min();
      int max = Enum.GetValues(typeof(TorahEventType)).Cast<int>().Max();
      foreach ( Form item in RemindCelebrationForms.ToList() )
        item.Close();
      RemindCelebrationDates.Clear();
      for ( int index = min; index < max; index++ )
        if ( LastCelebrationReminded.ContainsKey((TorahEventType)index) )
          LastCelebrationReminded[(TorahEventType)index] = null;
      for ( int index = min; index < max; index++ )
        if ( RemindCelebrationDayForms.ContainsKey((TorahEventType)index) )
          RemindCelebrationDayForms[(TorahEventType)index].Close();
      RemindCelebrationDayForms.Clear();
      LastShabatReminded = null;
      ShabatForm = null;
    }

    static ReminderForm()
    {
      foreach ( TorahEventType value in Enum.GetValues(typeof(TorahEventType)) )
        LastCelebrationReminded.Add(value, null);
    }

    static public void Run(Data.LunisolarCalendar.LunisolarDaysRow row, bool isShabat, TorahEventType torahevent, string time1, string time2)
    {
      ReminderForm form = null;
      if ( isShabat && ShabatForm != null )
      {
        ShabatForm.Hide();
        System.Threading.Thread.Sleep(1000);
        ShabatForm.Show();
        ShabatForm.BringToFront();
        return;
      }
      else
      if ( torahevent != TorahEventType.None )
      {
        if ( RemindCelebrationDayForms.ContainsKey(torahevent) )
        {
          RemindCelebrationDayForms[torahevent].Hide();
          System.Threading.Thread.Sleep(1000);
          RemindCelebrationDayForms[torahevent].Show();
          RemindCelebrationDayForms[torahevent].BringToFront();
          return;
        }
      }
      else
        foreach ( var item in RemindCelebrationForms )
          if ( (string)item.Tag == row.Date )
          {
            item.Hide();
            System.Threading.Thread.Sleep(1000);
            item.Show();
            item.BringToFront();
            return;
          }
      form = new ReminderForm();
      var date = SQLiteUtility.GetDate(row.Date);
      form.LabelNextCelebrationText.Text = !isShabat
                                         ? Translations.TorahEvent.GetLang((TorahEventType)row.TorahEvents)
                                         : "Shabat";
      form.LabelNextCelebrationDate.Text = date.ToLongDateString();
      form.LabelHours.Text = time1 + " - " + time2;
      form.LabelNextCelebrationDate.Tag = date;
      int left = SystemInformation.WorkingArea.Left;
      int top = SystemInformation.WorkingArea.Top;
      int width = SystemInformation.WorkingArea.Width;
      int height = SystemInformation.WorkingArea.Height;
      form.Location = new Point(left + width - form.Width, top + height - form.Height);
      form.Tag = row.Date;
      form.Text = form.LabelNextCelebrationText.Text;
      form.IsShabat = isShabat;
      if ( isShabat )
        ShabatForm = form;
      else
      if ( torahevent != TorahEventType.None )
      {
        foreach ( var item in RemindCelebrationForms.ToList() )
          if ( (string)item.Tag == row.Date )
          {
            item.Close();
            break;
          }
        RemindCelebrationDayForms.Add(torahevent, form);
      }
      else
        RemindCelebrationForms.Add(form);
      form.Show();
      form.BringToFront();
    }

    protected override bool ShowWithoutActivation { get { return true; } }

    private bool IsShabat;

    private ReminderForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
    }

    private void ReminderForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      if ( IsShabat )
        ShabatForm = null;
      else
      {
        RemindCelebrationForms.Remove(this);
        RemindCelebrationDayForms.Remove(RemindCelebrationDayForms.FirstOrDefault(x => x.Value == this).Key);
      }
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

  }

}
