namespace RestaurantFlow.ConsoleUI.Services
{
    public class NotificationService
    {
        public void SendSms(string phoneNumber, string message)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine("SMS bilgileri eksik.");
                return;
            }

            Console.WriteLine("----- SMS BİLDİRİMİ -----");
            Console.WriteLine("Telefon: " + phoneNumber);
            Console.WriteLine("Mesaj: " + message);
            Console.WriteLine("SMS bildirimi oluşturuldu.");
        }

        public void SendEmail(string emailAddress, string subject, string message)
        {
            if (string.IsNullOrWhiteSpace(emailAddress) || string.IsNullOrWhiteSpace(subject) || string.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine("E-posta bilgileri eksik.");
                return;
            }

            Console.WriteLine("----- E-POSTA BİLDİRİMİ -----");
            Console.WriteLine("Alıcı: " + emailAddress);
            Console.WriteLine("Konu: " + subject);
            Console.WriteLine("İçerik: " + message);
            Console.WriteLine("E-posta bildirimi oluşturuldu.");
        }

        public void SendOrderStatusNotification(string customerName, int orderId, string orderStatus)
        {
            Console.WriteLine("----- SİPARİŞ BİLDİRİMİ -----");

            Console.WriteLine("Sayın " + customerName + ",");
            Console.WriteLine(orderId + " numaralı siparişinizin durumu güncellendi.");
            Console.WriteLine("Yeni Durum: " + orderStatus);
            Console.WriteLine("Sipariş bildirimi hazırlandı.");
        }

        public void SendPaymentNotification(string customerName, decimal amount)
        {
            Console.WriteLine("----- ÖDEME BİLDİRİMİ -----");
            Console.WriteLine("Sayın " + customerName + ",");
            Console.WriteLine(amount + " TL tutarındaki ödemeniz tamamlandı.");
            Console.WriteLine("RestaurantFlow'u tercih ettiğiniz için teşekkür ederiz.");
        }
    }
}