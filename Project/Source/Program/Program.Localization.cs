/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2023 Olivier Rogier.
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
namespace Ordisoftware.Hebrew.Calendar;

/// <summary>
/// Provides Program class.
/// </summary>
static partial class Program
{

  /// <summary>
  /// Updates localization strings to the whole application.
  /// </summary>
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP004:Don't ignore created IDisposable", Justification = "<En attente>")]
  static public void UpdateLocalization()
  {
    Globals.ChronoTranslate.Restart();
    Task task = null;
    try
    {
      static void update(Form form)
      {
        new Infralution.Localization.CultureManager().ManagedControl = form;
        var resources = new ComponentResourceManager(form.GetType());
        resources.ApplyResources(form.Controls);
      }
      string lang = "en-US";
      if ( Settings.LanguageSelected == Language.FR ) lang = "fr-FR";
      var culture = new CultureInfo(lang);
      Thread.CurrentThread.CurrentCulture = culture;
      Thread.CurrentThread.CurrentUICulture = culture;
      task = new Task(HebrewGlobals.LoadProviders);
      task.Start();
      if ( Globals.IsReady )
      {
        MessageBoxEx.CloseAll();
        AboutBox.Instance.Hide();
        MainForm.Instance.ClearLists();
      }
      else
        update(MainForm.Instance);
      new Infralution.Localization.CultureManager().ManagedControl = StatisticsForm.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = AboutBox.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = TranscriptionGuideForm;
      new Infralution.Localization.CultureManager().ManagedControl = GrammarGuideForm;
      new Infralution.Localization.CultureManager().ManagedControl = NoticesForm.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = NextCelebrationsForm.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = CelebrationsBoardForm.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = CelebrationVersesBoardForm.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = NewMoonsBoardForm.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = ParashotForm.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = LunarMonthsForm.Instance;
      new Infralution.Localization.CultureManager().ManagedControl = DatesDifferenceForm.Instance;
      Infralution.Localization.CultureManager.ApplicationUICulture = culture;
      var formsToSkip = new Form[] { DebugManager.TraceForm, AboutBox.Instance, GrammarGuideForm };
      foreach ( Form form in Application.OpenForms.GetAll().Except(formsToSkip) )
      {
        update(form);
        if ( form is ShowTextForm formShowText )
          formShowText.Relocalize();
      }
      // Various updates
      if ( Globals.IsReady )
      {
        LoadingForm.Instance.Relocalize();
        TextBoxEx.Relocalize();
        AboutBox.Instance.AboutBox_Shown(null, null);
        TranscriptionGuideForm.HTMLBrowserForm_Shown(null, null);
        GrammarGuideForm.HTMLBrowserForm_Shown(null, null);
        LunarMonthsForm.Instance.Relocalize();
        NavigationForm.Instance.Relocalize();
        ParashotFactory.Instance.Reset();
        DatesDifferenceForm.Instance.Relocalize();
        SystemManager.TryCatchManage(ShowExceptionMode.OnlyMessage,
                                     () => MainForm.Instance.LoadMenuBookmarks(MainForm.Instance));
      }
      MainForm.Instance.MonthlyCalendar._btnToday.ButtonText = AppTranslations.Today.GetLang();
      task?.Wait();
      MainForm.Instance.CreateSystemInformationMenu();
    }
    catch ( Exception ex )
    {
      ex.Manage();
    }
    finally
    {
      Globals.ChronoTranslate.Stop();
      Settings.BenchmarkTranslate = Globals.ChronoTranslate.ElapsedMilliseconds;
    }
  }

}
