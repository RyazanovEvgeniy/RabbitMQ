using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(configurator =>
{
    configurator.SetKebabCaseEndpointNameFormatter();

    configurator.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", _ => { });
        // cfg.Host("rabbitmq://localhost", c =>
        // {
        //     c.Username("root");
        //     c.Password("123");
        // });
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();