using RestaurantFlow.ConsoleUI.DIPExamples.Interfaces;

namespace RestaurantFlow.ConsoleUI.DIPExamples.Services
{
    public class SmsService : INotificationService
    {
        public string ProviderName { get; set; } = "RestaurantSMS";
        public int SentMessageCount { get; private set; }

        public void SendNotification(string recipient, string message)
        {
            Console.WriteLine("===== SMS BİLDİRİMİ =====");

            if (string.IsNullOrWhiteSpace(recipient))
            {
                Console.WriteLine("Telefon numarası boş olamaz.");
                return;
            }

            if (string.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine("Mesaj içeriği boş olamaz.");
                return;
            }

            Console.WriteLine("SMS Sağlayıcısı: " + ProviderName);
            Console.WriteLine("Telefon Numarası: " + recipient);
            Console.WriteLine("Mesaj: " + message);

            Console.WriteLine("SMS servisine bağlanılıyor...");
            Console.WriteLine("Mesaj gönderimi simüle edildi.");

            SentMessageCount++;

            Console.WriteLine("Gönderim Sayısı: " + SentMessageCount);
        }
    }
}
