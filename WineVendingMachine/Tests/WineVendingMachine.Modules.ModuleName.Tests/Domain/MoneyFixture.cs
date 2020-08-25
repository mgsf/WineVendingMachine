using WineVendingMachine.Modules.SellWine.Domain;
using FluentAssertions;
using Xunit;


namespace WineVendingMachine.Modules.SellWine.Tests.Domain
{
    public class MoneyFixture
    {
        [Fact]
        public void Sum_of_two_moneys()
        {
            //Arrange
            Money money1 = new Money(1, 2, 3, 4, 5, 6);
            Money money2 = new Money(1, 2, 3, 4, 5, 6);

            //Act
            Money sum = money1 + money2;

            //Assert
            sum.TenRupeeCount.Should().Be(2);
            sum.TwentyRupeeCount.Should().Be(4);
            sum.FiftyRupeeCount.Should().Be(6);
            sum.HundredRupeeCount.Should().Be(8);
            sum.FiveHundredRupeeCount.Should().Be(10);
            sum.ThousandRupeeCount.Should().Be(12);

        }


        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0, 0)]
        [InlineData(1, 0, 2, 0, 0, 0, 110)]
        [InlineData(1, 2, 0, 0, 2, 0, 1050)]
        [InlineData(1, 2, 3, 3, 2, 1, 2500)]
        public void Amount_calculated_correctly(
            int tenRupeeCount,
            int twentyRupeeCount,
            int fiftyRupeeCount,
            int hundredRupeeCount,
            int fivehundredRupeeCount,
            int thousandRupeeCount,
            decimal expAmount
            )
        {
            Money money = new Money(
                tenRupeeCount,
                twentyRupeeCount,
                fiftyRupeeCount,
                hundredRupeeCount,
                fivehundredRupeeCount,
                thousandRupeeCount);

            money.Amount.Should().Be(expAmount);

        }
    }
}
