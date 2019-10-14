namespace Ordisoftware.HebrewCalendar
{
  partial class SearchEventForm
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
      this.PanelButtons = new System.Windows.Forms.Panel();
      this.ButtonCancel = new System.Windows.Forms.Button();
      this.ButtonOk = new System.Windows.Forms.Button();
      this.EditYear = new System.Windows.Forms.NumericUpDown();
      this.LabelYear = new System.Windows.Forms.Label();
      this.SelectEvents = new System.Windows.Forms.ListBox();
      this.PanelButtons.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EditYear)).BeginInit();
      this.SuspendLayout();
      // 
      // PanelButtons
      // 
      this.PanelButtons.Controls.Add(this.ButtonCancel);
      this.PanelButtons.Controls.Add(this.ButtonOk);
      this.PanelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.PanelButtons.Location = new System.Drawing.Point(10, 240);
      this.PanelButtons.Name = "PanelButtons";
      this.PanelButtons.Size = new System.Drawing.Size(161, 28);
      this.PanelButtons.TabIndex = 55;
      // 
      // ButtonCancel
      // 
      this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ButtonCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ButtonCancel.Location = new System.Drawing.Point(83, 2);
      this.ButtonCancel.Name = "ButtonCancel";
      this.ButtonCancel.Size = new System.Drawing.Size(75, 24);
      this.ButtonCancel.TabIndex = 1;
      this.ButtonCancel.Text = "Cancel";
      // 
      // ButtonOk
      // 
      this.ButtonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.ButtonOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ButtonOk.Location = new System.Drawing.Point(2, 2);
      this.ButtonOk.Name = "ButtonOk";
      this.ButtonOk.Size = new System.Drawing.Size(75, 24);
      this.ButtonOk.TabIndex = 0;
      this.ButtonOk.Text = "Ok";
      this.ButtonOk.UseVisualStyleBackColor = true;
      this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
      // 
      // EditYear
      // 
      this.EditYear.Location = new System.Drawing.Point(20, 28);
      this.EditYear.Name = "EditYear";
      this.EditYear.Size = new System.Drawing.Size(50, 20);
      this.EditYear.TabIndex = 53;
      this.EditYear.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
      // 
      // LabelYear
      // 
      this.LabelYear.AutoSize = true;
      this.LabelYear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.LabelYear.Location = new System.Drawing.Point(17, 10);
      this.LabelYear.Name = "LabelYear";
      this.LabelYear.Size = new System.Drawing.Size(29, 13);
      this.LabelYear.TabIndex = 54;
      this.LabelYear.Text = "Year";
      // 
      // SelectEvents
      // 
      this.SelectEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
      this.SelectEvents.FormattingEnabled = true;
      this.SelectEvents.Location = new System.Drawing.Point(20, 59);
      this.SelectEvents.Name = "SelectEvents";
      this.SelectEvents.Size = new System.Drawing.Size(143, 160);
      this.SelectEvents.TabIndex = 56;
      // 
      // SearchEventForm
      // 
      this.AcceptButton = this.ButtonOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ButtonCancel;
      this.ClientSize = new System.Drawing.Size(181, 278);
      this.Controls.Add(this.SelectEvents);
      this.Controls.Add(this.PanelButtons);
      this.Controls.Add(this.EditYear);
      this.Controls.Add(this.LabelYear);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SearchEventForm";
      this.Padding = new System.Windows.Forms.Padding(10);
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Search celebration";
      this.Load += new System.EventHandler(this.SearchEventForm_Load);
      this.PanelButtons.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.EditYear)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel PanelButtons;
    private System.Windows.Forms.Button ButtonCancel;
    private System.Windows.Forms.Button ButtonOk;
    internal System.Windows.Forms.NumericUpDown EditYear;
    private System.Windows.Forms.Label LabelYear;
    internal System.Windows.Forms.ListBox SelectEvents;
  }
}