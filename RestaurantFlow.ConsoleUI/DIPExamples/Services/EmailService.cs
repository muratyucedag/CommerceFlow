using RestaurantFlow.ConsoleUI.DIPExamples.Interfaces;

namespace RestaurantFlow.ConsoleUI.DIPExamples.Services
{
    public class EmailService : INotificationService
    {
        public string SenderEmail { get; set; } = "info@restaurantflow.com";
        public string EmailSubject { get; set; } = "RestaurantFlow Sipariş Bilgilendirmesi";
        public int SentEmailCount { get; private set; }

        public void SendNotification(string recipient, string message)
        {
            Console.WriteLine("===== E-POSTA BİLDİRİMİ =====");

            if (string.IsNullOrWhiteSpace(recipient) || !recipient.Contains("@"))
            {
                Console.WriteLine("E-posta adresi geçersiz.");
                return;
            }

            if (string.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine("E-posta içeriği boş olamaz.");
                return;
            }

            Console.WriteLine("Gönderen: " + SenderEmail);
            Console.WriteLine("Alıcı: " + recipient);
            Console.WriteLine("Konu: " + EmailSubject);
            Console.WriteLine("Mesaj: " + message);

            Console.WriteLine("E-posta sunucusuna bağlanılıyor...");
            Console.WriteLine("E-posta gönderimi simüle edildi.");

            SentEmailCount++;

            Console.WriteLine("Gönderilen E-Posta: " + SentEmailCount);
        }
    }
}
