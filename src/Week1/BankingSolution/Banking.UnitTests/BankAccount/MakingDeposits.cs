using Banking.Domain;

namespace Banking.UnitTests.BankAccount;
public class MakingDeposits
{
    [Fact]
    public void MakingADepositIncreasesBalance()
    {
        //given
        var account = new Account();
        var openingBalance = account.GetBalance();
        var amountToDeposit = 125.23M;

        //when
        account.Deposit(amountToDeposit);

        //then
        Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
    }
}