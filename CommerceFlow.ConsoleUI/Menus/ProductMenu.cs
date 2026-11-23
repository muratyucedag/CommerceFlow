using CommerceFlow.ConsoleUI.Helpers;
using CommerceFlow.ConsoleUI.Screens;

namespace CommerceFlow.ConsoleUI.Menus
{
    public class ProductMenu
    {
        private readonly ProductScreens _productScreens;
        public ProductMenu(ProductScreens productScreens)
        {
            _productScreens = productScreens;
        }
        public void Show()
        {
            bool isRunning = true;

            while (isRunning)
            {
                ConsoleRestaurantDesign.WriteHeader("Ürün Yönetimi");

                ConsoleRestaurantDesign.WriteMenuItem(1, "Ürünleri Listele");
                ConsoleRestaurantDesign.WriteMenuItem(2, "Ürün Detayını Görüntüle");
                ConsoleRestaurantDesign.WriteMenuItem(3, "Yeni Ürün Ekle");
                ConsoleRestaurantDesign.WriteMenuItem(4, "Ürün Güncelle");
                ConsoleRestaurantDesign.WriteMenuItem(5, "Ürün Sil");
                ConsoleRestaurantDesign.WriteMenuItem(6, "Düşük Stoklu Ürünleri Listele");
                ConsoleRestaurantDesign.WriteMenuItem(0, "Ana Menüye Dön");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("  Seçiminiz: ");
                Console.ResetColor();

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": _productScreens.ShowProducts(); break;
                    case "2": _productScreens.ShowProductDetail(); break;
                    case "3": _productScreens.AddProduct(); break;
                    case "4": _productScreens.UpdateProduct(); break;
                    case "5": _productScreens.DeleteProduct(); break;
                    case "6": _productScreens.ShowLowStockProducts(); break;
                    case "0": isRunning = false; break;
                    default: ConsoleRestaurantDesign.WriteError("Geçersiz seçim yaptınız."); ConsoleRestaurantDesign.WaitForKey(); break;
                }
            }
        }
    }
}