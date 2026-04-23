namespace MqsCleanArchitectureMVP.Domain.Events
{
    public class AccountCreatedEvent
    {
        public Guid AccountId { get; private set; }
        public string HolderName { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public AccountCreatedEvent(Guid accountId, string holderName, DateTime createdAt)
        {
            AccountId = accountId;
            HolderName = holderName;
            CreatedAt = createdAt;
        }
    }
}
