using CommerceFlow.ConsoleUI.Helpers;
using CommerceFlow.ConsoleUI.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceFlow.ConsoleUI.Menus
{
    public class CustomerMenu
    {
        private readonly CustomerScreens _customerScreens;
        public CustomerMenu(CustomerScreens customerScreens)
        {
            _customerScreens = customerScreens;
        }
        public void Show()
        {
            bool isRunning = true;

            while (isRunning)
            {
                ConsoleRestaurantDesign.WriteHeader("Müşteri Yönetimi");

                ConsoleRestaurantDesign.WriteMenuItem(1, "Müşterileri Listele");
                ConsoleRestaurantDesign.WriteMenuItem(2, "Müşteri Detayını Görüntüle");
                ConsoleRestaurantDesign.WriteMenuItem(3, "Yeni Müşteri Ekle");
                ConsoleRestaurantDesign.WriteMenuItem(4, "Müşteri Güncelle");
                ConsoleRestaurantDesign.WriteMenuItem(5, "Müşteri Sil");
                ConsoleRestaurantDesign.WriteMenuItem(6, "E-Posta Adresiyle Müşteri Ara");
                ConsoleRestaurantDesign.WriteMenuItem(0, "Ana Menüye Dön");

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("  Seçiminiz: ");
                Console.ResetColor();

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": _customerScreens.ShowCustomers(); break;
                    case "2": _customerScreens.ShowCustomerDetail(); break;
                    case "3": _customerScreens.AddCustomer(); break;
                    case "4": _customerScreens.UpdateCustomer(); break;
                    case "5": _customerScreens.DeleteCustomer(); break;
                    case "6": _customerScreens.SearchCustomerByEmail(); break;
                    case "0": isRunning = false; break;
                    default: ConsoleRestaurantDesign.WriteError("Geçersiz seçim yaptınız."); ConsoleRestaurantDesign.WaitForKey(); break;
                }
            }
        }
    }
}