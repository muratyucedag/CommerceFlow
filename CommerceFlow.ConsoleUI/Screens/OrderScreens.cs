using CommerceFlow.Business.Abstract;
using CommerceFlow.ConsoleUI.Helpers;
using CommerceFlow.Entities.Entities;

namespace CommerceFlow.ConsoleUI.Screens
{
    public class OrderScreens
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        public OrderScreens(IOrderService orderService, IProductService productService, ICustomerService customerService)
        {
            _orderService = orderService;
            _productService = productService;
            _customerService = customerService;
        }

        public void ShowOrders()
        {
            ConsoleRestaurantDesign.WriteHeader("Sipariş Listesi");

            List<Order> orders = _orderService.GetAllOrders();

            if (orders.Count == 0)
            {
                ConsoleRestaurantDesign.WriteInfo("Kayıtlı sipariş bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"  {"ID",-6} {"MÜŞTERİ",-9} {"ÜRÜN",-7} {"ADET",-7} {"TOPLAM",-15} {"TARİH",-13} {"DURUM",-18}");
            Console.WriteLine(new string('-', 95));
            Console.ResetColor();

            foreach (Order order in orders)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"  {order.OrderId,-6}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{order.CustomerId,-9}");
                Console.Write($"{order.ProductId,-7}");
                Console.Write($"{order.OrderQuantity,-7}");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{order.OrderTotalPrice,-15:N2}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{order.OrderDate,-13:dd.MM.yyyy}");

                Console.ForegroundColor = order.OrderStatus switch
                {
                    "Teslim Edildi" => ConsoleColor.Green,
                    "Kargoda" => ConsoleColor.Cyan,
                    "İptal Edildi" => ConsoleColor.Red,
                    _ => ConsoleColor.Yellow
                };

                Console.WriteLine($"{order.OrderStatus,-18}");
            }

            Console.ResetColor();
            Console.WriteLine(new string('-', 95));
            Console.WriteLine();

            ConsoleRestaurantDesign.WriteSuccess($"Toplam {orders.Count} sipariş listelendi.");
            ConsoleRestaurantDesign.WaitForKey();
        }
        public void AddOrder()
        {
            ConsoleRestaurantDesign.WriteHeader("Yeni Sipariş Oluştur");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Müşteri ID      : ");
            Console.ResetColor();

            string? customerInput = Console.ReadLine();

            if (!int.TryParse(customerInput, out int customerId) || customerId <= 0)
            {
                ConsoleRestaurantDesign.WriteError("Geçerli bir müşteri ID değeri giriniz.");

                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Customer? customer = _customerService.GetCustomerById(customerId);

            if (customer == null)
            {
                ConsoleRestaurantDesign.WriteError("Belirtilen müşteri bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            ConsoleRestaurantDesign.WriteSuccess($"Müşteri: {customer.CustomerName} {customer.CustomerSurname}");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Ürün ID         : ");
            Console.ResetColor();

            string? productInput = Console.ReadLine();

            if (!int.TryParse(productInput, out int productId) || productId <= 0)
            {
                ConsoleRestaurantDesign.WriteError("Geçerli bir ürün ID değeri giriniz.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Product? product = _productService.GetProductById(productId);

            if (product == null)
            {
                ConsoleRestaurantDesign.WriteError("Belirtilen ürün bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            ConsoleRestaurantDesign.WriteSuccess($"Ürün: {product.ProductName}");
            ConsoleRestaurantDesign.WriteInfo($"Birim Fiyat: {product.ProductPrice:N2} TL");
            ConsoleRestaurantDesign.WriteInfo($"Mevcut Stok: {product.ProductStock}");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Sipariş Adedi   : ");
            Console.ResetColor();

            string? quantityInput = Console.ReadLine();

            if (!int.TryParse(quantityInput, out int quantity) || quantity <= 0)
            {
                ConsoleRestaurantDesign.WriteError("Sipariş adedi sıfırdan büyük olmalıdır.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            if (quantity > product.ProductStock)
            {
                ConsoleRestaurantDesign.WriteError("Sipariş adedi mevcut stok miktarını aşamaz.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            decimal totalPrice = product.ProductPrice * quantity;

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  -----------------------------------------------");
            Console.WriteLine("                 SİPARİŞ ÖZETİ");
            Console.WriteLine("  -----------------------------------------------");
            Console.ResetColor();

            Console.WriteLine($"  Müşteri       : {customer.CustomerName} {customer.CustomerSurname}");
            Console.WriteLine($"  Ürün          : {product.ProductName}");
            Console.WriteLine($"  Birim Fiyat   : {product.ProductPrice:N2} TL");
            Console.WriteLine($"  Sipariş Adedi : {quantity}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  Toplam Tutar  : {totalPrice:N2} TL");
            Console.ResetColor();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Siparişi oluşturmak istiyor musunuz? (E/H): ");
            Console.ResetColor();

            string? confirmation = Console.ReadLine();

            if (!string.Equals(confirmation?.Trim(), "E", StringComparison.OrdinalIgnoreCase))
            {
                ConsoleRestaurantDesign.WriteInfo("Sipariş oluşturma işlemi iptal edildi.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Order order = new Order
            {
                CustomerId = customerId,
                ProductId = productId,
                OrderQuantity = quantity
            };

            _orderService.AddOrder(order);

            ConsoleRestaurantDesign.WaitForKey();
        }
        public void ShowOrderDetail()
        {
            ConsoleRestaurantDesign.WriteHeader("Sipariş Detayı");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Sipariş ID: ");
            Console.ResetColor();

            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int orderId) || orderId <= 0)
            {
                ConsoleRestaurantDesign.WriteError("Geçerli bir sipariş ID değeri giriniz.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Order? order = _orderService.GetOrderById(orderId);

            if (order == null)
            {
                ConsoleRestaurantDesign.WriteError("Belirtilen ID değerine ait sipariş bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Customer? customer = _customerService.GetCustomerById(order.CustomerId);
            Product? product = _productService.GetProductById(order.ProductId);

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  ------------------------------------------------");
            Console.WriteLine("                  SİPARİŞ BİLGİLERİ");
            Console.WriteLine("  ------------------------------------------------");
            Console.ResetColor();

            Console.WriteLine($"  Sipariş ID     : {order.OrderId}");
            Console.WriteLine($"  Sipariş Tarihi : {order.OrderDate:dd.MM.yyyy HH:mm}");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Sipariş Durumu : ");

            Console.ForegroundColor = order.OrderStatus switch
            {
                "Teslim Edildi" => ConsoleColor.Green,
                "Kargoda" => ConsoleColor.Cyan,
                "İptal Edildi" => ConsoleColor.Red,
                _ => ConsoleColor.Yellow
            };

            Console.WriteLine(order.OrderStatus);
            Console.ResetColor();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  ---------------- MÜŞTERİ ----------------");
            Console.ResetColor();

            Console.WriteLine($"  Müşteri ID : {order.CustomerId}");

            if (customer != null)
            {
                Console.WriteLine($"  Ad Soyad   : {customer.CustomerName} {customer.CustomerSurname}");
                Console.WriteLine($"  E-Posta    : {customer.CustomerEmail}");
                Console.WriteLine($"  Telefon    : {customer.CustomerPhone}");
                Console.WriteLine($"  Şehir      : {customer.City}");
            }
            else
            {
                ConsoleRestaurantDesign.WriteError("Müşteri bilgileri bulunamadı.");
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  ----------------- ÜRÜN ------------------");
            Console.ResetColor();

            Console.WriteLine($"  Ürün ID       : {order.ProductId}");

            if (product != null)
            {
                Console.WriteLine($"  Ürün Adı      : {product.ProductName}");
                Console.WriteLine($"  Güncel Fiyat  : {product.ProductPrice:N2} TL");
            }
            else
            {
                ConsoleRestaurantDesign.WriteError("Ürün bilgileri bulunamadı.");
            }

            Console.WriteLine($"  Sipariş Adedi : {order.OrderQuantity}");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  Sipariş Toplamı : {order.OrderTotalPrice:N2} TL");
            Console.ResetColor();
            Console.WriteLine();

            ConsoleRestaurantDesign.WriteSuccess("Sipariş bilgileri başarıyla getirildi.");

            ConsoleRestaurantDesign.WaitForKey();
        }
        public void UpdateOrderStatus()
        {
            ConsoleRestaurantDesign.WriteHeader("Sipariş Durumunu Güncelle");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Güncellenecek Sipariş ID: ");
            Console.ResetColor();

            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int orderId) || orderId <= 0)
            {
                ConsoleRestaurantDesign.WriteError("Geçerli bir sipariş ID değeri giriniz.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Order? order = _orderService.GetOrderById(orderId);

            if (order == null)
            {
                ConsoleRestaurantDesign.WriteError("Belirtilen sipariş bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  ---------------------------------------------");
            Console.WriteLine("                SİPARİŞ BİLGİLERİ");
            Console.WriteLine("  ---------------------------------------------");
            Console.ResetColor();

            Console.WriteLine($"  Sipariş ID     : {order.OrderId}");
            Console.WriteLine($"  Müşteri ID     : {order.CustomerId}");
            Console.WriteLine($"  Ürün ID        : {order.ProductId}");
            Console.WriteLine($"  Sipariş Adedi  : {order.OrderQuantity}");
            Console.WriteLine($"  Toplam Tutar   : {order.OrderTotalPrice:N2} TL");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Mevcut Durum   : ");

            Console.ForegroundColor = order.OrderStatus switch
            {
                "Hazırlanıyor" => ConsoleColor.Yellow,
                "Kargoda" => ConsoleColor.Cyan,
                "Teslim Edildi" => ConsoleColor.Green,
                "İptal Edildi" => ConsoleColor.Red,
                _ => ConsoleColor.White
            };

            Console.WriteLine(order.OrderStatus);
            Console.ResetColor();

            Console.WriteLine();

            if (order.OrderStatus == "Teslim Edildi")
            {
                ConsoleRestaurantDesign.WriteInfo("Bu sipariş teslim edilmiştir. Durumu değiştirilemez.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            if (order.OrderStatus == "İptal Edildi")
            {
                ConsoleRestaurantDesign.WriteError("İptal edilmiş siparişin durumu değiştirilemez.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            string newStatus;

            if (order.OrderStatus == "Hazırlanıyor")
            {
                newStatus = "Kargoda";
            }
            else if (order.OrderStatus == "Kargoda")
            {
                newStatus = "Teslim Edildi";
            }
            else
            {
                ConsoleRestaurantDesign.WriteError("Sipariş durumu güncellemeye uygun değil.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            ConsoleRestaurantDesign.WriteInfo($"Yeni Sipariş Durumu: {newStatus}");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Durum değişikliğini onaylıyor musunuz? (E/H): ");
            Console.ResetColor();

            string? confirmation = Console.ReadLine();

            if (!string.Equals(confirmation?.Trim(), "E", StringComparison.OrdinalIgnoreCase))
            {
                ConsoleRestaurantDesign.WriteInfo("Sipariş durumu güncelleme işlemi iptal edildi.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            _orderService.UpdateOrderStatus(orderId, newStatus);

            ConsoleRestaurantDesign.WaitForKey();
        }
        public void CancelOrder()
        {
            ConsoleRestaurantDesign.WriteHeader("Sipariş İptal Etme");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  İptal Edilecek Sipariş ID: ");
            Console.ResetColor();

            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int orderId) || orderId <= 0)
            {
                ConsoleRestaurantDesign.WriteError("Geçerli bir sipariş ID değeri giriniz.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Order? order = _orderService.GetOrderById(orderId);

            if (order == null)
            {
                ConsoleRestaurantDesign.WriteError("Belirtilen sipariş bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Customer? customer = _customerService.GetCustomerById(order.CustomerId);
            Product? product = _productService.GetProductById(order.ProductId);

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  ---------------------------------------------");
            Console.WriteLine("             İPTAL EDİLECEK SİPARİŞ");
            Console.WriteLine("  ---------------------------------------------");
            Console.ResetColor();

            Console.WriteLine($"  Sipariş ID     : {order.OrderId}");
            Console.WriteLine($"  Sipariş Tarihi : {order.OrderDate:dd.MM.yyyy HH:mm}");

            Console.WriteLine($"  Müşteri        : {customer?.CustomerName} {customer?.CustomerSurname}");
            Console.WriteLine($"  Ürün           : {product?.ProductName ?? "Ürün bulunamadı"}");
            Console.WriteLine($"  Sipariş Adedi  : {order.OrderQuantity}");
            Console.WriteLine($"  Toplam Tutar   : {order.OrderTotalPrice:N2} TL");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Sipariş Durumu : ");

            Console.ForegroundColor = order.OrderStatus switch
            {
                "Hazırlanıyor" => ConsoleColor.Yellow,
                "Kargoda" => ConsoleColor.Cyan,
                "Teslim Edildi" => ConsoleColor.Green,
                "İptal Edildi" => ConsoleColor.Red,
                _ => ConsoleColor.White
            };

            Console.WriteLine(order.OrderStatus);
            Console.ResetColor();

            Console.WriteLine();

            if (order.OrderStatus != "Hazırlanıyor")
            {
                ConsoleRestaurantDesign.WriteError("Yalnızca hazırlanıyor durumundaki siparişler iptal edilebilir.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            if (product == null)
            {
                ConsoleRestaurantDesign.WriteError("Siparişe ait ürün bulunamadığı için iptal işlemi yapılamıyor.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            ConsoleRestaurantDesign.WriteInfo($"İptal sonrasında {order.OrderQuantity} adet ürün stoğa geri eklenecek.");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  Siparişi iptal etmek istiyor musunuz? (E/H): ");
            Console.ResetColor();

            string? confirmation = Console.ReadLine();

            if (!string.Equals(confirmation?.Trim(), "E", StringComparison.OrdinalIgnoreCase))
            {
                ConsoleRestaurantDesign.WriteInfo("Sipariş iptal işlemi kullanıcı tarafından vazgeçildi.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            _orderService.CancelOrder(orderId);

            ConsoleRestaurantDesign.WaitForKey();
        }


        public void ShowPlaceholder(string title)
        {
            ConsoleRestaurantDesign.WriteHeader(title);
            ConsoleRestaurantDesign.WriteInfo("Bu işlem daha sonra geliştirilecek.");
            ConsoleRestaurantDesign.WaitForKey();
        }
    }
}
