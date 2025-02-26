using System.Text.Json.Serialization;

namespace AutoReceipt.Api;

public class NotionRichTextText : NotionRichText
{
    [JsonPropertyName("text")]
    public required NotionText Text { get; set; }
}