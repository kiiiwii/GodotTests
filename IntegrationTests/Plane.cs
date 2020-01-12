using System;
using Xunit;
using Godot;

namespace IntegrationTestsKseniia
{
    public class PlaneTests
    {
        [Fact]
        public void PlaneTestHasPoint1()
        {
            var plane = new Plane(1, 0, 0, 1);
            for (int j=0; j< 50; j++) {
                Vector3 v3 = plane.GetAnyPoint();
                Assert.True(plane.HasPoint(v3));
            }
        }
        [Fact]
        public void PlaneTestHasPoint2()
        {
            var plane = new Plane(0, 1, 0, (float)0.5);
            for (int j=0; j< 50; j++) {
                Vector3 v3 = plane.GetAnyPoint();
                Assert.True(plane.HasPoint(v3));
            }
        }
        [Fact]
        public void PlaneTestHasPoint3()
        {
            var plane = new Plane(0, 0, 1, 0);
            for (int j=0; j< 50; j++) {
                Vector3 v3 = plane.GetAnyPoint();
                Assert.True(plane.HasPoint(v3));
            }
        }
        [Fact]
        public void IsPointOverTest1()
        {
            var plane = new Plane((float)1, 0, 0, 0);
            Vector3 v3 = new Vector3((float)0.5,0,0);
            Assert.True(plane.IsPointOver(v3));
            plane = -plane;
            Assert.False(plane.IsPointOver(v3));
        }

        [Fact]
        public void IsPointOverTest2()
        {
            var plane = new Plane((float)1, 0, 0, 0);
            Vector3 v3 = new Vector3(0,(float)1,0);
            Assert.True(plane.HasPoint(v3));
            Assert.False(plane.IsPointOver(v3));
            plane = -plane;
            Assert.False(plane.IsPointOver(v3));
        }

        [Fact]
        public void IsPointOverTest3()
        {
            var plane = new Plane(0,(float)1, 0, 0);
            Vector3 v3 = new Vector3(0,(float)1,0);
            Assert.False(plane.HasPoint(v3));
            Assert.True(plane.IsPointOver(v3));
            plane = -plane;
            Assert.False(plane.IsPointOver(v3));
        }
        [Fact]
        public void IsPointOverTest4()
        {
            Vector3 v3Normal = new Vector3(1,0,0);
            v3Normal = v3Normal.Normalized();
            var plane = new Plane(v3Normal,0);
            Vector3 v3 = new Vector3(1,0,0);
            Assert.True(plane.IsPointOver(v3));
            plane = -plane;
            Assert.False(plane.IsPointOver(v3));
            v3= v3.Reflect(new Vector3(0,1,1).Normalized());
            Assert.True(plane.IsPointOver(v3));
        }
    }
}
