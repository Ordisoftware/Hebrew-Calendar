﻿using Xunit;

namespace AASharp.Tests
{
    public class MoonTest
    {
        [Theory]
        [InlineData(2448724.5, -3.229126419222907)]
        public void EclipticLatitudeTest(double JD, double expectedEclipticLatitude)
        {
            double moonLat = AASMoon.EclipticLatitude(JD);
            Assert.Equal(expectedEclipticLatitude, moonLat);
        }

        [Theory]
        [InlineData(2448724.5, 133.16726428105474)]
        public void EclipticLongitudeTest(double JD, double expectedEclipticLongitude)
        {
            double moonLong = AASMoon.EclipticLongitude(JD);
            Assert.Equal(expectedEclipticLongitude, moonLong);
        }

        [Theory]
        [InlineData(2448724.5, 368409.68481612689, 0.99199010252035424)]
        public void RadiusVectorTest(double JD, double expectedRadiusVector, double expectedParallax)
        {
            double moonRadius = AASMoon.RadiusVector(JD);
            Assert.Equal(expectedRadiusVector, moonRadius);
        }

        [Theory]
        [InlineData(2448724.5, 273.73752853280308)]
        public void TrueLongitudeAscendingNodeTest(double JD, double expectedTrueLongitudeAscendingNode)
        {
            double trueMeanAscendingNode = AASMoon.TrueLongitudeAscendingNode(JD);
            Assert.Equal(expectedTrueLongitudeAscendingNode, trueMeanAscendingNode);
        }

        [Theory]
        [InlineData(2448724.5, 134.29018171936332)]
        public void MeanLongitudeTest(double JD, double expectedMeanLongitude)
        {
            double meanLongitude = AASMoon.MeanLongitude(JD);
            Assert.Equal(expectedMeanLongitude, meanLongitude);
        }

        [Theory]
        [InlineData(2448724.5, 113.8423037166358)]
        public void MeanElongationTest(double JD, double expectedMeanElongation)
        {
            double meanElongation = AASMoon.MeanElongation(JD);
            Assert.Equal(expectedMeanElongation, meanElongation);
        }

        [Theory]
        [InlineData(2448724.5, 5.1508325229588081)]
        public void MeanAnomalyTest(double JD, double expectedMeanAnomaly)
        {
            double meanAnomaly = AASMoon.MeanAnomaly(JD);
            Assert.Equal(expectedMeanAnomaly, meanAnomaly);
        }


        [Theory]
        [InlineData(2448724.5, 274.40065619286639)]
        public void MeanLongitudeAscendingNodeTest(double JD, double expectedMeanLongitudeAscendingNode)
        {
            double moonMeanAscendingNode = AASMoon.MeanLongitudeAscendingNode(JD);
            Assert.Equal(expectedMeanLongitudeAscendingNode, moonMeanAscendingNode);
        }

        [Theory]
        [InlineData(2448724.5, 219.88972072785691)]
        public void ArgumentOfLatitudeTest(double JD, double expectedArgumentOfLatitude)
        {
            double argumentOfLatitude = AASMoon.ArgumentOfLatitude(JD);
            Assert.Equal(expectedArgumentOfLatitude, argumentOfLatitude);
        }

        [Theory]
        [InlineData(2448724.5, 129.13954439718148)]
        public void MeanLongitudePerigeeTest(double JD, double expectedMeanLongitudePerigee)
        {
            double moonMeanPerigee = AASMoon.MeanLongitudePerigee(JD);
            Assert.Equal(expectedMeanLongitudePerigee, moonMeanPerigee);
        }

        [Theory]
        [InlineData(1.0254225820430043, 356399.41899484064)]
        [InlineData(0.991990, 368409.72288679035)]
        public void HorizontalParallaxToRadiusVectorTest(double parallax, double expectedRadiusVector)
        {
            double radiusVector = AASMoon.HorizontalParallaxToRadiusVector(parallax);
            Assert.Equal(expectedRadiusVector, radiusVector);
        }

        [Theory]
        [InlineData(368409.72288679035, 0.99199)]
        public void RadiusVectorToHorizontalParallaxTest(double radiusVector, double expectedHorizontalParallax)
        {
            double horizontalParallax = AASMoon.RadiusVectorToHorizontalParallax(radiusVector);
            Assert.Equal(expectedHorizontalParallax, horizontalParallax);
        }
    }
}