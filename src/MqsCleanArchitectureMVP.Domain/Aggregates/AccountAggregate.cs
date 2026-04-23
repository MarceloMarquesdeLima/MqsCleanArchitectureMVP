using MqsCleanArchitectureMVP.Domain.Entities;
using MqsCleanArchitectureMVP.Domain.Events;

namespace MqsCleanArchitectureMVP.Domain.Aggregates
{
    public class AccountAggregate
    {
        public Account Account { get; private set; }
        public List<Transaction> Transactions { get; private set; }

        public AccountAggregate(Account account)
        {
            Account = account;
            Transactions = new List<Transaction>();
        }

        public void Deposit(Money amount)
        {
            Account.Deposit(amount);
            Transactions.Add(new Transaction(Account.Id, amount, "Credit"));
        }

        public void Withdraw(Money amount)
        {
            Account.Withdraw(amount);
            Transactions.Add(new Transaction(Account.Id, amount, "Debit"));
        }

        public AccountCreatedEvent CreateAccountEvent()
        {
            return new AccountCreatedEvent(Account.Id, Account.HolderName, Account.CreatedAt);

        }
    }
}
