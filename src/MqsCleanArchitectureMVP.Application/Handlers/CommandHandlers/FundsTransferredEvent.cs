using MqsCleanArchitectureMVP.Domain.Entities;

namespace MqsCleanArchitectureMVP.Application.Handlers.CommandHandlers
{
    internal class FundsTransferredEvent
    {
        private Guid id1;
        private Guid id2;
        private Money amount;

        public FundsTransferredEvent(Guid id1, Guid id2, Money amount)
        {
            this.id1 = id1;
            this.id2 = id2;
            this.amount = amount;
        }
    }
}