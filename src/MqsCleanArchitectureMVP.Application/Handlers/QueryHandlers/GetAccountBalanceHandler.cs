using MqsCleanArchitectureMVP.Application.DTOs;
using MqsCleanArchitectureMVP.Application.Queries;
using MqsCleanArchitectureMVP.Domain.Interfaces;

namespace MqsCleanArchitectureMVP.Application.Handlers.QueryHandlers
{
    public class GetAccountBalanceHandler
    {
        private readonly IAccountRepository _repository;

        public GetAccountBalanceHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<AccountDto> Handle(GetAccountBalanceQuery query)
        {
            var account = await _repository.GetByIdAsync(query.AccountId);
            return new AccountDto
            {
                Id = account.Id,
                HolderName = account.HolderName,
                AccountNumber = account.AccountNumber,
                Balance = account.Balance.Amount
            };
        }
    }
}
