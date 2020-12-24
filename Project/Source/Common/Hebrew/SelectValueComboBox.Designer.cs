namespace Ordisoftware.Hebrew
{
  partial class SelectValueComboBox
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
      this.SelectValue = new System.Windows.Forms.ComboBox();
      this.ActionLast = new System.Windows.Forms.Button();
      this.ActionNext = new System.Windows.Forms.Button();
      this.ActionFirst = new System.Windows.Forms.Button();
      this.ActionPrevious = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // SelectValue
      // 
      this.SelectValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.SelectValue.FormattingEnabled = true;
      this.SelectValue.Location = new System.Drawing.Point(0, 0);
      this.SelectValue.Name = "SelectValue";
      this.SelectValue.Size = new System.Drawing.Size(55, 21);
      this.SelectValue.TabIndex = 5;
      this.SelectValue.SelectedIndexChanged += new System.EventHandler(this.SelectYear_SelectedIndexChanged);
      // 
      // ActionLast
      // 
      this.ActionLast.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionLast.Location = new System.Drawing.Point(148, -1);
      this.ActionLast.Name = "ActionLast";
      this.ActionLast.Size = new System.Drawing.Size(28, 23);
      this.ActionLast.TabIndex = 9;
      this.ActionLast.Text = ">>";
      this.ActionLast.Click += new System.EventHandler(this.ActionLast_Click);
      // 
      // ActionNext
      // 
      this.ActionNext.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionNext.Location = new System.Drawing.Point(119, -1);
      this.ActionNext.Name = "ActionNext";
      this.ActionNext.Size = new System.Drawing.Size(28, 23);
      this.ActionNext.TabIndex = 8;
      this.ActionNext.Text = ">";
      this.ActionNext.Click += new System.EventHandler(this.ActionNext_Click);
      // 
      // ActionFirst
      // 
      this.ActionFirst.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionFirst.Location = new System.Drawing.Point(61, -1);
      this.ActionFirst.Name = "ActionFirst";
      this.ActionFirst.Size = new System.Drawing.Size(28, 23);
      this.ActionFirst.TabIndex = 6;
      this.ActionFirst.Text = "<<";
      this.ActionFirst.Click += new System.EventHandler(this.ActionFirst_Click);
      // 
      // ActionPrevious
      // 
      this.ActionPrevious.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.ActionPrevious.Location = new System.Drawing.Point(90, -1);
      this.ActionPrevious.Name = "ActionPrevious";
      this.ActionPrevious.Size = new System.Drawing.Size(28, 23);
      this.ActionPrevious.TabIndex = 7;
      this.ActionPrevious.Text = "<";
      this.ActionPrevious.Click += new System.EventHandler(this.ActionPrevious_Click);
      // 
      // SelectValueComboBox
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.Controls.Add(this.SelectValue);
      this.Controls.Add(this.ActionLast);
      this.Controls.Add(this.ActionNext);
      this.Controls.Add(this.ActionFirst);
      this.Controls.Add(this.ActionPrevious);
      this.Name = "SelectValueComboBox";
      this.Size = new System.Drawing.Size(194, 34);
      this.VisibleChanged += new System.EventHandler(this.SelectYearControl_VisibleChanged);
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Button ActionLast;
    private System.Windows.Forms.Button ActionNext;
    private System.Windows.Forms.Button ActionFirst;
    private System.Windows.Forms.Button ActionPrevious;
    public System.Windows.Forms.ComboBox SelectValue;
  }
}
