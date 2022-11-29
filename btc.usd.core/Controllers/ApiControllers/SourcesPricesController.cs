using Core.App.ApiModels.BitFinex;
using Core.App.ApiModels.BitStamp;
using Core.App.Entities.BitFinex;
using Core.App.Entities.BitStamp;
using Core.Interfaces.Interfaces.IApi;
using Core.Interfaces.Interfaces.IData;
using Domain.Configuration;
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
        public IUnitOfWork<TbBitStamp> UnitOfWorkBitStamp { get; }
        public IUnitOfWork<TbBitFinex> UnitOfWorkBitFinex { get; }
        public BitStampRestService<BitStampModel> RestServiceBitStamp { get; }
        public BitFixexRestService<BitFinexModel> RestServiceBitFinex { get; }

        public SourcesPricesController(
            ILogger<SourcesPricesController> logger,
            IOptions<DomainConfig> options,
            IUnitOfWork<TbBitStamp> unitOfWorkBitStamp,
            IUnitOfWork<TbBitFinex> unitOfWorkBitFinex,
            BitStampRestService<BitStampModel> restServiceBitStamp,
            BitFixexRestService<BitFinexModel> restServiceBitFinex)
        {
            Logger = logger;
            Options = options;
            UnitOfWorkBitStamp = unitOfWorkBitStamp;
            UnitOfWorkBitFinex = unitOfWorkBitFinex;
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


        //API Endpoint fetches bitcoin price for specific source {Bitstamp} on demand
        [HttpGet(nameof(BitstampPrices))]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async  Task<IEnumerable<BitStampModel>> BitstampPrices(CancellationToken cancellationToken)
        {
            var bitStampModels = await RestServiceBitStamp.GetObjectAsync(cancellationToken);
            return bitStampModels;
        }


        //API Endpoint fetches bitcoin price for specific source {BitFinex} on demand
        [HttpGet(nameof(BitFinexPrices))]
        [ApiExplorerSettings(GroupName = "v1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<BitFinexModel>> BitFinexPrices(CancellationToken cancellationToken)
        {
            var bitStampModels = await RestServiceBitFinex.GetObjectAsync(cancellationToken);
            return bitStampModels;
        }


        //API Endpoint fetches bitcoin price for specific source {BitFinex} on demand
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
