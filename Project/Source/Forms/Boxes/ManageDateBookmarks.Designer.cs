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
      this.PanelBottom.Controls.Add(this.ActionCancel);
      this.PanelBottom.Controls.Add(this.ActionOK);
      this.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.PanelBottom.Location = new System.Drawing.Point(10, 208);
      this.PanelBottom.Name = "PanelBottom";
      this.PanelBottom.Size = new System.Drawing.Size(212, 28);
      this.PanelBottom.TabIndex = 54;
      // 
      // ActionCancel
      // 
      this.ActionCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.ActionCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionCancel.Location = new System.Drawing.Point(134, 2);
      this.ActionCancel.Name = "ActionCancel";
      this.ActionCancel.Size = new System.Drawing.Size(75, 24);
      this.ActionCancel.TabIndex = 1;
      this.ActionCancel.Text = "Cancel";
      // 
      // ActionOK
      // 
      this.ActionOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.ActionOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.ActionOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionOK.Location = new System.Drawing.Point(53, 2);
      this.ActionOK.Name = "ActionOK";
      this.ActionOK.Size = new System.Drawing.Size(75, 24);
      this.ActionOK.TabIndex = 0;
      this.ActionOK.Text = "OK";
      this.ActionOK.UseVisualStyleBackColor = true;
      // 
      // ListBox
      // 
      this.ListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.ListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ListBox.FormattingEnabled = true;
      this.ListBox.ItemHeight = 15;
      this.ListBox.Location = new System.Drawing.Point(13, 13);
      this.ListBox.Name = "ListBox";
      this.ListBox.Size = new System.Drawing.Size(160, 184);
      this.ListBox.TabIndex = 0;
      this.ListBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
      // 
      // ActionDelete
      // 
      this.ActionDelete.Enabled = false;
      this.ActionDelete.FlatAppearance.BorderSize = 0;
      this.ActionDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ActionDelete.Image = ((System.Drawing.Image)(resources.GetObject("ActionDelete.Image")));
      this.ActionDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionDelete.Location = new System.Drawing.Point(181, 156);
      this.ActionDelete.Name = "ActionDelete";
      this.ActionDelete.Size = new System.Drawing.Size(42, 42);
      this.ActionDelete.TabIndex = 4;
      this.ActionDelete.UseVisualStyleBackColor = true;
      this.ActionDelete.Click += new System.EventHandler(this.ActionDelete_Click);
      // 
      // ActionUp
      // 
      this.ActionUp.Enabled = false;
      this.ActionUp.FlatAppearance.BorderSize = 0;
      this.ActionUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ActionUp.Image = ((System.Drawing.Image)(resources.GetObject("ActionUp.Image")));
      this.ActionUp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionUp.Location = new System.Drawing.Point(181, 60);
      this.ActionUp.Name = "ActionUp";
      this.ActionUp.Size = new System.Drawing.Size(42, 42);
      this.ActionUp.TabIndex = 2;
      this.ActionUp.UseVisualStyleBackColor = true;
      this.ActionUp.Click += new System.EventHandler(this.ActionUp_Click);
      // 
      // ActionDown
      // 
      this.ActionDown.Enabled = false;
      this.ActionDown.FlatAppearance.BorderSize = 0;
      this.ActionDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ActionDown.Image = ((System.Drawing.Image)(resources.GetObject("ActionDown.Image")));
      this.ActionDown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionDown.Location = new System.Drawing.Point(181, 108);
      this.ActionDown.Name = "ActionDown";
      this.ActionDown.Size = new System.Drawing.Size(42, 42);
      this.ActionDown.TabIndex = 3;
      this.ActionDown.UseVisualStyleBackColor = true;
      this.ActionDown.Click += new System.EventHandler(this.ActionDown_Click);
      // 
      // ActionSort
      // 
      this.ActionSort.FlatAppearance.BorderSize = 0;
      this.ActionSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ActionSort.Image = ((System.Drawing.Image)(resources.GetObject("ActionSort.Image")));
      this.ActionSort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionSort.Location = new System.Drawing.Point(181, 12);
      this.ActionSort.Name = "ActionSort";
      this.ActionSort.Size = new System.Drawing.Size(42, 42);
      this.ActionSort.TabIndex = 1;
      this.ActionSort.UseVisualStyleBackColor = true;
      this.ActionSort.Click += new System.EventHandler(this.ActionSort_Click);
      // 
      // ManageDateBookmarksForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(232, 246);
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
      this.Padding = new System.Windows.Forms.Padding(10);
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Manage date bookmarks";
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
  }
}