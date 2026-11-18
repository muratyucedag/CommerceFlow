
using RestaurantFlow.ConsoleUI.LSPExamples.Interfaces;

namespace RestaurantFlow.ConsoleUI.LSPExamples.Payments
{
    public class CashPayment : IPaymentProcessor
    {
        public decimal ReceivedAmount { get; set; }
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine("===== NAKİT ÖDEME =====");

            if (amount <= 0)
            {
                Console.WriteLine("Geçersiz ödeme tutarı.");
                return false;
            }

            Console.WriteLine("Ödenecek Tutar: " + amount + " TL");
            Console.WriteLine("Alınan Nakit: " + ReceivedAmount + " TL");

            if (ReceivedAmount < amount)
            {
                Console.WriteLine("Nakit tutarı yetersiz.");
                Console.WriteLine("Eksik Tutar: " + (amount - ReceivedAmount) + " TL");
                return false;
            }

            decimal change = ReceivedAmount - amount;

            ReceivedAmount -= amount;

            Console.WriteLine("Nakit ödeme gerçekleştirildi.");
            Console.WriteLine("Para Üstü: " + change + " TL");
            Console.WriteLine("Ödeme başarıyla tamamlandı.");

            return true;
        }
    }
}
