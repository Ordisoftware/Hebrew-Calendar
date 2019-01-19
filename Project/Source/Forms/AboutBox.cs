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
/// <created> 2016-04 </created>
/// <edited> 2016-04 </edited>
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using Ordisoftware.Core;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Provide the about box.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  public partial class AboutBox : Form
  {

    /// <summary>
    /// Indicate the singleton instance.
    /// </summary>
    static internal AboutBox Instance { get; private set; }

    /// <summary>
    /// Static constructor.
    /// </summary>
    static AboutBox()
    {
      Instance = new AboutBox();
    }

    /// <summary>
    /// Default constructor.
    /// </summary>
    private AboutBox()
    {
      InitializeComponent();
      Text = Text + " " + AssemblyTitle;
      labelTitle.Text = AssemblyTitle;
      labelDescription.Text = Localizer.ApplicationDescriptionText.GetLang();
      labelVersion.Text = labelVersion.Text + AssemblyVersion;
      labelCopyright.Text = AssemblyCopyright;
      labelTrademark.Text = AssemblyTrademark;
    }

    /// <summary>
    /// Event handler. Called by AboutBox for load events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Event information.</param>
    private void AboutBox_Load(object sender, EventArgs e)
    {
      editLicense.Rtf = Properties.Resources.MPL_2_0;
    }

    /// <summary>
    /// Event handler. Called by labelIconsProvider for link clicked events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Link label link clicked event information.</param>
    private void labelIconsProvider_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      SystemManager.OpenWebLink(((LinkLabel)sender).Text);
    }

    /// <summary>
    /// Event handler. Called by labelTrademarkName for link clicked events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Link label link clicked event information.</param>
    private void labelTrademarkName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      OpenAuthorHome();
    }

    /// <summary>
    /// Open the software home page.
    /// </summary>
    public void OpenApplicationHome()
    {
      SystemManager.OpenWebLink(AssemblyProduct);
    }

    /// <summary>
    /// Open the author home page.
    /// </summary>
    public void OpenAuthorHome()
    {
      SystemManager.OpenWebLink(AssemblyTrademark);
    }

    /// <summary>
    /// Open the author contact page.
    /// </summary>
    public void OpenContactPage()
    {
      SystemManager.OpenWebLink(AssemblyTrademark + "/contact");
    }

    /// <summary>
    /// Event handler. Called by editLicense for link clicked events.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">Link clicked event information.</param>
    private void editLicense_LinkClicked(object sender, LinkClickedEventArgs e)
    {
      Process.Start(e.LinkText);
    }

    #region Accesseurs d'attribut de l'assembly

    /// <summary>
    /// get the assembly title.
    /// </summary>
    public string AssemblyTitle
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
        if ( attributes.Length > 0 )
        {
          AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
          if ( titleAttribute.Title != "" )
          {
            return titleAttribute.Title;
          }
        }
        return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
      }
    }

    /// <summary>
    /// get the assembly version.
    /// </summary>
    public string AssemblyVersion
    {
      get
      {
        var version = Assembly.GetExecutingAssembly().GetName().Version;
        return version.Major + "." + version.Minor;
      }
    }

    /// <summary>
    /// get information describing the assembly.
    /// </summary>
    public string AssemblyDescription
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
        if ( attributes.Length == 0 )
        {
          return "";
        }
        return ((AssemblyDescriptionAttribute)attributes[0]).Description;
      }
    }

    /// <summary>
    /// get the assembly product.
    /// </summary>
    public string AssemblyProduct
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
        if ( attributes.Length == 0 )
        {
          return "";
        }
        return ((AssemblyProductAttribute)attributes[0]).Product;
      }
    }

    /// <summary>
    /// get the assembly copyright.
    /// </summary>
    public string AssemblyCopyright
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
        if ( attributes.Length == 0 )
        {
          return "";
        }
        return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
      }
    }

    /// <summary>
    /// get the assembly company.
    /// </summary>
    public string AssemblyCompany
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
        if ( attributes.Length == 0 )
        {
          return "";
        }
        return ((AssemblyCompanyAttribute)attributes[0]).Company;
      }
    }

    /// <summary>
    /// get the assembly trademark.
    /// </summary>
    public string AssemblyTrademark
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTrademarkAttribute), false);
        if ( attributes.Length == 0 )
        {
          return "";
        }
        return ((AssemblyTrademarkAttribute)attributes[0]).Trademark;
      }
    }
    #endregion

  }

}
