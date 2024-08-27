using MassTransit;

using Consumer2.Consumers;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices((hostContext, services) =>
{
    services.AddMassTransit(c =>
    {
        c.AddConsumer<NotificationTransactionConsumer>();

        c.UsingRabbitMq((context, cfg) =>
        {
            cfg.Host("rabbitmq", "/", _ => { });
            // cfg.Host("rabbitmq://localhost", c =>
            // {
            //     c.Username("root");
            //     c.Password("123");
            // });

            cfg.ReceiveEndpoint("NotifyTransactionsQueue2", e => e.ConfigureConsumer<NotificationTransactionConsumer>(context));

            cfg.ConfigureEndpoints(context);
        });
    });
});

var app = builder.Build();

app.Run();