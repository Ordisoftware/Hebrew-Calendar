using System;

namespace AASharp
{
    public static class AASEarth
    {
        #region coefficient
        
        static VSOP87Coefficient[] g_L0EarthCoefficients =
        {
            new VSOP87Coefficient( 175347046, 0,         0            ),
            new VSOP87Coefficient( 3341656,   4.6692568, 6283.0758500 ),
            new VSOP87Coefficient( 34894,     4.62610,   12566.15170  ),
            new VSOP87Coefficient( 3497,      2.7441,    5753.3849    ),
            new VSOP87Coefficient( 3418,      2.8289,    3.5231       ),
            new VSOP87Coefficient( 3136,      3.6277,    77713.7715   ),
            new VSOP87Coefficient( 2676,      4.4181,    7860.4194    ),
            new VSOP87Coefficient( 2343,      6.1352,    3930.2097    ),
            new VSOP87Coefficient( 1324,      0.7425,    11506.7698   ),
            new VSOP87Coefficient( 1273,      2.0371,    529.6910     ),
            new VSOP87Coefficient( 1199,      1.1096,    1577.3435    ),
            new VSOP87Coefficient( 990,       5.233,     5884.927     ),
            new VSOP87Coefficient( 902,       2.045,     26.298       ),
            new VSOP87Coefficient( 857,       3.508,     398.149      ),
            new VSOP87Coefficient( 780,       1.179,     5223.694     ),
            new VSOP87Coefficient( 753,       2.533,     5507.553     ),
            new VSOP87Coefficient( 505,       4.583,     18849.228    ),
            new VSOP87Coefficient( 492,       4.205,     775.523      ),
            new VSOP87Coefficient( 357,       2.920,     0.067        ),
            new VSOP87Coefficient( 317,       5.849,     11790.629    ),
            new VSOP87Coefficient( 284,       1.899,     796.298      ),
            new VSOP87Coefficient( 271,       0.315,     10977.079    ),
            new VSOP87Coefficient( 243,       0.345,     5486.778     ),
            new VSOP87Coefficient( 206,       4.806,     2544.314     ),
            new VSOP87Coefficient( 205,       1.869,     5573.143     ),
            new VSOP87Coefficient( 202,       2.458,     6069.777     ),
            new VSOP87Coefficient( 156,       0.833,     213.299      ),
            new VSOP87Coefficient( 132,       3.411,     2942.463     ),
            new VSOP87Coefficient( 126,       1.083,     20.775       ),
            new VSOP87Coefficient( 115,       0.645,     0.980        ),
            new VSOP87Coefficient( 103,       0.636,     4694.003     ),
            new VSOP87Coefficient( 102,       0.976,     15720.839    ),
            new VSOP87Coefficient( 102,       4.267,     7.114        ),
            new VSOP87Coefficient( 99,        6.21,      2146.17      ),
            new VSOP87Coefficient( 98,        0.68,      155.42       ),
            new VSOP87Coefficient( 86,        5.98,      161000.69    ),
            new VSOP87Coefficient( 85,        1.30,      6275.96      ),
            new VSOP87Coefficient( 85,        3.67,      71430.70     ),
            new VSOP87Coefficient( 80,        1.81,      17260.15     ),
            new VSOP87Coefficient( 79,        3.04,      12036.46     ),
            new VSOP87Coefficient( 75,        1.76,      5088.63      ),
            new VSOP87Coefficient( 74,        3.50,      3154.69      ),
            new VSOP87Coefficient( 74,        4.68,      801.82       ),
            new VSOP87Coefficient( 70,        0.83,      9437.76      ),
            new VSOP87Coefficient( 62,        3.98,      8827.39      ),
            new VSOP87Coefficient( 61,        1.82,      7084.90      ),
            new VSOP87Coefficient( 57,        2.78,      6286.60      ),
            new VSOP87Coefficient( 56,        4.39,      14143.50     ),
            new VSOP87Coefficient( 56,        3.47,      6279.55      ),
            new VSOP87Coefficient( 52,        0.19,      12139.55     ),
            new VSOP87Coefficient( 52,        1.33,      1748.02      ),
            new VSOP87Coefficient( 51,        0.28,      5856.48      ),
            new VSOP87Coefficient( 49,        0.49,      1194.45      ),
            new VSOP87Coefficient( 41,        5.37,      8429.24      ),
            new VSOP87Coefficient( 41,        2.40,      19651.05     ),
            new VSOP87Coefficient( 39,        6.17,      10447.39     ),
            new VSOP87Coefficient( 37,        6.04,      10213.29     ),
            new VSOP87Coefficient( 37,        2.57,      1059.38      ),
            new VSOP87Coefficient( 36,        1.71,      2352.87      ),
            new VSOP87Coefficient( 36,        1.78,      6812.77      ),
            new VSOP87Coefficient( 33,        0.59,      17789.85     ),
            new VSOP87Coefficient( 30,        0.44,      83996.85     ),
            new VSOP87Coefficient( 30,        2.74,      1349.87      ),
            new VSOP87Coefficient( 25,        3.16,      4690.48      )
        };

        static VSOP87Coefficient[] g_L1EarthCoefficients =
        {
            new VSOP87Coefficient( 628331966747.0, 0,          0           ),
            new VSOP87Coefficient( 206059,         2.678235,   6283.075850 ),
            new VSOP87Coefficient( 4303,           2.6351,     12566.1517  ),
            new VSOP87Coefficient( 425,            1.590,      3.523       ),
            new VSOP87Coefficient( 119,            5.796,      26.298      ),
            new VSOP87Coefficient( 109,            2.966,      1577.344    ),
            new VSOP87Coefficient( 93,             2.59,       18849.23    ),
            new VSOP87Coefficient( 72,             1.14,       529.69      ),
            new VSOP87Coefficient( 68,             1.87,       398.15      ),
            new VSOP87Coefficient( 67,             4.41,       5507.55     ),
            new VSOP87Coefficient( 59,             2.89,       5223.69     ),
            new VSOP87Coefficient( 56,             2.17,       155.42      ),
            new VSOP87Coefficient( 45,             0.40,       796.30      ),
            new VSOP87Coefficient( 36,             0.47,       775.52      ),
            new VSOP87Coefficient( 29,             2.65,       7.11        ),
            new VSOP87Coefficient( 21,             5.34,       0.98        ),
            new VSOP87Coefficient( 19,             1.85,       5486.78     ),
            new VSOP87Coefficient( 19,             4.97,       213.30      ),
            new VSOP87Coefficient( 17,             2.99,       6275.96     ),
            new VSOP87Coefficient( 16,             0.03,       2544.31     ),
            new VSOP87Coefficient( 16,             1.43,       2146.17     ),
            new VSOP87Coefficient( 15,             1.21,       10977.08    ),
            new VSOP87Coefficient( 12,             2.83,       1748.02     ),
            new VSOP87Coefficient( 12,             3.26,       5088.63     ),
            new VSOP87Coefficient( 12,             5.27,       1194.45     ),
            new VSOP87Coefficient( 12,             2.08,       4694.00     ),
            new VSOP87Coefficient( 11,             0.77,       553.57      ),
            new VSOP87Coefficient( 10,             1.30,       6286.60     ),
            new VSOP87Coefficient( 10,             4.24,       1349.87     ),
            new VSOP87Coefficient( 9,              2.70,       242.73      ),
            new VSOP87Coefficient( 9,              5.64,       951.72      ),
            new VSOP87Coefficient( 8,              5.30,       2352.87     ),
            new VSOP87Coefficient( 6,              2.65,       9437.76     ),
            new VSOP87Coefficient( 6,              4.67,       4690.48     )
        };

        static VSOP87Coefficient[] g_L2EarthCoefficients =
        {
            new VSOP87Coefficient( 52919,  0,      0         ),
            new VSOP87Coefficient( 8720,   1.0721, 6283.0758 ),
            new VSOP87Coefficient( 309,    0.867,  12566.152 ),
            new VSOP87Coefficient( 27,     0.05,   3.52      ),
            new VSOP87Coefficient( 16,     5.19,   26.30     ),
            new VSOP87Coefficient( 16,     3.68,   155.42    ),
            new VSOP87Coefficient( 10,     0.76,   18849.23  ),
            new VSOP87Coefficient( 9,      2.06,   77713.77  ),
            new VSOP87Coefficient( 7,      0.83,   775.52    ),
            new VSOP87Coefficient( 5,      4.66,   1577.34   ),
            new VSOP87Coefficient( 4,      1.03,   7.11      ),
            new VSOP87Coefficient( 4,      3.44,   5573.14   ),
            new VSOP87Coefficient( 3,      5.14,   796.30    ),
            new VSOP87Coefficient( 3,      6.05,   5507.55   ),
            new VSOP87Coefficient( 3,      1.19,   242.73    ),
            new VSOP87Coefficient( 3,      6.12,   529.69    ),
            new VSOP87Coefficient( 3,      0.31,   398.15    ),
            new VSOP87Coefficient( 3,      2.28,   553.57    ),
            new VSOP87Coefficient( 2,      4.38,   5223.69   ),
            new VSOP87Coefficient( 2,      3.75,   0.98      )
        };

        static VSOP87Coefficient[] g_L3EarthCoefficients =
        {
            new VSOP87Coefficient( 289, 5.844, 6283.076 ),
            new VSOP87Coefficient( 35,  0,     0        ),
            new VSOP87Coefficient( 17,  5.49,  12566.15 ),
            new VSOP87Coefficient( 3,   5.20,  155.42   ),
            new VSOP87Coefficient( 1,   4.72,  3.52     ),
            new VSOP87Coefficient( 1,   5.30,  18849.23 ),
            new VSOP87Coefficient( 1,   5.97,  242.73   )
        };

        static VSOP87Coefficient[] g_L4EarthCoefficients =
        {
            new VSOP87Coefficient( 114, 3.142,  0        ),
            new VSOP87Coefficient( 8,   4.13,   6283.08  ),
            new VSOP87Coefficient( 1,   3.84,   12566.15 )
        };

        static VSOP87Coefficient[] g_L5EarthCoefficients =
        {
            new VSOP87Coefficient( 1, 3.14, 0 ) 
        };


        static VSOP87Coefficient[] g_B0EarthCoefficients =
        {
            new VSOP87Coefficient( 280, 3.199, 84334.662 ),
            new VSOP87Coefficient( 102, 5.422, 5507.553  ),
            new VSOP87Coefficient( 80,  3.88,  5223.69   ),
            new VSOP87Coefficient( 44,  3.70,  2352.87   ),
            new VSOP87Coefficient( 32,  4.00,  1577.34   )
        };

        static VSOP87Coefficient[] g_B1EarthCoefficients =
        {
            new VSOP87Coefficient( 9, 3.90, 5507.55 ),
            new VSOP87Coefficient( 6, 1.73, 5223.69 )
        };


        static VSOP87Coefficient[] g_R0EarthCoefficients =
        {
            new VSOP87Coefficient( 100013989,  0,          0            ),
            new VSOP87Coefficient( 1670700,    3.0984635,  6283.0758500 ),
            new VSOP87Coefficient( 13956,      3.05525,    12566.15170  ),
            new VSOP87Coefficient( 3084,       5.1985,     77713.7715   ),
            new VSOP87Coefficient( 1628,       1.1739,     5753.3849    ),
            new VSOP87Coefficient( 1576,       2.8469,     7860.4194    ),
            new VSOP87Coefficient( 925,        5.453,      11506.770    ),
            new VSOP87Coefficient( 542,        4.564,      3930.210     ),
            new VSOP87Coefficient( 472,        3.661,      5884.927     ),
            new VSOP87Coefficient( 346,        0.964,      5507.553     ),
            new VSOP87Coefficient( 329,        5.900,      5223.694     ),
            new VSOP87Coefficient( 307,        0.299,      5573.143     ),
            new VSOP87Coefficient( 243,        4.273,      11790.629    ),
            new VSOP87Coefficient( 212,        5.847,      1577.344     ),
            new VSOP87Coefficient( 186,        5.022,      10977.079    ),
            new VSOP87Coefficient( 175,        3.012,      18849.228    ),
            new VSOP87Coefficient( 110,        5.055,      5486.778     ),
            new VSOP87Coefficient( 98,         0.89,       6069.78      ),
            new VSOP87Coefficient( 86,         5.69,       15720.84     ),
            new VSOP87Coefficient( 86,         1.27,       161000.69    ),
            new VSOP87Coefficient( 65,         0.27,       17260.15     ),
            new VSOP87Coefficient( 63,         0.92,       529.69       ),
            new VSOP87Coefficient( 57,         2.01,       83996.85     ),
            new VSOP87Coefficient( 56,         5.24,       71430.70     ),
            new VSOP87Coefficient( 49,         3.25,       2544.31      ),
            new VSOP87Coefficient( 47,         2.58,       775.52       ),
            new VSOP87Coefficient( 45,         5.54,       9437.76      ),
            new VSOP87Coefficient( 43,         6.01,       6275.96      ),
            new VSOP87Coefficient( 39,         5.36,       4694.00      ),
            new VSOP87Coefficient( 38,         2.39,       8827.39      ),
            new VSOP87Coefficient( 37,         0.83,       19651.05     ),
            new VSOP87Coefficient( 37,         4.90,       12139.55     ),
            new VSOP87Coefficient( 36,         1.67,       12036.46     ),
            new VSOP87Coefficient( 35,         1.84,       2942.46      ),
            new VSOP87Coefficient( 33,         0.24,       7084.90      ),
            new VSOP87Coefficient( 32,         0.18,       5088.63      ),
            new VSOP87Coefficient( 32,         1.78,       398.15       ),
            new VSOP87Coefficient( 28,         1.21,       6286.60      ),
            new VSOP87Coefficient( 28,         1.90,       6279.55      ),
            new VSOP87Coefficient( 26,         4.59,       10447.39     )
        };

        static VSOP87Coefficient[] g_R1EarthCoefficients =
        {
            new VSOP87Coefficient( 103019, 1.107490, 6283.075850 ),
            new VSOP87Coefficient( 1721,   1.0644,   12566.1517  ),
            new VSOP87Coefficient( 702,    3.142,    0           ),
            new VSOP87Coefficient( 32,     1.02,     18849.23    ),
            new VSOP87Coefficient( 31,     2.84,     5507.55     ),
            new VSOP87Coefficient( 25,     1.32,     5223.69     ),
            new VSOP87Coefficient( 18,     1.42,     1577.34     ),
            new VSOP87Coefficient( 10,     5.91,     10977.08    ),
            new VSOP87Coefficient( 9,      1.42,     6275.96     ),
            new VSOP87Coefficient( 9,      0.27,     5486.78     ) 
        };

        static VSOP87Coefficient[] g_R2EarthCoefficients =
        {
            new VSOP87Coefficient( 4359, 5.7846, 6283.0758 ),
            new VSOP87Coefficient( 124,  5.579,  12566.152 ),
            new VSOP87Coefficient( 12,   3.14,   0         ),
            new VSOP87Coefficient( 9,    3.63,   77713.77  ),
            new VSOP87Coefficient( 6,    1.87,   5573.14   ),
            new VSOP87Coefficient( 3,    5.47,   18849.23  ) 
        };

        static VSOP87Coefficient[] g_R3EarthCoefficients =
        {
            new VSOP87Coefficient( 145,  4.273,  6283.076 ),
            new VSOP87Coefficient( 7,    3.92,   12566.15 )
        };

        static VSOP87Coefficient[] g_R4EarthCoefficients =
        {
            new VSOP87Coefficient( 4, 2.56, 6283.08 )
        };


        static VSOP87Coefficient[] g_L1EarthCoefficientsJ2000 =
        {
            new VSOP87Coefficient( 628307584999.0, 0,          0           ),
            new VSOP87Coefficient( 206059,         2.678235,   6283.075850 ),
            new VSOP87Coefficient( 4303,           2.6351,     12566.1517  ),
            new VSOP87Coefficient( 425,            1.590,      3.523       ),
            new VSOP87Coefficient( 119,            5.796,      26.298      ),
            new VSOP87Coefficient( 109,            2.966,      1577.344    ),
            new VSOP87Coefficient( 93,             2.59,       18849.23    ),
            new VSOP87Coefficient( 72,             1.14,       529.69      ),
            new VSOP87Coefficient( 68,             1.87,       398.15      ),
            new VSOP87Coefficient( 67,             4.41,       5507.55     ),
            new VSOP87Coefficient( 59,             2.89,       5223.69     ),
            new VSOP87Coefficient( 56,             2.17,       155.42      ),
            new VSOP87Coefficient( 45,             0.40,       796.30      ),
            new VSOP87Coefficient( 36,             0.47,       775.52      ),
            new VSOP87Coefficient( 29,             2.65,       7.11        ),
            new VSOP87Coefficient( 21,             5.43,       0.98        ),
            new VSOP87Coefficient( 19,             1.85,       5486.78     ),
            new VSOP87Coefficient( 19,             4.97,       213.30      ),
            new VSOP87Coefficient( 17,             2.99,       6275.96     ),
            new VSOP87Coefficient( 16,             0.03,       2544.31     ),
            new VSOP87Coefficient( 16,             1.43,       2146.17     ),
            new VSOP87Coefficient( 15,             1.21,       10977.08    ),
            new VSOP87Coefficient( 12,             2.83,       1748.02     ),
            new VSOP87Coefficient( 12,             3.26,       5088.63     ),
            new VSOP87Coefficient( 12,             5.27,       1194.45     ),
            new VSOP87Coefficient( 12,             2.08,       4694.00     ),
            new VSOP87Coefficient( 11,             0.77,       553.57      ),
            new VSOP87Coefficient( 10,             1.30,       6286.60     ),
            new VSOP87Coefficient( 10,             4.24,       1349.87     ),
            new VSOP87Coefficient( 9,              2.70,       242.73      ),
            new VSOP87Coefficient( 9,              5.64,       951.72      ),
            new VSOP87Coefficient( 8,              5.30,       2352.87     ),
            new VSOP87Coefficient( 6,              2.65,       9437.76     ),
            new VSOP87Coefficient( 6,              4.67,       4690.48     )
        };

        static VSOP87Coefficient[] g_L2EarthCoefficientsJ2000 =
        {
            new VSOP87Coefficient( 8722, 1.0725, 6283.0758 ),
            new VSOP87Coefficient( 991,  3.1416, 0         ),
            new VSOP87Coefficient( 295,  0.437,  12566.152 ),
            new VSOP87Coefficient( 27,   0.05,   3.52      ),
            new VSOP87Coefficient( 16,   5.19,   26.30     ),
            new VSOP87Coefficient( 16,   3.69,   155.42    ),
            new VSOP87Coefficient( 9,    0.30,   18849.23  ),
            new VSOP87Coefficient( 9,    2.06,   77713.77  ),
            new VSOP87Coefficient( 7,    0.83,   775.52    ),
            new VSOP87Coefficient( 5,    4.66,   1577.34   ),
            new VSOP87Coefficient( 4,    1.03,   7.11      ),
            new VSOP87Coefficient( 4,    3.44,   5573.14   ),
            new VSOP87Coefficient( 3,    5.14,   796.30    ),
            new VSOP87Coefficient( 3,    6.05,   5507.55   ),
            new VSOP87Coefficient( 3,    1.19,   242.73    ),
            new VSOP87Coefficient( 3,    6.12,   529.69    ),
            new VSOP87Coefficient( 3,    0.30,   398.15    ),
            new VSOP87Coefficient( 3,    2.28,   553.57    ),
            new VSOP87Coefficient( 2,    4.38,   5223.69   ),
            new VSOP87Coefficient( 2,    3.75,   0.98      )
        };

        static VSOP87Coefficient[] g_L3EarthCoefficientsJ2000 =
        {
            new VSOP87Coefficient( 289,  5.842,  6283.076 ),
            new VSOP87Coefficient( 21,   6.05,   12566.15 ),
            new VSOP87Coefficient( 3,    5.20,   155.42 ),
            new VSOP87Coefficient( 3,    3.14,   0 ),
            new VSOP87Coefficient( 1,    4.72,   3.52 ),
            new VSOP87Coefficient( 1,    5.97,   242.73 ),
            new VSOP87Coefficient( 1,    5.54,   18849.23 )
        };

        static VSOP87Coefficient[] g_L4EarthCoefficientsJ2000 =
        {
            new VSOP87Coefficient( 8,  4.14, 6283.08 ),
            new VSOP87Coefficient( 1,  3.28, 12566.15 )
        };



        static VSOP87Coefficient[] g_B1EarthCoefficientsJ2000 =
        {
            new VSOP87Coefficient( 227778, 3.413766, 6283.075850 ),
            new VSOP87Coefficient( 3806,   3.3706,   12566.1517  ),
            new VSOP87Coefficient( 3620,   0,        0           ),
            new VSOP87Coefficient( 72,     3.33,     18849.23    ),
            new VSOP87Coefficient( 8,      3.89,     5507.55     ),
            new VSOP87Coefficient( 8,      1.79,     5223.69     ),
            new VSOP87Coefficient( 6,      5.20,     2352.87     )
        };

        static VSOP87Coefficient[] g_B2EarthCoefficientsJ2000 =
        {
            new VSOP87Coefficient( 9721, 5.1519, 6283.07585 ),
            new VSOP87Coefficient( 233,  3.1416, 0 ),
            new VSOP87Coefficient( 134,  0.644,  12566.152 ),
            new VSOP87Coefficient( 7,    1.07,   18849.23 )
        };

        static VSOP87Coefficient[] g_B3EarthCoefficientsJ2000 =
        {
            new VSOP87Coefficient( 276,  0.595,  6283.076 ),
            new VSOP87Coefficient( 17,   3.14,   0 ),
            new VSOP87Coefficient( 4,    0.12,   12566.15 )
        };

        static VSOP87Coefficient[] g_B4EarthCoefficientsJ2000 =
        {
            new VSOP87Coefficient( 6,  2.27, 6283.08 ),
            new VSOP87Coefficient( 1,  0,    0 )
        };
        
        #endregion

        public static double EclipticLongitude(double JD, bool bHighPrecision)
        {
            if (bHighPrecision)
            {
                return AASCoordinateTransformation.MapTo0To360Range(AASCoordinateTransformation.RadiansToDegrees(AASVSOP87D_Earth.L(JD)));
            }

            double rho = (JD - 2451545) / 365250;
            double rhosquared = rho * rho;
            double rhocubed = rhosquared * rho;
            double rho4 = rhocubed * rho;
            double rho5 = rho4 * rho;

            //Calculate L0
            int nL0Coefficients = g_L0EarthCoefficients.Length;
            double L0 = 0;
            int i;
            for (i = 0; i < nL0Coefficients; i++)
                L0 += g_L0EarthCoefficients[i].A * Math.Cos(g_L0EarthCoefficients[i].B + g_L0EarthCoefficients[i].C * rho);

            //Calculate L1
            int nL1Coefficients = g_L1EarthCoefficients.Length;
            double L1 = 0;
            for (i = 0; i < nL1Coefficients; i++)
                L1 += g_L1EarthCoefficients[i].A * Math.Cos(g_L1EarthCoefficients[i].B + g_L1EarthCoefficients[i].C * rho);

            //Calculate L2
            int nL2Coefficients = g_L2EarthCoefficients.Length;
            double L2 = 0;
            for (i = 0; i < nL2Coefficients; i++)
                L2 += g_L2EarthCoefficients[i].A * Math.Cos(g_L2EarthCoefficients[i].B + g_L2EarthCoefficients[i].C * rho);

            //Calculate L3
            int nL3Coefficients = g_L3EarthCoefficients.Length;
            double L3 = 0;
            for (i = 0; i < nL3Coefficients; i++)
                L3 += g_L3EarthCoefficients[i].A * Math.Cos(g_L3EarthCoefficients[i].B + g_L3EarthCoefficients[i].C * rho);

            //Calculate L4
            int nL4Coefficients = g_L4EarthCoefficients.Length;
            double L4 = 0;
            for (i = 0; i < nL4Coefficients; i++)
                L4 += g_L4EarthCoefficients[i].A * Math.Cos(g_L4EarthCoefficients[i].B + g_L4EarthCoefficients[i].C * rho);

            //Calculate L5
            int nL5Coefficients = g_L5EarthCoefficients.Length;
            double L5 = 0;
            for (i = 0; i < nL5Coefficients; i++)
                L5 += g_L5EarthCoefficients[i].A * Math.Cos(g_L5EarthCoefficients[i].B + g_L5EarthCoefficients[i].C * rho);

            double value = (L0 + L1 * rho + L2 * rhosquared + L3 * rhocubed + L4 * rho4 + L5 * rho5) / 100000000;

            //convert results back to degrees
            value = AASCoordinateTransformation.MapTo0To360Range(AASCoordinateTransformation.RadiansToDegrees(value));
            return value;
        }

        public static double EclipticLatitude(double JD, bool bHighPrecision)
        {
            if (bHighPrecision)
            {
                return AASCoordinateTransformation.MapToMinus90To90Range(AASCoordinateTransformation.RadiansToDegrees(AASVSOP87D_Earth.B(JD)));
            }
            
            double rho = (JD - 2451545) / 365250;

            //Calculate B0
            int nB0Coefficients = g_B0EarthCoefficients.Length;
            double B0 = 0;
            int i;
            for (i = 0; i < nB0Coefficients; i++)
                B0 += g_B0EarthCoefficients[i].A * Math.Cos(g_B0EarthCoefficients[i].B + g_B0EarthCoefficients[i].C * rho);

            //Calculate B1
            int nB1Coefficients = g_B1EarthCoefficients.Length;
            double B1 = 0;
            for (i = 0; i < nB1Coefficients; i++)
                B1 += g_B1EarthCoefficients[i].A * Math.Cos(g_B1EarthCoefficients[i].B + g_B1EarthCoefficients[i].C * rho);

            //Note for Earth there are no B2, B3 or B4 coefficients to calculate

            double value = (B0 + B1 * rho) / 100000000;

            //convert results back to degrees
            value = AASCoordinateTransformation.RadiansToDegrees(value);
            return value;
        }

        public static double RadiusVector(double JD, bool bHighPrecision)
        {
            if (bHighPrecision)
            {
                return AASVSOP87D_Earth.R(JD);
            }
            
            double rho = (JD - 2451545) / 365250;
            double rhosquared = rho * rho;
            double rhocubed = rhosquared * rho;
            double rho4 = rhocubed * rho;

            //Calculate R0
            int nR0Coefficients = g_R0EarthCoefficients.Length;
            double R0 = 0;
            int i;
            for (i = 0; i < nR0Coefficients; i++)
                R0 += g_R0EarthCoefficients[i].A * Math.Cos(g_R0EarthCoefficients[i].B + g_R0EarthCoefficients[i].C * rho);

            //Calculate R1
            int nR1Coefficients = g_R1EarthCoefficients.Length;
            double R1 = 0;
            for (i = 0; i < nR1Coefficients; i++)
                R1 += g_R1EarthCoefficients[i].A * Math.Cos(g_R1EarthCoefficients[i].B + g_R1EarthCoefficients[i].C * rho);

            //Calculate R2
            int nR2Coefficients = g_R2EarthCoefficients.Length;
            double R2 = 0;
            for (i = 0; i < nR2Coefficients; i++)
                R2 += g_R2EarthCoefficients[i].A * Math.Cos(g_R2EarthCoefficients[i].B + g_R2EarthCoefficients[i].C * rho);

            //Calculate R3
            int nR3Coefficients = g_R3EarthCoefficients.Length;
            double R3 = 0;
            for (i = 0; i < nR3Coefficients; i++)
                R3 += g_R3EarthCoefficients[i].A * Math.Cos(g_R3EarthCoefficients[i].B + g_R3EarthCoefficients[i].C * rho);

            //Calculate R4
            int nR4Coefficients = g_R4EarthCoefficients.Length;
            double R4 = 0;
            for (i = 0; i < nR4Coefficients; i++)
                R4 += g_R4EarthCoefficients[i].A * Math.Cos(g_R4EarthCoefficients[i].B + g_R4EarthCoefficients[i].C * rho);

            return (R0 + R1 * rho + R2 * rhosquared + R3 * rhocubed + R4 * rho4) / 100000000;
        }

        public static double EclipticLongitudeJ2000(double JD, bool bHighPrecision)
        {
            if (bHighPrecision)
            {
                return AASCoordinateTransformation.MapTo0To360Range(AASCoordinateTransformation.RadiansToDegrees(AASVSOP87B_Earth.L(JD)));
            }
            
            double rho = (JD - 2451545) / 365250;
            double rhosquared = rho * rho;
            double rhocubed = rhosquared * rho;
            double rho4 = rhocubed * rho;

            //Calculate L0
            int nL0Coefficients = g_L0EarthCoefficients.Length;
            double L0 = 0;
            int i;
            for (i = 0; i < nL0Coefficients; i++)
                L0 += g_L0EarthCoefficients[i].A * Math.Cos(g_L0EarthCoefficients[i].B + g_L0EarthCoefficients[i].C * rho);

            //Calculate L1
            int nL1Coefficients = g_L1EarthCoefficientsJ2000.Length;
            double L1 = 0;
            for (i = 0; i < nL1Coefficients; i++)
                L1 += g_L1EarthCoefficientsJ2000[i].A * Math.Cos(g_L1EarthCoefficientsJ2000[i].B + g_L1EarthCoefficientsJ2000[i].C * rho);

            //Calculate L2
            int nL2Coefficients = g_L2EarthCoefficientsJ2000.Length;
            double L2 = 0;
            for (i = 0; i < nL2Coefficients; i++)
                L2 += g_L2EarthCoefficientsJ2000[i].A * Math.Cos(g_L2EarthCoefficientsJ2000[i].B + g_L2EarthCoefficientsJ2000[i].C * rho);

            //Calculate L3
            int nL3Coefficients = g_L3EarthCoefficientsJ2000.Length;
            double L3 = 0;
            for (i = 0; i < nL3Coefficients; i++)
                L3 += g_L3EarthCoefficientsJ2000[i].A * Math.Cos(g_L3EarthCoefficientsJ2000[i].B + g_L3EarthCoefficientsJ2000[i].C * rho);

            //Calculate L4
            int nL4Coefficients = g_L4EarthCoefficientsJ2000.Length;
            double L4 = 0;
            for (i = 0; i < nL4Coefficients; i++)
                L4 += g_L4EarthCoefficientsJ2000[i].A * Math.Cos(g_L4EarthCoefficientsJ2000[i].B + g_L4EarthCoefficientsJ2000[i].C * rho);

            double value = (L0 + L1 * rho + L2 * rhosquared + L3 * rhocubed + L4 * rho4) / 100000000;

            //convert results back to degrees
            value = AASCoordinateTransformation.MapTo0To360Range(AASCoordinateTransformation.RadiansToDegrees(value));
            return value;
        }

        public static double EclipticLatitudeJ2000(double JD, bool bHighPrecision)
        {
            if (bHighPrecision)
            {
                return AASCoordinateTransformation.MapToMinus90To90Range(AASCoordinateTransformation.RadiansToDegrees(AASVSOP87B_Earth.B(JD)));
            }
            
            double rho = (JD - 2451545) / 365250;
            double rhosquared = rho * rho;
            double rhocubed = rhosquared * rho;
            double rho4 = rhocubed * rho;

            //Calculate B0
            int nB0Coefficients = g_B0EarthCoefficients.Length;
            double B0 = 0;
            int i;
            for (i = 0; i < nB0Coefficients; i++)
                B0 += g_B0EarthCoefficients[i].A * Math.Cos(g_B0EarthCoefficients[i].B + g_B0EarthCoefficients[i].C * rho);

            //Calculate B1
            int nB1Coefficients = g_B1EarthCoefficientsJ2000.Length;
            double B1 = 0;
            for (i = 0; i < nB1Coefficients; i++)
                B1 += g_B1EarthCoefficientsJ2000[i].A * Math.Cos(g_B1EarthCoefficientsJ2000[i].B + g_B1EarthCoefficientsJ2000[i].C * rho);

            //Calculate B2
            int nB2Coefficients = g_B2EarthCoefficientsJ2000.Length;
            double B2 = 0;
            for (i = 0; i < nB2Coefficients; i++)
                B2 += g_B2EarthCoefficientsJ2000[i].A * Math.Cos(g_B2EarthCoefficientsJ2000[i].B + g_B2EarthCoefficientsJ2000[i].C * rho);

            //Calculate B3
            int nB3Coefficients = g_B3EarthCoefficientsJ2000.Length;
            double B3 = 0;
            for (i = 0; i < nB3Coefficients; i++)
                B3 += g_B3EarthCoefficientsJ2000[i].A * Math.Cos(g_B3EarthCoefficientsJ2000[i].B + g_B3EarthCoefficientsJ2000[i].C * rho);

            //Calculate B4
            int nB4Coefficients = g_B4EarthCoefficientsJ2000.Length;
            double B4 = 0;
            for (i = 0; i < nB4Coefficients; i++)
                B4 += g_B4EarthCoefficientsJ2000[i].A * Math.Cos(g_B4EarthCoefficientsJ2000[i].B + g_B4EarthCoefficientsJ2000[i].C * rho);

            double value = (B0 + B1 * rho + B2 * rhosquared + B3 * rhocubed + B4 * rho4) / 100000000;

            //convert results back to degrees
            value = AASCoordinateTransformation.RadiansToDegrees(value);
            return value;
        }

        public static double SunMeanAnomaly(double JD)
        {
            double T = (JD - 2451545) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
            return AASCoordinateTransformation.MapTo0To360Range(357.5291092 + 35999.0502909 * T - 0.0001536 * Tsquared + Tcubed / 24490000);
        }

        public static double Eccentricity(double JD)
        {
            double T = (JD - 2451545) / 36525;
            double Tsquared = T * T;
            return 1 - 0.002516 * T - 0.0000074 * Tsquared;
        }
    }
}
