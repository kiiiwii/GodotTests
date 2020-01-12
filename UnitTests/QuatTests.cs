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
        
    }
}