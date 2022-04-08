namespace Ordisoftware.Hebrew.Calendar
{
  partial class SelectBirthTimeForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectBirthTimeForm));
      this.EditTime = new System.Windows.Forms.DateTimePicker();
      this.Label = new System.Windows.Forms.Label();
      this.PanelButtons = new System.Windows.Forms.Panel();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.ActionOK = new System.Windows.Forms.Button();
      this.PanelButtons.SuspendLayout();
      this.SuspendLayout();
      // 
      // EditTime
      // 
      resources.ApplyResources(this.EditTime, "EditTime");
      this.EditTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.EditTime.Name = "EditTime";
      this.EditTime.ShowUpDown = true;
      this.EditTime.Value = new System.DateTime(2019, 10, 20, 0, 0, 0, 0);
      // 
      // Label
      // 
      resources.ApplyResources(this.Label, "Label");
      this.Label.Name = "Label";
      // 
      // PanelButtons
      // 
      resources.ApplyResources(this.PanelButtons, "PanelButtons");
      this.PanelButtons.Controls.Add(this.ActionCancel);
      this.PanelButtons.Controls.Add(this.ActionOK);
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
      // SelectBirthTimeForm
      // 
      this.AcceptButton = this.ActionOK;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionCancel;
      this.Controls.Add(this.PanelButtons);
      this.Controls.Add(this.Label);
      this.Controls.Add(this.EditTime);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SelectBirthTimeForm";
      this.PanelButtons.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label Label;
    private System.Windows.Forms.Panel PanelButtons;
    private System.Windows.Forms.Button ActionCancel;
    private System.Windows.Forms.Button ActionOK;
    public System.Windows.Forms.DateTimePicker EditTime;
  }
}