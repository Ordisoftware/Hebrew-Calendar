using System;

namespace AASharp
{
    public class AASEllipticalObjectElements
    {
        public double a { get; set; }
        public double e { get; set; }
        public double i { get; set; }
        public double w { get; set; }
        public double omega { get; set; }
        public double JDEquinox { get; set; }
        public double T { get; set; }
    }

    public class AASEllipticalPlanetaryDetails
    {
        public double ApparentGeocentricLongitude { get; set; }
        public double ApparentGeocentricLatitude { get; set; }
        public double ApparentGeocentricDistance { get; set; }
        public double ApparentLightTime { get; set; }
        public double ApparentGeocentricRA { get; set; }
        public double ApparentGeocentricDeclination { get; set; }
    }

    public class AASEllipticalObjectDetails
    {
        public AAS3DCoordinate HeliocentricRectangularEquatorial { get; set; }
        public AAS3DCoordinate HeliocentricRectangularEcliptical { get; set; }
        public double HeliocentricEclipticLongitude { get; set; }
        public double HeliocentricEclipticLatitude { get; set; }
        public double TrueGeocentricRA { get; set; }
        public double TrueGeocentricDeclination { get; set; }
        public double TrueGeocentricDistance { get; set; }
        public double TrueGeocentricLightTime { get; set; }
        public double AstrometricGeocentricRA { get; set; }
        public double AstrometricGeocentricDeclination { get; set; }
        public double AstrometricGeocentricDistance { get; set; }
        public double AstrometricGeocentricLightTime { get; set; }
        public double Elongation { get; set; }
        public double PhaseAngle { get; set; }
    }

    public enum AASEllipticalObject
    {
        SUN,
        MERCURY,
        VENUS,
        MARS,
        JUPITER,
        SATURN,
        URANUS,
        NEPTUNE,
        PLUTO
    }
        
    public static class AASElliptical
    {
        public static double DistanceToLightTime(double Distance)
        {
            return Distance * 0.0057755183;
        }

        public static AASEllipticalPlanetaryDetails Calculate(double JD, AASEllipticalObject ellipticalObject, bool bHighPrecision)
        {
            //What will the the return value
            AASEllipticalPlanetaryDetails details = new AASEllipticalPlanetaryDetails();

            //Calculate the position of the earth first
            double JD0 = JD;
            double L0 = AASEarth.EclipticLongitude(JD0, bHighPrecision);
            double B0 = AASEarth.EclipticLatitude(JD0, bHighPrecision);
            double R0 = AASEarth.RadiusVector(JD0, bHighPrecision);
            L0 = AASCoordinateTransformation.DegreesToRadians(L0);
            B0 = AASCoordinateTransformation.DegreesToRadians(B0);
            double cosB0 = Math.Cos(B0);

            //Iterate to find the positions adjusting for light-time correction if required
            double L = 0;
            double B = 0;
            double R = 0;

            if (ellipticalObject != AASEllipticalObject.SUN)
            {
                bool bRecalc = true;
                bool bFirstRecalc = true;
                double LPrevious = 0;
                double BPrevious = 0;
                double RPrevious = 0;

                while (bRecalc)
                {
                    switch (ellipticalObject)
                    {
                        case AASEllipticalObject.SUN:

                            L = AASSun.GeometricEclipticLongitude(JD0, bHighPrecision);
                            B = AASSun.GeometricEclipticLatitude(JD0, bHighPrecision);
                            R = AASEarth.RadiusVector(JD0, bHighPrecision);
                            break;

                        case AASEllipticalObject.MERCURY:

                            L = AASMercury.EclipticLongitude(JD0, bHighPrecision);
                            B = AASMercury.EclipticLatitude(JD0, bHighPrecision);
                            R = AASMercury.RadiusVector(JD0, bHighPrecision);
                            break;

                        case AASEllipticalObject.VENUS:

                            L = AASVenus.EclipticLongitude(JD0, bHighPrecision);
                            B = AASVenus.EclipticLatitude(JD0, bHighPrecision);
                            R = AASVenus.RadiusVector(JD0, bHighPrecision);
                            break;

                        case AASEllipticalObject.MARS:

                            L = AASMars.EclipticLongitude(JD0, bHighPrecision);
                            B = AASMars.EclipticLatitude(JD0, bHighPrecision);
                            R = AASMars.RadiusVector(JD0, bHighPrecision);
                            break;

                        case AASEllipticalObject.JUPITER:

                            L = AASJupiter.EclipticLongitude(JD0, bHighPrecision);
                            B = AASJupiter.EclipticLatitude(JD0, bHighPrecision);
                            R = AASJupiter.RadiusVector(JD0, bHighPrecision);
                            break;

                        case AASEllipticalObject.SATURN:

                            L = AASSaturn.EclipticLongitude(JD0, bHighPrecision);
                            B = AASSaturn.EclipticLatitude(JD0, bHighPrecision);
                            R = AASSaturn.RadiusVector(JD0, bHighPrecision);
                            break;

                        case AASEllipticalObject.URANUS:

                            L = AASUranus.EclipticLongitude(JD0, bHighPrecision);
                            B = AASUranus.EclipticLatitude(JD0, bHighPrecision);
                            R = AASUranus.RadiusVector(JD0, bHighPrecision);
                            break;

                        case AASEllipticalObject.NEPTUNE:

                            L = AASNeptune.EclipticLongitude(JD0, bHighPrecision);
                            B = AASNeptune.EclipticLatitude(JD0, bHighPrecision);
                            R = AASNeptune.RadiusVector(JD0, bHighPrecision);
                            break;

                        case AASEllipticalObject.PLUTO:

                            L = AASPluto.EclipticLongitude(JD0);
                            B = AASPluto.EclipticLatitude(JD0);
                            R = AASPluto.RadiusVector(JD0);
                            break;

                        default:
                            break;
                    }

                    if (!bFirstRecalc)
                    {
                        bRecalc = ((Math.Abs(L - LPrevious) > 0.00001) || (Math.Abs(B - BPrevious) > 0.00001) || (Math.Abs(R - RPrevious) > 0.000001));
                        LPrevious = L;
                        BPrevious = B;
                        RPrevious = R;
                    }
                    else
                    {
                        bFirstRecalc = false;
                    }

                    //Calculate the new value
                    if (bRecalc)
                    {
                        double Lrad = AASCoordinateTransformation.DegreesToRadians(L);
                        double Brad = AASCoordinateTransformation.DegreesToRadians(B);
                        double cosB = Math.Cos(Brad);
                        double cosL = Math.Cos(Lrad);
                        double x1 = R * cosB * cosL - R0 * cosB0 * Math.Cos(L0);
                        double y1 = R * cosB * Math.Sin(Lrad) - R0 * cosB0 * Math.Sin(L0);
                        double z1 = R * Math.Sin(Brad) - R0 * Math.Sin(B0);
                        double distance = Math.Sqrt(x1 * x1 + y1 * y1 + z1 * z1);

                        //Prepare for the next loop around
                        JD0 = JD - AASElliptical.DistanceToLightTime(distance);
                    }
                }
            }

            double x = 0;
            double y = 0;
            double z = 0;
            if (ellipticalObject != AASEllipticalObject.SUN)
            {
                double Lrad = AASCoordinateTransformation.DegreesToRadians(L);
                double Brad = AASCoordinateTransformation.DegreesToRadians(B);
                double cosB = Math.Cos(Brad);
                double cosL = Math.Cos(Lrad);

                x = R * cosB * cosL - R0 * cosB0 * Math.Cos(L0);
                y = R * cosB * Math.Sin(Lrad) - R0 * cosB0 * Math.Sin(L0);
                z = R * Math.Sin(Brad) - R0 * Math.Sin(B0);
            }
            else
            {
                x = -R0 * cosB0 * Math.Cos(L0);
                y = -R0 * cosB0 * Math.Sin(L0);
                z = -R0 * Math.Sin(B0);
            }

            double x2 = x * x;
            double y2 = y * y;

            details.ApparentGeocentricLatitude = AASCoordinateTransformation.RadiansToDegrees(Math.Atan2(z, Math.Sqrt(x2 + y2)));
            details.ApparentGeocentricDistance = Math.Sqrt(x2 + y2 + z * z);
            details.ApparentGeocentricLongitude = AASCoordinateTransformation.MapTo0To360Range(AASCoordinateTransformation.RadiansToDegrees(Math.Atan2(y, x)));
            details.ApparentLightTime = AASElliptical.DistanceToLightTime(details.ApparentGeocentricDistance);

            //Adjust for Aberration
            AAS2DCoordinate Aberration = AASAberration.EclipticAberration(details.ApparentGeocentricLongitude, details.ApparentGeocentricLatitude, JD, bHighPrecision);
            details.ApparentGeocentricLongitude += Aberration.X;
            details.ApparentGeocentricLatitude += Aberration.Y;

            //convert to the FK5 system
            double DeltaLong = AASFK5.CorrectionInLongitude(details.ApparentGeocentricLongitude, details.ApparentGeocentricLatitude, JD);
            details.ApparentGeocentricLatitude += AASFK5.CorrectionInLatitude(details.ApparentGeocentricLongitude, JD);
            details.ApparentGeocentricLongitude += DeltaLong;

            //Correct for nutation
            double NutationInLongitude = AASNutation.NutationInLongitude(JD);
            double Epsilon = AASNutation.TrueObliquityOfEcliptic(JD);
            details.ApparentGeocentricLongitude += AASCoordinateTransformation.DMSToDegrees(0, 0, NutationInLongitude);

            //Convert to RA and Dec
            AAS2DCoordinate ApparentEqu = AASCoordinateTransformation.Ecliptic2Equatorial(details.ApparentGeocentricLongitude, details.ApparentGeocentricLatitude, Epsilon);
            details.ApparentGeocentricRA = ApparentEqu.X;
            details.ApparentGeocentricDeclination = ApparentEqu.Y;

            return details;
        }

        public static double SemiMajorAxisFromPerihelionDistance(double q, double e)
        {
            return q / (1 - e);
        }

        public static double MeanMotionFromSemiMajorAxis(double a)
        {
            return 0.9856076686 / (a * Math.Sqrt(a));
        }

        public static AASEllipticalObjectDetails Calculate(double JD, ref AASEllipticalObjectElements elements, bool bHighPrecision)
        {
            double Epsilon = AASNutation.MeanObliquityOfEcliptic(elements.JDEquinox);

            double JD0 = JD;

            //What will be the return value
            AASEllipticalObjectDetails details = new AASEllipticalObjectDetails();

            Epsilon = AASCoordinateTransformation.DegreesToRadians(Epsilon);
            double omega = AASCoordinateTransformation.DegreesToRadians(elements.omega);
            double w = AASCoordinateTransformation.DegreesToRadians(elements.w);
            double i = AASCoordinateTransformation.DegreesToRadians(elements.i);

            double sinEpsilon = Math.Sin(Epsilon);
            double cosEpsilon = Math.Cos(Epsilon);
            double sinOmega = Math.Sin(omega);
            double cosOmega = Math.Cos(omega);
            double cosi = Math.Cos(i);
            double sini = Math.Sin(i);

            double F = cosOmega;
            double G = sinOmega * cosEpsilon;
            double H = sinOmega * sinEpsilon;
            double P = -sinOmega * cosi;
            double Q = cosOmega * cosi * cosEpsilon - sini * sinEpsilon;
            double R = cosOmega * cosi * sinEpsilon + sini * cosEpsilon;
            double a = Math.Sqrt(F * F + P * P);
            double b = Math.Sqrt(G * G + Q * Q);
            double c = Math.Sqrt(H * H + R * R);
            double A = Math.Atan2(F, P);
            double B = Math.Atan2(G, Q);
            double C = Math.Atan2(H, R);
            double n = AASElliptical.MeanMotionFromSemiMajorAxis(elements.a);

            AAS3DCoordinate SunCoord = AASSun.EquatorialRectangularCoordinatesAnyEquinox(JD, elements.JDEquinox, bHighPrecision);

            for (int j = 0; j < 2; j++)
            {
                double M = n * (JD0 - elements.T);
                double E = AASKepler.Calculate(M, elements.e);
                E = AASCoordinateTransformation.DegreesToRadians(E);
                double v = 2 * Math.Atan(Math.Sqrt((1 + elements.e) / (1 - elements.e)) * Math.Tan(E / 2));
                double r = elements.a * (1 - elements.e * Math.Cos(E));
                double x = r * a * Math.Sin(A + w + v);
                double y = r * b * Math.Sin(B + w + v);
                double z = r * c * Math.Sin(C + w + v);

                if (j == 0)
                {
                    details.HeliocentricRectangularEquatorial = new AAS3DCoordinate { X = x, Y = y, Z = z };

                    //Calculate the heliocentric ecliptic coordinates also
                    double u = w + v;
                    double cosu = Math.Cos(u);
                    double sinu = Math.Sin(u);

                    details.HeliocentricRectangularEcliptical = new AAS3DCoordinate
                    {
                        X = r * (cosOmega * cosu - sinOmega * sinu * cosi),
                        Y = r * (sinOmega * cosu + cosOmega * sinu * cosi),
                        Z = r * sini * sinu
                    };

                    details.HeliocentricEclipticLongitude = AASCoordinateTransformation.MapTo0To360Range(AASCoordinateTransformation.RadiansToDegrees(Math.Atan2(details.HeliocentricRectangularEcliptical.Y, details.HeliocentricRectangularEcliptical.X)));
                    details.HeliocentricEclipticLatitude = AASCoordinateTransformation.RadiansToDegrees(Math.Asin(details.HeliocentricRectangularEcliptical.Z / r));
                }

                double psi = SunCoord.X + x;
                double nu = SunCoord.Y + y;
                double sigma = SunCoord.Z + z;

                double Alpha = Math.Atan2(nu, psi);
                Alpha = AASCoordinateTransformation.RadiansToDegrees(Alpha);
                double Delta = Math.Atan2(sigma, Math.Sqrt(psi * psi + nu * nu));
                Delta = AASCoordinateTransformation.RadiansToDegrees(Delta);
                double Distance = Math.Sqrt(psi * psi + nu * nu + sigma * sigma);

                if (j == 0)
                {
                    details.TrueGeocentricRA = AASCoordinateTransformation.MapTo0To24Range(Alpha / 15);
                    details.TrueGeocentricDeclination = Delta;
                    details.TrueGeocentricDistance = Distance;
                    details.TrueGeocentricLightTime = DistanceToLightTime(Distance);
                }
                else
                {
                    details.AstrometricGeocentricRA = AASCoordinateTransformation.MapTo0To24Range(Alpha / 15);
                    details.AstrometricGeocentricDeclination = Delta;
                    details.AstrometricGeocentricDistance = Distance;
                    details.AstrometricGeocentricLightTime = DistanceToLightTime(Distance);

                    double RES = Math.Sqrt(SunCoord.X * SunCoord.X + SunCoord.Y * SunCoord.Y + SunCoord.Z * SunCoord.Z);

                    details.Elongation = Math.Acos((RES * RES + Distance * Distance - r * r) / (2 * RES * Distance));
                    details.Elongation = AASCoordinateTransformation.RadiansToDegrees(details.Elongation);

                    details.PhaseAngle = Math.Acos((r * r + Distance * Distance - RES * RES) / (2 * r * Distance));
                    details.PhaseAngle = AASCoordinateTransformation.RadiansToDegrees(details.PhaseAngle);
                }

                if (j == 0)
                    //Prepare for the next loop around
                    JD0 = JD - details.TrueGeocentricLightTime;
            }

            return details;
        }

        public static double InstantaneousVelocity(double r, double a)
        {
            return 42.1219 * Math.Sqrt((1 / r) - (1 / (2 * a)));
        }

        public static double VelocityAtPerihelion(double e, double a)
        {
            return 29.7847 / Math.Sqrt(a) * Math.Sqrt((1 + e) / (1 - e));
        }

        public static double VelocityAtAphelion(double e, double a)
        {
            return 29.7847 / Math.Sqrt(a) * Math.Sqrt((1 - e) / (1 + e));
        }

        public static double LengthOfEllipse(double e, double a)
        {
            double b = a * Math.Sqrt(1 - e * e);
            return AASCoordinateTransformation.PI() * (3 * (a + b) - Math.Sqrt((a + 3 * b) * (3 * a + b)));
        }

        public static double CometMagnitude(double g, double delta, double k, double r)
        {
            return g + 5 * Math.Log10(delta) + k * Math.Log10(r);
        }

        public static double MinorPlanetMagnitude(double H, double delta, double G, double r, double PhaseAngle)
        {
            //Convert from degrees to radians
            PhaseAngle = AASCoordinateTransformation.DegreesToRadians(PhaseAngle);

            double phi1 = Math.Exp(-3.33 * Math.Pow(Math.Tan(PhaseAngle / 2), 0.63));
            double phi2 = Math.Exp(-1.87 * Math.Pow(Math.Tan(PhaseAngle / 2), 1.22));

            return H + 5 * Math.Log10(r * delta) - 2.5 * Math.Log10((1 - G) * phi1 + G * phi2);
        }
    }
}
