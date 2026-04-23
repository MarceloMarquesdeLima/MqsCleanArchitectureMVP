using Microsoft.EntityFrameworkCore;
using MqsCleanArchitectureMVP.Application.Handlers.QueryHandlers;
using MqsCleanArchitectureMVP.Application.Queries;
using MqsCleanArchitectureMVP.Infra.Persistence;
using MqsCleanArchitectureMVP.Infra.Repositories;
using MqsCleanArchitectureMVP.Domain.Shared.ValueObject;

namespace MqsCleanArchitectureMVP.Tests.IntegrationTests
{
    public class BalanceIntegrationTests
    {
        private readonly SqlServerContext _context;
        private readonly AccountRepository _repository;

        /*public BalanceIntegrationTests()
        {
            var options = new DbContextOptionsBuilder<SqlServerContext>()
                .UseInMemoryDatabase("BankingBalanceTestDB")
                .Options;

            _context = new SqlServerContext(options);
            _repository = new AccountRepository(_context);
        }

        [Fact]
        public async Task GetAccountBalanceHandler_ReturnsCorrectBalance()
        {
            var account = new Domain.Entities.Account("0001-01", "Marcelo");
            account.Deposit(new Domain.Shared.ValueObject.Money(500));
            await _repository.AddAsync(account);

            var handler = new GetAccountBalanceHandler(_repository);
            var query = new GetAccountBalanceQuery { AccountId = account.Id };

            var result = await handler.Handle(query);

            Assert.Equal(500, result.Balance);
        }*/
    }
}
