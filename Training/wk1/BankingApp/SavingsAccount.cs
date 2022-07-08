namespace BankingApp
{
    class SavingsAccount : Account // the ": Account" means we are EXTENDING the Account class.
    // The Savings Account IS-A Account 
    {
        // Fields / State
        private double interestRate;

        // Constructor
        public SavingsAccount(string fname, string lname, decimal balance, double interestRate) : base(fname, lname, balance)
        {
            this.interestRate = interestRate;
        }

        // Methods / Behaviors
        public void AddInterest()
        {
            decimal payment = (this.balance * ((decimal)this.interestRate));
            this.MakeDeposit(payment);
        }

    }
}