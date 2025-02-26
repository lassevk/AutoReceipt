using System.Text.Json.Serialization;

namespace AutoReceipt.Api;

public class NotionRichTextEquation : NotionRichText
{
    [JsonPropertyName("equation")]
    public required NotionEquation Equation { get; set; }
}