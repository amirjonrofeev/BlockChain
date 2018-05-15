namespace BlockChains
{
    public class Transaction
    {
        public double Amount { get; set; }
        public string FromUser { get; set; }
        public string ToUser { get; set; }

        public Transaction(User fromUser, User toUser, double amount)
        {
            FromUser = fromUser == null ? " " : fromUser.Name;
            ToUser = toUser.Name;
            Amount = amount;
        }
    }
}
