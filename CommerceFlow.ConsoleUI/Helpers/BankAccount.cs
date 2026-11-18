
namespace CommerceFlow.ConsoleUI.Helpers
{
    public class BankAccount
    {
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
        public BankAccount()
        {
            AccountType = "Vadesiz";
            Balance = 0;
            IsActive = true;
        }
    }
}
