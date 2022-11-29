namespace Domain.Entities.BitFinex
{
    public class TbBitFinex
    {
        public int Id { get; set; }
        public decimal mid { get; set; }
        public decimal bid { get; set; }
        public decimal ask { get; set; }
        public decimal last_price { get; set; }
        public decimal low { get; set; }
        public decimal high { get; set; }
        public decimal volume { get; set; }
        public int timestamp { get; set; }
        public TbBitFinex(){}
    }
}
