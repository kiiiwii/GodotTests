//Ksenia
using Xunit;
using Godot;

namespace UnitTests
{
    public class VectorTests
    {
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
            Assert.False(b.x == null);
            Assert.False(b.y == null);

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
    }
}
