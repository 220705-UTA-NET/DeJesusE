using System;

namespace BankingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Account newAccount = new Account("Ellery", "De Jesus", 100m);
            Account newAccount2 = new Account("Johnny", "Bravo", 100m);

            try
            {
                newAccount.MakeDeposit(100m);
                Console.WriteLine(newAccount.ToString());
                newAccount.MakeWithdrawal(50m);
                Console.WriteLine(newAccount.ToString());

                newAccount.Logs();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
