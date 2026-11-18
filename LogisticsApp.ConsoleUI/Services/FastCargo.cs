
using LogisticsApp.ConsoleUI.Interfaces;

namespace LogisticsApp.ConsoleUI.Services
{
    public class FastCargo : IShippingService
    {
        public string CompanyName { get; set; } = "FastCargo";
        public string TrackingNumber { get; set; } = "";
        public string ShipmentStatus { get; set; } = "Henüz oluşturulmadı";

        public void CreateShipment()
        {
            TrackingNumber = "FC1001";
            ShipmentStatus = "Gönderi oluşturuldu";

            Console.WriteLine("Kargo Firması: " + CompanyName);
            Console.WriteLine("Takip Numarası: " + TrackingNumber);
            Console.WriteLine("Yeni gönderi oluşturuldu.");
        }

        public void TrackShipment()
        {
            Console.WriteLine("Takip Numarası: " + TrackingNumber);
            Console.WriteLine("Gönderi Durumu: " + ShipmentStatus);
        }

        public void CancelShipment()
        {
            ShipmentStatus = "İptal edildi";
            Console.WriteLine("Gönderi iptal edildi.");
        }
    }
}
