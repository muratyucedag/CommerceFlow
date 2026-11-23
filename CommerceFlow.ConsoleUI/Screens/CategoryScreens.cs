using CommerceFlow.Business.Abstract;
using CommerceFlow.ConsoleUI.Helpers;
using CommerceFlow.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceFlow.ConsoleUI.Screens
{
    public class CategoryScreens
    {
        private readonly ICategoryService _categoryService;
        public CategoryScreens(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public void ShowCategories()
        {
            ConsoleRestaurantDesign.WriteHeader("Kategori Listesi");
            List<Category> categories = _categoryService.GetAllCategories();

            if (categories.Count == 0)
            {
                ConsoleRestaurantDesign.WriteInfo("Kayıtlı kategori bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("  ---------------------------------------------");
            Console.WriteLine("  ID      KATEGORİ ADI");
            Console.WriteLine("  ---------------------------------------------");

            Console.ResetColor();

            foreach (Category category in categories)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"  {category.CategoryId,-8}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(category.CategoryName);
            }

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  ---------------------------------------------");
            Console.ResetColor();

            ConsoleRestaurantDesign.WriteSuccess($"Toplam {categories.Count} kategori listelendi.");
            ConsoleRestaurantDesign.WaitForKey();
        }

        public void AddCategory()
        {
            ConsoleRestaurantDesign.WriteHeader("Yeni Kategori Ekle");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Kategori Adı: ");
            Console.ResetColor();

            string? categoryName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                ConsoleRestaurantDesign.WriteError("Kategori adı boş bırakılamaz.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Category category = new Category
            {
                CategoryName = categoryName.Trim()
            };

            _categoryService.AddCategory(category);

            ConsoleRestaurantDesign.WaitForKey();
        }

        public void ShowCategoryDetail()
        {
            ConsoleRestaurantDesign.WriteHeader("Kategori Detayı");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Kategori ID: ");
            Console.ResetColor();

            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int categoryId) || categoryId <= 0)
            {
                ConsoleRestaurantDesign.WriteError("Geçerli bir kategori ID değeri giriniz.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Category? category = _categoryService.GetCategoryById(categoryId);

            if (category == null)
            {
                ConsoleRestaurantDesign.WriteError("Belirtilen ID değerine ait kategori bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  ---------------------------------------------");
            Console.WriteLine("                 KATEGORİ BİLGİLERİ");
            Console.WriteLine("  ---------------------------------------------");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Kategori ID   : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(category.CategoryId);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Kategori Adı  : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(category.CategoryName);

            Console.ResetColor();

            Console.WriteLine();

            ConsoleRestaurantDesign.WriteSuccess("Kategori bilgileri başarıyla getirildi.");
            ConsoleRestaurantDesign.WaitForKey();
        }

        public void DeleteCategory()
        {
            ConsoleRestaurantDesign.WriteHeader("Kategori Silme");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Silinecek Kategori ID: ");
            Console.ResetColor();

            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int categoryId) || categoryId <= 0)
            {
                ConsoleRestaurantDesign.WriteError("Geçerli bir kategori ID değeri giriniz.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Category? category = _categoryService.GetCategoryById(categoryId);

            if (category == null)
            {
                ConsoleRestaurantDesign.WriteError("Silinecek kategori bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  ---------------------------------------------");
            Console.WriteLine("              SİLİNECEK KATEGORİ");
            Console.WriteLine("  ---------------------------------------------");
            Console.ResetColor();

            Console.WriteLine($"  Kategori ID  : {category.CategoryId}");
            Console.WriteLine($"  Kategori Adı : {category.CategoryName}");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  Bu kategoriyi silmek istediğinize emin misiniz? (E/H): ");
            Console.ResetColor();

            string? confirmation = Console.ReadLine();

            if (!string.Equals(confirmation?.Trim(), "E", StringComparison.OrdinalIgnoreCase))
            {
                ConsoleRestaurantDesign.WriteInfo("Kategori silme işlemi iptal edildi.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            try
            {
                _categoryService.DeleteCategory(categoryId);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                ConsoleRestaurantDesign.WriteError("Kategori silinemedi. İlişkili ürün kayıtları bulunuyor olabilir.");
            }

            ConsoleRestaurantDesign.WaitForKey();
        }


        public void UpdateCategory()
        {
            ConsoleRestaurantDesign.WriteHeader("Kategori Güncelleme");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Güncellenecek Kategori ID: ");
            Console.ResetColor();

            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int categoryId) || categoryId <= 0)
            {
                ConsoleRestaurantDesign.WriteError("Geçerli bir kategori ID değeri giriniz.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Category? category = _categoryService.GetCategoryById(categoryId);

            if (category == null)
            {
                ConsoleRestaurantDesign.WriteError("Güncellenecek kategori bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  ---------------------------------------------");
            Console.WriteLine("             MEVCUT KATEGORİ BİLGİLERİ");
            Console.WriteLine("  ---------------------------------------------");
            Console.ResetColor();

            Console.WriteLine($"  Kategori ID  : {category.CategoryId}");
            Console.WriteLine($"  Kategori Adı : {category.CategoryName}");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Yeni Kategori Adı: ");
            Console.ResetColor();

            string? newCategoryName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newCategoryName))
            {
                ConsoleRestaurantDesign.WriteError("Yeni kategori adı boş bırakılamaz.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            string oldCategoryName = category.CategoryName;

            category.CategoryName = newCategoryName.Trim();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  -------- GÜNCELLEME ÖZETİ --------");
            Console.ResetColor();

            Console.WriteLine($"  Eski Kategori Adı : {oldCategoryName}");
            Console.WriteLine($"  Yeni Kategori Adı : {category.CategoryName}");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Değişiklikleri kaydetmek istiyor musunuz? (E/H): ");
            Console.ResetColor();

            string? confirmation = Console.ReadLine();

            if (!string.Equals(confirmation?.Trim(), "E", StringComparison.OrdinalIgnoreCase))
            {
                ConsoleRestaurantDesign.WriteInfo("Kategori güncelleme işlemi iptal edildi.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            _categoryService.UpdateCategory(category);

            ConsoleRestaurantDesign.WaitForKey();
        }



        public void ShowPlaceholder(string title)
        {
            ConsoleRestaurantDesign.WriteHeader(title);
            ConsoleRestaurantDesign.WriteInfo("Bu işlemin geliştirilmesine daha sonra başlanacak.");
            ConsoleRestaurantDesign.WaitForKey();
        }
    }
}
