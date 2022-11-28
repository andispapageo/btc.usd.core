using Core.App.Entities.BitFinex;
using Core.App.Entities.BitStamp;
using Core.Interfaces.Interfaces.IApi;
using Core.Interfaces.Interfaces.IData;
using Domain.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace btc.usd.core.Controllers.ApiControllers
{
    [ApiController]
    [Route("[controller]")]
    public class SourcesPricesController : ControllerBase
    {

        private readonly ILogger<SourcesPricesController> Logger;
        public IOptions<GLobalConfig> Options { get; }
        public IUnitOfWork<BitStampModel> UnitOfWorkBitStamp { get; }
        public IUnitOfWork<BitFinexModel> UnitOfWorkBitFinex { get; }

        public SourcesPricesController(ILogger<SourcesPricesController> logger, 
            IOptions<GLobalConfig> options,
            IUnitOfWork<BitStampModel> unitOfWorkBitStamp,
            IUnitOfWork<BitFinexModel> unitOfWorkBitFinex)
            //IRestService<BitStampModel> restServiceBitStamp,
            //IRestService<BitFinexModel> restServiceBitFinex)
        {
            Logger = logger;
            Options = options;
            UnitOfWorkBitStamp = unitOfWorkBitStamp;
            UnitOfWorkBitFinex = unitOfWorkBitFinex;
        }


        //API Endpoint providing all the available soures
        [HttpGet(nameof(GetAvailableSources))]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<string>> GetAvailableSources()
        {
            return await Task.FromResult(Options.Value.Sources.Select(x => x.Key));
        }


        //API Endpoint fetches bitcoin price for specific source {Bitstamp} on demand
        [HttpGet(nameof(GetBitstampPrices))]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<BitStampModel> GetBitstampPrices()
        {
            return default;
        }


        //API Endpoint fetches bitcoin price for specific source {BitFinex} on demand
        [HttpGet("GetBitFinexPrices")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<BitFinexModel> GetBitFinexPrices()
        {
            return default;
        }


        //API Endpoint fetches bitcoin price for specific source {BitFinex} on demand
        [HttpGet("GetBitcoinPricesHistory")]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<BitFinexModel> GetBitcoinPricesHistory()
        {
            return default;
        }
    }
}
