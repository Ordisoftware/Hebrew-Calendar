using System;
using System.Globalization;
using System.Windows.Forms;

namespace Calendar.NET
{
    internal partial class EventDetails : Form
    {
        private IEvent _event;
        private IEvent _newEvent;

        public IEvent Event
        {
            get { return _event; }
            set
            {
                _event = value;
                FillValues();
            }
        }

        public IEvent NewEvent
        {
            get { return _newEvent; }
        }

        public EventDetails()
        {
            InitializeComponent();
            PopulateComboBox();
        }

        private void EventDetailsLoad(object sender, EventArgs e)
        {

        }

        private void PopulateComboBox()
        {
            cbRecurringFrequency.Items.Add("None");
            cbRecurringFrequency.Items.Add("Custom");
            cbRecurringFrequency.Items.Add("Daily");
            cbRecurringFrequency.Items.Add("Every Monday, Wednesday and Friday");
            cbRecurringFrequency.Items.Add("Every Tuesday and Thursday");
            cbRecurringFrequency.Items.Add("Every Week Day (Mon - Fri)");
            cbRecurringFrequency.Items.Add("Every Weekend (Sat & Sun)");
            cbRecurringFrequency.Items.Add("Every Month");
            cbRecurringFrequency.Items.Add("Every week");
            cbRecurringFrequency.Items.Add("Every year");
        }

        private RecurringFrequencies StringToRecurringFrequencies(string f)
        {
            RecurringFrequencies retval = RecurringFrequencies.None;

            if (f.Equals("Custom"))
                retval = RecurringFrequencies.Custom;
            if (f.Equals("Daily"))
                retval = RecurringFrequencies.Daily;
            if (f.Equals("Every Monday, Wednesday and Friday"))
                retval = RecurringFrequencies.EveryMonWedFri;
            if (f.Equals("Every Tuesday and Thursday"))
                retval = RecurringFrequencies.EveryTueThurs;
            if (f.Equals("Every Week Day (Mon - Fri)"))
                retval = RecurringFrequencies.EveryWeekday;
            if (f.Equals("Every Weekend (Sat & Sun)"))
                retval = RecurringFrequencies.EveryWeekend;
            if (f.Equals("Every Month"))
                retval = RecurringFrequencies.Monthly;
            if (f.Equals("Every week"))
                retval = RecurringFrequencies.Weekly;
            if (f.Equals("Every year"))
                retval = RecurringFrequencies.Yearly;
            if (f.Equals("None"))
                retval = RecurringFrequencies.None;
            return retval;
        }

        private string RecurringFrequencyToString(RecurringFrequencies f)
        {
            string retval = "";

            switch (f)
            {
                case RecurringFrequencies.Custom:
                    retval = "Custom";
                    break;
                case RecurringFrequencies.Daily:
                    retval = "Daily";
                    break;
                case RecurringFrequencies.EveryMonWedFri:
                    retval = "Every Monday, Wednesday and Friday";
                    break;
                case RecurringFrequencies.EveryTueThurs:
                    retval = "Every Tuesday and Thursday";
                    break;
                case RecurringFrequencies.EveryWeekday:
                    retval = "Every Week Day (Mon - Fri)";
                    break;
                case RecurringFrequencies.EveryWeekend:
                    retval = "Every Weekend (Sat & Sun)";
                    break;
                case RecurringFrequencies.Monthly:
                    retval = "Every Month";
                    break;
                case RecurringFrequencies.None:
                    retval = "None";
                    break;
                case RecurringFrequencies.Weekly:
                    retval = "Every week";
                    break;
                case RecurringFrequencies.Yearly:
                    retval = "Every year";
                    break;
            }
            return retval;
        }

        private void FillValues()
        {
            txtEventName.Text = _event.EventText;
            dtDate.Value = _event.Date;
            dtDate.CustomFormat = _event.IgnoreTimeComponent ? "M/d/yyyy" : "M/d/yyyy h:mm tt";
            cbRecurringFrequency.SelectedItem = RecurringFrequencyToString(_event.RecurringFrequency);
            chkThisDayForwardOnly.Enabled = _event.RecurringFrequency != RecurringFrequencies.None;
            chkEnabled.Checked = _event.Enabled;
            lblFont.Text = _event.EventFont.FontFamily.Name + " " + _event.EventFont.Size.ToString(CultureInfo.InvariantCulture) + "pt";
            pnlEventColor.BackColor = _event.EventColor;
            pnlTextColor.BackColor = _event.EventTextColor;
            chkIgnoreTimeComponent.Checked = _event.IgnoreTimeComponent;
            chkEnableTooltip.Checked = _event.TooltipEnabled;

            Text = char.ToUpper(_event.EventText[0]) + _event.EventText.Substring(1) + " Details";

            _newEvent = _event.Clone();
        }

        private void BtnFontClick(object sender, EventArgs e)
        {
            fontDialog1.Font = _newEvent.EventFont;
            DialogResult dr = fontDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                _newEvent.EventFont = fontDialog1.Font;
            }
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            _newEvent.EventText = txtEventName.Text;
            _newEvent.Date = dtDate.Value;
            _newEvent.Enabled = chkEnabled.Checked;
            _newEvent.RecurringFrequency = StringToRecurringFrequencies(cbRecurringFrequency.SelectedItem.ToString());
            _newEvent.ThisDayForwardOnly = chkThisDayForwardOnly.Checked;
            _newEvent.IgnoreTimeComponent = chkIgnoreTimeComponent.Checked;
            _newEvent.TooltipEnabled = chkEnableTooltip.Checked;

            DialogResult = DialogResult.OK;
            
            Close();
        }

        private void PnlEventColorDoubleClick(object sender, EventArgs e)
        {
            colorDialog1.Color = _newEvent.EventColor;
            
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pnlEventColor.BackColor = colorDialog1.Color;
                _newEvent.EventColor = colorDialog1.Color;
            }
        }

        private void PnlTextColorDoubleClick(object sender, EventArgs e)
        {
            colorDialog1.Color = _newEvent.EventColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pnlTextColor.BackColor = colorDialog1.Color;
                _newEvent.EventTextColor = colorDialog1.Color;
            }
        }

        private void ChkIgnoreTimeComponentCheckedChanged(object sender, EventArgs e)
        {
            dtDate.CustomFormat = chkIgnoreTimeComponent.Checked ? "M/d/yyyy" : "M/d/yyyy h:mm tt";
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
