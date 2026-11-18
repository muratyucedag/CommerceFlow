using RestaurantFlow.ConsoleUI.LSPExamples.Interfaces;

namespace RestaurantFlow.ConsoleUI.LSPExamples.Payments
{
    public class CreditCardPayment : IPaymentProcessor
    {
        public string CardHolder { get; set; } = "";
        public decimal AvailableLimit { get; set; }
        
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine("===== KREDİ KARTI ÖDEMESİ =====");

            if (amount <= 0)
            {
                Console.WriteLine("Geçersiz ödeme tutarı.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(CardHolder))
            {
                Console.WriteLine("Kart sahibi bilgisi bulunamadı.");
                return false;
            }

            Console.WriteLine("Kart Sahibi: " + CardHolder);
            Console.WriteLine("Ödeme Tutarı: " + amount + " TL");
            Console.WriteLine("Kullanılabilir Limit: " + AvailableLimit + " TL");

            if (AvailableLimit < amount)
            {
                Console.WriteLine("Kart limiti yetersiz.");
                return false;
            }

            Console.WriteLine("POS işlemi gerçekleştiriliyor.");
            Console.WriteLine("Ödeme onayı kontrol ediliyor.");

            AvailableLimit -= amount;

            Console.WriteLine("Ödeme onaylandı.");
            Console.WriteLine("Kalan Limit: " + AvailableLimit + " TL");

            return true;
        }
    }
}
