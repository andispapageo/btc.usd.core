namespace btc.usd.core.Models
{
    public class ErrorViewModel
    {
            public string? RequestId { get; set; }

            public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
