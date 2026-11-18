namespace RestaurantFlow.ConsoleUI.DIPExamples.BadExamples
{
    public class SmsService
    {
        public void SendSms(string phoneNumber, string message)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                Console.WriteLine("Telefon numarası bulunamadı.");
                return;
            }

            if (string.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine("SMS mesajı boş olamaz.");
                return;
            }

            Console.WriteLine("===== SMS SERVİSİ =====");
            Console.WriteLine("Alıcı: " + phoneNumber);
            Console.WriteLine("Mesaj: " + message);
            Console.WriteLine("SMS bildirimi oluşturuldu.");
        }
    }
}
