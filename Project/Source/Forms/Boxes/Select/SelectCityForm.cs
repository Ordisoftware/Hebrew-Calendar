﻿/// <license>
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
/// <created> 2019-10 </created>
/// <edited> 2021-04 </edited>
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ordisoftware.Core;
using FileHelpers;

namespace Ordisoftware.Hebrew.Calendar
{

  partial class SelectCityForm : Form
  {

    static private readonly Properties.Settings Settings = Program.Settings;

    static public readonly SortedAutoDictionary<string, AutoResizedList<CityItem>> GPS
      = new SortedAutoDictionary<string, AutoResizedList<CityItem>>();

    static SelectCityForm()
    {
      try
      {
        string filePath = Program.GPSFilePath;
        var parser = new FileHelperAsyncEngine<WorldCities>(Encoding.UTF8);
        using ( parser.BeginReadFile(filePath) )
          foreach ( var item in parser )
          {
            var country = GPS[item.country.RemoveDiacritics()];
            var city = new CityItem();
            city.Name = item.city_ascii;
            city.Latitude = item.lat;
            city.Longitude = item.lng;
            country.Add(city);
          }
        if ( GPS.Keys.Count == 0 )
        {
          string msg = $"{nameof(SelectCityForm)}.{nameof(GPS)} = {SysTranslations.UndefinedSlot.GetLang()}";
#pragma warning disable S3877 // Exceptions should not be thrown from unexpected methods
          throw new NullReferenceException(msg);
#pragma warning restore S3877 // Exceptions should not be thrown from unexpected methods
        }
      }
      catch ( Exception ex )
      {
        Enable = false;
        ex.Manage();
        if ( !Globals.IsReady )
          DisplayManager.ShowAndTerminate(AppTranslations.LoadingCitiesError.GetLang());
      }
    }

    /// <summary>
    /// Indicate if the cities are loaded and ready, else there is an error.
    /// </summary>
    public static bool Enable { get; set; } = true;

    public string Country { get; private set; }
    public string City { get; private set; }
    public string Latitude { get; private set; }
    public string Longitude { get; private set; }

    private const int DefaultDelay = 750;
    private bool Mutex;
    private bool IsLoading;
    private bool IsReady;

    static public bool Run(bool canCancel)
    {
      using ( var form = new SelectCityForm() )
      {
        form.ActionCancel.Enabled = canCancel;
        if ( form.ShowDialog() != DialogResult.OK ) return false;
        if ( form.EditTimeZone.SelectedItem != null )
          Settings.TimeZone = ( (TimeZoneInfo)form.EditTimeZone.SelectedItem ).Id;
        Settings.GPSLatitude = form.Latitude;
        Settings.GPSLongitude = form.Longitude;
        Settings.GPSCountry = form.Country;
        Settings.GPSCity = form.City;
        SystemManager.TryCatch(Settings.Save);
        return true;
      }
    }

    private SelectCityForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
    }

    private void SelectCityForm_Load(object sender, EventArgs e)
    {
      IsLoading = true;
      try
      {
        ListBoxCountries.DataSource = GPS.Keys.ToList();
      }
      finally
      {
        IsLoading = false;
        ActiveControl = EditFilter;
        if ( !Settings.GPSCountry.IsNullOrEmpty() )
        {
          EditFilter.Text = Settings.GPSCountry;
          if ( !Settings.GPSCity.IsNullOrEmpty() )
            EditFilter.Text += Settings.GPSCity;
        }
        else
          EditFilter_TextChanged(null, null);
        foreach ( var item in TimeZoneInfo.GetSystemTimeZones() )
        {
          int index = EditTimeZone.Items.Add(item);
          if ( Settings.TimeZone == item.Id )
            EditTimeZone.SelectedIndex = index;
        }
        IsReady = true;
      }
    }

    private void SelectCityForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if ( DialogResult == DialogResult.OK ) return;
      if ( !ActionCancel.Enabled ) e.Cancel = true;
    }

    private void ActionOK_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
    }

    private void ListBoxCountries_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( IsLoading ) return;
      if ( ListBoxCountries.SelectedIndex == -1 ) return;
      ListBoxCities.DataSource = GPS[(string)ListBoxCountries.SelectedItem].OrderBy(c => c.Name).ToList();
      ListBoxCities.SelectedIndex = -1;
      if ( Mutex ) return;
      EditFilter.Text = ListBoxCountries.SelectedItem.ToString() + ", ";
      EditFilter.Focus();
      EditFilter.SelectionStart = EditFilter.Text.Length;
    }

    private void ListBoxCities_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( IsLoading ) return;
      if ( ListBoxCities.SelectedIndex == -1 ) return;
      Country = (string)ListBoxCountries.SelectedItem;
      City = ( (CityItem)ListBoxCities.SelectedItem ).Name;
      Latitude = ( (CityItem)ListBoxCities.SelectedItem ).Latitude;
      Longitude = ( (CityItem)ListBoxCities.SelectedItem ).Longitude;
      ActionOK.Enabled = EditTimeZone.SelectedItem != null;
      if ( Mutex ) return;
      EditFilter.Text = ListBoxCountries.SelectedItem.ToString() + ", " + ListBoxCities.SelectedItem.ToString();
      EditFilter.Focus();
      EditFilter.SelectionStart = EditFilter.Text.Length;
    }

    private bool FoundCountry = false;
    private bool FoundCity = false;

    private void EditFilter_TextChanged(object sender, EventArgs e)
    {
      if ( Mutex ) return;
      Mutex = true;
      FoundCountry = false;
      FoundCity = false;
      ListBoxCountries.SelectedIndex = -1;
      ListBoxCities.SelectedIndex = -1;
      try
      {
        var list = EditFilter.Text.Split(',');
        if ( list.Length == 0 ) return;
        // Country
        list[0] = list[0].Trim().RemoveDiacritics().ToLower();
        if ( list[0].Length < 3 ) return;
        var resultCountry = from country in GPS
                            where country.Key.ToLower().StartsWith(list[0])
                            orderby country.Key
                            select country;
        if ( !resultCountry.Any() ) return;
        string strCountry = resultCountry.ElementAt(0).Key;
        FoundCountry = resultCountry.Count() == 1;
        if ( !FoundCountry )
          if ( resultCountry.SingleOrDefault(c => c.Key.ToLower() == list[0]).Key != null )
            FoundCountry = true;
        if ( FoundCountry && !EditFilter.Text.Contains(",") )
        {
          EditFilter.Text = strCountry + ", ";
          tempo(EditFilter.Text);
        }

        int index = ListBoxCountries.FindString(strCountry);
        if ( ListBoxCountries.SelectedIndex != index )
          ListBoxCountries.SelectedIndex = index;
        if ( list.Length == 1 ) return;
        // City
        list[1] = list[1].Trim().RemoveDiacritics().ToLower();
        if ( list[1].Length < 3 ) return;
        var resultCity = from country in GPS
                         from city in country.Value
                         where country.Key == strCountry
                            && city.Name.ToLower().StartsWith(list[1])
                         orderby city.Name
                         select city;
        if ( !resultCity.Any() ) return;
        string strCity = resultCity.ElementAt(0).Name;
        FoundCity = resultCity.Count() == 1;
        if ( !FoundCity )
          if ( resultCountry.SingleOrDefault(c => c.Key.ToLower() == list[1]).Key != null )
            FoundCity = true;
        if ( FoundCity )
        {
          EditFilter.Text = strCountry + ", " + strCity;
          tempo(EditFilter.Text);
        }
        index = ListBoxCities.FindString(strCity);
        if ( ListBoxCities.SelectedIndex != index )
          ListBoxCities.SelectedIndex = index;
        if ( FoundCountry && FoundCity )
          for ( index = 0; index < EditTimeZone.Items.Count; index++ )
            if ( EditTimeZone.Items[index].ToString().Contains(strCountry)
              || EditTimeZone.Items[index].ToString().Contains(strCity) )
              EditTimeZone.SelectedIndex = index;
      }
      finally
      {
        ActionOK.Enabled = FoundCountry && FoundCity && EditTimeZone.SelectedItem != null;
        if ( !IsLoading )
          if ( !FoundCountry || !FoundCity )
            EditTimeZone.SelectedItem = null;
        Mutex = false;
      }
      void tempo(string str)
      {
        if ( !IsLoading )
        {
          EditTimeZone.Enabled = false;
          ListBoxCountries.Enabled = false;
          ListBoxCities.Enabled = false;
          EditFilter.Text = str;
          EditFilter.Enabled = false;
          Application.DoEvents();
          if ( IsReady ) System.Threading.Thread.Sleep(DefaultDelay);
          Application.DoEvents();
          EditTimeZone.Enabled = true;
          EditFilter.Enabled = true;
          ListBoxCountries.Enabled = true;
          ListBoxCities.Enabled = true;
        }
        ActiveControl = EditFilter;
        EditFilter.SelectionStart = EditFilter.Text.Length;
      }
    }

    private void EditTimeZone_SelectedIndexChanged(object sender, EventArgs e)
    {
      ActionOK.Enabled = FoundCountry && FoundCity && EditTimeZone.SelectedItem != null;
    }

  }

}
