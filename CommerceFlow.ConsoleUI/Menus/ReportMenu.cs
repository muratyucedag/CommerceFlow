using CommerceFlow.ConsoleUI.Helpers;
using CommerceFlow.ConsoleUI.Screens;

namespace CommerceFlow.ConsoleUI.Menus
{
    public class ReportMenu
    {
        private readonly ReportScreens _reportScreens;
        public ReportMenu(ReportScreens reportScreens)
        {
            _reportScreens = reportScreens;
        }
        public void Show()
        {
            bool isRunning = true;

            while (isRunning)
            {
                ConsoleRestaurantDesign.WriteHeader("Raporlar ve İstatistikler");
                ConsoleRestaurantDesign.WriteMenuItem(1, "Genel İstatistikler");
                ConsoleRestaurantDesign.WriteMenuItem(2, "Sipariş Durumu Raporu");
                ConsoleRestaurantDesign.WriteMenuItem(3, "Satış ve Ciro Raporu");
                ConsoleRestaurantDesign.WriteMenuItem(4, "Stok Durumu Raporu");
                ConsoleRestaurantDesign.WriteMenuItem(5, "Kategori Bazlı Ürün Raporu");
                ConsoleRestaurantDesign.WriteMenuItem(0, "Ana Menüye Dön");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("  Seçiminiz: ");
                Console.ResetColor();

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": _reportScreens.ShowGeneralStatistics(); break;
                    case "2": _reportScreens.ShowOrderStatusReport(); break;
                    case "3": _reportScreens.ShowSalesReport(); break;
                    case "4": _reportScreens.ShowStockReport(); break;
                    case "5": _reportScreens.ShowCategoryProductReport(); break;
                    case "0": isRunning = false; break;
                    default: ConsoleRestaurantDesign.WriteError("Geçersiz seçim yaptınız."); ConsoleRestaurantDesign.WaitForKey(); break;
                }
            }
        }
    }
}