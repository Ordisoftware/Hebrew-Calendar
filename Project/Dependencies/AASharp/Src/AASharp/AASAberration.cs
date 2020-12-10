using System;

namespace AASharp
{
    public static class AASAberration
    {
        #region coefficients
        
        static readonly AberrationCoefficient[] g_AberrationCoefficients =
        {
                                 //L2   L3   L4  L5  L6  L7  L8  Ldash D   Mdash F   xsin      xsint xcos    xcost ysin   ysint ycos     ycost zsin   zsint zcos    zcost
        new AberrationCoefficient(  0,  1,   0,  0,  0,  0,  0,  0,    0,  0,    0,  -1719914, -2,   -25,    0,    25,    -13,  1578089, 156,  10,    32,   684185, -358 ),
        new AberrationCoefficient(  0,  2,   0,  0,  0,  0,  0,  0,    0,  0,    0,  6434,     141,  28007,  -107, 25697, -95,  -5904,   -130, 11141, -48,  -2559,  -55  ),
        new AberrationCoefficient(  0,  0,   0,  1,  0,  0,  0,  0,    0,  0,    0,  715,      0,    0,      0,    6,     0,    -657,    0,    -15,   0,    -282,   0    ),
        new AberrationCoefficient(  0,  0,   0,  0,  0,  0,  0,  1,    0,  0,    0,  715,      0,    0,      0,    0,     0,    -656,    0,    0,     0,    -285,   0    ),
        new AberrationCoefficient(  0,  3,   0,  0,  0,  0,  0,  0,    0,  0,    0,  486,      -5,   -236,   -4,   -216,  -4,   -446,    5,    -94,   0,    -193,   0    ),
        new AberrationCoefficient(  0,  0,   0,  0,  1,  0,  0,  0,    0,  0,    0,  159,      0,    0,      0,    2,     0,    -147,    0,    -6,    0,    -61,    0    ),
        new AberrationCoefficient(  0,  0,   0,  0,  0,  0,  0,  0,    0,  0,    1,  0,        0,    0,      0,    0,     0,    26,      0,    0,     0,    -59,    0    ),
        new AberrationCoefficient(  0,  0,   0,  0,  0,  0,  0,  1,    0,  1,    0,  39,       0,    0,      0,    0,     0,    -36,     0,    0,     0,    -16,    0    ),
        new AberrationCoefficient(  0,  0,   0,  2,  0,  0,  0,  0,    0,  0,    0,  33,       0,    -10,    0,    -9,    0,    -30,     0,    -5,    0,    -13,    0    ),
        new AberrationCoefficient(  0,  2,   0,  -1, 0,  0,  0,  0,    0,  0,    0,  31,       0,    1,      0,    1,     0,    -28,     0,    0,     0,    -12,    0    ),
        new AberrationCoefficient(  0,  3,   -8, 3,  0,  0,  0,  0,    0,  0,    0,  8,        0,    -28,    0,    25,    0,    8,       0,    11,    0,    3,      0    ),
        new AberrationCoefficient(  0,  5,   -8, 3,  0,  0,  0,  0,    0,  0,    0,  8,        0,    -28,    0,    -25,   0,    -8,      0,    -11,   0,    -3,     0    ),
        new AberrationCoefficient(  2,  -1,  0,  0,  0,  0,  0,  0,    0,  0,    0,  21,       0,    0,      0,    0,     0,    -19,     0,    0,     0,    -8,     0    ),
        new AberrationCoefficient(  1,  0,   0,  0,  0,  0,  0,  0,    0,  0,    0,  -19,      0,    0,      0,    0,     0,    17,      0,    0,     0,    8,      0    ),
        new AberrationCoefficient(  0,  0,   0,  0,  0,  1,  0,  0,    0,  0,    0,  17,       0,    0,      0,    0,     0,    -16,     0,    0,     0,    -7,     0    ),
        new AberrationCoefficient(  0,  1,   0,  -2, 0,  0,  0,  0,    0,  0,    0,  16,       0,    0,      0,    0,     0,    15,      0,    1,     0,    7,      0    ),
        new AberrationCoefficient(  0,  0,   0,  0,  0,  0,  1,  0,    0,  0,    0,  16,       0,    0,      0,    1,     0,    -15,     0,    -3,    0,    -6,     0    ),
        new AberrationCoefficient(  0,  1,   0,  1,  0,  0,  0,  0,    0,  0,    0,  11,       0,    -1,     0,    -1,    0,    -10,     0,    -1,    0,    -5,     0    ),
        new AberrationCoefficient(  2,  -2,  0,  0,  0,  0,  0,  0,    0,  0,    0,  0,        0,    -11,    0,    -10,   0,    0,       0,    -4,    0,    0,      0    ),
        new AberrationCoefficient(  0,  1,   0,  -1, 0,  0,  0,  0,    0,  0,    0,  -11,      0,    -2,     0,    -2,    0,    9,       0,    -1,    0,    4,      0    ),
        new AberrationCoefficient(  0,  4,   0,  0,  0,  0,  0,  0,    0,  0,    0,  -7,       0,    -8,     0,    -8,    0,    6,       0,    -3,    0,    3,      0    ),
        new AberrationCoefficient(  0,  3,   0,  -2, 0,  0,  0,  0,    0,  0,    0,  -10,      0,    0,      0,    0,     0,    9,       0,    0,     0,    4,      0    ),
        new AberrationCoefficient(  1,  -2,  0,  0,  0,  0,  0,  0,    0,  0,    0,  -9,       0,    0,      0,    0,     0,    -9,      0,    0,     0,    -4,     0    ),
        new AberrationCoefficient(  2,  -3,  0,  0,  0,  0,  0,  0,    0,  0,    0,  -9,       0,    0,      0,    0,     0,    -8,      0,    0,     0,    -4,     0    ),
        new AberrationCoefficient(  0,  0,   0,  0,  2,  0,  0,  0,    0,  0,    0,  0,        0,    -9,     0,    -8,    0,    0,       0,    -3,    0,    0,      0    ),
        new AberrationCoefficient(  2,  -4,  0,  0,  0,  0,  0,  0,    0,  0,    0,  0,        0,    -9,     0,    8,     0,    0,       0,    3,     0,    0,      0    ),
        new AberrationCoefficient(  0,  3,   -2, 0,  0,  0,  0,  0,    0,  0,    0,  8,        0,    0,      0,    0,     0,    -8,      0,    0,     0,    -3,     0    ),
        new AberrationCoefficient(  0,  0,   0,  0,  0,  0,  0,  1,    2,  -1,   0,  8,        0,    0,      0,    0,     0,    -7,      0,    0,     0,    -3,     0    ),
        new AberrationCoefficient(  8,  -12, 0,  0,  0,  0,  0,  0,    0,  0,    0,  -4,       0,    -7,     0,    -6,    0,    4,       0,    -3,    0,    2,      0    ),
        new AberrationCoefficient(  8,  -14, 0,  0,  0,  0,  0,  0,    0,  0,    0,  -4,       0,    -7,     0,    6,     0,    -4,      0,    3,     0,    -2,     0    ),
        new AberrationCoefficient(  0,  0,   2,  0,  0,  0,  0,  0,    0,  0,    0,  -6,       0,    -5,     0,    -4,    0,    5,       0,    -2,    0,    2,      0    ),
        new AberrationCoefficient(  3,  -4,  0,  0,  0,  0,  0,  0,    0,  0,    0,  -1,       0,    -1,     0,    -2,    0,    -7,      0,    1,     0,    -4,     0    ),
        new AberrationCoefficient(  0,  2,   0,  -2, 0,  0,  0,  0,    0,  0,    0,  4,        0,    -6,     0,    -5,    0,    -4,      0,    -2,    0,    -2,     0    ),
        new AberrationCoefficient(  3,  -3,  0,  0,  0,  0,  0,  0,    0,  0,    0,  0,        0,    -7,     0,    -6,    0,    0,       0,    -3,    0,    0,      0    ),
        new AberrationCoefficient(  0,  2,   -2, 0,  0,  0,  0,  0,    0,  0,    0,  5,        0,    -5,     0,    -4,    0,    -5,      0,    -2,    0,    -2,     0    ),
        new AberrationCoefficient(  0,  0,   0,  0,  0,  0,  0,  1,    -2, 0,    0,  5,        0,    0,      0,    0,     0,    -5,      0,    0,     0,    -2,     0    )
        };

        #endregion
        
        public static AAS3DCoordinate EarthVelocity(double JD, bool bHighPrecision)
        {
            AAS3DCoordinate velocity = new AAS3DCoordinate();
            
            if (bHighPrecision)
            {
                velocity.X = AASVSOP87A_Earth.X_DASH(JD);
                velocity.Y = AASVSOP87A_Earth.Y_DASH(JD);
                velocity.Z = AASVSOP87A_Earth.Z_DASH(JD);
                velocity = AASFK5.ConvertVSOPToFK5J2000(velocity);
                velocity.X *= 100000000;
                velocity.Y *= 100000000;
                velocity.Z *= 100000000;
                return velocity;
            }
            
            double T = (JD - 2451545) / 36525;
            double L2 = 3.1761467 + 1021.3285546 * T;
            double L3 = 1.7534703 + 628.3075849 * T;
            double L4 = 6.2034809 + 334.0612431 * T;
            double L5 = 0.5995465 + 52.9690965 * T;
            double L6 = 0.8740168 + 21.3299095 * T;
            double L7 = 5.4812939 + 7.4781599 * T;
            double L8 = 5.3118863 + 3.8133036 * T;
            double Ldash = 3.8103444 + 8399.6847337 * T;
            double D = 5.1984667 + 7771.3771486 * T;
            double Mdash = 2.3555559 + 8328.6914289 * T;
            double F = 1.6279052 + 8433.4661601 * T;

            

            int nAberrationCoefficients = g_AberrationCoefficients.Length;
            for (int i = 0; i < nAberrationCoefficients; i++)
            {
                double Argument = g_AberrationCoefficients[i].L2 * L2 + g_AberrationCoefficients[i].L3 * L3 +
                g_AberrationCoefficients[i].L4 * L4 + g_AberrationCoefficients[i].L5 * L5 +
                g_AberrationCoefficients[i].L6 * L6 + g_AberrationCoefficients[i].L7 * L7 +
                g_AberrationCoefficients[i].L8 * L8 + g_AberrationCoefficients[i].Ldash * Ldash +
                g_AberrationCoefficients[i].D * D + g_AberrationCoefficients[i].Mdash * Mdash +
                g_AberrationCoefficients[i].F * F;
                velocity.X += (g_AberrationCoefficients[i].xsin + g_AberrationCoefficients[i].xsint * T) * Math.Sin(Argument);
                velocity.X += (g_AberrationCoefficients[i].xcos + g_AberrationCoefficients[i].xcost * T) * Math.Cos(Argument);

                velocity.Y += (g_AberrationCoefficients[i].ysin + g_AberrationCoefficients[i].ysint * T) * Math.Sin(Argument);
                velocity.Y += (g_AberrationCoefficients[i].ycos + g_AberrationCoefficients[i].ycost * T) * Math.Cos(Argument);

                velocity.Z += (g_AberrationCoefficients[i].zsin + g_AberrationCoefficients[i].zsint * T) * Math.Sin(Argument);
                velocity.Z += (g_AberrationCoefficients[i].zcos + g_AberrationCoefficients[i].zcost * T) * Math.Cos(Argument);
            }

            return velocity;
        }

        public static AAS2DCoordinate EquatorialAberration(double Alpha, double Delta, double JD, bool bHighPrecision)
        {
            //Convert to radians
            Alpha = AASCoordinateTransformation.DegreesToRadians(Alpha * 15);
            Delta = AASCoordinateTransformation.DegreesToRadians(Delta);

            double cosAlpha = Math.Cos(Alpha);
            double sinAlpha = Math.Sin(Alpha);
            double cosDelta = Math.Cos(Delta);
            double sinDelta = Math.Sin(Delta);

            AAS3DCoordinate velocity = EarthVelocity(JD, bHighPrecision);

            //What is the return value
            AAS2DCoordinate aberration = new AAS2DCoordinate { X = AASCoordinateTransformation.RadiansToHours((velocity.Y * cosAlpha - velocity.X * sinAlpha) / (17314463350.0 * cosDelta)), Y = AASCoordinateTransformation.RadiansToDegrees(-(((velocity.X * cosAlpha + velocity.Y * sinAlpha) * sinDelta - velocity.Z * cosDelta) / 17314463350.0)) };

            return aberration;
        }

        public static AAS2DCoordinate EclipticAberration(double Lambda, double Beta, double JD, bool bHighPrecision)
        {
            //What is the return value
            AAS2DCoordinate aberration = new AAS2DCoordinate();

            double T = (JD - 2451545) / 36525;
            double Tsquared = T * T;
            double e = 0.016708634 - 0.000042037 * T - 0.0000001267 * Tsquared;
            double pi = 102.93735 + 1.71946 * T + 0.00046 * Tsquared;
            const double k = 20.49552;
            double SunLongitude = AASSun.GeometricEclipticLongitude(JD, bHighPrecision);

            //Convert to radians
            pi = AASCoordinateTransformation.DegreesToRadians(pi);
            Lambda = AASCoordinateTransformation.DegreesToRadians(Lambda);
            Beta = AASCoordinateTransformation.DegreesToRadians(Beta);
            SunLongitude = AASCoordinateTransformation.DegreesToRadians(SunLongitude);

            aberration.X = (-k * Math.Cos(SunLongitude - Lambda) + e * k * Math.Cos(pi - Lambda)) / Math.Cos(Beta) / 3600;
            aberration.Y = -k * Math.Sin(Beta) * (Math.Sin(SunLongitude - Lambda) - e * Math.Sin(pi - Lambda)) / 3600;

            return aberration;
        }
    }
}
