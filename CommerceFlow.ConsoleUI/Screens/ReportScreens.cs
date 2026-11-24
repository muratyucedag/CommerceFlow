using CommerceFlow.Business.Abstract;
using CommerceFlow.ConsoleUI.Helpers;

namespace CommerceFlow.ConsoleUI.Screens
{
    public class ReportScreens
    {
        private readonly ICategoryService _categoryService;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        public ReportScreens(ICategoryService categoryService, ICustomerService customerService, IProductService productService, IOrderService orderService)
        {
            _categoryService = categoryService;
            _customerService = customerService;
            _productService = productService;
            _orderService = orderService;
        }

        public void ShowGeneralStatistics()
        {
            ConsoleRestaurantDesign.WriteHeader("Genel İstatistikler");

            var categories = _categoryService.GetAllCategories();
            var customers = _customerService.GetAllCustomers();
            var products = _productService.GetAllProducts();
            var orders = _orderService.GetAllOrders();

            int totalCategories = categories.Count;
            int totalCustomers = customers.Count;
            int totalProducts = products.Count;
            int totalOrders = orders.Count;

            int totalStock = products.Sum(x => x.ProductStock);

            int lowStockProducts = products.Count(x => x.ProductStock < 10);
            int outOfStockProducts = products.Count(x => x.ProductStock == 0);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  -------- GENEL VERİLER --------");
            Console.ResetColor();

            Console.WriteLine($"  Toplam Kategori       : {totalCategories}");
            Console.WriteLine($"  Toplam Müşteri        : {totalCustomers}");
            Console.WriteLine($"  Toplam Ürün           : {totalProducts}");
            Console.WriteLine($"  Toplam Sipariş        : {totalOrders}");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  -------- STOK VERİLERİ --------");
            Console.ResetColor();

            Console.WriteLine($"  Toplam Stok Adedi     : {totalStock}");
            Console.WriteLine($"  Düşük Stoklu Ürün     : {lowStockProducts}");
            Console.WriteLine($"  Stoğu Tükenen Ürün   : {outOfStockProducts}");

            Console.WriteLine();

            ConsoleRestaurantDesign.WriteSuccess("Genel istatistikler başarıyla getirildi.");

            ConsoleRestaurantDesign.WaitForKey();
        }
        public void ShowOrderStatusReport()
        {
            ConsoleRestaurantDesign.WriteHeader("Sipariş Durumu Raporu");

            var orders = _orderService.GetAllOrders();

            if (orders.Count == 0)
            {
                ConsoleRestaurantDesign.WriteInfo("Raporlanacak sipariş bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            int totalOrders = orders.Count;

            int preparingOrders = orders.Count(x => x.OrderStatus == "Hazırlanıyor");
            int shippingOrders = orders.Count(x => x.OrderStatus == "Kargoda");
            int deliveredOrders = orders.Count(x => x.OrderStatus == "Teslim Edildi");
            int cancelledOrders = orders.Count(x => x.OrderStatus == "İptal Edildi");

            double preparingRate = (double)preparingOrders / totalOrders * 100;
            double shippingRate = (double)shippingOrders / totalOrders * 100;
            double deliveredRate = (double)deliveredOrders / totalOrders * 100;
            double cancelledRate = (double)cancelledOrders / totalOrders * 100;

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"  {"SİPARİŞ DURUMU",-22} {"ADET",-12} {"ORAN",-12}");
            Console.WriteLine(new string('-', 50));

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  {"Hazırlanıyor",-22} {preparingOrders,-12} %{preparingRate:N2}");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"  {"Kargoda",-22} {shippingOrders,-12} %{shippingRate:N2}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  {"Teslim Edildi",-22} {deliveredOrders,-12} %{deliveredRate:N2}");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"  {"İptal Edildi",-22} {cancelledOrders,-12} %{cancelledRate:N2}");

            Console.ResetColor();

            Console.WriteLine(new string('-', 50));
            Console.WriteLine();

            ConsoleRestaurantDesign.WriteSuccess($"Toplam Sipariş Sayısı: {totalOrders}");

            ConsoleRestaurantDesign.WaitForKey();
        }
        public void ShowSalesReport()
        {
            ConsoleRestaurantDesign.WriteHeader("Satış ve Ciro Raporu");

            var orders = _orderService.GetAllOrders();

            if (orders.Count == 0)
            {
                ConsoleRestaurantDesign.WriteInfo("Raporlanacak sipariş bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            decimal totalOrderAmount = orders.Sum(x => x.OrderTotalPrice);
            decimal completedRevenue = orders.Where(x => x.OrderStatus == "Teslim Edildi").Sum(x => x.OrderTotalPrice);
            decimal pendingAmount = orders.Where(x => x.OrderStatus == "Hazırlanıyor" || x.OrderStatus == "Kargoda").Sum(x => x.OrderTotalPrice);
            decimal cancelledAmount = orders.Where(x => x.OrderStatus == "İptal Edildi").Sum(x => x.OrderTotalPrice);
            var validOrders = orders.Where(x => x.OrderStatus != "İptal Edildi").ToList();

            decimal averageOrderAmount = validOrders.Count > 0 ? validOrders.Average(x => x.OrderTotalPrice) : 0;

            decimal highestOrderAmount = orders.Max(x => x.OrderTotalPrice);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  -------- SATIŞ VE CİRO BİLGİLERİ --------");
            Console.ResetColor();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Toplam Sipariş Tutarı      : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{totalOrderAmount:N2} TL");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Gerçekleşen Ciro           : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{completedRevenue:N2} TL");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Bekleyen Sipariş Tutarı    : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{pendingAmount:N2} TL");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  İptal Edilen Sipariş Tutarı: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{cancelledAmount:N2} TL");

            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  -------- SİPARİŞ ANALİZİ --------");
            Console.ResetColor();

            Console.WriteLine();

            Console.WriteLine($"  Ortalama Sipariş Tutarı    : {averageOrderAmount:N2} TL");
            Console.WriteLine($"  En Yüksek Sipariş Tutarı   : {highestOrderAmount:N2} TL");
            Console.WriteLine($"  Toplam Sipariş Sayısı      : {orders.Count}");
            Console.WriteLine($"  Geçerli Sipariş Sayısı     : {validOrders.Count}");
            Console.WriteLine();

            ConsoleRestaurantDesign.WriteSuccess("Satış ve ciro raporu başarıyla oluşturuldu.");
            ConsoleRestaurantDesign.WaitForKey();
        }
        public void ShowStockReport()
        {
            ConsoleRestaurantDesign.WriteHeader("Stok Durumu Raporu");

            var products = _productService.GetAllProducts();

            if (products.Count == 0)
            {
                ConsoleRestaurantDesign.WriteInfo("Raporlanacak ürün bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            int totalProducts = products.Count;
            int totalStock = products.Sum(x => x.ProductStock);
            decimal totalStockValue = products.Sum(x => x.ProductPrice * x.ProductStock);

            int outOfStock = products.Count(x => x.ProductStock == 0);
            int lowStock = products.Count(x => x.ProductStock > 0 && x.ProductStock < 10);
            int sufficientStock = products.Count(x => x.ProductStock >= 10);

            var highestStockProduct = products.OrderByDescending(x => x.ProductStock).FirstOrDefault();
            var lowestStockProduct = products.OrderBy(x => x.ProductStock).FirstOrDefault();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  -------- GENEL STOK BİLGİLERİ --------");
            Console.ResetColor();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Toplam Ürün Çeşidi   : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(totalProducts);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Toplam Stok Adedi    : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(totalStock);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Toplam Stok Değeri   : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{totalStockValue:N2} TL");

            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  -------- STOK DURUMU DAĞILIMI --------");
            Console.ResetColor();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"  Stoğu Tükenen Ürünler : {outOfStock}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  Düşük Stoklu Ürünler  : {lowStock}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  Yeterli Stoklu Ürünler: {sufficientStock}");

            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  -------- STOK ANALİZİ --------");
            Console.ResetColor();

            Console.WriteLine();

            if (highestStockProduct != null)
            {
                Console.WriteLine($"  En Fazla Stok: {highestStockProduct.ProductName}");
                ConsoleRestaurantDesign.WriteInfo($"  Stok Miktarı: {highestStockProduct.ProductStock}");
            }

            Console.WriteLine();

            if (lowestStockProduct != null)
            {
                Console.WriteLine($"  En Az Stok: {lowestStockProduct.ProductName}");
                ConsoleRestaurantDesign.WriteInfo($"  Stok Miktarı: {lowestStockProduct.ProductStock}");
            }

            Console.WriteLine();
            ConsoleRestaurantDesign.WriteSuccess("Stok raporu başarıyla oluşturuldu.");
            ConsoleRestaurantDesign.WaitForKey();
        }
        public void ShowCategoryProductReport()
        {
            ConsoleRestaurantDesign.WriteHeader("Kategori Bazlı Ürün Raporu");

            var categories = _categoryService.GetAllCategories();
            var products = _productService.GetAllProducts();

            if (categories.Count == 0)
            {
                ConsoleRestaurantDesign.WriteInfo("Raporlanacak kategori bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            // Ürünleri kategori ID değerlerine göre gruplandıralım.
            var productGroups = products
                .GroupBy(x => x.CategoryId)
                .ToDictionary(
                    x => x.Key,
                    x => new
                    {
                        ProductCount = x.Count(),
                        TotalStock = x.Sum(p => p.ProductStock),
                        StockValue = x.Sum(
                            p => p.ProductPrice * p.ProductStock)
                    });

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"  {"KATEGORİ ADI",-35} {"ÜRÜN",-8} {"STOK",-10} {"STOK DEĞERİ",-20}");
            Console.WriteLine(new string('-', 80));
            Console.ResetColor();

            foreach (var category in categories)
            {
                bool hasProducts = productGroups.TryGetValue(category.CategoryId, out var group);

                int productCount = hasProducts ? group!.ProductCount : 0;
                int totalStock = hasProducts ? group!.TotalStock : 0;
                decimal stockValue = hasProducts ? group!.StockValue : 0;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"  {category.CategoryName,-35}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{productCount,-8}");
                Console.Write($"{totalStock,-10}");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{stockValue,-20:N2}");
            }

            Console.ResetColor();

            Console.WriteLine(new string('-', 80));
            Console.WriteLine();

            // Genel toplamlar
            int totalProducts = products.Count;
            int totalStockQuantity = products.Sum(x => x.ProductStock);
            decimal totalStockValue = products.Sum(x => x.ProductPrice * x.ProductStock);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  -------- GENEL TOPLAMLAR --------");
            Console.ResetColor();

            Console.WriteLine();

            Console.WriteLine($"  Toplam Kategori  : {categories.Count}");
            Console.WriteLine($"  Toplam Ürün      : {totalProducts}");
            Console.WriteLine($"  Toplam Stok      : {totalStockQuantity}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  Toplam Stok Değeri : {totalStockValue:N2} TL");

            Console.ResetColor();

            Console.WriteLine();

            ConsoleRestaurantDesign.WriteSuccess("Kategori bazlı ürün raporu başarıyla oluşturuldu.");

            ConsoleRestaurantDesign.WaitForKey();
        }




        public void ShowPlaceholder(string title)
        {
            ConsoleRestaurantDesign.WriteHeader(title);
            ConsoleRestaurantDesign.WriteInfo("Bu rapor daha sonra geliştirilecek.");
            ConsoleRestaurantDesign.WaitForKey();
        }
    }
}
