namespace Ordisoftware.Hebrew.Calendar
{
  partial class SelectExportTargetForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectExportTargetForm));
      this.PanelButtons = new System.Windows.Forms.Panel();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.ActionOK = new System.Windows.Forms.Button();
      this.SelectText = new System.Windows.Forms.RadioButton();
      this.SelectMonth = new System.Windows.Forms.RadioButton();
      this.SelectGrid = new System.Windows.Forms.RadioButton();
      this.EditAutoOpenExportedFile = new System.Windows.Forms.CheckBox();
      this.EditAutoOpenExportFolder = new System.Windows.Forms.CheckBox();
      this.ActionLast2 = new System.Windows.Forms.Button();
      this.ActionNext2 = new System.Windows.Forms.Button();
      this.ActionFirst2 = new System.Windows.Forms.Button();
      this.ActionPrevious2 = new System.Windows.Forms.Button();
      this.EditYear2 = new System.Windows.Forms.ComboBox();
      this.LabelYear2 = new System.Windows.Forms.Label();
      this.ActionLast1 = new System.Windows.Forms.Button();
      this.ActionNext1 = new System.Windows.Forms.Button();
      this.ActionFirst1 = new System.Windows.Forms.Button();
      this.ActionPrevious1 = new System.Windows.Forms.Button();
      this.EditYear1 = new System.Windows.Forms.ComboBox();
      this.LabelYear1 = new System.Windows.Forms.Label();
      this.PanelYears = new System.Windows.Forms.Panel();
      this.SelectSingle = new System.Windows.Forms.RadioButton();
      this.SelectInterval = new System.Windows.Forms.RadioButton();
      this.GroupBoxView = new System.Windows.Forms.GroupBox();
      this.GroupBoxOptions = new System.Windows.Forms.GroupBox();
      this.GroupBoxSettings = new System.Windows.Forms.GroupBox();
      this.ActionIntervalInfo = new System.Windows.Forms.Button();
      this.EditShowPrintPreviewDialog = new System.Windows.Forms.CheckBox();
      this.EditPrintImageInLandscape = new System.Windows.Forms.CheckBox();
      this.PanelButtons.SuspendLayout();
      this.PanelYears.SuspendLayout();
      this.GroupBoxView.SuspendLayout();
      this.GroupBoxOptions.SuspendLayout();
      this.GroupBoxSettings.SuspendLayout();
      this.SuspendLayout();
      // 
      // PanelButtons
      // 
      this.PanelButtons.Controls.Add(this.ActionCancel);
      this.PanelButtons.Controls.Add(this.ActionOK);
      resources.ApplyResources(this.PanelButtons, "PanelButtons");
      this.PanelButtons.Name = "PanelButtons";
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
      // SelectText
      // 
      resources.ApplyResources(this.SelectText, "SelectText");
      this.SelectText.Name = "SelectText";
      this.SelectText.TabStop = true;
      this.SelectText.UseVisualStyleBackColor = true;
      this.SelectText.CheckedChanged += new System.EventHandler(this.SelectView_CheckedChanged);
      // 
      // SelectMonth
      // 
      resources.ApplyResources(this.SelectMonth, "SelectMonth");
      this.SelectMonth.Name = "SelectMonth";
      this.SelectMonth.TabStop = true;
      this.SelectMonth.UseVisualStyleBackColor = true;
      this.SelectMonth.CheckedChanged += new System.EventHandler(this.SelectView_CheckedChanged);
      // 
      // SelectGrid
      // 
      resources.ApplyResources(this.SelectGrid, "SelectGrid");
      this.SelectGrid.Name = "SelectGrid";
      this.SelectGrid.TabStop = true;
      this.SelectGrid.UseVisualStyleBackColor = true;
      this.SelectGrid.CheckedChanged += new System.EventHandler(this.SelectView_CheckedChanged);
      // 
      // EditAutoOpenExportedFile
      // 
      resources.ApplyResources(this.EditAutoOpenExportedFile, "EditAutoOpenExportedFile");
      this.EditAutoOpenExportedFile.Checked = true;
      this.EditAutoOpenExportedFile.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditAutoOpenExportedFile.Name = "EditAutoOpenExportedFile";
      this.EditAutoOpenExportedFile.UseVisualStyleBackColor = true;
      this.EditAutoOpenExportedFile.CheckedChanged += new System.EventHandler(this.EditAutoOpenExportedFile_CheckedChanged);
      // 
      // EditAutoOpenExportFolder
      // 
      resources.ApplyResources(this.EditAutoOpenExportFolder, "EditAutoOpenExportFolder");
      this.EditAutoOpenExportFolder.Name = "EditAutoOpenExportFolder";
      this.EditAutoOpenExportFolder.UseVisualStyleBackColor = true;
      this.EditAutoOpenExportFolder.CheckedChanged += new System.EventHandler(this.EditAutoOpenExportFolder_CheckedChanged);
      // 
      // ActionLast2
      // 
      resources.ApplyResources(this.ActionLast2, "ActionLast2");
      this.ActionLast2.Name = "ActionLast2";
      this.ActionLast2.Click += new System.EventHandler(this.ActionLast2_Click);
      // 
      // ActionNext2
      // 
      resources.ApplyResources(this.ActionNext2, "ActionNext2");
      this.ActionNext2.Name = "ActionNext2";
      this.ActionNext2.Click += new System.EventHandler(this.ActionNext2_Click);
      // 
      // ActionFirst2
      // 
      resources.ApplyResources(this.ActionFirst2, "ActionFirst2");
      this.ActionFirst2.Name = "ActionFirst2";
      this.ActionFirst2.Click += new System.EventHandler(this.ActionFirst2_Click);
      // 
      // ActionPrevious2
      // 
      resources.ApplyResources(this.ActionPrevious2, "ActionPrevious2");
      this.ActionPrevious2.Name = "ActionPrevious2";
      this.ActionPrevious2.Click += new System.EventHandler(this.ActionPrevious2_Click);
      // 
      // EditYear2
      // 
      this.EditYear2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.EditYear2.FormattingEnabled = true;
      resources.ApplyResources(this.EditYear2, "EditYear2");
      this.EditYear2.Name = "EditYear2";
      this.EditYear2.SelectedIndexChanged += new System.EventHandler(this.EditYear2_SelectedIndexChanged);
      // 
      // LabelYear2
      // 
      resources.ApplyResources(this.LabelYear2, "LabelYear2");
      this.LabelYear2.Name = "LabelYear2";
      // 
      // ActionLast1
      // 
      resources.ApplyResources(this.ActionLast1, "ActionLast1");
      this.ActionLast1.Name = "ActionLast1";
      this.ActionLast1.Click += new System.EventHandler(this.ActionLast1_Click);
      // 
      // ActionNext1
      // 
      resources.ApplyResources(this.ActionNext1, "ActionNext1");
      this.ActionNext1.Name = "ActionNext1";
      this.ActionNext1.Click += new System.EventHandler(this.ActionNext1_Click);
      // 
      // ActionFirst1
      // 
      resources.ApplyResources(this.ActionFirst1, "ActionFirst1");
      this.ActionFirst1.Name = "ActionFirst1";
      this.ActionFirst1.Click += new System.EventHandler(this.ActionFirst1_Click);
      // 
      // ActionPrevious1
      // 
      resources.ApplyResources(this.ActionPrevious1, "ActionPrevious1");
      this.ActionPrevious1.Name = "ActionPrevious1";
      this.ActionPrevious1.Click += new System.EventHandler(this.ActionPrevious1_Click);
      // 
      // EditYear1
      // 
      this.EditYear1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.EditYear1.FormattingEnabled = true;
      resources.ApplyResources(this.EditYear1, "EditYear1");
      this.EditYear1.Name = "EditYear1";
      this.EditYear1.SelectedIndexChanged += new System.EventHandler(this.EditYear1_SelectedIndexChanged);
      // 
      // LabelYear1
      // 
      resources.ApplyResources(this.LabelYear1, "LabelYear1");
      this.LabelYear1.BackColor = System.Drawing.SystemColors.Control;
      this.LabelYear1.Name = "LabelYear1";
      // 
      // PanelYears
      // 
      this.PanelYears.Controls.Add(this.ActionIntervalInfo);
      this.PanelYears.Controls.Add(this.LabelYear1);
      this.PanelYears.Controls.Add(this.ActionLast2);
      this.PanelYears.Controls.Add(this.EditYear1);
      this.PanelYears.Controls.Add(this.ActionNext2);
      this.PanelYears.Controls.Add(this.ActionPrevious1);
      this.PanelYears.Controls.Add(this.ActionFirst2);
      this.PanelYears.Controls.Add(this.ActionFirst1);
      this.PanelYears.Controls.Add(this.ActionPrevious2);
      this.PanelYears.Controls.Add(this.ActionNext1);
      this.PanelYears.Controls.Add(this.EditYear2);
      this.PanelYears.Controls.Add(this.ActionLast1);
      this.PanelYears.Controls.Add(this.LabelYear2);
      resources.ApplyResources(this.PanelYears, "PanelYears");
      this.PanelYears.Name = "PanelYears";
      // 
      // SelectSingle
      // 
      resources.ApplyResources(this.SelectSingle, "SelectSingle");
      this.SelectSingle.Checked = true;
      this.SelectSingle.Name = "SelectSingle";
      this.SelectSingle.TabStop = true;
      this.SelectSingle.UseVisualStyleBackColor = true;
      this.SelectSingle.CheckedChanged += new System.EventHandler(this.SelectSingleOrInterval_CheckedChanged);
      // 
      // SelectInterval
      // 
      resources.ApplyResources(this.SelectInterval, "SelectInterval");
      this.SelectInterval.Name = "SelectInterval";
      this.SelectInterval.UseVisualStyleBackColor = true;
      this.SelectInterval.CheckedChanged += new System.EventHandler(this.SelectSingleOrInterval_CheckedChanged);
      // 
      // GroupBoxView
      // 
      resources.ApplyResources(this.GroupBoxView, "GroupBoxView");
      this.GroupBoxView.Controls.Add(this.SelectText);
      this.GroupBoxView.Controls.Add(this.SelectMonth);
      this.GroupBoxView.Controls.Add(this.SelectGrid);
      this.GroupBoxView.Name = "GroupBoxView";
      this.GroupBoxView.TabStop = false;
      // 
      // GroupBoxOptions
      // 
      resources.ApplyResources(this.GroupBoxOptions, "GroupBoxOptions");
      this.GroupBoxOptions.Controls.Add(this.SelectSingle);
      this.GroupBoxOptions.Controls.Add(this.SelectInterval);
      this.GroupBoxOptions.Controls.Add(this.PanelYears);
      this.GroupBoxOptions.Name = "GroupBoxOptions";
      this.GroupBoxOptions.TabStop = false;
      // 
      // GroupBoxSettings
      // 
      resources.ApplyResources(this.GroupBoxSettings, "GroupBoxSettings");
      this.GroupBoxSettings.Controls.Add(this.EditAutoOpenExportFolder);
      this.GroupBoxSettings.Controls.Add(this.EditPrintImageInLandscape);
      this.GroupBoxSettings.Controls.Add(this.EditShowPrintPreviewDialog);
      this.GroupBoxSettings.Controls.Add(this.EditAutoOpenExportedFile);
      this.GroupBoxSettings.Name = "GroupBoxSettings";
      this.GroupBoxSettings.TabStop = false;
      // 
      // ActionIntervalInfo
      // 
      this.ActionIntervalInfo.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionIntervalInfo, "ActionIntervalInfo");
      this.ActionIntervalInfo.Name = "ActionIntervalInfo";
      this.ActionIntervalInfo.UseVisualStyleBackColor = true;
      this.ActionIntervalInfo.Click += new System.EventHandler(this.ActionIntervalInfo_Click);
      // 
      // EditShowPrintPreviewDialog
      // 
      resources.ApplyResources(this.EditShowPrintPreviewDialog, "EditShowPrintPreviewDialog");
      this.EditShowPrintPreviewDialog.Checked = global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default.ShowPrintPreviewDialog;
      this.EditShowPrintPreviewDialog.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditShowPrintPreviewDialog.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default, "ShowPrintPreviewDialog", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditShowPrintPreviewDialog.Name = "EditShowPrintPreviewDialog";
      this.EditShowPrintPreviewDialog.UseVisualStyleBackColor = true;
      this.EditShowPrintPreviewDialog.CheckedChanged += new System.EventHandler(this.EditAutoOpenExportFolder_CheckedChanged);
      // 
      // EditPrintImageInLandscape
      // 
      resources.ApplyResources(this.EditPrintImageInLandscape, "EditPrintImageInLandscape");
      this.EditPrintImageInLandscape.Checked = global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default.PrintImageInLandscape;
      this.EditPrintImageInLandscape.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditPrintImageInLandscape.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default, "PrintImageInLandscape", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditPrintImageInLandscape.Name = "EditPrintImageInLandscape";
      this.EditPrintImageInLandscape.UseVisualStyleBackColor = true;
      this.EditPrintImageInLandscape.CheckedChanged += new System.EventHandler(this.EditAutoOpenExportFolder_CheckedChanged);
      // 
      // SelectExportTargetForm
      // 
      this.AcceptButton = this.ActionOK;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionCancel;
      this.Controls.Add(this.GroupBoxSettings);
      this.Controls.Add(this.GroupBoxOptions);
      this.Controls.Add(this.GroupBoxView);
      this.Controls.Add(this.PanelButtons);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SelectExportTargetForm";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SelectViewForm_FormClosed);
      this.Load += new System.EventHandler(this.SelectViewForm_Load);
      this.PanelButtons.ResumeLayout(false);
      this.PanelYears.ResumeLayout(false);
      this.PanelYears.PerformLayout();
      this.GroupBoxView.ResumeLayout(false);
      this.GroupBoxView.PerformLayout();
      this.GroupBoxOptions.ResumeLayout(false);
      this.GroupBoxOptions.PerformLayout();
      this.GroupBoxSettings.ResumeLayout(false);
      this.GroupBoxSettings.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Panel PanelButtons;
    private System.Windows.Forms.Button ActionCancel;
    private System.Windows.Forms.Button ActionOK;
    private System.Windows.Forms.RadioButton SelectText;
    private System.Windows.Forms.RadioButton SelectMonth;
    private System.Windows.Forms.RadioButton SelectGrid;
    private System.Windows.Forms.CheckBox EditAutoOpenExportedFile;
    private System.Windows.Forms.CheckBox EditAutoOpenExportFolder;
    private System.Windows.Forms.CheckBox EditShowPrintPreviewDialog;
    private System.Windows.Forms.Button ActionLast2;
    private System.Windows.Forms.Button ActionNext2;
    private System.Windows.Forms.Button ActionFirst2;
    private System.Windows.Forms.Button ActionPrevious2;
    private System.Windows.Forms.ComboBox EditYear2;
    private System.Windows.Forms.Label LabelYear2;
    private System.Windows.Forms.Button ActionLast1;
    private System.Windows.Forms.Button ActionNext1;
    private System.Windows.Forms.Button ActionFirst1;
    private System.Windows.Forms.Button ActionPrevious1;
    private System.Windows.Forms.ComboBox EditYear1;
    private System.Windows.Forms.Label LabelYear1;
    private System.Windows.Forms.Panel PanelYears;
    private System.Windows.Forms.RadioButton SelectSingle;
    private System.Windows.Forms.RadioButton SelectInterval;
    private System.Windows.Forms.GroupBox GroupBoxView;
    private System.Windows.Forms.GroupBox GroupBoxOptions;
    private System.Windows.Forms.GroupBox GroupBoxSettings;
    private System.Windows.Forms.Button ActionIntervalInfo;
    private System.Windows.Forms.CheckBox EditPrintImageInLandscape;
  }
}