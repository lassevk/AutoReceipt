using System.Text.Json.Serialization;

namespace AutoReceipt.Api;

public class NotionBlockParentDatabase : NotionBlockParent
{
    [JsonPropertyName("database_id")]
    public required Guid DatabaseId { get; set; }
}