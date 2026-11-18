namespace RestaurantFlow.ConsoleUI.DIPExamples.BadExamples
{
    public class OrderManager
    {
        public int TotalOrders { get; private set; }
        public decimal TotalSales { get; private set; }

        public void CreateOrder(int orderId, string customerName, string phoneNumber, string productName, int quantity, decimal unitPrice)
        {
            Console.WriteLine("===== YENİ SİPARİŞ =====");

            if (orderId <= 0 || string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(productName) || quantity <= 0 || unitPrice <= 0)

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
            Console.WriteLine("Toplam: " + totalAmount + " TL");
            Console.WriteLine("Sipariş oluşturuldu.");

            string message = $"{orderId} numaralı siparişiniz alındı. " + $"Toplam tutar: {totalAmount} TL";

            // Somut SMS sınıfına doğrudan bağımlılık
            SmsService smsService = new SmsService();

            smsService.SendSms(phoneNumber, message);
        }

        public void ShowOrderSummary()
        {
            Console.WriteLine("===== SİPARİŞ ÖZETİ =====");
            Console.WriteLine("Toplam Sipariş: " + TotalOrders);
            Console.WriteLine("Toplam Satış: " + TotalSales + " TL");
        }
    }
}
