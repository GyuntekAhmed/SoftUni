namespace BankSolution.Tests
{
    public class AccountTests
    {
        [Test]
        public void WithNegativeStartingBalanceShouldThrowException()
        {
            Assert.That(() =>
            {
                // Arrange & Act
                var account = new Account(-100);

            },
            // Assert
            Throws.Exception.TypeOf<InvalidOperationException>(),
            "You cannot have a negative balance.");
        }

        [Test]
        public void DepositWithPositiveAmountShoulAddToBalance()
        {
            // Arrange
            var account = new Account(100);

            // Act
            account.Deposit(200, "Deposit");

            // Assert
            Assert.That(account.Balance, Is.EqualTo(300));
        }

        [Test]
        public void WithdrawWithValidAmountShouldSubstractFromBalance()
        {
            // Arrange
            var account = new Account(100);

            // Act
            account.Withdraw(40);

            // Assert
            Assert.That(account.Balance, Is.EqualTo(59.5));
        }

        [Test]
        public void WithdrawWithInvalidAmountShouldThrowException()
        {
            Assert.That(() =>
            {
                // Arrange
                var account = new Account(500);
                // Act
                account.Withdraw(1000);
            },
            // Assert
                Throws.Exception.TypeOf<InvalidOperationException>(),
            "You do not have enough money for this operation.");
        }

        [Test]
        public void TransactionHistoryShouldReturnCorrectValues()
        {
            // Arrange
            var account = new Account(100);

            account.Deposit(500, "From Parents");
            account.Deposit(1500, "Salary");
            account.Withdraw(300);
            account.Withdraw(800);
            account.Deposit(2000, "Car Trade");
            account.Withdraw(450);

            // Act
            var transactiontHistory = account.TransactionHistory();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(transactiontHistory[0],
                    Contains.Substring("Deposit: 100.00 - Initial Balance"));
                Assert.That(transactiontHistory[1],
                    Contains.Substring("Deposit: 500.00 - From Parents"));
                Assert.That(transactiontHistory[2],
                    Contains.Substring("Deposit: 1500.00 - Salary"));
                Assert.That(transactiontHistory[3],
                    Contains.Substring("Withdrawal: -300.00 - Withdrawal"));
                Assert.That(transactiontHistory[4],
                    Contains.Substring("Withdrawal: -0.50 - Withdrawal all bank tax"));
                Assert.That(transactiontHistory[5],
                    Contains.Substring("Withdrawal: -800.00 - Withdrawal"));
                Assert.That(transactiontHistory[6],
                    Contains.Substring("Withdrawal: -0.50 - Withdrawal all bank tax"));
                Assert.That(transactiontHistory[7],
                    Contains.Substring("Deposit: 2000.00 - Car Trade"));
                Assert.That(transactiontHistory[8],
                    Contains.Substring("Withdrawal: -450.00 - Withdrawal"));
                Assert.That(transactiontHistory[9],
                    Contains.Substring("Withdrawal: -0.50 - Withdrawal all bank tax"));
            });
        }
    }
}
