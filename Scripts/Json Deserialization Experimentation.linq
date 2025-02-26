<Query Kind="Program">
  <Namespace>System.Text.Json.Serialization</Namespace>
  <Namespace>System.Text.Json</Namespace>
  <Namespace>System.Text.Json.Nodes</Namespace>
</Query>

#load ".\Notion Models"

void Main()
{
    //string json = File.ReadAllText(@"D:\Temp\response.json", Encoding.UTF8);
    //JsonSerializer.Deserialize<NotionPaginatedList<NotionBlock>>(json).Dump();

    string json = """
        {
          "object": "block",
          "type": "paragraph",
          "id": "1a6e41ba-84a5-805a-9d8f-ec858f4cca21",
          "parent": {
            "type": "page_id",
            "page_id": "1a6e41ba-84a5-804b-b8ed-ed463ba8e06f"
          },
          "created_time": "2025-02-26T21:59:00.000Z",
          "last_edited_time": "2025-02-26T21:59:00.000Z",
          "created_by": {
            "object": "user",
            "id": "f8fb0747-852c-4d25-a6d6-8bef46927ca5"
          },
          "last_edited_by": {
            "object": "user",
            "id": "f8fb0747-852c-4d25-a6d6-8bef46927ca5"
          },
          "has_children": false,
          "archived": false,
          "in_trash": false
        }
        """;
    JsonSerializer.Deserialize<NotionBlock>(json, new JsonSerializerOptions
    {
        AllowOutOfOrderMetadataProperties = true,
    }).Dump();
}