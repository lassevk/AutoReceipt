namespace NotionAutomation.Api;

public interface INotionApiClient
{
    Task RetrieveBlockChildren(Guid blockId, CancellationToken cancellationToken);
}