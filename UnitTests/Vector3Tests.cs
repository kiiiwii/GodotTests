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

        [Fact]
        public void Test1()
        {
            int i = 0;
            Vector2 v0 = new Vector2(i, ++i);
            while (i <= 30)
            {
                Vector2 v1 = new Vector2(i, ++i);
                Assert.Equal(v1.x - 1, v0.x);
                Assert.Equal(v1.y - 1, v0.y);
                v0 = v1;
            }
        }
        [Fact]
        public void Test2()
        {
            Vector2 v1 = new Vector2(2, 5);
            var b = new Vector2();
            Assert.True(b.x == 0.0f);
            Assert.True(b.y == 0.0f);

            int i = 0;
            while (i <= 30)
            {
                Vector2 v2 = new Vector2(i, ++i);
                b = v1 * v2;
                Assert.Equal(b.x, v2.x * 2);
                Assert.Equal(b.y, v2.y * 5);
            }
        }

        [Fact]
        public void Test3()
        {
            Vector2 v1 = new Vector2(10, 10);
            var b = new Vector2();

            int i = 0;
            while (i <= 30)
            {
                Vector2 v2 = new Vector2(i, ++i);
                b = v1 * v2;
                b = b / new Vector2(2, 5);
                Assert.Equal(b.x, v2.x * 5);
                Assert.Equal(b.y, v2.y * 2);
            }
        }

        [Fact]
        public void TestNormilize()
        {
            int i = 0;
            while (i <= 30)
            {
                var a = new Vector2(2, 4);
                var b = new Vector2(2, 4);
                var m = Mathf.Sqrt(a.x * a.x + a.y * a.y);
                a.x /= m;
                a.y /= m;
                Assert.Equal(a.x, b.Normalized().x);
                Assert.Equal(a.y, b.Normalized().y);
                i++;
            }
        }

        private float GetDegreesFromRadians(float radians) => radians * 180 / (float)Math.PI;
    }
}