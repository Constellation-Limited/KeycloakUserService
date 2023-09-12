using FastEndpoints;
using FastEndpoints.Swagger;
using KeycloakUserService.API.Middlewares;
using KeycloakUserService.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();

if (builder.Environment.IsDevelopment())
{
    builder.Services.SwaggerDocument(o =>
    {
        o.MaxEndpointVersion = 1;
        o.DocumentSettings = s =>
        {
            s.DocumentName = "v1";
            s.Title = "A proxy service for retrieving users from Keycloak service.";
            s.Version = "v1";
        };
    });
}

builder.Services.AddDataAccess(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseAuthorization();
app.UseFastEndpoints(c =>
{
    c.Versioning.DefaultVersion = 1;
    c.Versioning.Prefix = "v";
    c.Versioning.PrependToRoute = true;
});
app.UseSwaggerGen();
app.Run();
