
using RestaurantFlow.ConsoleUI.LSPExamples.Interfaces;

namespace RestaurantFlow.ConsoleUI.LSPExamples.BadExamples
{
    public class FakePayment : IPaymentProcessor
    {
        public decimal Balance { get; set; } = 300;
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine("===== HATALI ÖDEME SİSTEMİ =====");

            Console.WriteLine("Mevcut Bakiye: " + Balance + " TL");
            Console.WriteLine("Ödeme Tutarı: " + amount + " TL");

            if (Balance < amount)
            {
                Console.WriteLine("Bakiye yetersiz.");

                // HATALI: Ödeme gerçekleşmediği halde
                // başarılı sonucu döndürülüyor.
                return true;
            }

            Balance -= amount;

            Console.WriteLine("Ödeme tamamlandı.");

            return true;
        }
    }
}
