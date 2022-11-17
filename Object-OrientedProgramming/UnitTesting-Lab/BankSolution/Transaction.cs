namespace BankSolution
{
    public class Transaction
    {
        public Transaction(DateTime transactionDate, decimal amount, string reference)
        {
            TransactionDate = transactionDate;
            Amount = amount;
            Reference = reference;
        }

        public DateTime TransactionDate { get; private set; }

        public decimal Amount { get; private set; }

        public string Reference { get; private set; }

        public override string ToString()
        {
            var typeOfTransaction = this.Amount > 0 ? "Deposit" : "Withdrawal";

            return
                $"{this.TransactionDate.ToShortDateString()}" +
                $": {this.TransactionDate.ToShortTimeString()}" +
                $" - {typeOfTransaction}" +
                $": {this.Amount:f2}" +
                $" - {this.Reference}";
        }
    }
}
