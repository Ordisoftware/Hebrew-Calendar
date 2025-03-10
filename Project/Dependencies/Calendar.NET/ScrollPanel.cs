﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CodeProjectCalendar.NET
{
  [SuppressMessage("Design", "GCop132:Since the type is inferred, use 'var' instead", Justification = "<En attente>")]
  [SuppressMessage("Naming", "GCop204:Rename the variable '{0}' to something clear and meaningful.", Justification = "<En attente>")]
  internal partial class ScrollPanel : UserControl
  {
    private int _scrollOffset;
    private bool _mouseDown;
    private Point _oldMouseCoords;
    private int _bmpSize;

    [DllImport("user32.dll")]
    static extern short GetKeyState(int nVirtKey);

    public event EventHandler<MouseEventArgs> RightButtonClicked;

    public ScrollPanel()
    {
      InitializeComponent();
      _scrollOffset = 0;
      _mouseDown = false;
      _oldMouseCoords = new Point(0, 0);
    }

    public int ScrollOffset
      => _scrollOffset;

    private void ScrollPanel_Load(object sender, EventArgs e)
    {
      //BackColor = Color.Blue;
    }

    private void ScrollPanel_Paint(object sender, PaintEventArgs e)
    {
      var c = (Calendar)Parent;

      using Bitmap bmp = c.RequestImage();
      if ( bmp is null )
        return;

      e.Graphics.DrawImage(bmp, new Rectangle(0, 0, ClientSize.Width, ClientSize.Height),
                           new Rectangle(0, _scrollOffset, ClientSize.Width, ClientSize.Height),
                           GraphicsUnit.Pixel);
      _bmpSize = bmp.Height;
      //e.Graphics.Dispose();
    }

    private void ScrollPanel_MouseDown(object sender, MouseEventArgs e)
    {
      if ( e.Button == MouseButtons.Left )
      {
        _mouseDown = true;
        _oldMouseCoords = e.Location;
      }
    }

    private void ScrollPanel_MouseUp(object sender, MouseEventArgs e)
    {
      if ( e.Button == MouseButtons.Left )
        _mouseDown = false;
    }

    private void ScrollPanel_MouseMove(object sender, MouseEventArgs e)
    {
      if ( _mouseDown && e.Location.Y < _oldMouseCoords.Y && _scrollOffset < _bmpSize - _scrollOffset - ClientSize.Height )
      {
        int offset = _oldMouseCoords.Y - e.Location.Y;
        _scrollOffset += offset;
        Refresh();
      }
      if ( _mouseDown && e.Location.Y > _oldMouseCoords.Y && _scrollOffset > 0 )
      {
        int offset = e.Location.Y - _oldMouseCoords.Y;
        _scrollOffset -= offset;
        Refresh();
      }
      _oldMouseCoords = e.Location;
    }

    private void ScrollPanel_MouseClick(object sender, MouseEventArgs e)
    {
      if ( e.Button == MouseButtons.Right )
      {
        RightButtonClicked?.Invoke(sender, e);
      }
    }
  }
}
