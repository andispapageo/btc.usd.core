using Core.Interfaces.Interfaces.IApi;

namespace Core.App.ApiModels.BitStamp
{
    public class BitStampModel : IRestEntity
    {
        public long timestamp { get; set; }
        public int open { get; set; }
        public int close { get; set; }
        public int high { get; set; }
        public int low { get; set; }
        public int last { get; set; }
        public decimal volume { get; set; }
        public int vwap { get; set; }
        public int bid { get; set; }
        public int ask { get; set; }
        public int open_24 { get; set; }
        public string percent_change_24 { get; set; }
        public DateTime AuditDate = DateTime.UtcNow;
    }
}
