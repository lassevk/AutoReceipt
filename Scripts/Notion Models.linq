<Query Kind="Program">
  <Namespace>System.Text.Json.Serialization</Namespace>
  <Namespace>System.Text.Json</Namespace>
  <Namespace>System.Text.Json.Nodes</Namespace>
</Query>

void Main()
{
    
}

public abstract class NotionObject
{
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; set; }
}

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(NotionParagraphBlock), "paragraph")]
public abstract class NotionBlock : NotionObject
{
    [JsonPropertyName("object")]
    public required string Object { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("parent")]
    public NotionBlockParent? Parent { get; set; }

    [JsonPropertyName("created_time")]
    public required DateTimeOffset CreatedTime { get; set; }

    [JsonPropertyName("last_edited_time")]
    public required DateTimeOffset LastEditTime { get; set; }

    [JsonPropertyName("type")]
    public abstract string Type { get; }
}

public class NotionParagraphBlock : NotionBlock
{
    [JsonPropertyName("type")]
    public override string Type => "paragraph";

    [JsonPropertyName("paragraph")]
    public JsonObject? Paragraph { get; set; }
}

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(NotionBlockParentPage), "page_id")]
public abstract class NotionBlockParent : NotionObject
{
}

public class NotionBlockParentPage : NotionBlockParent
{
    [JsonPropertyName("page_id")]
    public required string PageId { get; set; }
}

[JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
public class NotionPaginatedList<T> : NotionObject
    where T : NotionObject
{
    [JsonPropertyName("object")]
    public required string Object { get; set; }

    [JsonPropertyName("results")]
    public List<T> Results { get; } = new();

    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }

    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }

    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("request_id")]
    public required string RequestId { get; set; }
}