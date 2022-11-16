namespace BankSolution.Tests
{
    public class AccountTests
    {
        [Test]
        public void WithNegativeStartingBalanceShouldThrowException()
        {
            Assert.That(() =>
            {
                var account = new Acocount(-100);

            }, Throws.Exception.TypeOf<InvalidOperationException>(),
            "You cannot have a negative balance.");
        }

        [Test]
        public void DepositWithPositiveAmountShoulAddToBalance()
        {
            var account = new Acocount(100);

            account.Deposit(200);

            Assert.That(account.Balance, Is.EqualTo(300));
        }
    }
}
