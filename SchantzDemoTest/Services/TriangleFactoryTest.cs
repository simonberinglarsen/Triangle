using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchantzDemo.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SchantzDemo.Domain;

namespace SchantzDemoTest.Services
{
    [TestClass]
    public class TriangleFactoryTest
    {
        private Mock<ILogger> loggerMock;
        private TriangleFactory target;

        [TestInitialize]
        public void TestInitialize()
        {
            loggerMock = new Mock<ILogger>();
            loggerMock.Setup(mock => mock.Error(It.IsAny<string>()));
            target = new TriangleFactory(loggerMock.Object);
        }

        [TestMethod]
        public void GivenNullInput_CreateFromArray_ThrowsExceptionAndLogsError()
        {
            // given
            float[] input = null;

            // when
            bool exceptionIsThrown = false;
            try
            {
                target.CreateFromArray(input);
            }
            catch
            {
                exceptionIsThrown = true;
            }

            //then
            loggerMock.Verify(mock => mock.Error(It.IsAny<string>()), Times.Once());
            Assert.IsTrue(exceptionIsThrown);
        }

        [TestMethod]
        public void GivenTooshortArray_CreateFromArray_ThrowsExceptionAndLogsError()
        {
            // given
            float[] input = new float[] { 3, 4 };
            
            // when
            bool exceptionIsThrown = false;
            try
            {
                target.CreateFromArray(input);
            }
            catch
            {
                exceptionIsThrown = true;
            }

            //then
            loggerMock.Verify(mock => mock.Error(It.IsAny<string>()), Times.Once());
            Assert.IsTrue(exceptionIsThrown);
        }

        [TestMethod]
        public void GivenTooLongArray_CreateFromArray_NoExceptionNoLogs()
        {
            // given
            float[] input = new float[] {3, 3, 3, 10000};

            // when
            bool exceptionIsThrown = false;
            try
            {
                target.CreateFromArray(input);
            }
            catch
            {
                exceptionIsThrown = true;
            }

            //then
            loggerMock.Verify(mock => mock.Error(It.IsAny<string>()), Times.Never());
            Assert.IsFalse(exceptionIsThrown);
        }

        [TestMethod]
        public void Given3Sides_CreateFromArray_NoExceptionNoLogs()
        {
            // given
            float[] input = new float[] {3, 4, 5};

            // when
            bool exceptionIsThrown = false;
            try
            {
                target.CreateFromArray(input);
            }
            catch
            {
                exceptionIsThrown = true;
            }

            //then
            loggerMock.Verify(mock => mock.Error(It.IsAny<string>()), Times.Never());
            Assert.IsFalse(exceptionIsThrown);
        }
    }
}
