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
      this.Panel = new System.Windows.Forms.Panel();
      this.Input = new System.Windows.Forms.TextBox();
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
      this.Input.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.Input.Font = new System.Drawing.Font("Hebrew", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Input.Location = new System.Drawing.Point(0, 187);
      this.Input.Name = "Input";
      this.Input.Size = new System.Drawing.Size(510, 53);
      this.Input.TabIndex = 2;
      this.Input.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.Input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
      this.Input.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Input_KeyPress);
      this.Input.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Input_KeyUp);
      // 
      // LettersControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.Input);
      this.Controls.Add(this.Panel);
      this.Name = "LettersControl";
      this.Size = new System.Drawing.Size(510, 240);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    public System.Windows.Forms.TextBox Input;
    public System.Windows.Forms.Panel Panel;
  }
}
