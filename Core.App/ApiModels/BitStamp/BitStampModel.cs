using Core.Interfaces.Interfaces.IApi;

namespace Core.App.ApiModels.BitStamp
{
    public class BitStampModel : IRestEntity
    {
        public long timestamp { get; set; }
        public decimal open { get; set; }
        public decimal close { get; set; }
        public decimal high { get; set; }
        public decimal low { get; set; }
        public decimal last { get; set; }
        public decimal volume { get; set; }
        public decimal vwap { get; set; }
        public decimal bid { get; set; }
        public decimal ask { get; set; }
        public decimal open_24 { get; set; }
        public decimal percent_change_24 { get; set; }
        public DateTime AuditDate = DateTime.UtcNow;
    }
}
