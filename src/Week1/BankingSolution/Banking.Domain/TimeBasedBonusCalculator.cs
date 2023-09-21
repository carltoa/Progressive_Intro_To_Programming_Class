namespace Banking.Domain;

public class TimeBasedBonusCalculator
{


    public decimal CalculateBonusForAccountDeposit(decimal balance, decimal deposit)
    {

        bool open = DateTime.Now.DayOfWeek == DayOfWeek.Thursday;
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