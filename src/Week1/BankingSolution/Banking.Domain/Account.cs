namespace Banking.Domain;

public class Account
{
    private decimal _balance = 5000M;
    private ICalculateBonusesForDeposits _bonusCalculator;

    public Account(ICalculateBonusesForDeposits bonusCalculator)
    {
        _bonusCalculator = bonusCalculator;
    }

    public virtual void Deposit(TransactionValueTypes.Deposit deposit)
    {

        // Write the Code You Wish You Had

        decimal bonus = _bonusCalculator.CalculateBonusFor(this, deposit);
        _balance += deposit.Value + bonus;

    }
    public decimal GetBalance()
    {

        return _balance;
    }
    // "Primitive Obsession" -
    public void Withdraw(TransactionValueTypes.Withdrawal withdrawal)
    {
        GuardHasSufficientFunds(withdrawal.Value);

        _balance -= withdrawal.Value; // The important business!
    }

    private void GuardHasSufficientFunds(decimal amountToWithdraw)
    {
        if (amountToWithdraw > _balance)
        {
            throw new OverdraftException();
        }
    }
}
