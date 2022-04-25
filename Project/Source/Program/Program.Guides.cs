/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2022 Olivier Rogier.
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
/// <edited> 2022-04 </edited>
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Provides Program class.
/// </summary>
static partial class Program
{

  /// <summary>
  /// Indicates the transcription guide form.
  /// </summary>
  static public HTMLBrowserForm TranscriptionGuideForm
  {
    get
    {
      return _TranscriptionGuideForm ??= new HTMLBrowserForm(HebrewTranslations.TranscriptionGuideTitle,
                                                             HebrewGlobals.TranscriptionGuideFilePath,
                                                             nameof(Settings.TranscriptionGuideFormLocation),
                                                             nameof(Settings.TranscriptionGuideFormSize),
                                                             false);
    }
  }
  static private HTMLBrowserForm _TranscriptionGuideForm;

  /// <summary>
  /// Indicates the grammar guide form.
  /// </summary>
  static public HTMLBrowserForm GrammarGuideForm
  {
    get
    {
      return _GrammarGuideForm ??= new HTMLBrowserForm(HebrewTranslations.GrammarGuideTitle,
                                                       HebrewGlobals.GrammarGuideFilePath,
                                                       nameof(Settings.GrammarGuideFormLocation),
                                                       nameof(Settings.GrammarGuideFormSize),
                                                       true);
    }
  }
  static private HTMLBrowserForm _GrammarGuideForm;

  /// <summary>
  /// Indicates the method notice form.
  /// </summary>
  static public HTMLBrowserForm MethodNoticeForm
  {
    get
    {
      return _MethodGuideForm ??= new HTMLBrowserForm(HebrewTranslations.MethodNoticeTitle,
                                                      HebrewGlobals.LettriqMethodNoticeFilePath,
                                                      nameof(Settings.MethodNoticeFormLocation),
                                                      nameof(Settings.MethodNoticeFormSize),
                                                      false);
    }
  }
  static private HTMLBrowserForm _MethodGuideForm;

}
