using System;

namespace BankingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Account newAccount = new Account("Ellery", "De Jesus", 100m);
            SavingsAccount newAccount2 = new SavingsAccount("Johnny", "Bravo", 100m, 0.5);

            try
            {
                // newAccount.MakeDeposit(100m);
                // Console.WriteLine(newAccount.ToString());
                // newAccount.MakeWithdrawal(50m);
                // Console.WriteLine(newAccount.ToString());

                // newAccount.Logs();

                newAccount2.AddInterest();
                Console.WriteLine(newAccount2.ToString());
                newAccount2.Logs();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
