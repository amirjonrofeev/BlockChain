namespace BlockChains.Data
{
    public class Transaction
    {
        public int Amount { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }

        public Transaction(string fromAddress, string toAdress, int amount)
        {
            FromAddress = fromAddress;
            ToAddress = toAdress;
            Amount = amount;
        }
    }
}
