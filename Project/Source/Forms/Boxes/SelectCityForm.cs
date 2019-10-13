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
/// <created> 2019-10 </created>
/// <edited> 2019-10 </edited>
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Ordisoftware.Core;
using GenericParsing;

namespace Ordisoftware.HebrewCalendar
{

  public partial class SelectCityForm : Form
  {

    public class CityItem
    {
      public string Name;
      public string Latitude;
      public string Longitude;
      public override string ToString()
      {
        return Name;
      }
    }

    static public readonly Dictionary<string, List<CityItem>> GPS = new Dictionary<string, List<CityItem>>();

    static SelectCityForm()
    {
      try
      {
        string filename = Program.AppDocumentsFolderPath + "WorldCities.csv";
        var parser = new GenericParser(filename);
        parser.FirstRowHasHeader = true;
        while ( parser.Read() )
        {
          var city = new CityItem();
          city.Name = parser["city"].RemoveDiacritics();
          city.Latitude = parser["lat"];
          city.Longitude = parser["lng"];
          string country = parser["country"].RemoveDiacritics(); ;
          if ( !GPS.ContainsKey(country) )
            GPS.Add(country, new List<CityItem>());
          GPS[country].Add(city);
        }
      }
      catch ( Exception ex )
      {
        ex.Manage();
      }
    }

    internal string Latitude;
    internal string Longitude;
    internal string Country;
    internal string City;

    public SelectCityForm()
    {
      InitializeComponent();
      Icon = MainForm.Instance.Icon;
    }

    private void SelectCityForm_Load(object sender, EventArgs e)
    {
      ListBoxCountries.DataSource = GPS.Keys.OrderBy(c => c).ToList();
      ActiveControl = EditFilter;
    }

    private void ButtonOk_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
    }

    private void ListBoxCountries_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( ListBoxCountries.SelectedIndex == -1 ) return;
      ListBoxCities.DataSource = GPS[(string)ListBoxCountries.SelectedItem].OrderBy(c => c.Name).ToList();
    }

    private void ListBoxCities_SelectedIndexChanged(object sender, EventArgs e)
    {
      if ( ListBoxCities.SelectedIndex == -1 ) return;
      Latitude = ( (CityItem)ListBoxCities.SelectedItem ).Latitude;
      Longitude = ( (CityItem)ListBoxCities.SelectedItem ).Longitude;
      Country = (string)ListBoxCountries.SelectedItem;
      City = ( (CityItem)ListBoxCities.SelectedItem ).Name;
    }

    private bool Mutex;

    private void EditFilter_TextChanged(object sender, EventArgs e)
    {
      if ( Mutex ) return;
      Mutex = true;
      bool found;
      try
      {
        var list = EditFilter.Text.Split(',');
        if ( list.Length == 0 ) return;
        list[0] = list[0].Trim().ToLower().RemoveDiacritics();
        if ( list[0].Length < 3 ) return;
        var resultCountry = from country in GPS
                            where country.Key.ToLower().Contains(list[0])
                            orderby country.Key
                            select country;
        if ( resultCountry.Count() == 0 ) return;
        string strCountry = resultCountry.ElementAt(0).Key;
        found = resultCountry.Count() == 1;
        if ( !found )
          if ( resultCountry.SingleOrDefault(c => c.Key.ToLower() == list[0]).Key != null )
            found = true;
        if ( found && !EditFilter.Text.Contains(",") )
          tempo(EditFilter.Text = strCountry + ", ");
        int index = ListBoxCountries.FindString(strCountry);
        if ( ListBoxCountries.SelectedIndex != index )
          ListBoxCountries.SelectedIndex = index;
        if ( list.Length == 1 ) return;
        list[1] = list[1].Trim().ToLower().RemoveDiacritics();
        if ( list[1].Length < 3 ) return;
        var resultCity = from country in GPS
                         from city in country.Value
                         where country.Key == strCountry
                            && city.Name.ToLower().Contains(list[1])
                         orderby city.Name
                         select city;
        if ( resultCity.Count() == 0 ) return;
        string strCity = resultCity.ElementAt(0).Name;
        found = resultCity.Count() == 1;
        if ( !found )
          if ( resultCountry.SingleOrDefault(c => c.Key.ToLower() == list[1]).Key != null )
            found = true;
        if ( found )
          tempo(EditFilter.Text = strCountry + ", " + strCity);
        ListBoxCities.SelectedIndex = ListBoxCities.FindString(strCity);
      }
      finally
      {
        Mutex = false;
      }
      void tempo(string str)
      {
        EditFilter.Text = str;
        EditFilter.Enabled = false;
        Application.DoEvents();
        System.Threading.Thread.Sleep(500);
        Application.DoEvents();
        EditFilter.Enabled = true;
        ActiveControl = EditFilter;
        EditFilter.SelectionStart = EditFilter.Text.Length;
      }
    }
  }

}
