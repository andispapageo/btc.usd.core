using Core.App.Entities.BitFinex;
using Core.App.Entities.BitStamp;
using Core.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace btc.usd.core.Controllers.ApiControllers
{
    [ApiController]
    [Route("[controller]")]
    public class PricesController : ControllerBase
    {

        private readonly ILogger<PricesController> _logger;

        public IUnitOfWork<BitStampModel> UnitOfWorkBitStamp { get; }
        public IUnitOfWork<BitFinexModel> UnitOfWorkBitFinex { get; }

        public PricesController(ILogger<PricesController> logger, 
            IUnitOfWork<BitStampModel> unitOfWorkBitStamp,
            IUnitOfWork<BitFinexModel> unitOfWorkBitFinex)
        {
            _logger = logger;
            UnitOfWorkBitStamp = unitOfWorkBitStamp;
            UnitOfWorkBitFinex = unitOfWorkBitFinex;
        }

        //API Endpoint providing all the available soures
        [HttpGet(Name = "AllAvailableSources")]
        public IEnumerable<string> GetAllAvailableSources()
        {
            return new string[] { };
        }

        //API Endpoint fetches bitcoin price for specific source {Bitstamp} on demand
        [HttpGet(Name = "BitstampPrices")]
        public IEnumerable<string> GetBitstampPrices()
        {
            return new string[] { };
        }

        //API Endpoint fetches bitcoin price for specific source {BitFinex} on demand
        [HttpGet(Name = "BitcoinPricesHistory")]
        public IEnumerable<string> GetBitcoinPricesHistory()
        {
            return new string[] { };
        }
    }
}
