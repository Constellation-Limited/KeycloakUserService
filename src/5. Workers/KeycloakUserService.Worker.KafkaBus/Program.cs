using KeycloakUserService.Worker.KafkaBus;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => { services.AddHostedService<Worker>(); })
    .Build();

host.Run();