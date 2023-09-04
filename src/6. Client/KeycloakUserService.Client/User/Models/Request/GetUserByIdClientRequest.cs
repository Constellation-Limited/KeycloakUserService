namespace KeycloakUserService.Client.User.Models.Request;

public record GetUserByIdClientRequest
{
    public required string Id { get; set; }
}