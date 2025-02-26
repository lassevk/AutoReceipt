using System.Text.Json.Serialization;

namespace AutoReceipt.Api;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "object")]
[JsonDerivedType(typeof(NotionObject), "block")]
public abstract class NotionObject : NotionBase
{
}