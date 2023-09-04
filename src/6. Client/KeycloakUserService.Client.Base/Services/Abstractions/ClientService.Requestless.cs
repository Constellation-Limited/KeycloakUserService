using KeycloakUserService.Client.Base.Services.Interfaces;

namespace KeycloakUserService.Client.Base.Services.Abstractions;

public abstract class ClientService<TResponse> : IClientService<TResponse>
{
    protected readonly HttpClient HttpClient;
    
    protected abstract string Route { get; }

    protected ClientService(IHttpClientFactory httpClientFactory)
    {
        HttpClient = httpClientFactory.CreateClient();
    }
    
    public abstract Task<TResponse?> ExecuteAsync(CancellationToken cancellationToken);
}