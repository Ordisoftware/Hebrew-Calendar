namespace Ordisoftware.Hebrew.Calendar
{
  partial class SelectSoundForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if ( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectSoundForm));
      this.PanelButtons = new System.Windows.Forms.Panel();
      this.ActionPlay = new System.Windows.Forms.Button();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.ActionOK = new System.Windows.Forms.Button();
      this.SelectNone = new System.Windows.Forms.RadioButton();
      this.SelectCustom = new System.Windows.Forms.RadioButton();
      this.SelectWindows = new System.Windows.Forms.RadioButton();
      this.ActionSelectFilePath = new System.Windows.Forms.Button();
      this.SelectWindowsSound = new System.Windows.Forms.ListBox();
      this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.SelectDialog = new System.Windows.Forms.RadioButton();
      this.SelectDialogSound = new System.Windows.Forms.ComboBox();
      this.SelectApplication = new System.Windows.Forms.RadioButton();
      this.SelectApplicationSound = new System.Windows.Forms.ListBox();
      this.EditVolume = new System.Windows.Forms.TrackBar();
      this.LabelVolumeValue = new System.Windows.Forms.Label();
      this.EditFilePath = new Ordisoftware.Core.TextBoxEx();
      this.PanelButtons.SuspendLayout();
      ( (System.ComponentModel.ISupportInitialize)( this.EditVolume ) ).BeginInit();
      this.SuspendLayout();
      // 
      // PanelButtons
      // 
      this.PanelButtons.Controls.Add(this.ActionPlay);
      this.PanelButtons.Controls.Add(this.ActionCancel);
      this.PanelButtons.Controls.Add(this.ActionOK);
      resources.ApplyResources(this.PanelButtons, "PanelButtons");
      this.PanelButtons.Name = "PanelButtons";
      // 
      // ActionPlay
      // 
      this.ActionPlay.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionPlay, "ActionPlay");
      this.ActionPlay.Name = "ActionPlay";
      this.ActionPlay.UseVisualStyleBackColor = true;
      this.ActionPlay.Click += new System.EventHandler(this.ActionPlay_Click);
      // 
      // ActionCancel
      // 
      resources.ApplyResources(this.ActionCancel, "ActionCancel");
      this.ActionCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionCancel.Name = "ActionCancel";
      // 
      // ActionOK
      // 
      resources.ApplyResources(this.ActionOK, "ActionOK");
      this.ActionOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.ActionOK.Name = "ActionOK";
      this.ActionOK.UseVisualStyleBackColor = true;
      // 
      // SelectNone
      // 
      resources.ApplyResources(this.SelectNone, "SelectNone");
      this.SelectNone.Name = "SelectNone";
      this.SelectNone.TabStop = true;
      this.SelectNone.UseVisualStyleBackColor = true;
      this.SelectNone.CheckedChanged += new System.EventHandler(this.SelectNone_CheckedChanged);
      // 
      // SelectCustom
      // 
      resources.ApplyResources(this.SelectCustom, "SelectCustom");
      this.SelectCustom.Name = "SelectCustom";
      this.SelectCustom.TabStop = true;
      this.SelectCustom.UseVisualStyleBackColor = true;
      this.SelectCustom.CheckedChanged += new System.EventHandler(this.SelectCustom_CheckedChanged);
      // 
      // SelectWindows
      // 
      resources.ApplyResources(this.SelectWindows, "SelectWindows");
      this.SelectWindows.Name = "SelectWindows";
      this.SelectWindows.TabStop = true;
      this.SelectWindows.UseVisualStyleBackColor = true;
      this.SelectWindows.CheckedChanged += new System.EventHandler(this.SelectWindows_CheckedChanged);
      // 
      // ActionSelectFilePath
      // 
      this.ActionSelectFilePath.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionSelectFilePath, "ActionSelectFilePath");
      this.ActionSelectFilePath.Name = "ActionSelectFilePath";
      this.ActionSelectFilePath.UseVisualStyleBackColor = true;
      this.ActionSelectFilePath.Click += new System.EventHandler(this.SelectFilePath_Click);
      // 
      // SelectWindowsSound
      // 
      this.SelectWindowsSound.FormattingEnabled = true;
      resources.ApplyResources(this.SelectWindowsSound, "SelectWindowsSound");
      this.SelectWindowsSound.Name = "SelectWindowsSound";
      this.SelectWindowsSound.SelectedIndexChanged += new System.EventHandler(this.SelectWindowsSound_SelectedIndexChanged);
      // 
      // OpenFileDialog
      // 
      resources.ApplyResources(this.OpenFileDialog, "OpenFileDialog");
      // 
      // SelectDialog
      // 
      resources.ApplyResources(this.SelectDialog, "SelectDialog");
      this.SelectDialog.Name = "SelectDialog";
      this.SelectDialog.TabStop = true;
      this.SelectDialog.UseVisualStyleBackColor = true;
      this.SelectDialog.CheckedChanged += new System.EventHandler(this.SelectDialog_CheckedChanged);
      // 
      // SelectDialogSound
      // 
      this.SelectDialogSound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.SelectDialogSound.FormattingEnabled = true;
      resources.ApplyResources(this.SelectDialogSound, "SelectDialogSound");
      this.SelectDialogSound.Name = "SelectDialogSound";
      this.SelectDialogSound.SelectedIndexChanged += new System.EventHandler(this.SelectDialogSound_SelectedIndexChanged);
      // 
      // SelectApplication
      // 
      resources.ApplyResources(this.SelectApplication, "SelectApplication");
      this.SelectApplication.Name = "SelectApplication";
      this.SelectApplication.TabStop = true;
      this.SelectApplication.UseVisualStyleBackColor = true;
      this.SelectApplication.CheckedChanged += new System.EventHandler(this.SelectApplication_CheckedChanged);
      // 
      // SelectApplicationSound
      // 
      this.SelectApplicationSound.FormattingEnabled = true;
      resources.ApplyResources(this.SelectApplicationSound, "SelectApplicationSound");
      this.SelectApplicationSound.Name = "SelectApplicationSound";
      this.SelectApplicationSound.SelectedIndexChanged += new System.EventHandler(this.SelectApplicationSound_SelectedIndexChanged);
      // 
      // EditVolume
      // 
      resources.ApplyResources(this.EditVolume, "EditVolume");
      this.EditVolume.Maximum = 100;
      this.EditVolume.Name = "EditVolume";
      this.EditVolume.TickFrequency = 10;
      this.EditVolume.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
      this.EditVolume.Value = 100;
      this.EditVolume.ValueChanged += new System.EventHandler(this.EditVolume_ValueChanged);
      // 
      // LabelVolumeValue
      // 
      resources.ApplyResources(this.LabelVolumeValue, "LabelVolumeValue");
      this.LabelVolumeValue.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
      this.LabelVolumeValue.Name = "LabelVolumeValue";
      // 
      // EditFilePath
      // 
      this.EditFilePath.BackColor = System.Drawing.SystemColors.Control;
      this.EditFilePath.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      resources.ApplyResources(this.EditFilePath, "EditFilePath");
      this.EditFilePath.Name = "EditFilePath";
      this.EditFilePath.ReadOnly = true;
      // 
      // SelectSoundForm
      // 
      this.AcceptButton = this.ActionOK;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionCancel;
      this.Controls.Add(this.EditVolume);
      this.Controls.Add(this.LabelVolumeValue);
      this.Controls.Add(this.SelectApplicationSound);
      this.Controls.Add(this.SelectDialogSound);
      this.Controls.Add(this.SelectWindowsSound);
      this.Controls.Add(this.ActionSelectFilePath);
      this.Controls.Add(this.EditFilePath);
      this.Controls.Add(this.SelectWindows);
      this.Controls.Add(this.SelectCustom);
      this.Controls.Add(this.SelectApplication);
      this.Controls.Add(this.SelectDialog);
      this.Controls.Add(this.SelectNone);
      this.Controls.Add(this.PanelButtons);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SelectSoundForm";
      this.Shown += new System.EventHandler(this.SelectSoundForm_Shown);
      this.PanelButtons.ResumeLayout(false);
      ( (System.ComponentModel.ISupportInitialize)( this.EditVolume ) ).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Panel PanelButtons;
    private System.Windows.Forms.Button ActionCancel;
    private System.Windows.Forms.Button ActionOK;
    private System.Windows.Forms.RadioButton SelectNone;
    private System.Windows.Forms.RadioButton SelectCustom;
    private System.Windows.Forms.RadioButton SelectWindows;
    private System.Windows.Forms.Button ActionSelectFilePath;
    private Ordisoftware.Core.TextBoxEx EditFilePath;
    private System.Windows.Forms.ListBox SelectWindowsSound;
    private System.Windows.Forms.OpenFileDialog OpenFileDialog;
    private System.Windows.Forms.RadioButton SelectDialog;
    private System.Windows.Forms.ComboBox SelectDialogSound;
    private System.Windows.Forms.Button ActionPlay;
    private System.Windows.Forms.RadioButton SelectApplication;
    private System.Windows.Forms.ListBox SelectApplicationSound;
    private System.Windows.Forms.TrackBar EditVolume;
    private System.Windows.Forms.Label LabelVolumeValue;
  }
}