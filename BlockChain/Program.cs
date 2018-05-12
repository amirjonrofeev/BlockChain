using System;

//Amir Rofeev
namespace BlockChains
{
    public class Program
    {
        internal static void Main()
        {
            BlockChain blockChain = new BlockChain();

            blockChain.CreateTransaction(new Transaction("Address2", "Address1", 75));
            blockChain.CreateTransaction(new Transaction("Address1", "Address2", 100));
            blockChain.CreateTransaction(new Transaction("Address2", "Address3", 25));
            blockChain.CreateTransaction(new Transaction("Address1", "Address4", 25));


            blockChain.MinePendingTransactions("Address1");

            Console.WriteLine("\nBalance of Address1 is " + blockChain.GetBalanceOfAddress("Address1"));
            Console.WriteLine("\nBalance of Address2 is " + blockChain.GetBalanceOfAddress("Address2"));
            Console.WriteLine("\nBalance of Address3 is " + blockChain.GetBalanceOfAddress("Address3"));
            Console.WriteLine("\nBalance of Address4 is " + blockChain.GetBalanceOfAddress("Address4"));

            Console.ReadKey();
        }
    }
}
