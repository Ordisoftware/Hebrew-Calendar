namespace Ordisoftware.Core
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
      this.EditMessage = new System.Windows.Forms.TextBox();
      this.PictureBox = new System.Windows.Forms.PictureBox();
      this.ActionClose = new System.Windows.Forms.Button();
      this.ActionTerminate = new System.Windows.Forms.Button();
      this.EditStack = new System.Windows.Forms.TextBox();
      this.LabelInfoProgram = new System.Windows.Forms.Label();
      this.EditType = new System.Windows.Forms.TextBox();
      this.LabelInfoAction = new System.Windows.Forms.Label();
      this.ActionViewInner = new System.Windows.Forms.Button();
      this.ActionSendToGitHub = new System.Windows.Forms.Button();
      this.ActionViewLog = new System.Windows.Forms.Button();
      ( (System.ComponentModel.ISupportInitialize)( this.PictureBox ) ).BeginInit();
      this.SuspendLayout();
      // 
      // EditMessage
      // 
      resources.ApplyResources(this.EditMessage, "EditMessage");
      this.EditMessage.BackColor = System.Drawing.SystemColors.Window;
      this.EditMessage.Name = "EditMessage";
      this.EditMessage.ReadOnly = true;
      this.EditMessage.TabStop = false;
      // 
      // PictureBox
      // 
      this.PictureBox.BackColor = System.Drawing.Color.Transparent;
      resources.ApplyResources(this.PictureBox, "PictureBox");
      this.PictureBox.Name = "PictureBox";
      this.PictureBox.TabStop = false;
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
      // EditStack
      // 
      resources.ApplyResources(this.EditStack, "EditStack");
      this.EditStack.BackColor = System.Drawing.SystemColors.Window;
      this.EditStack.Name = "EditStack";
      this.EditStack.ReadOnly = true;
      this.EditStack.TabStop = false;
      // 
      // LabelInfoProgram
      // 
      resources.ApplyResources(this.LabelInfoProgram, "LabelInfoProgram");
      this.LabelInfoProgram.Name = "LabelInfoProgram";
      // 
      // EditType
      // 
      resources.ApplyResources(this.EditType, "EditType");
      this.EditType.BackColor = System.Drawing.SystemColors.Window;
      this.EditType.Name = "EditType";
      this.EditType.ReadOnly = true;
      this.EditType.TabStop = false;
      // 
      // LabelInfoAction
      // 
      resources.ApplyResources(this.LabelInfoAction, "LabelInfoAction");
      this.LabelInfoAction.Name = "LabelInfoAction";
      // 
      // ActionViewInner
      // 
      resources.ApplyResources(this.ActionViewInner, "ActionViewInner");
      this.ActionViewInner.Name = "ActionViewInner";
      this.ActionViewInner.UseVisualStyleBackColor = true;
      this.ActionViewInner.Click += new System.EventHandler(this.ActionViewInner_Click);
      // 
      // ActionSendToGitHub
      // 
      resources.ApplyResources(this.ActionSendToGitHub, "ActionSendToGitHub");
      this.ActionSendToGitHub.FlatAppearance.BorderSize = 0;
      this.ActionSendToGitHub.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 192 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
      this.ActionSendToGitHub.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 192 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ), ( (int)( ( (byte)( 192 ) ) ) ));
      this.ActionSendToGitHub.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 255 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ), ( (int)( ( (byte)( 192 ) ) ) ));
      this.ActionSendToGitHub.Name = "ActionSendToGitHub";
      this.ActionSendToGitHub.UseVisualStyleBackColor = true;
      this.ActionSendToGitHub.Click += new System.EventHandler(this.ActionSendToGitHub_Click);
      // 
      // ActionViewLog
      // 
      this.ActionViewLog.FlatAppearance.BorderSize = 0;
      this.ActionViewLog.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 192 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
      this.ActionViewLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 192 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ), ( (int)( ( (byte)( 192 ) ) ) ));
      this.ActionViewLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 255 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ), ( (int)( ( (byte)( 192 ) ) ) ));
      resources.ApplyResources(this.ActionViewLog, "ActionViewLog");
      this.ActionViewLog.Name = "ActionViewLog";
      this.ActionViewLog.UseVisualStyleBackColor = true;
      this.ActionViewLog.Click += new System.EventHandler(this.ActionViewLog_Click);
      // 
      // ExceptionForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.ActionSendToGitHub);
      this.Controls.Add(this.ActionViewLog);
      this.Controls.Add(this.ActionViewInner);
      this.Controls.Add(this.EditType);
      this.Controls.Add(this.LabelInfoAction);
      this.Controls.Add(this.LabelInfoProgram);
      this.Controls.Add(this.EditStack);
      this.Controls.Add(this.ActionTerminate);
      this.Controls.Add(this.ActionClose);
      this.Controls.Add(this.PictureBox);
      this.Controls.Add(this.EditMessage);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ExceptionForm";
      this.Shown += new System.EventHandler(this.ExceptionForm_Shown);
      ( (System.ComponentModel.ISupportInitialize)( this.PictureBox ) ).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    /// <summary>
    /// Message describing the text.
    /// </summary>
    private System.Windows.Forms.TextBox EditMessage;

    /// <summary>
    /// The picture box control.
    /// </summary>
    private System.Windows.Forms.PictureBox PictureBox;

    /// <summary>
    /// The button close control.
    /// </summary>
    private System.Windows.Forms.Button ActionClose;

    /// <summary>
    /// The button terminate control.
    /// </summary>
    private System.Windows.Forms.Button ActionTerminate;

    /// <summary>
    /// Stack of texts.
    /// </summary>
    private System.Windows.Forms.TextBox EditStack;

    /// <summary>
    /// The label information 1 control.
    /// </summary>
    private System.Windows.Forms.Label LabelInfoProgram;

    /// <summary>
    /// The text Exception control.
    /// </summary>
    private System.Windows.Forms.TextBox EditType;

    /// <summary>
    /// The label information 2 control.
    /// </summary>
    private System.Windows.Forms.Label LabelInfoAction;

    /// <summary>
    /// The button view inner control.
    /// </summary>
    private System.Windows.Forms.Button ActionViewInner;
    private System.Windows.Forms.Button ActionSendToGitHub;
    private System.Windows.Forms.Button ActionViewLog;
  }

}