using Core.Interfaces.Interfaces.IApi;

namespace Core.App.ApiModels.BitFinex
{
    public class BitFinexModel : IRestEntity
    {
        public decimal? mid { get; set; }
        public decimal? bid { get; set; }
        public decimal? ask { get; set; }
        public decimal? last_price { get; set; }
        public decimal? low { get; set; }
        public decimal? high { get; set; }
        public decimal? volume { get; set; }
        public long? timestamp { get; set; }
    }
}
