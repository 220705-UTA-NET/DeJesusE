using System;

namespace BankingApp
{
    class Account
    {
        // Fields, or states

        public int accountNumber { get; set; }
        // private int accountNumber;
        private string fName;
        private string lName;
        protected decimal balance;
        private List<string> logs;


        // There is only one accountNumberSeed for objects created from Account and it is shared
        // amongst them due to it being static.
        private static int accountNumberSeed = 0;

        // Random number generator for account number. Abandoned as it didn't protect against duplicity.
        // Random rnd = new Random();

        // Methods / Behaviors
        // [access modifier] [return type] [name]([parameters]) { ... }

        // Constructor
        public Account() { }

        public Account(string fName, string lName, decimal balance)
        {
            this.accountNumber = accountNumberSeed;
            accountNumberSeed++;

            this.fName = fName;
            this.lName = lName;
            this.logs = new List<string>();

            MakeDeposit(balance);
        }

        // Methods
        public void MakeDeposit(decimal deposit)
        {
            if (deposit == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(deposit), "Deposit cannot be 0.");
            }
            else if (deposit < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(deposit), "Deposit cannot be less than 0.");
            }
            else
            {
                this.balance += deposit;
                MakeTransaction($"Deposit of ${deposit} made.");
            }
        }

        public void MakeWithdrawal(decimal withdraw)
        {
            if (withdraw == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(withdraw), "Withdrawal cannot be 0.");
            }
            else if (withdraw < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(withdraw), "Withdrawal cannot be less than 0.");
            }
            else
            {
                this.balance -= withdraw;
                MakeTransaction($"Withdrawal of ${withdraw} made.");
            }
        }

        void MakeTransaction(string transaction)
        {
            this.logs.Add($"Transaction #{this.logs.Count()}: {transaction}");
        }

        public void Logs()
        {
            Console.WriteLine("###");
            foreach (string log in this.logs)
            {
                Console.WriteLine($"# {log}");
            }
            Console.WriteLine("###");
        }

        public string ToString()
        {
            string display = "###\n";
            display += $"# Account #: {this.accountNumber}\n";
            display += $"# {this.fName} {this.lName}\n";
            display += $"# Balance: {this.balance}\n";
            display += "###\n";

            return display;
        }


    }
}