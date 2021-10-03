namespace Ordisoftware.Core
{
  partial class DataFileEditorForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataFileEditorForm));
      this.PanelBottomSeparator = new System.Windows.Forms.Panel();
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionReset = new System.Windows.Forms.LinkLabel();
      this.ActionOK = new System.Windows.Forms.Button();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.TabControl = new System.Windows.Forms.TabControl();
      this.PanelBottom.SuspendLayout();
      this.SuspendLayout();
      // 
      // PanelBottomSeparator
      // 
      resources.ApplyResources(this.PanelBottomSeparator, "PanelBottomSeparator");
      this.PanelBottomSeparator.Name = "PanelBottomSeparator";
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionReset);
      this.PanelBottom.Controls.Add(this.ActionOK);
      this.PanelBottom.Controls.Add(this.ActionCancel);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
      // 
      // ActionReset
      // 
      this.ActionReset.ActiveLinkColor = System.Drawing.Color.MediumBlue;
      resources.ApplyResources(this.ActionReset, "ActionReset");
      this.ActionReset.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.ActionReset.LinkColor = System.Drawing.Color.Navy;
      this.ActionReset.Name = "ActionReset";
      this.ActionReset.TabStop = true;
      this.ActionReset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActionReset_LinkClicked);
      // 
      // ActionOK
      // 
      resources.ApplyResources(this.ActionOK, "ActionOK");
      this.ActionOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.ActionOK.Name = "ActionOK";
      this.ActionOK.Click += new System.EventHandler(this.ActionOK_Click);
      // 
      // ActionCancel
      // 
      resources.ApplyResources(this.ActionCancel, "ActionCancel");
      this.ActionCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionCancel.Name = "ActionCancel";
      this.ActionCancel.Click += new System.EventHandler(this.ActionCancel_Click);
      // 
      // TabControl
      // 
      resources.ApplyResources(this.TabControl, "TabControl");
      this.TabControl.Multiline = true;
      this.TabControl.Name = "TabControl";
      this.TabControl.SelectedIndex = 0;
      this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
      // 
      // DataFileEditorForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionCancel;
      this.Controls.Add(this.TabControl);
      this.Controls.Add(this.PanelBottomSeparator);
      this.Controls.Add(this.PanelBottom);
      this.Name = "DataFileEditorForm";
      this.Load += new System.EventHandler(this.EditProvidersForm_Load);
      this.Shown += new System.EventHandler(this.EditProvidersForm_Shown);
      this.PanelBottom.ResumeLayout(false);
      this.PanelBottom.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel PanelBottomSeparator;
    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionCancel;
    private System.Windows.Forms.Button ActionOK;
    private System.Windows.Forms.TabControl TabControl;
    private System.Windows.Forms.LinkLabel ActionReset;
  }
}