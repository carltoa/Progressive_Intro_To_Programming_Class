using Banking.Domain;

namespace Banking.UnitTests.BankAccount;
public class MakingWithdrawal
{

    [Theory]
    [InlineData(82.23)]
    [InlineData(200)]
    public void MakingAWithdrawalDecreasesTheBalance(decimal amountToWithdraw)
    {
        // Given
        var account = new Account();
        var openingBalance = account.GetBalance();
        var withdraw = TransactionValueTypes.Withdrawal.CreateFrom(amountToWithdraw);

        // When
        account.Withdraw(withdraw);

        Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
    }

    [Fact]
    public void CanTakeEntireBalance()
    {
        var account = new Account();
        var withdraw = TransactionValueTypes.Withdrawal.CreateFrom(account.GetBalance());

        account.Withdraw(withdraw);

        Assert.Equal(0, account.GetBalance());
    }
}
