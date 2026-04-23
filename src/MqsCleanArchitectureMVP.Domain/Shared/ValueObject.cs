namespace MqsCleanArchitectureMVP.Domain.Sharedd.ValueObject
{
    public class Money
    {
        public decimal Amount { get; private set; }
        public string Currency { get; private set; }

        public Money(decimal amount, string currency = "BRL")
        {
            if (amount < 0)
                throw new ArgumentException("Valor não pode ser negativo.");
            Amount = amount;
            Currency = currency;
        }

        public Money Add(Money other) => new Money(Amount + other.Amount, Currency);
        public Money Subtract(Money other) => new Money(Amount - other.Amount, Currency);
    }

    public class AccountNumber
    {
        public string Value { get; private set; }

        public AccountNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Número da conta inválido.");
            Value = value;
        }

        public override string ToString() => Value;
    }
}
