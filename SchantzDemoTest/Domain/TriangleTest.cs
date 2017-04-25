using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchantzDemo.Domain;

namespace SchantzDemoTest.Domain
{
    [TestClass]
    public class TriangleTest
    {
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
            Assert.IsTrue(triangle1.Type == Triangle.Types.Ligebenet);
            Assert.IsTrue(triangle2.Type == Triangle.Types.Ligebenet);
            Assert.IsTrue(triangle3.Type == Triangle.Types.Ligebenet);
            Assert.IsTrue(triangle4.Type == Triangle.Types.Ligebenet);
            Assert.IsTrue(triangle5.Type == Triangle.Types.Ligebenet);
            Assert.IsTrue(triangle6.Type == Triangle.Types.Ligebenet);
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
            Assert.IsTrue(triangle1.Type == Triangle.Types.Ligesidet);
            Assert.IsTrue(triangle2.Type == Triangle.Types.Ligesidet);
            Assert.IsTrue(triangle3.Type == Triangle.Types.Ligesidet);
            Assert.IsTrue(triangle4.Type == Triangle.Types.Ligesidet);
            Assert.IsTrue(triangle5.Type == Triangle.Types.Ligesidet);
            Assert.IsTrue(triangle6.Type == Triangle.Types.Ligesidet);
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
            Assert.IsTrue(triangle1.Type == Triangle.Types.Andet);
            Assert.IsTrue(triangle2.Type == Triangle.Types.Andet);
            Assert.IsTrue(triangle3.Type == Triangle.Types.Andet);
            Assert.IsTrue(triangle4.Type == Triangle.Types.Andet);
            Assert.IsTrue(triangle5.Type == Triangle.Types.Andet);
            Assert.IsTrue(triangle6.Type == Triangle.Types.Andet);
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

            Assert.IsTrue(triangleIsosceles.Type == Triangle.Types.Ligebenet);
            Assert.IsTrue(triangleEquilateral.Type == Triangle.Types.Ligesidet);
            Assert.IsTrue(triangleOther.Type == Triangle.Types.Andet);
            Assert.IsTrue(triangleInvalid.Type == Triangle.Types.Ugyldig);

        }
    }
}
