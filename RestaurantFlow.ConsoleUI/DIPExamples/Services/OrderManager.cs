
using RestaurantFlow.ConsoleUI.DIPExamples.Interfaces;

namespace RestaurantFlow.ConsoleUI.DIPExamples.Services
{
    public class OrderManager
    {
        private readonly INotificationService _notificationService;
        public int TotalOrders { get; private set; }
        public decimal TotalSales { get; private set; }

        public OrderManager(INotificationService notificationService)
        {
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        }

        public void CreateOrder(int orderId, string customerName, string recipient, string productName, int quantity, decimal unitPrice)
        {
            Console.WriteLine("===== YENİ SİPARİŞ =====");

            if (orderId <= 0 || string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(recipient) || string.IsNullOrWhiteSpace(productName) || quantity <= 0 || unitPrice <= 0)
            {
                Console.WriteLine("Sipariş bilgileri geçersiz.");
                return;
            }

            decimal totalAmount = quantity * unitPrice;

            TotalOrders++;
            TotalSales += totalAmount;

            Console.WriteLine("Sipariş No: " + orderId);
            Console.WriteLine("Müşteri: " + customerName);
            Console.WriteLine("Ürün: " + productName);
            Console.WriteLine("Miktar: " + quantity);
            Console.WriteLine("Birim Fiyat: " + unitPrice + " TL");
            Console.WriteLine("Toplam Tutar: " + totalAmount + " TL");
            Console.WriteLine("Sipariş başarıyla oluşturuldu.");

            Console.WriteLine();

            string message = $"Sayın {customerName}, " + $"{orderId} numaralı siparişiniz alındı. " + $"Toplam tutar: {totalAmount} TL.";
            _notificationService.SendNotification(recipient, message);
        }

        public void ShowOrderSummary()
        {
            Console.WriteLine("===== SİPARİŞ ÖZETİ =====");
            Console.WriteLine("Toplam Sipariş: " + TotalOrders);
            Console.WriteLine("Toplam Satış: " + TotalSales + " TL");
        }
    }
}