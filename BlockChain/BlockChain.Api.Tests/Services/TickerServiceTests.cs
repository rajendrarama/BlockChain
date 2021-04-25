using BlockChain.Api.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BlockChain.Api.Tests.Services
{
    [TestClass]
    public class TickerServiceTests
    {
        private Mock<ILogger<TickerService>> _mockLogger;

        [TestInitialize]
        public void Initialise()
        {
            _mockLogger = new Mock<ILogger<TickerService>>();
        }

        [TestMethod]
        public void Constructor_WhenLoggerIsNull_ShouldThrowAnException()
        {
            Action act = () => new TickerService(null);
            act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("logger");
        }

        [TestMethod]
        public void GetTickerData_WhenInvoked_ShouldReturnDictionary()
        {
            var tickerService = new TickerService(_mockLogger.Object);
            var result = tickerService.GetTickerData();
            result.Count.Should().BeGreaterThan(0);
        }
    }
}
