using System;

namespace AASharp
{
    public class AASParabolicObjectElements
    {
        public double q { get; set; }
        public double i { get; set; }
        public double w { get; set; }
        public double omega { get; set; }
        public double JDEquinox { get; set; }
        public double T { get; set; }
    }

    public class AASParabolicObjectDetails
    {
        public AASParabolicObjectDetails()
        {
            HeliocentricRectangularEquatorial = new AAS3DCoordinate();
            HeliocentricRectangularEcliptical = new AAS3DCoordinate();
        }

        public AAS3DCoordinate HeliocentricRectangularEquatorial { get; set; }
        public AAS3DCoordinate HeliocentricRectangularEcliptical { get; set; }
        public double HeliocentricEclipticLongitude { get; set; }
        public double HeliocentricEclipticLatitude { get; set; }
        public double TrueGeocentricRA { get; set; }
        public double TrueGeocentricDeclination { get; set; }
        public double TrueGeocentricDistance { get; set; }
        public double TrueGeocentricLightTime { get; set; }
        public double AstrometricGeocenticRA { get; set; }
        public double AstrometricGeocentricDeclination { get; set; }
        public double AstrometricGeocentricDistance { get; set; }
        public double AstrometricGeocentricLightTime { get; set; }
        public double Elongation { get; set; }
        public double PhaseAngle { get; set; }
    }

    public static class AASParabolic
    {
        public static double CalculateBarkers(double W)
        {
            double S = W / 3;
            bool bRecalc = true;
            while (bRecalc)
            {
                double S2 = S * S;
                double NextS = (2 * S2 * S + W) / (3 * (S2 + 1));

                //Prepare for the next loop around
                bRecalc = (Math.Abs(NextS - S) > 0.000001);
                S = NextS;
            }

            return S;
        }

        public static AASParabolicObjectDetails Calculate(double JD, ref AASParabolicObjectElements elements, bool bHighPrecision)
        {
            double Epsilon = AASNutation.MeanObliquityOfEcliptic(elements.JDEquinox);

            double JD0 = JD;

            //What will be the return value
            AASParabolicObjectDetails details = new AASParabolicObjectDetails();

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

            AAS3DCoordinate SunCoord = AASSun.EquatorialRectangularCoordinatesAnyEquinox(JD, elements.JDEquinox, bHighPrecision);

            for (int j = 0; j < 2; j++)
            {
                double W = 0.03649116245 / (elements.q * Math.Sqrt(elements.q)) * (JD0 - elements.T);
                double s = CalculateBarkers(W);
                double v = 2 * Math.Atan(s);
                double r = elements.q * (1 + s * s);
                double x = r * a * Math.Sin(A + w + v);
                double y = r * b * Math.Sin(B + w + v);
                double z = r * c * Math.Sin(C + w + v);

                if (j == 0)
                {
                    details.HeliocentricRectangularEquatorial.X = x;
                    details.HeliocentricRectangularEquatorial.Y = y;
                    details.HeliocentricRectangularEquatorial.Z = z;

                    //Calculate the heliocentric ecliptic coordinates also
                    double u = w + v;
                    double cosu = Math.Cos(u);
                    double sinu = Math.Sin(u);

                    details.HeliocentricRectangularEcliptical.X = r * (cosOmega * cosu - sinOmega * sinu * cosi);
                    details.HeliocentricRectangularEcliptical.Y = r * (sinOmega * cosu + cosOmega * sinu * cosi);
                    details.HeliocentricRectangularEcliptical.Z = r * sini * sinu;

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
                    details.TrueGeocentricLightTime = AASElliptical.DistanceToLightTime(Distance);
                }
                else
                {
                    details.AstrometricGeocenticRA = AASCoordinateTransformation.MapTo0To24Range(Alpha / 15);
                    details.AstrometricGeocentricDeclination = Delta;
                    details.AstrometricGeocentricDistance = Distance;
                    details.AstrometricGeocentricLightTime = AASElliptical.DistanceToLightTime(Distance);

                    double RES = Math.Sqrt(SunCoord.X * SunCoord.X + SunCoord.Y * SunCoord.Y + SunCoord.Z * SunCoord.Z);

                    details.Elongation = AASCoordinateTransformation.RadiansToDegrees(Math.Acos((RES * RES + Distance * Distance - r * r) / (2 * RES * Distance)));
                    details.PhaseAngle = AASCoordinateTransformation.RadiansToDegrees(Math.Acos((r * r + Distance * Distance - RES * RES) / (2 * r * Distance)));
                }

                if (j == 0) //Prepare for the next loop around
                    JD0 = JD - details.TrueGeocentricLightTime;
            }

            return details;
        }
    }
}
