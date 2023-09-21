namespace Banking.Domain;

public class StandardBonusCalculator : ICalculateBonusesForDeposits
{
    public decimal CalculateBonusFor(Account account, TransactionValueTypes.Deposit amountToDeposit)
    {
        return CalculateBonusForAccountDeposit(account.GetBalance(), amountToDeposit.Value);
    }

    public decimal CalculateBonusForAccountDeposit(decimal balance, decimal deposit)
    {

        return balance >= 5000M ? deposit * .10M : 0;
    }
}