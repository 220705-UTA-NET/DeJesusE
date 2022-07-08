namespace Banking
{
    class SavingsAccount : Account // the ": Account" means we are EXTENDING the Account class.
    // The Savings Account IS-A Account 
    {
        // Fields / State
        private double interestRate;

        // Constructor
        public SavingsAccount(double interestRate)
        {
            this.interestRate = interestRate;
        }

        // Methods / Behaviors
        public void AddInterest()
        {
            int payment = (this.balance * this.interestRate);
            this.MakeDeposit(payment);
        }

        // Constructor
    }
}