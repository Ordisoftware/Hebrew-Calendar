namespace Ordisoftware.HebrewCommon
{
  partial class MessageBoxEx
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageBoxEx));
      this.ActionNo = new System.Windows.Forms.Button();
      this.Label = new System.Windows.Forms.Label();
      this.PanelMain = new System.Windows.Forms.Panel();
      this.PictureBox = new System.Windows.Forms.PictureBox();
      this.ActionRetry = new System.Windows.Forms.Button();
      this.ActionIgnore = new System.Windows.Forms.Button();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.ActionOK = new System.Windows.Forms.Button();
      this.ActionYes = new System.Windows.Forms.Button();
      this.ActionAbort = new System.Windows.Forms.Button();
      this.PanelBottom = new System.Windows.Forms.FlowLayoutPanel();
      this.PanelMain.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
      this.PanelBottom.SuspendLayout();
      this.SuspendLayout();
      // 
      // ActionNo
      // 
      resources.ApplyResources(this.ActionNo, "ActionNo");
      this.ActionNo.DialogResult = System.Windows.Forms.DialogResult.No;
      this.ActionNo.Name = "ActionNo";
      this.ActionNo.Click += new System.EventHandler(this.ActionClose_Click);
      // 
      // Label
      // 
      resources.ApplyResources(this.Label, "Label");
      this.Label.Name = "Label";
      // 
      // PanelMain
      // 
      resources.ApplyResources(this.PanelMain, "PanelMain");
      this.PanelMain.BackColor = System.Drawing.SystemColors.Window;
      this.PanelMain.Controls.Add(this.Label);
      this.PanelMain.Controls.Add(this.PictureBox);
      this.PanelMain.Name = "PanelMain";
      // 
      // PictureBox
      // 
      resources.ApplyResources(this.PictureBox, "PictureBox");
      this.PictureBox.Name = "PictureBox";
      this.PictureBox.TabStop = false;
      // 
      // ActionRetry
      // 
      resources.ApplyResources(this.ActionRetry, "ActionRetry");
      this.ActionRetry.DialogResult = System.Windows.Forms.DialogResult.Retry;
      this.ActionRetry.Name = "ActionRetry";
      this.ActionRetry.Click += new System.EventHandler(this.ActionClose_Click);
      // 
      // ActionIgnore
      // 
      resources.ApplyResources(this.ActionIgnore, "ActionIgnore");
      this.ActionIgnore.DialogResult = System.Windows.Forms.DialogResult.Ignore;
      this.ActionIgnore.Name = "ActionIgnore";
      this.ActionIgnore.Click += new System.EventHandler(this.ActionClose_Click);
      // 
      // ActionCancel
      // 
      resources.ApplyResources(this.ActionCancel, "ActionCancel");
      this.ActionCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionCancel.Name = "ActionCancel";
      this.ActionCancel.Click += new System.EventHandler(this.ActionClose_Click);
      // 
      // ActionOK
      // 
      resources.ApplyResources(this.ActionOK, "ActionOK");
      this.ActionOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.ActionOK.Name = "ActionOK";
      this.ActionOK.Click += new System.EventHandler(this.ActionClose_Click);
      // 
      // ActionYes
      // 
      resources.ApplyResources(this.ActionYes, "ActionYes");
      this.ActionYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
      this.ActionYes.Name = "ActionYes";
      this.ActionYes.Click += new System.EventHandler(this.ActionClose_Click);
      // 
      // ActionAbort
      // 
      resources.ApplyResources(this.ActionAbort, "ActionAbort");
      this.ActionAbort.DialogResult = System.Windows.Forms.DialogResult.Abort;
      this.ActionAbort.Name = "ActionAbort";
      this.ActionAbort.Click += new System.EventHandler(this.ActionClose_Click);
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionCancel);
      this.PanelBottom.Controls.Add(this.ActionOK);
      this.PanelBottom.Controls.Add(this.ActionIgnore);
      this.PanelBottom.Controls.Add(this.ActionRetry);
      this.PanelBottom.Controls.Add(this.ActionAbort);
      this.PanelBottom.Controls.Add(this.ActionNo);
      this.PanelBottom.Controls.Add(this.ActionYes);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
      // 
      // MessageBoxEx
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.PanelMain);
      this.Controls.Add(this.PanelBottom);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MessageBoxEx";
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MessageBoxEx_FormClosing);
      this.PanelMain.ResumeLayout(false);
      this.PanelMain.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
      this.PanelBottom.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Button ActionNo;
    private System.Windows.Forms.Panel PanelMain;
    public System.Windows.Forms.Label Label;
    private System.Windows.Forms.Button ActionOK;
    private System.Windows.Forms.Button ActionCancel;
    private System.Windows.Forms.Button ActionIgnore;
    private System.Windows.Forms.Button ActionRetry;
    private System.Windows.Forms.Button ActionYes;
    private System.Windows.Forms.Button ActionAbort;
    private System.Windows.Forms.FlowLayoutPanel PanelBottom;
    private System.Windows.Forms.PictureBox PictureBox;
  }
}