using FastEndpoints;
using KeycloakUserService.API.Models.Hello.Requests;
using KeycloakUserService.API.Models.Hello.Responses;
using KeycloakUserService.API.Models.Hello.Validators;

namespace KeycloakUserService.API.Endpoints.Hello;

public class HelloEndpoint : Endpoint<HelloEndpointRequest, HelloEndpointResponse>
{
    public override void Configure()
    {
        Version(1);
        Get("/hello");
        AllowAnonymous();
        Validator<HelloRequestValidator>();
    }

    public override Task<HelloEndpointResponse> ExecuteAsync(HelloEndpointRequest req, CancellationToken ct)
    {
        var response = new HelloEndpointResponse
        {
            Message = $"Hello, {req.Name}!"
        };

        return Task.FromResult(response);
    }
}