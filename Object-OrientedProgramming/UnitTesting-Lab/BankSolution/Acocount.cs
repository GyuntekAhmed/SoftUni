namespace BankSolution
{
    public class Acocount
    {
        private decimal balance;

        public Acocount(int amount)
        {
            this.Balance = amount;
        }

        public decimal Balance 
        {
            get => this.balance;
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("You cannot have a negative balanc");
                }

                this.balance = value;
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("You cannot have a negative balance.");
            }

            this.balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (this.Balance < amount)
            {
                throw new InvalidOperationException("You do not have enough money for this operation.");
            }

            this.balance -= amount;
        }
    }
}
