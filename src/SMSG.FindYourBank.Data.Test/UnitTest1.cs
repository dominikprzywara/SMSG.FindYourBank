using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSG.FindYourBank.Data.Logic;

namespace SMSG.FindYourBank.Data.Test
{
    [TestClass]
    public class UnitTest1
    {
        IBankNameResolver bankNameResolver;
        
        [TestInitialize]
        public void Init()
        {
            bankNameResolver = new BankNameResolver();
        }

        [TestMethod]
        public void IsAccountNumberCorrect_CorrectAccountNumber()
        {
            Assert.IsTrue(bankNameResolver.IsAccountNumberCorrect("83 1010 1023 0000 2613 9510 0000"));
        }

        [TestMethod]
        public void IsAccountNumberCorrect_IncorrectAccountNumber()
        {
            Assert.IsFalse(bankNameResolver.IsAccountNumberCorrect("83 2130 1223 0210 2613 9510 0000"));
        }

        [TestMethod]
        public void GetBankName_CorrectAccountNameNBP()
        {
            var bankName = bankNameResolver.GetBankName("83 1010 1023 0000 2613 9510 0000");
            Assert.AreEqual("Narodowy Bank Polski", bankName, true);
        }
    }
}
