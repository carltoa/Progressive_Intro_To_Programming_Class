namespace Banking.Domain;

public class TimeBasedBonusCalculator
{
    private readonly IProvideTheBusinessClock _businessClock;

    public TimeBasedBonusCalculator(IProvideTheBusinessClock businessClock)
    {
        _businessClock = businessClock;
    }

    public decimal CalculateBonusForAccountDeposit(decimal balance, decimal deposit)
    {

        bool open = _businessClock.isOpen();
        if (open)
        {
            return balance >= 5000M ? deposit * .13M : 0;
        }
        else
        {
            return balance >= 5000M ? deposit * .10M : 0;
        }
    }
}

public interface IProvideTheBusinessClock
{
    public bool isOpen();
}