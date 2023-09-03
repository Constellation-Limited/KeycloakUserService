using System.Text.Json.Serialization;

namespace KeycloakUserService.API.Models.Hello.Responses;

public record HelloEndpointResponse
{
    [JsonPropertyName("message")]
    public required string Message { get; init; }
}