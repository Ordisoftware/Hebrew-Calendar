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
      this.PanelLetters = new System.Windows.Forms.Panel();
      this.PanelSeparator = new System.Windows.Forms.Panel();
      this.Input = new Ordisoftware.HebrewCommon.UndoRedoTextBox();
      this.SuspendLayout();
      // 
      // PanelLetters
      // 
      this.PanelLetters.BackColor = System.Drawing.SystemColors.Window;
      this.PanelLetters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.PanelLetters.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PanelLetters.Location = new System.Drawing.Point(0, 0);
      this.PanelLetters.Name = "PanelLetters";
      this.PanelLetters.Size = new System.Drawing.Size(510, 179);
      this.PanelLetters.TabIndex = 1;
      // 
      // PanelSeparator
      // 
      this.PanelSeparator.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.PanelSeparator.Location = new System.Drawing.Point(0, 179);
      this.PanelSeparator.Name = "PanelSeparator";
      this.PanelSeparator.Size = new System.Drawing.Size(510, 8);
      this.PanelSeparator.TabIndex = 3;
      // 
      // Input
      // 
      this.Input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.Input.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.Input.Font = new System.Drawing.Font("Hebrew", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Input.Location = new System.Drawing.Point(0, 187);
      this.Input.Name = "Input";
      this.Input.Size = new System.Drawing.Size(510, 53);
      this.Input.TabIndex = 2;
      this.Input.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.Input.TextChanging += new Ordisoftware.HebrewCommon.TextChangingEventHandler(this.Input_TextChanging);
      this.Input.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Input_KeyPress);
      this.Input.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Input_KeyUp);
      // 
      // LettersControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.PanelLetters);
      this.Controls.Add(this.PanelSeparator);
      this.Controls.Add(this.Input);
      this.Name = "LettersControl";
      this.Size = new System.Drawing.Size(510, 240);
      this.Load += new System.EventHandler(this.LettersControl_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Panel PanelSeparator;
    private System.Windows.Forms.Panel PanelLetters;
    private UndoRedoTextBox Input;
  }
}
