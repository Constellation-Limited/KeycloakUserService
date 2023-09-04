using KeycloakUserService.Client.Base.Services.Interfaces;
using KeycloakUserService.Client.User.Models.Request;
using KeycloakUserService.Client.User.Models.Response;

namespace KeycloakUserService.Client.User.Interfaces;

public interface IGetUserByIdClientService : IClientService<GetUserByIdClientRequest, GetUserByIdClientResponse>
{
}