namespace MqsCleanArchitectureMVP.Domain.Entities
{
    public class Money
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }

        public Money(decimal amount, string currency = "BRL")
        {
            Amount = amount;
            Currency = currency;
        }

        public Money(decimal amount) 
        {
            Amount = amount;
        }

        public Money Add(Money other) => new Money(Amount + other.Amount, Currency);
        public Money Subtract(Money other) => new Money(Amount - other.Amount, Currency);
    }
}
