using System;

namespace AASharp
{
    public class AASRiseTransitSetDetails
    {
        public bool bRiseValid { get; set; }
        public double Rise { get; set; }
        public bool bTransitValid { get; set; }
        public bool bTransitAboveHorizon { get; set; }
        public double Transit { get; set; }
        public bool bSetValid { get; set; }
        public double Set { get; set; }
    }

    public static class AASRiseTransitSet
    {
        private static void ConstraintM(ref double M)
        {
            while (M > 1)
                M -= 1;
            while (M < 0)
                M += 1;
        }

        private static double CalculateTransit(double Alpha2, double theta0, double Longitude)
        {
            //Calculate and ensure the M0 is in the range 0 to +1
            double M0 = (Alpha2 * 15 + Longitude - theta0) / 360;
            ConstraintM(ref M0);

            return M0;
        }

        private static void CalculateRiseSet(double M0, double cosH0, ref AASRiseTransitSetDetails details, ref double M1, ref double M2)
        {
            M1 = 0;
            M2 = 0;

            if ((cosH0 > -1) && (cosH0 < 1))
            {
                details.bRiseValid = true;
                details.bSetValid = true;
                details.bTransitAboveHorizon = true;

                double H0 = Math.Acos(cosH0);
                H0 = AASCoordinateTransformation.RadiansToDegrees(H0);

                //Calculate and ensure the M1 and M2 is in the range 0 to +1
                M1 = M0 - H0 / 360;
                M2 = M0 + H0 / 360;

                ConstraintM(ref M1);
                ConstraintM(ref M2);
            }
            else if (cosH0 < 1)
                details.bTransitAboveHorizon = true;
        }

        private static void CorrectRAValuesForInterpolation(ref double Alpha1, ref double Alpha2, ref double Alpha3)
        {
            //Ensure the RA values are corrected for interpolation. Due to important Remark 2 by Meeus on Interopolation of RA values
            Alpha1 = AASCoordinateTransformation.MapTo0To24Range(Alpha1);
            Alpha2 = AASCoordinateTransformation.MapTo0To24Range(Alpha2);
            Alpha3 = AASCoordinateTransformation.MapTo0To24Range(Alpha3);
            if (Math.Abs(Alpha2 - Alpha1) > 12.0)
            {
                if (Alpha2 > Alpha1)
                    Alpha1 += 24;
                else
                    Alpha2 += 24;
            }
            if (Math.Abs(Alpha3 - Alpha2) > 12.0)
            {
                if (Alpha3 > Alpha2)
                    Alpha2 += 24;
                else
                    Alpha3 += 24;
            }
            if (Math.Abs(Alpha2 - Alpha1) > 12.0)
            {
                if (Alpha2 > Alpha1)
                    Alpha1 += 24;
                else
                    Alpha2 += 24;
            }
            if (Math.Abs(Alpha3 - Alpha2) > 12.0)
            {
                if (Alpha3 > Alpha2)
                    Alpha2 += 24;
                else
                    Alpha3 += 24;
            }
        }


        private static void CalculateRiseHelper(ref AASRiseTransitSetDetails details, double theta0, double deltaT, double Alpha1, double Delta1, double Alpha2, double Delta2, double Alpha3, double Delta3, double Longitude, double Latitude, double LatitudeRad, double h0, ref double M1)
        {
            for (int i = 0; i < 2; i++)
            {
                //Calculate the details of rising
                if (details.bRiseValid)
                {
                    double theta1 = theta0 + 360.985647 * M1;
                    theta1 = AASCoordinateTransformation.MapTo0To360Range(theta1);

                    double n = M1 + deltaT / 86400;

                    double Alpha = AASInterpolate.Interpolate(n, Alpha1, Alpha2, Alpha3);
                    double Delta = AASInterpolate.Interpolate(n, Delta1, Delta2, Delta3);

                    double H = theta1 - Longitude - Alpha * 15;
                    AAS2DCoordinate Horizontal = AASCoordinateTransformation.Equatorial2Horizontal(H / 15, Delta, Latitude);

                    double DeltaM = (Horizontal.Y - h0) / (360 * Math.Cos(AASCoordinateTransformation.DegreesToRadians(Delta)) * Math.Cos(LatitudeRad) * Math.Sin(AASCoordinateTransformation.DegreesToRadians(H)));
                    M1 += DeltaM;

                    if ((M1 < 0) || (M1 >= 1))
                        details.bRiseValid = false;
                }
            }
        }

        private static void CalculateSetHelper(ref AASRiseTransitSetDetails details, double theta0, double deltaT, double Alpha1, double Delta1, double Alpha2, double Delta2, double Alpha3, double Delta3, double Longitude, double Latitude, double LatitudeRad, double h0, ref double M2)
        {
            for (int i = 0; i < 2; i++)
            {
                //Calculate the details of setting
                if (details.bSetValid)
                {
                    double theta1 = theta0 + 360.985647 * M2;
                    theta1 = AASCoordinateTransformation.MapTo0To360Range(theta1);

                    double n = M2 + deltaT / 86400;

                    double Alpha = AASInterpolate.Interpolate(n, Alpha1, Alpha2, Alpha3);
                    double Delta = AASInterpolate.Interpolate(n, Delta1, Delta2, Delta3);

                    double H = theta1 - Longitude - Alpha * 15;
                    AAS2DCoordinate Horizontal = AASCoordinateTransformation.Equatorial2Horizontal(H / 15, Delta, Latitude);

                    double DeltaM = (Horizontal.Y - h0) / (360 * Math.Cos(AASCoordinateTransformation.DegreesToRadians(Delta)) * Math.Cos(LatitudeRad) * Math.Sin(AASCoordinateTransformation.DegreesToRadians(H)));
                    M2 += DeltaM;

                    if ((M2 < 0) || (M2 >= 1))
                        details.bSetValid = false;
                }
            }
        }


        private static void CalculateTransitHelper(ref AASRiseTransitSetDetails details, double theta0, double deltaT, double Alpha1, double Alpha2, double Alpha3, double Longitude, ref double M0)
        {
            for (int i = 0; i < 2; i++)
            {
                //Calculate the details of transit
                if (details.bTransitValid)
                {
                    double theta1 = theta0 + 360.985647 * M0;
                    theta1 = AASCoordinateTransformation.MapTo0To360Range(theta1);

                    double n = M0 + deltaT / 86400;

                    double Alpha = AASInterpolate.Interpolate(n, Alpha1, Alpha2, Alpha3);

                    double H = theta1 - Longitude - Alpha * 15;
                    H = AASCoordinateTransformation.MapTo0To360Range(H);
                    if (H > 180)
                        H -= 360;

                    double DeltaM = -H / 360;
                    M0 += DeltaM;

                    if (M0 < 0 || M0 >= 1)
                        details.bTransitValid = false;
                }
            }
        }

        public static AASRiseTransitSetDetails Calculate(double JD, double Alpha1, double Delta1, double Alpha2, double Delta2, double Alpha3, double Delta3, double Longitude, double Latitude, double h0)
        {
            //What will be the return value
            AASRiseTransitSetDetails details = new AASRiseTransitSetDetails();
            details.bRiseValid = false;
            details.bSetValid = false;
            details.bTransitValid = true;
            details.bTransitAboveHorizon = false;

            //Calculate the sidereal time
            double theta0 = AASSidereal.ApparentGreenwichSiderealTime(JD);
            theta0 *= 15; //Express it as degrees

            //Calculate deltat
            double deltaT = AASDynamicalTime.DeltaT(JD);

            //Convert values to radians
            double Delta2Rad = AASCoordinateTransformation.DegreesToRadians(Delta2);
            double LatitudeRad = AASCoordinateTransformation.DegreesToRadians(Latitude);

            //Convert the standard latitude to radians
            double h0Rad = AASCoordinateTransformation.DegreesToRadians(h0);

            //Calculate cosH0
            double cosH0 = (Math.Sin(h0Rad) - Math.Sin(LatitudeRad) * Math.Sin(Delta2Rad)) / (Math.Cos(LatitudeRad) * Math.Cos(Delta2Rad));

            //Calculate M0
            double M0 = CalculateTransit(Alpha2, theta0, Longitude);

            //Calculate M1 & M2
            double M1 = 0;
            double M2 = 0;
            CalculateRiseSet(M0, cosH0, ref details, ref M1, ref M2);

            //Ensure the RA values are corrected for interpolation. Due to important Remark 2 by Meeus on Interopolation of RA values
            CorrectRAValuesForInterpolation(ref Alpha1, ref Alpha2, ref Alpha3);

            //Do the main work
            CalculateTransitHelper(ref details, theta0, deltaT, Alpha1, Alpha2, Alpha3, Longitude, ref M0);
            CalculateRiseHelper(ref details, theta0, deltaT, Alpha1, Delta1, Alpha2, Delta2, Alpha3, Delta3, Longitude, Latitude, LatitudeRad, h0, ref M1);
            CalculateSetHelper(ref details, theta0, deltaT, Alpha1, Delta1, Alpha2, Delta2, Alpha3, Delta3, Longitude, Latitude, LatitudeRad, h0, ref M2);

            details.Rise = details.bRiseValid ? (M1 * 24) : 0.0;
            details.Set = details.bSetValid ? (M2 * 24) : 0.0;
            details.Transit = details.bTransitValid ? (M0 * 24) : 0.0;

            return details;
        }
    }
}
