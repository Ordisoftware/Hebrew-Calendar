/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2021 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2016-04 </created>
/// <edited> 2021-01 </edited>
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.Hebrew.Calendar
{

  public partial class MainForm
  {

    private void DoTrayIconMouse_Click(object sender, MouseEventArgs e)
    {
      SystemManager.TryCatchManage(() =>
      {
        TimerBallon.Stop();
        TimerTrayMouseMove.Stop();
        if ( e != null )
        {
          if ( e.Button == MouseButtons.Left )
            switch ( Settings.TrayIconClickOpen )
            {
              case TrayIconClickOpen.MainForm:
                MenuShowHide_Click(TrayIcon, MenuTray.Enabled ? EventArgs.Empty : null);
                break;
              case TrayIconClickOpen.NextCelebrationsForm:
                if ( NextCelebrationsForm.Instance != null && NextCelebrationsForm.Instance.Visible )
                  NextCelebrationsForm.Instance.Close();
                else
                  ActionViewCelebrations.PerformClick();
                break;
              case TrayIconClickOpen.NavigationForm:
                var form = NavigationForm.Instance;
                if ( form.Visible )
                  form.Visible = false;
                else
                  SystemManager.TryCatchManage(() =>
                  {
                    if ( Settings.MainFormShownGoToToday )
                      form.Date = DateTime.Today;
                    else
                      GoToDate(CalendarMonth.CalendarDate.Date);
                    form.Visible = true;
                  });
                break;
              default:
                throw new NotImplementedExceptionEx(Settings.TrayIconClickOpen);
            }
          else
        if ( e.Button == MouseButtons.Right )
            if ( NavigationForm.Instance.Visible )
              ActionNavigate.PerformClick();
        }
      });
    }

    public void DoMenuShowHide_Click(object sender, EventArgs e)
    {
      SystemManager.TryCatchManage(() =>
      {
        if ( Visible && ( WindowState == FormWindowState.Minimized ) )
        {
          WindowState = Settings.MainFormState;
          this.Popup();
        }
        else
        if ( !Visible || e == null )
        {
          FormBorderStyle = FormBorderStyle.Sizable;
          Visible = true;
          ShowInTaskbar = true;
          bool temp = Globals.IsReady;
          try
          {
            Globals.IsReady = false;
            WindowState = Settings.MainFormState;
          }
          finally
          {
            Globals.IsReady = temp;
          }
          if ( Globals.IsReady )
          {
            if ( IsTrayBallooned )
              NavigationForm.Instance.Hide();
            this.Popup();
          }
          if ( !NavigationForm.Instance.Visible )
            if ( Settings.MainFormShownGoToToday )
              new Task(() => DisplayManager.SyncMainUI(() => GoToDate(DateTime.Today))).Start();
            else
              new Task(() => DisplayManager.SyncMainUI(() => GoToDate(CalendarMonth.CalendarDate.Date))).Start();
        }
        else
        {
          Settings.MainFormState = WindowState;
          WindowState = FormWindowState.Minimized;
          Visible = false;
          ShowInTaskbar = false;
          FormBorderStyle = FormBorderStyle.SizableToolWindow;
          Settings.Store();
        }
        MenuShowHide.Text = SysTranslations.HideRestoreCaption.GetLang(Visible);
      });
    }

  }

}
