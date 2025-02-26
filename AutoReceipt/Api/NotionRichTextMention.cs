using System.Text.Json.Serialization;

namespace AutoReceipt.Api;

public class NotionRichTextMention : NotionRichText
{
    [JsonPropertyName("mention")]
    public required NotionMention Mention { get; set; }
}