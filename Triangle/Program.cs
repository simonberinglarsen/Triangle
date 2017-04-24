using System;

namespace ConsoleApplication9
{
    /// <summary>
    /// Console-application that takes 3 input numbers representing sideA, sideB and sideC in a triangle
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // create triangle from input arguments
                Triangle inputTriangle = CreateTriangleFromArguments(args);
                if (inputTriangle != null)
                {
                    if (inputTriangle.IsValidTriangle)
                    {
                        Console.WriteLine($"Type of triangle: {inputTriangle.TriangleType}");
                    }
                    else
                    {
                        Console.WriteLine("Not a valid triangle");
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                // if an exception is thrown - display the error
                Console.WriteLine("Failed to determine triangle type: " + ex.Message);
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

        /// <summary>
        /// Create a triangle from input arguments (3 sides)
        /// - if string array is too short or contains non-parsable floats exceptions will be thrown
        /// </summary>
        /// <param name="args">commandline arguments</param>
        /// <returns>triangle with sides according to arguments</returns>
        /// <exception cref="ArgumentException">If any side is zero</exception>
        /// <exception cref="FormatException">Format error when parsing float</exception>
        /// <exception cref="OverflowException">if input side cannot be contained in a float</exception>
        /// <exception cref="IndexOutOfRangeException">If less than 3 arguments has been given</exception>
        private static Triangle CreateTriangleFromArguments(string[] args)
        {
            // if no arguments return null
            if (args == null || args.Length == 0)
                return null;
            // assume correct arguments - if arguments cannot be parsed exceptions will be thrown
            float sideA = float.Parse(args[0]);
            float sideB = float.Parse(args[1]);
            float sideC = float.Parse(args[2]);
            Console.WriteLine($"A = {sideA}; B = {sideB}; C = {sideC};");
            // construct and return triangle - if any side is zero argumentexception is thrown
            Triangle triangle = new Triangle(sideA, sideB, sideC);
            return triangle;
        }
    }

}