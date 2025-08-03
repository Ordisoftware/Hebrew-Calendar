﻿namespace Ordisoftware.Hebrew
{
  partial class LettersControl
  {
    /// <summary> 
    /// Variable nécessaire au concepteur.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Nettoyage des ressources utilisées.
    /// </summary>
    /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
    protected override void Dispose(bool disposing)
    {
      if ( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Code généré par le Concepteur de composants

    /// <summary> 
    /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
    /// le contenu de cette méthode avec l'éditeur de code.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LettersControl));
      this.PanelLetters = new System.Windows.Forms.Panel();
      this.ContextMenuLetter = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ActionLetterAddAtCaret = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionLetterAddAtEnd = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionLetterAddAtStart = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuItemSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.ActionLetterViewDetails = new System.Windows.Forms.ToolStripMenuItem();
      this.PanelSeparator = new System.Windows.Forms.Panel();
      this.ActionDelLast = new System.Windows.Forms.Button();
      this.ActionReset = new System.Windows.Forms.Button();
      this.ActionReverseWord = new System.Windows.Forms.Button();
      this.EditCopyWithFinalLetter = new System.Windows.Forms.CheckBox();
      this.ActionDelFirst = new System.Windows.Forms.Button();
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.PanelGematria = new System.Windows.Forms.Panel();
      this.LabelGematriaSimple = new System.Windows.Forms.Label();
      this.EditGematriaFull = new Ordisoftware.Core.TextBoxEx();
      this.LabelGematriaFull = new System.Windows.Forms.Label();
      this.EditGematriaSimple = new Ordisoftware.Core.TextBoxEx();
      this.LabelClipboardContentType = new System.Windows.Forms.Label();
      this.ActionPaste = new System.Windows.Forms.Button();
      this.ActionCopyToHebrew = new System.Windows.Forms.Button();
      this.ActionCopyToUnicode = new System.Windows.Forms.Button();
      this.PanelSeparatorActionClear = new System.Windows.Forms.Panel();
      this.ActionClear = new System.Windows.Forms.Button();
      this.PanelSeparatorActionSearch = new System.Windows.Forms.Panel();
      this.ActionSearchOnline = new System.Windows.Forms.Button();
      this.ContextMenuSearchOnline = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ToolTipClipboard = new System.Windows.Forms.ToolTip(this.components);
      this.PanelTextBox = new System.Windows.Forms.Panel();
      this.TextBox = new Ordisoftware.Core.TextBoxEx();
      this.LabelGematriaFinal = new System.Windows.Forms.Label();
      this.EditGematriaFinal = new Ordisoftware.Core.TextBoxEx();
      this.ContextMenuLetter.SuspendLayout();
      this.PanelSeparator.SuspendLayout();
      this.PanelBottom.SuspendLayout();
      this.PanelGematria.SuspendLayout();
      this.PanelTextBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // PanelLetters
      // 
      this.PanelLetters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      resources.ApplyResources(this.PanelLetters, "PanelLetters");
      this.PanelLetters.Name = "PanelLetters";
      // 
      // ContextMenuLetter
      // 
      this.ContextMenuLetter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionLetterAddAtCaret,
            this.ActionLetterAddAtEnd,
            this.ActionLetterAddAtStart,
            this.MenuItemSeparator,
            this.ActionLetterViewDetails});
      this.ContextMenuLetter.Name = "ContextMenuLetter";
      resources.ApplyResources(this.ContextMenuLetter, "ContextMenuLetter");
      this.ContextMenuLetter.Opened += new System.EventHandler(this.ContextMenuLetter_Opened);
      // 
      // ActionLetterAddAtCaret
      // 
      resources.ApplyResources(this.ActionLetterAddAtCaret, "ActionLetterAddAtCaret");
      this.ActionLetterAddAtCaret.Name = "ActionLetterAddAtCaret";
      this.ActionLetterAddAtCaret.Click += new System.EventHandler(this.ActionLetterAddAtCaret_Click);
      // 
      // ActionLetterAddAtEnd
      // 
      resources.ApplyResources(this.ActionLetterAddAtEnd, "ActionLetterAddAtEnd");
      this.ActionLetterAddAtEnd.Name = "ActionLetterAddAtEnd";
      this.ActionLetterAddAtEnd.Click += new System.EventHandler(this.ActionLetterAddAtEnd_Click);
      // 
      // ActionLetterAddAtStart
      // 
      resources.ApplyResources(this.ActionLetterAddAtStart, "ActionLetterAddAtStart");
      this.ActionLetterAddAtStart.Name = "ActionLetterAddAtStart";
      this.ActionLetterAddAtStart.Click += new System.EventHandler(this.ActionLetterAddAtBegin_Click);
      // 
      // MenuItemSeparator
      // 
      this.MenuItemSeparator.Name = "MenuItemSeparator";
      resources.ApplyResources(this.MenuItemSeparator, "MenuItemSeparator");
      // 
      // ActionLetterViewDetails
      // 
      resources.ApplyResources(this.ActionLetterViewDetails, "ActionLetterViewDetails");
      this.ActionLetterViewDetails.Name = "ActionLetterViewDetails";
      this.ActionLetterViewDetails.Click += new System.EventHandler(this.ActionLetterViewDetails_Click);
      this.ActionLetterViewDetails.VisibleChanged += new System.EventHandler(this.ActionLetterViewDetails_VisibleChanged);
      // 
      // PanelSeparator
      // 
      this.PanelSeparator.Controls.Add(this.ActionDelLast);
      this.PanelSeparator.Controls.Add(this.ActionReset);
      this.PanelSeparator.Controls.Add(this.ActionReverseWord);
      this.PanelSeparator.Controls.Add(this.EditCopyWithFinalLetter);
      this.PanelSeparator.Controls.Add(this.ActionDelFirst);
      resources.ApplyResources(this.PanelSeparator, "PanelSeparator");
      this.PanelSeparator.Name = "PanelSeparator";
      // 
      // ActionDelLast
      // 
      resources.ApplyResources(this.ActionDelLast, "ActionDelLast");
      this.ActionDelLast.FlatAppearance.BorderSize = 0;
      this.ActionDelLast.Name = "ActionDelLast";
      this.ActionDelLast.UseVisualStyleBackColor = true;
      this.ActionDelLast.Click += new System.EventHandler(this.ActionDelLast_Click);
      // 
      // ActionReset
      // 
      resources.ApplyResources(this.ActionReset, "ActionReset");
      this.ActionReset.FlatAppearance.BorderSize = 0;
      this.ActionReset.Name = "ActionReset";
      this.ActionReset.UseVisualStyleBackColor = true;
      this.ActionReset.Click += new System.EventHandler(this.ActionReset_Click);
      // 
      // ActionReverseWord
      // 
      resources.ApplyResources(this.ActionReverseWord, "ActionReverseWord");
      this.ActionReverseWord.FlatAppearance.BorderSize = 0;
      this.ActionReverseWord.Name = "ActionReverseWord";
      this.ActionReverseWord.UseVisualStyleBackColor = true;
      this.ActionReverseWord.Click += new System.EventHandler(this.ActionRevertWord_Click);
      // 
      // EditCopyWithFinalLetter
      // 
      resources.ApplyResources(this.EditCopyWithFinalLetter, "EditCopyWithFinalLetter");
      this.EditCopyWithFinalLetter.Checked = true;
      this.EditCopyWithFinalLetter.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditCopyWithFinalLetter.Name = "EditCopyWithFinalLetter";
      // 
      // ActionDelFirst
      // 
      resources.ApplyResources(this.ActionDelFirst, "ActionDelFirst");
      this.ActionDelFirst.FlatAppearance.BorderSize = 0;
      this.ActionDelFirst.Name = "ActionDelFirst";
      this.ActionDelFirst.UseVisualStyleBackColor = true;
      this.ActionDelFirst.Click += new System.EventHandler(this.ActionDelFirst_Click);
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.PanelGematria);
      this.PanelBottom.Controls.Add(this.LabelClipboardContentType);
      this.PanelBottom.Controls.Add(this.ActionPaste);
      this.PanelBottom.Controls.Add(this.ActionCopyToHebrew);
      this.PanelBottom.Controls.Add(this.ActionCopyToUnicode);
      this.PanelBottom.Controls.Add(this.PanelSeparatorActionClear);
      this.PanelBottom.Controls.Add(this.ActionClear);
      this.PanelBottom.Controls.Add(this.PanelSeparatorActionSearch);
      this.PanelBottom.Controls.Add(this.ActionSearchOnline);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
      // 
      // PanelGematria
      // 
      this.PanelGematria.Controls.Add(this.LabelGematriaFinal);
      this.PanelGematria.Controls.Add(this.EditGematriaFinal);
      this.PanelGematria.Controls.Add(this.LabelGematriaSimple);
      this.PanelGematria.Controls.Add(this.EditGematriaFull);
      this.PanelGematria.Controls.Add(this.LabelGematriaFull);
      this.PanelGematria.Controls.Add(this.EditGematriaSimple);
      resources.ApplyResources(this.PanelGematria, "PanelGematria");
      this.PanelGematria.Name = "PanelGematria";
      // 
      // LabelGematriaSimple
      // 
      resources.ApplyResources(this.LabelGematriaSimple, "LabelGematriaSimple");
      this.LabelGematriaSimple.Name = "LabelGematriaSimple";
      // 
      // EditGematriaFull
      // 
      resources.ApplyResources(this.EditGematriaFull, "EditGematriaFull");
      this.EditGematriaFull.BackColor = System.Drawing.Color.LavenderBlush;
      this.EditGematriaFull.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.EditGematriaFull.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      this.EditGematriaFull.Name = "EditGematriaFull";
      this.EditGematriaFull.ReadOnly = true;
      this.EditGematriaFull.SpellCheckAllowed = false;
      this.EditGematriaFull.TextChanged += new System.EventHandler(this.EditGematria_TextChanged);
      // 
      // LabelGematriaFull
      // 
      resources.ApplyResources(this.LabelGematriaFull, "LabelGematriaFull");
      this.LabelGematriaFull.Name = "LabelGematriaFull";
      // 
      // EditGematriaSimple
      // 
      resources.ApplyResources(this.EditGematriaSimple, "EditGematriaSimple");
      this.EditGematriaSimple.BackColor = System.Drawing.Color.LavenderBlush;
      this.EditGematriaSimple.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.EditGematriaSimple.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      this.EditGematriaSimple.Name = "EditGematriaSimple";
      this.EditGematriaSimple.ReadOnly = true;
      this.EditGematriaSimple.SpellCheckAllowed = false;
      this.EditGematriaSimple.TextChanged += new System.EventHandler(this.EditGematria_TextChanged);
      // 
      // LabelClipboardContentType
      // 
      resources.ApplyResources(this.LabelClipboardContentType, "LabelClipboardContentType");
      this.LabelClipboardContentType.ForeColor = System.Drawing.SystemColors.GrayText;
      this.LabelClipboardContentType.Name = "LabelClipboardContentType";
      this.LabelClipboardContentType.MouseHover += new System.EventHandler(this.LabelClipboardContentType_MouseHover);
      // 
      // ActionPaste
      // 
      resources.ApplyResources(this.ActionPaste, "ActionPaste");
      this.ActionPaste.FlatAppearance.BorderSize = 0;
      this.ActionPaste.Name = "ActionPaste";
      this.ActionPaste.UseVisualStyleBackColor = true;
      this.ActionPaste.Click += new System.EventHandler(this.ActionPaste_Click);
      // 
      // ActionCopyToHebrew
      // 
      resources.ApplyResources(this.ActionCopyToHebrew, "ActionCopyToHebrew");
      this.ActionCopyToHebrew.FlatAppearance.BorderSize = 0;
      this.ActionCopyToHebrew.Name = "ActionCopyToHebrew";
      this.ActionCopyToHebrew.UseVisualStyleBackColor = true;
      this.ActionCopyToHebrew.Click += new System.EventHandler(this.ActionCopyToHebrew_Click);
      // 
      // ActionCopyToUnicode
      // 
      resources.ApplyResources(this.ActionCopyToUnicode, "ActionCopyToUnicode");
      this.ActionCopyToUnicode.FlatAppearance.BorderSize = 0;
      this.ActionCopyToUnicode.Name = "ActionCopyToUnicode";
      this.ActionCopyToUnicode.UseVisualStyleBackColor = true;
      this.ActionCopyToUnicode.Click += new System.EventHandler(this.ActionCopyToUnicode_Click);
      // 
      // PanelSeparatorActionClear
      // 
      resources.ApplyResources(this.PanelSeparatorActionClear, "PanelSeparatorActionClear");
      this.PanelSeparatorActionClear.Name = "PanelSeparatorActionClear";
      // 
      // ActionClear
      // 
      resources.ApplyResources(this.ActionClear, "ActionClear");
      this.ActionClear.FlatAppearance.BorderSize = 0;
      this.ActionClear.Name = "ActionClear";
      this.ActionClear.UseVisualStyleBackColor = true;
      this.ActionClear.Click += new System.EventHandler(this.ActionClear_Click);
      // 
      // PanelSeparatorActionSearch
      // 
      resources.ApplyResources(this.PanelSeparatorActionSearch, "PanelSeparatorActionSearch");
      this.PanelSeparatorActionSearch.Name = "PanelSeparatorActionSearch";
      // 
      // ActionSearchOnline
      // 
      this.ActionSearchOnline.Cursor = System.Windows.Forms.Cursors.Default;
      resources.ApplyResources(this.ActionSearchOnline, "ActionSearchOnline");
      this.ActionSearchOnline.FlatAppearance.BorderSize = 0;
      this.ActionSearchOnline.Name = "ActionSearchOnline";
      this.ActionSearchOnline.UseVisualStyleBackColor = true;
      this.ActionSearchOnline.Click += new System.EventHandler(this.ActionSearchOnline_Click);
      // 
      // ContextMenuSearchOnline
      // 
      this.ContextMenuSearchOnline.Name = "ContextMenuSearchOnline";
      resources.ApplyResources(this.ContextMenuSearchOnline, "ContextMenuSearchOnline");
      // 
      // PanelTextBox
      // 
      this.PanelTextBox.Controls.Add(this.TextBox);
      resources.ApplyResources(this.PanelTextBox, "PanelTextBox");
      this.PanelTextBox.Name = "PanelTextBox";
      // 
      // TextBox
      // 
      this.TextBox.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Beginning;
      resources.ApplyResources(this.TextBox, "TextBox");
      this.TextBox.Name = "TextBox";
      this.TextBox.SpellCheckAllowed = false;
      this.TextBox.InsertingText += new Ordisoftware.Core.InsertingTextEventHandler(this.Input_TextChanging);
      this.TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Input_KeyPress);
      this.TextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Input_KeyUp);
      // 
      // LabelGematriaFinal
      // 
      resources.ApplyResources(this.LabelGematriaFinal, "LabelGematriaFinal");
      this.LabelGematriaFinal.Name = "LabelGematriaFinal";
      // 
      // EditGematriaFinal
      // 
      resources.ApplyResources(this.EditGematriaFinal, "EditGematriaFinal");
      this.EditGematriaFinal.BackColor = System.Drawing.Color.LavenderBlush;
      this.EditGematriaFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.EditGematriaFinal.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      this.EditGematriaFinal.Name = "EditGematriaFinal";
      this.EditGematriaFinal.ReadOnly = true;
      this.EditGematriaFinal.SpellCheckAllowed = false;
      // 
      // LettersControl
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Transparent;
      this.Controls.Add(this.PanelLetters);
      this.Controls.Add(this.PanelSeparator);
      this.Controls.Add(this.PanelTextBox);
      this.Controls.Add(this.PanelBottom);
      this.Name = "LettersControl";
      this.Load += new System.EventHandler(this.LettersControl_Load);
      this.SizeChanged += new System.EventHandler(this.LettersControl_SizeChanged);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.LettersControl_Paint);
      this.ContextMenuLetter.ResumeLayout(false);
      this.PanelSeparator.ResumeLayout(false);
      this.PanelSeparator.PerformLayout();
      this.PanelBottom.ResumeLayout(false);
      this.PanelGematria.ResumeLayout(false);
      this.PanelGematria.PerformLayout();
      this.PanelTextBox.ResumeLayout(false);
      this.PanelTextBox.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Panel PanelLetters;
    public Ordisoftware.Core.TextBoxEx TextBox;
    private System.Windows.Forms.ToolStripMenuItem ActionLetterAddAtStart;
    private System.Windows.Forms.ToolStripMenuItem ActionLetterAddAtEnd;
    private System.Windows.Forms.ToolStripMenuItem ActionLetterAddAtCaret;
    private System.Windows.Forms.ToolStripSeparator MenuItemSeparator;
    private System.Windows.Forms.ToolStripMenuItem ActionLetterViewDetails;
    private ContextMenuStrip ContextMenuLetter;
    private Panel PanelSeparator;
    public CheckBox EditCopyWithFinalLetter;
    public Button ActionDelFirst;
    public Button ActionDelLast;
    public Button ActionReset;
    private Panel PanelBottom;
    internal Label LabelClipboardContentType;
    private ToolTip ToolTipClipboard;
    internal ContextMenuStrip ContextMenuSearchOnline;
    internal Label LabelGematriaSimple;
    internal Label LabelGematriaFull;
    private Panel PanelTextBox;
    public Panel PanelSeparatorActionClear;
    public Panel PanelSeparatorActionSearch;
    public Button ActionPaste;
    public Button ActionCopyToHebrew;
    public Button ActionCopyToUnicode;
    public Button ActionSearchOnline;
    public TextBoxEx EditGematriaFull;
    public TextBoxEx EditGematriaSimple;
    public Button ActionClear;
    private Panel PanelGematria;
    public Button ActionReverseWord;
    internal Label LabelGematriaFinal;
    public TextBoxEx EditGematriaFinal;
  }
}
