using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CodeProjectCalendar.NET
{
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP017:Prefer using", Justification = "<En attente>")]
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP004:Don't ignore created IDisposable", Justification = "<En attente>")]
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP007:Don't dispose injected", Justification = "N/A")]
  [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP008:Don't assign member with injected and created disposables", Justification = "N/A")]
  [SuppressMessage("Design", "GCop132:Since the type is inferred, use 'var' instead", Justification = "<En attente>")]
  internal partial class EventToolTip : UserControl
  {
    private Color _eventToolTipColor;
    private Color _eventToolTipTextColor;
    private Color _eventToolTipBorderColor;
    private Font _eventToolTipFont;
    private bool _shouldRender;
    private string _eventToolTipText;
    private Margin _eventToolTipMargins;

    public Margin EventToolTipMargins
    {
      get { return _eventToolTipMargins; }
      set
      {
        _eventToolTipMargins = value;
        Refresh();
      }
    }

    public string EventToolTipText
    {
      get { return _eventToolTipText; }
      set
      {
        _eventToolTipText = value;
        Refresh();
      }
    }

    public bool ShouldRender
    {
      get { return _shouldRender; }
      set
      {
        _shouldRender = value;
        Refresh();
      }
    }

    public Font EventToolTipFont
    {
      get { return _eventToolTipFont; }
      set
      {
        _eventToolTipFont = value;
        Refresh();
      }
    }

    public Color EventToolTipBorderColor
    {
      get { return _eventToolTipBorderColor; }
      set
      {
        _eventToolTipBorderColor = value;
        Refresh();
      }
    }

    public Color EventToolTipTextColor
    {
      get { return _eventToolTipTextColor; }
      set
      {
        _eventToolTipTextColor = value;
        Refresh();
      }
    }

    public Color EventToolTipColor
    {
      get { return _eventToolTipColor; }
      set
      {
        _eventToolTipColor = value;
        Refresh();
      }
    }

    public EventToolTip()
    {
      InitializeComponent();

      _shouldRender = false;
      _eventToolTipBorderColor = Color.Black;
      // ORDISOFTWARE MODIF BEGIN
      //_eventToolTipColor = Color.Yellow;
      _eventToolTipColor = Color.LemonChiffon;
      // ORDISOFTWARE MODIF BEGIN
      //_eventToolTipFont = new Font("Arial", 10, FontStyle.Regular);
      _eventToolTipFont = new Font("Calibri", 10, FontStyle.Regular);
      // ORDISOFTWARE MODIF BEGIN
      _eventToolTipText = "";
      _eventToolTipTextColor = Color.Black;
      _eventToolTipMargins = new Margin { Top = 10, Right = 10, Bottom = 10, Left = 10 };
    }

    private void EventToolTipLoad(object sender, EventArgs e)
    {
      //
    }

    public Size CalculateSize()
    {
      Graphics g = CreateGraphics();

      SizeF textSize = g.MeasureString(_eventToolTipText, _eventToolTipFont);

      Size = new Size((int)textSize.Width + _eventToolTipMargins.Left + _eventToolTipMargins.Right,
                                     (int)textSize.Height + _eventToolTipMargins.Top + _eventToolTipMargins.Bottom);

      g.Dispose();
      return Size;
    }

    private void EventToolTipPaint(object sender, PaintEventArgs e)
    {
      if ( !_shouldRender )
        return;

      SizeF textSize = e.Graphics.MeasureString(_eventToolTipText, _eventToolTipFont);

      Size = new Size((int)textSize.Width + _eventToolTipMargins.Left + _eventToolTipMargins.Right,
                                     (int)textSize.Height + _eventToolTipMargins.Top + _eventToolTipMargins.Bottom);

      var bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
      Graphics g = Graphics.FromImage(bmp);
      GraphicsPath gp = RoundedRectangle.Create(0, 0, ClientSize.Width - 1, ClientSize.Height - 1, 5,
                                                RoundedRectangle.RectangleCorners.All);

      BackColor = Color.Transparent;
      g.FillPath(new SolidBrush(_eventToolTipColor), gp);
      g.DrawPath(new Pen(_eventToolTipBorderColor), gp);

      int totHorMargin = _eventToolTipMargins.Left + _eventToolTipMargins.Right;
      int totVerMargin = _eventToolTipMargins.Top + _eventToolTipMargins.Bottom;

      g.DrawString(_eventToolTipText, _eventToolTipFont, new SolidBrush(_eventToolTipTextColor),
                   ( ClientSize.Width - textSize.Width + totHorMargin ) / 2f - _eventToolTipMargins.Right,
                   ( ClientSize.Height - textSize.Height + totVerMargin ) / 2f - _eventToolTipMargins.Bottom - 1);


      e.Graphics.DrawImage(bmp, 0, 0);
      gp.Dispose();
      g.Dispose();
      bmp.Dispose();
    }
  }

  internal class Margin
  {
    public int Left
    {
      get;
      set;
    }

    public int Right
    {
      get;
      set;
    }

    public int Top
    {
      get;
      set;
    }

    public int Bottom
    {
      get;
      set;
    }
  }
}
