using Core.App.ApiModels.BitFinex;
using Core.App.ApiModels.BitStamp;
using Core.App.Services;
using Core.Interfaces.Interfaces.IData;
using Domain.Configuration;
using Domain.Entities.BitFinex;
using Domain.Entities.BitStamp;
using Infastructure.Rest.BitFinex;
using Infastructure.Rest.BitStamp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Mime;

namespace btc.usd.core.Controllers.ApiControllers
{
    [ApiController]
    [Route("[controller]")]
    public class SourcesPricesController : ControllerBase
    {

        private readonly ILogger<SourcesPricesController> Logger;
        public IOptions<DomainConfig> Options { get; }
        public BitStampAdaptor<BitStampModel, TbBitStamp> BitStampMainService { get; }
        public BitFinexAdaptor<BitFinexModel, TbBitFinex> BitFinexAdaptor { get; }
        public BitStampRestService<BitStampModel> RestServiceBitStamp { get; }
        public BitFixexRestService<BitFinexModel> RestServiceBitFinex { get; }

        public SourcesPricesController(
            ILogger<SourcesPricesController> logger,
            IOptions<DomainConfig> options,
            BitStampAdaptor<BitStampModel, TbBitStamp> bitStampMainService,
            BitFinexAdaptor<BitFinexModel, TbBitFinex> bitFinexAdaptor,
            BitStampRestService<BitStampModel> restServiceBitStamp,
            BitFixexRestService<BitFinexModel> restServiceBitFinex)
        {
            Logger = logger;
            Options = options;
            BitStampMainService = bitStampMainService;
            BitFinexAdaptor = bitFinexAdaptor;
            RestServiceBitStamp = restServiceBitStamp;
            RestServiceBitFinex = restServiceBitFinex;
        }


        //API Endpoint providing all the available soures
        [HttpGet(nameof(AvailableSources))]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IEnumerable<string>> AvailableSources()
        {
            return await Task.FromResult(Options.Value.Sources.Select(x => x.Key));
        }


        //API Endpoint fetches bitcoin/usd price for specific source {Bitstamp} on demand
        [HttpGet(nameof(BitstampPrices))]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IEnumerable<BitStampModel>> BitstampPrices(CancellationToken cancellationToken)
        {
            var bitStampModels = await RestServiceBitStamp.GetObjectAsync(cancellationToken);
            await BitStampMainService.AddModel(bitStampModels);
            return bitStampModels;
        }


        //API Endpoint fetches bitcoin/usd price for specific source {BitFinex} on demand
        [HttpGet(nameof(BitFinexPrices))]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<BitFinexModel>> BitFinexPrices(CancellationToken cancellationToken)
        {
            var bitFinex = await RestServiceBitFinex.GetObjectAsync(cancellationToken);
            await BitFinexAdaptor.AddModel(bitFinex);
            return bitFinex;
        }


        //API Endpoint fetches bitcoin/usd price for specific source {BitFinex} on demand
        [HttpGet(nameof(BitcoinPricesHistory))]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<TbBitFinex> BitcoinPricesHistory(CancellationToken cancellationToken)
        {
            return default;
        }
    }
}
