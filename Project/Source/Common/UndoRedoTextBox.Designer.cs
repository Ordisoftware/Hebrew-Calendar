namespace Ordisoftware.HebrewCommon
{
  partial class UndoRedoTextBox
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UndoRedoTextBox));
      this.ContextMenuEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ActionUndo = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionRedo = new System.Windows.Forms.ToolStripMenuItem();
      this.Separator = new System.Windows.Forms.ToolStripSeparator();
      this.ActionCopy = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionCut = new System.Windows.Forms.ToolStripMenuItem();
      this.ActionPaste = new System.Windows.Forms.ToolStripMenuItem();
      this.ContextMenuEdit.SuspendLayout();
      this.SuspendLayout();
      // 
      // ContextMenuEdit
      // 
      this.ContextMenuEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionUndo,
            this.ActionRedo,
            this.Separator,
            this.ActionCopy,
            this.ActionCut,
            this.ActionPaste});
      this.ContextMenuEdit.Name = "ContextMenuStrip";
      this.ContextMenuEdit.Size = new System.Drawing.Size(104, 120);
      this.ContextMenuEdit.Opened += new System.EventHandler(this.ContextMenuEdit_Opened);
      // 
      // ActionUndo
      // 
      this.ActionUndo.Image = ((System.Drawing.Image)(resources.GetObject("ActionUndo.Image")));
      this.ActionUndo.Name = "ActionUndo";
      this.ActionUndo.Size = new System.Drawing.Size(103, 22);
      this.ActionUndo.Text = "Undo";
      // 
      // ActionRedo
      // 
      this.ActionRedo.Image = ((System.Drawing.Image)(resources.GetObject("ActionRedo.Image")));
      this.ActionRedo.Name = "ActionRedo";
      this.ActionRedo.Size = new System.Drawing.Size(103, 22);
      this.ActionRedo.Text = "Redo";
      // 
      // Separator
      // 
      this.Separator.Name = "Separator";
      this.Separator.Size = new System.Drawing.Size(100, 6);
      // 
      // ActionCopy
      // 
      this.ActionCopy.Image = ((System.Drawing.Image)(resources.GetObject("ActionCopy.Image")));
      this.ActionCopy.Name = "ActionCopy";
      this.ActionCopy.Size = new System.Drawing.Size(103, 22);
      this.ActionCopy.Text = "Copy";
      // 
      // ActionCut
      // 
      this.ActionCut.Image = ((System.Drawing.Image)(resources.GetObject("ActionCut.Image")));
      this.ActionCut.Name = "ActionCut";
      this.ActionCut.Size = new System.Drawing.Size(103, 22);
      this.ActionCut.Text = "Cut";
      // 
      // ActionPaste
      // 
      this.ActionPaste.Image = ((System.Drawing.Image)(resources.GetObject("ActionPaste.Image")));
      this.ActionPaste.Name = "ActionPaste";
      this.ActionPaste.Size = new System.Drawing.Size(103, 22);
      this.ActionPaste.Text = "Paste";
      // 
      // UndoRedoTextBox
      // 
      this.ContextMenuStrip = this.ContextMenuEdit;
      this.TextChanged += new System.EventHandler(this.TextChangedEvent);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownEvent);
      this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressEvent);
      this.ContextMenuEdit.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ContextMenuStrip ContextMenuEdit;
    private System.Windows.Forms.ToolStripMenuItem ActionUndo;
    private System.Windows.Forms.ToolStripMenuItem ActionRedo;
    private System.Windows.Forms.ToolStripSeparator Separator;
    private System.Windows.Forms.ToolStripMenuItem ActionCopy;
    private System.Windows.Forms.ToolStripMenuItem ActionCut;
    private System.Windows.Forms.ToolStripMenuItem ActionPaste;
  }
}
