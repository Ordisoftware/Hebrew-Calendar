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
      this.ActionOk = new System.Windows.Forms.Button();
      this.PanelBottom = new System.Windows.Forms.Panel();
      this.ActionCancel = new System.Windows.Forms.Button();
      this.ListBoxCountries = new System.Windows.Forms.ListBox();
      this.ListBoxCities = new System.Windows.Forms.ListBox();
      this.LabelCountry = new System.Windows.Forms.Label();
      this.LabelCity = new System.Windows.Forms.Label();
      this.EditFilter = new System.Windows.Forms.TextBox();
      this.LabelFilter = new System.Windows.Forms.Label();
      this.LabelTimeZone = new System.Windows.Forms.Label();
      this.EditTimeZone = new System.Windows.Forms.ComboBox();
      this.PanelBottom.SuspendLayout();
      this.SuspendLayout();
      // 
      // ActionOk
      // 
      resources.ApplyResources(this.ActionOk, "ActionOk");
      this.ActionOk.Name = "ActionOk";
      this.ActionOk.UseVisualStyleBackColor = true;
      this.ActionOk.Click += new System.EventHandler(this.ActionOk_Click);
      // 
      // PanelBottom
      // 
      this.PanelBottom.Controls.Add(this.ActionCancel);
      this.PanelBottom.Controls.Add(this.ActionOk);
      resources.ApplyResources(this.PanelBottom, "PanelBottom");
      this.PanelBottom.Name = "PanelBottom";
      // 
      // ActionCancel
      // 
      resources.ApplyResources(this.ActionCancel, "ActionCancel");
      this.ActionCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.ActionCancel.Name = "ActionCancel";
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
      resources.ApplyResources(this.EditFilter, "EditFilter");
      this.EditFilter.Name = "EditFilter";
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
      this.AcceptButton = this.ActionOk;
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
      this.ShowInTaskbar = false;
      this.Load += new System.EventHandler(this.SelectCityForm_Load);
      this.PanelBottom.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Button ActionOk;
    private System.Windows.Forms.Panel PanelBottom;
    private System.Windows.Forms.Button ActionCancel;
    private System.Windows.Forms.ListBox ListBoxCountries;
    private System.Windows.Forms.ListBox ListBoxCities;
    private System.Windows.Forms.Label LabelCountry;
    private System.Windows.Forms.Label LabelCity;
    private System.Windows.Forms.TextBox EditFilter;
    private System.Windows.Forms.Label LabelFilter;
    private System.Windows.Forms.Label LabelTimeZone;
    internal System.Windows.Forms.ComboBox EditTimeZone;
  }
}