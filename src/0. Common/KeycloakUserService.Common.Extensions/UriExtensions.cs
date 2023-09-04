using System.Web;

namespace KeycloakUserService.Common.Extensions;

public static class UriExtensions
{
    public static Uri AddSegment(this Uri uri, string segment) => new(uri, segment);

    public static Uri AddQueryParams(this Uri uri, IEnumerable<KeyValuePair<string, string?>> queryParams)
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
}