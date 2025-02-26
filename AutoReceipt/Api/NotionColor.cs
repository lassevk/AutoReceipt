using System.Text.Json.Serialization;

namespace AutoReceipt.Api;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum NotionColor
{
    [JsonStringEnumMemberName("default")]
    Default,

    [JsonStringEnumMemberName("blue")]
    Blue,

    [JsonStringEnumMemberName("blue_background")]
    BlueBackground,
    
    [JsonStringEnumMemberName("brown")]
    Brown,
    
    [JsonStringEnumMemberName("brown_background")]
    BrownBackground,
    
    [JsonStringEnumMemberName("gray")]
    Gray,
    
    [JsonStringEnumMemberName("gray_background")]
    GrayBackground,
    
    [JsonStringEnumMemberName("green")]
    Green,
    
    [JsonStringEnumMemberName("green_background")]
    GreenBackground,
    
    [JsonStringEnumMemberName("orange")]
    Orange,
    
    [JsonStringEnumMemberName("orange_background")]
    OrangeBackground,
    
    [JsonStringEnumMemberName("pink")]
    Pink,
    
    [JsonStringEnumMemberName("pink_background")]
    PinkBackground,
    
    [JsonStringEnumMemberName("purple")]
    Purple,
    
    [JsonStringEnumMemberName("purple_background")]
    PurpleBackground,
    
    [JsonStringEnumMemberName("red")]
    Red,
    
    [JsonStringEnumMemberName("red_background")]
    RedBackground,
    
    [JsonStringEnumMemberName("yellow")]
    Yellow,
    
    [JsonStringEnumMemberName("yellow_background")]
    YellowBackground,
}