namespace Infastructure.Rest.BitStamp
{
    public class BitStampRestService<T> : BaseRestAPI<T> where T : class
    {
        public BitStampRestService(string url) : base(url) { }
        public override bool FetchAllSymbols() => false;
        public override IEnumerable<string> Symbols() => new[] { "btcusd" };

    }
}
