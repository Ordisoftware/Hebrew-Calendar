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
      this.SelectMonth = new System.Windows.Forms.RadioButton();
      this.SelectGrid = new System.Windows.Forms.RadioButton();
      this.EditAutoOpenExportedFile = new System.Windows.Forms.CheckBox();
      this.EditAutoOpenExportFolder = new System.Windows.Forms.CheckBox();
      this.LabelYear2 = new System.Windows.Forms.Label();
      this.ActionIntervalInfo = new System.Windows.Forms.Button();
      this.SelectSingle = new System.Windows.Forms.RadioButton();
      this.SelectInterval = new System.Windows.Forms.RadioButton();
      this.GroupBoxView = new System.Windows.Forms.GroupBox();
      this.SelectText = new System.Windows.Forms.RadioButton();
      this.GroupBoxOptions = new System.Windows.Forms.GroupBox();
      this.GroupBoxSettings = new System.Windows.Forms.GroupBox();
      this.GroupBoxFormat = new System.Windows.Forms.GroupBox();
      this.GroupBoxYears = new System.Windows.Forms.GroupBox();
      this.SelectYear2 = new Ordisoftware.Core.SelectYearsControl();
      this.SelectYear1 = new Ordisoftware.Core.SelectYearsControl();
      this.labelYear1 = new System.Windows.Forms.Label();
      this.EditExportDataEnumsAsTranslations = new System.Windows.Forms.CheckBox();
      this.EditPrintImageInLandscape = new System.Windows.Forms.CheckBox();
      this.EditShowPrintPreviewDialog = new System.Windows.Forms.CheckBox();
      this.PanelButtons.SuspendLayout();
      this.GroupBoxView.SuspendLayout();
      this.GroupBoxOptions.SuspendLayout();
      this.GroupBoxSettings.SuspendLayout();
      this.GroupBoxYears.SuspendLayout();
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
      // LabelYear2
      // 
      resources.ApplyResources(this.LabelYear2, "LabelYear2");
      this.LabelYear2.Name = "LabelYear2";
      // 
      // ActionIntervalInfo
      // 
      this.ActionIntervalInfo.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionIntervalInfo, "ActionIntervalInfo");
      this.ActionIntervalInfo.Name = "ActionIntervalInfo";
      this.ActionIntervalInfo.UseVisualStyleBackColor = true;
      this.ActionIntervalInfo.Click += new System.EventHandler(this.ActionIntervalInfo_Click);
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
      this.GroupBoxView.Controls.Add(this.SelectText);
      this.GroupBoxView.Controls.Add(this.SelectMonth);
      this.GroupBoxView.Controls.Add(this.SelectGrid);
      resources.ApplyResources(this.GroupBoxView, "GroupBoxView");
      this.GroupBoxView.Name = "GroupBoxView";
      this.GroupBoxView.TabStop = false;
      // 
      // SelectText
      // 
      resources.ApplyResources(this.SelectText, "SelectText");
      this.SelectText.Name = "SelectText";
      this.SelectText.TabStop = true;
      this.SelectText.UseVisualStyleBackColor = true;
      this.SelectText.CheckedChanged += new System.EventHandler(this.SelectView_CheckedChanged);
      // 
      // GroupBoxOptions
      // 
      this.GroupBoxOptions.Controls.Add(this.SelectSingle);
      this.GroupBoxOptions.Controls.Add(this.SelectInterval);
      resources.ApplyResources(this.GroupBoxOptions, "GroupBoxOptions");
      this.GroupBoxOptions.Name = "GroupBoxOptions";
      this.GroupBoxOptions.TabStop = false;
      // 
      // GroupBoxSettings
      // 
      resources.ApplyResources(this.GroupBoxSettings, "GroupBoxSettings");
      this.GroupBoxSettings.Controls.Add(this.EditExportDataEnumsAsTranslations);
      this.GroupBoxSettings.Controls.Add(this.EditAutoOpenExportFolder);
      this.GroupBoxSettings.Controls.Add(this.EditPrintImageInLandscape);
      this.GroupBoxSettings.Controls.Add(this.EditShowPrintPreviewDialog);
      this.GroupBoxSettings.Controls.Add(this.EditAutoOpenExportedFile);
      this.GroupBoxSettings.Name = "GroupBoxSettings";
      this.GroupBoxSettings.TabStop = false;
      // 
      // GroupBoxFormat
      // 
      resources.ApplyResources(this.GroupBoxFormat, "GroupBoxFormat");
      this.GroupBoxFormat.Name = "GroupBoxFormat";
      this.GroupBoxFormat.TabStop = false;
      // 
      // GroupBoxYears
      // 
      this.GroupBoxYears.Controls.Add(this.SelectYear2);
      this.GroupBoxYears.Controls.Add(this.SelectYear1);
      this.GroupBoxYears.Controls.Add(this.ActionIntervalInfo);
      this.GroupBoxYears.Controls.Add(this.labelYear1);
      this.GroupBoxYears.Controls.Add(this.LabelYear2);
      resources.ApplyResources(this.GroupBoxYears, "GroupBoxYears");
      this.GroupBoxYears.Name = "GroupBoxYears";
      this.GroupBoxYears.TabStop = false;
      // 
      // SelectYear2
      // 
      resources.ApplyResources(this.SelectYear2, "SelectYear2");
      this.SelectYear2.Name = "SelectYear2";
      this.SelectYear2.SelectedIndex = -1;
      this.SelectYear2.SelectedItem = null;
      this.SelectYear2.Value = -1;
      // 
      // SelectYear1
      // 
      resources.ApplyResources(this.SelectYear1, "SelectYear1");
      this.SelectYear1.Name = "SelectYear1";
      this.SelectYear1.SelectedIndex = -1;
      this.SelectYear1.SelectedItem = null;
      this.SelectYear1.Value = -1;
      // 
      // labelYear1
      // 
      resources.ApplyResources(this.labelYear1, "labelYear1");
      this.labelYear1.Name = "labelYear1";
      // 
      // EditExportDataEnumsAsTranslations
      // 
      resources.ApplyResources(this.EditExportDataEnumsAsTranslations, "EditExportDataEnumsAsTranslations");
      this.EditExportDataEnumsAsTranslations.Checked = global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default.ExportDataEnumsAsTranslations;
      this.EditExportDataEnumsAsTranslations.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditExportDataEnumsAsTranslations.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default, "ExportDataEnumsAsTranslations", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditExportDataEnumsAsTranslations.Name = "EditExportDataEnumsAsTranslations";
      this.EditExportDataEnumsAsTranslations.UseVisualStyleBackColor = true;
      this.EditExportDataEnumsAsTranslations.CheckedChanged += new System.EventHandler(this.EditExportDataEnumsAsTranslations_CheckedChanged);
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
      // SelectExportTargetForm
      // 
      this.AcceptButton = this.ActionOK;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionCancel;
      this.Controls.Add(this.GroupBoxSettings);
      this.Controls.Add(this.GroupBoxOptions);
      this.Controls.Add(this.GroupBoxFormat);
      this.Controls.Add(this.GroupBoxView);
      this.Controls.Add(this.PanelButtons);
      this.Controls.Add(this.GroupBoxYears);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SelectExportTargetForm";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SelectViewForm_FormClosed);
      this.Load += new System.EventHandler(this.SelectViewForm_Load);
      this.PanelButtons.ResumeLayout(false);
      this.GroupBoxView.ResumeLayout(false);
      this.GroupBoxView.PerformLayout();
      this.GroupBoxOptions.ResumeLayout(false);
      this.GroupBoxOptions.PerformLayout();
      this.GroupBoxSettings.ResumeLayout(false);
      this.GroupBoxSettings.PerformLayout();
      this.GroupBoxYears.ResumeLayout(false);
      this.GroupBoxYears.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Panel PanelButtons;
    private System.Windows.Forms.Button ActionCancel;
    private System.Windows.Forms.Button ActionOK;
    private System.Windows.Forms.RadioButton SelectMonth;
    private System.Windows.Forms.RadioButton SelectGrid;
    private System.Windows.Forms.CheckBox EditAutoOpenExportedFile;
    private System.Windows.Forms.CheckBox EditAutoOpenExportFolder;
    private System.Windows.Forms.CheckBox EditShowPrintPreviewDialog;
    private System.Windows.Forms.Label LabelYear2;
    private System.Windows.Forms.RadioButton SelectSingle;
    private System.Windows.Forms.RadioButton SelectInterval;
    private System.Windows.Forms.GroupBox GroupBoxView;
    private System.Windows.Forms.GroupBox GroupBoxOptions;
    private System.Windows.Forms.GroupBox GroupBoxSettings;
    private System.Windows.Forms.Button ActionIntervalInfo;
    private System.Windows.Forms.CheckBox EditPrintImageInLandscape;
    private System.Windows.Forms.CheckBox EditExportDataEnumsAsTranslations;
    private System.Windows.Forms.GroupBox GroupBoxFormat;
    private System.Windows.Forms.GroupBox GroupBoxYears;
    private System.Windows.Forms.Label labelYear1;
    private Ordisoftware.Core.SelectYearsControl SelectYear2;
    private Ordisoftware.Core.SelectYearsControl SelectYear1;
    private System.Windows.Forms.RadioButton SelectText;
  }
}