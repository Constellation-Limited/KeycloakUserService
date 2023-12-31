using FastEndpoints;
using FastEndpoints.Swagger;

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

var app = builder.Build();

app.UseAuthorization();
app.UseFastEndpoints(c =>
{
    c.Versioning.DefaultVersion = 1;
    c.Versioning.Prefix = "v";
    c.Versioning.PrependToRoute = true;
});
app.UseSwaggerGen();
app.Run();
