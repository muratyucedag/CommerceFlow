using CommerceFlow.Business.Abstract;
using CommerceFlow.DataAccess.Interfaces;
using CommerceFlow.Entities.Entities;

namespace CommerceFlow.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrderManager(IOrderRepository orderRepository, IProductRepository productRepository, ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }

        public void AddOrder(Order order)
        {
            if (order == null)
            {
                Console.WriteLine("Sipariş bilgileri bulunamadı.");
                return;
            }

            if (order.OrderQuantity <= 0)
            {
                Console.WriteLine("Sipariş miktarı sıfırdan büyük olmalıdır.");
                return;
            }

            Customer? customer = _customerRepository.GetById(order.CustomerId);

            if (customer == null)
            {
                Console.WriteLine("Müşteri bulunamadı.");
                return;
            }

            Product? product = _productRepository.GetById(order.ProductId);

            if (product == null)
            {
                Console.WriteLine("Ürün bulunamadı.");
                return;
            }

            if (product.ProductPrice <= 0)
            {
                Console.WriteLine("Ürün fiyatı geçersiz.");
                return;
            }

            if (product.ProductStock < order.OrderQuantity)
            {
                Console.WriteLine("Yetersiz ürün stoğu.");
                Console.WriteLine("Mevcut Stok: " + product.ProductStock);
                return;
            }

            order.OrderTotalPrice = product.ProductPrice * order.OrderQuantity;

            order.OrderDate = DateTime.Now;
            order.OrderStatus = "Hazırlanıyor";

            product.ProductStock -= order.OrderQuantity;

            _orderRepository.Insert(order);
            _productRepository.Update(product);

            Console.WriteLine("Sipariş başarıyla oluşturuldu.");
            Console.WriteLine("Sipariş No: " + order.OrderId);
            Console.WriteLine("Müşteri: " + customer.CustomerName + " " + customer.CustomerSurname);
            Console.WriteLine("Ürün: " + product.ProductName);
            Console.WriteLine("Adet: " + order.OrderQuantity);
            Console.WriteLine("Toplam Tutar: " + order.OrderTotalPrice + " TL");
            Console.WriteLine("Kalan Stok: " + product.ProductStock);
        }

        public void UpdateOrderStatus(int orderId, string status)
        {
            Order? order = _orderRepository.GetById(orderId);

            if (order == null)
            {
                Console.WriteLine("Sipariş bulunamadı.");
                return;
            }

            if (order.OrderStatus == "İptal Edildi")
            {
                Console.WriteLine("İptal edilen sipariş güncellenemez.");
                return;
            }

            if (order.OrderStatus == "Teslim Edildi")
            {
                Console.WriteLine("Teslim edilen sipariş güncellenemez.");
                return;
            }

            if (status != "Kargoda" && status != "Teslim Edildi")
            {
                Console.WriteLine("Geçersiz sipariş durumu.");
                return;
            }

            if (order.OrderStatus == "Hazırlanıyor" && status == "Teslim Edildi")
            {
                Console.WriteLine("Sipariş önce kargoya verilmelidir.");
                return;
            }

            order.OrderStatus = status;

            _orderRepository.Update(order);

            Console.WriteLine("Sipariş durumu güncellendi.");
            Console.WriteLine("Yeni Durum: " + order.OrderStatus);
        }

        public void CancelOrder(int orderId)
        {
            Order? order = _orderRepository.GetById(orderId);

            if (order == null)
            {
                Console.WriteLine("Sipariş bulunamadı.");
                return;
            }

            if (order.OrderStatus == "İptal Edildi")
            {
                Console.WriteLine("Bu sipariş zaten iptal edilmiş.");
                return;
            }

            if (order.OrderStatus != "Hazırlanıyor")
            {
                Console.WriteLine("Yalnızca hazırlanan siparişler iptal edilebilir.");
                return;
            }

            Product? product = _productRepository.GetById(order.ProductId);

            if (product == null)
            {
                Console.WriteLine("Siparişe ait ürün bulunamadı.");
                return;
            }

            product.ProductStock += order.OrderQuantity;

            order.OrderStatus = "İptal Edildi";

            _productRepository.Update(product);
            _orderRepository.Update(order);

            Console.WriteLine("Sipariş iptal edildi.");
            Console.WriteLine("İade Edilen Stok: " + order.OrderQuantity);
            Console.WriteLine("Güncel Stok: " + product.ProductStock);
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        public Order? GetOrderById(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return _orderRepository.GetById(id);
        }
    }
}
