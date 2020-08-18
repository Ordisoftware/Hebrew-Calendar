namespace Ordisoftware.HebrewCalendar
{
  partial class SuspendReminderDelayForm
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
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.ActionOk = new System.Windows.Forms.Button();
      this.SelectDelay = new System.Windows.Forms.ListBox();
      this.LabelCustom = new System.Windows.Forms.Label();
      this.EditDelay = new System.Windows.Forms.NumericUpDown();
      this.PanelBottom.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditDelay)).BeginInit();
      this.SuspendLayout();
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionCancel);
      this.PanelBottom.Controls.Add(this.ActionOk);
      this.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.PanelBottom.Location = new System.Drawing.Point(10, 183);
      this.PanelBottom.Name = "PanelBottom";
      this.PanelBottom.Size = new System.Drawing.Size(164, 28);
      this.PanelBottom.TabIndex = 54;
      // 
      // ActionCancel
      // 
      this.ActionCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.ActionCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionCancel.Location = new System.Drawing.Point(86, 2);
      this.ActionCancel.Name = "ActionCancel";
      this.ActionCancel.Size = new System.Drawing.Size(75, 24);
      this.ActionCancel.TabIndex = 1;
      this.ActionCancel.Text = "Cancel";
      // 
      // ActionOk
      // 
      this.ActionOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.ActionOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.ActionOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionOk.Location = new System.Drawing.Point(5, 2);
      this.ActionOk.Name = "ActionOk";
      this.ActionOk.Size = new System.Drawing.Size(75, 24);
      this.ActionOk.TabIndex = 0;
      this.ActionOk.Text = "Ok";
      this.ActionOk.UseVisualStyleBackColor = true;
      // 
      // SelectDelay
      // 
      this.SelectDelay.FormattingEnabled = true;
      this.SelectDelay.Location = new System.Drawing.Point(13, 13);
      this.SelectDelay.Name = "SelectDelay";
      this.SelectDelay.Size = new System.Drawing.Size(87, 160);
      this.SelectDelay.TabIndex = 55;
      this.SelectDelay.SelectedIndexChanged += new System.EventHandler(this.SelectDelay_SelectedIndexChanged);
      // 
      // LabelCustom
      // 
      this.LabelCustom.AutoSize = true;
      this.LabelCustom.Location = new System.Drawing.Point(103, 134);
      this.LabelCustom.Name = "LabelCustom";
      this.LabelCustom.Size = new System.Drawing.Size(44, 13);
      this.LabelCustom.TabIndex = 56;
      this.LabelCustom.Text = "Minutes";
      // 
      // EditDelay
      // 
      this.EditDelay.Location = new System.Drawing.Point(106, 153);
      this.EditDelay.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
      this.EditDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.EditDelay.Name = "EditDelay";
      this.EditDelay.Size = new System.Drawing.Size(65, 20);
      this.EditDelay.TabIndex = 57;
      this.EditDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // SuspendReminderDelayForm
      // 
      this.AcceptButton = this.ActionOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionCancel;
      this.ClientSize = new System.Drawing.Size(184, 221);
      this.Controls.Add(this.EditDelay);
      this.Controls.Add(this.LabelCustom);
      this.Controls.Add(this.SelectDelay);
      this.Controls.Add(this.PanelBottom);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SuspendReminderDelayForm";
      this.Padding = new System.Windows.Forms.Padding(10);
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Select suspend delay";
      this.PanelBottom.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.EditDelay)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionCancel;
    private System.Windows.Forms.Button ActionOk;
    private System.Windows.Forms.ListBox SelectDelay;
    private System.Windows.Forms.Label LabelCustom;
    private System.Windows.Forms.NumericUpDown EditDelay;
  }
}