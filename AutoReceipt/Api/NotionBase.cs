using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoReceipt.Api;

public abstract class NotionBase
{
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; set; }
}