using System.Web;

namespace KeycloakUserService.Common.Extensions;

public static class UriExtensions
{
    /// <summary>
    /// Add route segment to existing route
    /// </summary>
    /// <param name="uri">Uri to modify</param>
    /// <param name="segment">Segment to add</param>
    /// <returns>Modified URI</returns>
    public static Uri AddSegment(this Uri uri, string segment) => new(uri, segment);

    /// <summary>
    /// Add query parameters to the route
    /// </summary>
    /// <param name="uri">Uri to modify</param>
    /// <param name="queryParams">Parameters to add</param>
    /// <returns>Modified URI</returns>
    public static Uri AddQueryParams(this Uri uri, IEnumerable<(string, string?)> queryParams)
    {
        var queryKeyValues = queryParams.ToList();
        
        if (!queryKeyValues.Any())
            return uri;
        
        var uriBuilder = new UriBuilder(uri);
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        
        foreach (var (key, value) in queryKeyValues)
            query[key] = value;
        
        uriBuilder.Query = query.ToString();

        return uriBuilder.Uri;
    }

    /// <summary>
    /// Add route parameters to the route
    /// </summary>
    /// <param name="uri">Uri to modify</param>
    /// <param name="routeParams">Parameters to add</param>
    /// <returns>Modified URI</returns>
    public static Uri AddRouteParams(this Uri uri, IEnumerable<(string, string?)> routeParams)
    {
        var routeKeyValues = routeParams.ToList();
        
        if (!routeKeyValues.Any())
            return uri;

        var url = uri.ToString();

        foreach (var (key, value) in routeKeyValues)
            url = url.Replace("{" + key + "}", value);
        
        return new Uri(url);
    }
}