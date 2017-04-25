using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchantzDemo.Services;

namespace SchantzDemoTest.Services
{
    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void Null_LogError_NoException()
        {
            try
            {
                Logger target = new Logger();
                target.Error(null);
            }
            catch
            {
                Assert.Fail("Exception when null input to log");   
            }
        }

        [TestMethod]
        public void EmptyString_LogError_NoException()
        {
            try
            {
                Logger target = new Logger();
                target.Error(String.Empty);
            }
            catch
            {
                Assert.Fail("Exception when null input to log");
            }
        }

        [TestMethod]
        public void VeryLargeString_LogError_NoException()
        {
            try
            {
                Logger target = new Logger();
                string largeString = Convert.ToBase64String(new byte[1048576]);
                target.Error(largeString);
            }
            catch
            {
                Assert.Fail("Exception when null input to log");
            }
        }
    }
}