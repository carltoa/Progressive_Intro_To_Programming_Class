using Banking.Domain;
using Banking.UnitTests.TestDoubles;

namespace Banking.UnitTests.BankAccount;
public class OverdraftNotAllowed
{
    private readonly Account _account;
    private readonly decimal _openingBalance;
    public OverdraftNotAllowed()
    {
        _account = new Account(new DummyStandardBonusCalculator());
        _openingBalance = _account.GetBalance();
    }
    [Fact]
    public void BalanceDoesNotDecreaseOnOverdraft()
    {
        // If you overdraft, what should be the "observable" thing that happens?
        // - it shouldn't decrease your balance.
        //    - if I have 5000, and I take out 6000, then I should still have 5000
        // Given


        var amountToWithdraw = TransactionValueTypes.Withdrawal.CreateFrom(_openingBalance + .01M);


        // When
        try
        {
            _account.Withdraw(amountToWithdraw);
        }
        catch (OverdraftException)
        {

            // Ignore
        }
        finally
        {
            Assert.Equal(_openingBalance, _account.GetBalance());
        }
    }
    [Fact]
    public void OverdraftThrowsAnException()
    {
        // Given

        var amountToWithdraw = TransactionValueTypes.Withdrawal.CreateFrom(_openingBalance + .01M);
        // When & then
        Assert.Throws<OverdraftException>(() =>
        {
            _account.Withdraw(amountToWithdraw);
        });
    }
}
