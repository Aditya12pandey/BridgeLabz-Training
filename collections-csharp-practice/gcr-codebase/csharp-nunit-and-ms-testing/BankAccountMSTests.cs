using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Tests
{
    internal class BankAccountMSTests
    {
        private BankAccount _account;

        [TestInitialize]
        public void Setup()
        {
            _account = new BankAccount(100);
        }

        [TestMethod]
        public void Deposit_ShouldIncreaseBalance()
        {
            _account.Deposit(50);

            Assert.AreEqual(150, _account.GetBalance());
        }

        [TestMethod]
        public void Withdraw_ShouldDecreaseBalance()
        {
            _account.Withdraw(30);

            Assert.AreEqual(70, _account.GetBalance());
        }

        [TestMethod]
        public void Withdraw_InsufficientFunds_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                _account.Withdraw(200);
            });
        }
    }
}
