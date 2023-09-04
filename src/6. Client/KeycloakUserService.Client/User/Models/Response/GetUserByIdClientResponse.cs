namespace KeycloakUserService.Client.User.Models.Response;

public record GetUserByIdClientResponse
{
    public required string Id { get; set; }
}