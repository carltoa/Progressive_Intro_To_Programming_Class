
using Banking.Domain;
using Banking.UnitTests.TestDoubles;

namespace Banking.UnitTests.BankAccount;
public class MakingDeposits
{
    [Fact]
    public void MakingADepositIncreasesTheBalance()
    {
        // Given
        var account = new Account(new DummyStandardBonusCalculator());
        var openingBalance = account.GetBalance();
        var amountToDeposit = 125.23M;
        var deposit = TransactionValueTypes.Deposit.CreateFrom(amountToDeposit);

        // When
        account.Deposit(deposit);

        // Then

        Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
    }

}
