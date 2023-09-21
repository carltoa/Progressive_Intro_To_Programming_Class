using Banking.Domain;

namespace Banking.UnitTests.TestDoubles;
public class StubbedStandardBonusCalculator : ICalculateBonusesForDeposits
{
    public decimal CalculateBonusFor(Account account, TransactionValueTypes.Deposit amountToDeposit)
    {
        return amountToDeposit.Value == 82.23M ? 42 : 0;
    }
}
