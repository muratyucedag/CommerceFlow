namespace RestaurantFlow.ConsoleUI.Services
{
    public class PaymentService
    {
        private decimal _lastPaymentAmount;
        private string _paymentMethod = "";
        private bool _isPaymentCompleted;

        public decimal CalculateDiscount(decimal amount, decimal discountRate)
        {
            if (amount <= 0 || discountRate < 0 || discountRate > 100)
            {
                Console.WriteLine("Geçersiz indirim bilgileri.");
                return 0;
            }

            decimal discountAmount = amount * discountRate / 100;
            Console.WriteLine("İndirim Oranı: %" + discountRate);
            Console.WriteLine("İndirim Tutarı: " + discountAmount + " TL");
            return amount - discountAmount;
        }

        public void ProcessPayment(decimal amount, string paymentMethod)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Ödeme tutarı sıfırdan büyük olmalıdır.");
                return;
            }

            if (string.IsNullOrWhiteSpace(paymentMethod))
            {
                Console.WriteLine("Ödeme yöntemi seçilmelidir.");
                return;
            }

            _lastPaymentAmount = amount;
            _paymentMethod = paymentMethod;
            _isPaymentCompleted = true;

            Console.WriteLine("Ödeme işlemi başlatıldı.");
            Console.WriteLine("Ödeme Yöntemi: " + _paymentMethod);
            Console.WriteLine("Ödenecek Tutar: " + amount + " TL");
            Console.WriteLine("Ödeme başarıyla tamamlandı.");
        }

        public void ShowPaymentInformation()
        {
            Console.WriteLine("----- ÖDEME BİLGİLERİ -----");

            if (!_isPaymentCompleted)
            {
                Console.WriteLine("Tamamlanan ödeme bulunmuyor.");
                return;
            }

            Console.WriteLine("Ödeme Yöntemi: " + _paymentMethod);
            Console.WriteLine("Ödenen Tutar: " + _lastPaymentAmount + " TL");
            Console.WriteLine("Durum: Ödeme Tamamlandı");
        }

        public void RefundPayment()
        {
            if (!_isPaymentCompleted)
            {
                Console.WriteLine("İade edilecek ödeme bulunamadı.");
                return;
            }

            Console.WriteLine("İade işlemi başlatıldı.");
            Console.WriteLine("İade Tutarı: " + _lastPaymentAmount + " TL");
            _isPaymentCompleted = false;
            Console.WriteLine("Ödeme iadesi tamamlandı.");
        }
    }
}