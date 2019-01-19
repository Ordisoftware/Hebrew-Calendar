using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Calendar.NET
{
    internal partial class CoolButton : UserControl
    {
        private Color _buttonColor;
        private Color _textColor;
        private Color _focusColor;
        private Color _borderColor;
        private Color _highlightBorderColor;
        private Color _highlightButtonColor;
        private Font _buttonFont;
        private string _buttonText;
        private bool _mouseOver;
        private bool _mouseDown;

        public delegate void ButtonClickedArgs(object sender);

        public event ButtonClickedArgs ButtonClicked;

        public Color FocusColor
        {
            get { return _focusColor; }
            set
            {
                _focusColor = value;
                Refresh();
            }
        }

        public Color TextColor
        {
            get { return _textColor; }
            set
            {
                _textColor = value;
                Refresh();
            }
        }

        public Color HighlightBorderColor
        {
            get { return _highlightBorderColor; }
            set
            {
                _highlightBorderColor = value;
                Refresh();
            }
        }

        public Color HighlightButtonColor
        {
            get { return _highlightButtonColor; }
            set
            {
                _highlightButtonColor = value;
                Refresh();
            }
        }

        public string ButtonText
        {
            get { return _buttonText; }
            set
            {
                _buttonText = value;
                Refresh();
            }
        }

        public Font ButtonFont
        {
            get { return _buttonFont; }
            set
            {
                _buttonFont = value;
                Refresh();
            }
        }

        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Refresh();
            }
        }

        public Color ButtonColor
        {
            get { return _buttonColor; }
            set
            {
                _buttonColor = value;
                Refresh();
            }
        }

        public CoolButton()
        {
            InitializeComponent();

            _buttonColor = Color.FromArgb(243, 243, 243);
            _borderColor = Color.FromArgb(220, 220, 220);
            _highlightBorderColor = Color.FromArgb(198, 198, 198);
            _highlightButtonColor = Color.FromArgb(246, 246, 246);
            _focusColor = Color.FromArgb(77, 144, 254);
            _buttonFont = new Font("Arial", 8, FontStyle.Bold);
            _buttonText = "button";
            _textColor = Color.Black;

            _mouseOver = false;
            _mouseDown = false;

            LostFocus += CoolButtonFocus;
            GotFocus += CoolButtonFocus;
        }

        void CoolButtonFocus(object sender, EventArgs e)
        {
            Refresh();
        }

        private void CoolButtonLoad(object sender, EventArgs e)
        {

        }

        private void CoolButtonPaint(object sender, PaintEventArgs e)
        {
            var bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
            Graphics g = Graphics.FromImage(bmp);

            if (!_mouseOver)
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                GraphicsPath path = RoundedRectangle.Create(0, 0, ClientSize.Width - 4, ClientSize.Height - 4);
                SizeF fontSize = g.MeasureString(_buttonText, _buttonFont);
                int horWidth = ((ClientSize.Width - 4 - (int)fontSize.Width) / 2);
                int verHeight = ((ClientSize.Height - 4 - (int)fontSize.Height) / 2);

                g.FillPath(new SolidBrush(_buttonColor), path);
                g.DrawPath(Focused ? new Pen(_focusColor) : new Pen(_borderColor), path);
                g.DrawString(_buttonText, _buttonFont, new SolidBrush(_textColor), horWidth, verHeight);
            }
            else
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                GraphicsPath path = RoundedRectangle.Create(0, 0, ClientSize.Width - 4, ClientSize.Height - 4);
                SizeF fontSize = g.MeasureString(_buttonText, _buttonFont);
                int horWidth = ((ClientSize.Width - 4 - (int)fontSize.Width) / 2);
                int verHeight = ((ClientSize.Height - 4 - (int)fontSize.Height) / 2);

                g.FillPath(new SolidBrush(_highlightButtonColor), path);
                g.DrawPath(ContainsFocus ? new Pen(_focusColor) : new Pen(_borderColor), path);
                g.DrawString(_buttonText, _buttonFont, new SolidBrush(_textColor), horWidth, verHeight);

                Color a1 = Color.FromArgb(255, 198, 198, 198);
                Color a2 = Color.FromArgb(128, 198, 198, 198);
                Color a3 = Color.FromArgb(64, 198, 198, 198);

                var shadowBmp = new Bitmap(1, 3);
                var shadowBmp2 = new Bitmap(3, 1);
                shadowBmp.SetPixel(0, 0, a1);
                shadowBmp.SetPixel(0, 1, a2);
                shadowBmp.SetPixel(0, 2, a3);

                shadowBmp2.SetPixel(0, 0, a1);
                shadowBmp2.SetPixel(1, 0, a2);
                shadowBmp2.SetPixel(2, 0, a3);

                for (int z = 4; z < ClientSize.Width - 4; z++)
                {
                    g.DrawImage(shadowBmp, z, ClientSize.Height - 4, 1, 3);
                }
                for (int z = 4; z < ClientSize.Height - 4; z++)
                {
                    g.DrawImage(shadowBmp2, ClientSize.Width - 4, z, 3, 1);
                }
                g.DrawPath(Focused ? new Pen(_focusColor) : new Pen(_borderColor), path);
            }

            e.Graphics.DrawImage(bmp, 0, 0, ClientSize.Width, ClientSize.Height);
            //bmp.Dispose();
        }

        private void CoolButtonMouseEnter(object sender, EventArgs e)
        {
            _mouseOver = true;
            Refresh();
        }

        private void CoolButtonMouseLeave(object sender, EventArgs e)
        {
            _mouseOver = false;
            _mouseDown = false;
            Refresh();
        }

        private void CoolButtonSizeChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void CoolButtonMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _mouseDown = true;
        }

        private void CoolButtonMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            if (_mouseDown)
            {
                if (ButtonClicked != null)
                {
                    ButtonClicked(this);
                }
            }
            _mouseDown = false;
        }
    }
}
