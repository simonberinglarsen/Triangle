using System;

namespace SchantzDemo.Services
{
    class Logger : ILogger
    {
        /// <summary>
        /// Add message to error log..
        /// </summary>
        /// <param name="message"></param>
        public void Error(string message)
        {
            Console.WriteLine($"ERROR: {message}");
        }
    }
}