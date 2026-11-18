using CommerceFlow.Business.Abstract;
using CommerceFlow.Business.Concrete;
using CommerceFlow.ConsoleUI.Helpers;
using CommerceFlow.DataAccess.Interfaces;
using CommerceFlow.DataAccess.Repositories;
using CommerceFlow.Entities.Entities;

Console.Title = "CommerceFlow - E-Ticaret Yönetim Sistemi";

ICategoryRepository categoryRepository = new CategoryRepository();
ICategoryService categoryService = new CategoryManager(categoryRepository);

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
        case "1":
            ShowSection("Ürün İşlemleri");
            break;

        case "2":
            ShowCategoryMenu();
            break;

        case "3":
            ShowSection("Müşteri İşlemleri");
            break;

        case "4":
            ShowSection("Sipariş İşlemleri");
            break;

        case "5":
            ShowSection("Raporlar");
            break;

        case "0":
            isRunning = false;
            break;

        default:
            ConsoleRestaurantDesign.WriteError("Geçersiz seçim yaptınız.");
            ConsoleRestaurantDesign.WaitForKey();
            break;
    }
}

Console.Clear();
ConsoleRestaurantDesign.WriteSuccess("CommerceFlow uygulamasından çıkış yapıldı.");

void ShowCategories()
{
    ConsoleRestaurantDesign.WriteHeader("Kategori Listesi");

    List<Category> categories = categoryService.GetAllCategories();

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

    ConsoleRestaurantDesign.WriteSuccess(
        $"Toplam {categories.Count} kategori listelendi.");

    ConsoleRestaurantDesign.WaitForKey();
}


void ShowCategoryMenu()
{
    bool categoryMenuRunning = true;

    while (categoryMenuRunning)
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
            case "1":
                ShowCategories();
                break;

            case "2":
                ShowCategoryPlaceholder("Kategori Detayı");
                break;

            case "3":
                ShowCategoryPlaceholder("Yeni Kategori Ekle");
                break;

            case "4":
                ShowCategoryPlaceholder("Kategori Güncelle");
                break;

            case "5":
                ShowCategoryPlaceholder("Kategori Sil");
                break;

            case "0":
                categoryMenuRunning = false;
                break;

            default:
                ConsoleRestaurantDesign.WriteError(
                    "Geçersiz seçim yaptınız.");

                ConsoleRestaurantDesign.WaitForKey();
                break;
        }
    }
}


void ShowCategoryPlaceholder(string title)
{
    ConsoleRestaurantDesign.WriteHeader(title);

    ConsoleRestaurantDesign.WriteInfo(
        "Bu işlemin geliştirilmesine daha sonra başlanacak.");

    ConsoleRestaurantDesign.WaitForKey();
}


static void ShowSection(string sectionName)
{
    ConsoleRestaurantDesign.WriteHeader(sectionName);

    ConsoleRestaurantDesign.WriteInfo("Bu bölümün işlemleri daha sonra eklenecek.");

    ConsoleRestaurantDesign.WaitForKey();
}
