<Query Kind="Program">
  <Namespace>System.Text.Json</Namespace>
</Query>

#load ".\Notion Models"

void Main()
{
    var block1 = new NotionParagraphBlock
    {
        Object = "object",
        CreatedTime = DateTimeOffset.Now,
        Id = "1234",
        LastEditTime = DateTimeOffset.Now,
        Parent = null,
    };

    JsonSerializer.Serialize(block1, new JsonSerializerOptions { WriteIndented = true }).Dump();
}

