using System;
using Xunit;
using Godot;

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
        public void PlaneTestHasPointXandZareNotZero_ShouldReturnTrue()
        {
            var plane = new Plane(1, 0, 0, 1);
            for (int j = 0; j < 50; j++)
            {
                Vector3 v3 = plane.GetAnyPoint();
                Assert.True(plane.HasPoint(v3));
            }
        }
        [Fact]
        public void PlaneTestHasPointDandZareNotZero_ShouldReturnTrue()
        {
            var plane = new Plane(0, 1, 0, (float)0.5);
            for (int j = 0; j < 50; j++)
            {
                Vector3 v3 = plane.GetAnyPoint();
                Assert.True(plane.HasPoint(v3));
            }
        }
        [Fact]
        public void PlaneTestHasPointYisNotZero_ShouldReturnTrue()
        {
            var plane = new Plane(0, 0, 1, 0);
            for (int j = 0; j < 50; j++)
            {
                Vector3 v3 = plane.GetAnyPoint();
                Assert.True(plane.HasPoint(v3));
            }
        }
        [Fact]
        public void IsPointOverTestDisnotZero_ShouldReturnTrue()
        {
            var plane = new Plane((float)1, 0, 0, 0);
            Vector3 v3 = new Vector3((float)0.5, 0, 0);
            Assert.True(plane.IsPointOver(v3));
            plane = -plane;
            Assert.False(plane.IsPointOver(v3));
        }

        [Fact]
        public void IsPointOverTestVector3YisNotZero_ShouldReturnTrue()
        {
            var plane = new Plane((float)1, 0, 0, 0);
            Vector3 v3 = new Vector3(0, (float)1, 0);
            Assert.True(plane.HasPoint(v3));
            Assert.False(plane.IsPointOver(v3));
            plane = -plane;
            Assert.False(plane.IsPointOver(v3));
        }

        [Fact]
        public void IsPointOverTestYisNotZero_ShouldReturnTrue()
        {
            var plane = new Plane(0, (float)1, 0, 0);
            Vector3 v3 = new Vector3(0, (float)1, 0);
            Assert.False(plane.HasPoint(v3));
            Assert.True(plane.IsPointOver(v3));
            plane = -plane;
            Assert.False(plane.IsPointOver(v3));
        }
        [Fact]
        public void IsPointOverTestReflectVectorAndReflectPlane_ShouldReturnTrue()
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
    }
}
