namespace Core.App.Entities.BitFinex
{
    public class TbBitFinex
    {
        public int Id { get; set; }
        public int mid { get; set; }
        public int? bid { get; set; }
        public int? ask { get; set; }
        public int? last_price { get; set; }
        public int? low { get; set; }
        public int? high { get; set; }
        public int? volume { get; set; }
        public int? timestamp { get; set; }
        public TbBitFinex(){}
    }
}
