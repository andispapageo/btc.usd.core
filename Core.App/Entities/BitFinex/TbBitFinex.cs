namespace Core.App.Entities.BitFinex
{
    public class TbBitFinex
    {
        public string? mid { get; set; }
        public string? bid { get; set; }
        public string? ask { get; set; }
        public string? last_price { get; set; }
        public string? low { get; set; }
        public string? high { get; set; }
        public string? volume { get; set; }
        public string? timestamp { get; set; }
        public DateTime AuditDate = DateTime.UtcNow;
        public TbBitFinex(){}
    }
}
