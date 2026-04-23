using MqsCleanArchitectureMVP.Application.Commands;
using MqsCleanArchitectureMVP.Domain.Aggregates;
using MqsCleanArchitectureMVP.Domain.Entities;
using MqsCleanArchitectureMVP.Domain.Interfaces;
using System.Security.Principal;

namespace MqsCleanArchitectureMVP.Application.Handlers.CommandHandlers
{
    public class CreateAccountHandler
    {
        private readonly IAccountRepository _repository;
        private readonly IEventPublisher _publisher;

        public CreateAccountHandler(IAccountRepository repository, IEventPublisher publisher)
        {
            _repository = repository;
            _publisher = publisher;
        }

        public async Task Handle(CreateAccountCommand command)
        {
            var account = new Account(command.AccountNumber, command.HolderName);
            var aggregate = new AccountAggregate(account);

            await _repository.AddAsync(account);
            await _publisher.PublishAsync(aggregate.CreateAccountEvent());
        }
    }
}
