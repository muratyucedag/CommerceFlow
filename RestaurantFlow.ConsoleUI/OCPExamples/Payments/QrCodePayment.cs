
using RestaurantFlow.ConsoleUI.OCPExamples.Interfaces;

namespace RestaurantFlow.ConsoleUI.OCPExamples.Payments
{
    public class QrCodePayment : IPaymentMethod
    {
        public string CustomerName { get; set; } = "";
        public string BankName { get; set; } = "";
        public decimal AccountBalance { get; set; }
        public bool IsQrScanned { get; set; }
        public bool IsPaymentApproved { get; private set; }

        public void Pay(decimal amount)
        {
            Console.WriteLine("===== QR KOD İLE ÖDEME =====");

            if (amount <= 0)
            {
                Console.WriteLine("Geçersiz ödeme tutarı.");
                return;
            }

            if (string.IsNullOrWhiteSpace(CustomerName))
            {
                Console.WriteLine("Müşteri bilgisi bulunamadı.");
                return;
            }

            if (string.IsNullOrWhiteSpace(BankName))
            {
                Console.WriteLine("Banka seçilmedi.");
                return;
            }

            Console.WriteLine("Müşteri: " + CustomerName);
            Console.WriteLine("Banka: " + BankName);
            Console.WriteLine("Ödeme Tutarı: " + amount + " TL");

            Console.WriteLine("QR kod hazırlanıyor...");
            Console.WriteLine("QR kod ödeme ekranında gösterildi.");

            if (!IsQrScanned)
            {
                Console.WriteLine("Müşteri QR kodu henüz okutmadı.");
                return;
            }

            Console.WriteLine("QR kod başarıyla okutuldu.");
            Console.WriteLine("Mobil bankacılık uygulaması kontrol ediliyor.");

            if (AccountBalance < amount)
            {
                Console.WriteLine("Hesap bakiyesi yetersiz.");
                Console.WriteLine("Eksik Tutar: " + (amount - AccountBalance) + " TL");
                return;
            }

            Console.WriteLine("Hesap bakiyesi yeterli.");

            AccountBalance -= amount;

            IsPaymentApproved = true;

            Console.WriteLine("Banka ödeme onayı alındı.");
            Console.WriteLine("İşlem tamamlandı.");
            Console.WriteLine("Kalan Bakiye: " + AccountBalance + " TL");
        }

        public void ShowPaymentStatus()
        {
            Console.WriteLine("===== QR ÖDEME DURUMU =====");
            Console.WriteLine("Müşteri: " + CustomerName);
            Console.WriteLine("Banka: " + BankName);

            if (IsPaymentApproved)
            {
                Console.WriteLine("Ödeme Durumu: Onaylandı");
            }
            else
            {
                Console.WriteLine("Ödeme Durumu: Onaylanmadı");
            }
        }

        public void ResetPayment()
        {
            IsQrScanned = false;
            IsPaymentApproved = false;
            Console.WriteLine("QR ödeme durumu sıfırlandı.");
        }

    }
}
