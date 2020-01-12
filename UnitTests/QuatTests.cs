using Godot;
using Xunit;
using System.Collections.Generic;
using System;

namespace UnitTests
{
    public class QuatTests
    {
        // Start from basis
        public static IEnumerable<object[]> FromBasisData =>
            new List<object[]>
            {
                new object[]{
                    new Basis(
                        new Vector3(0.0f, -1.0f, 0.0f),
                        new Vector3(1.0f, 0.0f, 0.0f), 
                        new Vector3(0.0f, 0.0f, 1.0f)
                    )
                },
                new object[]{
                    new Basis(
                        new Vector3(0.0f, 0.0f, 1.0f),
                        new Vector3(0.0f, 1.0f, 0.0f),
                        new Vector3(-1.0f, 0.0f, 0.0f)
                    )
                },
                new object[]{
                    new Basis(
                        new Vector3(1.0f, 0.0f, 0.0f),
                        new Vector3(0.0f, 0.0f, -1.0f),
                        new Vector3(0.0f, 1.0f, 0.0f)
                    )
                }
            };

        [Theory]
        [MemberData(nameof(FromBasisData))]
        private void FromBasis_CoordinatesShoudlBeCorrect(Basis basis) {
            var result = new Quat(basis);
            var expected = basis.Quat();
            Assert.Equal(expected.w, result.w);
            Assert.Equal(expected.x, result.x);
            Assert.Equal(expected.y, result.y);
            Assert.Equal(expected.z, result.z);
        }

        // Start from euler
        public static IEnumerable<object[]> FromEulerData =>
            new List<object[]>
            {
                new object[]{
                    new Vector3(0, (float)Math.PI/2, 0),
                    0.70710677f,
                    0.0f,
                    0.70710677f,
                    0f
                },
                new object[]{
                    new Vector3((float)Math.PI/2, 0.0f, 0.0f),
                    0.70710677f,
                    0.70710677f,
                    0.0f,
                    0.0f
                },
                new object[]{
                    new Vector3(83.0f, 58.0f, 70.0f),
                    -0.7084004f,
                    -0.6387032f,
                    -0.27782744f,
                    0.114188105f                    
                }
            };
        [Theory]
        [MemberData(nameof(FromEulerData))]
        private void FromEuler_CoordinatesShoudlBeCorrect(Vector3 vector, float w, float x, float y, float z){
            var result = new Quat(vector);
            
            Assert.Equal(w, result.w);
            Assert.Equal(x, result.x);
            Assert.Equal(y, result.y);
            Assert.Equal(z, result.z);
        }

        // Start from axis and angle
        public static IEnumerable<object[]> FromAxisAngleData =>
            new List<object[]>
            {
                new object[]{
                    new Vector3(0.0f, 0.0f, 0.0f),
                    9.0f,
                    0.0f,
                    0.0f,
                    0.0f,
                    0.0f
                },
                new object[]{
                    new Vector3(0.802f, 0.267f, 0.534f),
                    5.0f,
                    -0.8011436f,
                    0.4800589f,
                    0.15982011f,
                    0.319640219f
                }
            };
        [Theory]
        [MemberData(nameof(FromAxisAngleData))]
        private void FromAxisAngle_CoordinatesShoudlBeCorrect(Vector3 axis, float angle, float w, float x, float y, float z){
            var result = new Quat(axis, angle);
            
            Assert.Equal(w, result.w);
            Assert.Equal(x, result.x);
            Assert.Equal(y, result.y);
            Assert.Equal(z, result.z);
        }

        [Fact]
        public void TestGetEuler1()
        {
            Quat test2 = new Quat(new Vector3(6, 5, 2));
            Vector3 v3 = test2.GetEuler();
            Vector3 compare = new Vector3((float)-0.283, (float)-1.283, 2);
            Assert.Equal(v3.x, compare.x, 3);
            Assert.Equal(v3.y, compare.y, 3);
            Assert.Equal(v3.z, compare.z, 3);
        }
        [Fact]
        public void TestGetEuler2()
        {
            Quat test2 = new Quat(new Vector3(1, 1, 1));
            Vector3 v3 = test2.GetEuler();
            Vector3 compare = new Vector3((float)1, (float)1, 1);
            Assert.Equal(v3.x, compare.x, 3);
            Assert.Equal(v3.y, compare.y, 3);
            Assert.Equal(v3.z, compare.z, 3);
        }
        [Fact]
        public void TestGetEuler3()
        {
            Quat test2 = new Quat(new Vector3((float)0.5, (float)0.5, (float)0.5));
            Vector3 v3 = test2.GetEuler();
            Vector3 compare = new Vector3((float)0.5, (float)0.5, (float)0.5);
            Assert.Equal(v3.x, compare.x, 3);
            Assert.Equal(v3.y, compare.y, 3);
            Assert.Equal(v3.z, compare.z, 3);
        }

        [Fact]
        public void TestGetEuler4()
        {
            Quat q = new Quat(1, 1, 1, 1);
            Vector3 v3 = q.GetEuler();
            Vector3 test = new Vector3(0, (float)1.57, (float)1.57);
            Assert.Equal(v3.x, test.x, 2);
            Assert.Equal(v3.y, test.y, 2);
            Assert.Equal(v3.y, test.y, 2);
        }

        [Fact]
        public void TestInversion1()
        {
            int i = 0;
            float w = (float)0.1;
            float x = (float)0.1;
            float y = (float)0.2;
            float z = (float)0.3;
            while (i <= 50)
            {
                Quat q = new Quat(w, x, y, z);
                Quat q2 = new Quat(w, x, y, z);
                q = q.Inverse();
                q = q.Inverse();
                Assert.Equal(q.x, q2.x, 2);
                Assert.Equal(q.y, q2.y, 2);
                Assert.Equal(q.z, q2.z, 2);
                Assert.Equal(q.w, q2.w, 2);

                i++;
                x += (float)0.1;
                y += (float)0.1;
                z += (float)0.1;
                w += (float)0.1;
            }
        }

        [Fact]
        public void TestIsNormalized()
        {
            int i = 0;
            float w = (float)0.1;
            float x = (float)0.1;
            float y = (float)0.2;
            float z = (float)0.3;
            while (i <= 50)
            {
                Quat q = new Quat(w, x, y, z);
                float length = q.Length;
                float length_calculated = (float)Math.Sqrt(q.x * q.x + q.y * q.y + q.z * q.z + q.w * q.w);
                Assert.Equal(length, length_calculated, 2);
                q = new Quat(q.w / q.Length, q.x / q.Length, q.y / q.Length, q.z / q.Length);
                Assert.True(q.IsNormalized());
                q = new Quat(w, x, y, z);
                q = new Quat(q.w / length_calculated, q.x / length_calculated, q.y / length_calculated, q.z / length_calculated);
                Assert.True(q.IsNormalized());
                q = new Quat(w, x, y, z);
                Assert.True(q.Normalized().IsNormalized());

                i++;
                x -= (float)0.1;
                y -= (float)0.1;
                z -= (float)0.1;
                w -= (float)0.1;
            }
        }

        [Fact]
        public void TestNormalized()
        {
            int i = 0;
            float w = (float)0.1;
            float x = (float)0.2;
            float y = (float)0.3;
            float z = (float)0.4;
            while (i <= 50)
            {
                Quat q = new Quat(x, y, z, w);
                Assert.Equal(q.x, x);
                Assert.Equal(q.y, y);
                Assert.Equal(q.z, z);
                Assert.Equal(q.w, w);
                float length = q.Length;
                q = q.Normalized();
                Assert.Equal(q.x, x / length, 2);
                Assert.Equal(q.y, y / length, 2);
                Assert.Equal(q.w, w / length, 2);
                Assert.Equal(q.z, z / length, 2);
                i++;
                x -= (float)0.1;
                y -= (float)0.1;
                z -= (float)0.1;
                w -= (float)0.1;
            }
        }

        [Fact]
        public void TestXform1()
        {
            Quat q = new Quat((float)0.5, (float)0.5, (float)0.5, (float)0.5);
            Vector3 v3 = q.Xform(new Vector3(2, 2, 2));
            Assert.Equal(v3, new Vector3(2, 2, 2));
        }

        //Multyplies by 4???????
        [Fact]
        public void TestXform2()
        {
            Quat q3 = new Quat(1, 1, 1, 1);
            Vector3 v3_3 = q3.Xform(new Vector3(1, 1, 1));
            Assert.Equal(v3_3, new Vector3(1, 1, 1));
        }
        [Fact]
        public void TestXform3()
        {
            Quat q2 = new Quat(1, 1, 1, 1);
            Vector3 v3_2 = q2.Xform(new Vector3(2, 2, 2));
            Assert.Equal(v3_2, new Vector3(2, 2, 2));
        }
        //=======
        [Fact]
        public void TestXform4()
        {
            Quat q2 = new Quat((float)0.25, (float)0.25, (float)0.25, (float)0.25);
            Vector3 test = new Vector3(1, 2, 3);
            Vector3 v3_2 = q2.Xform(test);
            v3_2 = q2.Xform(test);
            v3_2 = q2.Xform(test);
            Assert.Equal(v3_2, new Vector3(1, 2, 3));
        }
        
    }
}