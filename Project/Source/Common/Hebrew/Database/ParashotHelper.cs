/// <license>
/// This file is part of Ordisoftware Hebrew Calendar and Words.
/// Copyright 2012-2023 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2021-02 </created>
/// <edited> 2022-11 </edited>
namespace Ordisoftware.Hebrew;

static public class ParashotHelper
{

  [SuppressMessage("AsyncUsage", "AsyncFixer03:Fire-and-forget async-void methods or delegates", Justification = "N/A (event)")]
  [SuppressMessage("Usage", "VSTHRD101:Avoid unsupported async delegates", Justification = "<En attente>")]
  [SuppressMessage("Style", "GCop408:Flag or switch parameters (bool) should go after all non-optional parameters. If the boolean parameter is not a flag or switch, split the method into two different methods, each doing one thing.", Justification = "Opinion")]
  static public bool ShowDescription(
    this List<Parashah> parashot,
    Parashah parashah,
    bool withLinked,
    Func<Form> runBoard)
  {
    if ( parashah is null ) return false;
    // Prepare
    var form = (MessageBoxEx)Application.OpenForms.GetAll(f => f is MessageBoxEx && f.Tag == parashah).FirstOrDefault();
    if ( form is not null )
    {
      form.Popup();
      return true;
    }
    var linked = withLinked ? parashah.GetLinked(parashot) : null;
    // Message box
    var message = parashah.ToStringReadable();
    if ( linked is not null )
      message += Globals.NL2 + linked.ToStringReadable();
    string title = $"{HebrewTranslations.WeeklyParashah.GetLang()} : {parashah.Name}";
    if ( linked is not null ) title += $" - {linked.Name}";
    form = new MessageBoxEx(title, message, width: MessageBoxEx.DefaultWidthMedium)
    {
      StartPosition = FormStartPosition.CenterScreen,
      ForceNoTopMost = true,
      ShowInTaskbar = true,
      AllowClose = true,
      Tag = parashah
    };
    // Button Open board
    form.ActionYes.Visible = runBoard is not null;
    form.ActionYes.Text = SysTranslations.Board.GetLang();
    form.ActionYes.Click += async (_, _) =>
    {
      Form form = null;
      SystemManager.TryCatchManage(() => form = runBoard.Invoke());
      await Task.Delay(1000).ConfigureAwait(false);
      if ( form is not null ) SystemManager.TryCatchManage(() => form.Popup());
    };
    // Button Open memo
    form.ActionNo.Visible = !parashah.Memo.IsNullOrEmpty() || ( !linked?.Memo.IsNullOrEmpty() ?? false );
    form.ActionNo.Text = SysTranslations.Memo.GetLang();
    form.ActionNo.Click += showParashah;
    // Button Copy to clipboard
    form.ActionRetry.Visible = true;
    form.ActionRetry.Text = SysTranslations.ActionCopy.GetLang();
    form.ActionRetry.DialogResult = DialogResult.None;
    form.ActionRetry.Click -= form.ActionClose_Click;
    form.ActionRetry.Click += (_, _) =>
    {
      Clipboard.SetText(message);
      DisplayManager.ShowSuccessOrSound(SysTranslations.DataCopiedToClipboard.GetLang(),
                                        Globals.ClipboardSoundFilePath);
    };
    // Show
    form.Show();
    return true;
    //
    void showParashah(object sender, EventArgs e)
      => DisplayManager.Show(string.Join(Globals.NL2, parashah.Memo, linked?.Memo ?? string.Empty));
  }

}
