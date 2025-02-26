using System.Text.Json.Serialization;

namespace AutoReceipt.Api;

public class NotionEquation : NotionBase
{
    [JsonPropertyName("expression")]
    public required string Expression { get; set; }
}