using System;
using SchantzDemo.Domain;

namespace SchantzDemo.Services
{
    class TriangleFactory : ITriangleFactory
    {
        private readonly ILogger _logger;

        public TriangleFactory(ILogger logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Constructs a triangle based on 3 input sides
        /// </summary>
        /// <param name="sides"></param>
        /// <returns></returns>
        public Triangle CreateFromArray(float[] sides)
        {
            try
            {
                return new Triangle(sides[0], sides[1], sides[2]);
            }
            catch (Exception)
            {
                _logger.Error(sides == null
                    ? "Failed to create triangle object. Sides is null!"
                    : $"Failed to create triangle object. Number of sides: {sides.Length}");
                throw;
            }
        }
    }
}