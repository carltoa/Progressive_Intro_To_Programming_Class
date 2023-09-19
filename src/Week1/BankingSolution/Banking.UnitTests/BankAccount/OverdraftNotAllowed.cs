using Banking.Domain;

namespace Banking.UnitTests.BankAccount;
public class OverdraftNotAllowed
{
    [Fact]
    public void BalanceDoesNotDecreaseOnOverdraft()
    {
        //withdrawal of more than account balance should not result in any change in balance
        var account = new Account();
        var openingBalance = account.GetBalance();
        var amountToWithdraw = openingBalance + 0.01m;

        try
        {
            account.Withdraw(amountToWithdraw);
        }
        catch (OverdraftException)
        {
            //ignore
        }
        finally
        {
            Assert.Equal(openingBalance, account.GetBalance());
        }
    }

    [Fact]
    public void OverdraftThrowsAnException()
    {
        //withdrawal of more than account balance should throw exception
        var account = new Account();
        var openingBalance = account.GetBalance();
        var amountToWithdraw = openingBalance + 0.01m;

        Assert.Throws<OverdraftException>(() =>
        {
            account.Withdraw(amountToWithdraw);
        });
    }
}
