using System.Net.Http.Json;
using KeycloakUserService.Client.Base.Services.Abstractions;
using KeycloakUserService.Common.Extensions;

namespace KeycloakUserService.Client.Base.Services.Implementation;

public abstract class GetClientService<TRequest, TResponse> : ClientService<TRequest, TResponse>
{
    protected GetClientService(IHttpClientFactory httpClientFactory) : base(httpClientFactory) { }

    public override async Task<TResponse?> ExecuteAsync(TRequest request, CancellationToken cancellationToken)
    {
        var uri = HttpClient.BaseAddress!
            .AddSegment(Route)
            .AddRouteParams(MatchRouteParams(request))
            .AddQueryParams(MatchQueryParams(request));

        var response = await HttpClient.GetAsync(uri, cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken);
    }
}