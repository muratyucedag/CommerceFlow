using LogisticsApp.ConsoleUI.Interfaces;

namespace LogisticsApp.ConsoleUI.Services
{
    public class NationalCargo : IShippingService,INotificationService
    {
        public string CompanyName { get; set; } = "NationalCargo";
        public string TrackingNumber { get; set; } = "";
        public string ShipmentStatus { get; set; } = "Henüz oluşturulmadı";

        public string SenderCity { get; set; } = "";
        public string ReceiverCity { get; set; } = "";
        public string TransferCenter { get; set; } = "";



        public void CancelShipment()
        {
            if (ShipmentStatus == "Aktarma merkezine hazırlanıyor")
            {
                ShipmentStatus = "İptal edildi";
                Console.WriteLine("Gönderi iptal edildi.");
            }
            else
            {
                Console.WriteLine("Gönderi bu aşamada iptal edilemiyor.");
            }
        }

        public void CreateShipment()
        {
            TrackingNumber = "NC2001";
            ShipmentStatus = "Aktarma merkezine hazırlanıyor";

            Console.WriteLine("Kargo Firması: " + CompanyName);
            Console.WriteLine("Takip Numarası: " + TrackingNumber);
            Console.WriteLine("Gönderici Şehir: " + SenderCity);
            Console.WriteLine("Alıcı Şehir: " + ReceiverCity);
            Console.WriteLine("Şehirler arası gönderi oluşturuldu.");
        }

        public void TrackShipment()
        {
            Console.WriteLine("Takip Numarası: " + TrackingNumber);
            Console.WriteLine("Gönderi Durumu: " + ShipmentStatus);
            Console.WriteLine("Aktarma Merkezi: " + TransferCenter);
        }

        // NationalCargo sınıfına özgü metot
        public void SendToTransferCenter()
        {
            ShipmentStatus = "Aktarma merkezinde";
            Console.WriteLine("Gönderi " + TransferCenter + " aktarma merkezine ulaştı.");
        }

        public void SendSms(string phoneNumber)
        {
            Console.WriteLine("NationalCargo SMS Bildirimi");
            Console.WriteLine("Telefon: " + phoneNumber);
            Console.WriteLine("Kargonuz aktarma merkezine hazırlanıyor.");
        }

        public void SendEmail(string emailAddress)
        {
            Console.WriteLine("NationalCargo E-Posta Bildirimi");
            Console.WriteLine("E-Posta: " + emailAddress);
            Console.WriteLine("Gönderinizin takip bilgileri hazırlandı.");
        }
    }
}