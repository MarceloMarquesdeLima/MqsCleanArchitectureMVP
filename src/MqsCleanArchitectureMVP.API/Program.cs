using MqsCleanArchitectureMVP.Application.Handlers.CommandHandlers;
using MqsCleanArchitectureMVP.Application.Handlers.QueryHandlers;
using MqsCleanArchitectureMVP.Domain.Interfaces;
using MqsCleanArchitectureMVP.Infra.Messaging;
using MqsCleanArchitectureMVP.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IEventPublisher, KafkaProducer>();
builder.Services.AddScoped<CreateAccountHandler>();
builder.Services.AddScoped<TransferFundsHandler>();
builder.Services.AddScoped<GetAccountBalanceHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
