using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using NotionAutomation.Api;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHttpClient();
builder.Configuration.AddUserSecrets<Program>();

builder.Services.Configure<NotionApiOptions>(builder.Configuration.GetSection("Notion"));
builder.Services.AddSingleton<INotionApiClient, NotionApiClient>();

IHost host = builder.Build();
INotionApiClient client = host.Services.GetRequiredService<INotionApiClient>();
await client.RetrieveBlockChildren(Guid.Parse("1a6e41ba-84a5-804b-b8ed-ed463ba8e06f"), CancellationToken.None);