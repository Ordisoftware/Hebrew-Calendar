// Adapted from http://www.codeproject.com/Articles/100174/Calculate-and-Draw-Moon-Phase
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MostafaKaisoun
{

  [SuppressMessage("Design", "GCop132:Since the type is inferred, use 'var' instead", Justification = "<En attente>")]
  [SuppressMessage("Design", "GCop179:Do not hardcode numbers, strings or other values. Use constant fields, enums, config files or database as appropriate.", Justification = "N/A")]
  [SuppressMessage("Naming", "GCop201:Use camelCasing when declaring {0}", Justification = "<En attente>")]
  [SuppressMessage("Naming", "GCop204:Rename the variable '{0}' to something clear and meaningful.", Justification = "<En attente>")]
  public static class MoonPhaseImage
  {

    static MoonPhaseImage()
    {
      //PictureBox PicMoon = new()
      //{
      //  BackColor = Color.Navy,
      //  ImeMode = ImeMode.NoControl,
      //  Location = new(16, 8),
      //  Name = "PicMoon",
      //  Size = new(155, 155),
      //  TabIndex = 13,
      //  TabStop = false
      //};
    }

    static public Image Draw(int y, int m, int d, int width, int height)
    {
      double ip;
      //double ag;
      int j;
      int mm, yy;
      int k1, k2, k3;
      yy = y - ( 12 - m ) / 10;
      mm = m + 9;
      if ( mm >= 12 )
      {
        mm -= 12;
      }
      k1 = (int)( 365.25 * ( yy + 4712 ) );
      k2 = (int)( 30.6001 * mm + 0.5 );
      k3 = (int)( ( ( yy / 100 ) + 49 ) * 0.75 ) - 38;
      // 'j' for dates in Julian calendar:
      j = k1 + k2 + d + 59;
      if ( j > 2299160 )
      {
        // For Gregorian calendar:
        j -= k3;  // 'j' is the Julian date at 12h UT (Universal Time)
      }
      //Calculate the approximate phase of the moon
      ip = ( j + 4.867 ) / 29.53059;
      ip -= Math.Floor(ip);
      //After several trials I've seen to add the following lines, 
      //which gave the result was not bad
      //if ( ip < 0.5 )
      //  ag = ip * 29.53059 + 29.53059 / 2;
      //else
      //  ag = ip * 29.53059 - 29.53059 / 2;
      //// Moon's age in days
      //ag = Math.Floor(ag) + 1;

      int Xpos, Ypos, Rpos;
      int Xpos1, Xpos2;
      double Phase = ip;

      // Width of 'ImageToDraw' Object = Width of 'PicMoon' control
      int PageWidth = width;
      // Height of 'ImageToDraw' Object = Height of 'PicMoon' control
      int PageHeight = height;
      // Initiate 'ImageToDraw' Object with size = size of control 'PicMoon' control
      Bitmap ImageToDraw = new(PageWidth, PageHeight);
      // Create graphics object for alteration.
      Graphics newGraphics = Graphics.FromImage(ImageToDraw);

      Pen PenB = new(Color.Black); // For darkness part of the moon
      Pen PenW = new(Color.White); // For the lighted part of the moon

      for ( Ypos = 0; Ypos <= 45; Ypos++ )
      {
        Xpos = (int)( Math.Sqrt(45 * 45 - Ypos * Ypos) );
        // Draw darkness part of the moon
        Point pB1 = new(90 - Xpos, Ypos + 90);
        Point pB2 = new(Xpos + 90, Ypos + 90);
        Point pB3 = new(90 - Xpos, 90 - Ypos);
        Point pB4 = new(Xpos + 90, 90 - Ypos);
        newGraphics.DrawLine(PenB, pB1, pB2);
        newGraphics.DrawLine(PenB, pB3, pB4);
        // Determine the edges of the lighted part of the moon
        Rpos = 2 * Xpos;
        if ( Phase < 0.5 )
        {
          Xpos1 = -Xpos;
          Xpos2 = (int)( Rpos - 2 * Phase * Rpos - Xpos );
        }
        else
        {
          Xpos1 = Xpos;
          Xpos2 = (int)( Xpos - 2 * Phase * Rpos + Rpos );
        }
        // Draw the lighted part of the moon
        Point pW1 = new(Xpos1 + 90, 90 - Ypos);
        Point pW2 = new(Xpos2 + 90, 90 - Ypos);
        Point pW3 = new(Xpos1 + 90, Ypos + 90);
        Point pW4 = new(Xpos2 + 90, Ypos + 90);
        newGraphics.DrawLine(PenW, pW1, pW2);
        newGraphics.DrawLine(PenW, pW3, pW4);
      }
      // Display the bitmap in the picture box.
      // Release graphics object
      PenB.Dispose();
      PenW.Dispose();
      newGraphics.Dispose();
      return ImageToDraw;
    }

  }

}