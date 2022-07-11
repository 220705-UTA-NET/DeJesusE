namespace BankingApp
{
    class Transaction
    {
        // Fields / State
        private decimal amount;
        private string note;
        private DateTime date;

        private uint transID;
        private static uint transactionIdSeed = 0;

        // Constructor

        public Transaction(decimal amount, DateTime date, string note)
        {
            this.amount = amount;
            this.date = date;
            this.note = note;

            this.transID = transactionIdSeed;
            transactionIdSeed++;
        }

        // Method
        public override string ToString()
        {
            return $"{this.transID}\t\t{this.date.ToShortDateString()}\t{amount}\t\t{note}";
        }
    }
}