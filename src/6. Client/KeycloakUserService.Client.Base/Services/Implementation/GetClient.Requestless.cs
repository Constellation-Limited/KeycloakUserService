using System.Net.Http.Json;
using KeycloakUserService.Client.Base.Services.Abstractions;
using KeycloakUserService.Common.Extensions;

namespace KeycloakUserService.Client.Base.Services.Implementation;

public abstract class GetClient<TResponse> : ClientService<TResponse>
{
    protected GetClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory) { }

    public override async Task<TResponse?> ExecuteAsync(CancellationToken cancellationToken)
    {
        var uri = HttpClient.BaseAddress!.AddSegment(Route);

        var response = await HttpClient.GetAsync(uri, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken);
    }
}