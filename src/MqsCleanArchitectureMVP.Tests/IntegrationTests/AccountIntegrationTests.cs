using Microsoft.EntityFrameworkCore;
using MqsCleanArchitectureMVP.Application.Commands;
using MqsCleanArchitectureMVP.Application.Handlers.CommandHandlers;
using MqsCleanArchitectureMVP.Domain.Interfaces;
using MqsCleanArchitectureMVP.Infra.Messaging;
using MqsCleanArchitectureMVP.Infra.Persistence;
using MqsCleanArchitectureMVP.Infra.Repositories;

namespace MqsCleanArchitectureMVP.Tests.IntegrationTests
{
    public class AccountIntegrationTests
    {
        private readonly SqlServerContext _context;
        private readonly AccountRepository _repository;
        private readonly KafkaProducer _publisher;

        public AccountIntegrationTests()
        {
            /*var options = new DbContextOptionsBuilder<SqlServerContext>()
                .UseInMemoryDatabase("BankingTestDB")
                .Options;

            _context = new SqlServerContext(options);
            _repository = new AccountRepository(_context);
            _publisher = new KafkaProducer("localhost:9092", "account-events");*/
        }

        [Fact]
        public async Task CreateAccountHandler_CreatesAccountAndPublishesEvent()
        {
            var handler = new CreateAccountHandler(_repository, _publisher);
            var command = new CreateAccountCommand
            {
                HolderName = "Marcelo",
                AccountNumber = "0001-01"
            };

            await handler.Handle(command);

            var account = await _repository.GetByIdAsync(_context.Accounts.First().Id);
            Assert.Equal("Marcelo", account.HolderName);
        }
    }
}
