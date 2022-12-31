namespace Ordisoftware.Hebrew.Calendar
{
  partial class SelectCityForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectCityForm));
      this.ActionOK = new System.Windows.Forms.Button();
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionImportSettings = new System.Windows.Forms.Button();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.DummyButton = new System.Windows.Forms.Button();
      this.ListBoxCountries = new System.Windows.Forms.ListBox();
      this.ListBoxCities = new System.Windows.Forms.ListBox();
      this.LabelCountry = new System.Windows.Forms.Label();
      this.LabelCity = new System.Windows.Forms.Label();
      this.EditFilter = new Ordisoftware.Core.TextBoxEx();
      this.LabelFilter = new System.Windows.Forms.Label();
      this.LabelTimeZone = new System.Windows.Forms.Label();
      this.EditTimeZone = new System.Windows.Forms.ComboBox();
      this.OpenSettingsDialog = new System.Windows.Forms.OpenFileDialog();
      this.PanelBottom.SuspendLayout();
      this.SuspendLayout();
      // 
      // ActionOK
      // 
      resources.ApplyResources(this.ActionOK, "ActionOK");
      this.ActionOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.ActionOK.Name = "ActionOK";
      this.ActionOK.UseVisualStyleBackColor = true;
      this.ActionOK.Click += new System.EventHandler(this.ActionOK_Click);
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionImportSettings);
      this.PanelBottom.Controls.Add(this.ActionCancel);
      this.PanelBottom.Controls.Add(this.ActionOK);
      this.PanelBottom.Controls.Add(this.DummyButton);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
      // 
      // ActionImportSettings
      // 
      this.ActionImportSettings.AllowDrop = true;
      this.ActionImportSettings.FlatAppearance.BorderSize = 0;
      resources.ApplyResources(this.ActionImportSettings, "ActionImportSettings");
      this.ActionImportSettings.Name = "ActionImportSettings";
      this.ActionImportSettings.UseVisualStyleBackColor = true;
      this.ActionImportSettings.Click += new System.EventHandler(this.ActionImportSettings_Click);
      // 
      // ActionCancel
      // 
      resources.ApplyResources(this.ActionCancel, "ActionCancel");
      this.ActionCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionCancel.Name = "ActionCancel";
      // 
      // DummyButton
      // 
      resources.ApplyResources(this.DummyButton, "DummyButton");
      this.DummyButton.Name = "DummyButton";
      this.DummyButton.UseVisualStyleBackColor = true;
      // 
      // ListBoxCountries
      // 
      this.ListBoxCountries.FormattingEnabled = true;
      resources.ApplyResources(this.ListBoxCountries, "ListBoxCountries");
      this.ListBoxCountries.Name = "ListBoxCountries";
      this.ListBoxCountries.SelectedIndexChanged += new System.EventHandler(this.ListBoxCountries_SelectedIndexChanged);
      // 
      // ListBoxCities
      // 
      this.ListBoxCities.FormattingEnabled = true;
      resources.ApplyResources(this.ListBoxCities, "ListBoxCities");
      this.ListBoxCities.Name = "ListBoxCities";
      this.ListBoxCities.SelectedIndexChanged += new System.EventHandler(this.ListBoxCities_SelectedIndexChanged);
      // 
      // LabelCountry
      // 
      resources.ApplyResources(this.LabelCountry, "LabelCountry");
      this.LabelCountry.Name = "LabelCountry";
      // 
      // LabelCity
      // 
      resources.ApplyResources(this.LabelCity, "LabelCity");
      this.LabelCity.Name = "LabelCity";
      // 
      // EditFilter
      // 
      this.EditFilter.CaretAfterPaste = Ordisoftware.Core.CaretPositionAfterPaste.Ending;
      resources.ApplyResources(this.EditFilter, "EditFilter");
      this.EditFilter.Name = "EditFilter";
      this.EditFilter.SpellCheckAllowed = false;
      this.EditFilter.TextChanged += new System.EventHandler(this.EditFilter_TextChanged);
      // 
      // LabelFilter
      // 
      resources.ApplyResources(this.LabelFilter, "LabelFilter");
      this.LabelFilter.Name = "LabelFilter";
      // 
      // LabelTimeZone
      // 
      resources.ApplyResources(this.LabelTimeZone, "LabelTimeZone");
      this.LabelTimeZone.Name = "LabelTimeZone";
      // 
      // EditTimeZone
      // 
      this.EditTimeZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.EditTimeZone.FormattingEnabled = true;
      resources.ApplyResources(this.EditTimeZone, "EditTimeZone");
      this.EditTimeZone.Name = "EditTimeZone";
      this.EditTimeZone.SelectedIndexChanged += new System.EventHandler(this.EditTimeZone_SelectedIndexChanged);
      // 
      // SelectCityForm
      // 
      this.AcceptButton = this.ActionOK;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ActionCancel;
      this.Controls.Add(this.EditTimeZone);
      this.Controls.Add(this.LabelTimeZone);
      this.Controls.Add(this.LabelFilter);
      this.Controls.Add(this.EditFilter);
      this.Controls.Add(this.LabelCity);
      this.Controls.Add(this.LabelCountry);
      this.Controls.Add(this.ListBoxCities);
      this.Controls.Add(this.ListBoxCountries);
      this.Controls.Add(this.PanelBottom);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SelectCityForm";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectCityForm_FormClosing);
      this.Load += new System.EventHandler(this.SelectCityForm_Load);
      this.PanelBottom.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Button ActionOK;
    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionCancel;
    private System.Windows.Forms.ListBox ListBoxCountries;
    private System.Windows.Forms.ListBox ListBoxCities;
    private System.Windows.Forms.Label LabelCountry;
    private System.Windows.Forms.Label LabelCity;
    private Ordisoftware.Core.TextBoxEx EditFilter;
    private System.Windows.Forms.Label LabelFilter;
    private System.Windows.Forms.Label LabelTimeZone;
    public System.Windows.Forms.ComboBox EditTimeZone;
    private System.Windows.Forms.Button DummyButton;
    private Button ActionImportSettings;
    private OpenFileDialog OpenSettingsDialog;
  }
}