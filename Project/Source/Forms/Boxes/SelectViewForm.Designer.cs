namespace Ordisoftware.Hebrew.Calendar
{
  partial class SelectViewForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectViewForm));
      this.Label = new System.Windows.Forms.Label();
      this.PanelButtons = new System.Windows.Forms.Panel();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.ActionOK = new System.Windows.Forms.Button();
      this.SelectText = new System.Windows.Forms.RadioButton();
      this.SelectMonth = new System.Windows.Forms.RadioButton();
      this.SelectGrid = new System.Windows.Forms.RadioButton();
      this.EditSelectViewToExport = new System.Windows.Forms.CheckBox();
      this.EditAutoOpenExportedFile = new System.Windows.Forms.CheckBox();
      this.EditAutoOpenExportFolder = new System.Windows.Forms.CheckBox();
      this.LabelOptions = new System.Windows.Forms.Label();
      this.EditShowPrintPreviewDialog = new System.Windows.Forms.CheckBox();
      this.PanelButtons.SuspendLayout();
      this.SuspendLayout();
      // 
      // Label
      // 
      resources.ApplyResources(this.Label, "Label");
      this.Label.Name = "Label";
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
      // 
      // SelectMonth
      // 
      resources.ApplyResources(this.SelectMonth, "SelectMonth");
      this.SelectMonth.Name = "SelectMonth";
      this.SelectMonth.TabStop = true;
      this.SelectMonth.UseVisualStyleBackColor = true;
      // 
      // SelectGrid
      // 
      resources.ApplyResources(this.SelectGrid, "SelectGrid");
      this.SelectGrid.Name = "SelectGrid";
      this.SelectGrid.TabStop = true;
      this.SelectGrid.UseVisualStyleBackColor = true;
      // 
      // EditSelectViewToExport
      // 
      resources.ApplyResources(this.EditSelectViewToExport, "EditSelectViewToExport");
      this.EditSelectViewToExport.Checked = global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default.SelectViewToExport;
      this.EditSelectViewToExport.CheckState = System.Windows.Forms.CheckState.Checked;
      this.EditSelectViewToExport.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Ordisoftware.Hebrew.Calendar.Properties.Settings.Default, "SelectViewToExport", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.EditSelectViewToExport.Name = "EditSelectViewToExport";
      this.EditSelectViewToExport.UseVisualStyleBackColor = true;
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
      // LabelOptions
      // 
      resources.ApplyResources(this.LabelOptions, "LabelOptions");
      this.LabelOptions.Name = "LabelOptions";
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
      // SelectViewForm
      // 
      this.AcceptButton = this.ActionOK;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionCancel;
      this.Controls.Add(this.EditSelectViewToExport);
      this.Controls.Add(this.EditAutoOpenExportedFile);
      this.Controls.Add(this.EditShowPrintPreviewDialog);
      this.Controls.Add(this.EditAutoOpenExportFolder);
      this.Controls.Add(this.SelectGrid);
      this.Controls.Add(this.SelectMonth);
      this.Controls.Add(this.SelectText);
      this.Controls.Add(this.PanelButtons);
      this.Controls.Add(this.LabelOptions);
      this.Controls.Add(this.Label);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SelectViewForm";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SelectViewForm_FormClosed);
      this.Load += new System.EventHandler(this.SelectViewForm_Load);
      this.PanelButtons.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label Label;
    private System.Windows.Forms.Panel PanelButtons;
    private System.Windows.Forms.Button ActionCancel;
    private System.Windows.Forms.Button ActionOK;
    private System.Windows.Forms.RadioButton SelectText;
    private System.Windows.Forms.RadioButton SelectMonth;
    private System.Windows.Forms.RadioButton SelectGrid;
    private System.Windows.Forms.CheckBox EditSelectViewToExport;
    private System.Windows.Forms.CheckBox EditAutoOpenExportedFile;
    private System.Windows.Forms.CheckBox EditAutoOpenExportFolder;
    private System.Windows.Forms.Label LabelOptions;
    private System.Windows.Forms.CheckBox EditShowPrintPreviewDialog;
  }
}