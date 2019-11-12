using System;

namespace AASharp
{
    public static class AASPlanetaryPhenomena
    {
        internal struct PlanetaryPhenomenaCoefficient1
        {
            internal PlanetaryPhenomenaCoefficient1(double a, double b, double m0, double m1)
            {
                A = a;
                B = b;
                M0 = m0;
                M1 = m1;
            }

            public double A { get; }
            public double B { get; }
            public double M0 { get; }
            public double M1 { get; }
        }
        
        private static PlanetaryPhenomenaCoefficient1[] g_PlanetaryPhenomenaCoefficient1 =
        {
        new PlanetaryPhenomenaCoefficient1( 2451612.023, 115.8774771, 63.5867,  114.2088742 ),
        new PlanetaryPhenomenaCoefficient1( 2451554.084, 115.8774771, 6.4822,   114.2088742 ),
        new PlanetaryPhenomenaCoefficient1( 2451996.706, 583.921361,  82.7311,  215.513058  ),
        new PlanetaryPhenomenaCoefficient1( 2451704.746, 583.921361,  154.9745, 215.513058  ),
        new PlanetaryPhenomenaCoefficient1( 2452097.382, 779.936104,  181.9573, 48.705244   ),
        new PlanetaryPhenomenaCoefficient1( 2451707.414, 779.936104,  157.6047, 48.705244   ),
        new PlanetaryPhenomenaCoefficient1( 2451870.628, 398.884046,  318.4681, 33.140229   ),
        new PlanetaryPhenomenaCoefficient1( 2451671.186, 398.884046,  121.8980, 33.140229   ),
        new PlanetaryPhenomenaCoefficient1( 2451870.170, 378.091904,  318.0172, 12.647487   ),
        new PlanetaryPhenomenaCoefficient1( 2451681.124, 378.091904,  131.6934, 12.647487   ),
        new PlanetaryPhenomenaCoefficient1( 2451764.317, 369.656035,  213.6884, 4.333093    ),
        new PlanetaryPhenomenaCoefficient1( 2451579.489, 369.656035,  31.5219,  4.333093    ),
        new PlanetaryPhenomenaCoefficient1( 2451753.122, 367.486703,  202.6544, 2.194998    ),
        new PlanetaryPhenomenaCoefficient1( 2451569.379, 367.486703,  21.5569,  2.194998    ) };

        /// <summary>
        ///
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="planetaryObject"></param>
        /// <param name="eventType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when an incorrect EventType is specified for a given PlanetaryObject. When planetaryObject is one of the four inner planets, eventType must be either EventType.OPPOSITION or EventType.CONJUNCTION. When planetaryObject is not one of the four inner planets, eventType must be either EventType.INFERIOR_CONJUNCTION or EventType.SUPERIOR_CONJUNCTION.</exception>
        public static double K(double Year, PlanetaryObject planetaryObject, EventType eventType)
        {
            uint nCoefficient;

            if (planetaryObject >= PlanetaryObject.MARS)
            {

                if (!(eventType == EventType.OPPOSITION || eventType == EventType.CONJUNCTION))
                    throw new ArgumentOutOfRangeException("eventType", "When planetaryObject is not one of the three inner planets, eventType must be either OPPOSITION or CONJUNCTION");
                {
                    if (eventType == EventType.OPPOSITION)
                        nCoefficient = (uint)planetaryObject * 2;
                    else
                        nCoefficient = (uint)planetaryObject * 2 + 1;
                }
            }
            else
            {
                if (!(eventType == EventType.INFERIOR_CONJUNCTION || eventType == EventType.SUPERIOR_CONJUNCTION))
                    throw new ArgumentOutOfRangeException(nameof(eventType), "When planetaryObject is one of the three inner planets, eventType must be either INFERIOR_CONJUNCTION or SUPERIOR_CONJUNCTION");

                {
                    if (eventType == EventType.INFERIOR_CONJUNCTION)
                        nCoefficient = (uint)planetaryObject * 2;
                    else
                        nCoefficient = (uint)planetaryObject * 2 + 1;
                }
            }

            double k = (365.2425 * Year + 1721060 - g_PlanetaryPhenomenaCoefficient1[nCoefficient].A) / g_PlanetaryPhenomenaCoefficient1[nCoefficient].B;
            return Math.Floor(k + 0.5);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="planetaryObject"></param>
        /// <param name="eventType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when an incorrect EventType is specified for a given PlanetaryObject. When planetaryObject is not one of the three inner planets, eventType must be one of the following: OPPOSITION, CONJUNCTION, STATION1, STATION2. When planetaryObject is one of the three inner planets, eventType must be either EventType.INFERIOR_CONJUNCTION or EventType.SUPERIOR_CONJUNCTION.</exception>
        public static double Mean(double k, PlanetaryObject planetaryObject, EventType eventType)
        {
            uint nCoefficient;
            if (planetaryObject >= PlanetaryObject.MARS)
            {
                if (!(eventType == EventType.OPPOSITION || eventType == EventType.CONJUNCTION))
                    throw new ArgumentOutOfRangeException("eventType", "When planetaryObject is not one of the three inner planets, eventType must be either OPPOSITION or CONJUNCTION");
                {
                    if (eventType == EventType.OPPOSITION)
                        nCoefficient = (uint)planetaryObject * 2;
                    else
                        nCoefficient = (uint)planetaryObject * 2 + 1;
                }
            }
            else
            {
                if (!(eventType == EventType.INFERIOR_CONJUNCTION || eventType == EventType.SUPERIOR_CONJUNCTION))
                    throw new ArgumentOutOfRangeException("eventType", "When planetaryObject is one of the three inner planets, eventType must be either INFERIOR_CONJUNCTION or SUPERIOR_CONJUNCTION");

                {
                    if (eventType == EventType.INFERIOR_CONJUNCTION)
                        nCoefficient = (uint)planetaryObject * 2;
                    else
                        nCoefficient = (uint)planetaryObject * 2 + 1;
                }

            }


            return g_PlanetaryPhenomenaCoefficient1[nCoefficient].A + g_PlanetaryPhenomenaCoefficient1[nCoefficient].B * k;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="k"></param>
        /// <param name="planetaryObject"></param>
        /// <param name="eventType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when an incorrect EventType is specified for a given PlanetaryObject. When planetaryObject is not one of the three inner planets, eventType must be one of the following: OPPOSITION, CONJUNCTION, STATION1, STATION2. When planetaryObject is one of the three inner planets, eventType must be one of the following: INFERIOR_CONJUNCTION, SUPERIOR_CONJUNCTION, EASTERN_ELONGATION, WESTERN_ELONGATION, STATION1, STATION2.</exception>
        public static double True(double k, PlanetaryObject planetaryObject, EventType eventType)
        {
            double JDE0;

            if (eventType == EventType.WESTERN_ELONGATION || eventType == EventType.EASTERN_ELONGATION || eventType == EventType.STATION1 || eventType == EventType.STATION2)
            {
                if (planetaryObject >= PlanetaryObject.MARS)
                    JDE0 = Mean(k, planetaryObject, EventType.OPPOSITION);
                else
                    JDE0 = Mean(k, planetaryObject, EventType.INFERIOR_CONJUNCTION);
            }
            else
                JDE0 = Mean(k, planetaryObject, eventType);

            uint nCoefficient;
            if (planetaryObject >= PlanetaryObject.MARS)
            {
                if (!(eventType == EventType.OPPOSITION || eventType == EventType.CONJUNCTION || eventType == EventType.STATION1 || eventType == EventType.STATION2))
                    throw new ArgumentOutOfRangeException(nameof(eventType), "When planetaryObject is not one of the three inner planets, eventType must be one of the following: OPPOSITION, CONJUNCTION, STATION1, STATION2");

                if (eventType == EventType.OPPOSITION || eventType == EventType.STATION1 || eventType == EventType.STATION2)
                    nCoefficient = (uint)planetaryObject * 2;
                else
                    nCoefficient = (uint)planetaryObject * 2 + 1;
            }
            else
            {
                if (!(eventType == EventType.INFERIOR_CONJUNCTION || eventType == EventType.SUPERIOR_CONJUNCTION || eventType == EventType.EASTERN_ELONGATION || eventType == EventType.WESTERN_ELONGATION || eventType == EventType.STATION1 || eventType == EventType.STATION2))
                    throw new ArgumentOutOfRangeException(nameof(eventType), "When planetaryObject is one of the three inner planets, eventType must be one of the following: INFERIOR_CONJUNCTION, SUPERIOR_CONJUNCTION, EASTERN_ELONGATION, WESTERN_ELONGATION, STATION1, STATION2");
                

                if (eventType == EventType.INFERIOR_CONJUNCTION || eventType == EventType.EASTERN_ELONGATION || eventType == EventType.WESTERN_ELONGATION || eventType == EventType.STATION1 || eventType == EventType.STATION2)
                    nCoefficient = (uint)planetaryObject * 2;
                else
                    nCoefficient = (uint)planetaryObject * 2 + 1;
            }

            double M = AASCoordinateTransformation.MapTo0To360Range(g_PlanetaryPhenomenaCoefficient1[nCoefficient].M0 + g_PlanetaryPhenomenaCoefficient1[nCoefficient].M1 * k);
            M = AASCoordinateTransformation.DegreesToRadians(M); //convert M to radians

            double T = (JDE0 - 2451545) / 36525;
            double T2 = T * T;

            double a = 0;
            double b = 0;
            double c = 0;
            double d = 0;
            double e = 0;
            double f = 0;
            double g = 0;

            if (planetaryObject == PlanetaryObject.JUPITER)
            {
                a = AASCoordinateTransformation.MapTo0To360Range(82.74 + 40.76 * T);
                a = AASCoordinateTransformation.DegreesToRadians(a);
            }
            else
                if (planetaryObject == PlanetaryObject.SATURN)
                {
                    a = AASCoordinateTransformation.MapTo0To360Range(82.74 + 40.76 * T);
                    a = AASCoordinateTransformation.DegreesToRadians(a);
                    b = AASCoordinateTransformation.MapTo0To360Range(29.86 + 1181.36 * T);
                    b = AASCoordinateTransformation.DegreesToRadians(b);
                    c = AASCoordinateTransformation.MapTo0To360Range(14.13 + 590.68 * T);
                    c = AASCoordinateTransformation.DegreesToRadians(c);
                    d = AASCoordinateTransformation.MapTo0To360Range(220.02 + 1262.87 * T);
                    d = AASCoordinateTransformation.DegreesToRadians(d);
                }
                else
                    if (planetaryObject == PlanetaryObject.URANUS)
                    {
                        e = AASCoordinateTransformation.MapTo0To360Range(207.83 + 8.51 * T);
                        e = AASCoordinateTransformation.DegreesToRadians(e);
                        f = AASCoordinateTransformation.MapTo0To360Range(108.84 + 419.96 * T);
                        f = AASCoordinateTransformation.DegreesToRadians(f);
                    }
                    else
                        if (planetaryObject == PlanetaryObject.NEPTUNE)
                        {
                            e = AASCoordinateTransformation.MapTo0To360Range(207.83 + 8.51 * T);
                            e = AASCoordinateTransformation.DegreesToRadians(e);
                            g = AASCoordinateTransformation.MapTo0To360Range(276.74 + 209.98 * T);
                            g = AASCoordinateTransformation.DegreesToRadians(g);
                        }

            double delta;
            if (planetaryObject == PlanetaryObject.MERCURY)
            {
                if (eventType == EventType.INFERIOR_CONJUNCTION)
                {
                    delta = (0.0545 + 0.0002 * T) +
                    Math.Sin(M) * (-6.2008 + 0.0074 * T + 0.00003 * T2) +
                    Math.Cos(M) * (-3.2750 - 0.0197 * T + 0.00001 * T2) +
                    Math.Sin(2 * M) * (0.4737 - 0.0052 * T - 0.00001 * T2) +
                    Math.Cos(2 * M) * (0.8111 + 0.0033 * T - 0.00002 * T2) +
                    Math.Sin(3 * M) * (0.0037 + 0.0018 * T) +
                    Math.Cos(3 * M) * (-0.1768 + 0.00001 * T2) +
                    Math.Sin(4 * M) * (-0.0211 - 0.0004 * T) +
                    Math.Cos(4 * M) * (0.0326 - 0.0003 * T) +
                    Math.Sin(5 * M) * (0.0083 + 0.0001 * T) +
                    Math.Cos(5 * M) * (-0.0040 + 0.0001 * T);
                }
                else
                    if (eventType == EventType.SUPERIOR_CONJUNCTION)
                    {
                        delta = (-0.0548 - 0.0002 * T) +
                        Math.Sin(M) * (7.3894 - 0.0100 * T - 0.00003 * T2) +
                        Math.Cos(M) * (3.2200 + 0.0197 * T - 0.00001 * T2) +
                        Math.Sin(2 * M) * (0.8383 - 0.0064 * T - 0.00001 * T2) +
                        Math.Cos(2 * M) * (0.9666 + 0.0039 * T - 0.00003 * T2) +
                        Math.Sin(3 * M) * (0.0770 - 0.0026 * T) +
                        Math.Cos(3 * M) * (0.2758 + 0.0002 * T - 0.00002 * T2) +
                        Math.Sin(4 * M) * (-0.0128 - 0.0008 * T) +
                        Math.Cos(4 * M) * (0.0734 - 0.0004 * T - 0.00001 * T2) +
                        Math.Sin(5 * M) * (-0.0122 - 0.0002 * T) +
                        Math.Cos(5 * M) * (0.0173 - 0.0002 * T);
                    }
                    else
                        if (eventType == EventType.EASTERN_ELONGATION)
                        {
                            delta = (-21.6101 + 0.0002 * T) +
                            Math.Sin(M) * (-1.9803 - 0.0060 * T + 0.00001 * T2) +
                            Math.Cos(M) * (1.4151 - 0.0072 * T - 0.00001 * T2) +
                            Math.Sin(2 * M) * (0.5528 - 0.0005 * T - 0.00001 * T2) +
                            Math.Cos(2 * M) * (0.2905 + 0.0034 * T + 0.00001 * T2) +
                            Math.Sin(3 * M) * (-0.1121 - 0.0001 * T + 0.00001 * T2) +
                            Math.Cos(3 * M) * (-0.0098 - 0.0015 * T) +
                            Math.Sin(4 * M) * (0.0192) +
                            Math.Cos(4 * M) * (0.0111 + 0.0004 * T) +
                            Math.Sin(5 * M) * (-0.0061) +
                            Math.Cos(5 * M) * (-0.0032 - 0.0001 * T2);
                        }
                        else
                            if (eventType == EventType.WESTERN_ELONGATION)
                            {
                                delta = (21.6249 - 0.0002 * T) +
                                Math.Sin(M) * (0.1306 + 0.0065 * T) +
                                Math.Cos(M) * (-2.7661 - 0.0011 * T + 0.00001 * T2) +
                                Math.Sin(2 * M) * (0.2438 - 0.0024 * T - 0.00001 * T2) +
                                Math.Cos(2 * M) * (0.5767 + 0.0023 * T) +
                                Math.Sin(3 * M) * (0.1041) +
                                Math.Cos(3 * M) * (-0.0184 + 0.0007 * T) +
                                Math.Sin(4 * M) * (-0.0051 - 0.0001 * T) +
                                Math.Cos(4 * M) * (0.0048 + 0.0001 * T) +
                                Math.Sin(5 * M) * (0.0026) +
                                Math.Cos(5 * M) * (0.0037);
                            }
                            else
                                if (eventType == EventType.STATION1)
                                {
                                    delta = (-11.0761 + 0.0003 * T) +
                                    Math.Sin(M) * (-4.7321 + 0.0023 * T + 0.00002 * T2) +
                                    Math.Cos(M) * (-1.3230 - 0.0156 * T) +
                                    Math.Sin(2 * M) * (0.2270 - 0.0046 * T) +
                                    Math.Cos(2 * M) * (0.7184 + 0.0013 * T - 0.00002 * T2) +
                                    Math.Sin(3 * M) * (0.0638 + 0.0016 * T) +
                                    Math.Cos(3 * M) * (-0.1655 + 0.0007 * T) +
                                    Math.Sin(4 * M) * (-0.0395 - 0.0003 * T) +
                                    Math.Cos(4 * M) * (0.0247 - 0.0006 * T) +
                                    Math.Sin(5 * M) * (0.0131) +
                                    Math.Cos(5 * M) * (0.0008 + 0.0002 * T);
                                }
                                else
                                {
                                    delta = (11.1343 - 0.0001 * T) +
                                    Math.Sin(M) * (-3.9137 + 0.0073 * T + 0.00002 * T2) +
                                    Math.Cos(M) * (-3.3861 - 0.0128 * T + 0.00001 * T2) +
                                    Math.Sin(2 * M) * (0.5222 - 0.0040 * T - 0.00002 * T2) +
                                    Math.Cos(2 * M) * (0.5929 + 0.0039 * T - 0.00002 * T2) +
                                    Math.Sin(3 * M) * (-0.0593 + 0.0018 * T) +
                                    Math.Cos(3 * M) * (-0.1733 - 0.0007 * T + 0.00001 * T2) +
                                    Math.Sin(4 * M) * (-0.0053 - 0.0006 * T) +
                                    Math.Cos(4 * M) * (0.0476 - 0.0001 * T) +
                                    Math.Sin(5 * M) * (0.0070 + 0.0002 * T) +
                                    Math.Cos(5 * M) * (-0.0115 + 0.0001 * T);
                                }
            }
            else
                if (planetaryObject == PlanetaryObject.VENUS)
                {
                    if (eventType == EventType.INFERIOR_CONJUNCTION)
                    {
                        delta = (-0.0096 + 0.0002 * T - 0.00001 * T2) +
                        Math.Sin(M) * (2.0009 - 0.0033 * T - 0.00001 * T2) +
                        Math.Cos(M) * (0.5980 - 0.0104 * T + 0.00001 * T2) +
                        Math.Sin(2 * M) * (0.0967 - 0.0018 * T - 0.00003 * T2) +
                        Math.Cos(2 * M) * (0.0913 + 0.0009 * T - 0.00002 * T2) +
                        Math.Sin(3 * M) * (0.0046 - 0.0002 * T) +
                        Math.Cos(3 * M) * (0.0079 + 0.0001 * T);
                    }
                    else
                        if (eventType == EventType.SUPERIOR_CONJUNCTION)
                        {
                            delta = (0.0099 - 0.0002 * T - 0.00001 * T2) +
                            Math.Sin(M) * (4.1991 - 0.0121 * T - 0.00003 * T2) +
                            Math.Cos(M) * (-0.6095 + 0.0102 * T - 0.00002 * T2) +
                            Math.Sin(2 * M) * (0.2500 - 0.0028 * T - 0.00003 * T2) +
                            Math.Cos(2 * M) * (0.0063 + 0.0025 * T - 0.00002 * T2) +
                            Math.Sin(3 * M) * (0.0232 - 0.0005 * T - 0.00001 * T2) +
                            Math.Cos(3 * M) * (0.0031 + 0.0004 * T);
                        }
                        else
                            if (eventType == EventType.EASTERN_ELONGATION)
                            {
                                delta = (-70.7600 + 0.0002 * T - 0.00001 * T2) +
                                Math.Sin(M) * (1.0282 - 0.0010 * T - 0.00001 * T2) +
                                Math.Cos(M) * (0.2761 - 0.0060 * T) +
                                Math.Sin(2 * M) * (-0.0438 - 0.0023 * T + 0.00002 * T2) +
                                Math.Cos(2 * M) * (0.1660 - 0.0037 * T - 0.00004 * T2) +
                                Math.Sin(3 * M) * (0.0036 + 0.0001 * T) +
                                Math.Cos(3 * M) * (-0.0011 + 0.00001 * T2);
                            }
                            else
                                if (eventType == EventType.WESTERN_ELONGATION)
                                {
                                    delta = (70.7462 - 0.00001 * T2) +
                                    Math.Sin(M) * (1.1218 - 0.0025 * T - 0.00001 * T2) +
                                    Math.Cos(M) * (0.4538 - 0.0066 * T) +
                                    Math.Sin(2 * M) * (0.1320 + 0.0020 * T - 0.00003 * T2) +
                                    Math.Cos(2 * M) * (-0.0702 + 0.0022 * T + 0.00004 * T2) +
                                    Math.Sin(3 * M) * (0.0062 - 0.0001 * T) +
                                    Math.Cos(3 * M) * (0.0015 - 0.00001 * T2);
                                }
                                else
                                    if (eventType == EventType.STATION1)
                                    {
                                        delta = (-21.0672 + 0.0002 * T - 0.00001 * T2) +
                                        Math.Sin(M) * (1.9396 - 0.0029 * T - 0.00001 * T2) +
                                        Math.Cos(M) * (1.0727 - 0.0102 * T) +
                                        Math.Sin(2 * M) * (0.0404 - 0.0023 * T - 0.00001 * T2) +
                                        Math.Cos(2 * M) * (0.1305 - 0.0004 * T - 0.00003 * T2) +
                                        Math.Sin(3 * M) * (-0.0007 - 0.0002 * T) +
                                        Math.Cos(3 * M) * (0.0098);
                                    }
                                    else
                                    {
                                        delta = (21.0623 - 0.00001 * T2) +
                                        Math.Sin(M) * (1.9913 - 0.0040 * T - 0.00001 * T2) +
                                        Math.Cos(M) * (-0.0407 - 0.0077 * T) +
                                        Math.Sin(2 * M) * (0.1351 - 0.0009 * T - 0.00004 * T2) +
                                        Math.Cos(2 * M) * (0.0303 + 0.0019 * T) +
                                        Math.Sin(3 * M) * (0.0089 - 0.0002 * T) +
                                        Math.Cos(3 * M) * (0.0043 + 0.0001 * T);
                                    }
                }
                else
                    if (planetaryObject == PlanetaryObject.MARS)
                    {
                        if (eventType == EventType.OPPOSITION)
                        {
                            delta = (-0.3088 + 0.00002 * T2) +
                            Math.Sin(M) * (-17.6965 + 0.0363 * T + 0.00005 * T2) +
                            Math.Cos(M) * (18.3131 + 0.0467 * T - 0.00006 * T2) +
                            Math.Sin(2 * M) * (-0.2162 - 0.0198 * T - 0.00001 * T2) +
                            Math.Cos(2 * M) * (-4.5028 - 0.0019 * T + 0.00007 * T2) +
                            Math.Sin(3 * M) * (0.8987 + 0.0058 * T - 0.00002 * T2) +
                            Math.Cos(3 * M) * (0.7666 - 0.0050 * T - 0.00003 * T2) +
                            Math.Sin(4 * M) * (-0.3636 - 0.0001 * T + 0.00002 * T2) +
                            Math.Cos(4 * M) * (0.0402 + 0.0032 * T) +
                            Math.Sin(5 * M) * (0.0737 - 0.0008 * T) +
                            Math.Cos(5 * M) * (-0.0980 - 0.0011 * T);
                        }
                        else
                            if (eventType == EventType.CONJUNCTION)
                            {
                                delta = (0.3102 - 0.0001 * T + 0.00001 * T2) +
                                Math.Sin(M) * (9.7273 - 0.0156 * T + 0.00001 * T2) +
                                Math.Cos(M) * (-18.3195 - 0.0467 * T + 0.00009 * T2) +
                                Math.Sin(2 * M) * (-1.6488 - 0.0133 * T + 0.00001 * T2) +
                                Math.Cos(2 * M) * (-2.6117 - 0.0020 * T + 0.00004 * T2) +
                                Math.Sin(3 * M) * (-0.6827 - 0.0026 * T + 0.00001 * T2) +
                                Math.Cos(3 * M) * (0.0281 + 0.0035 * T + 0.00001 * T2) +
                                Math.Sin(4 * M) * (-0.0823 + 0.0006 * T + 0.00001 * T2) +
                                Math.Cos(4 * M) * (0.1584 + 0.0013 * T) +
                                Math.Sin(5 * M) * (0.0270 + 0.0005 * T) +
                                Math.Cos(5 * M) * (0.0433);
                            }
                            else
                                if (eventType == EventType.STATION1)
                                {
                                    delta = (-37.0790 - 0.0009 * T + 0.00002 * T2) +
                                    Math.Sin(M) * (-20.0651 + 0.0228 * T + 0.00004 * T2) +
                                    Math.Cos(M) * (14.5205 + 0.0504 - 0.00001 * T2) +
                                    Math.Sin(2 * M) * (1.1737 - 0.0169 * T) +
                                    Math.Cos(2 * M) * (-4.2550 - 0.0075 * T + 0.00008 * T2) +
                                    Math.Sin(3 * M) * (0.4897 + 0.0074 * T - 0.00001 * T2) +
                                    Math.Cos(3 * M) * (1.1151 - 0.0021 * T - 0.00005 * T2) +
                                    Math.Sin(4 * M) * (-0.3636 - 0.0020 * T + 0.00001 * T2) +
                                    Math.Cos(4 * M) * (-0.1769 + 0.0028 * T + 0.00002 * T2) +
                                    Math.Sin(5 * M) * (0.1437 - 0.0004 * T) +
                                    Math.Cos(5 * M) * (-0.0383 - 0.0016 * T);
                                }
                                else
                                {
                                    delta = (36.7191 + 0.0016 * T + 0.00003 * T2) +
                                    Math.Sin(M) * (-12.6163 + 0.0417 * T - 0.00001 * T2) +
                                    Math.Cos(M) * (20.1218 + 0.0379 * T - 0.00006 * T2) +
                                    Math.Sin(2 * M) * (-1.6360 - 0.0190 * T) +
                                    Math.Cos(2 * M) * (-3.9657 + 0.0045 * T + 0.00007 * T2) +
                                    Math.Sin(3 * M) * (1.1546 + 0.0029 * T - 0.00003 * T2) +
                                    Math.Cos(3 * M) * (0.2888 - 0.0073 * T - 0.00002 * T2) +
                                    Math.Sin(4 * M) * (-0.3128 + 0.0017 * T + 0.00002 * T2) +
                                    Math.Cos(4 * M) * (0.2513 + 0.0026 * T - 0.00002 * T2) +
                                    Math.Sin(5 * M) * (-0.0021 - 0.0016 * T) +
                                    Math.Cos(5 * M) * (-0.1497 - 0.0006 * T);
                                }
                    }
                    else
                        if (planetaryObject == PlanetaryObject.JUPITER)
                        {
                            if (eventType == EventType.OPPOSITION)
                            {
                                delta = (-0.1029 - 0.00009 * T2) +
                                Math.Sin(M) * (-1.9658 - 0.0056 * T + 0.00007 * T2) +
                                Math.Cos(M) * (6.1537 + 0.0210 * T - 0.00006 * T2) +
                                Math.Sin(2 * M) * (-0.2081 - 0.0013 * T) +
                                Math.Cos(2 * M) * (-0.1116 - 0.0010 * T) +
                                Math.Sin(3 * M) * (0.0074 + 0.0001 * T) +
                                Math.Cos(3 * M) * (-0.0097 - 0.0001 * T) +
                                Math.Sin(a) * (0.0144 * T - 0.00008 * T2) +
                                Math.Cos(a) * (0.3642 - 0.0019 * T - 0.00029 * T2);
                            }
                            else
                                if (eventType == EventType.CONJUNCTION)
                                {
                                    delta = (0.1027 + 0.0002 * T - 0.00009 * T2) +
                                    Math.Sin(M) * (-2.2637 + 0.0163 * T - 0.00003 * T2) +
                                    Math.Cos(M) * (-6.1540 - 0.0210 * T + 0.00008 * T2) +
                                    Math.Sin(2 * M) * (-0.2021 - 0.0017 * T + 0.00001 * T2) +
                                    Math.Cos(2 * M) * (0.1310 - 0.0008 * T) +
                                    Math.Sin(3 * M) * (0.0086) +
                                    Math.Cos(3 * M) * (0.0087 + 0.0002 * T) +
                                    Math.Sin(a) * (0.0144 * T - 0.00008 * T2) +
                                    Math.Cos(a) * (0.3642 - 0.0019 * T - 0.00029 * T2);
                                }
                                else
                                    if (eventType == EventType.STATION1)
                                    {
                                        delta = (-60.3670 - 0.0001 * T - 0.00009 * T2) +
                                        Math.Sin(M) * (-2.3144 - 0.0124 * T + 0.00007 * T2) +
                                        Math.Cos(M) * (6.7439 + 0.0166 * T - 0.00006 * T2) +
                                        Math.Sin(2 * M) * (-0.2259 - 0.0010 * T) +
                                        Math.Cos(2 * M) * (-0.1497 - 0.0014 * T) +
                                        Math.Sin(3 * M) * (0.0105 + 0.0001 * T) +
                                        Math.Cos(3 * M) * (-0.0098) +
                                        Math.Sin(a) * (0.0144 * T - 0.00008 * T2) +
                                        Math.Cos(a) * (0.3642 - 0.0019 * T - 0.00029 * T2);
                                    }
                                    else
                                    {
                                        delta = (60.3023 + 0.0002 * T - 0.00009 * T2) +
                                        Math.Sin(M) * (0.3506 - 0.0034 * T + 0.00004 * T2) +
                                        Math.Cos(M) * (5.3635 + 0.0247 * T - 0.00007 * T2) +
                                        Math.Sin(2 * M) * (-0.1872 - 0.0016 * T) +
                                        Math.Cos(2 * M) * (-0.0037 - 0.0005 * T) +
                                        Math.Sin(3 * M) * (0.0012 + 0.0001 * T) +
                                        Math.Cos(3 * M) * (-0.0096 - 0.0001 * T) +
                                        Math.Sin(a) * (0.0144 * T - 0.00008 * T2) +
                                        Math.Cos(a) * (0.3642 - 0.0019 * T - 0.00029 * T2);
                                    }
                        }
                        else
                            if (planetaryObject == PlanetaryObject.SATURN)
                            {
                                if (eventType == EventType.OPPOSITION)
                                {
                                    delta = (-0.0209 + 0.0006 * T + 0.00023 * T2) +
                                    Math.Sin(M) * (4.5795 - 0.0312 * T - 0.00017 * T2) +
                                    Math.Cos(M) * (1.1462 - 0.0351 * T + 0.00011 * T2) +
                                    Math.Sin(2 * M) * (0.0985 - 0.0015 * T) +
                                    Math.Cos(2 * M) * (0.0733 - 0.0031 * T + 0.00001 * T2) +
                                    Math.Sin(3 * M) * (0.0025 - 0.0001 * T) +
                                    Math.Cos(3 * M) * (0.0050 - 0.0002 * T) +
                                    Math.Sin(a) * (-0.0337 * T + 0.00018 * T2) +
                                    Math.Cos(a) * (-0.8510 + 0.0044 * T + 0.00068 * T2) +
                                    Math.Sin(b) * (-0.0064 * T + 0.00004 * T2) +
                                    Math.Cos(b) * (0.2397 - 0.0012 * T - 0.00008 * T2) +
                                    Math.Sin(c) * (-0.0010 * T) +
                                    Math.Cos(c) * (0.1245 + 0.0006 * T) +
                                    Math.Sin(d) * (0.0024 * T - 0.00003 * T2) +
                                    Math.Cos(d) * (0.0477 - 0.0005 * T - 0.00006 * T2);
                                }
                                else
                                    if (eventType == EventType.CONJUNCTION)
                                    {
                                        delta = (0.0172 - 0.0006 * T + 0.00023 * T2) +
                                        Math.Sin(M) * (-8.5885 + 0.0411 * T + 0.00020 * T2) +
                                        Math.Cos(M) * (-1.1470 + 0.0352 * T - 0.00011 * T2) +
                                        Math.Sin(2 * M) * (0.3331 - 0.0034 * T - 0.00001 * T2) +
                                        Math.Cos(2 * M) * (0.1145 - 0.0045 * T + 0.00002 * T2) +
                                        Math.Sin(3 * M) * (-0.0169 + 0.0002 * T) +
                                        Math.Cos(3 * M) * (-0.0109 + 0.0004 * T) +
                                        Math.Sin(a) * (-0.0337 * T + 0.00018 * T2) +
                                        Math.Cos(a) * (-0.8510 + 0.0044 * T + 0.00068 * T2) +
                                        Math.Sin(b) * (-0.0064 * T + 0.00004 * T2) +
                                        Math.Cos(b) * (0.2397 - 0.0012 * T - 0.00008 * T2) +
                                        Math.Sin(c) * (-0.0010 * T) +
                                        Math.Cos(c) * (0.1245 + 0.0006 * T) +
                                        Math.Sin(d) * (0.0024 * T - 0.00003 * T2) +
                                        Math.Cos(d) * (0.0477 - 0.0005 * T - 0.00006 * T2);
                                    }
                                    else
                                        if (eventType == EventType.STATION1)
                                        {
                                            delta = (-68.8840 + 0.0009 * T + 0.00023 * T2) +
                                            Math.Sin(M) * (5.5452 - 0.0279 * T - 0.00020 * T2) +
                                            Math.Cos(M) * (3.0727 - 0.0430 * T + 0.00007 * T2) +
                                            Math.Sin(2 * M) * (0.1101 - 0.0006 * T - 0.00001 * T2) +
                                            Math.Cos(2 * M) * (0.1654 - 0.0043 * T + 0.00001 * T2) +
                                            Math.Sin(3 * M) * (0.0010 + 0.0001 * T) +
                                            Math.Cos(3 * M) * (0.0095 - 0.0003 * T) +
                                            Math.Sin(a) * (-0.0337 * T + 0.00018 * T2) +
                                            Math.Cos(a) * (-0.8510 + 0.0044 * T + 0.00068 * T2) +
                                            Math.Sin(b) * (-0.0064 * T + 0.00004 * T2) +
                                            Math.Cos(b) * (0.2397 - 0.0012 * T - 0.00008 * T2) +
                                            Math.Sin(c) * (-0.0010 * T) +
                                            Math.Cos(c) * (0.1245 + 0.0006 * T) +
                                            Math.Sin(d) * (0.0024 * T - 0.00003 * T2) +
                                            Math.Cos(d) * (0.0477 - 0.0005 * T - 0.00006 * T2);
                                        }
                                        else
                                        {
                                            delta = (68.8720 - 0.0007 * T + 0.00023 * T2) +
                                            Math.Sin(M) * (5.9399 - 0.0400 * T - 0.00015 * T2) +
                                            Math.Cos(M) * (-0.7998 - 0.0266 * T + 0.00014 * T2) +
                                            Math.Sin(2 * M) * (0.1738 - 0.0032 * T) +
                                            Math.Cos(2 * M) * (-0.0039 - 0.0024 * T + 0.00001 * T2) +
                                            Math.Sin(3 * M) * (0.0073 - 0.0002 * T) +
                                            Math.Cos(3 * M) * (0.0020 - 0.0002 * T) +
                                            Math.Sin(a) * (-0.0337 * T + 0.00018 * T2) +
                                            Math.Cos(a) * (-0.8510 + 0.0044 * T + 0.00068 * T2) +
                                            Math.Sin(b) * (-0.0064 * T + 0.00004 * T2) +
                                            Math.Cos(b) * (0.2397 - 0.0012 * T - 0.00008 * T2) +
                                            Math.Sin(c) * (-0.0010 * T) +
                                            Math.Cos(c) * (0.1245 + 0.0006 * T) +
                                            Math.Sin(d) * (0.0024 * T - 0.00003 * T2) +
                                            Math.Cos(d) * (0.0477 - 0.0005 * T - 0.00006 * T2);
                                        }
                            }
                            else
                                if (planetaryObject == PlanetaryObject.URANUS)
                                {
                                    if (eventType == EventType.OPPOSITION)
                                    {
                                        delta = (0.0844 - 0.0006 * T) +
                                        Math.Sin(M) * (-0.1048 + 0.0246 * T) +
                                        Math.Cos(M) * (-5.1221 + 0.0104 * T + 0.00003 * T2) +
                                        Math.Sin(2 * M) * (-0.1428 - 0.0005 * T) +
                                        Math.Cos(2 * M) * (-0.0148 - 0.0013 * T) +
                                        Math.Cos(3 * M) * 0.0055 +
                                        Math.Cos(e) * 0.8850 +
                                        Math.Cos(f) * 0.2153;
                                    }
                                    else
                                    {
                                        delta = (-0.0859 + 0.0003 * T) +
                                        Math.Sin(M) * (-3.8179 - 0.0148 * T + 0.00003 * T2) +
                                        Math.Cos(M) * (5.1228 - 0.0105 * T - 0.00002 * T2) +
                                        Math.Sin(2 * M) * (-0.0803 + 0.0011 * T) +
                                        Math.Cos(2 * M) * (-0.1905 - 0.0006 * T) +
                                        Math.Sin(3 * M) * (0.0088 + 0.0001 * T) +
                                        Math.Cos(e) * 0.8850 +
                                        Math.Cos(f) * 0.2153;
                                    }
                                }
                                else
                                {
                                    if (eventType == EventType.OPPOSITION)
                                    {
                                        delta = (-0.0140 + 0.00001 * T2) +
                                        Math.Sin(M) * (-1.3486 + 0.0010 * T + 0.00001 * T2) +
                                        Math.Cos(M) * (0.8597 + 0.0037 * T) +
                                        Math.Sin(2 * M) * (-0.0082 - 0.0002 * T + 0.00001 * T2) +
                                        Math.Cos(2 * M) * (0.0037 - 0.0003 * T) +
                                        Math.Cos(e) * (-0.5964) +
                                        Math.Cos(g) * (0.0728);
                                    }
                                    else
                                    {
                                        delta = (0.0168) +
                                        Math.Sin(M) * (-2.5606 + 0.0088 * T + 0.00002 * T2) +
                                        Math.Cos(M) * (-0.8611 - 0.0037 * T + 0.00002 * T2) +
                                        Math.Sin(2 * M) * (0.0118 - 0.0004 * T + 0.00001 * T2) +
                                        Math.Cos(2 * M) * (0.0307 - 0.0003 * T) +
                                        Math.Cos(e) * (-0.5964) +
                                        Math.Cos(g) * (0.0728);
                                    }
                                }

            return JDE0 + delta;
        }

        public static double ElongationValue(double k, PlanetaryObject planetaryObject, bool bEastern)
        {
            if (!(planetaryObject < PlanetaryObject.MARS))
                throw new ArgumentOutOfRangeException("planetaryObject", "planetaryObject must be one of the three inner planets");

            double JDE0 = Mean(k, planetaryObject, EventType.INFERIOR_CONJUNCTION);

            uint nCoefficient = (uint)planetaryObject * 2;

            double M = AASCoordinateTransformation.MapTo0To360Range(g_PlanetaryPhenomenaCoefficient1[nCoefficient].M0 + g_PlanetaryPhenomenaCoefficient1[nCoefficient].M1 * k);
            M = AASCoordinateTransformation.DegreesToRadians(M); //convert M to radians

            double T = (JDE0 - 2451545) / 36525;
            double T2 = T * T;

            double value = 0;
            if (planetaryObject == PlanetaryObject.MERCURY)
            {
                if (bEastern)
                {
                    value = (22.4697) +
                    Math.Sin(M) * (-4.2666 + 0.0054 * T + 0.00002 * T2) +
                    Math.Cos(M) * (-1.8537 - 0.0137 * T) +
                    Math.Sin(2 * M) * (0.3598 + 0.0008 * T - 0.00001 * T2) +
                    Math.Cos(2 * M) * (-0.0680 + 0.0026 * T) +
                    Math.Sin(3 * M) * (-0.0524 - 0.0003 * T) +
                    Math.Cos(3 * M) * (0.0052 - 0.0006 * T) +
                    Math.Sin(4 * M) * (0.0107 + 0.0001 * T) +
                    Math.Cos(4 * M) * (-0.0013 + 0.0001 * T) +
                    Math.Sin(5 * M) * (-0.0021) +
                    Math.Cos(5 * M) * (0.0003);
                }
                else
                {
                    value = (22.4143 - 0.0001 * T) +
                    Math.Sin(M) * (4.3651 - 0.0048 * T - 0.00002 * T2) +
                    Math.Cos(M) * (2.3787 + 0.0121 * T - 0.00001 * T2) +
                    Math.Sin(2 * M) * (0.2674 + 0.0022 * T) +
                    Math.Cos(2 * M) * (-0.3873 + 0.0008 * T + 0.00001 * T2) +
                    Math.Sin(3 * M) * (-0.0369 - 0.0001 * T) +
                    Math.Cos(3 * M) * (0.0017 - 0.0001 * T) +
                    Math.Sin(4 * M) * (0.0059) +
                    Math.Cos(4 * M) * (0.0061 + 0.0001 * T) +
                    Math.Sin(5 * M) * (0.0007) +
                    Math.Cos(5 * M) * (-0.0011);
                }
            }
            else
                if (planetaryObject == PlanetaryObject.VENUS)
                {
                    if (bEastern)
                    {
                        value = (46.3173 + 0.0001 * T) +
                        Math.Sin(M) * (0.6916 - 0.0024 * T) +
                        Math.Cos(M) * (0.6676 - 0.0045 * T) +
                        Math.Sin(2 * M) * (0.0309 - 0.0002 * T) +
                        Math.Cos(2 * M) * (0.0036 - 0.0001 * T);
                    }
                    else
                    {
                        value = (46.3245) +
                        Math.Sin(M) * (-0.5366 - 0.0003 * T + 0.00001 * T2) +
                        Math.Cos(M) * (0.3097 + 0.0016 * T - 0.00001 * T2) +
                        Math.Sin(2 * M) * (-0.0163) +
                        Math.Cos(2 * M) * (-0.0075 + 0.0001 * T);
                    }
                }

            return value;
        }
    }
}
