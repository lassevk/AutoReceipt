using System.Text.Json.Serialization;

namespace AutoReceipt.Api;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(NotionParagraphBlock), "paragraph")]
[JsonDerivedType(typeof(NotionFileBlock), "file")]
public abstract class NotionBlock : NotionObject
{
    [JsonPropertyName("object")]
    public required string Object { get; set; }

    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("parent")]
    public NotionBlockParent? Parent { get; set; }

    [JsonPropertyName("created_time")]
    public required DateTimeOffset CreatedTime { get; set; }

    [JsonPropertyName("last_edited_time")]
    public required DateTimeOffset LastEditTime { get; set; }
}