using System.Text.Json.Serialization;

namespace AutoReceipt.Api;

public class NotionTextLink : NotionBase
{
    [JsonPropertyName("url")]
    public required string Url { get; set; }
}