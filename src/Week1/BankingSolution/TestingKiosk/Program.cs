


using Banking.Domain;

Console.WriteLine("Welcome to the Bank!");
var account = new Account(new StandardBonusCalculator());

while (true)
{
    Console.WriteLine($"Your Current Balance is {account.GetBalance():c}");
    Console.Write("Do you want to make a (d)eposit, (w)ithdrawal, or (q)uit? ");
    var response = Console.ReadLine();
    if (response == "d")
    {
        Console.Write("Amount to Deposit: ");
        var amountEntered = Console.ReadLine();
        if (amountEntered != null)
        {
            var depositAmount = int.Parse(amountEntered);
            var deposit = TransactionValueTypes.Deposit.CreateFrom(depositAmount);
            account.Deposit(deposit);
        }
    }
    if (response == "w")
    {
        Console.Write("Amount to Withdraw: ");
        try
        {
            var amountEntered = Console.ReadLine();
            if (amountEntered != null)
            {
                var depositAmount = int.Parse(amountEntered);
                var withdrawal = TransactionValueTypes.Withdrawal.CreateFrom(depositAmount);
                account.Withdraw(withdrawal);
            }
        }
        catch (OverdraftException)
        {

            Console.WriteLine("Sorry, you don't have enough money for that!");
        }
    }
    if (response == "q")
    {

        break; // quit looping

    }
}