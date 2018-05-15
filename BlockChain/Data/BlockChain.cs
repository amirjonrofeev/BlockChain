using System;
using System.Collections.Generic;

namespace BlockChains
{
    public class BlockChain
    {
        public IList<Block> Blocks { get; set; }
        public Block GetLastestBlock { get { return Blocks[Blocks.Count - 1]; } }
        public IList<Transaction> PendingTransactions { get; set; }
        public int Diffuclty { get; set; }
        public int MiningReward { get; set; }

        public BlockChain()
        {
            Blocks = new List<Block>
            {
                CreateGenesisBlock()
            };
            MiningReward = 100;
            Diffuclty = 4;
            PendingTransactions = new List<Transaction>();
        }

        private Block CreateGenesisBlock()
        {
            return new Block(DateTime.Now, new List<Transaction>(), "0000");
        }

        public void MinePendingTransactions(User miningRewardUser)
        {
            PendingTransactions.Add(new Transaction(null, miningRewardUser, 150));

            Block block = new Block(DateTime.Now, PendingTransactions, GetLastestBlock.CurrentHash);
            block.MineBlock(Diffuclty);

            Console.WriteLine("Block successfully mined!");
            Blocks.Add(block);

            PendingTransactions= new List<Transaction>();
        }

        public void BuyCoins(User user, double amount)
        {
            //Логика для покупки криптовалюты пока что нету обменников(но есть возможность поменять QIWI,WEBMONEY и другии веб - деньги или настоящие деньги на криптовалюту.)
            PendingTransactions.Add(new Transaction(null, user, amount));
        }

        public double GetBalanceOfAddress(User user)
        {
            double balance = 0;

            foreach (var block in Blocks)
            {
                foreach (var transaction in block.Transactions)
                {
                    if (transaction.FromUser == user.Name)
                    {
                        balance -= transaction.Amount;
                    }
                    if (transaction.ToUser == user.Name)
                    {
                        balance += transaction.Amount;
                    }
                }
            }

            return balance;
        }

        public bool CreateTransaction(Transaction transaction)
        {
            if (transaction != null)
            {
                PendingTransactions.Add(transaction);
                return true;
            }
            else
                return false;

        }

        public bool IsChainValid()
        {
            for (int i = 1; i < Blocks.Count; i++)
            {
                var currentBlock = Blocks[i];
                var previousBlock = Blocks[i - 1];

                if (currentBlock.CurrentHash != currentBlock.CalculateHash())
                    return false;

                if (previousBlock.CurrentHash != currentBlock.PreviousHash)
                    return false;

            }
            return true;
        }

    }
}
