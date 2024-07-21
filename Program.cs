using SendMessage;
using SendMessage.Interfaces;
using SendMessage.Repository;
using SendMessage.Services.SendMessage;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<ISendMessage, SendMessageService>();
        services.AddSingleton<IMessageRepository, MessageRepository>();
    })
    .Build();

host.Run();
