
using Banking.Domain;
using NSubstitute;
namespace Banking.UnitTests.BankAccount;
public class NewAccounts
{
    [Fact]
    public void NewAccountsHaveTheCorrectOpeningBalance()
    {
        // Write the Code We Wish We Had.
        // Given
        var account = new Account(Substitute.For<ICalculateBonusesForDeposits>());

        // When
        decimal balance = account.GetBalance();
        // Then
        Assert.Equal(5000M, balance);


    }
}
