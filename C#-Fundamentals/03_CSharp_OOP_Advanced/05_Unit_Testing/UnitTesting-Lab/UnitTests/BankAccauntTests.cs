using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class BankAccauntTests
    {
        [Test]
        public void AccountInitializeWithPositiveValue()
        {
            var account = new BankAccount();
            account.Deposit(10);
            Assert.That(account.Balance, Is.EqualTo(10));
        }

        [Test]
        public void Deposit_AddMoney_20()
        {
            var account = new BankAccount();

            account.Deposit(20);
            Assert.That(account.Balance,Is.EqualTo(20));
        }
    }
}
