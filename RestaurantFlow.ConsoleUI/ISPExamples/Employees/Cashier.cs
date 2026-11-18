
using RestaurantFlow.ConsoleUI.ISPExamples.Interfaces;

namespace RestaurantFlow.ConsoleUI.ISPExamples.Employees
{
    public class Cashier : IPaymentService
    {
        public string FullName { get; set; } = "";
        public decimal TotalRevenue { get; private set; }
        public int CompletedPaymentCount { get; private set; }

        private bool _hasUnreceiptedPayment;
        private decimal _lastPaidAmount;

        public void PrintReceipt(int orderId, decimal amount)
        {
            Console.WriteLine("===== ÖDEME FİŞİ =====");

            if (!_hasUnreceiptedPayment)
            {
                Console.WriteLine("Fiş oluşturulacak ödeme bulunamadı.");
                return;
            }

            if (orderId <= 0 || amount != _lastPaidAmount)
            {
                Console.WriteLine("Fiş bilgileri ödeme ile uyuşmuyor.");
                return;
            }

            Console.WriteLine("RestaurantFlow");
            Console.WriteLine("Sipariş No: " + orderId);
            Console.WriteLine("Kasiyer: " + FullName);
            Console.WriteLine("Ödenen Tutar: " + amount + " TL");
            Console.WriteLine("Ödeme Durumu: Başarılı");
            Console.WriteLine("Fiş oluşturuldu.");

            _hasUnreceiptedPayment = false;
        }

        public bool ProcessPayment(decimal amount, decimal receivedAmount)
        {
            Console.WriteLine("===== ÖDEME İŞLEMİ =====");

            if (amount <= 0)
            {
                Console.WriteLine("Ödeme tutarı geçersiz.");
                return false;
            }

            if (receivedAmount < amount)
            {
                Console.WriteLine("Alınan tutar yetersiz.");
                Console.WriteLine("Eksik Tutar: " + (amount - receivedAmount) + " TL");
                return false;
            }

            if (_hasUnreceiptedPayment)
            {
                Console.WriteLine("Önce önceki ödemenin fişini oluşturun.");
                return false;
            }

            decimal change = receivedAmount - amount;

            TotalRevenue += amount;
            CompletedPaymentCount++;
            _lastPaidAmount = amount;
            _hasUnreceiptedPayment = true;

            Console.WriteLine("Kasiyer: " + FullName);
            Console.WriteLine("Ödeme Tutarı: " + amount + " TL");
            Console.WriteLine("Alınan Tutar: " + receivedAmount + " TL");
            Console.WriteLine("Para Üstü: " + change + " TL");
            Console.WriteLine("Ödeme başarıyla tamamlandı.");

            return true;
        }

        public void ShowDailyRevenue()
        {
            Console.WriteLine("===== KASA ÖZETİ =====");
            Console.WriteLine("Kasiyer: " + FullName);
            Console.WriteLine("Tamamlanan Ödeme: " + CompletedPaymentCount);
            Console.WriteLine("Toplam Tahsilat: " + TotalRevenue + " TL");
        }
    }
}
