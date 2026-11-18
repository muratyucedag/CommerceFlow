
using RestaurantFlow.ConsoleUI.OCPExamples.Interfaces;

namespace RestaurantFlow.ConsoleUI.OCPExamples.Payments
{
    public class CashPayment : IPaymentMethod
    {
        public decimal ReceivedAmount { get; set; }
        public void Pay(decimal amount)
        {
            Console.WriteLine("===== NAKİT ÖDEME =====");

            if (amount <= 0)
            {
                Console.WriteLine("Geçersiz ödeme tutarı.");
                return;
            }

            Console.WriteLine("Ödenecek Tutar: " + amount + " TL");
            Console.WriteLine("Alınan Nakit: " + ReceivedAmount + " TL");

            if (ReceivedAmount < amount)
            {
                decimal missingAmount = amount - ReceivedAmount;

                Console.WriteLine("Ödeme için yeterli nakit bulunmuyor.");
                Console.WriteLine("Eksik Tutar: " + missingAmount + " TL");
                return;
            }

            decimal change = ReceivedAmount - amount;

            Console.WriteLine("Nakit ödeme kabul edildi.");
            Console.WriteLine("Para Üstü: " + change + " TL");
            Console.WriteLine("Ödeme tamamlandı.");
        }
    }
}
