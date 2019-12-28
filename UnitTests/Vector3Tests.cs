using System;
using Godot;
using Xunit;

namespace UnitTests
{
    public class Vector3Tests
    {
        private readonly float _epsilon = 0.01f;

        [Fact]
        public void AngleTo_0DegreesBetweenVectors_ShouldReturn0()
        {
            Vector3 v1 = new Vector3(1, 1, 1);
            Vector3 v2 = new Vector3(1, 1, 1);

            var angleRadians = v1.AngleTo(v2);
            var degrees = GetDegreesFromRadians(angleRadians);

            var expected = 0;
            Assert.InRange(degrees, expected - _epsilon, expected + _epsilon);
        }

        [Fact]
        public void AngleTo_180DegreesBetweenVectors_ShouldReturn180()
        {
            Vector3 v1 = new Vector3(1, 1, 1);
            Vector3 v2 = new Vector3(-1, -1, -1);

            var angleRadians = v1.AngleTo(v2);
            var degrees = GetDegreesFromRadians(angleRadians);

            var expected = 180;
            Assert.InRange(degrees, expected - _epsilon, expected + _epsilon);
        }

        [Theory]
        [InlineData(1.0375)]
        [InlineData(0.9637)]
        public void AngleTo_1DegreeBetweenVectors_ShouldReturn1(float xAxis)
        {
            Vector3 v1 = new Vector3(xAxis, 1, 1);
            Vector3 v2 = new Vector3(1, 1, 1);

            var angleRadians = v1.AngleTo(v2);
            var degrees = GetDegreesFromRadians(angleRadians);

            var expected = 1;
            Assert.InRange(degrees, expected - _epsilon, expected + _epsilon);
        }

        [Theory]
        [InlineData(1.0375)]
        [InlineData(0.9637)]
        public void AngleTo_179DegreeBetweenVectors_ShouldReturn179(float xAxis)
        {
            Vector3 v1 = new Vector3(xAxis, 1, 1);
            Vector3 v2 = new Vector3(-1, -1, -1);

            var angleRadians = v1.AngleTo(v2);
            var degrees = GetDegreesFromRadians(angleRadians);

            var expected = 179;
            Assert.InRange(degrees, expected - _epsilon, expected + _epsilon);
        }

        private float GetDegreesFromRadians(float radians) => radians * 180 / (float)Math.PI;
    }
}