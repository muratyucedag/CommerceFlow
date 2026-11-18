
namespace RestaurantFlow.ConsoleUI.Services
{
    public class OrderService
    {
        private int _orderId;
        private string _customerName = "";
        private string _productName = "";
        private int _quantity;
        private decimal _unitPrice;
        private decimal _totalPrice;
        private string _orderStatus = "Sipariş Yok";

        public void CreateOrder(int orderId, string customerName, string productName, int quantity, decimal unitPrice)
        {
            if (orderId <= 0 || string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(productName) || quantity <= 0 || unitPrice <= 0)
            {
                Console.WriteLine("Geçersiz sipariş bilgileri.");
                return;
            }

            _orderId = orderId;
            _customerName = customerName;
            _productName = productName;
            _quantity = quantity;
            _unitPrice = unitPrice;
            _totalPrice = _quantity * _unitPrice;
            _orderStatus = "Hazırlanıyor";

            Console.WriteLine("Yeni sipariş oluşturuldu.");
            Console.WriteLine("Sipariş No: " + _orderId);
            Console.WriteLine("Müşteri: " + _customerName);
            Console.WriteLine("Ürün: " + _productName);
            Console.WriteLine("Adet: " + _quantity);
            Console.WriteLine("Toplam: " + _totalPrice + " TL");
        }
        public decimal CalculateTotalPrice()
        {
            return _totalPrice;
        }

        public void ShowOrderDetails()
        {
            Console.WriteLine("----- SİPARİŞ DETAYLARI -----");
            Console.WriteLine("Sipariş No: " + _orderId);
            Console.WriteLine("Müşteri: " + _customerName);
            Console.WriteLine("Ürün: " + _productName);
            Console.WriteLine("Miktar: " + _quantity);
            Console.WriteLine("Birim Fiyat: " + _unitPrice + " TL");
            Console.WriteLine("Toplam Tutar: " + _totalPrice + " TL");
            Console.WriteLine("Durum: " + _orderStatus);
        }

        public void UpdateOrderStatus(string newStatus)
        {
            _orderStatus = newStatus;
            Console.WriteLine("Sipariş durumu güncellendi.");
            Console.WriteLine("Yeni Durum: " + _orderStatus);
        }

        public void CancelOrder()
        {
            if (_orderStatus == "Teslim Edildi")
            {
                Console.WriteLine("Teslim edilen sipariş iptal edilemez.");
                return;
            }
            _orderStatus = "İptal Edildi";

            Console.WriteLine("Sipariş başarıyla iptal edildi.");
            Console.WriteLine("Sipariş No: " + _orderId);
        }
    }
}