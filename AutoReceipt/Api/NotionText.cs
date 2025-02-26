using System.Text.Json.Serialization;

namespace AutoReceipt.Api;

public class NotionText : NotionBase
{
    [JsonPropertyName("content")]
    public required string Content { get; set; }

    [JsonPropertyName("link")]
    public NotionTextLink? Link { get; set; }
}