using System;
using ConsoleApplication9;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApplication9Test
{
    [TestClass]
    public class TriangleTest
    {
        [TestMethod]
        public void ValidTrianglesAllPermutations_TrianglesCreated_AllIsValid()
        {
            // given sides
            float sideA = 3;
            float sideB = 4;
            float sideC = 5;

            // when all permutations are created
            Triangle triangle1 = new Triangle(sideA, sideB, sideC);
            Triangle triangle2 = new Triangle(sideA, sideC, sideB);
            Triangle triangle3 = new Triangle(sideB, sideA, sideC);
            Triangle triangle4 = new Triangle(sideB, sideC, sideA);
            Triangle triangle5 = new Triangle(sideC, sideA, sideB);
            Triangle triangle6 = new Triangle(sideC, sideB, sideA);

            // then all is valid
            Assert.IsTrue(triangle1.IsValidTriangle);
            Assert.IsTrue(triangle2.IsValidTriangle);
            Assert.IsTrue(triangle3.IsValidTriangle);
            Assert.IsTrue(triangle4.IsValidTriangle);
            Assert.IsTrue(triangle5.IsValidTriangle);
            Assert.IsTrue(triangle6.IsValidTriangle);
        }

        [TestMethod]
        public void InvalidTrianglesAllPermutations_TrianglesCreated_AllIsInvalid()
        {
            // given sides
            float sideA = 1;
            float sideB = 2;
            float sideC = 6;

            // when all permutations are created
            Triangle triangle1 = new Triangle(sideA, sideB, sideC);
            Triangle triangle2 = new Triangle(sideA, sideC, sideB);
            Triangle triangle3 = new Triangle(sideB, sideA, sideC);
            Triangle triangle4 = new Triangle(sideB, sideC, sideA);
            Triangle triangle5 = new Triangle(sideC, sideA, sideB);
            Triangle triangle6 = new Triangle(sideC, sideB, sideA);

            // then all is invalid
            Assert.IsFalse(triangle1.IsValidTriangle);
            Assert.IsFalse(triangle2.IsValidTriangle);
            Assert.IsFalse(triangle3.IsValidTriangle);
            Assert.IsFalse(triangle4.IsValidTriangle);
            Assert.IsFalse(triangle5.IsValidTriangle);
            Assert.IsFalse(triangle6.IsValidTriangle);
        }

        [TestMethod]
        public void IsoscelesTrianglesAllPermutations_TrianglesCreated_AllIsOfTypeIsosceles()
        {
            // given sides
            float sideA = 5;
            float sideB = 5;
            float sideC = 6;

            // when all permutations are created
            Triangle triangle1 = new Triangle(sideA, sideB, sideC);
            Triangle triangle2 = new Triangle(sideA, sideC, sideB);
            Triangle triangle3 = new Triangle(sideB, sideA, sideC);
            Triangle triangle4 = new Triangle(sideB, sideC, sideA);
            Triangle triangle5 = new Triangle(sideC, sideA, sideB);
            Triangle triangle6 = new Triangle(sideC, sideB, sideA);

            // then all is invalid
            Assert.IsTrue(triangle1.TriangleType == Triangle.TriangleTypes.Isosceles);
            Assert.IsTrue(triangle2.TriangleType == Triangle.TriangleTypes.Isosceles);
            Assert.IsTrue(triangle3.TriangleType == Triangle.TriangleTypes.Isosceles);
            Assert.IsTrue(triangle4.TriangleType == Triangle.TriangleTypes.Isosceles);
            Assert.IsTrue(triangle5.TriangleType == Triangle.TriangleTypes.Isosceles);
            Assert.IsTrue(triangle6.TriangleType == Triangle.TriangleTypes.Isosceles);
        }

        [TestMethod]
        public void EquilateralTrianglesAllPermutations_TrianglesCreated_AllIsOfTypeEquilateral()
        {
            // given sides
            float sideA = 15;
            float sideB = 15;
            float sideC = 15;

            // when all permutations are created
            Triangle triangle1 = new Triangle(sideA, sideB, sideC);
            Triangle triangle2 = new Triangle(sideA, sideC, sideB);
            Triangle triangle3 = new Triangle(sideB, sideA, sideC);
            Triangle triangle4 = new Triangle(sideB, sideC, sideA);
            Triangle triangle5 = new Triangle(sideC, sideA, sideB);
            Triangle triangle6 = new Triangle(sideC, sideB, sideA);

            // then all is invalid
            Assert.IsTrue(triangle1.TriangleType == Triangle.TriangleTypes.Equilateral);
            Assert.IsTrue(triangle2.TriangleType == Triangle.TriangleTypes.Equilateral);
            Assert.IsTrue(triangle3.TriangleType == Triangle.TriangleTypes.Equilateral);
            Assert.IsTrue(triangle4.TriangleType == Triangle.TriangleTypes.Equilateral);
            Assert.IsTrue(triangle5.TriangleType == Triangle.TriangleTypes.Equilateral);
            Assert.IsTrue(triangle6.TriangleType == Triangle.TriangleTypes.Equilateral);
        }

        [TestMethod]
        public void OtherTrianglesAllPermutations_TrianglesCreated_AllIsOfTypeOther()
        {
            // given sides
            float sideA = 3;
            float sideB = 4;
            float sideC = 5;

            // when all permutations are created
            Triangle triangle1 = new Triangle(sideA, sideB, sideC);
            Triangle triangle2 = new Triangle(sideA, sideC, sideB);
            Triangle triangle3 = new Triangle(sideB, sideA, sideC);
            Triangle triangle4 = new Triangle(sideB, sideC, sideA);
            Triangle triangle5 = new Triangle(sideC, sideA, sideB);
            Triangle triangle6 = new Triangle(sideC, sideB, sideA);

            // then all is invalid
            Assert.IsTrue(triangle1.TriangleType == Triangle.TriangleTypes.Other);
            Assert.IsTrue(triangle2.TriangleType == Triangle.TriangleTypes.Other);
            Assert.IsTrue(triangle3.TriangleType == Triangle.TriangleTypes.Other);
            Assert.IsTrue(triangle4.TriangleType == Triangle.TriangleTypes.Other);
            Assert.IsTrue(triangle5.TriangleType == Triangle.TriangleTypes.Other);
            Assert.IsTrue(triangle6.TriangleType == Triangle.TriangleTypes.Other);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SideAIsZero_TriangleCreated_ThrowsArgumentException()
        {
            Triangle triangle = new Triangle(0, 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SideBIsZero_TriangleCreated_ThrowsArgumentException()
        {
            Triangle triangle = new Triangle(1, 0, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SideCIsZero_TriangleCreated_ThrowsArgumentException()
        {
            Triangle triangle = new Triangle(1, 1, 0);
        }

        [TestMethod]
        public void AllTypesWithNegativeSide_TrianglesCreated_TypeCorrectlyIdentified()
        {
            Triangle triangleIsosceles = new Triangle(10, 12, -10);
            Triangle triangleEquilateral = new Triangle(22, 22, -22);
            Triangle triangleOther = new Triangle(-6, -8, -10);
            Triangle triangleInvalid = new Triangle(-1, 2, 5);

            Assert.IsTrue(triangleIsosceles.TriangleType == Triangle.TriangleTypes.Isosceles);
            Assert.IsTrue(triangleEquilateral.TriangleType == Triangle.TriangleTypes.Equilateral);
            Assert.IsTrue(triangleOther.TriangleType == Triangle.TriangleTypes.Other);
            Assert.IsTrue(triangleInvalid.TriangleType == Triangle.TriangleTypes.Invalid);

        }
    }
}
