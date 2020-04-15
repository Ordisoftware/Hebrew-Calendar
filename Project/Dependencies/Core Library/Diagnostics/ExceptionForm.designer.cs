namespace Ordisoftware.Core.Windows.Forms
{

  /// <summary>
  /// Form for viewing the exception.
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionForm));
      this.textMessage = new System.Windows.Forms.TextBox();
      this.pictureBox = new System.Windows.Forms.PictureBox();
      this.buttonClose = new System.Windows.Forms.Button();
      this.buttonTerminate = new System.Windows.Forms.Button();
      this.buttonViewLog = new System.Windows.Forms.Button();
      this.imageList = new System.Windows.Forms.ImageList(this.components);
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
      this.textMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.textMessage.BackColor = System.Drawing.SystemColors.Info;
      this.textMessage.Location = new System.Drawing.Point(12, 86);
      this.textMessage.Multiline = true;
      this.textMessage.Name = "textMessage";
      this.textMessage.ReadOnly = true;
      this.textMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.textMessage.Size = new System.Drawing.Size(418, 110);
      this.textMessage.TabIndex = 0;
      this.textMessage.TabStop = false;
      // 
      // pictureBox
      // 
      this.pictureBox.BackColor = System.Drawing.Color.Transparent;
      this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
      this.pictureBox.Location = new System.Drawing.Point(17, 12);
      this.pictureBox.Name = "pictureBox";
      this.pictureBox.Size = new System.Drawing.Size(32, 32);
      this.pictureBox.TabIndex = 1;
      this.pictureBox.TabStop = false;
      // 
      // buttonClose
      // 
      this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.buttonClose.Location = new System.Drawing.Point(355, 205);
      this.buttonClose.Name = "buttonClose";
      this.buttonClose.Size = new System.Drawing.Size(75, 23);
      this.buttonClose.TabIndex = 1;
      this.buttonClose.Text = "Close";
      this.buttonClose.UseVisualStyleBackColor = true;
      // 
      // buttonTerminate
      // 
      this.buttonTerminate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonTerminate.Location = new System.Drawing.Point(274, 205);
      this.buttonTerminate.Name = "buttonTerminate";
      this.buttonTerminate.Size = new System.Drawing.Size(75, 23);
      this.buttonTerminate.TabIndex = 2;
      this.buttonTerminate.Text = "Terminate";
      this.buttonTerminate.UseVisualStyleBackColor = true;
      this.buttonTerminate.Click += new System.EventHandler(this.buttonTerminate_Click);
      // 
      // buttonViewLog
      // 
      this.buttonViewLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonViewLog.FlatAppearance.BorderSize = 0;
      this.buttonViewLog.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.buttonViewLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.buttonViewLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.buttonViewLog.ImageIndex = 0;
      this.buttonViewLog.ImageList = this.imageList;
      this.buttonViewLog.Location = new System.Drawing.Point(172, 205);
      this.buttonViewLog.Name = "buttonViewLog";
      this.buttonViewLog.Size = new System.Drawing.Size(28, 23);
      this.buttonViewLog.TabIndex = 4;
      this.buttonViewLog.UseVisualStyleBackColor = true;
      this.buttonViewLog.Click += new System.EventHandler(this.buttonViewLog_Click);
      // 
      // imageList
      // 
      this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
      this.imageList.TransparentColor = System.Drawing.Color.White;
      this.imageList.Images.SetKeyName(0, "shell32_dll_Bmp1111.bmp");
      this.imageList.Images.SetKeyName(1, "comdlg32_dll_Bmp15.bmp");
      this.imageList.Images.SetKeyName(2, "xp036.bmp");
      // 
      // buttonViewStack
      // 
      this.buttonViewStack.Location = new System.Drawing.Point(12, 205);
      this.buttonViewStack.Name = "buttonViewStack";
      this.buttonViewStack.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.buttonViewStack.Size = new System.Drawing.Size(75, 23);
      this.buttonViewStack.TabIndex = 3;
      this.buttonViewStack.Text = "Stack";
      this.buttonViewStack.UseVisualStyleBackColor = true;
      this.buttonViewStack.Click += new System.EventHandler(this.buttonViewStack_Click);
      // 
      // textStack
      // 
      this.textStack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.textStack.BackColor = System.Drawing.SystemColors.Info;
      this.textStack.Location = new System.Drawing.Point(12, 239);
      this.textStack.Multiline = true;
      this.textStack.Name = "textStack";
      this.textStack.ReadOnly = true;
      this.textStack.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.textStack.Size = new System.Drawing.Size(418, 143);
      this.textStack.TabIndex = 0;
      this.textStack.TabStop = false;
      this.textStack.WordWrap = false;
      // 
      // labelInfo1
      // 
      this.labelInfo1.AutoSize = true;
      this.labelInfo1.Location = new System.Drawing.Point(60, 15);
      this.labelInfo1.Name = "labelInfo1";
      this.labelInfo1.Size = new System.Drawing.Size(184, 13);
      this.labelInfo1.TabIndex = 0;
      this.labelInfo1.Text = "Unhandled exception has occured in ";
      // 
      // textException
      // 
      this.textException.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.textException.BackColor = System.Drawing.SystemColors.Info;
      this.textException.Location = new System.Drawing.Point(12, 55);
      this.textException.Name = "textException";
      this.textException.ReadOnly = true;
      this.textException.Size = new System.Drawing.Size(418, 20);
      this.textException.TabIndex = 6;
      this.textException.TabStop = false;
      // 
      // labelInfo2
      // 
      this.labelInfo2.AutoSize = true;
      this.labelInfo2.Location = new System.Drawing.Point(60, 31);
      this.labelInfo2.Name = "labelInfo2";
      this.labelInfo2.Size = new System.Drawing.Size(297, 13);
      this.labelInfo2.TabIndex = 0;
      this.labelInfo2.Text = "You can choose to Continue execution or Terminate program.";
      // 
      // buttonPrint
      // 
      this.buttonPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonPrint.FlatAppearance.BorderSize = 0;
      this.buttonPrint.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.buttonPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.buttonPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.buttonPrint.ImageIndex = 1;
      this.buttonPrint.ImageList = this.imageList;
      this.buttonPrint.Location = new System.Drawing.Point(206, 205);
      this.buttonPrint.Name = "buttonPrint";
      this.buttonPrint.Size = new System.Drawing.Size(28, 23);
      this.buttonPrint.TabIndex = 7;
      this.buttonPrint.UseVisualStyleBackColor = true;
      this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
      // 
      // buttonSendMail
      // 
      this.buttonSendMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonSendMail.FlatAppearance.BorderSize = 0;
      this.buttonSendMail.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.buttonSendMail.ImageIndex = 2;
      this.buttonSendMail.ImageList = this.imageList;
      this.buttonSendMail.Location = new System.Drawing.Point(240, 205);
      this.buttonSendMail.Name = "buttonSendMail";
      this.buttonSendMail.Size = new System.Drawing.Size(28, 23);
      this.buttonSendMail.TabIndex = 8;
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
      this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
      this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
      this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
      this.printPreviewDialog.Document = this.printDocument;
      this.printPreviewDialog.Enabled = true;
      this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
      this.printPreviewDialog.Name = "printPreviewDialog";
      this.printPreviewDialog.UseAntiAlias = true;
      this.printPreviewDialog.Visible = false;
      // 
      // buttonViewInner
      // 
      this.buttonViewInner.Location = new System.Drawing.Point(91, 205);
      this.buttonViewInner.Name = "buttonViewInner";
      this.buttonViewInner.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.buttonViewInner.Size = new System.Drawing.Size(75, 23);
      this.buttonViewInner.TabIndex = 9;
      this.buttonViewInner.Text = "Inner Info";
      this.buttonViewInner.UseVisualStyleBackColor = true;
      this.buttonViewInner.Click += new System.EventHandler(this.buttonViewInner_Click);
      // 
      // ExceptionForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonClose;
      this.ClientSize = new System.Drawing.Size(442, 394);
      this.Controls.Add(this.buttonViewInner);
      this.Controls.Add(this.buttonSendMail);
      this.Controls.Add(this.buttonPrint);
      this.Controls.Add(this.textException);
      this.Controls.Add(this.labelInfo2);
      this.Controls.Add(this.labelInfo1);
      this.Controls.Add(this.textStack);
      this.Controls.Add(this.buttonViewStack);
      this.Controls.Add(this.buttonViewLog);
      this.Controls.Add(this.buttonTerminate);
      this.Controls.Add(this.buttonClose);
      this.Controls.Add(this.pictureBox);
      this.Controls.Add(this.textMessage);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(450, 420);
      this.Name = "ExceptionForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "ExceptionForm";
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
    /// The text exception control.
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
    /// List of images.
    /// </summary>
    private System.Windows.Forms.ImageList imageList;

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