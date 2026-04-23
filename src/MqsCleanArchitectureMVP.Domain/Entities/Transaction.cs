namespace MqsCleanArchitectureMVP.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; private set; }
        public Guid AccountId { get; private set; }
        public Money Amount { get; private set; }
        public string Type { get; private set; }
        public DateTime Timestamp { get; private set; }

        public Transaction(Guid accountId, Money amount, string type)
        {
            Id = Guid.NewGuid();
            AccountId = accountId;
            Amount = amount;
            Type = type;
            Timestamp = DateTime.UtcNow;
        }
    }
}
