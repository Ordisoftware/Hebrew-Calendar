// http://samik26.webgarden.cz/temata/class-sun-moonrise-set
namespace Keith_Burnett_moonr2cs
{

  public class SunMoon
  {
    string outstring;
    double[] quadout = new double[8];
    readonly double[] suneq = new double[8];
    readonly double[] mooneq = new double[8];

    //
    //  *** Functions go here - mostly adapted from Montenbruck and Pfleger section 3.8 ***
    //
    static string Hrsmin(double hours)
    {
      //
      //	takes decimal hours and returns a string in hhmm format
      //
      double hrs, h, m, dum;
      hrs = Math.Floor(hours * 60 + 0.5) / 60.0;
      h = Math.Floor(hrs);
      m = Math.Floor(60 * ( hrs - h ) + 0.5);
      dum = h * 100 + m;
      //
      // the jiggery pokery below is to make sure that two minutes past midnight
      // comes out as 0002 not 2. Javascript does not appear to have 'format codes'
      // like C
      //
      return ( (int)dum ).ToString("0000");
    }

    static double Ipart(double x)
    {
      //
      //	returns the integer part - like int() in basic
      //
      return x > 0 ? Math.Floor(x) : Math.Ceiling(x);
    }

    static double Frac(double x)
    {
      //
      //	returns the fractional part of x as used in minimoon and minisun
      //
      double a = x - Math.Floor(x);
      if ( a < 0 ) a++;
      return a;
    }

    //
    // round rounds the number num to dp decimal places
    // the second line is some C like jiggery pokery I
    // found in an OReilly book which means if dp is null
    // you get 2 decimal places.
    //
    static double Round(double num, int dp)
    {
      //   dp = (!dp ? 2: dp);
      return Math.Round(num * Math.Pow(10, dp)) / Math.Pow(10, dp);
    }

    static double Range(double x)
    {
      //
      //	returns an angle in degrees in the range 0 to 360
      //
      double a, b;
      b = x / 360;
      a = 360 * ( b - Ipart(b) );
      if ( a < 0 )
      {
        a += 360;
      }
      return a;
    }

    static double Mjd(int day, int month, int year, int hour)
    {
      //
      //	Takes the day, month, year and hours in the day and returns the
      //  modified julian day number defined as mjd = jd - 2400000.5
      //  checked OK for Greg era dates - 26th Dec 02
      //
      double a, b;
      if ( month <= 2 )
      {
        month += 12;
        year--;
      }
      a = 10000.0 * year + 100.0 * month + day;
      if ( a <= 15821004.1 )
      {
        b = -2 * Math.Floor(( year + 4716 ) / 4.0) - 1179;
      }
      else
      {
        b = Math.Floor(year / 400.0) - Math.Floor(year / 100.0) + Math.Floor(year / 4.0);
      }
      a = 365.0 * year - 679004.0;
      return a + b + Math.Floor(30.6001 * ( month + 1 )) + day + hour / 24.0;
    }

    static string Caldat(double mjd)
    {
      //
      //	Takes mjd and returns the civil calendar date in Gregorian calendar
      //  as a string in format yyyymmdd.hhhh
      //  looks OK for Greg era dates  - not good for earlier - 26th Dec 02
      //
      //var calout;
      double b, d, f, jd, jd0, c, e;
      double day, month, year, hour;
      jd = mjd + 2400000.5;
      jd0 = Math.Floor(jd + 0.5);
      if ( jd0 < 2299161.0 )
      {
        c = jd0 + 1524.0;
      }
      else
      {
        b = Math.Floor(( jd0 - 1867216.25 ) / 36524.25);
        c = jd0 + ( b - Math.Floor(b / 4) ) + 1525.0;
      }
      d = Math.Floor(( c - 122.1 ) / 365.25);
      e = 365.0 * d + Math.Floor(d / 4);
      f = Math.Floor(( c - e ) / 30.6001);
      day = Math.Floor(c - e + 0.5) - Math.Floor(30.6001 * f);
      month = f - 1 - 12 * Math.Floor(f / 14);
      year = d - 4715 - Math.Floor(( 7 + month ) / 10);
      hour = 24.0 * ( jd + 0.5 - jd0 ) + 5;
      //hour = _wtoi(hrsmin(hour));
      hour = Convert.ToUInt32(Hrsmin(hour));
      double calout = Round(year * 10000.0 + month * 100.0 + day + hour / 10000, 4);
      double dum1 = calout;
      string cc = dum1.ToString("########");
      return cc;
    }

    double[] Quad(double ym, double yz, double yp)
    {
      //
      //	finds the parabola throuh the three points (-1,ym), (0,yz), (1, yp)
      //  and returns the coordinates of the max/min (if any) xe, ye
      //  the values of x where the parabola crosses zero (roots of the quadratic)
      //  and the number of roots (0, 1 or 2) within the interval [-1, 1]
      //
      //	well, this routine is producing sensible answers
      //
      //  results passed as array [nz, z1, z2, xe, ye]
      //
      double nz, a, b, c, dis, dx, xe, ye, z1, z2;
      //var quadout = new Array;
      z1 = 0;
      z2 = 0;
      nz = 0;
      a = 0.5 * ( ym + yp ) - yz;
      b = 0.5 * ( yp - ym );
      c = yz;
      xe = -b / ( 2 * a );
      ye = ( a * xe + b ) * xe + c;
      dis = b * b - 4.0 * a * c;
      if ( dis > 0 )
      {
        dx = 0.5 * Math.Sqrt(dis) / Math.Abs(a);
        z1 = xe - dx;
        z2 = xe + dx;
        if ( Math.Abs(z1) <= 1.0 ) nz++;
        if ( Math.Abs(z2) <= 1.0 ) nz++;
        if ( z1 < -1.0 ) z1 = z2;
      }
      quadout[0] = nz;
      quadout[1] = z1;
      quadout[2] = z2;
      quadout[3] = xe;
      quadout[4] = ye;
      return quadout;
    }

    static double Lmst(double mjd, double glong)
    {
      //
      //	Takes the mjd and the longitude (west negative) and then returns
      //  the local sidereal time in hours. Im using Meeus formula 11.4
      //  instead of messing about with UTo and so on
      //
      double lst, t, d;
      d = mjd - 51544.5;
      t = d / 36525.0;
      lst = Range(280.46061837 + 360.98564736629 * d + 0.000387933 * t * t - t * t * t / 38710000);
      return lst / 15.0 + glong / 15;
    }

    double[] Minisun(double t)
    {
      //
      //	returns the ra and dec of the Sun in an array called suneq[]
      //  in decimal hours, degs referred to the equinox of date and using
      //  obliquity of the ecliptic at J2000.0 (small error for +- 100 yrs)
      //	takes t centuries since J2000.0. Claimed good to 1 arcmin
      //
      const double p2 = 6.283185307, coseps = 0.91748, sineps = 0.39778;
      double L, M, DL, SL, X, Y, Z, RHO, ra, dec;
      M = p2 * Frac(0.993133 + 99.997361 * t);
      DL = 6893.0 * Math.Sin(M) + 72.0 * Math.Sin(2 * M);
      L = p2 * Frac(0.7859453 + M / p2 + ( 6191.2 * t + DL ) / 1296000);
      SL = Math.Sin(L);
      X = Math.Cos(L);
      Y = coseps * SL;
      Z = sineps * SL;
      RHO = Math.Sqrt(1 - Z * Z);
      dec = ( 360.0 / p2 ) * Math.Atan(Z / RHO);
      ra = ( 48.0 / p2 ) * Math.Atan(Y / ( X + RHO ));
      if ( ra < 0 ) ra += 24;
      suneq[1] = dec;
      suneq[2] = ra;
      return suneq;
    }

    double[] Minimoon(double t)
    {
      //
      // takes t and returns the geocentric ra and dec in an array mooneq
      // claimed good to 5' (angle) in ra and 1' in dec
      // tallies with another approximate method and with ICE for a couple of dates
      //
      const double p2 = 6.283185307, arc = 206264.8062, coseps = 0.91748, sineps = 0.39778;
      double L0, L, LS, F, D, H, S, N, DL, CB, L_moon, B_moon, V, W, X, Y, Z, RHO, dec, ra;
      L0 = Frac(0.606433 + 1336.855225 * t);	// mean longitude of moon
      L = p2 * Frac(0.374897 + 1325.552410 * t); //mean anomaly of Moon
      LS = p2 * Frac(0.993133 + 99.997361 * t); //mean anomaly of Sun
      D = p2 * Frac(0.827361 + 1236.853086 * t); //difference in longitude of moon and sun
      F = p2 * Frac(0.259086 + 1342.227825 * t); //mean argument of latitude
      // corrections to mean longitude in arcsec
      DL = 22640 * Math.Sin(L);
      DL += -4586 * Math.Sin(L - 2 * D);
      DL += +2370 * Math.Sin(2 * D);
      DL += +769 * Math.Sin(2 * L);
      DL += -668 * Math.Sin(LS);
      DL += -412 * Math.Sin(2 * F);
      DL += -212 * Math.Sin(2 * L - 2 * D);
      DL += -206 * Math.Sin(L + LS - 2 * D);
      DL += +192 * Math.Sin(L + 2 * D);
      DL += -165 * Math.Sin(LS - 2 * D);
      DL += -125 * Math.Sin(D);
      DL += -110 * Math.Sin(L + LS);
      DL += +148 * Math.Sin(L - LS);
      DL += -55 * Math.Sin(2 * F - 2 * D);
      // simplified form of the latitude terms
      S = F + ( DL + 412 * Math.Sin(2 * F) + 541 * Math.Sin(LS) ) / arc;
      H = F - 2 * D;
      N = -526 * Math.Sin(H);
      N += +44 * Math.Sin(L + H);
      N += -31 * Math.Sin(-L + H);
      N += -23 * Math.Sin(LS + H);
      N += +11 * Math.Sin(-LS + H);
      N += -25 * Math.Sin(-2 * L + F);
      N += +21 * Math.Sin(-L + F);
      // ecliptic long and lat of Moon in rads
      L_moon = p2 * Frac(L0 + DL / 1296000);
      B_moon = ( 18520.0 * Math.Sin(S) + N ) / arc;
      // equatorial coord conversion - note fixed obliquity
      CB = Math.Cos(B_moon);
      X = CB * Math.Cos(L_moon);
      V = CB * Math.Sin(L_moon);
      W = Math.Sin(B_moon);
      Y = coseps * V - sineps * W;
      Z = sineps * V + coseps * W;
      RHO = Math.Sqrt(1.0 - Z * Z);
      dec = ( 360.0 / p2 ) * Math.Atan(Z / RHO);
      ra = ( 48.0 / p2 ) * Math.Atan(Y / ( X + RHO ));
      if ( ra < 0 ) ra += 24;
      mooneq[1] = dec;
      mooneq[2] = ra;
      return mooneq;
    }

    double Sin_alt(double iobj, double mjd0, double hour, double glong, double cglat, double sglat)
    {
      //
      //	this rather mickey mouse function takes a lot of
      //  arguments and then returns the sine of the altitude of
      //  the object labelled by iobj. iobj = 1 is moon, iobj = 2 is sun
      //
      double mjd, t, ra, dec, tau, /*salt, */rads = 0.0174532925;
      double[] objpos;
      mjd = mjd0 + hour / 24.0;
      t = ( mjd - 51544.5 ) / 36525.0;
      if ( iobj == 1 )
      {
        objpos = Minimoon(t);
      }
      else
      {
        objpos = Minisun(t);
      }
      ra = objpos[2];
      dec = objpos[1];
      // hour angle of object
      tau = 15.0 * ( Lmst(mjd, glong) - ra );
      // sin(alt) of object using the conversion formulas
      return sglat * Math.Sin(rads * dec) + cglat * Math.Cos(rads * dec) * Math.Cos(rads * tau);
    }

    [SuppressMessage("Minor Code Smell", "S1643:Strings should not be concatenated using '+' in a loop", Justification = "<En attente>")]
    [SuppressMessage("Design", "MA0051:Method is too long", Justification = "N/A")]
    string Find_sun_and_twi_events_for_date(double mjd, double tz, double glong, double glat)
    {
      //
      //	this is my attempt to encapsulate most of the program in a function
      //	then this function can be generalised to find all the Sun events.
      //
      //
      double sglat, date, ym, yz, utrise, utset, cglat, /*xe, */ye;
      double yp, nz, hour, z1, z2, rads = 0.0174532925;
      bool rise, sett, above;
      int j;
      utrise = utset = 0;
      double[] sinho = new double[6];
      string always_up;
      string always_down;
      always_up = " ****";
      always_down = " ....";
      outstring = "";
      //
      //	Set up the array with the 4 values of sinho needed for the 4
      //      kinds of sun event
      //
      sinho[0] = Math.Sin(rads * -0.833);		//sunset upper limb simple refraction
      sinho[1] = Math.Sin(rads * -6.0);		//civil twi
      sinho[2] = Math.Sin(rads * -12.0);		//nautical twi
      sinho[3] = Math.Sin(rads * -18.0);		//astro twi
      sglat = Math.Sin(rads * glat);
      cglat = Math.Cos(rads * glat);
      date = mjd - tz / 24;
      //
      //	main loop takes each value of sinho in turn and finds the rise/set
      //      events associated with that altitude of the Sun
      //
      for ( j = 0; j < 4; j++ )
      {
        ref double element = ref sinho[j];
        rise = false;
        sett = false;
        above = false;
        hour = 1.0;
        ym = Sin_alt(2.0, date, hour - 1.0, glong, cglat, sglat) - element;
        if ( ym > 0.0 ) above = true;
        //
        // the while loop finds the sin(alt) for sets of three consecutive
        // hours, and then tests for a single zero crossing in the interval
        // or for two zero crossings in an interval or for a grazing event
        // The flags rise and sett are set accordingly
        //
        while ( hour < 25 && ( !sett || !rise ) )
        {
          yz = Sin_alt(2, date, hour, glong, cglat, sglat) - element;
          yp = Sin_alt(2, date, hour + 1.0, glong, cglat, sglat) - element;
          quadout = Quad(ym, yz, yp);
          nz = quadout[0];
          z1 = quadout[1];
          z2 = quadout[2];
          //xe = quadout[3];
          ye = quadout[4];
          // case when one event is found in the interval
          if ( nz == 1 )
          {
            if ( ym < 0.0 )
            {
              utrise = hour + z1;
              rise = true;
            }
            else
            {
              utset = hour + z1;
              sett = true;
            }
          } // end of nz = 1 case

          // case where two events are found in this interval
          // (rare but whole reason we are not using simple iteration)
          if ( nz == 2 )
          {
            if ( ye < 0.0 )
            {
              utrise = hour + z2;
              utset = hour + z1;
            }
            else
            {
              utrise = hour + z1;
              utset = hour + z2;
            }
          } // end of nz = 2 case

          // set up the next search interval
          ym = yp;
          hour += 2.0;
        } // end of while loop
        //
        // now search has completed, we compile the string to pass back
        // to the main loop. The string depends on several combinations
        // of the above flag (always above or always below) and the rise
        // and sett flags
        //
        if ( rise || sett )
        {
          if ( rise ) { outstring += " "; outstring += Hrsmin(utrise); } //(outstring += " " + hrsmin(utrise);
          else outstring += " ----";//outstring += " ----";
          if ( sett ) { outstring += " "; outstring += Hrsmin(utset); }//outstring += " " + hrsmin(utset);
          else outstring += " ----";//outstring += " ----";
        }
        else
        {
          if ( above ) { outstring += always_up; outstring += always_up; }//outstring += always_up + always_up;
          else { outstring += always_down; outstring += always_down; }//outstring += always_down + always_down;
        }
      } // end of for loop - next condition
      return outstring;
    }

    string Find_moonrise_set(double mjd, double tz, double glong, double glat)
    {
      //
      //	Im using a separate function for moonrise/set to allow for different tabulations
      //  of moonrise and sun events ie weekly for sun and daily for moon. The logic of
      //  the function is identical to find_sun_and_twi_events_for_date()
      //
      const double rads = 0.0174532925;
      double sglat, date, ym, yz, utrise, utset, cglat, /*xe, */ye;
      double yp, nz, hour, z1, z2;
      double sinho;
      bool rise, sett, above;
      utrise = utset = 0;
      string always_up;
      string always_down;
      always_up = " ****";
      always_down = " ....";
      outstring = "";
      sinho = Math.Sin(rads * 8 / 60);		//moonrise taken as centre of moon at +8 arcmin
      sglat = Math.Sin(rads * glat);
      cglat = Math.Cos(rads * glat);
      date = mjd - tz / 24;
      rise = false;
      sett = false;
      above = false;
      hour = 1.0;
      ym = Sin_alt(1, date, hour - 1.0, glong, cglat, sglat) - sinho;
      if ( ym > 0.0 ) above = true;
      while ( hour < 25 && ( !sett || !rise ) )
      {
        yz = Sin_alt(1, date, hour, glong, cglat, sglat) - sinho;
        yp = Sin_alt(1, date, hour + 1.0, glong, cglat, sglat) - sinho;
        quadout = Quad(ym, yz, yp);
        nz = quadout[0];
        z1 = quadout[1];
        z2 = quadout[2];
        //xe = quadout[3];
        ye = quadout[4];
        // case when one event is found in the interval
        if ( nz == 1 )
        {
          if ( ym < 0.0 )
          {
            utrise = hour + z1;
            rise = true;
          }
          else
          {
            utset = hour + z1;
            sett = true;
          }
        } // end of nz = 1 case
        // case where two events are found in this interval
        // (rare but whole reason we are not using simple iteration)
        if ( nz == 2 )
        {
          if ( ye < 0.0 )
          {
            utrise = hour + z2;
            utset = hour + z1;
          }
          else
          {
            utrise = hour + z1;
            utset = hour + z2;
          }
        }
        // set up the next search interval
        ym = yp;
        hour += 2.0;
      } // end of while loop
      if ( rise || sett )
      {
        if ( rise ) { outstring += " "; outstring += Hrsmin(utrise); }//outstring += " " + hrsmin(utrise);
        else outstring += " ----"; //outstring += " ----";
        if ( sett ) { outstring += " "; outstring += Hrsmin(utset); }//outstring += " " + hrsmin(utset);
        else outstring += " ----"; //outstring += " ----";
      }
      else
      {
        if ( above ) { outstring += always_up; outstring += always_up; }//outstring += always_up + always_up;
        else { outstring += always_down; outstring += always_down; }// outstring += always_down + always_down;
      }

      return outstring;
    }

    [SuppressMessage("Minor Code Smell", "S1643:Strings should not be concatenated using '+' in a loop", Justification = "<En attente>")]
    public string Get(int iiy, int iim, int iid, float flat, float flong, float fzone, int iinum)
    {
      string OutString = "";
      // parse the form to make sure the numbers are numbers and not strings!
      //
      double y = iiy;//2008;//parseInt(InForm.Year.value, 10);
      double m = iim;//7;//parseInt(InForm.Month.value, 10);
      double day = iid;//3;//parseInt(InForm.Day.value, 10);
      int numday = iinum;//1;//parseInt(InForm.NumDays.value, 10);
      double glong = flong;//14.26;//parseFloat(InForm.Glong.value);
      double glat = flat;//50.05;//parseFloat(InForm.Glat.value);
      double tz = fzone;//2.0;//parseFloat(InForm.TimeZone.value);
      //
      //  print the table header to the text area
      //
      //InForm.OutTable.value = HeadString;
      //
      // main loop. All the work is done in the functions with the long names
      // find_sun_and_twi_events_for_date() and find_moonrise_set()
      //
      double mj = Mjd((int)day, (int)m, (int)y, 0);
      int i;
      string po;
      for ( i = 0; i < numday; i++ )
      {
        po = Caldat(mj + i);
        OutString += po;
        OutString += " ";
        OutString += Find_sun_and_twi_events_for_date(mj + i, tz, glong, glat);
        OutString += " ";
        OutString += Find_moonrise_set(mj + i, tz, glong, glat);
        //if(numday>1)
        //OutString+="\n";
      }
      return OutString;
    } // end of main program
  }
}
