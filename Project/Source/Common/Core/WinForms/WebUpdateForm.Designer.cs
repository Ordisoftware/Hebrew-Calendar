namespace Ordisoftware.Core
{
  partial class WebUpdateForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebUpdateForm));
      this.LabelNewVersion = new System.Windows.Forms.Label();
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.ActionOK = new System.Windows.Forms.Button();
      this.SelectInstall = new System.Windows.Forms.RadioButton();
      this.SelectDownload = new System.Windows.Forms.RadioButton();
      this.ActionReleaseNotes = new System.Windows.Forms.LinkLabel();
      this.PanelBottom.SuspendLayout();
      this.SuspendLayout();
      // 
      // LabelNewVersion
      // 
      resources.ApplyResources(this.LabelNewVersion, "LabelNewVersion");
      this.LabelNewVersion.Name = "LabelNewVersion";
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionCancel);
      this.PanelBottom.Controls.Add(this.ActionOK);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
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
      // SelectInstall
      // 
      resources.ApplyResources(this.SelectInstall, "SelectInstall");
      this.SelectInstall.Checked = true;
      this.SelectInstall.Name = "SelectInstall";
      this.SelectInstall.TabStop = true;
      this.SelectInstall.UseVisualStyleBackColor = true;
      // 
      // SelectDownload
      // 
      resources.ApplyResources(this.SelectDownload, "SelectDownload");
      this.SelectDownload.Name = "SelectDownload";
      this.SelectDownload.UseVisualStyleBackColor = true;
      // 
      // ActionReleaseNotes
      // 
      resources.ApplyResources(this.ActionReleaseNotes, "ActionReleaseNotes");
      this.ActionReleaseNotes.LinkColor = System.Drawing.Color.Navy;
      this.ActionReleaseNotes.Name = "ActionReleaseNotes";
      this.ActionReleaseNotes.TabStop = true;
      this.ActionReleaseNotes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionOpenWebPage_LinkClicked);
      // 
      // WebUpdateForm
      // 
      this.AcceptButton = this.ActionOK;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionCancel;
      this.Controls.Add(this.ActionReleaseNotes);
      this.Controls.Add(this.SelectDownload);
      this.Controls.Add(this.SelectInstall);
      this.Controls.Add(this.PanelBottom);
      this.Controls.Add(this.LabelNewVersion);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "WebUpdateForm";
      this.TopMost = true;
      this.Shown += new System.EventHandler(this.WebUpdateForm_Shown);
      this.PanelBottom.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionCancel;
    private System.Windows.Forms.Button ActionOK;
    internal System.Windows.Forms.RadioButton SelectInstall;
    internal System.Windows.Forms.RadioButton SelectDownload;
    internal System.Windows.Forms.Label LabelNewVersion;
    private System.Windows.Forms.LinkLabel ActionReleaseNotes;
  }
}