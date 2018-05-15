using System;

namespace BlockChains
{
    public class Program
    {
        internal static void Main()
        {
            BlockChain blockChain = new BlockChain();

            User user1 = new User("User1");
            User user2 = new User("User2");

            //История транзакций
            blockChain.BuyCoins(user1, 200);
            blockChain.BuyCoins(user2, 300);
            blockChain.CreateTransaction(new Transaction(user2, user1, 150));

            /* После майнинг - создается блок и вся previous история транзакций хранится в блоке.
            Временная история транзакций в блокчейне очищается. В качестве MinePendingTransactions - указывается user который майнит.
            Если это например какая нибудь глобальная сеть, то например то кто находит свободный хеш получает деньги в размере 150 у.е.
            */
            blockChain.MinePendingTransactions(user1);

            Console.WriteLine("\nBalance of User1 is " + blockChain.GetBalanceOfAddress(user1));
            Console.WriteLine("\nBalance of User2 is " + blockChain.GetBalanceOfAddress(user2));


            Console.WriteLine(new string('-', 50));

            //История транзакций
            blockChain.PendingTransactions.Add(new Transaction(user1, user2, 100));
            blockChain.MinePendingTransactions(user2);

            Console.WriteLine("\nBalance of User1 is " + blockChain.GetBalanceOfAddress(user1));
            Console.WriteLine("\nBalance of User2 is " + blockChain.GetBalanceOfAddress(user2));

            Console.ReadKey();
        }
    }
}
