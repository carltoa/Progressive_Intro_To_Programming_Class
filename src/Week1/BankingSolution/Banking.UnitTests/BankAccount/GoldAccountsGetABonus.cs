using Banking.Domain;
using NSubstitute;

namespace Banking.UnitTests.BankAccount;
public class GoldAccountsGetABonus
{
    [Fact]
    public void AccountDepositsUseTherBonusCalculator()
    {
        // Given
        var stubbedCalculator = Substitute.For<ICalculateBonusesForDeposits>();
        Account account = new Account(stubbedCalculator);
        var openingBalance = account.GetBalance();
        var amountToDeposit = 82.23M;
        var deposit = TransactionValueTypes.Deposit.CreateFrom(amountToDeposit);
        stubbedCalculator.CalculateBonusFor(account, deposit).Returns(42M);

        // When 
        account.Deposit(deposit);

        Assert.Equal(openingBalance + amountToDeposit + 42M, account.GetBalance());

    }
}
