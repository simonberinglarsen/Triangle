using System;

namespace SchantzDemo.Domain
{
    /// <summary>
    /// Domain object representing a triangle
    /// </summary>
    public class Triangle
    {
        // length of each side in the triangle
        private readonly float _sideA;
        private readonly float _sideB;
        private readonly float _sideC;
        /// <summary>
        /// Types of Triangles
        /// Andet: if sides cannot connect or if sides are different length
        /// Ligesidet: if all sides are equal in length
        /// Ligebenet: if two sides are equal in length but different from last side
        /// </summary>
        public enum Types
        {
            Ligesidet,
            Ligebenet,
            Ugyldig,
            Andet
        }
        /// <summary>
        /// Construct a triangle
        /// </summary>
        /// <param name="sideA"></param>
        /// <param name="sideB"></param>
        /// <param name="sideC"></param>
        /// <exception cref="ArgumentException">If any side is zero</exception>
        public Triangle(float sideA, float sideB, float sideC)
        {
            if (sideA == 0) throw new ArgumentException("sideA cannot be zero");
            _sideA = Math.Abs(sideA);
            if (sideB == 0) throw new ArgumentException("sideB cannot be zero");
            _sideB = Math.Abs(sideB);
            if (sideC == 0) throw new ArgumentException("sideC cannot be zero");
            _sideC = Math.Abs(sideC);
        }

        /// <summary>
        /// true if all sides in triangle can be connected
        /// </summary>
        private bool IsValidTriangle =>
            (_sideA + _sideB) > _sideC &&
            (_sideA + _sideC) > _sideB &&
            (_sideB + _sideC) > _sideA;

        /// <summary>
        /// returns type of triangle see TriangleType enum
        /// </summary>
        public Types Type
        {
            get
            {
                // not valid: check if this is an invalid triangle
                if (!IsValidTriangle)
                    return Types.Ugyldig;
                // all sides equal: check if all sides are equal in length
                if (_sideA == _sideB && _sideB == _sideC)
                    return Types.Ligesidet;
                // two equal sides: if not all sides are equal then see if at least two sides are equal
                if (_sideA == _sideB || _sideA == _sideC || _sideB == _sideC)
                    return Types.Ligebenet;
                // no equal sides: all sides have different length
                return Types.Andet;
            }
        }

    }
}