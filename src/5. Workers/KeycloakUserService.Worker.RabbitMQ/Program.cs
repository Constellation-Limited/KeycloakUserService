using KeycloakUserService.Worker.RabbitMQ;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => { services.AddHostedService<Worker>(); })
    .Build();

host.Run();