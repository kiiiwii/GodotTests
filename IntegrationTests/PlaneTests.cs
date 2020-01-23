using System;
using Xunit;
using Godot;
using System.Collections.Generic;

namespace IntegrationTests
{
    public class PlaneTests
    {
        private float _epsilon = 0.001f;

        [Fact]
        public void PlaneCenter_PointInCenter_DistanceBetweenShouldBe0()
        {
            var plane = new Plane(0, 0, 1, 1);
            var vector = new Vector3(0, 0, 1);

            var center = plane.Center;
            var distance = vector.DistanceTo(center);

            Assert.InRange(distance, 0 - _epsilon, 0 + _epsilon);
        }

        [Fact]
        public void PlaneCenter_PointAboveCenter_DistanceBetweenShouldNotBe0()
        {
            var plane = new Plane(0, 0, 1, 1);
            var vector = new Vector3(0, 0, 1 + _epsilon * 2);

            var center = plane.Center;
            var distance = vector.DistanceTo(center);

            Assert.NotInRange(distance, 0 - _epsilon, 0 + _epsilon);
        }

        [Fact]
        public void PlaneTestHasPoint1()
        {
            var plane = new Plane(1, 0, 0, 1);
            for (int j = 0; j < 50; j++)
            {
                Vector3 v3 = plane.GetAnyPoint();
                Assert.True(plane.HasPoint(v3));
            }
        }
        [Fact]
        public void PlaneTestHasPoint2()
        {
            var plane = new Plane(0, 1, 0, (float)0.5);
            for (int j = 0; j < 50; j++)
            {
                Vector3 v3 = plane.GetAnyPoint();
                Assert.True(plane.HasPoint(v3));
            }
        }
        [Fact]
        public void PlaneTestHasPoint3()
        {
            var plane = new Plane(0, 0, 1, 0);
            for (int j = 0; j < 50; j++)
            {
                Vector3 v3 = plane.GetAnyPoint();
                Assert.True(plane.HasPoint(v3));
            }
        }
        [Fact]
        public void IsPointOverTest1()
        {
            var plane = new Plane((float)1, 0, 0, 0);
            Vector3 v3 = new Vector3((float)0.5, 0, 0);
            Assert.True(plane.IsPointOver(v3));
            plane = -plane;
            Assert.False(plane.IsPointOver(v3));
        }

        [Fact]
        public void IsPointOverTest2()
        {
            var plane = new Plane((float)1, 0, 0, 0);
            Vector3 v3 = new Vector3(0, (float)1, 0);
            Assert.True(plane.HasPoint(v3));
            Assert.False(plane.IsPointOver(v3));
            plane = -plane;
            Assert.False(plane.IsPointOver(v3));
        }

        [Fact]
        public void IsPointOverTest3()
        {
            var plane = new Plane(0, (float)1, 0, 0);
            Vector3 v3 = new Vector3(0, (float)1, 0);
            Assert.False(plane.HasPoint(v3));
            Assert.True(plane.IsPointOver(v3));
            plane = -plane;
            Assert.False(plane.IsPointOver(v3));
        }
        [Fact]
        public void IsPointOverTest4()
        {
            Vector3 v3Normal = new Vector3(1, 0, 0);
            v3Normal = v3Normal.Normalized();
            var plane = new Plane(v3Normal, 0);
            Vector3 v3 = new Vector3(1, 0, 0);
            Assert.True(plane.IsPointOver(v3));
            plane = -plane;
            Assert.False(plane.IsPointOver(v3));
            v3 = v3.Reflect(new Vector3(0, 1, 1).Normalized());
            Assert.True(plane.IsPointOver(v3));
        }

        //Start IntersectRay
        public static IEnumerable<object[]> IntersectRayData =>
            new List<object[]>
            {
                new object[]{
                    new Vector3(0, 0, 1),
                    1.0f,
                    new Vector3(0, 0, 0),
                    new Vector3(0, 0, 1),
                    new Vector3(0, 0, 1)
                },
                new object[]{
                    new Vector3(0, 0, 1),
                    1.0f,
                    new Vector3(0, 0, 0),
                    new Vector3(0, 0, -1),
                    null
                },
                new object[]{
                    new Vector3(0, 0, 1),
                    1.0f,
                    new Vector3(0, 0, 0),
                    new Vector3(1, 1, 0.000001f),
                    new Vector3(1000000, 1000000, 1)
                },
                new object[]{
                    new Vector3(0, 0, 1),
                    0.0f,
                    new Vector3(0, 0, 0),
                    new Vector3(1, 1, 0),
                    null
                }
            };


        [Theory]
        [MemberData(nameof(IntersectRayData))]
        public void IntersectRay_ShouldReturnCorrectResult(Vector3 normalVector, float distance, Vector3 from, Vector3 direction, Vector3? expected) {
            
            var testObj = new Plane(normalVector, distance);
            var result = testObj.IntersectRay(from, direction);

            Assert.Equal(expected, result);
        }
    }
}
