using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

using Microsoft.Extensions.Options;

namespace AutoReceipt.Api;

public class NotionApiClient : INotionApiClient
{
    private readonly TimeSpan _rateLimitWindow = TimeSpan.FromSeconds(1);
    private const int _rateLimitMaxRequests = 3;

    private readonly HttpClient _client;
    private readonly Queue<DateTimeOffset> _rateLimitQueue = new();

    public NotionApiClient(HttpClient client, IOptions<NotionApiOptions> options)
    {
        _client = client;
        _client.DefaultRequestHeaders.Authorization = new("Bearer", options.Value.Secret);
        _client.DefaultRequestHeaders.Accept.Add(new("application/json"));
        _client.DefaultRequestHeaders.Add("Notion-Version", "2022-06-28");
        _client.BaseAddress = new Uri("https://api.notion.com/v1/");
    }

    private async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        await RateLimiterAsync(cancellationToken);

        while (true)
        {
            HttpResponseMessage response = await _client.SendAsync(request, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return response;
            }

            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                await Task.Delay(300, cancellationToken);
                await RateLimiterAsync(cancellationToken);
                continue;
            }

            response.EnsureSuccessStatusCode();
        }
    }

    private async Task<List<T>> GetListAsync<T>(string path, CancellationToken cancellationToken)
        where T : NotionObject
    {
        var request = new HttpRequestMessage(HttpMethod.Get, path);
        HttpResponseMessage response = await SendAsync(request, cancellationToken);
        string json = await response.Content.ReadAsStringAsync(cancellationToken);

        await File.WriteAllTextAsync(@"D:\Temp\response.json", JsonSerializer.Serialize(JsonSerializer.Deserialize<JsonElement>(json), new JsonSerializerOptions
        {
            WriteIndented = true
        }), Encoding.UTF8, cancellationToken);
        NotionPaginatedList<T>? results = JsonSerializer.Deserialize<NotionPaginatedList<T>>(json);
        if (results == null)
        {
            return [];
        }

        if (results.HasMore)
        {
            throw new NotSupportedException("Notion API does not support pagination yet.");
        }

        return results.Results;
    }

    public async Task RetrieveBlockChildren(Guid blockId, CancellationToken cancellationToken)
    {
        List<NotionBlock> blocks = await GetListAsync<NotionBlock>($"blocks/{blockId}/children", cancellationToken);
        string json = JsonSerializer.Serialize(blocks, new JsonSerializerOptions
        {
            WriteIndented = true,
        });

        Console.WriteLine(json);
    }

    private async Task RateLimiterAsync(CancellationToken cancellationToken)
    {
        while (_rateLimitQueue.Count >= _rateLimitMaxRequests && _rateLimitQueue.Peek() >= DateTimeOffset.UtcNow.Subtract(_rateLimitWindow))
        {
            await Task.Delay(300, cancellationToken);
        }

        while (_rateLimitQueue.Count > 0 && _rateLimitQueue.Peek() <= DateTimeOffset.UtcNow.Subtract(_rateLimitWindow))
        {
            _rateLimitQueue.Dequeue();
        }

        _rateLimitQueue.Enqueue(DateTimeOffset.UtcNow);
    }
}

public class NotionApiOptions
{
    public required string Secret { get; set; }
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
}

public class NotionParagraphBlock : NotionBlock
{
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