namespace Ordisoftware.Core
{
  partial class ComboBoxNavigator
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
      this.ActionLast = new System.Windows.Forms.Button();
      this.ActionNext = new System.Windows.Forms.Button();
      this.ActionFirst = new System.Windows.Forms.Button();
      this.ActionPrevious = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // ActionLast
      // 
      this.ActionLast.Enabled = false;
      this.ActionLast.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionLast.Location = new System.Drawing.Point(86, -1);
      this.ActionLast.Name = "ActionLast";
      this.ActionLast.Size = new System.Drawing.Size(28, 23);
      this.ActionLast.TabIndex = 9;
      this.ActionLast.Text = ">>";
      this.ActionLast.Click += new System.EventHandler(this.ActionLast_Click);
      // 
      // ActionNext
      // 
      this.ActionNext.Enabled = false;
      this.ActionNext.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionNext.Location = new System.Drawing.Point(57, -1);
      this.ActionNext.Name = "ActionNext";
      this.ActionNext.Size = new System.Drawing.Size(28, 23);
      this.ActionNext.TabIndex = 8;
      this.ActionNext.Text = ">";
      this.ActionNext.Click += new System.EventHandler(this.ActionNext_Click);
      // 
      // ActionFirst
      // 
      this.ActionFirst.Enabled = false;
      this.ActionFirst.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionFirst.Location = new System.Drawing.Point(-1, -1);
      this.ActionFirst.Name = "ActionFirst";
      this.ActionFirst.Size = new System.Drawing.Size(28, 23);
      this.ActionFirst.TabIndex = 6;
      this.ActionFirst.Text = "<<";
      this.ActionFirst.Click += new System.EventHandler(this.ActionFirst_Click);
      // 
      // ActionPrevious
      // 
      this.ActionPrevious.Enabled = false;
      this.ActionPrevious.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionPrevious.Location = new System.Drawing.Point(28, -1);
      this.ActionPrevious.Name = "ActionPrevious";
      this.ActionPrevious.Size = new System.Drawing.Size(28, 23);
      this.ActionPrevious.TabIndex = 7;
      this.ActionPrevious.Text = "<";
      this.ActionPrevious.Click += new System.EventHandler(this.ActionPrevious_Click);
      // 
      // ComboBoxNavigator
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.Controls.Add(this.ActionLast);
      this.Controls.Add(this.ActionNext);
      this.Controls.Add(this.ActionFirst);
      this.Controls.Add(this.ActionPrevious);
      this.Margin = new System.Windows.Forms.Padding(0);
      this.Name = "ComboBoxNavigator";
      this.Size = new System.Drawing.Size(117, 25);
      this.EnabledChanged += new System.EventHandler(this.ComboBoxNavigator_EnabledChanged);
      this.VisibleChanged += new System.EventHandler(this.ComboBox_VisibleChanged);
      this.ResumeLayout(false);

    }

    #endregion
    public System.Windows.Forms.Button ActionLast;
    public System.Windows.Forms.Button ActionNext;
    public System.Windows.Forms.Button ActionFirst;
    public System.Windows.Forms.Button ActionPrevious;
  }
}
