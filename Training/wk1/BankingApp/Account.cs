using System;

namespace BankingApp
{
    // Account could also be made abstract by replacing below with
    // abstract class Account
    class Account
    {
        // Fields, or states

        public int accountNumber { get; set; }
        // Same as
        // private int accountNumber;
        // public get() { return this.accountNumber}
        // public set(int accountNumber){this.accountNumber=accountNumber}
        private string fName;
        private string lName;
        protected decimal balance;
        private List<Transaction> logs;


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
            this.logs = new List<Transaction>();

            MakeDeposit(balance, "Initial Deposit");
        }

        // public abstract method, must be overridden
        // public virtual method, could be overridden

        // Methods
        public void MakeDeposit(decimal deposit, string note)
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
                MakeTransaction(deposit, $"{note}");
            }
        }

        public void MakeWithdrawal(decimal withdraw, string note)
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
                MakeTransaction(withdraw, $"{note}");
            }
        }

        public void MakeTransaction(decimal amount, string note)
        {
            logs.Add(new Transaction(amount, DateTime.Now, note));
        }

        public string Logs()
        {
            string display;

            // string display = "###\n";
            // foreach (Transaction log in this.logs)
            // {
            //     display += $"# {log.ToString()}\n";
            // }
            // Console.WriteLine("###");

            // The above code is also valid. It simply just uses more resources than using StringBuilder.

            var report = new System.Text.StringBuilder();
            report.Append("TransactionID\tDate\t\tAmount\t\tNote\n");
            foreach (var log in this.logs)
            {
                report.AppendLine(log.ToString());
            }
            display = report.ToString();

            return display;
        }

        // Must override the Object class' ToString method
        public override string ToString()
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