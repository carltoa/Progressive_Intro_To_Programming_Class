namespace Banking.Domain;

public class Account
{
    private decimal _balance;
    public Account()
    {
        _balance = 5000m;
    }

    public void Deposit(decimal amountToDeposit)
    {
        _balance += amountToDeposit;
    }

    public decimal GetBalance()
    {
        return _balance;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        GuardHasSufficientFunds(amountToWithdraw);

        _balance -= amountToWithdraw;
    }

    private void GuardHasSufficientFunds(decimal amountToWithdraw)
    {
        if (amountToWithdraw > _balance)
        {
            throw new OverdraftException();
        }
    }
}
