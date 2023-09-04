using System.Reflection;
using System.Text.RegularExpressions;
using KeycloakUserService.Client.Base.Services.Interfaces;

namespace KeycloakUserService.Client.Base.Services.Abstractions;

public abstract class ClientService<TRequest, TResponse> : IClientService<TRequest, TResponse>
{
    private static readonly Regex RouteRegex = new(@"(?<=\{).+?(?=\})");
    private PropertyInfo[]? _requestProperties;
    
    protected readonly HttpClient HttpClient;
    
    protected abstract string Route { get; }

    protected ClientService(IHttpClientFactory httpClientFactory)
    {
        HttpClient = httpClientFactory.CreateClient();
    }

    protected IEnumerable<(string Key, string? Value)> MatchRouteParams(TRequest request)
    {
        _requestProperties ??= typeof(TRequest).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var routeParams = RouteRegex.Matches(Route).Select(s => s.Value);

        var routeProperties = _requestProperties
            .Where(w => routeParams.Any(a => a.Equals(w.Name, StringComparison.InvariantCultureIgnoreCase)));

        return routeProperties.Select(s => (s.Name, s.GetValue(request)?.ToString()));
    }

    protected IEnumerable<(string Key, string? Value)> MatchQueryParams(TRequest request)
    {
        var routeParams = MatchRouteParams(request);
        var queryProperties = _requestProperties!
            .Where(w => !routeParams.Any(a => a.Key.Equals(w.Name, StringComparison.InvariantCultureIgnoreCase)));

        return queryProperties.Select(s => (s.Name, s.GetValue(request)?.ToString()));
    }

    public abstract Task<TResponse?> ExecuteAsync(TRequest request, CancellationToken cancellationToken);
}