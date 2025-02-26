using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace AutoReceipt.Api;

public class NotionFileBlock : NotionBlock
{
    [JsonPropertyName("file")]
    public required JsonObject File { get; set; }
}