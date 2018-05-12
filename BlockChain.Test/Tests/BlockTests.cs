using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlockChains.Test
{
    [TestClass]
    public class BlockTests
    {
        [TestMethod]
        public void CalculateHash_Hashing_ReturnsHash()
        {
            DateTime dateTime = DateTime.Now;
            IList<Transaction> transactions = new List<Transaction>() {
                new Transaction("Address1", "Address2", 100),
                new Transaction("Address2", "Address1", 50),
                new Transaction("Address3", "Address2", 25),
                new Transaction("Address2", "Address25", 100)
            };
            string previousHash = "0000";

            Block block = new Block(dateTime, transactions, previousHash);

            Assert.IsNotNull(block.CalculateHash());
        }

        [TestMethod]
        public void MineBlock_Mining_SuccessMining()
        {
            DateTime dateTime = DateTime.Now;
            IList<Transaction> transactions = new List<Transaction>() {
                new Transaction("Address1", "Address2", 100),
                new Transaction("Address2", "Address1", 50),
                new Transaction("Address3", "Address2", 25),
                new Transaction("Address2", "Address25", 100)
            };
            string previousHash = "0000";
            Block block = new Block(dateTime, transactions, previousHash);
            int diffuclty = 2;

            block.MineBlock(diffuclty);
        }
    }
}
