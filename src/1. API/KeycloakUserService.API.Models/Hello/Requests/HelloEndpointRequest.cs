using FastEndpoints;

namespace KeycloakUserService.API.Models.Hello.Requests;

public record HelloEndpointRequest
{
    [QueryParam, BindFrom("name")]
    public required string Name { get; init; }
}