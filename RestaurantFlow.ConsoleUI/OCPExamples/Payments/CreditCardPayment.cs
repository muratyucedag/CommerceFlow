using RestaurantFlow.ConsoleUI.OCPExamples.Interfaces;

namespace RestaurantFlow.ConsoleUI.OCPExamples.Payments
{
    public class CreditCardPayment : IPaymentMethod
    {
        public string CardHolderName { get; set; } = "";
        public string CardNumber { get; set; } = "";
        public decimal CardLimit { get; set; }

        public void Pay(decimal amount)
        {
            Console.WriteLine("===== KREDİ KARTI ÖDEMESİ =====");

            if (amount <= 0)
            {
                Console.WriteLine("Geçersiz ödeme tutarı.");
                return;
            }

            if (string.IsNullOrWhiteSpace(CardHolderName))
            {
                Console.WriteLine("Kart sahibi bilgisi eksik.");
                return;
            }

            if (string.IsNullOrWhiteSpace(CardNumber))
            {
                Console.WriteLine("Kart numarası girilmedi.");
                return;
            }

            Console.WriteLine("Kart Sahibi: " + CardHolderName);
            Console.WriteLine("Ödeme Tutarı: " + amount + " TL");

            if (CardLimit < amount)
            {
                Console.WriteLine("Kart limiti yetersiz.");
                Console.WriteLine("Kullanılabilir Limit: " + CardLimit + " TL");
                return;
            }

            Console.WriteLine("POS cihazına bağlanılıyor...");
            Console.WriteLine("Banka onayı kontrol ediliyor...");

            CardLimit -= amount;

            Console.WriteLine("Banka işlemi onaylandı.");
            Console.WriteLine("Kalan Limit: " + CardLimit + " TL");
            Console.WriteLine("Kredi kartı ödemesi tamamlandı.");
        }
    }
}
