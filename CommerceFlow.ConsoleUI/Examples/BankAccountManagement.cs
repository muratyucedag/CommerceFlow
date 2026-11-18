
namespace CommerceFlow.ConsoleUI.Examples
{
    public class BankAccountManagement
    {
        private decimal _balance;
        private bool _isActive;
        public string AccountOwner { get; private set; }
        public decimal Balance
        {
            get { return _balance; }
        }
        public bool IsActive
        {
            get { return _isActive; }
        }
        public BankAccountManagement(string accountOwner, decimal balance)
        {
            if (string.IsNullOrWhiteSpace(accountOwner))
                throw new ArgumentException("Hesap sahibi boş olamaz.");

            if (balance < 0)
                throw new ArgumentException("Başlangıç bakiyesi negatif olamaz.");

            AccountOwner = accountOwner;
            _balance = balance;
            _isActive = true;
        }

        public void Deposit(decimal amount)
        {
            if (!_isActive)
            {
                Console.WriteLine("Hesap kapalı. İşlem yapılamaz.");
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Yatırılacak tutar sıfırdan büyük olmalıdır.");
                return;
            }

            _balance += amount;

            Console.WriteLine($"Para yatırıldı. Güncel bakiye: {_balance} TL");
        }

        public void Withdraw(decimal amount)
        {
            if (!_isActive)
            {
                Console.WriteLine("Hesap kapalı. İşlem yapılamaz.");
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Çekilecek tutar sıfırdan büyük olmalıdır.");
                return;
            }

            if (amount > _balance)
            {
                Console.WriteLine("Yetersiz bakiye.");
                return;
            }

            _balance -= amount;

            Console.WriteLine($"Para çekildi. Güncel bakiye: {_balance} TL");
        }

        public void CloseAccount()
        {
            _isActive = false;
            Console.WriteLine("Banka hesabı kapatıldı.");
        }

        public void ShowAccountInformation()
        {
            Console.WriteLine($"Hesap Sahibi: {AccountOwner}");
            Console.WriteLine($"Bakiye: {_balance} TL");
            Console.WriteLine($"Hesap Durumu: {(_isActive ? "Aktif" : "Pasif")}");
        }
    }
}
