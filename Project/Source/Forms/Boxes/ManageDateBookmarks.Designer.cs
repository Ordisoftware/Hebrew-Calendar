namespace Ordisoftware.HebrewCalendar
{
  partial class ManageDateBookmarksForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageDateBookmarksForm));
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionClear = new System.Windows.Forms.Button();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.ActionOK = new System.Windows.Forms.Button();
      this.ListBox = new System.Windows.Forms.ListBox();
      this.ActionDelete = new System.Windows.Forms.Button();
      this.ActionUp = new System.Windows.Forms.Button();
      this.ActionDown = new System.Windows.Forms.Button();
      this.ActionSort = new System.Windows.Forms.Button();
      this.PanelBottom.SuspendLayout();
      this.SuspendLayout();
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionClear);
      this.PanelBottom.Controls.Add(this.ActionCancel);
      this.PanelBottom.Controls.Add(this.ActionOK);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
      // 
      // ActionClear
      // 
      this.ActionClear.AllowDrop = true;
      this.ActionClear.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionClear, "ActionClear");
      this.ActionClear.Name = "ActionClear";
      this.ActionClear.UseVisualStyleBackColor = true;
      this.ActionClear.Click += new System.EventHandler(this.ActionClear_Click);
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
      // ListBox
      // 
      resources.ApplyResources(this.ListBox, "ListBox");
      this.ListBox.FormattingEnabled = true;
      this.ListBox.Name = "ListBox";
      this.ListBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
      // 
      // ActionDelete
      // 
      resources.ApplyResources(this.ActionDelete, "ActionDelete");
      this.ActionDelete.FlatAppearance.BorderSize = 0;
      this.ActionDelete.Name = "ActionDelete";
      this.ActionDelete.UseVisualStyleBackColor = true;
      this.ActionDelete.Click += new System.EventHandler(this.ActionDelete_Click);
      // 
      // ActionUp
      // 
      resources.ApplyResources(this.ActionUp, "ActionUp");
      this.ActionUp.FlatAppearance.BorderSize = 0;
      this.ActionUp.Name = "ActionUp";
      this.ActionUp.UseVisualStyleBackColor = true;
      this.ActionUp.Click += new System.EventHandler(this.ActionUp_Click);
      // 
      // ActionDown
      // 
      resources.ApplyResources(this.ActionDown, "ActionDown");
      this.ActionDown.FlatAppearance.BorderSize = 0;
      this.ActionDown.Name = "ActionDown";
      this.ActionDown.UseVisualStyleBackColor = true;
      this.ActionDown.Click += new System.EventHandler(this.ActionDown_Click);
      // 
      // ActionSort
      // 
      this.ActionSort.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionSort, "ActionSort");
      this.ActionSort.Name = "ActionSort";
      this.ActionSort.UseVisualStyleBackColor = true;
      this.ActionSort.Click += new System.EventHandler(this.ActionSort_Click);
      // 
      // ManageDateBookmarksForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.ActionDown);
      this.Controls.Add(this.ActionSort);
      this.Controls.Add(this.ActionUp);
      this.Controls.Add(this.ActionDelete);
      this.Controls.Add(this.ListBox);
      this.Controls.Add(this.PanelBottom);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ManageDateBookmarksForm";
      this.ShowInTaskbar = false;
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManageDateBookmarks_FormClosed);
      this.Load += new System.EventHandler(this.ManageDateBookmarks_Load);
      this.PanelBottom.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionCancel;
    private System.Windows.Forms.Button ActionOK;
    private System.Windows.Forms.ListBox ListBox;
    private System.Windows.Forms.Button ActionSort;
    private System.Windows.Forms.Button ActionDelete;
    private System.Windows.Forms.Button ActionUp;
    private System.Windows.Forms.Button ActionDown;
    private System.Windows.Forms.Button ActionClear;
  }
}