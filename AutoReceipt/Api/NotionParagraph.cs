using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace AutoReceipt.Api;

[JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
public class NotionParagraph : NotionBase
{
    [JsonPropertyName("rich_text")]
    public List<NotionRichText> RichText { get; } = new();

    [JsonPropertyName("color")]
    public required NotionColor Color { get; set; }
}