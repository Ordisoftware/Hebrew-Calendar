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
      // SelectViewForm
      // 
      this.AcceptButton = this.ActionOK;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionCancel;
      this.Controls.Add(this.SelectGrid);
      this.Controls.Add(this.SelectMonth);
      this.Controls.Add(this.SelectText);
      this.Controls.Add(this.PanelButtons);
      this.Controls.Add(this.Label);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SelectViewForm";
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
  }
}