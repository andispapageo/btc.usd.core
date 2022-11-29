using Core.App.ApiModels.BitFinex;
using Core.App.ApiModels.BitStamp;
using Infastructure.Rest.BitFinex;
using Infastructure.Rest.BitStamp;
using Xunit;

namespace FunctionalTests
{
    public class APITests
    {
        [Fact]
        public async Task ReturnsBitStampRest(CancellationToken cancellationToken)
        {
            var response = await new BitStampRestService<BitStampModel>("https://www.bitstamp.net/api/v2/ticker/btcusd/").GetObjectAsync(cancellationToken);
            Assert.NotNull(response);
            Assert.True(response?.Any());
        }

        [Fact]
        public async Task ReturnsBitFinexRest(CancellationToken cancellationToken)
        {
            var response = await new BitFixexRestService<BitFinexModel>("https://api.bitfinex.com/v1/pubticker/btcusd/").GetObjectAsync(cancellationToken);
            Assert.NotNull(response);
            Assert.True(response?.Any());
        }
    }
}
