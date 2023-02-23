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

        [Test]
        public void NegativeCashShouldThrowInvalidOperationExeptionsWithMessage()
        {
            //Assert
            BankAccount bankAccount = new BankAccount(123);
            decimal cashCredit = -100;
            //Act

            //Assert
            var ex = Assert.Throws<InvalidOperationException>(() => bankAccount.Credit(cashCredit));

            Assert.AreEqual(ex.Message, "Negative cash");
        }

        [Test]
        public void PercentShouldBeAPositiveNumber()
        {
            //Assert
            BankAccount bankAccount = new BankAccount(123);
            double percent = -100;
            //Act

            //Assert
            var ex = Assert.Throws<ArgumentException>(() => bankAccount.Increase(percent));

            Assert.AreEqual(ex.Message, "The percent must be positive!");
        }

        [TestCase(1020)]
        [TestCase(2500)]
        [TestCase(3400)]

        public void BonusShouldIncreaseBalanceInBankAccount(decimal bonusAmount)
        {
            {
                //Arrange
                BankAccount bankAccount = new BankAccount(123);
                bankAccount.Balance = bankAccount.Bonus();

                //Assert
                Assert.AreEqual(bankAccount.Bonus(), bankAccount.Balance);
            }
        }

        [Test]
        public void PaymentShouldNotBeNegativeAmount()
        {
            //Assert
            BankAccount bankAccount = new BankAccount(123);
            decimal payment = -100;
            //Act

            //Assert
            var ex = Assert.Throws<ArgumentException>(() => bankAccount.PaymentForCredit(payment));

            Assert.AreEqual(ex.Message, "Payment cannot be zero or negative");
        }

        [Test]
        public void PaymentShouldNotNullAmount()
        {
            //Assert
            BankAccount bankAccount = new BankAccount(123);
            decimal payment = 0;
            //Act

            //Assert
            var ex = Assert.Throws<ArgumentException>(() => bankAccount.PaymentForCredit(payment));

            Assert.AreEqual(ex.Message, "Payment cannot be zero or negative");
        }

        [Test]
        public void NotEnouhgAmountInBalanceForPayment()
        {
            //Assert
            BankAccount bankAccount = new BankAccount(123);
            decimal payment = 100;

            //Act


            //Assert
            var ex = Assert.Throws<ArgumentException>(() => bankAccount.PaymentForCredit(payment));

            Assert.AreEqual(ex.Message, "Not enough money");
        }

        [Test]
        public void BalanceMinusPaymentIfEnoughMoney() 
        {
            BankAccount bankAccount = new BankAccount(123, 1000);

            bankAccount.Balance = bankAccount.PaymentForCredit(100);
            Assert.AreEqual(bankAccount.PaymentForCredit(100), bankAccount.Balance);
        }
    }
}


    
