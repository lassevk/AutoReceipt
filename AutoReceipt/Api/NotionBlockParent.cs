using System.Text.Json.Serialization;

namespace AutoReceipt.Api;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(NotionBlockParentPage), "page_id")]
[JsonDerivedType(typeof(NotionBlockParentWorkspace), "workspace")]
[JsonDerivedType(typeof(NotionBlockParentBlock), "block_id")]
[JsonDerivedType(typeof(NotionBlockParentDatabase), "database_id")]
public abstract class NotionBlockParent : NotionBase
{
}