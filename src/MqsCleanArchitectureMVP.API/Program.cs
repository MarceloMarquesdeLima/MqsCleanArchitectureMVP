using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MqsCleanArchitectureMVP.Application.Handlers.CommandHandlers;
using MqsCleanArchitectureMVP.Application.Handlers.QueryHandlers;
using MqsCleanArchitectureMVP.Domain.Interfaces;
using MqsCleanArchitectureMVP.Infra.Messaging;
using MqsCleanArchitectureMVP.Infra.Persistence;
using MqsCleanArchitectureMVP.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// 🔗 SQL Server
builder.Services.AddDbContext<SqlServerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

// 🔗 MongoDB
builder.Services.AddSingleton<IMongoClient>(sp =>
    new MongoClient(builder.Configuration.GetConnectionString("MongoDb")));
builder.Services.AddScoped<MongoContext>();

// 🗂️ Repositórios
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
//builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

// 📡 Mensageria (Kafka)
builder.Services.AddScoped<IEventPublisher>(sp =>
    new KafkaProducer("kafka:9092", "account-events"));

// Handlers
builder.Services.AddScoped<CreateAccountHandler>();
builder.Services.AddScoped<TransferFundsHandler>();
builder.Services.AddScoped<GetAccountBalanceHandler>();

var app = builder.Build();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty; // Para abrir o Swagger na raiz (localhost:port/)
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
