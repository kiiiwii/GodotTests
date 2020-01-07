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
    }
}
