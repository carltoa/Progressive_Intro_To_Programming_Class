using Banking.Domain;
using Banking.UnitTests.TestDoubles;

namespace Banking.UnitTests.BankAccount;
public class MakingWithdrawal
{
    private readonly Account _account;
    private readonly decimal _openingBalance;
    public MakingWithdrawal()
    {
        _account = new Account(new DummyStandardBonusCalculator());
        _openingBalance = _account.GetBalance();
    }

    [Theory]
    [InlineData(82.23)]
    [InlineData(200)]
    public void MakingAWithdrawalDecreasesTheBalance(decimal amountToWithdraw)
    {
        // Given

        var withdraw = TransactionValueTypes.Withdrawal.CreateFrom(amountToWithdraw);

        // When
        _account.Withdraw(withdraw);

        Assert.Equal(_openingBalance - amountToWithdraw, _account.GetBalance());
    }

    [Fact]
    public void CanTakeEntireBalance()
    {

        var withdraw = TransactionValueTypes.Withdrawal.CreateFrom(_openingBalance);

        _account.Withdraw(withdraw);

        Assert.Equal(0, _account.GetBalance());
    }
}
