using RestaurantFlow.ConsoleUI.OCPExamples.Interfaces;

namespace RestaurantFlow.ConsoleUI.OCPExamples.Payments
{
    public class MealCardPayment : IPaymentMethod
    {
        public string CardProvider { get; set; } = "";
        public string CustomerName { get; set; } = "";
        public decimal Balance { get; set; }

        public void Pay(decimal amount)
        {
            Console.WriteLine("===== YEMEK KARTI ÖDEMESİ =====");

            if (amount <= 0)
            {
                Console.WriteLine("Geçersiz ödeme tutarı.");
                return;
            }

            if (string.IsNullOrWhiteSpace(CardProvider))
            {
                Console.WriteLine("Yemek kartı sağlayıcısı belirtilmedi.");
                return;
            }

            Console.WriteLine("Kart Sağlayıcısı: " + CardProvider);
            Console.WriteLine("Müşteri: " + CustomerName);
            Console.WriteLine("Mevcut Bakiye: " + Balance + " TL");
            Console.WriteLine("Ödeme Tutarı: " + amount + " TL");

            if (Balance < amount)
            {
                Console.WriteLine("Yemek kartı bakiyesi yetersiz.");
                Console.WriteLine("Eksik Tutar: " + (amount - Balance) + " TL");
                return;
            }

            Balance -= amount;

            Console.WriteLine("Yemek kartı ödemesi onaylandı.");
            Console.WriteLine("Kalan Bakiye: " + Balance + " TL");
            Console.WriteLine("Ödeme tamamlandı.");
        }
    }
}
