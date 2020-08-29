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
      this.textMessage = new System.Windows.Forms.TextBox();
      this.pictureBox = new System.Windows.Forms.PictureBox();
      this.buttonClose = new System.Windows.Forms.Button();
      this.buttonTerminate = new System.Windows.Forms.Button();
      this.buttonViewLog = new System.Windows.Forms.Button();
      this.buttonViewStack = new System.Windows.Forms.Button();
      this.textStack = new System.Windows.Forms.TextBox();
      this.labelInfo1 = new System.Windows.Forms.Label();
      this.textException = new System.Windows.Forms.TextBox();
      this.labelInfo2 = new System.Windows.Forms.Label();
      this.buttonPrint = new System.Windows.Forms.Button();
      this.buttonSendMail = new System.Windows.Forms.Button();
      this.printDialog = new System.Windows.Forms.PrintDialog();
      this.printDocument = new System.Drawing.Printing.PrintDocument();
      this.pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
      this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
      this.buttonViewInner = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // textMessage
      // 
      resources.ApplyResources(this.textMessage, "textMessage");
      this.textMessage.BackColor = System.Drawing.SystemColors.Info;
      this.textMessage.Name = "textMessage";
      this.textMessage.ReadOnly = true;
      this.textMessage.TabStop = false;
      // 
      // pictureBox
      // 
      this.pictureBox.BackColor = System.Drawing.Color.Transparent;
      resources.ApplyResources(this.pictureBox, "pictureBox");
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.TabStop = false;
      // 
      // buttonClose
      // 
      resources.ApplyResources(this.buttonClose, "buttonClose");
      this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.buttonClose.Name = "buttonClose";
      this.buttonClose.UseVisualStyleBackColor = true;
      // 
      // buttonTerminate
      // 
      resources.ApplyResources(this.buttonTerminate, "buttonTerminate");
      this.buttonTerminate.DialogResult = System.Windows.Forms.DialogResult.Abort;
      this.buttonTerminate.Name = "buttonTerminate";
      this.buttonTerminate.UseVisualStyleBackColor = true;
      this.buttonTerminate.Click += new System.EventHandler(this.buttonTerminate_Click);
      // 
      // buttonViewLog
      // 
      resources.ApplyResources(this.buttonViewLog, "buttonViewLog");
      this.buttonViewLog.FlatAppearance.BorderSize = 0;
      this.buttonViewLog.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.buttonViewLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.buttonViewLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.buttonViewLog.Name = "buttonViewLog";
      this.buttonViewLog.UseVisualStyleBackColor = true;
      this.buttonViewLog.Click += new System.EventHandler(this.buttonViewLog_Click);
      // 
      // buttonViewStack
      // 
      resources.ApplyResources(this.buttonViewStack, "buttonViewStack");
      this.buttonViewStack.Name = "buttonViewStack";
      this.buttonViewStack.UseVisualStyleBackColor = true;
      this.buttonViewStack.Click += new System.EventHandler(this.buttonViewStack_Click);
      // 
      // textStack
      // 
      resources.ApplyResources(this.textStack, "textStack");
      this.textStack.BackColor = System.Drawing.SystemColors.Info;
      this.textStack.Name = "textStack";
      this.textStack.ReadOnly = true;
      this.textStack.TabStop = false;
      // 
      // labelInfo1
      // 
      resources.ApplyResources(this.labelInfo1, "labelInfo1");
      this.labelInfo1.Name = "labelInfo1";
      // 
      // textException
      // 
      resources.ApplyResources(this.textException, "textException");
      this.textException.BackColor = System.Drawing.SystemColors.Info;
      this.textException.Name = "textException";
      this.textException.ReadOnly = true;
      this.textException.TabStop = false;
      // 
      // labelInfo2
      // 
      resources.ApplyResources(this.labelInfo2, "labelInfo2");
      this.labelInfo2.Name = "labelInfo2";
      // 
      // buttonPrint
      // 
      resources.ApplyResources(this.buttonPrint, "buttonPrint");
      this.buttonPrint.FlatAppearance.BorderSize = 0;
      this.buttonPrint.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.buttonPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.buttonPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.buttonPrint.Name = "buttonPrint";
      this.buttonPrint.UseVisualStyleBackColor = true;
      this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
      // 
      // buttonSendMail
      // 
      resources.ApplyResources(this.buttonSendMail, "buttonSendMail");
      this.buttonSendMail.FlatAppearance.BorderSize = 0;
      this.buttonSendMail.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.buttonSendMail.Name = "buttonSendMail";
      this.buttonSendMail.UseVisualStyleBackColor = true;
      this.buttonSendMail.Click += new System.EventHandler(this.buttonSendMail_Click);
      // 
      // printDialog
      // 
      this.printDialog.Document = this.printDocument;
      this.printDialog.UseEXDialog = true;
      // 
      // printDocument
      // 
      this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
      // 
      // pageSetupDialog
      // 
      this.pageSetupDialog.Document = this.printDocument;
      // 
      // printPreviewDialog
      // 
      resources.ApplyResources(this.printPreviewDialog, "printPreviewDialog");
      this.printPreviewDialog.Document = this.printDocument;
      this.printPreviewDialog.Name = "printPreviewDialog";
      this.printPreviewDialog.UseAntiAlias = true;
      // 
      // buttonViewInner
      // 
      resources.ApplyResources(this.buttonViewInner, "buttonViewInner");
      this.buttonViewInner.Name = "buttonViewInner";
      this.buttonViewInner.UseVisualStyleBackColor = true;
      this.buttonViewInner.Click += new System.EventHandler(this.buttonViewInner_Click);
      // 
      // ExceptionForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.buttonViewInner);
      this.Controls.Add(this.buttonSendMail);
      this.Controls.Add(this.buttonPrint);
      this.Controls.Add(this.textException);
      this.Controls.Add(this.labelInfo2);
      this.Controls.Add(this.labelInfo1);
      this.Controls.Add(this.textStack);
      this.Controls.Add(this.buttonViewLog);
      this.Controls.Add(this.buttonTerminate);
      this.Controls.Add(this.buttonClose);
      this.Controls.Add(this.pictureBox);
      this.Controls.Add(this.textMessage);
      this.Controls.Add(this.buttonViewStack);
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
    private System.Windows.Forms.TextBox textMessage;

    /// <summary>
    /// The picture box control.
    /// </summary>
    private System.Windows.Forms.PictureBox pictureBox;

    /// <summary>
    /// The button close control.
    /// </summary>
    private System.Windows.Forms.Button buttonClose;

    /// <summary>
    /// The button terminate control.
    /// </summary>
    private System.Windows.Forms.Button buttonTerminate;

    /// <summary>
    /// The button view log control.
    /// </summary>
    private System.Windows.Forms.Button buttonViewLog;

    /// <summary>
    /// Stack of button views.
    /// </summary>
    private System.Windows.Forms.Button buttonViewStack;

    /// <summary>
    /// Stack of texts.
    /// </summary>
    private System.Windows.Forms.TextBox textStack;

    /// <summary>
    /// The label information 1 control.
    /// </summary>
    private System.Windows.Forms.Label labelInfo1;

    /// <summary>
    /// The text Exception control.
    /// </summary>
    private System.Windows.Forms.TextBox textException;

    /// <summary>
    /// The label information 2 control.
    /// </summary>
    private System.Windows.Forms.Label labelInfo2;

    /// <summary>
    /// The button print control.
    /// </summary>
    private System.Windows.Forms.Button buttonPrint;

    /// <summary>
    /// The button send mail control.
    /// </summary>
    private System.Windows.Forms.Button buttonSendMail;

    /// <summary>
    /// The print dialog.
    /// </summary>
    private System.Windows.Forms.PrintDialog printDialog;

    /// <summary>
    /// The print document.
    /// </summary>
    private System.Drawing.Printing.PrintDocument printDocument;

    /// <summary>
    /// The page setup dialog.
    /// </summary>
    private System.Windows.Forms.PageSetupDialog pageSetupDialog;

    /// <summary>
    /// The print preview dialog.
    /// </summary>
    private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;

    /// <summary>
    /// The button view inner control.
    /// </summary>
    private System.Windows.Forms.Button buttonViewInner;

  }

}