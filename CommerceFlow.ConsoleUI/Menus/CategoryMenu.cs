using CommerceFlow.ConsoleUI.Helpers;
using CommerceFlow.ConsoleUI.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceFlow.ConsoleUI.Menus
{
    public class CategoryMenu
    {
        private readonly CategoryScreens _categoryScreens;
        public CategoryMenu(CategoryScreens categoryScreens)
        {
            _categoryScreens = categoryScreens;
        }

        public void Show()
        {
            bool isRunning = true;

            while (isRunning)
            {
                ConsoleRestaurantDesign.WriteHeader("Kategori Yönetimi");

                ConsoleRestaurantDesign.WriteMenuItem(1, "Kategorileri Listele");
                ConsoleRestaurantDesign.WriteMenuItem(2, "Kategori Detayını Görüntüle");
                ConsoleRestaurantDesign.WriteMenuItem(3, "Yeni Kategori Ekle");
                ConsoleRestaurantDesign.WriteMenuItem(4, "Kategori Güncelle");
                ConsoleRestaurantDesign.WriteMenuItem(5, "Kategori Sil");
                ConsoleRestaurantDesign.WriteMenuItem(0, "Ana Menüye Dön");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("  Seçiminiz: ");
                Console.ResetColor();

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": _categoryScreens.ShowCategories(); break;
                    case "2": _categoryScreens.ShowCategoryDetail(); break;
                    case "3": _categoryScreens.AddCategory(); break;
                    case "4": _categoryScreens.UpdateCategory(); break;
                    case "5": _categoryScreens.DeleteCategory(); break;
                    case "0": isRunning = false; break;
                    default: ConsoleRestaurantDesign.WriteError("Geçersiz seçim yaptınız."); ConsoleRestaurantDesign.WaitForKey(); break;
                }
            }
        }
    }
}