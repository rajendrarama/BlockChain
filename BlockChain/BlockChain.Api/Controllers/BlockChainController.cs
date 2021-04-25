using BlockChain.Api.Models;
using BlockChain.Api.Services;
using BlockChain.Api.SignalRHub;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BlockChain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockChainController : ControllerBase
    {
        private IHubContext<BlockChainHub> _hub;

        private readonly ITickerService _tickerService;

        private readonly ILogger<BlockChainController> _logger;

        public BlockChainController(IHubContext<BlockChainHub> hub, ITickerService tickerService, ILogger<BlockChainController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _hub = hub ?? throw new ArgumentNullException(nameof(hub));
            _tickerService = tickerService ?? throw new ArgumentNullException(nameof(tickerService));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Dictionary<string, Currency>))]
        public IActionResult Get()
        {
            _logger.LogInformation("Get Ticker Results and communicate to Client through SignalR");

            var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("tickerdata", _tickerService.GetTickerData()));

            return Ok(new { Message = "Request Completed" });
        }
    }
}