namespace Ordisoftware.Hebrew
{
  partial class SelectYearsControl
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
      this.Navigator = new Ordisoftware.Core.ComboBoxNavigator();
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
      // 
      // comboBoxNavigator1
      // 
      this.Navigator.AutoSize = true;
      this.Navigator.ComboBox = this.SelectValue;
      this.Navigator.Location = new System.Drawing.Point(62, 0);
      this.Navigator.Margin = new System.Windows.Forms.Padding(0);
      this.Navigator.Name = "comboBoxNavigator1";
      this.Navigator.SelectedIndex = -1;
      this.Navigator.SelectedItem = null;
      this.Navigator.Size = new System.Drawing.Size(118, 26);
      this.Navigator.TabIndex = 0;
      // 
      // SelectYearsControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.Controls.Add(this.Navigator);
      this.Controls.Add(this.SelectValue);
      this.Name = "SelectYearsControl";
      this.Size = new System.Drawing.Size(180, 26);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    public System.Windows.Forms.ComboBox SelectValue;
    private Core.ComboBoxNavigator Navigator;
  }
}
