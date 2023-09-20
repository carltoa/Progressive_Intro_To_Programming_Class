namespace Banking.Domain;

public class Account
{
    private decimal _balance = 5000M;
    public void Deposit(TransactionValueTypes.Deposit amountToDeposit)
    {
        _balance += amountToDeposit.Value;
    }

    public decimal GetBalance()
    {

        return _balance;
    }
    // "Primitive Obsession" -
    public void Withdraw(TransactionValueTypes.Withdrawal amountToWithdraw)
    {
        GuardHasSufficientFunds(amountToWithdraw.Value);

        _balance -= amountToWithdraw.Value; // The important business!
    }

    private void GuardHasSufficientFunds(decimal amountToWithdraw)
    {
        if (amountToWithdraw > _balance)
        {
            throw new OverdraftException();
        }
    }
}
