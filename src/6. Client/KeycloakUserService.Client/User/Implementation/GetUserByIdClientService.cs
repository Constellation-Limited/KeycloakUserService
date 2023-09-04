using KeycloakUserService.Client.Base.Services.Implementation;
using KeycloakUserService.Client.User.Interfaces;
using KeycloakUserService.Client.User.Models.Request;
using KeycloakUserService.Client.User.Models.Response;
using KeycloakUserService.Common.Contracts.Api;

namespace KeycloakUserService.Client.User.Implementation;

public class GetUserByIdClientService : GetClientService<GetUserByIdClientRequest, GetUserByIdClientResponse>, IGetUserByIdClientService
{
    protected override string Route => Routes.GetUserByIdRoute;

    public GetUserByIdClientService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
    {
    }
}