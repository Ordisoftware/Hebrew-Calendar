using System;

namespace AASharp
{
    public static class AASPluto
    {
        #region coefficients
        
        static readonly PlutoCoefficient1[] g_PlutoArgumentCoefficients =
        { 
            new PlutoCoefficient1( 0,   0,    1 ),
            new PlutoCoefficient1( 0,   0,    2 ),
            new PlutoCoefficient1( 0,   0,    3 ),
            new PlutoCoefficient1( 0,   0,    4 ),
            new PlutoCoefficient1( 0,   0,    5 ),
            new PlutoCoefficient1( 0,   0,    6 ),
            new PlutoCoefficient1( 0,   1,   -1 ),
            new PlutoCoefficient1( 0,   1,    0 ),
            new PlutoCoefficient1( 0,   1,    1 ),
            new PlutoCoefficient1( 0,   1,    2 ),
            new PlutoCoefficient1( 0,   1,    3 ),
            new PlutoCoefficient1( 0,   2,   -2 ),
            new PlutoCoefficient1( 0,   2,   -1 ),
            new PlutoCoefficient1( 0,   2,    0 ),
            new PlutoCoefficient1( 1,  -1,    0 ),
            new PlutoCoefficient1( 1,  -1,    1 ),
            new PlutoCoefficient1( 1,   0,   -3 ),
            new PlutoCoefficient1( 1,   0,   -2 ),
            new PlutoCoefficient1( 1,   0,   -1 ),
            new PlutoCoefficient1( 1,   0,    0 ),
            new PlutoCoefficient1( 1,   0,    1 ),
            new PlutoCoefficient1( 1,   0,    2 ),
            new PlutoCoefficient1( 1,   0,    3 ),
            new PlutoCoefficient1( 1,   0,    4 ),
            new PlutoCoefficient1( 1,   1,   -3 ),
            new PlutoCoefficient1( 1,   1,   -2 ),
            new PlutoCoefficient1( 1,   1,   -1 ),
            new PlutoCoefficient1( 1,   1,    0 ),
            new PlutoCoefficient1( 1,   1,    1 ),
            new PlutoCoefficient1( 1,   1,    3 ),
            new PlutoCoefficient1( 2,   0,   -6 ),
            new PlutoCoefficient1( 2,   0,   -5 ),
            new PlutoCoefficient1( 2,   0,   -4 ),
            new PlutoCoefficient1( 2,   0,   -3 ),
            new PlutoCoefficient1( 2,   0,   -2 ),
            new PlutoCoefficient1( 2,   0,   -1 ),
            new PlutoCoefficient1( 2,   0,    0 ),
            new PlutoCoefficient1( 2,   0,    1 ),
            new PlutoCoefficient1( 2,   0,    2 ),
            new PlutoCoefficient1( 2,   0,    3 ),
            new PlutoCoefficient1( 3,   0,   -2 ),
            new PlutoCoefficient1( 3,   0,   -1 ),
            new PlutoCoefficient1( 3,   0,    0 )
        };
        
        static readonly PlutoCoefficient2[] g_PlutoLongitudeCoefficients =
        { 
            new PlutoCoefficient2( -19799805, 19850055 ),
            new PlutoCoefficient2(  897144,  -4954829  ),
            new PlutoCoefficient2(  611149,   1211027  ),
            new PlutoCoefficient2( -341243,  -189585   ),
            new PlutoCoefficient2(  129287,  -34992    ),
            new PlutoCoefficient2( -38164,    30893    ),
            new PlutoCoefficient2(  20442,   -9987     ),
            new PlutoCoefficient2( -4063,    -5071     ),
            new PlutoCoefficient2( -6016,    -3336     ),
            new PlutoCoefficient2( -3956,     3039     ),
            new PlutoCoefficient2( -667,      3572     ),
            new PlutoCoefficient2(  1276,     501      ),
            new PlutoCoefficient2(  1152,    -917      ),
            new PlutoCoefficient2(  630,     -1277     ),
            new PlutoCoefficient2(  2571,    -459      ),
            new PlutoCoefficient2(  899,     -1449     ),
            new PlutoCoefficient2( -1016,     1043     ),
            new PlutoCoefficient2( -2343,    -1012     ),
            new PlutoCoefficient2(  7042,     788      ),
            new PlutoCoefficient2(  1199,    -338      ),
            new PlutoCoefficient2(  418,     -67       ),
            new PlutoCoefficient2(  120,     -274      ),
            new PlutoCoefficient2( -60,      -159      ),
            new PlutoCoefficient2( -82,      -29       ),
            new PlutoCoefficient2( -36,      -29       ),
            new PlutoCoefficient2( -40,       7        ),
            new PlutoCoefficient2( -14,       22       ),
            new PlutoCoefficient2(  4,        13       ),
            new PlutoCoefficient2(  5,        2        ),
            new PlutoCoefficient2( -1,        0        ),
            new PlutoCoefficient2(  2,        0        ),
            new PlutoCoefficient2( -4,        5        ),
            new PlutoCoefficient2(  4,       -7        ),
            new PlutoCoefficient2(  14,       24       ),
            new PlutoCoefficient2( -49,      -34       ),
            new PlutoCoefficient2(  163,     -48       ),
            new PlutoCoefficient2(  9,       -24       ),
            new PlutoCoefficient2( -4,        1        ),
            new PlutoCoefficient2( -3,        1        ),
            new PlutoCoefficient2(  1,        3        ),
            new PlutoCoefficient2( -3,       -1        ),
            new PlutoCoefficient2(  5,       -3        ),
            new PlutoCoefficient2(  0,        0        )
        };
        
        static readonly PlutoCoefficient2[] g_PlutoLatitudeCoefficients =
        { 
            new PlutoCoefficient2( -5452852, -14974862 ),
            new PlutoCoefficient2(  3527812,  1672790  ),
            new PlutoCoefficient2( -1050748,  327647   ),
            new PlutoCoefficient2(  178690,  -292153   ),
            new PlutoCoefficient2(  18650,    100340   ),
            new PlutoCoefficient2( -30697,   -25823    ),
            new PlutoCoefficient2(  4878,     11248    ),
            new PlutoCoefficient2(  226,     -64       ),
            new PlutoCoefficient2(  2030,    -836      ),
            new PlutoCoefficient2(  69,      -604      ),
            new PlutoCoefficient2( -247,     -567      ),
            new PlutoCoefficient2( -57,       1        ),
            new PlutoCoefficient2( -122,      175      ),
            new PlutoCoefficient2( -49,      -164      ),
            new PlutoCoefficient2( -197,      199      ),
            new PlutoCoefficient2( -25,       217      ),
            new PlutoCoefficient2(  589,     -248      ),
            new PlutoCoefficient2( -269,      711      ),
            new PlutoCoefficient2(  185,      193      ),
            new PlutoCoefficient2(  315,      807      ),
            new PlutoCoefficient2( -130,     -43       ),
            new PlutoCoefficient2(  5,        3        ),
            new PlutoCoefficient2(  2,        17       ),
            new PlutoCoefficient2(  2,        5        ),
            new PlutoCoefficient2(  2,        3        ),
            new PlutoCoefficient2(  3,        1        ),
            new PlutoCoefficient2(  2,       -1        ),
            new PlutoCoefficient2(  1,       -1        ),
            new PlutoCoefficient2(  0,       -1        ),
            new PlutoCoefficient2(  0,        0        ),
            new PlutoCoefficient2(  0,       -2        ),
            new PlutoCoefficient2(  2,        2        ),
            new PlutoCoefficient2( -7,        0        ),
            new PlutoCoefficient2(  10,      -8        ),
            new PlutoCoefficient2( -3,        20       ),
            new PlutoCoefficient2(  6,        5        ),
            new PlutoCoefficient2(  14,       17       ),
            new PlutoCoefficient2( -2,        0        ),
            new PlutoCoefficient2(  0,        0        ),
            new PlutoCoefficient2(  0,        0        ),
            new PlutoCoefficient2(  0,        1        ),
            new PlutoCoefficient2(  0,        0        ),
            new PlutoCoefficient2(  1,        0        )
        };
        
        static readonly PlutoCoefficient2[] g_PlutoRadiusCoefficients =
        { 
            new PlutoCoefficient2(  66865439,   68951812 ),
            new PlutoCoefficient2( -11827535,  -332538   ),
            new PlutoCoefficient2(  1593179,   -1438890  ),
            new PlutoCoefficient2( -18444,      483220   ),
            new PlutoCoefficient2( -65977,     -85431    ),
            new PlutoCoefficient2(  31174,     -6032     ),
            new PlutoCoefficient2( -5794,       22161    ),
            new PlutoCoefficient2(  4601,       4032     ),
            new PlutoCoefficient2( -1729,       234      ),
            new PlutoCoefficient2( -415,        702      ),
            new PlutoCoefficient2(  239,        723      ),
            new PlutoCoefficient2(  67,        -67       ),
            new PlutoCoefficient2(  1034,      -451      ),
            new PlutoCoefficient2( -129,        504      ),
            new PlutoCoefficient2(  480,       -231      ),
            new PlutoCoefficient2(  2,         -441      ),
            new PlutoCoefficient2( -3359,       265      ),
            new PlutoCoefficient2(  7856,      -7832     ),
            new PlutoCoefficient2(  36,         45763    ),
            new PlutoCoefficient2(  8663,       8547     ),
            new PlutoCoefficient2( -809,       -769      ),
            new PlutoCoefficient2(  263,       -144      ),
            new PlutoCoefficient2( -126,        32       ),
            new PlutoCoefficient2( -35,        -16       ),
            new PlutoCoefficient2( -19,        -4        ),
            new PlutoCoefficient2( -15,         8        ),
            new PlutoCoefficient2( -4,          12       ),
            new PlutoCoefficient2(  5,          6        ),
            new PlutoCoefficient2(  3,          1        ),
            new PlutoCoefficient2(  6,         -2        ),
            new PlutoCoefficient2(  2,          2        ),
            new PlutoCoefficient2( -2,         -2        ),
            new PlutoCoefficient2(  14,         13       ),
            new PlutoCoefficient2( -63,         13       ),
            new PlutoCoefficient2(  136,       -236      ),
            new PlutoCoefficient2(  273,        1065     ),
            new PlutoCoefficient2(  251,        149      ),
            new PlutoCoefficient2( -25,        -9        ),
            new PlutoCoefficient2(  9,         -2        ),
            new PlutoCoefficient2( -8,          7        ),
            new PlutoCoefficient2(  2,         -10       ),
            new PlutoCoefficient2(  19,         35       ),
            new PlutoCoefficient2(  10,         3        )
        };
        
        #endregion

        public static double EclipticLongitude(double JD)
        {
            double T = (JD - 2451545) / 36525;
            double J = 34.35 + 3034.9057 * T;
            double S = 50.08 + 1222.1138 * T;
            double P = 238.96 + 144.9600 * T;

            //Calculate Longitude
            double L = 0;
            int nPlutoCoefficients = g_PlutoArgumentCoefficients.Length;
            for (int i = 0; i < nPlutoCoefficients; i++)
            {
                double Alpha = g_PlutoArgumentCoefficients[i].J * J + g_PlutoArgumentCoefficients[i].S * S + g_PlutoArgumentCoefficients[i].P * P;
                Alpha = AASCoordinateTransformation.DegreesToRadians(Alpha);
                L += ((g_PlutoLongitudeCoefficients[i].A * Math.Sin(Alpha)) + (g_PlutoLongitudeCoefficients[i].B * Math.Cos(Alpha)));
            }
            L = L / 1000000;
            L += (238.958116 + 144.96 * T);
            L = AASCoordinateTransformation.MapTo0To360Range(L);

            return L;
        }

        public static double EclipticLatitude(double JD)
        {
            double T = (JD - 2451545) / 36525;
            double J = 34.35 + 3034.9057 * T;
            double S = 50.08 + 1222.1138 * T;
            double P = 238.96 + 144.9600 * T;

            //Calculate Latitude
            double L = 0;
            int nPlutoCoefficients = g_PlutoArgumentCoefficients.Length;
            for (int i = 0; i < nPlutoCoefficients; i++)
            {
                double Alpha = g_PlutoArgumentCoefficients[i].J * J + g_PlutoArgumentCoefficients[i].S * S + g_PlutoArgumentCoefficients[i].P * P;
                Alpha = AASCoordinateTransformation.DegreesToRadians(Alpha);
                L += ((g_PlutoLatitudeCoefficients[i].A * Math.Sin(Alpha)) + (g_PlutoLatitudeCoefficients[i].B * Math.Cos(Alpha)));
            }
            L = L / 1000000;
            L += -3.908239;

            return L;
        }

        public static double RadiusVector(double JD)
        {
            double T = (JD - 2451545) / 36525;
            double J = 34.35 + 3034.9057 * T;
            double S = 50.08 + 1222.1138 * T;
            double P = 238.96 + 144.9600 * T;

            //Calculate Radius
            double R = 0;
            int nPlutoCoefficients = g_PlutoArgumentCoefficients.Length;
            for (int i = 0; i < nPlutoCoefficients; i++)
            {
                double Alpha = g_PlutoArgumentCoefficients[i].J * J + g_PlutoArgumentCoefficients[i].S * S + g_PlutoArgumentCoefficients[i].P * P;
                Alpha = AASCoordinateTransformation.DegreesToRadians(Alpha);
                R += ((g_PlutoRadiusCoefficients[i].A * Math.Sin(Alpha)) + (g_PlutoRadiusCoefficients[i].B * Math.Cos(Alpha)));
            }
            R = R / 10000000;
            R += 40.7241346;

            return R;
        }
    }
}
