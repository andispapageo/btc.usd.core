namespace Core.App.DTO.BitStamp
{
    public class BitStampDTO
    {
        public long timestamp { get; set; }
        public string open { get; set; }
        public string close { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string last { get; set; }
        public string volume { get; set; }
        public string vwap { get; set; }
        public string bid { get; set; }
        public string ask { get; set; }
        public string open_24 { get; set; }
        public decimal percent_change_24 { get; set; }
    }
}
