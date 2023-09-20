namespace Banking.Domain;
public abstract record TransactionValueTypes
{
    public record Deposit : TransactionValueTypes
    {

        public decimal Value { get; private init; }
        public static Deposit CreateFrom(decimal amount)
        {
            GuardAgainstWrongValue(amount);
            return new Deposit { Value = amount };
        }

    }

    public record Withdrawal : TransactionValueTypes
    {
        public decimal Value { get; private init; }
        public static Withdrawal CreateFrom(decimal amount)
        {
            GuardAgainstWrongValue(amount);
            return new Withdrawal { Value = amount };
        }
    }

    protected static void GuardAgainstWrongValue(decimal amount)
    {
        if (amount <= 0) { throw new InvalidTransactionValueException(); }
    }
}

public class InvalidTransactionValueException : ArgumentOutOfRangeException { }


// Deposit(decimal amount)
// Withdraw(decimal amount)
