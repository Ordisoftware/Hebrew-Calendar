namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Form for viewing the Exception.
  /// </summary>
  /// <seealso cref="T:System.Windows.Forms.Form"/>
  partial class ExceptionForm
  {

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// StopAndEmpty up any resources being used.
    /// </summary>
    /// <seealso cref="M:System.Windows.Forms.Form.Dispose(bool)"/>
    /// ### <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
    /// Required method for Designer support - do not modify the contents of this method with the
    /// code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionForm));
      this.TextMessage = new System.Windows.Forms.TextBox();
      this.pictureBox = new System.Windows.Forms.PictureBox();
      this.ActionClose = new System.Windows.Forms.Button();
      this.ActionTerminate = new System.Windows.Forms.Button();
      this.ActionViewStack = new System.Windows.Forms.Button();
      this.TextStack = new System.Windows.Forms.TextBox();
      this.LabelInfo1 = new System.Windows.Forms.Label();
      this.TextException = new System.Windows.Forms.TextBox();
      this.LabelInfo2 = new System.Windows.Forms.Label();
      this.ActionSend = new System.Windows.Forms.Button();
      this.ActionViewInner = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // TextMessage
      // 
      resources.ApplyResources(this.TextMessage, "TextMessage");
      this.TextMessage.BackColor = System.Drawing.SystemColors.Info;
      this.TextMessage.Name = "TextMessage";
      this.TextMessage.ReadOnly = true;
      this.TextMessage.TabStop = false;
      // 
      // pictureBox
      // 
      this.pictureBox.BackColor = System.Drawing.Color.Transparent;
      resources.ApplyResources(this.pictureBox, "pictureBox");
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.TabStop = false;
      // 
      // ActionClose
      // 
      resources.ApplyResources(this.ActionClose, "ActionClose");
      this.ActionClose.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.ActionClose.Name = "ActionClose";
      this.ActionClose.Tag = "";
      this.ActionClose.UseVisualStyleBackColor = true;
      // 
      // ActionTerminate
      // 
      resources.ApplyResources(this.ActionTerminate, "ActionTerminate");
      this.ActionTerminate.DialogResult = System.Windows.Forms.DialogResult.Abort;
      this.ActionTerminate.Name = "ActionTerminate";
      this.ActionTerminate.UseVisualStyleBackColor = true;
      this.ActionTerminate.Click += new System.EventHandler(this.ActionTerminate_Click);
      // 
      // ActionViewStack
      // 
      resources.ApplyResources(this.ActionViewStack, "ActionViewStack");
      this.ActionViewStack.Name = "ActionViewStack";
      this.ActionViewStack.UseVisualStyleBackColor = true;
      this.ActionViewStack.Click += new System.EventHandler(this.ActionViewStack_Click);
      // 
      // TextStack
      // 
      resources.ApplyResources(this.TextStack, "TextStack");
      this.TextStack.BackColor = System.Drawing.SystemColors.Info;
      this.TextStack.Name = "TextStack";
      this.TextStack.ReadOnly = true;
      this.TextStack.TabStop = false;
      // 
      // LabelInfo1
      // 
      resources.ApplyResources(this.LabelInfo1, "LabelInfo1");
      this.LabelInfo1.Name = "LabelInfo1";
      // 
      // TextException
      // 
      resources.ApplyResources(this.TextException, "TextException");
      this.TextException.BackColor = System.Drawing.SystemColors.Info;
      this.TextException.Name = "TextException";
      this.TextException.ReadOnly = true;
      this.TextException.TabStop = false;
      // 
      // LabelInfo2
      // 
      resources.ApplyResources(this.LabelInfo2, "LabelInfo2");
      this.LabelInfo2.Name = "LabelInfo2";
      // 
      // ActionSend
      // 
      resources.ApplyResources(this.ActionSend, "ActionSend");
      this.ActionSend.FlatAppearance.BorderSize = 0;
      this.ActionSend.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.ActionSend.Name = "ActionSend";
      this.ActionSend.UseVisualStyleBackColor = true;
      this.ActionSend.Click += new System.EventHandler(this.ActionSend_Click);
      // 
      // ActionViewInner
      // 
      resources.ApplyResources(this.ActionViewInner, "ActionViewInner");
      this.ActionViewInner.Name = "ActionViewInner";
      this.ActionViewInner.UseVisualStyleBackColor = true;
      this.ActionViewInner.Click += new System.EventHandler(this.ActionViewInner_Click);
      // 
      // ExceptionForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.ActionViewInner);
      this.Controls.Add(this.ActionSend);
      this.Controls.Add(this.TextException);
      this.Controls.Add(this.LabelInfo2);
      this.Controls.Add(this.LabelInfo1);
      this.Controls.Add(this.TextStack);
      this.Controls.Add(this.ActionTerminate);
      this.Controls.Add(this.ActionClose);
      this.Controls.Add(this.pictureBox);
      this.Controls.Add(this.TextMessage);
      this.Controls.Add(this.ActionViewStack);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ExceptionForm";
      this.TopMost = true;
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    /// <summary>
    /// Message describing the text.
    /// </summary>
    private System.Windows.Forms.TextBox TextMessage;

    /// <summary>
    /// The picture box control.
    /// </summary>
    private System.Windows.Forms.PictureBox pictureBox;

    /// <summary>
    /// The button close control.
    /// </summary>
    private System.Windows.Forms.Button ActionClose;

    /// <summary>
    /// The button terminate control.
    /// </summary>
    private System.Windows.Forms.Button ActionTerminate;

    /// <summary>
    /// Stack of button views.
    /// </summary>
    private System.Windows.Forms.Button ActionViewStack;

    /// <summary>
    /// Stack of texts.
    /// </summary>
    private System.Windows.Forms.TextBox TextStack;

    /// <summary>
    /// The label information 1 control.
    /// </summary>
    private System.Windows.Forms.Label LabelInfo1;

    /// <summary>
    /// The text Exception control.
    /// </summary>
    private System.Windows.Forms.TextBox TextException;

    /// <summary>
    /// The label information 2 control.
    /// </summary>
    private System.Windows.Forms.Label LabelInfo2;

    /// <summary>
    /// The button send mail control.
    /// </summary>
    private System.Windows.Forms.Button ActionSend;

    /// <summary>
    /// The button view inner control.
    /// </summary>
    private System.Windows.Forms.Button ActionViewInner;

  }

}