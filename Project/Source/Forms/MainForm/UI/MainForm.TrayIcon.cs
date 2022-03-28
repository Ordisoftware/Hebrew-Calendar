/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2022 Olivier Rogier.
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
/// <edited> 2021-11 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class MainForm
{

  private void DoTrayIconMouse_Click(object sender, MouseEventArgs e)
  {
    if ( !Globals.IsReady ) return;
    SystemManager.TryCatchManage(() =>
    {
      TimerBallon.Stop();
      TimerTrayMouseMove.Stop();
      if ( e is not null )
      {
        if ( e.Button == MouseButtons.Left )
          switch ( Settings.TrayIconClickOpen )
          {
            case TrayIconClickOpen.MainForm:
              MenuShowHide_Click(TrayIcon, MenuTray.Enabled ? EventArgs.Empty : null);
              break;
            case TrayIconClickOpen.NextCelebrationsForm:
              if ( NextCelebrationsForm.Instance?.Visible == true )
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
              throw new AdvNotImplementedException(Settings.TrayIconClickOpen);
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
      if ( Visible && WindowState == FormWindowState.Minimized && ( sender is null or NotifyIcon ) )
      {
        WindowState = Settings.MainFormState;
        UpdateTitles(true);
        this.Popup();
      }
      else
      if ( !Visible || e is null )
      {
        FormBorderStyle = FormBorderStyle.Sizable;
        UpdateTitles(true);
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
          CalendarMonth.Refresh();
        }
        if ( sender is not null )
          if ( !NavigationForm.Instance.Visible )
            if ( Settings.MainFormShownGoToToday )
              GoToDate(DateTime.Today);
            else
              GoToDate(CalendarMonth.CalendarDate.Date);
      }
      else
      if ( Visible && !this.IsVisibleOnTop(Globals.WindowDetectionMargin) )
      {
        this.Popup();
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

  private void DoMenuExit_Click(object sender, EventArgs e)
  {
    if ( Globals.IsGenerating )
    {
      DisplayManager.ShowInformation(SysTranslations.CantExitWhileGenerating.GetLang());
      return;
    }
    if ( EditConfirmClosing.Checked || ( e is null && !Globals.IsDevExecutable ) )
      if ( !DisplayManager.QueryYesNo(SysTranslations.AskToExitApplication.GetLang()) )
        return;
    Globals.AllowClose = true;
    Close();
  }

}
