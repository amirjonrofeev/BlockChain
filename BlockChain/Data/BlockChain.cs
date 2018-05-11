using System;
using System.Collections.Generic;

namespace BlockChains.Data
{
    public class BlockChain
    {
        //Chain of blocks
        public IList<Block> Chain { get; set; }

        //Block- transactions
        public IList<Transaction> PendingTransactions { get; set; }

        //Level of diffuclty of mining. //e.g = (4) 0000.
        public int Diffuclty { get; set; }

        //LastRewardValue
        public int MiningReward { get; set; }

        //Constructor for intialize first/genesis block.
        public BlockChain()
        {
            Chain = new List<Block>
            {
                CreateGenesisBlock() //FirstOrGenesisBlock
            };
            Diffuclty = 4;
            MiningReward = 100;
            PendingTransactions = new List<Transaction>();
        }

        //Constructor
        public Block CreateGenesisBlock()
        {
            return new Block(DateTime.Now, new List<Transaction>(), "0000");
        }

        //Lastest in blockchain.
        public Block GetLastestBlock()
        {
            return Chain[Chain.Count - 1];
        }

        //Mining of block
        public void MinePendingTransactions(string miningRewardAddress)
        {
            var block = new Block(DateTime.Now, PendingTransactions, GetLastestBlock().CurrentHash);
            block.MineBlock(Diffuclty); 

            Console.WriteLine("Block successfully mined!");
            Chain.Add(block);

            PendingTransactions.Add(new Transaction(null, miningRewardAddress, MiningReward));
        }

        //Balance of Address
        public int GetBalanceOfAddress(string address)
        {
            int balance = 0;

            foreach (var block in Chain)
            {
                foreach (var transaction in block.Transactions)
                {
                    if (transaction.FromAddress == address)
                    {
                        balance -= transaction.Amount;
                    }
                    if (transaction.ToAddress == address)
                    {
                        balance += transaction.Amount;
                    }
                }
            }

            return balance;
        }

        //CreateTransaction
        public void CreateTransaction(Transaction transaction)
        {
            PendingTransactions.Add(transaction);
        }

        //IsChainValid
        public bool IsChainValid()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                var currentBlock = Chain[i];
                var previousBlock = Chain[i - 1];

                if (currentBlock.CurrentHash != currentBlock.CalculateHash())
                    return false;

                if (previousBlock.CurrentHash != currentBlock.PreviousHash)
                    return false;

            }
            return true;
        }

    }
}
