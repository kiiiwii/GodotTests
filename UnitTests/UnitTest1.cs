using System;
using Xunit;
using Godot;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Vector3 v3 = new Vector3(1, 2, 3);
            Assert.Equal(v3.x, 1);
        }
    }
}
