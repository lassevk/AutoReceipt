using System.Text.Json.Serialization;

namespace AutoReceipt.Api;

public class NotionBlockParentPage : NotionBlockParent
{
    [JsonPropertyName("page_id")]
    public required string PageId { get; set; }
}