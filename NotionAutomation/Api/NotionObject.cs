﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace NotionAutomation.Api;

public abstract class NotionObject
{
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalData { get; set; }
}