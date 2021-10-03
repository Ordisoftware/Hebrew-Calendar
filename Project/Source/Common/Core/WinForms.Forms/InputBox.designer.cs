using System;
using System.Windows.Forms;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide input box.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  public partial class InputBox<T> : Form
    where T : IConvertible
  {

    /// <summary>
    /// Variable nécessaire au concepteur.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Nettoyage des ressources utilisées.
    /// </summary>
    /// <seealso cref="M:System.Windows.Forms.Form.Dispose(bool)"/>
    /// ### <param name="disposing">true si les ressources managées doivent être supprimées ; sinon,
    /// false.</param>
    protected override void Dispose(bool disposing)
    {
      if ( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Code généré par le Concepteur Windows Form

    /// <summary>
    /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas le contenu de cette
    /// méthode avec list'éditeur de code.
    /// </summary>
    private void InitializeComponent()
    {
      this.ActionOK = new System.Windows.Forms.Button();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.TextBox = new System.Windows.Forms.TextBox();
      this.Label = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // ActionOK
      // 
      this.ActionOK.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.ActionOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.ActionOK.Location = new System.Drawing.Point(79, 5);
      this.ActionOK.Name = "ActionOK";
      this.ActionOK.Size = new System.Drawing.Size(75, 23);
      this.ActionOK.TabIndex = 0;
      this.ActionOK.Text = "OK";
      this.ActionOK.UseVisualStyleBackColor = true;
      this.ActionOK.Click += new System.EventHandler(this.ActionOK_Click);
      // 
      // ActionCancel
      // 
      this.ActionCancel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.ActionCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionCancel.Location = new System.Drawing.Point(160, 5);
      this.ActionCancel.Name = "ActionCancel";
      this.ActionCancel.Size = new System.Drawing.Size(75, 23);
      this.ActionCancel.TabIndex = 1;
      this.ActionCancel.Text = "Cancel";
      this.ActionCancel.UseVisualStyleBackColor = true;
      this.ActionCancel.Click += new System.EventHandler(this.ActionCancel_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.ActionCancel);
      this.panel1.Controls.Add(this.ActionOK);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 63);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(244, 35);
      this.panel1.TabIndex = 1;
      // 
      // TextBox
      // 
      this.TextBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
            | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.TextBox.Location = new System.Drawing.Point(12, 29);
      this.TextBox.Name = "TextBox";
      this.TextBox.Size = new System.Drawing.Size(220, 20);
      this.TextBox.TabIndex = 0;
      // 
      // Label
      // 
      this.Label.AutoSize = true;
      this.Label.Location = new System.Drawing.Point(12, 9);
      this.Label.Name = "Label";
      this.Label.Size = new System.Drawing.Size(63, 13);
      this.Label.TabIndex = 2;
      this.Label.Text = "Value name";
      // 
      // InputBox
      // 
      this.AcceptButton = this.ActionOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionCancel;
      this.ClientSize = new System.Drawing.Size(244, 98);
      this.Controls.Add(this.Label);
      this.Controls.Add(this.TextBox);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "InputBox";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Enter a value";
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    /// <summary>
    /// The button ok control.
    /// </summary>
    private System.Windows.Forms.Button ActionOK;

    /// <summary>
    /// The button cancel control.
    /// </summary>
    private System.Windows.Forms.Button ActionCancel;

    /// <summary>
    /// The first panel.
    /// </summary>
    private System.Windows.Forms.Panel panel1;

    /// <summary>
    /// The text box control.
    /// </summary>
    private System.Windows.Forms.TextBox TextBox;

    /// <summary>
    /// The label.
    /// </summary>
    private System.Windows.Forms.Label Label;

  }

}