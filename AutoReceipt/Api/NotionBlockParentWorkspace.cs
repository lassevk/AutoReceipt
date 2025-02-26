using System.Text.Json.Serialization;

namespace AutoReceipt.Api;

public class NotionBlockParentWorkspace : NotionBlockParent
{
    [JsonPropertyName("workspace")]
    public required bool Workspace { get; set; }
}