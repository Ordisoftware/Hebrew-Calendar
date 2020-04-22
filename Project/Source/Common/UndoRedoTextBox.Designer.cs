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
            this.ActionCut,
            this.ActionCopy,
            this.ActionPaste});
      this.ContextMenuEdit.Name = "ContextMenuStrip";
      resources.ApplyResources(this.ContextMenuEdit, "ContextMenuEdit");
      this.ContextMenuEdit.Opened += new System.EventHandler(this.ContextMenuEdit_Opened);
      // 
      // ActionUndo
      // 
      resources.ApplyResources(this.ActionUndo, "ActionUndo");
      this.ActionUndo.Name = "ActionUndo";
      // 
      // ActionRedo
      // 
      resources.ApplyResources(this.ActionRedo, "ActionRedo");
      this.ActionRedo.Name = "ActionRedo";
      // 
      // Separator
      // 
      this.Separator.Name = "Separator";
      resources.ApplyResources(this.Separator, "Separator");
      // 
      // ActionCopy
      // 
      resources.ApplyResources(this.ActionCopy, "ActionCopy");
      this.ActionCopy.Name = "ActionCopy";
      // 
      // ActionCut
      // 
      resources.ApplyResources(this.ActionCut, "ActionCut");
      this.ActionCut.Name = "ActionCut";
      // 
      // ActionPaste
      // 
      resources.ApplyResources(this.ActionPaste, "ActionPaste");
      this.ActionPaste.Name = "ActionPaste";
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
