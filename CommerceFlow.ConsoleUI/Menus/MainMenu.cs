using CommerceFlow.ConsoleUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceFlow.ConsoleUI.Menus
{
    public class MainMenu
    {
        private readonly CategoryMenu _categoryMenu;
        private readonly CustomerMenu _customerMenu;
        private readonly ProductMenu _productMenu;
        public MainMenu(CategoryMenu categoryMenu, CustomerMenu customerMenu, ProductMenu productMenu)
        {
            _categoryMenu = categoryMenu;
            _customerMenu = customerMenu;
            _productMenu = productMenu;
        }

        public void Show()
        {
            bool isRunning = true;

            while (isRunning)
            {
                ConsoleRestaurantDesign.WriteHeader("Ana Menü");

                ConsoleRestaurantDesign.WriteMenuItem(1, "Ürün İşlemleri");
                ConsoleRestaurantDesign.WriteMenuItem(2, "Kategori İşlemleri");
                ConsoleRestaurantDesign.WriteMenuItem(3, "Müşteri İşlemleri");
                ConsoleRestaurantDesign.WriteMenuItem(4, "Sipariş İşlemleri");
                ConsoleRestaurantDesign.WriteMenuItem(5, "Raporlar");
                ConsoleRestaurantDesign.WriteMenuItem(0, "Çıkış");

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("  Seçiminiz: ");
                Console.ResetColor();

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": _productMenu.Show(); break;
                    case "2": _categoryMenu.Show(); break;
                    case "3": _customerMenu.Show(); break;
                    case "4": ShowPlaceholder("Sipariş İşlemleri"); break;
                    case "5": ShowPlaceholder("Raporlar"); break;
                    case "0": isRunning = false; break;
                    default: ConsoleRestaurantDesign.WriteError("Geçersiz seçim yaptınız."); ConsoleRestaurantDesign.WaitForKey(); break;
                }
            }

            Console.Clear();
            ConsoleRestaurantDesign.WriteSuccess("CommerceFlow uygulamasından çıkış yapıldı.");
        }
        private void ShowPlaceholder(string title)
        {
            ConsoleRestaurantDesign.WriteHeader(title);
            ConsoleRestaurantDesign.WriteInfo("Bu bölümün işlemleri daha sonra eklenecek.");
            ConsoleRestaurantDesign.WaitForKey();
        }
    }
}
