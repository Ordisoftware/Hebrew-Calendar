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
/// <edited> 2023-04 </edited>
namespace Ordisoftware.Hebrew;

using System.Windows.Forms;
using MoreLinq;

static public class ParashotHelper
{

  private const int WidthButtonSmall = 35;

  [SuppressMessage("Usage", "VSTHRD101:Avoid unsupported async delegates", Justification = "<En attente>")]
  [SuppressMessage("Design", "MA0051:Method is too long", Justification = "N/A")]
  static public bool ShowDescription(this List<Parashah> parashot,
                                     Parashah parashah,
                                     bool withLinked,
                                     Func<Form> runBoard)
  {
    if ( parashah is null ) return false;
    // Check if already opened
    var form = (MessageBoxEx)Application.OpenForms
                                        .GetAll(f => f is MessageBoxEx && f.Tag == parashah)
                                        .FirstOrDefault();
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
    message += Globals.NL2 + SysTranslations.NavigationTip.GetLang();
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
    // Button Previous
    form.ActionYes.Visible = true;
    form.ActionYes.Enabled = parashah.ID != ParashotFactory.Instance.All.First().ID;
    form.ActionYes.Width = WidthButtonSmall;
    form.ActionYes.Text = "<";
    form.ActionYes.KeyUp += onKeyUp;
    form.ActionYes.Click += previous;
    // Button Next
    form.ActionNo.Visible = true;
    form.ActionNo.Enabled = ( linked ?? parashah ).ID != ParashotFactory.Instance.All.Last().ID;
    form.ActionNo.Width = WidthButtonSmall;
    form.ActionNo.Text = ">";
    form.ActionNo.KeyUp += onKeyUp;
    form.ActionNo.Click += next;
    // Button Open board
    form.ActionAbort.Visible = runBoard is not null;
    form.ActionAbort.Text = SysTranslations.Board.GetLang();
    form.ActionAbort.KeyUp += onKeyUp;
    form.ActionAbort.Click += openBoard;
    // Button Open memo box
    form.ActionRetry.Visible = !parashah.Memo.IsNullOrEmpty() || ( !linked?.Memo.IsNullOrEmpty() ?? false );
    form.ActionRetry.Text = SysTranslations.Memo.GetLang();
    form.ActionRetry.KeyUp += onKeyUp;
    form.ActionRetry.Click += openMemo;
    // Button Copy to clipboard
    form.ActionIgnore.Visible = true;
    form.ActionIgnore.Text = SysTranslations.ActionCopy.GetLang();
    form.ActionIgnore.DialogResult = DialogResult.None;
    form.ActionIgnore.KeyUp += onKeyUp;
    form.ActionIgnore.Click -= form.ActionClose_Click;
    form.ActionIgnore.Click += copyToClipboard;
    // Show
    form.ActionOK.KeyUp += onKeyUp;
    form.Show();
    return true;
    //
    void previous(object sender, EventArgs e)
    {
      string id = parashah.ID;
      var previous = ParashotFactory.Instance.All.TakeWhile(p => p.ID != id).LastOrDefault();
      if ( previous is null ) return;
      form.Close();
      ParashotForm.Instance?.Select(previous);
      parashot.ShowDescription(previous, false, runBoard);
    }
    //
    void next(object sender, EventArgs e)
    {
      string id = ( linked ?? parashah ).ID;
      var next = ParashotFactory.Instance.All.SkipUntil(p => p.ID == id).FirstOrDefault();
      if ( next is null ) return;
      form.Close();
      ParashotForm.Instance?.Select(next);
      parashot.ShowDescription(next, false, runBoard);
    }
    //
    void openMemo(object sender, EventArgs e)
    {
      DisplayManager.Show(string.Join(Globals.NL2, parashah.Memo, linked?.Memo ?? string.Empty));
    }
    //
    async void openBoard(object sender, EventArgs e)
    {
      Form form = null;
      SystemManager.TryCatchManage(() => form = runBoard.Invoke());
      await Task.Delay(1000).ConfigureAwait(false);
      if ( form is not null ) SystemManager.TryCatchManage(() => form.Popup());
    }
    //
    void copyToClipboard(object sender, EventArgs e)
    {
      Clipboard.SetText(message);
      DisplayManager.ShowSuccessOrSound(SysTranslations.DataCopiedToClipboard.GetLang(),
                                        Globals.ClipboardSoundFilePath);
    }
    //
    void onKeyUp(object senderOnKeyUp, KeyEventArgs eOnKeyUp)
    {
      switch ( eOnKeyUp.KeyCode )
      {
        case Keys.Home:
          if ( !form.ActionYes.Enabled ) return;
          var first = ParashotFactory.Instance.All.FirstOrDefault();
          if ( first is null ) return;
          form.Close();
          ParashotForm.Instance?.Select(first);
          parashot.ShowDescription(first, false, runBoard);
          break;
        case Keys.End:
          if ( !form.ActionNo.Enabled ) return;
          var last = ParashotFactory.Instance.All.LastOrDefault();
          if ( last is null ) return;
          form.Close();
          ParashotForm.Instance?.Select(last);
          parashot.ShowDescription(last, false, runBoard);
          break;
        case Keys.PageUp:
          form.ActionYes.PerformClick();
          break;
        case Keys.PageDown:
          form.ActionNo.PerformClick();
          break;
        default:
          // Nothing to do
          break;
      }
    }
  }

}
