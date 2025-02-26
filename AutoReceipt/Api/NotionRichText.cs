using System.Text.Json.Serialization;

namespace AutoReceipt.Api;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(NotionRichTextText), "text")]
[JsonDerivedType(typeof(NotionRichTextMention), "mention")]
[JsonDerivedType(typeof(NotionRichTextEquation), "equation")]
public abstract class NotionRichText : NotionBase
{
    [JsonPropertyName("annotations")]
    public NotionAnnotation? Annotations { get; set; }

    [JsonPropertyName("plain_text")]
    public required string PlainText { get; set; }

    [JsonPropertyName("href")]
    public string? Href { get; set; }
}