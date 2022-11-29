namespace Infastructure.Rest.BitFinex
{
    public class BitFixexRestService<T> : BaseRestAPI<T> where T : class
    {
        public BitFixexRestService(string url) : base(url) { }
        public override bool FetchAllSymbols() => false;
        public override IEnumerable<string> Symbols() => new[] { "btcusd" };
    }
}
