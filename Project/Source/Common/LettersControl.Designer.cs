namespace Ordisoftware.HebrewCommon
{
  partial class LettersControl
  {
    /// <summary> 
    /// Variable nécessaire au concepteur.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Nettoyage des ressources utilisées.
    /// </summary>
    /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
    protected override void Dispose(bool disposing)
    {
      if ( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Code généré par le Concepteur de composants

    /// <summary> 
    /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
    /// le contenu de cette méthode avec l'éditeur de code.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LettersControl));
      this.Panel = new System.Windows.Forms.Panel();
      this.Input = new System.Windows.Forms.TextBox();
      this.ContextMenuStripInput = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ActionCopy = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionCut = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionPaste = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.ActionUndo = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionRedo = new System.Windows.Forms.ToolStripMenuItem();
      this.ContextMenuStripInput.SuspendLayout();
      this.SuspendLayout();
      // 
      // Panel
      // 
      this.Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.Panel.BackColor = System.Drawing.SystemColors.Window;
      this.Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.Panel.Location = new System.Drawing.Point(0, 0);
      this.Panel.Name = "Panel";
      this.Panel.Size = new System.Drawing.Size(510, 180);
      this.Panel.TabIndex = 1;
      // 
      // Input
      // 
      this.Input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.Input.ContextMenuStrip = this.ContextMenuStripInput;
      this.Input.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.Input.Font = new System.Drawing.Font("Hebrew", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Input.Location = new System.Drawing.Point(0, 187);
      this.Input.Name = "Input";
      this.Input.Size = new System.Drawing.Size(510, 53);
      this.Input.TabIndex = 2;
      this.Input.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.Input.TextChanged += new System.EventHandler(this.Input_TextChanged);
      this.Input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
      this.Input.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Input_KeyPress);
      this.Input.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Input_KeyUp);
      // 
      // ContextMenuStripInput
      // 
      this.ContextMenuStripInput.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionUndo,
            this.ActionRedo,
            this.toolStripMenuItem1,
            this.ActionCopy,
            this.ActionCut,
            this.ActionPaste});
      this.ContextMenuStripInput.Name = "ContextMenuStrip";
      this.ContextMenuStripInput.Size = new System.Drawing.Size(104, 120);
      this.ContextMenuStripInput.Opened += new System.EventHandler(this.ContextMenuStripInput_Opened);
      // 
      // ActionCopy
      // 
      this.ActionCopy.Image = ((System.Drawing.Image)(resources.GetObject("ActionCopy.Image")));
      this.ActionCopy.Name = "ActionCopy";
      this.ActionCopy.Size = new System.Drawing.Size(180, 22);
      this.ActionCopy.Text = "Copy";
      this.ActionCopy.Click += new System.EventHandler(this.ActionCopy_Click);
      // 
      // ActionCut
      // 
      this.ActionCut.Image = ((System.Drawing.Image)(resources.GetObject("ActionCut.Image")));
      this.ActionCut.Name = "ActionCut";
      this.ActionCut.Size = new System.Drawing.Size(180, 22);
      this.ActionCut.Text = "Cut";
      this.ActionCut.Click += new System.EventHandler(this.ActionCut_Click);
      // 
      // ActionPaste
      // 
      this.ActionPaste.Image = ((System.Drawing.Image)(resources.GetObject("ActionPaste.Image")));
      this.ActionPaste.Name = "ActionPaste";
      this.ActionPaste.Size = new System.Drawing.Size(180, 22);
      this.ActionPaste.Text = "Paste";
      this.ActionPaste.Click += new System.EventHandler(this.ActionPaste_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
      // 
      // ActionUndo
      // 
      this.ActionUndo.Image = ((System.Drawing.Image)(resources.GetObject("ActionUndo.Image")));
      this.ActionUndo.Name = "ActionUndo";
      this.ActionUndo.Size = new System.Drawing.Size(103, 22);
      this.ActionUndo.Text = "Undo";
      this.ActionUndo.Click += new System.EventHandler(this.ActionUndo_Click);
      // 
      // ActionRedo
      // 
      this.ActionRedo.Image = ((System.Drawing.Image)(resources.GetObject("ActionRedo.Image")));
      this.ActionRedo.Name = "ActionRedo";
      this.ActionRedo.Size = new System.Drawing.Size(180, 22);
      this.ActionRedo.Text = "Redo";
      this.ActionRedo.Click += new System.EventHandler(this.ActionRedo_Click);
      // 
      // LettersControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.Input);
      this.Controls.Add(this.Panel);
      this.Name = "LettersControl";
      this.Size = new System.Drawing.Size(510, 240);
      this.ContextMenuStripInput.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    public System.Windows.Forms.TextBox Input;
    public System.Windows.Forms.Panel Panel;
    private System.Windows.Forms.ContextMenuStrip ContextMenuStripInput;
    private System.Windows.Forms.ToolStripMenuItem ActionCopy;
    private System.Windows.Forms.ToolStripMenuItem ActionCut;
    private System.Windows.Forms.ToolStripMenuItem ActionPaste;
    private System.Windows.Forms.ToolStripMenuItem ActionUndo;
    private System.Windows.Forms.ToolStripMenuItem ActionRedo;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
  }
}
