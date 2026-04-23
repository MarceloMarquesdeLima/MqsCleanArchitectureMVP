using MqsCleanArchitectureMVP.Domain.Entities;

namespace MqsCleanArchitectureMVP.Tests.UnitTests
{
    public class MoneyTests
    {
        [Fact]
        public void Add_ReturnsCorrectSum()
        {
            var m1 = new Money(100);
            var m2 = new Money(50);

            var result = m1.Add(m2);

            Assert.Equal(150, result.Amount);
        }

        [Fact]
        public void Subtract_ReturnsCorrectDifference()
        {
            var m1 = new Money(100);
            var m2 = new Money(40);

            var result = m1.Subtract(m2);

            Assert.Equal(60, result.Amount);
        }
    }
}
