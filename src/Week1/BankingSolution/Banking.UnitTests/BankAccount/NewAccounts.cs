
using Banking.Domain;

namespace Banking.UnitTests.BankAccount;
public class NewAccounts
{
    [Fact]
    public void NewAccountsHaveTheCorrectOpeningBalance()
    {
        // Write the Code We Wish We Had.
        // Given
        var account = new Account();

        // When
        decimal balance = account.GetBalance();
        // Then
        Assert.Equal(5000M, balance);


    }
}
