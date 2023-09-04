using KeycloakUserService.Common.Extensions;

namespace KeycloakUserService.Client.Base;

public abstract class ClientService<T> : IClientService
{
    private readonly HttpClient _client;
    protected abstract string Route { get; }

    protected ClientService(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient();
    }

    /*public virtual Task<T> Get()
    {
        _client.BaseAddress!.AddSegment(Route).AddQueryParams()
    }*/
}