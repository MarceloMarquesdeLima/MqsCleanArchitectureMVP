using MqsCleanArchitectureMVP.Domain.Entities;
using System.Security.Principal;

namespace MqsCleanArchitectureMVP.Tests.UnitTests
{
    public class AccountTests
    {
        [Fact]
        public void Deposit_IncreasesBalance()
        {
            var account = new Account("0001-01", "Marcelo");
            account.Deposit(new Money(100));

            Assert.Equal(100, account.Balance.Amount);
        }

        [Fact]
        public void Withdraw_DecreasesBalance()
        {
            var account = new Account("0001-01", "Marcelo");
            account.Deposit(new Money(200));
            account.Withdraw(new Money(50));

            Assert.Equal(150, account.Balance.Amount);
        }

        [Fact]
        public void Withdraw_ThrowsException_WhenInsufficientFunds()
        {
            var account = new Account("0001-01", "Marcelo");
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(new Money(100)));
        }
    }
}
