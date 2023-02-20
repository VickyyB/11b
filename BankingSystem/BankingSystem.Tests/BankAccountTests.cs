using NUnit.Framework;
using System;

namespace BankingSystem.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DepositShouldIncreaseBalance()
        {
            {
                //Arrange
                BankAccount bankAccount = new BankAccount(123);
                decimal depositAmount = 100;

                //Act
                bankAccount.Deposit(depositAmount);

                //Assert
                Assert.AreEqual(depositAmount, bankAccount.Balance);
            }
        }

        [Test]
        public void AccountInicializeWhithPositiveValue()
        {
            {
                //Arrange

                //Act
                BankAccount bankAccount = new BankAccount(123, 2000m);

                //Assert
                Assert.AreEqual(2000m, bankAccount.Balance);
            }
        }

        [TestCase(100)]
        [TestCase(3500)]
        [TestCase(2400)]
        public void DepositShouldIncreaseBalanceAll(decimal depositAmount)
        {
            {
                //Arrange
                BankAccount bankAccount = new BankAccount(123);

                //Act
                bankAccount.Deposit(depositAmount);

                //Assert
                Assert.AreEqual(depositAmount, bankAccount.Balance);
            }
        }

        [Test]
        public void NegativeAmountShouldThrowInvalidOperationExeptions()
        {
            {
                //Arrange
                BankAccount bankAccount = new BankAccount(123);
                decimal depositAmount = -100;

                //Act

                //Assert
                Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(depositAmount));
            }
        }

        [Test]
        public void NegativeAmountShouldThrowInvalidOperationExeptionsWithMessage()
        {
            //Assert
            BankAccount bankAccount = new BankAccount(123);
            decimal depositAmount = -100;
            //Act

            //Assert
            var ex = Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(depositAmount));

            Assert.AreEqual(ex.Message, "Negative amount");
        }
    }
}