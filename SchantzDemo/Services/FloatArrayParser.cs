using System;

namespace SchantzDemo.Services
{
    /// <summary>
    /// Commandline parser for float arrays
    /// </summary>
    public class FloatArrayParser : IArgumentParser
    {
        private readonly ILogger _logger;
        public FloatArrayParser(ILogger logger)
        {
            _logger = logger;
        }
        public float[] Parse(string[] args)
        {
            try
            {
                // if no arguments return null
                if (args == null)
                    throw new NullReferenceException("no input given");
                if (args.Length != 3)
                    throw new ArgumentException($"3 arguments expected and {args.Length} was given");
                // assume correct arguments - if arguments cannot be parsed exceptions will be thrown
                float sideA = float.Parse(args[0]);
                float sideB = float.Parse(args[1]);
                float sideC = float.Parse(args[2]);
                return new[]
                {
                    sideA, sideB, sideC
                };

            }
            catch (Exception)
            {
                _logger.Error("Failed to parse input to read triangle sides");
                throw;
            }
        }
    }
}