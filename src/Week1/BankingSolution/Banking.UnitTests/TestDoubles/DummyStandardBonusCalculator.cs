using Banking.Domain;

namespace Banking.UnitTests.TestDoubles;
public class DummyStandardBonusCalculator : ICalculateBonusesForDeposits
{
    public decimal CalculateBonusFor(Account account, TransactionValueTypes.Deposit amountToDeposit)
    {
        return 0;
    }
}
