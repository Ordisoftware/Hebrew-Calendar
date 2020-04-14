/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2020 Olivier Rogier.
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
/// <edited> 2020-04 </edited>
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Ordisoftware.HebrewCommon;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Provide Program class.
  /// </summary>
  static partial class Program
  {

    /// <summary>
    /// Application mutex to allow only one process instance.
    /// </summary>
    static private Mutex Mutex;

    /// <summary>
    /// Check if the process is already running.
    /// </summary>
    static private bool CheckApplicationOnlyOneInstance()
    {
      var assembly = typeof(Program).Assembly;
      var attribute = (GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
      string id = attribute.Value;
      bool created;
      Mutex = new Mutex(true, id, out created);
      return created;
    }

    /// <summary>
    /// Check is application's settings must be upgraded and apply it if necessary.
    /// </summary>
    static private void CheckSettingsUpgrade()
    {
      if ( Settings.UpgradeRequired )
      {
        Settings.Upgrade();
        Settings.UpgradeRequired = false;
        Settings.Save();
      }
      if ( Settings.UpgradeResetRequiredV3_6 )
      {
        Settings.Reset();
        Settings.UpgradeResetRequiredV3_6 = false;
        Settings.Language = Localizer.Language;
        Settings.Save();
      }
    }

    /// <summary>
    /// Check command line arguments and apply them.
    /// </summary>
    static private void CheckCommandLineArguments(string[] args)
    {
      try
      {
        if ( args.Length == 2 && args[0] == "/lang" )
          if ( args[1] == "en" || args[1] == "fr" )
            Settings.Language = args[1];
        if ( Settings.Language == "" )
          Settings.Language = Localizer.Language;
        Settings.Save();
      }
      catch
      {
      }
    }

    /// <summary>
    /// Update localization strings to the whole application.
    /// </summary>
    static internal void UpdateLocalization()
    {
      string lang = "en-US";
      if ( Settings.Language == "fr" ) lang = "fr-FR";
      var culture = new CultureInfo(lang);
      Thread.CurrentThread.CurrentCulture = culture;
      Thread.CurrentThread.CurrentUICulture = culture;
      AboutBox.Instance.Hide();
      string str = MainForm.Instance.CalendarText.Text;
      foreach ( var f in MainForm.Instance.RemindCelebrationForms.ToList() )
        f.Close();
      foreach ( Form form in Application.OpenForms )
      {
        if ( form != AboutBox.Instance )
        {
          new Infralution.Localization.CultureManager().ManagedControl = form;
          ComponentResourceManager resources = new ComponentResourceManager(form.GetType());
          ApplyResources(resources, form.Controls);
        }
        if ( form is ShowTextForm )
          ( (ShowTextForm)form ).RelocalizeText();
      }
      new Infralution.Localization.CultureManager().ManagedControl = AboutBox.Instance;
      Infralution.Localization.CultureManager.ApplicationUICulture = culture;
      AboutBox.Instance.AboutBox_Shown(null, null);
      MainForm.Instance.CalendarText.Text = str;
    }

    /// <summary>
    /// Called by UpdateLocalization().
    /// </summary>
    static private void ApplyResources(ComponentResourceManager resources, Control.ControlCollection controls)
    {
      foreach ( Control control in controls )
      {
        if ( control is Label )
          resources.ApplyResources(control, control.Name);
        ApplyResources(resources, control.Controls);
      }
    }

    /// <summary>
    /// Set forms icon.
    /// </summary>
    static private void SetFormsIcon()
    {
      MainForm.Instance.Icon = Icon.ExtractAssociatedIcon(IconFilename);
      AboutBox.Instance.Icon = MainForm.Instance.Icon;
      NavigationForm.Instance.Icon = MainForm.Instance.Icon;
      CelebrationsForm.Instance.Icon = MainForm.Instance.Icon;
    }

    /// <summary>
    /// Create winforms submenu items for web links from definitions files.
    /// </summary>
    static public void CreateWebLinks(ToolStripDropDownButton menuRoot, Image imageFolder, Image imageLink)
    {
      foreach ( var items in OnlineLinksProviders )
        if ( items.Items.Count > 0 )
        {
          string title = items.Title.GetLang();
          ToolStripDropDownItem menu;
          if ( title != "" )
          {
            menu = new ToolStripMenuItem(title);
            menu.ImageScaling = ToolStripItemImageScaling.None;
            menu.Image = imageFolder;
            menuRoot.DropDownItems.Add(menu);
          }
          else
            menu = menuRoot;
          foreach ( var item in items.Items )
          {
            var menuitem = menu.DropDownItems.Add(item.Name);
            menuitem.ImageScaling = ToolStripItemImageScaling.None;
            menuitem.Image = imageLink;
            menuitem.Tag = item.URL;
            menuitem.Click += (sender, e) =>
            {
              string url = (string)( (ToolStripItem)sender ).Tag;
              SystemManager.OpenWebLink(url);
            };
          }
        }
    }

  }

}
