/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words/Pi.
/// Copyright 2012-2025 Olivier Rogier.
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
/// <edited> 2022-11 </edited>
namespace Ordisoftware.Hebrew;

/// <summary>
/// Provides Hebrew tools.
/// </summary>
[SuppressMessage("Roslynator", "RCS1021:Convert lambda expression body to expression body.", Justification = "Opinion")]
static public class HebrewTools
{

  /// <summary>
  /// Remove diacritics and numbers Alef or Bet.
  /// </summary>
  [SuppressMessage("Usage", "MA0074:Avoid implicit culture-sensitive methods", Justification = "N/A")]
  static public (string Word, bool IsUnicode) RemoveNumberingAndDiacritics(string word)
  {
    word = word.RemoveDiacritics();
    bool isUnicode = HebrewAlphabet.ContainsUnicode(word);
    if ( isUnicode && ( word.EndsWith(" א") || word.EndsWith(" ב") ) )
      word = word.Remove(word.Length - 2);
    else
    if ( word.StartsWith("a ") || word.StartsWith("b ") )
      word = word.Remove(0, 2);
    return (word, isUnicode);
  }

  static private void ProcessHebrewSoftware(string appcode, Func<string> getExePath, Action<string> process)
  {
    string path = getExePath?.Invoke() ?? throw new SystemException($"Delegate not assigned: {nameof(getExePath)}");
    if ( File.Exists(path) )
      SystemManager.TryCatchManage(ShowExceptionMode.Message, () => process(path));
    else
    if ( DisplayManager.QueryYesNo(HebrewTranslations.AskToDownloadHebrewWords.GetLang()) )
      SystemManager.RunShell($"{Globals.AuthorProjectsURL}/{appcode}");
  }

  /// <summary>
  /// Starts Hebrew Words.
  /// </summary>
  static public void OpenHebrewWordsGoToVerse(string reference)
  {
    ProcessHebrewSoftware(HebrewGlobals.AppCodeHebrewWords, HebrewGlobals.GetHebrewWordsExecutablePath, path =>
    {
      SystemManager.RunShell(path, "--verse " + reference);
    });
  }

  /// <summary>
  /// Starts Hebrew Words.
  /// </summary>
  static public void OpenHebrewWordsSearchWord(string word)
  {
    ProcessHebrewSoftware(HebrewGlobals.AppCodeHebrewWords, HebrewGlobals.GetHebrewWordsExecutablePath, path =>
    {
      SystemManager.RunShell(path, "--word " + word);
    });
  }

  /// <summary>
  /// Starts Hebrew Words.
  /// </summary>
  static public void OpenHebrewWordsSearchTranslated(string word)
  {
    ProcessHebrewSoftware(HebrewGlobals.AppCodeHebrewWords, HebrewGlobals.GetHebrewWordsExecutablePath, path =>
    {
      SystemManager.RunShell(path, "--translated " + word);
    });
  }

  /// <summary>
  /// Starts Hebrew Letters.
  /// </summary>
  /// <param name="word">The Unicode or Hebrew font chars of the word.</param>
  [SuppressMessage("Style", "IDE0042:Déconstruire la déclaration de variable", Justification = "Opinion")]
  static public void OpenHebrewLetters(string word)
  {
    ProcessHebrewSoftware(HebrewGlobals.AppCodeHebrewLetters, HebrewGlobals.GetHebrewLettersExecutablePath, path =>
    {
      if ( word.IsNullOrEmpty() )
        SystemManager.RunShell(path);
      else
      {
        var wordAnalyzed = RemoveNumberingAndDiacritics(word);
        var items = wordAnalyzed.Word.Split(' ');
        if ( wordAnalyzed.IsUnicode )
          items = items.Reverse().ToArray();
        foreach ( string item in items )
        {
          SystemManager.RunShell(path, item);
          Thread.Sleep(250);
        }
      }
    });
  }

  /// <summary>
  /// Opens online word provider.
  /// </summary>
  /// <param name="link">Web provider link.</param>
  /// <param name="word">The Unicode or Hebrew font chars of the word.</param>
  [SuppressMessage("Style", "IDE0042:Déconstruire la déclaration de variable", Justification = "Opinion")]
  static public void OpenWordProvider(string link, string word)
  {
    if ( word.Length > 1 ) word = HebrewAlphabet.SetFinal(word, true);
    SystemManager.TryCatchManage(ShowExceptionMode.Message, () =>
    {
      var wordAnalyzed = RemoveNumberingAndDiacritics(word);
      var items = wordAnalyzed.Word.Split(' ');
      if ( !wordAnalyzed.IsUnicode )
        items = items.Select(w => HebrewAlphabet.ToUnicodeChars(HebrewAlphabet.SetFinal(w, true))).ToArray();
      foreach ( string item in items )
        if ( item.Length > 0 )
        {
          string url = link.Replace("%CUSTOM%", HebrewGlobals.GetCustomWebSearchPattern?.Invoke() ?? string.Empty)
                           .Replace("%FIRSTLETTER%", item[0].ToString())
                           .Replace("%WORD%", item);
          SystemManager.RunShell(url);
          Thread.Sleep(250);
        }
    });
  }

  /// <summary>
  /// Opens online concordance provider.
  /// </summary>
  static public void OpenWordConcordance(string link, int concordance)
  {
    if ( concordance < 1 ) return;
    SystemManager.TryCatchManage(ShowExceptionMode.Message, () =>
    {
      link = link.Replace("%CONCORDANCE%", concordance.ToString());
      SystemManager.RunShell(link);
    });
  }

  /// <summary>
  /// Opens online bible provider.
  /// </summary>
  static public void OpenBibleProvider(string url, string reference)
  {
    SystemManager.TryCatchManage(ShowExceptionMode.Message, () =>
    {
      int[] list = reference.Split('.').Select(int.Parse).ToArray();
      OpenBibleProvider(url, list[0], list[1], list[2]);
    });
  }

  /// <summary>
  /// Opens online bible provider.
  /// </summary>
  [SuppressMessage("Performance", "U2U1103:Index strings correctly", Justification = "For code readability")]
  [SuppressMessage("Style", "GCop414:Remove .ToString() as it's unnecessary.", Justification = "Opinion")]
  static public void OpenBibleProvider(string pattern, int book, int chapter, int verse)
  {
    SystemManager.TryCatchManage(ShowExceptionMode.Message, () =>
    {
      SystemManager.RunShell(OnlineBookInfos.GetUrl(pattern, book, chapter, verse));
    });
  }

  /// <summary>
  /// Opens online parashah provider.
  /// </summary>
  static public void OpenParashahProvider(string pattern, Parashah parashah, bool openLinked = false)
  {
    if ( parashah is null )
    {
      DisplayManager.Show(HebrewTranslations.ParashahNotFound.GetLang());
      return;
    }
    open(parashah);
    if ( openLinked && pattern.IndexOf('%') >= 0 )
    {
      var linked = parashah.GetLinked();
      if ( linked is not null ) open(linked);
    }
    //
    void open(Parashah item)
    {
      SystemManager.TryCatchManage(ShowExceptionMode.Message, () =>
      {
        SystemManager.OpenWebLink(OnlineParashot.GetUrl(pattern, item));
      });
    }
  }

  /// <summary>
  /// Opens online celebration provider.
  /// </summary>
  static public void OpenCelebrationProvider(string pattern, TorahCelebration celebration)
  {
    SystemManager.TryCatchManage(ShowExceptionMode.Message, () =>
    {
      SystemManager.OpenWebLink(OnlineCelebration.GetUrl(pattern, celebration));
    });
  }

}
