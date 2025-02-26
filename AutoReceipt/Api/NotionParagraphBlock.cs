using System.Text.Json.Serialization;

namespace AutoReceipt.Api;

public class NotionParagraphBlock : NotionBlock
{
    [JsonPropertyName("paragraph")]
    public required NotionParagraph Paragraph { get; set; }
}