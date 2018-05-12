using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlockChains.Test
{
    [TestClass]
    public class BlockChainTest
    {
        [TestMethod]
        public void MinePendingTransactions_ValidMindPending_ValidValue()
        {
            //Поумолчанию то есть в приложении даёт по 100 $.

            BlockChain blockChain = new BlockChain();

            string address1 = "Address1", address2 = "Address2", address3 = "Address3";

            blockChain.CreateTransaction(new Transaction(address1, address2, 25));
            blockChain.CreateTransaction(new Transaction(address2, address1, 10));
            blockChain.CreateTransaction(new Transaction(address3, address1, 30));

            blockChain.MinePendingTransactions(address1);

        }

        [TestMethod]
        public void GetBalanceOfAddress_CheckingValue_ReturningValue()
        {
            BlockChain blockChain = new BlockChain();

            string address1 = "Address1", address2 = "Address2", address3 = "Address3";

            blockChain.CreateTransaction(new Transaction(address1, address2, 25));
            blockChain.CreateTransaction(new Transaction(address2, address1, 10));
            blockChain.CreateTransaction(new Transaction(address3, address1, 30));

            blockChain.MinePendingTransactions(address1);

            blockChain.GetBalanceOfAddress(address1);
        }

        [TestMethod]
        public void CreateTransaction_ValidAdding()
        {
            BlockChain blockChain = new BlockChain();

            Transaction transaction = new Transaction("Address1", "Address2", 100);

            Assert.IsTrue(blockChain.CreateTransaction(transaction));
        }

        [TestMethod]
        public void CreateTransactions_UnValidAdding()
        {
            BlockChain blockChain = new BlockChain();

            Transaction transaction = null;

            Assert.IsFalse(blockChain.CreateTransaction(transaction));
        }

        [TestMethod]
        public void IsChainValid_TrueValue_ReturnTrue()
        {
            BlockChain blockChain = new BlockChain();

            string address1 = "Address1", address2 = "Address2", address3 = "Address3";

            blockChain.CreateTransaction(new Transaction(address1, address2, 25));
            blockChain.CreateTransaction(new Transaction(address2, address1, 10));
            blockChain.CreateTransaction(new Transaction(address3, address1, 30));

            blockChain.MinePendingTransactions(address1);
            blockChain.MinePendingTransactions(address2);

            Assert.IsTrue(blockChain.IsChainValid());
        }

        [TestMethod]
        public void IsChainVaid_FalseCurrentHash_ReturnFalse()
        {
            BlockChain blockChain = new BlockChain();

            string address1 = "Address1", address2 = "Address2", address3 = "Address3";

            blockChain.CreateTransaction(new Transaction(address1, address2, 25));
            blockChain.CreateTransaction(new Transaction(address2, address1, 10));
            blockChain.CreateTransaction(new Transaction(address3, address1, 30));

            blockChain.MinePendingTransactions(address1);
            blockChain.MinePendingTransactions(address2);

            blockChain.Chain[1].CurrentHash = "WrongHashHackerchangedhash";

            Assert.IsFalse(blockChain.IsChainValid());

        }

        [TestMethod]
        public void IsChainVaid_FalsePreviousHash_ReturnFalse()
        {
            BlockChain blockChain = new BlockChain();

            string address1 = "Address1", address2 = "Address2", address3 = "Address3";

            blockChain.CreateTransaction(new Transaction(address1, address2, 25));
            blockChain.CreateTransaction(new Transaction(address2, address1, 10));
            blockChain.CreateTransaction(new Transaction(address3, address1, 30));

            blockChain.MinePendingTransactions(address1);
            blockChain.MinePendingTransactions(address2);

            blockChain.Chain[1].PreviousHash = "WrongHashHackerchangedhash";

            Assert.IsFalse(blockChain.IsChainValid());

        }
    }
}
