using SendMessage;
using SendMessage.Models.Interfaces;
using SendMessage.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<ISendMessage, SendMessageService>();
    })
    .Build();

host.Run();
