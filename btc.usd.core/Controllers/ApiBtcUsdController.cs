using Microsoft.AspNetCore.Mvc;

namespace btc.usd.core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiBtcUsdController : ControllerBase
    {
     
        private readonly ILogger<ApiBtcUsdController> _logger;

        public ApiBtcUsdController(ILogger<ApiBtcUsdController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetApiControllers")]
        public IEnumerable<string> Get()
        {
            return new string[] { };
        }
    }
}