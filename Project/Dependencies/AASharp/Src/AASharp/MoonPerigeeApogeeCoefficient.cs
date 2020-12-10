using System;

namespace AASharp
{
    internal struct MoonPerigeeApogeeCoefficient
    {
        internal MoonPerigeeApogeeCoefficient(int d, int m, int f, double c, double t)
        {
            D = d;
            M = m;
            F = f;
            C = c;
            T = t;
        }

        public int D { get; }
        public int M { get; }
        public int F { get; }
        public double C { get; }
        public double T { get; }
    }
    
    public static class AASMoonPerigeeApogee
    {
        #region coefficients
        
        static readonly MoonPerigeeApogeeCoefficient[] g_MoonPerigeeApogeeCoefficients1 =
        { 
            new MoonPerigeeApogeeCoefficient( 2,  0,  0,  -1.6769,  0 ),
            new MoonPerigeeApogeeCoefficient( 4,  0,  0,  0.4589,   0 ),
            new MoonPerigeeApogeeCoefficient( 6,  0,  0,  -0.1856,  0 ),
            new MoonPerigeeApogeeCoefficient( 8,  0,  0,  0.0883,   0 ),
            new MoonPerigeeApogeeCoefficient( 2,  -1, 0,  -0.0773,  0.00019 ),
            new MoonPerigeeApogeeCoefficient( 0,  1,  0,  0.0502,   -0.00013 ),
            new MoonPerigeeApogeeCoefficient( 10, 0,  0,  -0.0460,  0 ),
            new MoonPerigeeApogeeCoefficient( 4,  -1, 0,  0.0422,   -0.00011 ),
            new MoonPerigeeApogeeCoefficient( 6,  -1, 0,  -0.0256,  0 ),
            new MoonPerigeeApogeeCoefficient( 12, 0,  0,  0.0253,   0 ),
            new MoonPerigeeApogeeCoefficient( 1,  0,  0,  0.0237,   0 ),
            new MoonPerigeeApogeeCoefficient( 8,  -1, 0,  0.0162,   0 ),
            new MoonPerigeeApogeeCoefficient( 14, 0,  0,  -0.0145,  0 ),
            new MoonPerigeeApogeeCoefficient( 0,  0,  2,  0.0129,   0 ),
            new MoonPerigeeApogeeCoefficient( 3,  0,  0,  -0.0112,  0 ),
            new MoonPerigeeApogeeCoefficient( 10, -1, 0,  -0.0104,  0 ),
            new MoonPerigeeApogeeCoefficient( 16, 0,  0,  0.0086,   0 ),
            new MoonPerigeeApogeeCoefficient( 12, -1, 0,  0.0069,   0 ),
            new MoonPerigeeApogeeCoefficient( 5,  0,  0,  0.0066,   0 ),
            new MoonPerigeeApogeeCoefficient( 2,  0,  2,  -0.0053,  0 ),
            new MoonPerigeeApogeeCoefficient( 18, 0,  0,  -0.0052,  0 ),
            new MoonPerigeeApogeeCoefficient( 14, -1, 0,  -0.0046,  0 ),
            new MoonPerigeeApogeeCoefficient( 7,  0,  0,  -0.0041,  0 ),
            new MoonPerigeeApogeeCoefficient( 2,  1,  0,  0.0040,   0 ),
            new MoonPerigeeApogeeCoefficient( 20, 0,  0,  0.0032,   0 ),
            new MoonPerigeeApogeeCoefficient( 1,  1,  0,  -0.0032,  0 ),
            new MoonPerigeeApogeeCoefficient( 16, -1, 0,  0.0031,   0 ),
            new MoonPerigeeApogeeCoefficient( 4,  1,  0,  -0.0029,  0 ),
            new MoonPerigeeApogeeCoefficient( 9,  0,  0,  0.0027,   0 ),
            new MoonPerigeeApogeeCoefficient( 4,  0,  2,  0.0027,   0 ),
            new MoonPerigeeApogeeCoefficient( 2,  -2, 0,  -0.0027,  0 ),
            new MoonPerigeeApogeeCoefficient( 4,  -2, 0,  0.0024,   0 ),
            new MoonPerigeeApogeeCoefficient( 6,  -2, 0,  -0.0021,  0 ),
            new MoonPerigeeApogeeCoefficient( 22, 0,  0,  -0.0021,  0 ),
            new MoonPerigeeApogeeCoefficient( 18, -1, 0,  -0.0021,  0 ),
            new MoonPerigeeApogeeCoefficient( 6,  1,  0,  0.0019,   0 ),
            new MoonPerigeeApogeeCoefficient( 11, 0,  0,  -0.0018,  0 ),
            new MoonPerigeeApogeeCoefficient( 8,  1,  0,  -0.0014,  0 ),
            new MoonPerigeeApogeeCoefficient( 4,  0,  -2, -0.0014,  0 ),
            new MoonPerigeeApogeeCoefficient( 6,  0,  2,  -0.0014,  0 ),
            new MoonPerigeeApogeeCoefficient( 3,  1,  0,  0.0014,   0 ),
            new MoonPerigeeApogeeCoefficient( 5,  1,  0,  -0.0014,  0 ),
            new MoonPerigeeApogeeCoefficient( 13, 0,  0,  0.0013,   0 ),
            new MoonPerigeeApogeeCoefficient( 20, -1, 0,  0.0013,   0 ),
            new MoonPerigeeApogeeCoefficient( 3,  2,  0,  0.0011,   0 ),
            new MoonPerigeeApogeeCoefficient( 4,  -2, 2,  -0.0011,  0 ),
            new MoonPerigeeApogeeCoefficient( 1,  2,  0,  -0.0010,  0 ),
            new MoonPerigeeApogeeCoefficient( 22, -1, 0,  -0.0009,  0 ),
            new MoonPerigeeApogeeCoefficient( 0,  0,  4,  -0.0008,  0 ),
            new MoonPerigeeApogeeCoefficient( 6,  0,  -2, 0.0008,   0 ),
            new MoonPerigeeApogeeCoefficient( 2,  1,  -2, 0.0008,   0 ),
            new MoonPerigeeApogeeCoefficient( 0,  2,  0 , 0.0007,   0 ),
            new MoonPerigeeApogeeCoefficient( 0,  -1, 2,  0.0007,   0 ),
            new MoonPerigeeApogeeCoefficient( 2,  0,  4,  0.0007,   0 ),
            new MoonPerigeeApogeeCoefficient( 0,  -2, 2,  -0.0006,  0 ),
            new MoonPerigeeApogeeCoefficient( 2,  2,  -2, -0.0006,  0 ),
            new MoonPerigeeApogeeCoefficient( 24, 0,  0,  0.0006,   0 ),
            new MoonPerigeeApogeeCoefficient( 4,  0,  -4, 0.0005,   0 ),
            new MoonPerigeeApogeeCoefficient( 2,  2,  0,  0.0005,   0 ),
            new MoonPerigeeApogeeCoefficient( 1,  -1, 0,  -0.0004,  0 )
        }; 
        
        static readonly MoonPerigeeApogeeCoefficient[] g_MoonPerigeeApogeeCoefficients2 =
        { 
            new MoonPerigeeApogeeCoefficient( 2,  0,  0,  0.4392,   0 ),
            new MoonPerigeeApogeeCoefficient( 4,  0,  0,  0.0684,   0 ),
            new MoonPerigeeApogeeCoefficient( 0,  1,  0,  0.0456,   -0.00011 ),
            new MoonPerigeeApogeeCoefficient( 2,  -1, 0,  0.0426,   -0.00011 ),
            new MoonPerigeeApogeeCoefficient( 0,  0,  2,  0.0212,   0 ),
            new MoonPerigeeApogeeCoefficient( 1,  0,  0,  -0.0189,  0 ),
            new MoonPerigeeApogeeCoefficient( 6,  0,  0,  0.0144,   0 ),
            new MoonPerigeeApogeeCoefficient( 4,  -1, 0,  0.0113,   0 ),
            new MoonPerigeeApogeeCoefficient( 2,  0,  2,  0.0047,   0 ),
            new MoonPerigeeApogeeCoefficient( 1,  1,  0,  0.0036,   0 ),
            new MoonPerigeeApogeeCoefficient( 8,  0,  0,  0.0035,   0 ),
            new MoonPerigeeApogeeCoefficient( 6,  -1, 0,  0.0034,   0 ),
            new MoonPerigeeApogeeCoefficient( 2,  0,  -2, -0.0034,  0 ),
            new MoonPerigeeApogeeCoefficient( 2,  -2, 0,  0.0022,   0 ),
            new MoonPerigeeApogeeCoefficient( 3,  0,  0,  -0.0017,  0 ),
            new MoonPerigeeApogeeCoefficient( 4,  0,  2,  0.0013,   0 ),
            new MoonPerigeeApogeeCoefficient( 8,  -1, 0,  0.0011,   0 ),
            new MoonPerigeeApogeeCoefficient( 4,  -2, 0,  0.0010,   0 ),
            new MoonPerigeeApogeeCoefficient( 10, 0,  0,  0.0009,   0 ),
            new MoonPerigeeApogeeCoefficient( 3,  1,  0,  0.0007,   0 ),
            new MoonPerigeeApogeeCoefficient( 0,  2,  0,  0.0006,   0 ),
            new MoonPerigeeApogeeCoefficient( 2,  1,  0,  0.0005,   0 ),
            new MoonPerigeeApogeeCoefficient( 2,  2,  0,  0.0005,   0 ),
            new MoonPerigeeApogeeCoefficient( 6,  0,  2,  0.0004,   0 ),
            new MoonPerigeeApogeeCoefficient( 6,  -2, 0,  0.0004,   0 ),
            new MoonPerigeeApogeeCoefficient( 10, -1, 0,  0.0004,   0 ),
            new MoonPerigeeApogeeCoefficient( 5,  0,  0,  -0.0004,  0 ),
            new MoonPerigeeApogeeCoefficient( 4,  0,  -2, -0.0004,  0 ),
            new MoonPerigeeApogeeCoefficient( 0,  1,  2,  0.0003,   0 ),
            new MoonPerigeeApogeeCoefficient( 12, 0,  0,  0.0003,   0 ),
            new MoonPerigeeApogeeCoefficient( 2,  -1, 2,  0.0003,   0 ),
            new MoonPerigeeApogeeCoefficient( 1,  -1, 0,  -0.0003,  0 )    
        };
        
        static readonly MoonPerigeeApogeeCoefficient[] g_MoonPerigeeApogeeCoefficients3 =
        { 
            new MoonPerigeeApogeeCoefficient( 2,  0,  0,   63.224,   0        ),
            new MoonPerigeeApogeeCoefficient( 4,  0,  0,   -6.990,   0        ),
            new MoonPerigeeApogeeCoefficient( 2,  -1, 0,   2.834,    -0.0071  ),
            new MoonPerigeeApogeeCoefficient( 6,  0,  0,   1.927,    0        ),
            new MoonPerigeeApogeeCoefficient( 1,  0,  0,   -1.263,   0        ),
            new MoonPerigeeApogeeCoefficient( 8,  0,  0,   -0.702,   0        ),
            new MoonPerigeeApogeeCoefficient( 0,  1,  0,   0.696,    -0.0017  ),
            new MoonPerigeeApogeeCoefficient( 0,  0,  2,   -0.690,   0        ),
            new MoonPerigeeApogeeCoefficient( 4,  -1, 0,   -0.629,   0.0016   ),
            new MoonPerigeeApogeeCoefficient( 2,  0,  -2,  -0.392,   0        ),
            new MoonPerigeeApogeeCoefficient( 10, 0,  0,   0.297,    0        ),
            new MoonPerigeeApogeeCoefficient( 6,  -1, 0,   0.260,    0        ),
            new MoonPerigeeApogeeCoefficient( 3,  0,  0,   0.201,    0        ),
            new MoonPerigeeApogeeCoefficient( 2,  1,  0,   -0.161,   0        ),
            new MoonPerigeeApogeeCoefficient( 1,  1,  0,   0.157,    0        ),
            new MoonPerigeeApogeeCoefficient( 12, 0,  0,   -0.138,   0        ),
            new MoonPerigeeApogeeCoefficient( 8,  -1, 0,   -0.127,   0        ),
            new MoonPerigeeApogeeCoefficient( 2,  0,  2,   0.104,    0        ),
            new MoonPerigeeApogeeCoefficient( 2,  -2, 0,   0.104,    0        ),
            new MoonPerigeeApogeeCoefficient( 5,  0,  0,   -0.079,   0        ),
            new MoonPerigeeApogeeCoefficient( 14, 0,  0,   0.068,    0        ),
            new MoonPerigeeApogeeCoefficient( 10, -1, 0,   0.067,    0        ),
            new MoonPerigeeApogeeCoefficient( 4,  1,  0,   0.054,    0        ),
            new MoonPerigeeApogeeCoefficient( 12, -1, 0,   -0.038,   0        ),
            new MoonPerigeeApogeeCoefficient( 4,  -2, 0,   -0.038,   0        ),
            new MoonPerigeeApogeeCoefficient( 7,  0,  0,   0.037,    0        ),
            new MoonPerigeeApogeeCoefficient( 4,  0,  2,   -0.037,   0        ),
            new MoonPerigeeApogeeCoefficient( 16, 0,  0,   -0.035,   0        ),
            new MoonPerigeeApogeeCoefficient( 3,  1,  0,   -0.030,   0        ),
            new MoonPerigeeApogeeCoefficient( 1,  -1, 0,   0.029,    0        ),
            new MoonPerigeeApogeeCoefficient( 6,  1,  0,   -0.025,   0        ),
            new MoonPerigeeApogeeCoefficient( 0,  2,  0,   0.023,    0        ),
            new MoonPerigeeApogeeCoefficient( 14, -1, 0,   0.023,    0        ),
            new MoonPerigeeApogeeCoefficient( 2,  2,  0,   -0.023,   0        ),
            new MoonPerigeeApogeeCoefficient( 6,  -2, 0,   0.022,    0        ),
            new MoonPerigeeApogeeCoefficient( 2,  -1, -2,  -0.021,   0        ),
            new MoonPerigeeApogeeCoefficient( 9,   0, 0,   -0.020,   0        ),
            new MoonPerigeeApogeeCoefficient( 18, 0,  0,   0.019,    0        ),
            new MoonPerigeeApogeeCoefficient( 6,  0,  2,   0.017,    0        ),
            new MoonPerigeeApogeeCoefficient( 0,  -1, 2,   0.014,    0        ),
            new MoonPerigeeApogeeCoefficient( 16, -1, 0,   -0.014,   0        ),
            new MoonPerigeeApogeeCoefficient( 4,  0,  -2,  0.013,    0        ), 
            new MoonPerigeeApogeeCoefficient( 8,  1,  0,   0.012,    0        ),
            new MoonPerigeeApogeeCoefficient( 11, 0,  0,   0.011,    0        ),
            new MoonPerigeeApogeeCoefficient( 5,  1,  0,   0.010,    0        ),
            new MoonPerigeeApogeeCoefficient( 20, 0,  0,   -0.010,   0        )
        };
        
        static readonly MoonPerigeeApogeeCoefficient[] g_MoonPerigeeApogeeCoefficients4 =
        {
            new MoonPerigeeApogeeCoefficient( 2,  0,  0,  -9.147,     0      ),
            new MoonPerigeeApogeeCoefficient( 1,  0,  0,  -0.841,     0      ),
            new MoonPerigeeApogeeCoefficient( 0,  0,  2,  0.697,      0      ),
            new MoonPerigeeApogeeCoefficient( 0,  1,  0,  -0.656,     0.0016 ),
            new MoonPerigeeApogeeCoefficient( 4,  0,  0,  0.355,      0      ),
            new MoonPerigeeApogeeCoefficient( 2,  -1, 0,  0.159,      0      ),
            new MoonPerigeeApogeeCoefficient( 1,  1,  0,  0.127,      0      ),
            new MoonPerigeeApogeeCoefficient( 4,  -1, 0,  0.065,      0      ),
            new MoonPerigeeApogeeCoefficient( 6,  0,  0,  0.052,      0      ),
            new MoonPerigeeApogeeCoefficient( 2,  1,  0,  0.043,      0      ),
            new MoonPerigeeApogeeCoefficient( 2,  0,  2,  0.031,      0      ),
            new MoonPerigeeApogeeCoefficient( 2,  0,  -2, -0.023,     0      ),
            new MoonPerigeeApogeeCoefficient( 2,  -2, 0,  0.022,      0      ),
            new MoonPerigeeApogeeCoefficient( 2,  2,  0,  0.019,      0      ),
            new MoonPerigeeApogeeCoefficient( 0,  2,  0,  -0.016,     0      ),
            new MoonPerigeeApogeeCoefficient( 6,  -1, 0,  0.014,      0      ),
            new MoonPerigeeApogeeCoefficient( 8,  0,  0,  0.010,      0      )   
        };
        
        #endregion
        

        public static double K(double Year)
        {
            return 13.2555 * (Year - 1999.97);
        }

        public static double MeanPerigee(double k)
        {
            //convert from K to T
            double T = k / 1325.55;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
            double T4 = Tcubed * T;

            return 2451534.6698 + 27.55454989 * k - 0.0006691 * Tsquared - 0.000001098 * Tcubed + 0.0000000052 * T4;
        }

        public static double MeanApogee(double k)
        {
            //Uses the same formula as MeanPerigee
            return MeanPerigee(k);
        }

        public static double TruePerigee(double k)
        {
            double MeanJD = MeanPerigee(k);

            //convert from K to T
            double T = k / 1325.55;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
            double T4 = Tcubed * T;

            double D = AASCoordinateTransformation.MapTo0To360Range(171.9179 + 335.9106046 * k - 0.0100383 * Tsquared - 0.00001156 * Tcubed + 0.000000055 * T4);
            D = AASCoordinateTransformation.DegreesToRadians(D);
            double M = AASCoordinateTransformation.MapTo0To360Range(347.3477 + 27.1577721 * k - 0.0008130 * Tsquared - 0.0000010 * Tcubed);
            M = AASCoordinateTransformation.DegreesToRadians(M);
            double F = AASCoordinateTransformation.MapTo0To360Range(316.6109 + 364.5287911 * k - 0.0125053 * Tsquared - 0.0000148 * Tcubed);
            F = AASCoordinateTransformation.DegreesToRadians(F);

            int nPerigeeCoefficients = g_MoonPerigeeApogeeCoefficients1.Length;
            double Sigma = 0;
            for (int i = 0; i < nPerigeeCoefficients; i++)
            {
                Sigma += (g_MoonPerigeeApogeeCoefficients1[i].C + T * g_MoonPerigeeApogeeCoefficients1[i].T) * Math.Sin(D * g_MoonPerigeeApogeeCoefficients1[i].D + M * g_MoonPerigeeApogeeCoefficients1[i].M +
                                                                                                                        F * g_MoonPerigeeApogeeCoefficients1[i].F);
            }

            return MeanJD + Sigma;
        }

        public static double PerigeeParallax(double k)
        {
            //convert from K to T
            double T = k / 1325.55;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
            double T4 = Tcubed * T;

            double D = AASCoordinateTransformation.MapTo0To360Range(171.9179 + 335.9106046 * k - 0.0100383 * Tsquared - 0.00001156 * Tcubed + 0.000000055 * T4);
            D = AASCoordinateTransformation.DegreesToRadians(D);
            double M = AASCoordinateTransformation.MapTo0To360Range(347.3477 + 27.1577721 * k - 0.0008130 * Tsquared - 0.0000010 * Tcubed);
            M = AASCoordinateTransformation.DegreesToRadians(M);
            double F = AASCoordinateTransformation.MapTo0To360Range(316.6109 + 364.5287911 * k - 0.0125053 * Tsquared - 0.0000148 * Tcubed);
            F = AASCoordinateTransformation.DegreesToRadians(F);

            int nPerigeeCoefficients = g_MoonPerigeeApogeeCoefficients3.Length;
            double Parallax = 3629.215;
            for (int i = 0; i < nPerigeeCoefficients; i++)
            {
                Parallax += (g_MoonPerigeeApogeeCoefficients3[i].C + T * g_MoonPerigeeApogeeCoefficients3[i].T) * Math.Cos(D * g_MoonPerigeeApogeeCoefficients3[i].D + M * g_MoonPerigeeApogeeCoefficients3[i].M +
                F * g_MoonPerigeeApogeeCoefficients3[i].F);
            }

            return Parallax / 3600;
        }

        public static double TrueApogee(double k)
        {
            double MeanJD = MeanApogee(k);

            //convert from K to T
            double T = k / 1325.55;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
            double T4 = Tcubed * T;

            double D = AASCoordinateTransformation.MapTo0To360Range(171.9179 + 335.9106046 * k - 0.0100383 * Tsquared - 0.00001156 * Tcubed + 0.000000055 * T4);
            D = AASCoordinateTransformation.DegreesToRadians(D);
            double M = AASCoordinateTransformation.MapTo0To360Range(347.3477 + 27.1577721 * k - 0.0008130 * Tsquared - 0.0000010 * Tcubed);
            M = AASCoordinateTransformation.DegreesToRadians(M);
            double F = AASCoordinateTransformation.MapTo0To360Range(316.6109 + 364.5287911 * k - 0.0125053 * Tsquared - 0.0000148 * Tcubed);
            F = AASCoordinateTransformation.DegreesToRadians(F);

            int nApogeeCoefficients = g_MoonPerigeeApogeeCoefficients2.Length;
            double Sigma = 0;
            for (int i = 0; i < nApogeeCoefficients; i++)
            {
                Sigma += (g_MoonPerigeeApogeeCoefficients2[i].C + T * g_MoonPerigeeApogeeCoefficients2[i].T) * Math.Sin(D * g_MoonPerigeeApogeeCoefficients2[i].D + M * g_MoonPerigeeApogeeCoefficients2[i].M +
                F * g_MoonPerigeeApogeeCoefficients2[i].F);
            }

            return MeanJD + Sigma;
        }

        public static double ApogeeParallax(double k)
        {
            //convert from K to T
            double T = k / 1325.55;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
            double T4 = Tcubed * T;

            double D = AASCoordinateTransformation.MapTo0To360Range(171.9179 + 335.9106046 * k - 0.0100383 * Tsquared - 0.00001156 * Tcubed + 0.000000055 * T4);
            D = AASCoordinateTransformation.DegreesToRadians(D);
            double M = AASCoordinateTransformation.MapTo0To360Range(347.3477 + 27.1577721 * k - 0.0008130 * Tsquared - 0.0000010 * Tcubed);
            M = AASCoordinateTransformation.DegreesToRadians(M);
            double F = AASCoordinateTransformation.MapTo0To360Range(316.6109 + 364.5287911 * k - 0.0125053 * Tsquared - 0.0000148 * Tcubed);
            F = AASCoordinateTransformation.DegreesToRadians(F);

            int nApogeeCoefficients = g_MoonPerigeeApogeeCoefficients4.Length;
            double Parallax = 3245.251;
            for (int i = 0; i < nApogeeCoefficients; i++)
            {
                Parallax += (g_MoonPerigeeApogeeCoefficients4[i].C + T * g_MoonPerigeeApogeeCoefficients4[i].T) * Math.Cos(D * g_MoonPerigeeApogeeCoefficients4[i].D + M * g_MoonPerigeeApogeeCoefficients4[i].M +
                F * g_MoonPerigeeApogeeCoefficients4[i].F);
            }

            return Parallax / 3600;
        }
    }
}
