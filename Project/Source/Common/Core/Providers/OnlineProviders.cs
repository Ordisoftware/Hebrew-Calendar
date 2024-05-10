/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2024 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-03 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Provides online providers list.
/// </summary>
public class OnlineProviders : DataFile
{

  static public bool MoveCurrentLanguageAtTop { get; set; } = true;

  /// <summary>
  /// Indicates display name tag.
  /// </summary>
  private const string TagName = "Name = ";

  /// <summary>
  /// Indicates url tag.
  /// </summary>
  private const string TagURL = "URL = ";

  /// <summary>
  /// Indicates items.
  /// </summary>
  public List<OnlineProviderItem> Items { get; private set; } = [];

  /// <summary>
  /// Indicates the multilingual title of the list to create a folder
  /// </summary>
  public TranslationsDictionary Title { get; } = [];

  /// <summary>
  /// Indicates if a separator must be inserted before the folder
  /// </summary>
  public bool SeparatorBeforeFolder { get; private set; }

  /// <summary>
  /// Constructor.
  /// </summary>
  public OnlineProviders(string filePath, bool showFileNotFound, bool configurable, DataFileFolder folder)
  : base(filePath, showFileNotFound, configurable, folder)
  {
  }

  /// <summary>
  /// Loads or reload data from disk.
  /// </summary>
  [SuppressMessage("Major Code Smell", "S127:\"for\" loop stop conditions should be invariant", Justification = "N/A")]
  protected override void DoReLoad(string filePath)
  {
    if ( filePath.IsNullOrEmpty() ) return;
    try
    {
      Title.Clear();
      Items.Clear();
      var lines = File.ReadAllLines(filePath);
      for ( int index = 0; index < lines.Length; index++ )
      {
        void showError()
        {
          string message = SysTranslations.ErrorInFile.GetLang(filePath, index + 1, lines[index]);
          DisplayManager.ShowError(message);
        }
        string line = lines[index].Trim();
        if ( line.Length == 0 ) continue;
        if ( line.IsCommented() ) continue;
        if ( line.StartsWith("FOLDER-SEPARATOR", StringComparison.OrdinalIgnoreCase) )
          SeparatorBeforeFolder = true;
        else
        if ( line.StartsWith("-", StringComparison.Ordinal) )
          Items.Add(new OnlineProviderItem("-"));
        else
        if ( line.StartsWith("Lang/", StringComparison.OrdinalIgnoreCase) )
        {
          var parts = line.Split('/', '=');
          if ( parts.Length == 3 )
            Title.Add(Languages.Values[parts[1].Trim().ToLower()], parts[2].Trim());
          else
            showError();
        }
        else
        if ( line.StartsWith(TagName, StringComparison.OrdinalIgnoreCase) )
        {
          string name = line.Substring(TagName.Length);
          if ( ++index >= lines.Length )
          {
            showError();
            break;
          }
          line = lines[index].Trim();
          if ( line.StartsWith(TagURL, StringComparison.OrdinalIgnoreCase) )
            Items.Add(new OnlineProviderItem(name, line.Substring(TagURL.Length)));
          else
            showError();
        }
        else
          showError();
      }
      SortByLanguage();
    }
    catch ( FileNotFoundException )
    {
      string msg = SysTranslations.FileNotFound.GetLang(filePath);
      DisplayManager.ShowError(msg);
    }
    catch ( Exception ex )
    {
      string msg = SysTranslations.LoadFileError.GetLang(filePath, ex.Message);
      DisplayManager.ShowError(msg);
    }
  }

  /// <summary>
  /// Sorts the by language.
  /// </summary>
  [SuppressMessage("Performance", "U2U1203:Use foreach efficiently", Justification = "The collection is modified")]
  private void SortByLanguage()
  {
    if ( !MoveCurrentLanguageAtTop ) return;
    string lang = Languages.Current.ToString();
    var slices = Items.Split(item => item.Name == "-");
    foreach ( var slice in slices )
    {
      int index = 0;
      foreach ( var item in slice.Where(item => item.Language.RawContains(lang)).ToList() )
      {
        slice.Remove(item);
        slice.Insert(index++, item);
      }
    }
    Items = slices.SelectMany(item => item).ToList();
  }

}
