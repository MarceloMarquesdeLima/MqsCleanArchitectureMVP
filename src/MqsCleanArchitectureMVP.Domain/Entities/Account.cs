namespace MqsCleanArchitectureMVP.Domain.Entities
{
    public class Account
    {
        public Guid Id { get; private set; }
        public string AccountNumber { get; private set; }
        public string HolderName { get; private set; }
        public Money Balance { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Account(string accountNumber, string holderName)
        {
            Id = Guid.NewGuid();
            AccountNumber = accountNumber;
            HolderName = holderName;
            Balance = new Money(0);
            CreatedAt = DateTime.UtcNow;
        }

        public void Deposit(Money amount)
        {
            Balance = Balance.Add(amount);
        }

        public void Withdraw(Money amount)
        {
            if (Balance.Amount < amount.Amount)
                throw new InvalidOperationException("Saldo insuficiente.");
            Balance = Balance.Subtract(amount);
        }
    }
}
