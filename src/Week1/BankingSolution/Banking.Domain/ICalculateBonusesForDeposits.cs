namespace Banking.Domain;

public interface ICalculateBonusesForDeposits
{
    decimal CalculateBonusFor(Account account, TransactionValueTypes.Deposit amountToDeposit);
}