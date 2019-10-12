namespace Ordisoftware.HebrewCalendar
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectCityForm));
      this.ButtonOk = new System.Windows.Forms.Button();
      this.PanelButtons = new System.Windows.Forms.Panel();
      this.ButtonCancel = new System.Windows.Forms.Button();
      this.ListBoxCountries = new System.Windows.Forms.ListBox();
      this.ListBoxCities = new System.Windows.Forms.ListBox();
      this.LabelCountry = new System.Windows.Forms.Label();
      this.LabelCity = new System.Windows.Forms.Label();
      this.EditFilter = new System.Windows.Forms.TextBox();
      this.LabelFilter = new System.Windows.Forms.Label();
      this.PanelButtons.SuspendLayout();
      this.SuspendLayout();
      // 
      // ButtonOk
      // 
      resources.ApplyResources(this.ButtonOk, "ButtonOk");
      this.ButtonOk.Name = "ButtonOk";
      this.ButtonOk.UseVisualStyleBackColor = true;
      this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
      // 
      // PanelButtons
      // 
      resources.ApplyResources(this.PanelButtons, "PanelButtons");
      this.PanelButtons.Controls.Add(this.ButtonCancel);
      this.PanelButtons.Controls.Add(this.ButtonOk);
      this.PanelButtons.Name = "PanelButtons";
      // 
      // ButtonCancel
      // 
      resources.ApplyResources(this.ButtonCancel, "ButtonCancel");
      this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ButtonCancel.Name = "ButtonCancel";
      // 
      // ListBoxCountries
      // 
      resources.ApplyResources(this.ListBoxCountries, "ListBoxCountries");
      this.ListBoxCountries.FormattingEnabled = true;
      this.ListBoxCountries.Name = "ListBoxCountries";
      this.ListBoxCountries.SelectedIndexChanged += new System.EventHandler(this.ListBoxCountries_SelectedIndexChanged);
      // 
      // ListBoxCities
      // 
      resources.ApplyResources(this.ListBoxCities, "ListBoxCities");
      this.ListBoxCities.FormattingEnabled = true;
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
      resources.ApplyResources(this.EditFilter, "EditFilter");
      this.EditFilter.Name = "EditFilter";
      this.EditFilter.TextChanged += new System.EventHandler(this.EditFilter_TextChanged);
      // 
      // LabelFilter
      // 
      resources.ApplyResources(this.LabelFilter, "LabelFilter");
      this.LabelFilter.Name = "LabelFilter";
      // 
      // SelectCityForm
      // 
      this.AcceptButton = this.ButtonOk;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.ButtonCancel;
      this.Controls.Add(this.LabelFilter);
      this.Controls.Add(this.EditFilter);
      this.Controls.Add(this.LabelCity);
      this.Controls.Add(this.LabelCountry);
      this.Controls.Add(this.ListBoxCities);
      this.Controls.Add(this.ListBoxCountries);
      this.Controls.Add(this.PanelButtons);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SelectCityForm";
      this.ShowInTaskbar = false;
      this.Load += new System.EventHandler(this.SelectCityForm_Load);
      this.PanelButtons.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Button ButtonOk;
    private System.Windows.Forms.Panel PanelButtons;
    private System.Windows.Forms.Button ButtonCancel;
    private System.Windows.Forms.ListBox ListBoxCountries;
    private System.Windows.Forms.ListBox ListBoxCities;
    private System.Windows.Forms.Label LabelCountry;
    private System.Windows.Forms.Label LabelCity;
    private System.Windows.Forms.TextBox EditFilter;
    private System.Windows.Forms.Label LabelFilter;
  }
}