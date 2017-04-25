using System;
using SchantzDemo.Domain;
using SchantzDemo.Services;

namespace SchantzDemo
{
    class SchantzDemo
    {
        private readonly ILogger _logger;
        private readonly IArgumentParser _parser;
        private readonly ITriangleFactory _triangleFactory;

        public SchantzDemo(ILogger logger, IArgumentParser parser, ITriangleFactory triangleFactory)
        {
            _logger = logger;
            _parser = parser;
            _triangleFactory = triangleFactory;
        }

        /// <summary>
        /// display type of triangle based on input
        /// </summary>
        /// <param name="args"></param>
        public void Run(string[] args)
        {
            try
            {
                float[] sides = _parser.Parse(args);
                Triangle inputTriangle = _triangleFactory.CreateFromArray(sides);
                if (inputTriangle != null)
                {
                    Console.WriteLine($"Triangle (A;B;C) = ({sides[0]};{sides[1]};{sides[2]}) - is of type: {inputTriangle.Type}");
                    return;
                }
                _logger.Error("Unable to create triangle given input sides.");
            }
            catch (ArgumentException)
            {
                // if an exception is thrown - display the error
                _logger.Error("Unable to parse array. Input is wrong");
            }
            catch (Exception ex)
            {
                // if an exception is thrown - display the error
                _logger.Error("Failed to determine triangle type: " + ex.Message);
            }
            // if triangle type was not determined then print the syntax info.
            PrintSyntax();
        }


        /// <summary>
        /// Display the usage of this console app
        /// </summary>
        private static void PrintSyntax()
        {
            Console.WriteLine(@"
Prints information about a triangle

Syntax: Triangle.exe sideA sideB sideC
sideA: length of side A
sideB: length of side B
sideC: length of side C

Example (note that decimal numbers will be parsed according to your regional settings ;-):
Triangle 3,141592 4 5,99");
        }

    }
}