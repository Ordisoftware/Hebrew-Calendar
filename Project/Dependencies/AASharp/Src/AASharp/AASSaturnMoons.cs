using System;

namespace AASharp
{
    public class AASSaturnMoonDetail
    {
        public AASSaturnMoonDetail()
        {
            TrueRectangularCoordinates = new AAS3DCoordinate();
            ApparentRectangularCoordinates = new AAS3DCoordinate();
        }

        public AAS3DCoordinate TrueRectangularCoordinates { get; set; }
        public AAS3DCoordinate ApparentRectangularCoordinates { get; set; }
        public bool bInTransit { get; set; }
        public bool bInOccultation { get; set; }
        public bool bInEclipse { get; set; }
        public bool bInShadowTransit { get; set; }
    }

    public class AASSaturnMoonsDetails
    {
        public AASSaturnMoonsDetails()
        {
            Satellite1 = new AASSaturnMoonDetail();
            Satellite2 = new AASSaturnMoonDetail();
            Satellite3 = new AASSaturnMoonDetail();
            Satellite4 = new AASSaturnMoonDetail();
            Satellite5 = new AASSaturnMoonDetail();
            Satellite6 = new AASSaturnMoonDetail();
            Satellite7 = new AASSaturnMoonDetail();
            Satellite8 = new AASSaturnMoonDetail();
        }

        public AASSaturnMoonDetail Satellite1 { get; set; }
        public AASSaturnMoonDetail Satellite2 { get; set; }
        public AASSaturnMoonDetail Satellite3 { get; set; }
        public AASSaturnMoonDetail Satellite4 { get; set; }
        public AASSaturnMoonDetail Satellite5 { get; set; }
        public AASSaturnMoonDetail Satellite6 { get; set; }
        public AASSaturnMoonDetail Satellite7 { get; set; }
        public AASSaturnMoonDetail Satellite8 { get; set; }
    }

    public static class AASSaturnMoons
    {
        private static void HelperSubroutine(double e, double lambdadash, double p, double a, double omega, double i, double c1, double s1, ref double r, ref double lambda, ref double gamma, ref double w)
        {
            double e2 = e * e;
            double e3 = e2 * e;
            double e4 = e3 * e;
            double e5 = e4 * e;
            double M = AASCoordinateTransformation.DegreesToRadians(lambdadash - p);

            double Crad = (2 * e - 0.25 * e3 + 0.0520833333 * e5) * Math.Sin(M) +
                          (1.25 * e2 - 0.458333333 * e4) * Math.Sin(2 * M) +
                          (1.083333333 * e3 - 0.671875 * e5) * Math.Sin(3 * M) +
                          1.072917 * e4 * Math.Sin(4 * M) + 1.142708 * e5 * Math.Sin(5 * M);
            double C = AASCoordinateTransformation.RadiansToDegrees(Crad);
            r = a * (1 - e2) / (1 + e * Math.Cos(M + Crad));
            double g = omega - 168.8112;
            double grad = AASCoordinateTransformation.DegreesToRadians(g);
            double irad = AASCoordinateTransformation.DegreesToRadians(i);
            double a1 = Math.Sin(irad) * Math.Sin(grad);
            double a2 = c1 * Math.Sin(irad) * Math.Cos(grad) - s1 * Math.Cos(irad);
            gamma = AASCoordinateTransformation.RadiansToDegrees(Math.Asin(Math.Sqrt(a1 * a1 + a2 * a2)));
            double urad = Math.Atan2(a1, a2);
            double u = AASCoordinateTransformation.RadiansToDegrees(urad);
            w = AASCoordinateTransformation.MapTo0To360Range(168.8112 + u);
            double h = c1 * Math.Sin(irad) - s1 * Math.Cos(irad) * Math.Cos(grad);
            double psirad = Math.Atan2(s1 * Math.Sin(grad), h);
            double psi = AASCoordinateTransformation.RadiansToDegrees(psirad);
            lambda = lambdadash + C + u - g - psi;
        }

        private static AASSaturnMoonsDetails CalculateHelper(double JD, double sunlongrad, double betarad, double R, bool bHighPrecision)
        {
            //What will be the return value
            AASSaturnMoonsDetails details = new AASSaturnMoonsDetails();

            //Calculate the position of Saturn decreased by the light travel time from Saturn to the specified position
            double DELTA = 9;
            double PreviousLightTravelTime = 0;
            double LightTravelTime = AASElliptical.DistanceToLightTime(DELTA);
            double x = 0;
            double y = 0;
            double z = 0;
            double JD1 = JD - LightTravelTime;
            bool bIterate = true;
            while (bIterate)
            {
                //Calculate the position of Saturn
                double l = AASSaturn.EclipticLongitude(JD1, bHighPrecision);
                double lrad = AASCoordinateTransformation.DegreesToRadians(l);
                double b = AASSaturn.EclipticLatitude(JD1, bHighPrecision);
                double brad = AASCoordinateTransformation.DegreesToRadians(b);
                double r = AASSaturn.RadiusVector(JD1, bHighPrecision);

                x = r * Math.Cos(brad) * Math.Cos(lrad) + R * Math.Cos(sunlongrad);
                y = r * Math.Cos(brad) * Math.Sin(lrad) + R * Math.Sin(sunlongrad);
                z = r * Math.Sin(brad) + R * Math.Sin(betarad);
                DELTA = Math.Sqrt(x * x + y * y + z * z);
                LightTravelTime = AASElliptical.DistanceToLightTime(DELTA);

                //Prepare for the next loop around
                bIterate = (Math.Abs(LightTravelTime - PreviousLightTravelTime) > 2e-6); //2e-6 corresponds to 0.17 of a second
                if (bIterate)
                {
                    JD1 = JD - LightTravelTime;
                    PreviousLightTravelTime = LightTravelTime;
                }
            }

            //Calculate Saturn's Longitude and Latitude
            double lambda0 = Math.Atan2(y, x);
            lambda0 = AASCoordinateTransformation.RadiansToDegrees(lambda0);
            double beta0 = Math.Atan(z / Math.Sqrt(x * x + y * y));
            beta0 = AASCoordinateTransformation.RadiansToDegrees(beta0);

            //Precess the longtitude and Latitutude to B1950.0
            AAS2DCoordinate Saturn1950 = AASPrecession.PrecessEcliptic(lambda0, beta0, JD, 2433282.4235);
            lambda0 = Saturn1950.X;
            double lambda0rad = AASCoordinateTransformation.DegreesToRadians(lambda0);
            beta0 = Saturn1950.Y;
            double beta0rad = AASCoordinateTransformation.DegreesToRadians(beta0);

            double JDE = JD - LightTravelTime;

            double t1 = JDE - 2411093.0;
            double t2 = t1 / 365.25;
            double t3 = ((JDE - 2433282.423) / 365.25) + 1950.0;
            double t4 = JDE - 2411368.0;
            double t5 = t4 / 365.25;
            double t6 = JDE - 2415020.0;
            double t7 = t6 / 36525.0;
            double t8 = t6 / 365.25;
            double t9 = (JDE - 2442000.5) / 365.25;
            double t10 = JDE - 2409786.0;
            double t11 = t10 / 36525.0;
            double t112 = t11 * t11;
            double t113 = t112 * t11;

            double W0 = AASCoordinateTransformation.MapTo0To360Range(5.095 * (t3 - 1866.39));
            double W0rad = AASCoordinateTransformation.DegreesToRadians(W0);
            double W1 = AASCoordinateTransformation.MapTo0To360Range(74.4 + 32.39 * t2);
            double W1rad = AASCoordinateTransformation.DegreesToRadians(W1);
            double W2 = AASCoordinateTransformation.MapTo0To360Range(134.3 + 92.62 * t2);
            double W2rad = AASCoordinateTransformation.DegreesToRadians(W2);
            double W3 = AASCoordinateTransformation.MapTo0To360Range(42.0 - 0.5118 * t5);
            double W3rad = AASCoordinateTransformation.DegreesToRadians(W3);
            double W4 = AASCoordinateTransformation.MapTo0To360Range(276.59 + 0.5118 * t5);
            double W4rad = AASCoordinateTransformation.DegreesToRadians(W4);
            double W5 = AASCoordinateTransformation.MapTo0To360Range(267.2635 + 1222.1136 * t7);
            double W5rad = AASCoordinateTransformation.DegreesToRadians(W5);
            double W6 = AASCoordinateTransformation.MapTo0To360Range(175.4762 + 1221.5515 * t7);
            double W6rad = AASCoordinateTransformation.DegreesToRadians(W6);
            double W7 = AASCoordinateTransformation.MapTo0To360Range(2.4891 + 0.002435 * t7);
            double W7rad = AASCoordinateTransformation.DegreesToRadians(W7);
            double W8 = AASCoordinateTransformation.MapTo0To360Range(113.35 - 0.2597 * t7);
            double W8rad = AASCoordinateTransformation.DegreesToRadians(W8);

            double s1 = Math.Sin(AASCoordinateTransformation.DegreesToRadians(28.0817));
            double s2 = Math.Sin(AASCoordinateTransformation.DegreesToRadians(168.8112));
            double c1 = Math.Cos(AASCoordinateTransformation.DegreesToRadians(28.0817));
            double c2 = Math.Cos(AASCoordinateTransformation.DegreesToRadians(168.8112));
            double e1 = 0.05589 - 0.000346 * t7;


            //Satellite 1
            double L = AASCoordinateTransformation.MapTo0To360Range(127.64 + 381.994497 * t1 - 43.57 * Math.Sin(W0rad) - 0.720 * Math.Sin(3 * W0rad) - 0.02144 * Math.Sin(5 * W0rad));
            double p = 106.1 + 365.549 * t2;
            double M = L - p;
            double Mrad = AASCoordinateTransformation.DegreesToRadians(M);
            double C = 2.18287 * Math.Sin(Mrad) + 0.025988 * Math.Sin(2 * Mrad) + 0.00043 * Math.Sin(3 * Mrad);
            double Crad = AASCoordinateTransformation.DegreesToRadians(C);
            double lambda1 = AASCoordinateTransformation.MapTo0To360Range(L + C);
            double r1 = 3.06879 / (1 + 0.01905 * Math.Cos(Mrad + Crad));
            double gamma1 = 1.563;
            double omega1 = AASCoordinateTransformation.MapTo0To360Range(54.5 - 365.072 * t2);

            //Satellite 2
            L = AASCoordinateTransformation.MapTo0To360Range(200.317 + 262.7319002 * t1 + 0.25667 * Math.Sin(W1rad) + 0.20883 * Math.Sin(W2rad));
            p = 309.107 + 123.44121 * t2;
            M = L - p;
            Mrad = AASCoordinateTransformation.DegreesToRadians(M);
            C = 0.55577 * Math.Sin(Mrad) + 0.00168 * Math.Sin(2 * Mrad);
            Crad = AASCoordinateTransformation.DegreesToRadians(C);
            double lambda2 = AASCoordinateTransformation.MapTo0To360Range(L + C);
            double r2 = 3.94118 / (1 + 0.00485 * Math.Cos(Mrad + Crad));
            double gamma2 = 0.0262;
            double omega2 = AASCoordinateTransformation.MapTo0To360Range(348 - 151.95 * t2);

            //Satellite 3
            double lambda3 = AASCoordinateTransformation.MapTo0To360Range(285.306 + 190.69791226 * t1 + 2.063 * Math.Sin(W0rad) + 0.03409 * Math.Sin(3 * W0rad) + 0.001015 * Math.Sin(5 * W0rad));
            double r3 = 4.880998;
            double gamma3 = 1.0976;
            double omega3 = AASCoordinateTransformation.MapTo0To360Range(111.33 - 72.2441 * t2);

            //Satellite 4
            L = AASCoordinateTransformation.MapTo0To360Range(254.712 + 131.53493193 * t1 - 0.0215 * Math.Sin(W1rad) - 0.01733 * Math.Sin(W2rad));
            p = 174.8 + 30.820 * t2;
            M = L - p;
            Mrad = AASCoordinateTransformation.DegreesToRadians(M);
            C = 0.24717 * Math.Sin(Mrad) + 0.00033 * Math.Sin(2 * Mrad);
            Crad = AASCoordinateTransformation.DegreesToRadians(C);
            double lambda4 = AASCoordinateTransformation.MapTo0To360Range(L + C);
            double r4 = 6.24871 / (1 + 0.002157 * Math.Cos(Mrad + Crad));
            double gamma4 = 0.0139;
            double omega4 = AASCoordinateTransformation.MapTo0To360Range(232 - 30.27 * t2);

            //Satellite 5
            double pdash = 342.7 + 10.057 * t2;
            double pdashrad = AASCoordinateTransformation.DegreesToRadians(pdash);
            double a1 = 0.000265 * Math.Sin(pdashrad) + 0.001 * Math.Sin(W4rad); //Note the book uses the incorrect constant 0.01*Math.Sin(W4rad);
            double a2 = 0.000265 * Math.Cos(pdashrad) + 0.001 * Math.Cos(W4rad); //Note the book uses the incorrect constant 0.01*cos(W4rad);
            double e = Math.Sqrt(a1 * a1 + a2 * a2);
            p = AASCoordinateTransformation.RadiansToDegrees(Math.Atan2(a1, a2));
            double N = 345 - 10.057 * t2;
            double Nrad = AASCoordinateTransformation.DegreesToRadians(N);
            double lambdadash = AASCoordinateTransformation.MapTo0To360Range(359.244 + 79.69004720 * t1 + 0.086754 * Math.Sin(Nrad));
            double i = 28.0362 + 0.346898 * Math.Cos(Nrad) + 0.01930 * Math.Cos(W3rad);
            double omega = 168.8034 + 0.736936 * Math.Sin(Nrad) + 0.041 * Math.Sin(W3rad);
            double a = 8.725924;
            double lambda5 = 0;
            double gamma5 = 0;
            double omega5 = 0;
            double r5 = 0;
            HelperSubroutine(e, lambdadash, p, a, omega, i, c1, s1, ref r5, ref lambda5, ref gamma5, ref omega5);

            //Satellite 6
            L = 261.1582 + 22.57697855 * t4 + 0.074025 * Math.Sin(W3rad);
            double idash = 27.45141 + 0.295999 * Math.Cos(W3rad);
            double idashrad = AASCoordinateTransformation.DegreesToRadians(idash);
            double omegadash = 168.66925 + 0.628808 * Math.Sin(W3rad);
            double omegadashrad = AASCoordinateTransformation.DegreesToRadians(omegadash);
            a1 = Math.Sin(W7rad) * Math.Sin(omegadashrad - W8rad);
            a2 = Math.Cos(W7rad) * Math.Sin(idashrad) - Math.Sin(W7rad) * Math.Cos(idashrad) * Math.Cos(omegadashrad - W8rad);
            double g0 = AASCoordinateTransformation.DegreesToRadians(102.8623);
            double psi = Math.Atan2(a1, a2);
            if (a2 < 0)
                psi += AASCoordinateTransformation.PI();
            double psideg = AASCoordinateTransformation.RadiansToDegrees(psi);
            double s = Math.Sqrt(a1 * a1 + a2 * a2);
            double g = W4 - omegadash - psideg;
            double w_ = 0;
            for (int j = 0; j < 3; j++)
            {
                w_ = W4 + 0.37515 * (Math.Sin(2 * AASCoordinateTransformation.DegreesToRadians(g)) - Math.Sin(2 * g0));
                g = w_ - omegadash - psideg;
            }
            double grad = AASCoordinateTransformation.DegreesToRadians(g);
            double edash = 0.029092 + 0.00019048 * (Math.Cos(2 * grad) - Math.Cos(2 * g0));
            double q = AASCoordinateTransformation.DegreesToRadians(2 * (W5 - w_));
            double b1 = Math.Sin(idashrad) * Math.Sin(omegadashrad - W8rad);
            double b2 = Math.Cos(W7rad) * Math.Sin(idashrad) * Math.Cos(omegadashrad - W8rad) - Math.Sin(W7rad) * Math.Cos(idashrad);
            double atanb1b2 = Math.Atan2(b1, b2);
            double theta = atanb1b2 + W8rad;
            e = edash + 0.002778797 * edash * Math.Cos(q);
            p = w_ + 0.159215 * Math.Sin(q);
            double u = 2 * W5rad - 2 * theta + psi;
            double h = 0.9375 * edash * edash * Math.Sin(q) + 0.1875 * s * s * Math.Sin(2 * (W5rad - theta));
            lambdadash = AASCoordinateTransformation.MapTo0To360Range(L - 0.254744 * (e1 * Math.Sin(W6rad) + 0.75 * e1 * e1 * Math.Sin(2 * W6rad) + h));
            i = idash + 0.031843 * s * Math.Cos(u);
            omega = omegadash + (0.031843 * s * Math.Sin(u)) / Math.Sin(idashrad);
            a = 20.216193;
            double lambda6 = 0;
            double gamma6 = 0;
            double omega6 = 0;
            double r6 = 0;
            HelperSubroutine(e, lambdadash, p, a, omega, i, c1, s1, ref r6, ref lambda6, ref gamma6, ref omega6);

            //Satellite 7
            double eta = 92.39 + 0.5621071 * t6;
            double etarad = AASCoordinateTransformation.DegreesToRadians(eta);
            double zeta = 148.19 - 19.18 * t8;
            double zetarad = AASCoordinateTransformation.DegreesToRadians(zeta);
            theta = AASCoordinateTransformation.DegreesToRadians(184.8 - 35.41 * t9);
            double thetadash = theta - AASCoordinateTransformation.DegreesToRadians(7.5);
            double aS = AASCoordinateTransformation.DegreesToRadians(176 + 12.22 * t8);
            double bs = AASCoordinateTransformation.DegreesToRadians(8 + 24.44 * t8);
            double cs = bs + AASCoordinateTransformation.DegreesToRadians(5);
            w_ = 69.898 - 18.67088 * t8;
            double phi = 2 * (w_ - W5);
            double phirad = AASCoordinateTransformation.DegreesToRadians(phi);
            double chi = 94.9 - 2.292 * t8;
            double chirad = AASCoordinateTransformation.DegreesToRadians(chi);
            a = 24.50601 - 0.08686 * Math.Cos(etarad) - 0.00166 * Math.Cos(zetarad + etarad) + 0.00175 * Math.Cos(zetarad - etarad);
            e = 0.103458 - 0.004099 * Math.Cos(etarad) - 0.000167 * Math.Cos(zetarad + etarad) + 0.000235 * Math.Cos(zetarad - etarad) +
                0.02303 * Math.Cos(zetarad) - 0.00212 * Math.Cos(2 * zetarad) + 0.000151 * Math.Cos(3 * zetarad) + 0.00013 * Math.Cos(phirad);
            p = w_ + 0.15648 * Math.Sin(chirad) - 0.4457 * Math.Sin(etarad) - 0.2657 * Math.Sin(zetarad + etarad) +
                -0.3573 * Math.Sin(zetarad - etarad) - 12.872 * Math.Sin(zetarad) + 1.668 * Math.Sin(2 * zetarad) +
                -0.2419 * Math.Sin(3 * zetarad) - 0.07 * Math.Sin(phirad);
            lambdadash = AASCoordinateTransformation.MapTo0To360Range(177.047 + 16.91993829 * t6 + 0.15648 * Math.Sin(chirad) + 9.142 * Math.Sin(etarad) +
                                                                      0.007 * Math.Sin(2 * etarad) - 0.014 * Math.Sin(3 * etarad) + 0.2275 * Math.Sin(zetarad + etarad) +
                                                                      0.2112 * Math.Sin(zetarad - etarad) - 0.26 * Math.Sin(zetarad) - 0.0098 * Math.Sin(2 * zetarad) +
                                                                      -0.013 * Math.Sin(aS) + 0.017 * Math.Sin(bs) - 0.0303 * Math.Sin(phirad));
            i = 27.3347 + 0.643486 * Math.Cos(chirad) + 0.315 * Math.Cos(W3rad) + 0.018 * Math.Cos(theta) - 0.018 * Math.Cos(cs);
            omega = 168.6812 + 1.40136 * Math.Cos(chirad) + 0.68599 * Math.Sin(W3rad) - 0.0392 * Math.Sin(cs) + 0.0366 * Math.Sin(thetadash);
            double lambda7 = 0;
            double gamma7 = 0;
            double omega7 = 0;
            double r7 = 0;
            HelperSubroutine(e, lambdadash, p, a, omega, i, c1, s1, ref r7, ref lambda7, ref gamma7, ref omega7);

            //Satellite 8
            L = AASCoordinateTransformation.MapTo0To360Range(261.1582 + 22.57697855 * t4);
            double w_dash = 91.796 + 0.562 * t7;
            psi = 4.367 - 0.195 * t7;
            double psirad = AASCoordinateTransformation.DegreesToRadians(psi);
            theta = 146.819 - 3.198 * t7;
            phi = 60.470 + 1.521 * t7;
            phirad = AASCoordinateTransformation.DegreesToRadians(phi);
            double PHI = 205.055 - 2.091 * t7;
            edash = 0.028298 + 0.001156 * t11;
            double w_0 = 352.91 + 11.71 * t11;
            double mu = AASCoordinateTransformation.MapTo0To360Range(76.3852 + 4.53795125 * t10);
            idash = 18.4602 - 0.9518 * t11 - 0.072 * t112 + 0.0054 * t113;
            idashrad = AASCoordinateTransformation.DegreesToRadians(idash);
            omegadash = 143.198 - 3.919 * t11 + 0.116 * t112 + 0.008 * t113;
            double _l = AASCoordinateTransformation.DegreesToRadians(mu - w_0);
            g = AASCoordinateTransformation.DegreesToRadians(w_0 - omegadash - psi);
            double g1 = AASCoordinateTransformation.DegreesToRadians(w_0 - omegadash - phi);
            double ls = AASCoordinateTransformation.DegreesToRadians(W5 - w_dash);
            double gs = AASCoordinateTransformation.DegreesToRadians(w_dash - theta);
            double lt = AASCoordinateTransformation.DegreesToRadians(L - W4);
            double gt = AASCoordinateTransformation.DegreesToRadians(W4 - PHI);
            double u1 = 2 * (_l + g - ls - gs);
            double u2 = _l + g1 - lt - gt;
            double u3 = _l + 2 * (g - ls - gs);
            double u4 = lt + gt - g1;
            double u5 = 2 * (ls + gs);
            a = 58.935028 + 0.004638 * Math.Cos(u1) + 0.058222 * Math.Cos(u2);
            e = edash - 0.0014097 * Math.Cos(g1 - gt) + 0.0003733 * Math.Cos(u5 - 2 * g) +
                0.0001180 * Math.Cos(u3) + 0.0002408 * Math.Cos(_l) +
                0.0002849 * Math.Cos(_l + u2) + 0.0006190 * Math.Cos(u4);
            double w = 0.08077 * Math.Sin(g1 - gt) + 0.02139 * Math.Sin(u5 - 2 * g) - 0.00676 * Math.Sin(u3) +
                       0.01380 * Math.Sin(_l) + 0.01632 * Math.Sin(_l + u2) + 0.03547 * Math.Sin(u4);
            p = w_0 + w / edash;
            lambdadash = mu - 0.04299 * Math.Sin(u2) - 0.00789 * Math.Sin(u1) - 0.06312 * Math.Sin(ls) +
                         -0.00295 * Math.Sin(2 * ls) - 0.02231 * Math.Sin(u5) + 0.00650 * Math.Sin(u5 + psirad);
            i = idash + 0.04204 * Math.Cos(u5 + psirad) + 0.00235 * Math.Cos(_l + g1 + lt + gt + phirad) +
                0.00360 * Math.Cos(u2 + phirad);
            double wdash = 0.04204 * Math.Sin(u5 + psirad) + 0.00235 * Math.Sin(_l + g1 + lt + gt + phirad) +
                           0.00358 * Math.Sin(u2 + phirad);
            omega = omegadash + wdash / Math.Sin(idashrad);
            double lambda8 = 0;
            double gamma8 = 0;
            double omega8 = 0;
            double r8 = 0;
            HelperSubroutine(e, lambdadash, p, a, omega, i, c1, s1, ref r8, ref lambda8, ref gamma8, ref omega8);


            u = AASCoordinateTransformation.DegreesToRadians(lambda1 - omega1);
            w = AASCoordinateTransformation.DegreesToRadians(omega1 - 168.8112);
            double gamma1rad = AASCoordinateTransformation.DegreesToRadians(gamma1);
            double X1 = r1 * (Math.Cos(u) * Math.Cos(w) - Math.Sin(u) * Math.Cos(gamma1rad) * Math.Sin(w));
            double Y1 = r1 * (Math.Sin(u) * Math.Cos(w) * Math.Cos(gamma1rad) + Math.Cos(u) * Math.Sin(w));
            double Z1 = r1 * Math.Sin(u) * Math.Sin(gamma1rad);

            u = AASCoordinateTransformation.DegreesToRadians(lambda2 - omega2);
            w = AASCoordinateTransformation.DegreesToRadians(omega2 - 168.8112);
            double gamma2rad = AASCoordinateTransformation.DegreesToRadians(gamma2);
            double X2 = r2 * (Math.Cos(u) * Math.Cos(w) - Math.Sin(u) * Math.Cos(gamma2rad) * Math.Sin(w));
            double Y2 = r2 * (Math.Sin(u) * Math.Cos(w) * Math.Cos(gamma2rad) + Math.Cos(u) * Math.Sin(w));
            double Z2 = r2 * Math.Sin(u) * Math.Sin(gamma2rad);

            u = AASCoordinateTransformation.DegreesToRadians(lambda3 - omega3);
            w = AASCoordinateTransformation.DegreesToRadians(omega3 - 168.8112);
            double gamma3rad = AASCoordinateTransformation.DegreesToRadians(gamma3);
            double X3 = r3 * (Math.Cos(u) * Math.Cos(w) - Math.Sin(u) * Math.Cos(gamma3rad) * Math.Sin(w));
            double Y3 = r3 * (Math.Sin(u) * Math.Cos(w) * Math.Cos(gamma3rad) + Math.Cos(u) * Math.Sin(w));
            double Z3 = r3 * Math.Sin(u) * Math.Sin(gamma3rad);

            u = AASCoordinateTransformation.DegreesToRadians(lambda4 - omega4);
            w = AASCoordinateTransformation.DegreesToRadians(omega4 - 168.8112);
            double gamma4rad = AASCoordinateTransformation.DegreesToRadians(gamma4);
            double X4 = r4 * (Math.Cos(u) * Math.Cos(w) - Math.Sin(u) * Math.Cos(gamma4rad) * Math.Sin(w));
            double Y4 = r4 * (Math.Sin(u) * Math.Cos(w) * Math.Cos(gamma4rad) + Math.Cos(u) * Math.Sin(w));
            double Z4 = r4 * Math.Sin(u) * Math.Sin(gamma4rad);

            u = AASCoordinateTransformation.DegreesToRadians(lambda5 - omega5);
            w = AASCoordinateTransformation.DegreesToRadians(omega5 - 168.8112);
            double gamma5rad = AASCoordinateTransformation.DegreesToRadians(gamma5);
            double X5 = r5 * (Math.Cos(u) * Math.Cos(w) - Math.Sin(u) * Math.Cos(gamma5rad) * Math.Sin(w));
            double Y5 = r5 * (Math.Sin(u) * Math.Cos(w) * Math.Cos(gamma5rad) + Math.Cos(u) * Math.Sin(w));
            double Z5 = r5 * Math.Sin(u) * Math.Sin(gamma5rad);

            u = AASCoordinateTransformation.DegreesToRadians(lambda6 - omega6);
            w = AASCoordinateTransformation.DegreesToRadians(omega6 - 168.8112);
            double gamma6rad = AASCoordinateTransformation.DegreesToRadians(gamma6);
            double X6 = r6 * (Math.Cos(u) * Math.Cos(w) - Math.Sin(u) * Math.Cos(gamma6rad) * Math.Sin(w));
            double Y6 = r6 * (Math.Sin(u) * Math.Cos(w) * Math.Cos(gamma6rad) + Math.Cos(u) * Math.Sin(w));
            double Z6 = r6 * Math.Sin(u) * Math.Sin(gamma6rad);

            u = AASCoordinateTransformation.DegreesToRadians(lambda7 - omega7);
            w = AASCoordinateTransformation.DegreesToRadians(omega7 - 168.8112);
            double gamma7rad = AASCoordinateTransformation.DegreesToRadians(gamma7);
            double X7 = r7 * (Math.Cos(u) * Math.Cos(w) - Math.Sin(u) * Math.Cos(gamma7rad) * Math.Sin(w));
            double Y7 = r7 * (Math.Sin(u) * Math.Cos(w) * Math.Cos(gamma7rad) + Math.Cos(u) * Math.Sin(w));
            double Z7 = r7 * Math.Sin(u) * Math.Sin(gamma7rad);

            u = AASCoordinateTransformation.DegreesToRadians(lambda8 - omega8);
            w = AASCoordinateTransformation.DegreesToRadians(omega8 - 168.8112);
            double gamma8rad = AASCoordinateTransformation.DegreesToRadians(gamma8);
            double X8 = r8 * (Math.Cos(u) * Math.Cos(w) - Math.Sin(u) * Math.Cos(gamma8rad) * Math.Sin(w));
            double Y8 = r8 * (Math.Sin(u) * Math.Cos(w) * Math.Cos(gamma8rad) + Math.Cos(u) * Math.Sin(w));
            double Z8 = r8 * Math.Sin(u) * Math.Sin(gamma8rad);

            double X9 = 0;
            double Y9 = 0;
            double Z9 = 1;

            //Now do the rotations, first for the ficticious 9th satellite, so that we can calculate D
            double A4 = 0;
            double B4 = 0;
            double C4 = 0;
            Rotations(X9, Y9, Z9, c1, s1, c2, s2, lambda0rad, beta0rad, ref A4, ref B4, ref C4);
            double D = Math.Atan2(A4, C4);

            //Now calculate the values for satellite 1
            Rotations(X1, Y1, Z1, c1, s1, c2, s2, lambda0rad, beta0rad, ref A4, ref B4, ref C4);
            details.Satellite1.TrueRectangularCoordinates.X = A4 * Math.Cos(D) - C4 * Math.Sin(D);
            details.Satellite1.TrueRectangularCoordinates.Y = A4 * Math.Sin(D) + C4 * Math.Cos(D);
            details.Satellite1.TrueRectangularCoordinates.Z = B4;

            //Now calculate the values for satellite 2
            Rotations(X2, Y2, Z2, c1, s1, c2, s2, lambda0rad, beta0rad, ref A4, ref B4, ref C4);
            details.Satellite2.TrueRectangularCoordinates.X = A4 * Math.Cos(D) - C4 * Math.Sin(D);
            details.Satellite2.TrueRectangularCoordinates.Y = A4 * Math.Sin(D) + C4 * Math.Cos(D);
            details.Satellite2.TrueRectangularCoordinates.Z = B4;

            //Now calculate the values for satellite 3
            Rotations(X3, Y3, Z3, c1, s1, c2, s2, lambda0rad, beta0rad, ref A4, ref B4, ref C4);
            details.Satellite3.TrueRectangularCoordinates.X = A4 * Math.Cos(D) - C4 * Math.Sin(D);
            details.Satellite3.TrueRectangularCoordinates.Y = A4 * Math.Sin(D) + C4 * Math.Cos(D);
            details.Satellite3.TrueRectangularCoordinates.Z = B4;

            //Now calculate the values for satellite 4
            Rotations(X4, Y4, Z4, c1, s1, c2, s2, lambda0rad, beta0rad, ref A4, ref B4, ref C4);
            details.Satellite4.TrueRectangularCoordinates.X = A4 * Math.Cos(D) - C4 * Math.Sin(D);
            details.Satellite4.TrueRectangularCoordinates.Y = A4 * Math.Sin(D) + C4 * Math.Cos(D);
            details.Satellite4.TrueRectangularCoordinates.Z = B4;

            //Now calculate the values for satellite 5
            Rotations(X5, Y5, Z5, c1, s1, c2, s2, lambda0rad, beta0rad, ref A4, ref B4, ref C4);
            details.Satellite5.TrueRectangularCoordinates.X = A4 * Math.Cos(D) - C4 * Math.Sin(D);
            details.Satellite5.TrueRectangularCoordinates.Y = A4 * Math.Sin(D) + C4 * Math.Cos(D);
            details.Satellite5.TrueRectangularCoordinates.Z = B4;

            //Now calculate the values for satellite 6
            Rotations(X6, Y6, Z6, c1, s1, c2, s2, lambda0rad, beta0rad, ref A4, ref B4, ref C4);
            details.Satellite6.TrueRectangularCoordinates.X = A4 * Math.Cos(D) - C4 * Math.Sin(D);
            details.Satellite6.TrueRectangularCoordinates.Y = A4 * Math.Sin(D) + C4 * Math.Cos(D);
            details.Satellite6.TrueRectangularCoordinates.Z = B4;

            //Now calculate the values for satellite 7
            Rotations(X7, Y7, Z7, c1, s1, c2, s2, lambda0rad, beta0rad, ref A4, ref B4, ref C4);
            details.Satellite7.TrueRectangularCoordinates.X = A4 * Math.Cos(D) - C4 * Math.Sin(D);
            details.Satellite7.TrueRectangularCoordinates.Y = A4 * Math.Sin(D) + C4 * Math.Cos(D);
            details.Satellite7.TrueRectangularCoordinates.Z = B4;

            //Now calculate the values for satellite 8
            Rotations(X8, Y8, Z8, c1, s1, c2, s2, lambda0rad, beta0rad, ref A4, ref B4, ref C4);
            details.Satellite8.TrueRectangularCoordinates.X = A4 * Math.Cos(D) - C4 * Math.Sin(D);
            details.Satellite8.TrueRectangularCoordinates.Y = A4 * Math.Sin(D) + C4 * Math.Cos(D);
            details.Satellite8.TrueRectangularCoordinates.Z = B4;


            //apply the differential light-time correction
            details.Satellite1.ApparentRectangularCoordinates.X = details.Satellite1.TrueRectangularCoordinates.X + Math.Abs(details.Satellite1.TrueRectangularCoordinates.Z) / 20947 * Math.Sqrt(1 - (details.Satellite1.TrueRectangularCoordinates.X / r1) * (details.Satellite1.TrueRectangularCoordinates.X / r1));
            details.Satellite1.ApparentRectangularCoordinates.Y = details.Satellite1.TrueRectangularCoordinates.Y;
            details.Satellite1.ApparentRectangularCoordinates.Z = details.Satellite1.TrueRectangularCoordinates.Z;

            details.Satellite2.ApparentRectangularCoordinates.X = details.Satellite2.TrueRectangularCoordinates.X + Math.Abs(details.Satellite2.TrueRectangularCoordinates.Z) / 23715 * Math.Sqrt(1 - (details.Satellite2.TrueRectangularCoordinates.X / r2) * (details.Satellite2.TrueRectangularCoordinates.X / r2));
            details.Satellite2.ApparentRectangularCoordinates.Y = details.Satellite2.TrueRectangularCoordinates.Y;
            details.Satellite2.ApparentRectangularCoordinates.Z = details.Satellite2.TrueRectangularCoordinates.Z;

            details.Satellite3.ApparentRectangularCoordinates.X = details.Satellite3.TrueRectangularCoordinates.X + Math.Abs(details.Satellite3.TrueRectangularCoordinates.Z) / 26382 * Math.Sqrt(1 - (details.Satellite3.TrueRectangularCoordinates.X / r3) * (details.Satellite3.TrueRectangularCoordinates.X / r3));
            details.Satellite3.ApparentRectangularCoordinates.Y = details.Satellite3.TrueRectangularCoordinates.Y;
            details.Satellite3.ApparentRectangularCoordinates.Z = details.Satellite3.TrueRectangularCoordinates.Z;

            details.Satellite4.ApparentRectangularCoordinates.X = details.Satellite4.TrueRectangularCoordinates.X + Math.Abs(details.Satellite4.TrueRectangularCoordinates.Z) / 29876 * Math.Sqrt(1 - (details.Satellite4.TrueRectangularCoordinates.X / r4) * (details.Satellite4.TrueRectangularCoordinates.X / r4));
            details.Satellite4.ApparentRectangularCoordinates.Y = details.Satellite4.TrueRectangularCoordinates.Y;
            details.Satellite4.ApparentRectangularCoordinates.Z = details.Satellite4.TrueRectangularCoordinates.Z;

            details.Satellite5.ApparentRectangularCoordinates.X = details.Satellite5.TrueRectangularCoordinates.X + Math.Abs(details.Satellite5.TrueRectangularCoordinates.Z) / 35313 * Math.Sqrt(1 - (details.Satellite5.TrueRectangularCoordinates.X / r5) * (details.Satellite5.TrueRectangularCoordinates.X / r5));
            details.Satellite5.ApparentRectangularCoordinates.Y = details.Satellite5.TrueRectangularCoordinates.Y;
            details.Satellite5.ApparentRectangularCoordinates.Z = details.Satellite5.TrueRectangularCoordinates.Z;

            details.Satellite6.ApparentRectangularCoordinates.X = details.Satellite6.TrueRectangularCoordinates.X + Math.Abs(details.Satellite6.TrueRectangularCoordinates.Z) / 53800 * Math.Sqrt(1 - (details.Satellite6.TrueRectangularCoordinates.X / r6) * (details.Satellite6.TrueRectangularCoordinates.X / r6));
            details.Satellite6.ApparentRectangularCoordinates.Y = details.Satellite6.TrueRectangularCoordinates.Y;
            details.Satellite6.ApparentRectangularCoordinates.Z = details.Satellite6.TrueRectangularCoordinates.Z;

            details.Satellite7.ApparentRectangularCoordinates.X = details.Satellite7.TrueRectangularCoordinates.X + Math.Abs(details.Satellite7.TrueRectangularCoordinates.Z) / 59222 * Math.Sqrt(1 - (details.Satellite7.TrueRectangularCoordinates.X / r7) * (details.Satellite7.TrueRectangularCoordinates.X / r7));
            details.Satellite7.ApparentRectangularCoordinates.Y = details.Satellite7.TrueRectangularCoordinates.Y;
            details.Satellite7.ApparentRectangularCoordinates.Z = details.Satellite7.TrueRectangularCoordinates.Z;

            details.Satellite8.ApparentRectangularCoordinates.X = details.Satellite8.TrueRectangularCoordinates.X + Math.Abs(details.Satellite8.TrueRectangularCoordinates.Z) / 91820 * Math.Sqrt(1 - (details.Satellite8.TrueRectangularCoordinates.X / r8) * (details.Satellite8.TrueRectangularCoordinates.X / r8));
            details.Satellite8.ApparentRectangularCoordinates.Y = details.Satellite8.TrueRectangularCoordinates.Y;
            details.Satellite8.ApparentRectangularCoordinates.Z = details.Satellite8.TrueRectangularCoordinates.Z;


            //apply the perspective effect correction
            double W = DELTA / (DELTA + details.Satellite1.TrueRectangularCoordinates.Z / 2475);
            details.Satellite1.ApparentRectangularCoordinates.X *= W;
            details.Satellite1.ApparentRectangularCoordinates.Y *= W;

            W = DELTA / (DELTA + details.Satellite2.TrueRectangularCoordinates.Z / 2475);
            details.Satellite2.ApparentRectangularCoordinates.X *= W;
            details.Satellite2.ApparentRectangularCoordinates.Y *= W;

            W = DELTA / (DELTA + details.Satellite3.TrueRectangularCoordinates.Z / 2475);
            details.Satellite3.ApparentRectangularCoordinates.X *= W;
            details.Satellite3.ApparentRectangularCoordinates.Y *= W;

            W = DELTA / (DELTA + details.Satellite4.TrueRectangularCoordinates.Z / 2475);
            details.Satellite4.ApparentRectangularCoordinates.X *= W;
            details.Satellite4.ApparentRectangularCoordinates.Y *= W;

            W = DELTA / (DELTA + details.Satellite5.TrueRectangularCoordinates.Z / 2475);
            details.Satellite5.ApparentRectangularCoordinates.X *= W;
            details.Satellite5.ApparentRectangularCoordinates.Y *= W;

            W = DELTA / (DELTA + details.Satellite6.TrueRectangularCoordinates.Z / 2475);
            details.Satellite6.ApparentRectangularCoordinates.X *= W;
            details.Satellite6.ApparentRectangularCoordinates.Y *= W;

            W = DELTA / (DELTA + details.Satellite7.TrueRectangularCoordinates.Z / 2475);
            details.Satellite7.ApparentRectangularCoordinates.X *= W;
            details.Satellite7.ApparentRectangularCoordinates.Y *= W;

            W = DELTA / (DELTA + details.Satellite8.TrueRectangularCoordinates.Z / 2475);
            details.Satellite8.ApparentRectangularCoordinates.X *= W;
            details.Satellite8.ApparentRectangularCoordinates.Y *= W;

            return details;
        }

        public static AASSaturnMoonsDetails Calculate(double JD, bool bHighPrecision)
        {
            //Calculate the position of the Sun
            double sunlong = AASSun.GeometricEclipticLongitude(JD, bHighPrecision);
            double sunlongrad = AASCoordinateTransformation.DegreesToRadians(sunlong);
            double beta = AASSun.GeometricEclipticLatitude(JD, bHighPrecision);
            double betarad = AASCoordinateTransformation.DegreesToRadians(beta);
            double R = AASEarth.RadiusVector(JD, bHighPrecision);

            //Calculate the the light travel time from Saturn to the Earth
            double DELTA = 9;
            double PreviousEarthLightTravelTime = 0;
            double EarthLightTravelTime = AASElliptical.DistanceToLightTime(DELTA);
            double JD1 = JD - EarthLightTravelTime;
            bool bIterate = true;
            double x;
            double y;
            double z;
            while (bIterate)
            {
                //Calculate the position of Jupiter
                double l = AASSaturn.EclipticLongitude(JD1, bHighPrecision);
                double lrad = AASCoordinateTransformation.DegreesToRadians(l);
                double b = AASSaturn.EclipticLatitude(JD1, bHighPrecision);
                double brad = AASCoordinateTransformation.DegreesToRadians(b);
                double r = AASSaturn.RadiusVector(JD1, bHighPrecision);

                x = r * Math.Cos(brad) * Math.Cos(lrad) + R * Math.Cos(sunlongrad);
                y = r * Math.Cos(brad) * Math.Sin(lrad) + R * Math.Sin(sunlongrad);
                z = r * Math.Sin(brad) + R * Math.Sin(betarad);
                DELTA = Math.Sqrt(x * x + y * y + z * z);
                EarthLightTravelTime = AASElliptical.DistanceToLightTime(DELTA);

                //Prepare for the next loop around
                bIterate = (Math.Abs(EarthLightTravelTime - PreviousEarthLightTravelTime) > 2e-6); //2e-6 corresponds to 0.17 of a second
                if (bIterate)
                {
                    JD1 = JD - EarthLightTravelTime;
                    PreviousEarthLightTravelTime = EarthLightTravelTime;
                }
            }

            //Calculate the details as seen from the earth
            AASSaturnMoonsDetails details1 = CalculateHelper(JD, sunlongrad, betarad, R, bHighPrecision);
            var details1Satellite1 = details1.Satellite1;
            var details1Satellite2 = details1.Satellite2;
            var details1Satellite3 = details1.Satellite3;
            var details1Satellite4 = details1.Satellite4;
            var details1Satellite5 = details1.Satellite5;
            var details1Satellite6 = details1.Satellite6;
            var details1Satellite7 = details1.Satellite7;
            var details1Satellite8 = details1.Satellite8;

            FillInPhenomenaDetails(ref details1Satellite1);
            FillInPhenomenaDetails(ref details1Satellite2);
            FillInPhenomenaDetails(ref details1Satellite3);
            FillInPhenomenaDetails(ref details1Satellite4);
            FillInPhenomenaDetails(ref details1Satellite5);
            FillInPhenomenaDetails(ref details1Satellite6);
            FillInPhenomenaDetails(ref details1Satellite7);
            FillInPhenomenaDetails(ref details1Satellite8);


            //Calculate the the light travel time from Saturn to the Sun
            JD1 = JD - EarthLightTravelTime;
            {
                double l = AASSaturn.EclipticLongitude(JD1, bHighPrecision);
                double lrad = AASCoordinateTransformation.DegreesToRadians(l);
                double b = AASSaturn.EclipticLatitude(JD1, bHighPrecision);
                double brad = AASCoordinateTransformation.DegreesToRadians(b);
                double r = AASSaturn.RadiusVector(JD1, bHighPrecision);
                x = r * Math.Cos(brad) * Math.Cos(lrad);
                y = r * Math.Cos(brad) * Math.Sin(lrad);
                z = r * Math.Sin(brad);
            }

            DELTA = Math.Sqrt(x * x + y * y + z * z);
            double SunLightTravelTime = AASElliptical.DistanceToLightTime(DELTA);

            //Calculate the details as seen from the Sun
            AASSaturnMoonsDetails details2 = CalculateHelper(JD + SunLightTravelTime - EarthLightTravelTime, sunlongrad, betarad, 0, bHighPrecision);
            var details2Satellite1 = details2.Satellite1;
            var details2Satellite2 = details2.Satellite2;
            var details2Satellite3 = details2.Satellite3;
            var details2Satellite4 = details2.Satellite4;
            var details2Satellite5 = details2.Satellite5;
            var details2Satellite6 = details2.Satellite6;
            var details2Satellite7 = details2.Satellite7;
            var details2Satellite8 = details2.Satellite8;
            FillInPhenomenaDetails(ref details2Satellite1);
            FillInPhenomenaDetails(ref details2Satellite2);
            FillInPhenomenaDetails(ref details2Satellite3);
            FillInPhenomenaDetails(ref details2Satellite4);
            FillInPhenomenaDetails(ref details2Satellite5);
            FillInPhenomenaDetails(ref details2Satellite6);
            FillInPhenomenaDetails(ref details2Satellite7);
            FillInPhenomenaDetails(ref details2Satellite8);

            //Finally transfer the required values from details2 to details1
            details1.Satellite1.bInEclipse = details2.Satellite1.bInOccultation;
            details1.Satellite2.bInEclipse = details2.Satellite2.bInOccultation;
            details1.Satellite3.bInEclipse = details2.Satellite3.bInOccultation;
            details1.Satellite4.bInEclipse = details2.Satellite4.bInOccultation;
            details1.Satellite5.bInEclipse = details2.Satellite5.bInOccultation;
            details1.Satellite6.bInEclipse = details2.Satellite6.bInOccultation;
            details1.Satellite7.bInEclipse = details2.Satellite7.bInOccultation;
            details1.Satellite8.bInEclipse = details2.Satellite8.bInOccultation;
            details1.Satellite1.bInShadowTransit = details2.Satellite1.bInTransit;
            details1.Satellite2.bInShadowTransit = details2.Satellite2.bInTransit;
            details1.Satellite3.bInShadowTransit = details2.Satellite3.bInTransit;
            details1.Satellite4.bInShadowTransit = details2.Satellite4.bInTransit;
            details1.Satellite5.bInShadowTransit = details2.Satellite5.bInTransit;
            details1.Satellite6.bInShadowTransit = details2.Satellite6.bInTransit;
            details1.Satellite7.bInShadowTransit = details2.Satellite7.bInTransit;
            details1.Satellite8.bInShadowTransit = details2.Satellite8.bInTransit;

            return details1;
        }

        private static void Rotations(double X, double Y, double Z, double c1, double s1, double c2, double s2, double lambda0, double beta0, ref double A4, ref double B4, ref double C4)
        {
            //Rotation towards the plane of the ecliptic
            double A1 = X;
            double B1 = c1 * Y - s1 * Z;
            double C1 = s1 * Y + c1 * Z;

            //Rotation towards the vernal equinox
            double A2 = c2 * A1 - s2 * B1;
            double B2 = s2 * A1 + c2 * B1;
            double C2 = C1;

            double A3 = A2 * Math.Sin(lambda0) - B2 * Math.Cos(lambda0);
            double B3 = A2 * Math.Cos(lambda0) + B2 * Math.Sin(lambda0);
            double C3 = C2;

            A4 = A3;
            B4 = B3 * Math.Cos(beta0) + C3 * Math.Sin(beta0);
            C4 = C3 * Math.Cos(beta0) - B3 * Math.Sin(beta0);
        }

        private static void FillInPhenomenaDetails(ref AASSaturnMoonDetail detail)
        {
            double Y1 = 1.108601 * detail.ApparentRectangularCoordinates.Y;

            double r = Y1 * Y1 + detail.ApparentRectangularCoordinates.X * detail.ApparentRectangularCoordinates.X;

            if (r < 1)
            {
                if (detail.ApparentRectangularCoordinates.Z < 0)
                {
                    //Satellite nearer to Earth than Saturn, so it must be a transit not an occultation
                    detail.bInTransit = true;
                    detail.bInOccultation = false;
                }
                else
                {
                    detail.bInTransit = false;
                    detail.bInOccultation = true;
                }
            }
            else
            {
                detail.bInTransit = false;
                detail.bInOccultation = false;
            }
        }
    }
}
