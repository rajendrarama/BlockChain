using BlockChain.Api.Controllers;
using BlockChain.Api.Services;
using BlockChain.Api.SignalRHub;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BlockChain.Api.Tests.Controllers
{
    [TestClass]
    public class BlockChainControllerTests
    {
        private Mock<ILogger<BlockChainController>> _mockLogger;
        private Mock<IHubContext<BlockChainHub>> _mockHub;
        private Mock<ITickerService> _mockTickerService;

        [TestInitialize]
        public void Initialise()
        {
            _mockLogger = new Mock<ILogger<BlockChainController>>();
            _mockHub = new Mock<IHubContext<BlockChainHub>>();
            _mockTickerService = new Mock<ITickerService>();
        }

        [TestMethod]
        public void Constructor_WhenTickerServiceIsNull_ShouldThrowAnException()
        {
            Action act = () => new BlockChainController(_mockHub.Object, null, _mockLogger.Object);
            act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("tickerService");
        }

        [TestMethod]
        public void Constructor_WhenHubIsNull_ShouldThrowAnException()
        {
            Action act = () => new BlockChainController(null, _mockTickerService.Object, _mockLogger.Object);
            act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("hub");
        }
        [TestMethod]
        public void Constructor_WhenLoggerIsNull_ShouldThrowAnException()
        {
            Action act = () => new BlockChainController(_mockHub.Object, _mockTickerService.Object, null);
            act.Should().Throw<ArgumentNullException>().Which.ParamName.Should().Be("logger");
        }

        [TestMethod]
        public void Get_WhenInvoked_ShouldReturnOk()
        {
            var controller = new BlockChainController(_mockHub.Object, _mockTickerService.Object, _mockLogger.Object);
            var result = controller.Get();
            result.Should().BeOfType<OkObjectResult>();
        }
    }
}
