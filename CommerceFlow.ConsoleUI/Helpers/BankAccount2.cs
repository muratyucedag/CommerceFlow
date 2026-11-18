
namespace CommerceFlow.ConsoleUI.Helpers
{
    public class BankAccount2
    {
        public string AccountOwner { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }

        public BankAccount2(string owner, string type, decimal balance)
        {
            AccountOwner = owner;
            AccountType = type;
            Balance = balance;
            IsActive = true;
        }
    }
}
