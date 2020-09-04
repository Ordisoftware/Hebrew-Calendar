namespace Ordisoftware.HebrewCommon
{
  partial class ShowTextForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowTextForm));
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionClose = new System.Windows.Forms.Button();
      this.PanelSeparator = new System.Windows.Forms.Panel();
      this.PanelTextBox = new System.Windows.Forms.Panel();
      this.TextBox = new Ordisoftware.HebrewCommon.RichTextBoxEx();
      this.PanelBottom.SuspendLayout();
      this.PanelTextBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionClose);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
      // 
      // ActionClose
      // 
      resources.ApplyResources(this.ActionClose, "ActionClose");
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionClose.Name = "ActionClose";
      this.ActionClose.Click += new System.EventHandler(this.ActionClose_Click);
      // 
      // PanelSeparator
      // 
      resources.ApplyResources(this.PanelSeparator, "PanelSeparator");
      this.PanelSeparator.Name = "PanelSeparator";
      // 
      // PanelTextBox
      // 
      this.PanelTextBox.BackColor = System.Drawing.SystemColors.Window;
      this.PanelTextBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.PanelTextBox.Controls.Add(this.TextBox);
      resources.ApplyResources(this.PanelTextBox, "PanelTextBox");
      this.PanelTextBox.Name = "PanelTextBox";
      // 
      // TextBox
      // 
      this.TextBox.BackColor = System.Drawing.SystemColors.Window;
      this.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      resources.ApplyResources(this.TextBox, "TextBox");
      this.TextBox.Name = "TextBox";
      this.TextBox.ReadOnly = true;
      this.TextBox.SelectionAlignment = Ordisoftware.HebrewCommon.TextAlign.Justify;
      this.TextBox.TabStop = false;
      // 
      // ShowTextForm
      // 
      this.AcceptButton = this.ActionClose;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionClose;
      this.Controls.Add(this.PanelTextBox);
      this.Controls.Add(this.PanelSeparator);
      this.Controls.Add(this.PanelBottom);
      this.MaximizeBox = false;
      this.Name = "ShowTextForm";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShowTextForm_FormClosing);
      this.PanelBottom.ResumeLayout(false);
      this.PanelTextBox.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Button ActionClose;
    private System.Windows.Forms.Panel PanelSeparator;
    private System.Windows.Forms.Panel PanelTextBox;
    internal RichTextBoxEx TextBox;
    private System.Windows.Forms.Panel PanelBottom;
  }
}