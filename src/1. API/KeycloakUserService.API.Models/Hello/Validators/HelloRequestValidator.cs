using FastEndpoints;
using FluentValidation;
using KeycloakUserService.API.Models.Hello.Requests;

namespace KeycloakUserService.API.Models.Hello.Validators;

public class HelloRequestValidator : Validator<HelloEndpointRequest>
{
    public HelloRequestValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty()
            .WithMessage("Name is required!")
            .MinimumLength(2)
            .WithMessage("Name is too short!");
    }
}