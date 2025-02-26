using System.Text.Json.Serialization;

namespace AutoReceipt.Api;

public class NotionBlockParentBlock : NotionBlockParent
{
    [JsonPropertyName("block_id")]
    public required Guid BlockId { get; set; }
}