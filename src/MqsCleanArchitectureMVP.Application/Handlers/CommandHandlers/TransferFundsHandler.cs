using MqsCleanArchitectureMVP.Application.Commands;
using MqsCleanArchitectureMVP.Domain.Entities;
using MqsCleanArchitectureMVP.Domain.Interfaces;

namespace MqsCleanArchitectureMVP.Application.Handlers.CommandHandlers
{
    public class TransferFundsHandler
    {
        private readonly IAccountRepository _repository;
        private readonly IEventPublisher _publisher;

        public TransferFundsHandler(IAccountRepository repository, IEventPublisher publisher)
        {
            _repository = repository;
            _publisher = publisher;
        }

        public async Task Handle(TransferFundsCommand command)
        {
            var fromAccount = await _repository.GetByIdAsync(command.FromAccountId);
            var toAccount = await _repository.GetByIdAsync(command.ToAccountId);

            var amount = new Money(command.Amount);
            fromAccount.Withdraw(amount);
            toAccount.Deposit(amount);

            await _repository.UpdateAsync(fromAccount);
            await _repository.UpdateAsync(toAccount);

            var eventTransfer = new FundsTransferredEvent(fromAccount.Id, toAccount.Id, amount);
            await _publisher.PublishAsync(eventTransfer);
        }
    }
}
