using Domain.Enums;

namespace Core.App.DTO
{
    public class HistoryPrices
    {
        public string? TimeStamp { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string bid { get; set; }
        public string ask { get; set; }
        public string? SourcesName { get; set; }
    }
}
