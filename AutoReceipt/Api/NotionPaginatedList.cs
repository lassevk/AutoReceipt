using System.Text.Json.Serialization;

namespace AutoReceipt.Api;

[JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
public class NotionPaginatedList<T> : NotionBase
    where T : NotionBase
{
    [JsonPropertyName("object")]
    public required string Object { get; set; }

    [JsonPropertyName("results")]
    public List<T> Results { get; } = new();

    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }

    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }

    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("request_id")]
    public required string RequestId { get; set; }
}