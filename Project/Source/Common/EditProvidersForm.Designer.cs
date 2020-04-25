namespace Ordisoftware.HebrewCommon
{
  partial class EditProvidersForm
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
      this.PanelBottomSeparator = new System.Windows.Forms.Panel();
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionOk = new System.Windows.Forms.Button();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.TabControl = new System.Windows.Forms.TabControl();
      this.PanelBottom.SuspendLayout();
      this.SuspendLayout();
      // 
      // PanelBottomSeparator
      // 
      this.PanelBottomSeparator.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.PanelBottomSeparator.Location = new System.Drawing.Point(10, 518);
      this.PanelBottomSeparator.Name = "PanelBottomSeparator";
      this.PanelBottomSeparator.Size = new System.Drawing.Size(772, 10);
      this.PanelBottomSeparator.TabIndex = 42;
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionOk);
      this.PanelBottom.Controls.Add(this.ActionCancel);
      this.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.PanelBottom.Location = new System.Drawing.Point(10, 528);
      this.PanelBottom.Name = "PanelBottom";
      this.PanelBottom.Size = new System.Drawing.Size(772, 28);
      this.PanelBottom.TabIndex = 41;
      // 
      // ActionOk
      // 
      this.ActionOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.ActionOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.ActionOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionOk.Location = new System.Drawing.Point(613, 2);
      this.ActionOk.Name = "ActionOk";
      this.ActionOk.Size = new System.Drawing.Size(75, 24);
      this.ActionOk.TabIndex = 0;
      this.ActionOk.Text = "OK";
      this.ActionOk.Click += new System.EventHandler(this.ActionOk_Click);
      // 
      // ActionCancel
      // 
      this.ActionCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.ActionCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionCancel.Location = new System.Drawing.Point(694, 2);
      this.ActionCancel.Name = "ActionCancel";
      this.ActionCancel.Size = new System.Drawing.Size(75, 24);
      this.ActionCancel.TabIndex = 1;
      this.ActionCancel.Text = "Cancel";
      // 
      // TabControl
      // 
      this.TabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
      this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TabControl.Location = new System.Drawing.Point(10, 10);
      this.TabControl.Multiline = true;
      this.TabControl.Name = "TabControl";
      this.TabControl.SelectedIndex = 0;
      this.TabControl.Size = new System.Drawing.Size(772, 508);
      this.TabControl.TabIndex = 0;
      // 
      // EditProvidersForm
      // 
      this.AcceptButton = this.ActionOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionCancel;
      this.ClientSize = new System.Drawing.Size(792, 566);
      this.Controls.Add(this.TabControl);
      this.Controls.Add(this.PanelBottomSeparator);
      this.Controls.Add(this.PanelBottom);
      this.Location = new System.Drawing.Point(-1, -1);
      this.MinimumSize = new System.Drawing.Size(600, 500);
      this.Name = "EditProvidersForm";
      this.Padding = new System.Windows.Forms.Padding(10);
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Load += new System.EventHandler(this.EditProvidersForm_Load);
      this.PanelBottom.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel PanelBottomSeparator;
    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionCancel;
    private System.Windows.Forms.Button ActionOk;
    private System.Windows.Forms.TabControl TabControl;
  }
}