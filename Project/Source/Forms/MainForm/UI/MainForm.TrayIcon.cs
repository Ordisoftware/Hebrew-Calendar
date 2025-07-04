﻿/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2025 Olivier Rogier.
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
/// <edited> 2023-09 </edited>
namespace Ordisoftware.Hebrew.Calendar;

partial class MainForm
{

  private void DoTrayIconMouse_Move(object sender, MouseEventArgs e)
  {
    if ( !Globals.IsReady ) return;
    if ( !MenuTray.Enabled ) return;
    SystemManager.TryCatch(() =>
    {
      if ( !Settings.BalloonEnabled || ( Settings.BalloonOnlyIfMainFormIsHidden && Visible ) )
      {
        // TODO NEXT refactor in UpdateUI and do a clean formatting with gregorian date before hebrew
        var text = Text.IndexOf('(') >= 0
          ? new string([.. Text.ToCharArray().TakeWhile(c => c != '(')])
          : Text;
        var lines = text.Replace(HebrewTranslations.Parashah + " ", "").SplitNoEmptyLines(" - ").ToList();
        if ( lines.Count >= 3 )
        {
          lines.Insert(2, DateTime.Today.ToShortDateString());
          int index = lines.Count - 1;
          int pos = lines[index].IndexOf('(');
          if ( pos != -1 )
            lines[index] = lines[index].Substring(0, pos - 1);
        }
        else
          lines.Add(DateTime.Today.ToShortDateString());
        TrayIcon.Text = new string([.. lines.AsMultiLine().Take(Globals.TrayIconTextLimit)]);
      }
      else
        TrayIcon.Text = string.Empty;
      if ( !Settings.BalloonEnabled || Settings.TrayIconClickOpen == TrayIconClickOpen.NavigationForm )
        return;
      TimerBalloon.Start();
      TrayIconMouse = Cursor.Position;
      if ( !TimerTrayMouseMove.Enabled && Settings.BalloonAutoHide )
        TimerTrayMouseMove.Start();
    });
  }

  private void DoTrayIconMouse_Click(object sender, MouseEventArgs e)
  {
    if ( !Globals.IsReady ) return;
    SystemManager.TryCatchManage(() =>
    {
      TimerBalloon.Stop();
      TimerTrayMouseMove.Stop();
      if ( e is not null )
      {
        if ( e.Button == MouseButtons.Left )
        {
          if ( !MenuTray.Enabled )
          {
            var forms = Application.OpenForms.GetAll();
            var form = forms.FirstOrDefault(f => f is PreferencesForm);
            if ( form?.Visible == true )
              form.ForceBringToFront();
            else
              FormsHelper.GetActiveForm()?.ForceBringToFront();
          }
          else
            switch ( Settings.TrayIconClickOpen )
            {
              case TrayIconClickOpen.MainForm:
                MenuShowHide_Click(TrayIcon, MenuTray.Enabled ? EventArgs.Empty : null);
                break;
              case TrayIconClickOpen.NextCelebrationsForm:
                if ( NextCelebrationsForm.Instance?.Visible == true )
                  NextCelebrationsForm.Instance.Close();
                else
                  ActionViewNextCelebrations.PerformClick();
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
                      GoToDate(MonthlyCalendar.CalendarDate.Date);
                    form.Visible = true;
                  });
                break;
              default:
                throw new AdvNotImplementedException(Settings.TrayIconClickOpen);
            }
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
    if ( Globals.IsExiting ) return;
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
          MonthlyCalendar.Refresh();
        }
        if ( sender is not null )
          if ( !NavigationForm.Instance.Visible )
            if ( Settings.MainFormShownGoToToday )
              GoToDate(DateTime.Today);
            else
              GoToDate(MonthlyCalendar.CalendarDate.Date);
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
    if ( Globals.IsProcessingData )
    {
      DisplayManager.ShowInformation(SysTranslations.CantExitWhileProcessing.GetLang());
      return;
    }
    if ( ( EditConfirmClosing.Checked && !Globals.IsSessionEnding )
      || ( e is null && !SystemManager.CommandLineOptions.IsPreviewEnabled ) )
      if ( !DisplayManager.QueryYesNo(SysTranslations.AskToExitApplication.GetLang()) )
        return;
    Globals.AllowClose = true;
    Close();
  }

}
