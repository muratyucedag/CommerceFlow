using CommerceFlow.ConsoleUI.Helpers;
using CommerceFlow.ConsoleUI.Screens;

namespace CommerceFlow.ConsoleUI.Menus
{
    public class OrderMenu
    {
        private readonly OrderScreens _orderScreens;
        public OrderMenu(OrderScreens orderScreens)
        {
            _orderScreens = orderScreens;
        }
        public void Show()
        {
            bool isRunning = true;

            while (isRunning)
            {
                ConsoleRestaurantDesign.WriteHeader("Sipariş Yönetimi");

                ConsoleRestaurantDesign.WriteMenuItem(1, "Siparişleri Listele");
                ConsoleRestaurantDesign.WriteMenuItem(2, "Sipariş Detayını Görüntüle");
                ConsoleRestaurantDesign.WriteMenuItem(3, "Yeni Sipariş Oluştur");
                ConsoleRestaurantDesign.WriteMenuItem(4, "Sipariş Durumunu Güncelle");
                ConsoleRestaurantDesign.WriteMenuItem(5, "Sipariş İptal Et");
                ConsoleRestaurantDesign.WriteMenuItem(0, "Ana Menüye Dön");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("  Seçiminiz: ");
                Console.ResetColor();

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": _orderScreens.ShowOrders(); break;
                    case "2": _orderScreens.ShowOrderDetail(); break;
                    case "3": _orderScreens.AddOrder(); break;
                    case "4": _orderScreens.UpdateOrderStatus(); break;
                    case "5": _orderScreens.CancelOrder(); break;
                    case "0": isRunning = false; break;
                    default: ConsoleRestaurantDesign.WriteError("Geçersiz seçim yaptınız."); ConsoleRestaurantDesign.WaitForKey(); break;
                }
            }
        }
    }
}