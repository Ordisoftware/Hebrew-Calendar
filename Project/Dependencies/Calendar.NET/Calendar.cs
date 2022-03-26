using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Ordisoftware.Core;
using Ordisoftware.Hebrew.Calendar;

namespace CodeProjectCalendar.NET
{
  /// <summary>
  /// An enumeration describing various ways to view the calendar
  /// </summary>
  public enum CalendarViews
  {
    /// <summary>
    /// Renders the Calendar in a month view
    /// </summary>
    Month = 1,
    /// <summary>
    /// Renders the Calendar in a day view
    /// </summary>
    Day = 2
  }

  /// <summary>
  /// A Winforms Calendar Control
  /// </summary>
  [SuppressMessage("Performance", "U2U1008:Parentheses can be used to enable constant evaluation", Justification = "TODO")]
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP017:Prefer using", Justification = "<En attente>")]
  public class Calendar : UserControl
  {
    private DateTime _calendarDate;
    private Font _dayOfWeekFont;
    private Font _daysFont;
    private Font _todayFont;
    private Font _dateHeaderFont;
    private Font _dayViewTimeFont;
    private bool _showArrowControls;
    private bool _showTodayButton;
    private bool _showDateInHeader;
    internal TodayButton _btnToday;
    private NavigateLeftButton _btnLeft;
    private NavigateRightButton _btnRight;
    private bool _showingToolTip;
    private bool _showEventTooltips;
    private bool _loadPresetHolidays;
    private CalendarEvent _clickedEvent;
    private bool _showDisabledEvents;
    private bool _showDashedBorderOnDisabledEvents;
    private bool _dimDisabledEvents;
    private bool _highlightCurrentDay;
    private CalendarViews _calendarView;
    private readonly ScrollPanel _scrollPanel;

    // ORDISOFTWARE MODIF BEGIN
    public List<IEvent> TheEvents { get; }
    internal List<CalendarEvent> CalendarEvents { get; }

    private readonly List<Rectangle> _rectangles;
    private readonly Dictionary<int, Point> _calendarDays;
    private readonly EventToolTip _eventTip;
    private ContextMenuStrip _contextMenuStrip;

    public event Action<DateTime> CalendarDateChanged;

    private const int MarginSize = 5;
    internal Brush RogueBrush = new SolidBrush(Color.FromArgb(255, 250, 250, 250));

    static public Color ColorText { get; set; } = Color.Black;
    static public Brush BrushGrayMedium { get; set; } = new SolidBrush(Color.FromArgb(170, 170, 170));
    static public Brush BrushGrayLight { get; set; } = new SolidBrush(Color.FromArgb(234, 234, 234));
    static public Brush BrushText { get; set; } = Brushes.Black;
    static public Brush BrushBlack { get; set; } = Brushes.Black;
    static public Brush CurrentDayForeBrush { get; set; } = Brushes.White;
    static public Brush CurrentDayBackBrush { get; set; } = Brushes.Firebrick;
    static public Pen PenBlack { get; set; } = Pens.Black;
    static public Pen PenText { get; set; } = Pens.Black;
    static public Pen PenTextReduced { get; set; } = Pens.DarkGray;
    static public Pen PenActiveDay { get; set; } = Pens.MediumSlateBlue;
    static public Pen PenSelectedDay { get; set; } = Pens.Brown;
    static public Pen PenHoverEffect { get; set; } = new Pen(Program.Settings.CalendarColorHoverEffect);
    // ORDISOFTWARE MODIF END

    /// <summary>
    /// Indicates the font for the times on the day view
    /// </summary>
    public Font DayViewTimeFont
    {
      get { return _dayViewTimeFont; }
      set
      {
        _dayViewTimeFont = value;
        if ( _calendarView == CalendarViews.Day )
          _scrollPanel.Refresh();
        else Refresh();
      }
    }


    /// <summary>
    /// Indicates the type of calendar to render, Month or Day view
    /// </summary>
    public CalendarViews CalendarView
    {
      get { return _calendarView; }
      set
      {
        _calendarView = value;
        _scrollPanel.Visible = value == CalendarViews.Day;
        Refresh();
      }
    }

    /// <summary>
    /// Indicates whether today's date should be highlighted
    /// </summary>
    public bool HighlightCurrentDay
    {
      get { return _highlightCurrentDay; }
      set
      {
        _highlightCurrentDay = value;
        Refresh();
      }
    }

    /// <summary>
    /// Indicates whether events can be right-clicked and edited
    /// </summary>
    public bool AllowEditingEvents
    {
      get;
      set;
    }

    /// <summary>
    /// Indicates whether disabled events will appear as "dimmed".
    /// This property is only used if <see cref="ShowDisabledEvents"/> is set to true.
    /// </summary>
    public bool DimDisabledEvents
    {
      get { return _dimDisabledEvents; }
      set
      {
        _dimDisabledEvents = value;
        Refresh();
      }
    }

    /// <summary>
    /// Indicates if a dashed border should show up around disabled events.
    /// This property is only used if <see cref="ShowDisabledEvents"/> is set to true.
    /// </summary>
    public bool ShowDashedBorderOnDisabledEvents
    {
      get { return _showDashedBorderOnDisabledEvents; }
      set
      {
        _showDashedBorderOnDisabledEvents = value;
        Refresh();
      }
    }

    /// <summary>
    /// Indicates whether disabled events should show up on the calendar control
    /// </summary>
    public bool ShowDisabledEvents
    {
      get { return _showDisabledEvents; }
      set
      {
        _showDisabledEvents = value;
        Refresh();
      }
    }

    /// <summary>
    /// Indicates whether Federal Holidays are automatically preloaded onto the calendar
    /// </summary>
    public bool LoadPresetHolidays
    {
      get { return _loadPresetHolidays; }
      set
      {
        _loadPresetHolidays = value;
        if ( _loadPresetHolidays )
        {
          TheEvents.Clear();
          PresetHolidays();
          Refresh();
        }
        else
        {
          TheEvents.Clear();
          Refresh();
        }
      }
    }

    /// <summary>
    /// Indicates whether hovering over an event will display a tooltip of the event
    /// </summary>
    public bool ShowEventTooltips
    {
      get { return _showEventTooltips; }
      set { _showEventTooltips = value; _eventTip.Visible = false; }
    }

    /// <summary>
    /// Get or Set this value to the Font you wish to use to render the date in the upper right corner
    /// </summary>
    public Font DateHeaderFont
    {
      get { return _dateHeaderFont; }
      set
      {
        _dateHeaderFont = value;
        Refresh();
      }
    }

    /// <summary>
    /// Indicates whether the date should be displayed in the upper right hand corner of the calendar control
    /// </summary>
    public bool ShowDateInHeader
    {
      get { return _showDateInHeader; }
      set
      {
        _showDateInHeader = value;
        if ( _calendarView == CalendarViews.Day )
          ResizeScrollPanel();

        Refresh();
      }
    }

    /// <summary>
    /// Indicates whether the calendar control should render the previous/next month buttons
    /// </summary>
    public bool ShowArrowControls
    {
      get { return _showArrowControls; }
      set
      {
        _showArrowControls = value;
        _btnLeft.Visible = value;
        _btnRight.Visible = value;
        if ( _calendarView == CalendarViews.Day )
          ResizeScrollPanel();
        Refresh();
      }
    }

    /// <summary>
    /// Indicates whether the calendar control should render the Today button
    /// </summary>
    public bool ShowTodayButton
    {
      get { return _showTodayButton; }
      set
      {
        _showTodayButton = value;
        _btnToday.Visible = value;
        if ( _calendarView == CalendarViews.Day )
          ResizeScrollPanel();
        Refresh();
      }
    }

    /// <summary>
    /// The font used to render the Today button
    /// </summary>
    public Font TodayFont
    {
      get { return _todayFont; }
      set
      {
        _todayFont = value;
        Refresh();
      }
    }

    /// <summary>
    /// The font used to render the number days on the calendar
    /// </summary>
    public Font DaysFont
    {
      get { return _daysFont; }
      set
      {
        _daysFont = value;
        Refresh();
      }
    }

    /// <summary>
    /// The font used to render the days of the week text
    /// </summary>
    public Font DayOfWeekFont
    {
      get { return _dayOfWeekFont; }
      set
      {
        _dayOfWeekFont = value;
        Refresh();
      }
    }

    /// <summary>
    /// The Date that the calendar is currently showing
    /// </summary>
    public DateTime CalendarDate
    {
      get { return _calendarDate; }
      set
      {
        if ( _calendarDate == value ) return;
        _calendarDate = value;
        Refresh();
      }
    }

    private readonly bool IsVisualStudioDesigner
      = System.IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath) == "devenv";

    /// <summary>
    /// Calendar Constructor
    /// </summary>
    public Calendar()
    {
      InitializeComponent();
      _calendarDate = DateTime.Now;
      _dayOfWeekFont = new Font("Arial", 10, FontStyle.Regular);
      _daysFont = new Font("Arial", 10, FontStyle.Regular);
      _todayFont = new Font("Arial", 10, FontStyle.Bold);
      _dateHeaderFont = new Font("Arial", 12, FontStyle.Bold);
      _dayViewTimeFont = new Font("Arial", 10, FontStyle.Bold);
      _showArrowControls = true;
      _showDateInHeader = true;
      _showTodayButton = true;
      _showingToolTip = false;
      _clickedEvent = null;
      _showDisabledEvents = false;
      _showDashedBorderOnDisabledEvents = true;
      _dimDisabledEvents = true;
      AllowEditingEvents = true;
      _highlightCurrentDay = true;
      _calendarView = CalendarViews.Month;
      _scrollPanel = new ScrollPanel();

      _scrollPanel.RightButtonClicked += ScrollPanelRightButtonClicked;

      TheEvents = new List<IEvent>();
      _rectangles = new List<Rectangle>();
      _calendarDays = new Dictionary<int, Point>();
      CalendarEvents = new List<CalendarEvent>();
      _showEventTooltips = true;
      _eventTip = new EventToolTip { Visible = false };

      Controls.Add(_eventTip);

      LoadPresetHolidays = true;

      _scrollPanel.Visible = false;
      Controls.Add(_scrollPanel);
    }

    private void InitializeComponent()
    {
      Container components;
      ToolStripMenuItem _miProperties;
      components = new System.ComponentModel.Container();
      _btnToday = new TodayButton();
      _btnLeft = new NavigateLeftButton();
      _btnRight = new NavigateRightButton();
      _contextMenuStrip = new ContextMenuStrip(components);
      _miProperties = new ToolStripMenuItem();
      _contextMenuStrip.SuspendLayout();
      SuspendLayout();
      // 
      // _btnToday
      // 
      _btnToday.BackColor = Color.Transparent;
      _btnToday.BorderColor = Color.FromArgb(220, 220, 220);
      _btnToday.ButtonColor = Color.FromArgb(243, 243, 243);
      _btnToday.ButtonFont = new Font("Arial", 8F, FontStyle.Bold);
      // ORDISOFTWARE MODIF BEGIN
      _btnToday.ButtonText = DesignMode || IsVisualStudioDesigner ? "Today" : AppTranslations.Today.GetLang();
      // ORDISOFTWARE MODIF END
      _btnToday.FocusColor = Color.FromArgb(77, 144, 244);
      _btnToday.HighlightBorderColor = Color.FromArgb(198, 198, 198);
      _btnToday.HighlightButtonColor = Color.FromArgb(246, 246, 246);
      _btnToday.Location = new Point(19, 10);
      _btnToday.Name = "_btnToday";
      //_btnToday.Size = new Size(72, 29);
      _btnToday.TabIndex = 0;
      _btnToday.TextColor = ColorText;
      _btnToday.ButtonClicked += BtnTodayButtonClicked;
      // 
      // _btnLeft
      // 
      _btnLeft.BackColor = Color.Transparent;
      _btnLeft.BorderColor = Color.FromArgb(220, 220, 220);
      _btnLeft.ButtonColor = Color.FromArgb(243, 243, 243);
      _btnLeft.ButtonFont = new Font("Arial", 8F, FontStyle.Bold);
      _btnLeft.ButtonText = "<";
      _btnLeft.FocusColor = Color.FromArgb(77, 144, 254);
      _btnLeft.HighlightBorderColor = Color.FromArgb(198, 198, 198);
      _btnLeft.HighlightButtonColor = Color.FromArgb(246, 246, 246);
      _btnLeft.Location = new Point(98, 10);
      _btnLeft.Name = "_btnLeft";
      //_btnLeft.Size = new Size(42, 29);
      _btnLeft.TabIndex = 1;
      _btnLeft.TextColor = ColorText;
      _btnLeft.ButtonClicked += BtnLeftButtonClicked;
      // 
      // _btnRight
      // 
      _btnRight.BackColor = Color.Transparent;
      _btnRight.BorderColor = Color.FromArgb(220, 220, 220);
      _btnRight.ButtonColor = Color.FromArgb(243, 243, 243);
      _btnRight.ButtonFont = new Font("Arial", 8F, FontStyle.Bold);
      _btnRight.ButtonText = ">";
      _btnRight.FocusColor = Color.FromArgb(77, 144, 254);
      _btnRight.HighlightBorderColor = Color.FromArgb(198, 198, 198);
      _btnRight.HighlightButtonColor = Color.FromArgb(246, 246, 246);
      _btnRight.Location = new Point(138 + 5, 10);
      _btnRight.Name = "_btnRight";
      //_btnRight.Size = new Size(42, 29);
      _btnRight.TabIndex = 2;
      _btnRight.TextColor = ColorText;
      _btnRight.ButtonClicked += BtnRightButtonClicked;
      // 
      // _contextMenuStrip1
      // 
      _contextMenuStrip.Items.AddRange(new ToolStripItem[] {
            _miProperties});
      _contextMenuStrip.Name = "_contextMenuStrip1";
      _contextMenuStrip.Size = new Size(137, 26);
      // 
      // _miProperties
      // 
      _miProperties.Name = "_miProperties";
      _miProperties.Size = new Size(136, 22);
      _miProperties.Text = "Properties...";
      _miProperties.Click += MenuItemPropertiesClick;
      // 
      // Calendar
      // 
      Controls.Add(_btnRight);
      Controls.Add(_btnLeft);
      Controls.Add(_btnToday);
      Name = "Calendar";
      Size = new Size(512, 440);
      Load += CalendarLoad;
      Paint += CalendarPaint;
      MouseClick += CalendarMouseClick;
      MouseMove += CalendarMouseMove;
      Resize += CalendarResize;
      DoubleBuffered = true;
      _contextMenuStrip.ResumeLayout(false);
      ResumeLayout(false);

    }

    /// <summary>
    /// Adds an event to the calendar
    /// </summary>
    /// <param name="calendarEvent">The <see cref="IEvent"/> to add to the calendar</param>
    public void AddEvent(IEvent calendarEvent)
    {
      TheEvents.Add(calendarEvent);
      Refresh();
    }

    /// <summary>
    /// Removes an event from the calendar
    /// </summary>
    /// <param name="calendarEvent">The <see cref="IEvent"/> to remove to the calendar</param>
    public void RemoveEvent(IEvent calendarEvent)
    {
      TheEvents.Remove(calendarEvent);
      Refresh();
    }

    private void CalendarLoad(object sender, EventArgs e)
    {
      if ( Parent is not null )
        Parent.Resize += ParentResize;
      ResizeScrollPanel();
    }

    private void CalendarPaint(object sender, PaintEventArgs e)
    {
      if ( _showingToolTip )
        return;
      if ( _calendarView == CalendarViews.Month )
        RenderMonthCalendar(e);
      else
      if ( _calendarView == CalendarViews.Day )
        RenderDayCalendar(e);
    }

    [SuppressMessage("Minor Code Smell", "S1643:Strings should not be concatenated using '+' in a loop", Justification = "N/A")]
    private void CalendarMouseMove(object sender, MouseEventArgs e)
    {
      if ( !_showEventTooltips )
        return;

      int num = CalendarEvents.Count;
      for ( int i = 0; i < num; i++ )
      {
        var z = CalendarEvents[i];

        if ( ( z.EventArea.Contains(e.X, e.Y) && z.Event.TooltipEnabled && _calendarView == CalendarViews.Month ) ||
            ( _calendarView == CalendarViews.Day && z.EventArea.Contains(e.X, e.Y + _scrollPanel.ScrollOffset) && z.Event.TooltipEnabled ) )
        {
          _eventTip.ShouldRender = false;
          _showingToolTip = true;
          // ORDISOFTWARE MODIF BEGIN
          //_eventTip.EventToolTipText = z.Event.EventText;
          _eventTip.EventToolTipText = z.Event.ToolTipText;
          // ORDISOFTWARE MODIF END
          if ( !z.Event.IgnoreTimeComponent )
            _eventTip.EventToolTipText += "\n" + z.Event.Date.ToShortTimeString();
          _eventTip.Location = new Point(e.X + 5, e.Y - _eventTip.CalculateSize().Height);
          _eventTip.ShouldRender = true;
          _eventTip.Visible = true;

          _showingToolTip = false;
          return;
        }
      }

      _eventTip.Visible = false;
      _eventTip.ShouldRender = false;
    }

    private void ScrollPanelRightButtonClicked(object sender, MouseEventArgs e)
    {
      if ( AllowEditingEvents && _calendarView == CalendarViews.Day )
      {
        int num = CalendarEvents.Count;
        for ( int i = 0; i < num; i++ )
        {
          var z = CalendarEvents[i];

          if ( z.EventArea.Contains(e.X, e.Y + _scrollPanel.ScrollOffset) && !z.Event.ReadOnlyEvent )
          {
            _clickedEvent = z;
            _contextMenuStrip.Show(_scrollPanel, new Point(e.X, e.Y));
            _eventTip.Visible = false;
            _eventTip.ShouldRender = false;
            break;
          }
        }
      }
    }

    private void CalendarMouseClick(object sender, MouseEventArgs e)
    {
      if ( e.Button == MouseButtons.Right && AllowEditingEvents )
      {
        if ( _calendarView == CalendarViews.Month )
        {
          int num = CalendarEvents.Count;
          for ( int i = 0; i < num; i++ )
          {
            var z = CalendarEvents[i];

            if ( z.EventArea.Contains(e.X, e.Y) && !z.Event.ReadOnlyEvent )
            {
              _clickedEvent = z;
              _contextMenuStrip.Show(this, e.Location);
              _eventTip.Visible = false;
              _eventTip.ShouldRender = false;
              break;
            }
          }
        }
      }
    }

    private void BtnTodayButtonClicked(object sender)
    {
      _calendarDate = DateTime.Now;
      Refresh();
      // ORDISOFTWARE MODIF BEGIN
      CalendarDateChanged(_calendarDate);
      // ORDISOFTWARE MODIF END
    }

    private void BtnLeftButtonClicked(object sender)
    {
      if ( _calendarView == CalendarViews.Month )
        _calendarDate = _calendarDate.AddMonths(-1);
      else
      if ( _calendarView == CalendarViews.Day )
        _calendarDate = _calendarDate.AddDays(-1);
      Refresh();
      // ORDISOFTWARE MODIF BEGIN
      CalendarDateChanged(_calendarDate);
      // ORDISOFTWARE MODIF END
    }

    private void BtnRightButtonClicked(object sender)
    {
      if ( _calendarView == CalendarViews.Day )
        _calendarDate = _calendarDate.AddDays(1);
      else if ( _calendarView == CalendarViews.Month )
        _calendarDate = _calendarDate.AddMonths(1);
      Refresh();
      // ORDISOFTWARE MODIF BEGIN
      CalendarDateChanged(_calendarDate);
      // ORDISOFTWARE MODIF END
    }

    private void MenuItemPropertiesClick(object sender, EventArgs e)
    {
      if ( _clickedEvent is null )
        return;

      var ed = new EventDetails { Event = _clickedEvent.Event };

      if ( ed.ShowDialog(this) == DialogResult.OK )
      {
        TheEvents.Remove(_clickedEvent.Event);
        TheEvents.Add(ed.NewEvent);
        Refresh();
      }
      _clickedEvent = null;
    }

    private void ParentResize(object sender, EventArgs e)
    {
      ResizeScrollPanel();
      Refresh();
    }

    private void PresetHolidays()
    {
      var aprilFools = new HolidayEvent
      {
        Date = new DateTime(DateTime.Now.Year, 4, 1),
        RecurringFrequency = RecurringFrequencies.Yearly,
        EventText = "April Fools Day"
      };
      AddEvent(aprilFools);

      var memorialDay = new HolidayEvent
      {
        Date = new DateTime(DateTime.Now.Year, 5, 28),
        RecurringFrequency = RecurringFrequencies.Custom,
        EventText = "Memorial Day",
        CustomRecurringFunction = MemorialDayHandler
      };
      AddEvent(memorialDay);

      var newYears = new HolidayEvent
      {
        Date = new DateTime(DateTime.Now.Year, 1, 1),
        RecurringFrequency = RecurringFrequencies.Yearly,
        EventText = "New Years Day"
      };
      AddEvent(newYears);

      var mlkDay = new HolidayEvent
      {
        Date = new DateTime(DateTime.Now.Year, 1, 15),
        RecurringFrequency = RecurringFrequencies.Custom,
        EventText = "Martin Luther King Jr. Day",
        CustomRecurringFunction = MlkDayHandler
      };
      AddEvent(mlkDay);

      var presidentsDay = new HolidayEvent
      {
        Date = new DateTime(DateTime.Now.Year, 2, 15),
        RecurringFrequency = RecurringFrequencies.Custom,
        EventText = "President's Day",
        CustomRecurringFunction = MlkDayHandler
      };
      AddEvent(presidentsDay);

      var independanceDay = new HolidayEvent
      {
        Date = new DateTime(DateTime.Now.Year, 7, 4),
        RecurringFrequency = RecurringFrequencies.Yearly,
        EventText = "Independence Day"
      };
      AddEvent(independanceDay);

      var laborDay = new HolidayEvent
      {
        Date = new DateTime(DateTime.Now.Year, 9, 1),
        RecurringFrequency = RecurringFrequencies.Custom,
        EventText = "Labor Day",
        CustomRecurringFunction = LaborDayHandler
      };
      AddEvent(laborDay);

      var columbusDay = new HolidayEvent
      {
        Date = new DateTime(DateTime.Now.Year, 10, 14),
        RecurringFrequency = RecurringFrequencies.Custom,
        EventText = "Columbus Day",
        CustomRecurringFunction = ColumbusDayHandler
      };
      AddEvent(columbusDay);

      var veteransDay = new HolidayEvent
      {
        Date = new DateTime(DateTime.Now.Year, 11, 11),
        RecurringFrequency = RecurringFrequencies.Yearly,
        EventText = "Veteran's Day"
      };
      AddEvent(veteransDay);

      var thanksgivingDay = new HolidayEvent
      {
        Date = new DateTime(DateTime.Now.Year, 11, 11),
        RecurringFrequency = RecurringFrequencies.Custom,
        EventText = "Thanksgiving Day",
        CustomRecurringFunction = ThanksgivingDayHandler
      };
      AddEvent(thanksgivingDay);

      var christmas = new HolidayEvent
      {
        Date = new DateTime(DateTime.Now.Year, 12, 25),
        RecurringFrequency = RecurringFrequencies.Yearly,
        EventText = "Christmas Day"
      };
      AddEvent(christmas);
    }

    [CustomRecurring("Thanksgiving Day Handler", "Selects the fourth Thursday in the month")]
    private bool ThanksgivingDayHandler(IEvent evnt, DateTime dt)
    {
      return dt.DayOfWeek == DayOfWeek.Thursday && dt.Day > 21 && dt.Day <= 28 && dt.Month == evnt.Date.Month;
    }

    [CustomRecurring("Columbus Day Handler", "Selects the second Monday in the month")]
    private bool ColumbusDayHandler(IEvent evnt, DateTime dt)
    {
      return dt.DayOfWeek == DayOfWeek.Monday && dt.Day > 7 && dt.Day <= 14 && dt.Month == evnt.Date.Month;
    }

    [CustomRecurring("Labor Day Handler", "Selects the first Monday in the month")]
    private bool LaborDayHandler(IEvent evnt, DateTime dt)
    {
      return dt.DayOfWeek == DayOfWeek.Monday && dt.Day <= 7 && dt.Month == evnt.Date.Month;
    }

    [CustomRecurring("Martin Luther King Jr. Day Handler", "Selects the third Monday in the month")]
    private bool MlkDayHandler(IEvent evnt, DateTime dt)
    {
      return dt.DayOfWeek == DayOfWeek.Monday && dt.Day > 14 && dt.Day <= 21 && dt.Month == evnt.Date.Month;
    }

    [CustomRecurring("Memorial Day Handler", "Selects the last Monday in the month")]
    private bool MemorialDayHandler(IEvent evnt, DateTime dt)
    {
      DateTime dt2 = LastDayOfWeekInMonth(dt, DayOfWeek.Monday);
      return dt.Month == evnt.Date.Month && dt2.Day == dt.Date.Day;
    }

    static private DateTime LastDayOfWeekInMonth(DateTime day, DayOfWeek dow)
    {
      DateTime lastDay = new DateTime(day.Year, day.Month, 1).AddMonths(1).AddDays(-1);
      DayOfWeek lastDow = lastDay.DayOfWeek;

      int diff = dow - lastDow;

      if ( diff > 0 ) diff -= 7;

      System.Diagnostics.Debug.Assert(diff <= 0);

      return lastDay.AddDays(diff);
    }

    //private int Max(params float[] value)
    //{
    //  return (int)value.Max(i => Math.Ceiling(i));
    //}

    static private bool DayForward(IEvent evnt, DateTime day)
    {
      if ( evnt.ThisDayForwardOnly )
      {
        int c = DateTime.Compare(day, evnt.Date);

        return c >= 0;
      }

      return true;
    }

    internal Bitmap RequestImage()
    {
      const int cellHourWidth = 60;
      const int cellHourHeight = 30;
      var bmp = new Bitmap(ClientSize.Width, cellHourWidth * 24);
      Graphics g = Graphics.FromImage(bmp);
      g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

      var dt = new DateTime(_calendarDate.Year, _calendarDate.Month, _calendarDate.Day, 0, 0, 0);
      int xStart = 0;
      int yStart = 0;

      g.DrawRectangle(PenText, 0, 0, ClientSize.Width - MarginSize * 2 - 2, cellHourHeight * 24);
      for ( int i = 0; i < 24; i++ )
      {
        var textWidth = (int)g.MeasureString(dt.ToString("htt").ToLower(), _dayViewTimeFont).Width;
        g.DrawRectangle(PenText, xStart, yStart, cellHourWidth, cellHourHeight);
        g.DrawLine(PenText, xStart + cellHourWidth, yStart + cellHourHeight,
                   ClientSize.Width - MarginSize * 2 - 3, yStart + cellHourHeight);
        g.DrawLine(PenTextReduced, xStart + cellHourWidth, yStart + cellHourHeight / 2,
                   ClientSize.Width - MarginSize * 2 - 3, yStart + cellHourHeight / 2);

        g.DrawString(dt.ToString("htt").ToLower(), _dayViewTimeFont, BrushText, xStart + cellHourWidth - textWidth, yStart);
        yStart += cellHourHeight;
        dt = dt.AddHours(1);
      }

      dt = new DateTime(_calendarDate.Year, _calendarDate.Month, _calendarDate.Day, 23, 59, 0);

      List<IEvent> evnts = TheEvents.Where(evnt => NeedsRendering(evnt, dt)).OrderBy(d => d.Date).ToList();

      xStart = cellHourWidth + 1;
      yStart = 0;

      g.Clip = new Region(new Rectangle(0, 0, ClientSize.Width - MarginSize * 2 - 2, cellHourHeight * 24));
      CalendarEvents.Clear();
      for ( int i = 0; i < 24; i++ )
      {
        dt = new DateTime(_calendarDate.Year, _calendarDate.Month, _calendarDate.Day, 0, 0, 0);
        dt = dt.AddHours(i);
        foreach ( var evnt in evnts )
        {
          TimeSpan ts = TimeSpan.FromHours(evnt.EventLengthInHours);

          if ( evnt.Date.Ticks >= dt.Ticks && evnt.Date.Ticks < dt.Add(ts).Ticks && evnt.EventLengthInHours > 0 && i >= evnt.Date.Hour )
          {
            int divisor = evnt.Date.Minute == 0 ? 1 : 60 / evnt.Date.Minute;
            Color clr = Color.FromArgb(175, evnt.EventColor.R, evnt.EventColor.G, evnt.EventColor.B);
            g.FillRectangle(new SolidBrush(GetFinalBackColor()), xStart, yStart + cellHourHeight / divisor + 1, ClientSize.Width - MarginSize * 2 - cellHourWidth - 3, cellHourHeight * ts.Hours - 1);
            g.FillRectangle(new SolidBrush(clr), xStart, yStart + cellHourHeight / divisor + 1, ClientSize.Width - MarginSize * 2 - cellHourWidth - 3, cellHourHeight * ts.Hours - 1);
            g.DrawString(evnt.EventText, evnt.EventFont, new SolidBrush(evnt.EventTextColor), xStart, yStart + cellHourHeight / divisor);

            var ce = new CalendarEvent
            {
              Event = evnt,
              Date = dt,
              EventArea = new Rectangle(xStart, yStart + cellHourHeight / divisor + 1,
                                                       ClientSize.Width - MarginSize * 2 - cellHourWidth - 3,
                                                       cellHourHeight * ts.Hours)
            };
            CalendarEvents.Add(ce);
          }
        }
        yStart += cellHourHeight;
      }

      g.Dispose();
      return bmp;
    }

    private Color GetFinalBackColor()
    {
      Control c = this;

      while ( c is not null )
      {
        if ( c.BackColor != Color.Transparent )
          return c.BackColor;
        c = c.Parent;
      }

      return Color.Transparent;
    }

    private void ResizeScrollPanel()
    {
      int controlsSpacing = ( ( !_showTodayButton ) && ( !_showDateInHeader ) && ( !_showArrowControls ) ) ? 0 : 30;

      _scrollPanel.Location = new Point(MarginSize, MarginSize + controlsSpacing);
      _scrollPanel.Size = new Size(ClientSize.Width - MarginSize * 2 - 1, ClientSize.Height - MarginSize - 1 - controlsSpacing);
    }

    private void RenderDayCalendar(PaintEventArgs e)
    {
      if ( _showDateInHeader )
      {
        Graphics g = e.Graphics;

        SizeF dateHeaderSize = g.MeasureString(
            $"{_calendarDate:MMMM} {_calendarDate.Day.ToString(CultureInfo.InvariantCulture)}" +
            $", {_calendarDate.Year.ToString(CultureInfo.InvariantCulture)}",
            DateHeaderFont);

        g.DrawString(
            $"{_calendarDate:MMMM} {_calendarDate.Day.ToString(CultureInfo.InvariantCulture)}" +
            $", {_calendarDate.Year.ToString(CultureInfo.InvariantCulture)}",
            _dateHeaderFont, BrushText,
            ClientSize.Width - MarginSize - dateHeaderSize.Width,
            MarginSize);
      }
    }

    private string MonthWithDayText;

    private void RenderMonthCalendar(PaintEventArgs e)
    {
      if ( IsVisualStudioDesigner ) return;
      if ( !Globals.IsReady ) return;
      bool isPrinting = Globals.IsPrinting;
      bool useColors = Program.Settings.UseColors;
      bool useHoverEffect = Program.Settings.CalendarUseHoverEffect;
      bool showSelectedox = Program.Settings.CalendarShowSelectedBox;
      bool selectedBoxOnlyCurrent = Program.Settings.SelectedDayBoxColorOnlyCurrent;
      _calendarDays.Clear();
      CalendarEvents.Clear();
      var bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
      Graphics g = Graphics.FromImage(bmp);
      e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
      g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
      SizeF sunSize = g.MeasureString("Sun", _dayOfWeekFont);
      // ORDISOFWTARE MODIF BEGIN
      var today = DateTime.Today;
      string monthText = _calendarDate.ToString("MMMM").Titleize();
      if ( isPrinting )
        MonthWithDayText = monthText;
      else
      if ( MainForm.Instance.CurrentDay is not null )
        MonthWithDayText = $"{MainForm.Instance.CurrentDay.Date.Day} {monthText}";
      else
      if ( !MainForm.Instance.PreferencesMutex )
        MonthWithDayText = $"{today.Day} {monthText}";
      int daysinmonth = DateTime.DaysInMonth(_calendarDate.Year, _calendarDate.Month);
      SizeF monSize = sunSize;// g.MeasureString("Mon", _dayOfWeekFont);
      SizeF tueSize = sunSize;// g.MeasureString("Tue", _dayOfWeekFont);
      SizeF wedSize = sunSize;// g.MeasureString("Wed", _dayOfWeekFont);
      SizeF thuSize = sunSize;// g.MeasureString("Thu", _dayOfWeekFont);
      SizeF friSize = sunSize;// g.MeasureString("Fri", _dayOfWeekFont);
      SizeF satSize = sunSize;// g.MeasureString("Sat", _dayOfWeekFont);
      int headerSpacing = (int)sunSize.Height + 5;// Max(sunSize.Height, monSize.Height, tueSize.Height, wedSize.Height, thuSize.Height, friSize.Height, satSize.Height) + 5;
      int controlsSpacing = ( ( !_showTodayButton ) && ( !_showDateInHeader ) && ( !_showArrowControls ) ) ? 0 : 30;
      //int numWeeks = NumberOfWeeks(_calendarDate.Year, _calendarDate.Month);
      int xStart = MarginSize;
      int yStart = MarginSize;
      var startWeekEnum = DesignMode ? DayOfWeek.Saturday : DayOfWeekMap.Position[(DayOfWeek)Program.Settings.ShabatDay][(int)new DateTime(_calendarDate.Year, _calendarDate.Month, 1).DayOfWeek];
      int startWeek = ( (int)startWeekEnum ) + 1;
      int rogueDays = startWeek - 1;
      var value = (float)( daysinmonth + rogueDays ) / 7;
      int numWeeks = (int)value < value ? (int)value + 1 : (int)value;
      int cellWidth = ( ClientSize.Width - MarginSize * 2 ) / 7;
      int cellHeight = ( ClientSize.Height - MarginSize * 2 - headerSpacing - controlsSpacing ) / numWeeks;
      var brushBack = new SolidBrush(BackColor);
      var outOfMonth = false;
      var isSelected = false;
      var isSelectedNoToday = false;
      int selectedDay;
      int selectedMonth;
      int selectedYear;
      if ( MainForm.Instance.DateSelected is not null )
      {
        var date = MainForm.Instance.DateSelected.Value;
        selectedDay = date.Day;
        selectedMonth = date.Month;
        selectedYear = date.Year;
      }
      else
      {
        selectedDay = today.Day;
        selectedMonth = today.Month;
        selectedYear = today.Year;
      }
      bool CheckSelected(int day)
        => day == selectedDay && _calendarDate.Month == selectedMonth && _calendarDate.Year == selectedYear;
      // ORDISOFWTARE MODIF END

      yStart += headerSpacing + controlsSpacing;

      int counter1 = 1;
      int counter2 = 1;

      bool first = false;
      bool first2 = false;

      // ORDISOFWTARE MODIF BEGIN
      _btnToday.Location = new Point(MarginSize, MarginSize);
      _btnLeft.Location = new Point(MarginSize + _btnToday.Width + MarginSize, MarginSize);
      _btnRight.Location = new Point(MarginSize + _btnToday.Width + _btnLeft.Width + MarginSize + MarginSize / 2, MarginSize);
      // ORDISOFWTARE MODIF END

      for ( int y = 0; y < numWeeks; y++ )
      {
        for ( int x = 0; x < 7; x++ )
        {
          if ( rogueDays == 0 && counter1 <= daysinmonth )
          {
            // ORDISOFTWARE MODIF BEGIN
            if ( MainForm.Instance is not null )
              if ( useColors )
              {
                var brush = MainForm.Instance.GetDayBrush(counter1, _calendarDate.Month, _calendarDate.Year);
                if ( brush is not null && brush != Brushes.Transparent )
                  g.FillRectangle(brush, xStart + 1, yStart + 1, cellWidth - 1, cellHeight - 1);
              }
            // ORDISOFTWARE MODIF END

            if ( !_calendarDays.ContainsKey(counter1) )
              _calendarDays.Add(counter1, new Point(xStart, (int)( yStart + 2f + g.MeasureString(counter1.ToString(CultureInfo.InvariantCulture), _daysFont).Height )));

            if ( _calendarDate.Year == DateTime.Now.Year && _calendarDate.Month == DateTime.Now.Month && counter1 == DateTime.Now.Day && _highlightCurrentDay )
              g.FillRectangle(BrushGrayLight, xStart, yStart, cellWidth, cellHeight);

            if ( !first )
            {
              first = true;
              string strCounter1 = $"{monthText} {counter1.ToString(CultureInfo.InvariantCulture)}";
              if ( _calendarDate.Year == DateTime.Now.Year && _calendarDate.Month == DateTime.Now.Month && counter1 == DateTime.Now.Day )
              {
                //ORDISOFTWARE MODIF BEGIN FIRST DAY OF MONTH ACTUAL DAY
                if ( !isPrinting )
                {
                  SizeF stringSize = g.MeasureString(strCounter1, _todayFont);
                  if ( useColors )
                  {
                    if ( CheckSelected(counter1) && !isPrinting )
                    {
                      isSelected = true;
                      g.FillRectangle(CurrentDayBackBrush, xStart + 5 - 1, yStart + 2 + 1, stringSize.Width + 4, stringSize.Height - 2);
                      g.DrawString(strCounter1, _todayFont, CurrentDayForeBrush, xStart + 5, yStart + 2);
                    }
                    else
                    {
                      var pen = useColors ? PenSelectedDay : PenBlack;
                      g.FillRectangle(brushBack, xStart + 5, yStart + 2 + 1, stringSize.Width + 4, stringSize.Height - 2);
                      g.DrawRectangle(pen, xStart + 5, yStart + 2 + 1, stringSize.Width + 4, stringSize.Height - 2);
                      g.DrawString(strCounter1, _todayFont, CurrentDayBackBrush, xStart + 5, yStart + 2);
                    }
                  }
                  else
                  {
                    if ( CheckSelected(counter1) && !isPrinting )
                    {
                      isSelected = true;
                      g.FillRectangle(BrushBlack, xStart + 5, yStart + 2 + 1, stringSize.Width + 4, stringSize.Height - 2);
                      g.DrawString(strCounter1, _todayFont, Brushes.White, xStart + 5, yStart + 2);
                    }
                    else
                    {
                      g.DrawRectangle(PenBlack, xStart + 5, yStart + 2 + 1, stringSize.Width + 4, stringSize.Height - 2);
                      g.DrawString(strCounter1, _todayFont, BrushText, xStart + 5, yStart + 2);
                    }
                  }
                }
                else
                  g.DrawString(strCounter1, _daysFont, BrushText, xStart + 5, yStart + 2);
                //ORDISOFTWARE MODIF END
              }
              else
              {
                //ORDISOFTWARE MODIF BEGIN FIRST DAY OF MONTH
                if ( CheckSelected(counter1) && !isPrinting )
                {
                  isSelected = true;
                  isSelectedNoToday = true;
                  SizeF stringSize = g.MeasureString(strCounter1, _daysFont);
                  var pen = useColors
                            ? selectedBoxOnlyCurrent ? PenText : PenSelectedDay
                            : PenBlack;
                  g.DrawRectangle(pen, xStart + 5 - 1, yStart + 2 + 1, stringSize.Width + 0, stringSize.Height - 2 - 2);
                }
                g.DrawString(strCounter1, _daysFont, BrushText, xStart + 5, yStart + 2);
                //ORDISOFTWARE MODIF END
              }
            }
            else
            {
              if ( _calendarDate.Year == DateTime.Now.Year && _calendarDate.Month == DateTime.Now.Month && counter1 == DateTime.Now.Day )
              {
                //ORDISOFTWARE MODIF BEGIN ACTUAL REAL DAY
                string strCounter1 = counter1.ToString(CultureInfo.InvariantCulture);
                if ( !isPrinting )
                {
                  SizeF stringSize = g.MeasureString(strCounter1, _todayFont);
                  if ( useColors )
                  {
                    if ( CheckSelected(counter1) )
                    {
                      isSelected = true;
                      g.FillRectangle(CurrentDayBackBrush, xStart + 5, yStart + 2 + 1, stringSize.Width + 1, stringSize.Height - 2);
                      g.DrawString(strCounter1, _todayFont, CurrentDayForeBrush, xStart + 5, yStart + 2);
                    }
                    else
                    {
                      g.FillRectangle(brushBack, xStart + 5, yStart + 2 + 1, stringSize.Width + 1, stringSize.Height - 2);
                      g.DrawRectangle(PenSelectedDay, xStart + 5, yStart + 2 + 1, stringSize.Width + 1, stringSize.Height - 2);
                      g.DrawString(strCounter1, _todayFont, CurrentDayBackBrush, xStart + 5, yStart + 2);
                    }
                  }
                  else
                  {
                    if ( CheckSelected(counter1) && !isPrinting )
                    {
                      isSelected = true;
                      g.FillRectangle(BrushBlack, xStart + 5, yStart + 2 + 1, stringSize.Width + 1, stringSize.Height - 2);
                      g.DrawString(strCounter1, _todayFont, Brushes.White, xStart + 5, yStart + 2);
                    }
                    else
                    {
                      g.DrawRectangle(PenBlack, xStart + 5, yStart + 2 + 1, stringSize.Width + 1, stringSize.Height - 2);
                      g.DrawString(strCounter1, _todayFont, BrushText, xStart + 5, yStart + 2);
                    }
                  }
                }
                else
                  g.DrawString(strCounter1, _daysFont, BrushText, xStart + 5, yStart + 2);
                //ORDISOFTWARE MODIF END
              }
              else
              {
                //ORDISOFTWARE MODIF BEGIN OTHER DAYS
                string strCounter1 = counter1.ToString(CultureInfo.InvariantCulture);
                if ( CheckSelected(counter1) && !isPrinting )
                {
                  SizeF stringSize = g.MeasureString(strCounter1, _daysFont);
                  isSelected = true;
                  isSelectedNoToday = true;
                  var pen = useColors
                            ? selectedBoxOnlyCurrent ? PenText : PenSelectedDay
                            : PenBlack;
                  g.DrawRectangle(pen, xStart + 5 - 1, yStart + 2 + 1, stringSize.Width + 0, stringSize.Height - 2 - 2);
                }
                g.DrawString(strCounter1, _daysFont, BrushText, xStart + 5, yStart + 2);
                //ORDISOFTWARE MODIF END
              }
            }
            var evDay = new CalendarEvent
            {
              EventArea = new Rectangle(xStart + 1, yStart + 1, cellWidth - 1, cellHeight - 1),
              Date = new DateTime(_calendarDate.Year, _calendarDate.Month, counter1)
            };
            CalendarEvents.Add(evDay);
            counter1++;
          }
          else if ( rogueDays > 0 )
          {
            int dm = DateTime.DaysInMonth(_calendarDate.AddMonths(-1).Year, _calendarDate.AddMonths(-1).Month) - rogueDays + 1;
            // ORDISOFWTARE MODIF BEGIN PREVIOUS MONTH
            outOfMonth = true;
            var evPrevious = new CalendarEvent
            {
              EventArea = new Rectangle(xStart + 1, yStart + 1, cellWidth - 1, cellHeight - 1),
              Date = new DateTime(_calendarDate.AddMonths(-1).Year, _calendarDate.AddMonths(-1).Month, dm)
            };
            CalendarEvents.Add(evPrevious);
            g.FillRectangle(RogueBrush, xStart + 1, yStart + 1, cellWidth - 1, cellHeight - 1);
            // ORDISOFWTARE MODIF END
            g.DrawString(dm.ToString(CultureInfo.InvariantCulture), _daysFont, BrushGrayMedium, xStart + 5, yStart + 2);
            rogueDays--;
          }

          g.DrawRectangle(PenTextReduced, xStart, yStart, cellWidth, cellHeight);

          if ( rogueDays == 0 && counter1 > daysinmonth )
          {
            if ( !first2 )
              first2 = true;
            else
            {
              if ( counter2 == 1 )
              {
                // ORDISOFWTARE MODIF BEGIN NEXT MONTH FIRST DAY
                outOfMonth = true;
                var evNextFirst = new CalendarEvent
                {
                  EventArea = new Rectangle(xStart + 1, yStart + 1, cellWidth - 1, cellHeight - 1),
                  Date = new DateTime(_calendarDate.AddMonths(1).Year, _calendarDate.AddMonths(1).Month, counter2)
                };
                CalendarEvents.Add(evNextFirst);
                g.FillRectangle(RogueBrush, xStart + 1, yStart + 1, cellWidth - 1, cellHeight - 1);
                // ORDISOFWTARE MODIF END
                g.DrawString($"{_calendarDate.AddMonths(1).ToString("MMMM").Titleize()} {counter2.ToString(CultureInfo.InvariantCulture)}", _daysFont, BrushGrayMedium, xStart + 5, yStart + 2);
              }
              else
              {
                // ORDISOFWTARE MODIF BEGIN NEXT MONTH OTHERS
                outOfMonth = true;
                var evNextOthers = new CalendarEvent
                {
                  EventArea = new Rectangle(xStart + 1, yStart + 1, cellWidth - 1, cellHeight - 1),
                  Date = new DateTime(_calendarDate.AddMonths(1).Year, _calendarDate.AddMonths(1).Month, counter2)
                };
                CalendarEvents.Add(evNextOthers);
                g.FillRectangle(RogueBrush, xStart + 1, yStart + 1, cellWidth - 1, cellHeight - 1);
                // ORDISOFWTARE MODIF END
                g.DrawString(counter2.ToString(CultureInfo.InvariantCulture), _daysFont, BrushGrayMedium, xStart + 5, yStart + 2);
              }
              counter2++;
            }
          }

          // ORDISOFWTARE MODIF BEGIN
          if ( !isPrinting )
          {
            bool isactiveday = counter1 - 1 == _calendarDate.Day;
            bool isMouseHover = false;
            var area1 = new Rectangle(xStart + 1, yStart + 1, cellWidth - 2, cellHeight - 2);
            if ( useHoverEffect )
            {
              var mouse = PointToClient(Cursor.Position);
              isMouseHover = area1.Contains(mouse.X, mouse.Y);
            }
            var area2 = new Rectangle(xStart + 2, yStart + 2, cellWidth - 4, cellHeight - 4);
            if ( isSelected )
            {
              if ( showSelectedox )
              {
                var pen = useColors
                          ? isSelectedNoToday && selectedBoxOnlyCurrent
                            ? PenText
                            : PenSelectedDay
                          : PenBlack;
                g.DrawRectangle(pen, area1);
              }
              isSelectedNoToday = false;
              if ( isMouseHover && !outOfMonth )
              {
                if ( showSelectedox )
                  g.DrawRectangle(PenHoverEffect, area2);
                else
                  g.DrawRectangle(PenHoverEffect, area1);
                isMouseHover = false;
              }
            }
            else
            {
              if ( useHoverEffect && ( isSelected || ( isMouseHover && !outOfMonth ) ) )
                if ( counter1 - 1 == today.Day && isactiveday )
                  g.DrawRectangle(PenHoverEffect, area2);
                else
                if ( isactiveday )
                  g.DrawRectangle(PenHoverEffect, area2);
                else
                  g.DrawRectangle(PenHoverEffect, area1);
            }
            if ( !isSelected && !outOfMonth && isactiveday )
              g.DrawRectangle(PenActiveDay, area1);
            isSelected = false;
            outOfMonth = false;
          }
          // ORDISOFWTARE MODIF END

          xStart += cellWidth;
        }
        xStart = MarginSize;
        yStart += cellHeight;
      }
      xStart = MarginSize + ( ( cellWidth - (int)sunSize.Width ) / 2 );
      yStart = MarginSize + controlsSpacing;

      // ORDISOFTWARE MODIF BEGIN
      var daysofweek = DayOfWeekMap.LocalizedNamesText[Languages.Current][(DayOfWeek)Program.Settings.ShabatDay];

      g.DrawString(daysofweek[(int)DayOfWeek.Sunday], _dayOfWeekFont, BrushText, xStart, yStart);

      xStart = MarginSize + ( ( cellWidth - (int)monSize.Width ) / 2 ) + cellWidth;
      g.DrawString(daysofweek[(int)DayOfWeek.Monday], _dayOfWeekFont, BrushText, xStart, yStart);

      xStart = MarginSize + ( ( cellWidth - (int)tueSize.Width ) / 2 ) + cellWidth * 2;
      g.DrawString(daysofweek[(int)DayOfWeek.Tuesday], _dayOfWeekFont, BrushText, xStart, yStart);

      xStart = MarginSize + ( ( cellWidth - (int)wedSize.Width ) / 2 ) + cellWidth * 3;
      g.DrawString(daysofweek[(int)DayOfWeek.Wednesday], _dayOfWeekFont, BrushText, xStart, yStart);

      xStart = MarginSize + ( ( cellWidth - (int)thuSize.Width ) / 2 ) + cellWidth * 4;
      g.DrawString(daysofweek[(int)DayOfWeek.Thursday], _dayOfWeekFont, BrushText, xStart, yStart);

      xStart = MarginSize + ( ( cellWidth - (int)friSize.Width ) / 2 ) + cellWidth * 5;
      g.DrawString(daysofweek[(int)DayOfWeek.Friday], _dayOfWeekFont, BrushText, xStart, yStart);

      xStart = MarginSize + ( ( cellWidth - (int)satSize.Width ) / 2 ) + cellWidth * 6;
      g.DrawString(daysofweek[(int)DayOfWeek.Saturday], _dayOfWeekFont, BrushText, xStart, yStart);
      // ORDISOFTWARE MODIF END

      if ( _showDateInHeader )
      {
        SizeF dateHeaderSize = g.MeasureString($"{MonthWithDayText} {_calendarDate.Year.ToString(CultureInfo.InvariantCulture)}", _dateHeaderFont);
        g.DrawString($"{MonthWithDayText} {_calendarDate.Year.ToString(CultureInfo.InvariantCulture)}", _dateHeaderFont, BrushText, ClientSize.Width - MarginSize - dateHeaderSize.Width, MarginSize);
      }

      // ORDISOFTWARE MODIF BEGIN
      //_events.Sort(new EventComparer());
      // ORDISOFTWARE MODIF END
      for ( int i = 1; i <= daysinmonth; i++ )
      {
        int renderOffsetY = -3 + Program.Settings.CalendarLineSpacing;

        // ORDISOFTWARE MODIF BEGIN
        //var dt = new DateTime(_calendarDate.Year, _calendarDate.Month, i, 23, 59, _calendarDate.Second);
        var dt = new DateTime(_calendarDate.Year, _calendarDate.Month, i, 00, 00, 0);
        var list = TheEvents.Where(ev => ev.Date == dt /*&& ( ev.Enabled || _showDisabledEvents )*/).ToArray();
        int countEvents = list.Length;
        int countEventsPrev = list.Length - 1;
        if ( countEvents == 0 ) continue;
        int deltaLine = -5 + Program.Settings.CalendarLineSpacing;
        SizeF sz = g.MeasureString(list[0].EventText, list[0].EventFont);
        for ( int index = 0; index < countEvents; index++ )
        //foreach ( IEvent v in _events )
        {
          var v = list[index];
          if ( DayForward(v, dt) )
          //if ( NeedsRendering(v, dt) )
          {
            int alpha = !v.Enabled && _dimDisabledEvents ? alpha = 64 : 255;
            Color alphaColor = Color.FromArgb(alpha, v.EventColor.R, v.EventColor.G, v.EventColor.B);

            int offsetY = renderOffsetY;
            Region r = g.Clip;
            if ( i > _calendarDays.Count ) continue;

            Point point = _calendarDays[i];
            int yy = point.Y - 1;

            //int xx = ( ( cellWidth - (int)sz.Width ) / 2 ) + point.X;
            int xx = point.X + 5;
            //if ( sz.Width > cellWidth ) xx = point.X;

            if ( renderOffsetY + sz.Height + sz.Height + sz.Height > cellHeight - 2 && index != countEventsPrev )
            {
              g.DrawString("...", new Font(v.EventFont, FontStyle.Bold), new SolidBrush(v.EventTextColor), xx, yy + offsetY);
              break;
            }

            int pointYoffsetY = point.Y + offsetY;

            g.Clip = new Region(new Rectangle(point.X + 1, pointYoffsetY, cellWidth - 1, (int)sz.Height));
            g.FillRectangle(new SolidBrush(alphaColor), point.X + 3, pointYoffsetY, cellWidth - 5, sz.Height);

            if ( !v.Enabled && _showDashedBorderOnDisabledEvents )
              g.DrawRectangle(PenBlack, point.X + 1, pointYoffsetY, cellWidth - 2, sz.Height - 1);

            g.DrawString(v.EventText, v.EventFont, new SolidBrush(v.EventTextColor), xx, yy + offsetY);
            g.Clip = r;

            /*if ( generateSunToolTips )
            {
              var ev = new CalendarEvent
              {
                EventArea = new Rectangle(point.X + 1, pointYoffsetY, cellWidth - 1, (int)sz.Height),
                Event = v,
                Date = dt
              };
              _calendarEvents.Add(ev);
            }*/
            renderOffsetY += (int)sz.Height + deltaLine;
          }
        }
        // ORDISOFTWARE MODIF END
      }

      _rectangles.Clear();
      g.Dispose();
      e.Graphics.DrawImage(bmp, 0, 0, ClientSize.Width, ClientSize.Height);
      bmp.Dispose();
    }

    private bool NeedsRendering(IEvent evnt, DateTime day)
    {
      if ( !evnt.Enabled && !_showDisabledEvents ) return false;
      DayOfWeek dw = evnt.Date.DayOfWeek;
      if ( evnt.RecurringFrequency == RecurringFrequencies.Daily )
        return DayForward(evnt, day);
      if ( evnt.RecurringFrequency == RecurringFrequencies.Weekly && day.DayOfWeek == dw )
        return DayForward(evnt, day);
      if ( evnt.RecurringFrequency == RecurringFrequencies.EveryWeekend && ( day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday ) )
        return DayForward(evnt, day);
      if ( evnt.RecurringFrequency == RecurringFrequencies.EveryMonWedFri && ( day.DayOfWeek == DayOfWeek.Monday || day.DayOfWeek == DayOfWeek.Wednesday || day.DayOfWeek == DayOfWeek.Friday ) )
        return DayForward(evnt, day);
      if ( evnt.RecurringFrequency == RecurringFrequencies.EveryTueThurs && ( day.DayOfWeek == DayOfWeek.Thursday || day.DayOfWeek == DayOfWeek.Tuesday ) )
        return DayForward(evnt, day);
      if ( evnt.RecurringFrequency == RecurringFrequencies.EveryWeekday && ( day.DayOfWeek != DayOfWeek.Sunday && day.DayOfWeek != DayOfWeek.Saturday ) )
        return DayForward(evnt, day);
      if ( evnt.RecurringFrequency == RecurringFrequencies.Yearly && evnt.Date.Month == day.Month && evnt.Date.Day == day.Day )
        return DayForward(evnt, day);
      if ( evnt.RecurringFrequency == RecurringFrequencies.Monthly && evnt.Date.Day == day.Day )
        return DayForward(evnt, day);
      if ( evnt.RecurringFrequency == RecurringFrequencies.Custom && evnt.CustomRecurringFunction is not null )
        if ( evnt.CustomRecurringFunction(evnt, day) )
          return DayForward(evnt, day);
        else
          return false;
      if ( evnt.RecurringFrequency == RecurringFrequencies.None && evnt.Date.Year == day.Year && evnt.Date.Month == day.Month && evnt.Date.Day == day.Day )
        return DayForward(evnt, day);
      return false;
    }

    //private int NumberOfWeeks(int year, int month)
    //{
    //  return NumberOfWeeks(new DateTime(year, month, DateTime.DaysInMonth(year, month)));
    //}

    //private int NumberOfWeeks(DateTime date)
    //{
    //  var beginningOfMonth = new DateTime(date.Year, date.Month, 1);

    //  // ORDISOFTWARE MODIF BEGIN
    //  while ( date.Date.AddDays(1).DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek )
    //    //while ( date.Date.AddDays(1).DayOfWeek != (DayOfWeek)Program.Settings.ShabatDay )
    //    date = date.AddDays(1);
    //  //ORDISOFTWARE MODIF END

    //  return (int)Math.Truncate(date.Subtract(beginningOfMonth).TotalDays / 7f) + 1;
    //}

    private void CalendarResize(object sender, EventArgs e)
    {
      if ( _calendarView == CalendarViews.Day )
        ResizeScrollPanel();
    }
  }
}
