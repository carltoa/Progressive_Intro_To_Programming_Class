using Banking.Domain;

namespace Banking.UnitTests.TransactionValues;
public class ValidTypes
{
    [Fact]
    public void CreatingADeposit()
    {
        //// Write the Code you wish you had - Cory Haynes

        var deposit = TransactionValueTypes.Deposit.CreateFrom(100M);
        Assert.Equal(100M, deposit.Value);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-0.1)]
    public void CreatingDepositsWithInvalidAmounts(decimal amount)
    {
        Assert.Throws<InvalidTransactionValueException>(() =>
        {
            var deposit = TransactionValueTypes.Deposit.CreateFrom(amount);
        });

    }

    //TODO - do this for withdraw as well.

}
