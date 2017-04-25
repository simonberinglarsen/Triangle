using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SchantzDemo.Services;

namespace SchantzDemoTest.Services
{
    [TestClass]
    public class FloatArrayParserTest
    {
        private FloatArrayParser _target;
        private Mock<ILogger> _loggerMock;

        [TestInitialize]
        public void TestInitialize()
        {
            // given
            _loggerMock = new Mock<ILogger>();
            _loggerMock.Setup(mock => mock.Error(It.IsAny<string>()));
            _target = new FloatArrayParser(_loggerMock.Object);
        }

        [TestMethod]
        public void Null_Parse_LogErrorAndThrowsException()
        {
            // given
            string[] input = null;

            // when
            bool exceptionIsThrown = false;
            try
            {
                _target.Parse(input);
            }
            catch
            {
                exceptionIsThrown = true;
            }

            //then
            _loggerMock.Verify(mock => mock.Error(It.IsAny<string>()), Times.Once());
            Assert.IsTrue(exceptionIsThrown);
        }

        [TestMethod]
        public void NonNumericCharacters_Parse_LogErrorAndThrowsException()
        {
            // given
            string[] input = new string[] {"1", "2", "SIMON"};

            // when
            bool exceptionIsThrown = false;
            try
            {
                _target.Parse(input);
            }
            catch
            {
                exceptionIsThrown = true;
            }

            //then
            _loggerMock.Verify(mock => mock.Error(It.IsAny<string>()), Times.Once());
            Assert.IsTrue(exceptionIsThrown);
        }

        [TestMethod]
        public void TooLargeNumber_Parse_LogErrorAndThrowsException()
        {
            // given
            string[] input = new string[] {"111111111111111111111111111111111111111111", "4", "5"};

            // when
            bool exceptionIsThrown = false;
            try
            {
                _target.Parse(input);
            }
            catch
            {
                exceptionIsThrown = true;
            }

            //then
            _loggerMock.Verify(mock => mock.Error(It.IsAny<string>()), Times.Once());
            Assert.IsTrue(exceptionIsThrown);
        }

        [TestMethod]
        public void TooManyElements_Parse_LogErrorAndThrowsException()
        {
            // given
            string[] input = new string[] {"3", "4", "5", "6"};

            // when
            bool exceptionIsThrown = false;
            try
            {
                _target.Parse(input);
            }
            catch
            {
                exceptionIsThrown = true;
            }

            //then
            _loggerMock.Verify(mock => mock.Error(It.IsAny<string>()), Times.Once());
            Assert.IsTrue(exceptionIsThrown);
        }

        [TestMethod]
        public void TooFewElements_Parse_LogErrorAndThrowsException()
        {
            // given
            string[] input = new string[] {"3"};

            // when
            bool exceptionIsThrown = false;
            try
            {
                _target.Parse(input);
            }
            catch
            {
                exceptionIsThrown = true;
            }

            //then
            _loggerMock.Verify(mock => mock.Error(It.IsAny<string>()), Times.Once());
            Assert.IsTrue(exceptionIsThrown);
        }

        [TestMethod]
        public void ThreeValidSides_Parse_NoLogNoException()
        {
            // given
            string[] input = new string[] {"3.1", "4.1", "5.1"};

            // when
            bool exceptionIsThrown = false;
            try
            {
                _target.Parse(input);
            }
            catch
            {
                exceptionIsThrown = true;
            }

            //then
            _loggerMock.Verify(mock => mock.Error(It.IsAny<string>()), Times.Never());
            Assert.IsFalse(exceptionIsThrown);
        }
    }
}