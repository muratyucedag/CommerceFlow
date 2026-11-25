using CommerceFlow.Business.Abstract;
using CommerceFlow.Business.Reports;
using CommerceFlow.ConsoleUI.Helpers;

namespace CommerceFlow.ConsoleUI.Screens
{
    public class ReportScreens
    {
        private readonly ICategoryService _categoryService;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IReportService _reportService;
        public ReportScreens(ICategoryService categoryService, ICustomerService customerService, IProductService productService, IOrderService orderService, IReportService reportService)
        {
            _categoryService = categoryService;
            _customerService = customerService;
            _productService = productService;
            _orderService = orderService;
            _reportService = reportService;
        }
        public void ShowGeneralStatistics()
        {
            ConsoleRestaurantDesign.WriteHeader("Genel İstatistikler");

            GeneralStatisticsReport report = _reportService.GetGeneralStatistics();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  -------- GENEL VERİLER --------");
            Console.ResetColor();

            Console.WriteLine($"  Toplam Kategori       : {report.TotalCategories}");
            Console.WriteLine($"  Toplam Müşteri        : {report.TotalCustomers}");
            Console.WriteLine($"  Toplam Ürün           : {report.TotalProducts}");
            Console.WriteLine($"  Toplam Sipariş        : {report.TotalOrders}");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  -------- STOK VERİLERİ --------");
            Console.ResetColor();

            Console.WriteLine($"  Toplam Stok Adedi     : {report.TotalStock}");
            Console.WriteLine($"  Düşük Stoklu Ürün     : {report.LowStockProducts}");
            Console.WriteLine($"  Stoğu Tükenen Ürün   : {report.OutOfStockProducts}");

            Console.WriteLine();
            ConsoleRestaurantDesign.WriteSuccess("Genel istatistikler başarıyla getirildi.");
            ConsoleRestaurantDesign.WaitForKey();
        }
        public void ShowOrderStatusReport()
        {
            ConsoleRestaurantDesign.WriteHeader("Sipariş Durumu Raporu");

            OrderStatusReport report = _reportService.GetOrderStatusReport();

            if (report.TotalOrders == 0)
            {
                ConsoleRestaurantDesign.WriteInfo("Raporlanacak sipariş bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"  {"SİPARİŞ DURUMU",-22} {"ADET",-12} {"ORAN",-12}");
            Console.WriteLine(new string('-', 50));
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  {"Hazırlanıyor",-22} {report.PreparingOrders,-12} %{report.PreparingRate:N2}");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"  {"Kargoda",-22} {report.ShippingOrders,-12} %{report.ShippingRate:N2}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  {"Teslim Edildi",-22} {report.DeliveredOrders,-12} %{report.DeliveredRate:N2}");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"  {"İptal Edildi",-22} {report.CancelledOrders,-12} %{report.CancelledRate:N2}");

            Console.ResetColor();

            Console.WriteLine(new string('-', 50));
            Console.WriteLine();
            ConsoleRestaurantDesign.WriteSuccess($"Toplam Sipariş Sayısı: {report.TotalOrders}");
            ConsoleRestaurantDesign.WaitForKey();
        }
        public void ShowSalesReport()
        {
            ConsoleRestaurantDesign.WriteHeader("Satış ve Ciro Raporu");

            SalesReport report = _reportService.GetSalesReport();

            if (report.TotalOrders == 0)
            {
                ConsoleRestaurantDesign.WriteInfo("Raporlanacak sipariş bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  -------- SATIŞ VE CİRO BİLGİLERİ --------");
            Console.ResetColor();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Toplam Sipariş Tutarı      : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{report.TotalOrderAmount:N2} TL");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Gerçekleşen Ciro           : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{report.CompletedRevenue:N2} TL");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Bekleyen Sipariş Tutarı    : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{report.PendingAmount:N2} TL");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  İptal Edilen Sipariş Tutarı: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{report.CancelledAmount:N2} TL");

            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  -------- SİPARİŞ ANALİZİ --------");
            Console.ResetColor();

            Console.WriteLine();

            Console.WriteLine($"  Ortalama Sipariş Tutarı    : {report.AverageOrderAmount:N2} TL");
            Console.WriteLine($"  En Yüksek Sipariş Tutarı   : {report.HighestOrderAmount:N2} TL");
            Console.WriteLine($"  Toplam Sipariş Sayısı      : {report.TotalOrders}");
            Console.WriteLine($"  Geçerli Sipariş Sayısı     : {report.ValidOrders}");

            Console.WriteLine();

            ConsoleRestaurantDesign.WriteSuccess("Satış ve ciro raporu başarıyla oluşturuldu.");
            ConsoleRestaurantDesign.WaitForKey();
        }
        public void ShowStockReport()
        {
            ConsoleRestaurantDesign.WriteHeader("Stok Durumu Raporu");

            StockReport report = _reportService.GetStockReport();

            if (report.TotalProducts == 0)
            {
                ConsoleRestaurantDesign.WriteInfo("Raporlanacak ürün bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  -------- GENEL STOK BİLGİLERİ --------");
            Console.ResetColor();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Toplam Ürün Çeşidi   : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(report.TotalProducts);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Toplam Stok Adedi    : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(report.TotalStock);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Toplam Stok Değeri   : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{report.TotalStockValue:N2} TL");

            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  -------- STOK DURUMU DAĞILIMI --------");
            Console.ResetColor();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"  Stoğu Tükenen Ürünler : {report.OutOfStock}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  Düşük Stoklu Ürünler  : {report.LowStock}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  Yeterli Stoklu Ürünler: {report.SufficientStock}");

            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  -------- STOK ANALİZİ --------");
            Console.ResetColor();

            Console.WriteLine();

            if (report.HighestStockProductName != null)
            {
                Console.WriteLine($"  En Fazla Stok: {report.HighestStockProductName}");
                ConsoleRestaurantDesign.WriteInfo($"  Stok Miktarı: {report.HighestStockQuantity}");
            }

            Console.WriteLine();

            if (report.LowestStockProductName != null)
            {
                Console.WriteLine($"  En Az Stok: {report.LowestStockProductName}");
                ConsoleRestaurantDesign.WriteInfo($"  Stok Miktarı: {report.LowestStockQuantity}");
            }

            Console.WriteLine();
            ConsoleRestaurantDesign.WriteSuccess("Stok raporu başarıyla oluşturuldu.");
            ConsoleRestaurantDesign.WaitForKey();
        }
        public void ShowCategoryProductReport()
        {
            ConsoleRestaurantDesign.WriteHeader("Kategori Bazlı Ürün Raporu");

            CategoryProductReport report = _reportService.GetCategoryProductReport();

            if (report.TotalCategories == 0)
            {
                ConsoleRestaurantDesign.WriteInfo("Raporlanacak kategori bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"  {"KATEGORİ ADI",-35} {"ÜRÜN",-8} {"STOK",-10} {"STOK DEĞERİ",-20}");

            Console.WriteLine(new string('-', 80));

            Console.ResetColor();

            foreach (CategoryProductReportItem category in report.Categories)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"  {category.CategoryName,-35}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{category.ProductCount,-8}");
                Console.Write($"{category.TotalStock,-10}");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{category.StockValue,-20:N2}");
            }

            Console.ResetColor();

            Console.WriteLine(new string('-', 80));
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  -------- GENEL TOPLAMLAR --------");
            Console.ResetColor();

            Console.WriteLine();

            Console.WriteLine($"  Toplam Kategori  : {report.TotalCategories}");
            Console.WriteLine($"  Toplam Ürün      : {report.TotalProducts}");
            Console.WriteLine($"  Toplam Stok      : {report.TotalStock}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  Toplam Stok Değeri : {report.TotalStockValue:N2} TL");

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