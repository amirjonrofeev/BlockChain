using System;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace BlockChains
{
    public class Block
    {
        public int Nonce { get; set; } //Nonce
        public DateTime DateTime { get; set; } //DateTime
        public IList<Transaction> Transactions { get; set; } //List of transactions - Block includes transactions.
        public string PreviousHash { get; set; } //Hash of Previous Block.
        public string CurrentHash { get; set; } //Hash of Current Block


        public Block(DateTime dateTime, IList<Transaction> transactions, string previousHash = "")
        {
            DateTime = dateTime;
            Transactions = transactions;
            PreviousHash = previousHash;
            CurrentHash = CalculateHash();
            Nonce = 0;
        }

        public string CalculateHash()
        {
            byte[] bytes = Encoding.Unicode.GetBytes(DateTime.ToShortTimeString() + (Transactions) + Nonce);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;

            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }

            return hashString; //Sha256 - (coding - hashing)  
        }

        public void MineBlock(int diffuclty)
        {
            while (CurrentHash.Substring(0, diffuclty) != new string('0', diffuclty))
            {
                Nonce++;
                CurrentHash = CalculateHash();
            }

            Console.WriteLine("Block mined: " + CurrentHash); //Minening block.
        }
    }
}
