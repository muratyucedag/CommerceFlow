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
    public class ProductScreens
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductScreens(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public void ShowProducts()
        {
            ConsoleRestaurantDesign.WriteHeader("Ürün Listesi");

            List<Product> products = _productService.GetAllProducts();

            if (products.Count == 0)
            {
                ConsoleRestaurantDesign.WriteInfo("Kayıtlı ürün bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"  {"ID",-5} {"ÜRÜN ADI",-35} {"FİYAT",-15} {"STOK",-8} {"KATEGORİ ID",-12}");
            Console.WriteLine(new string('-', 90));
            Console.ResetColor();

            foreach (Product product in products)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"  {product.ProductId,-5}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{product.ProductName,-35}");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{product.ProductPrice,-15:N2}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{product.ProductStock,-8}");

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{product.CategoryId,-12}");
            }

            Console.ResetColor();
            Console.WriteLine(new string('-', 90));
            ConsoleRestaurantDesign.WriteSuccess($"Toplam {products.Count} ürün listelendi.");
            ConsoleRestaurantDesign.WaitForKey();
        }
        public void AddProduct()
        {
            ConsoleRestaurantDesign.WriteHeader("Yeni Ürün Ekle");

            List<Category> categories = _categoryService.GetAllCategories();

            if (categories.Count == 0)
            {
                ConsoleRestaurantDesign.WriteError("Ürün eklemek için öncelikle kategori oluşturmalısınız.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  -------- MEVCUT KATEGORİLER --------");
            Console.ResetColor();

            foreach (Category category in categories)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"  [{category.CategoryId}] ");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(category.CategoryName);
            }

            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Ürün Adı       : ");
            Console.ResetColor();
            string? productName = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Ürün Fiyatı    : ");
            Console.ResetColor();
            string? priceInput = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Ürün Stok      : ");
            Console.ResetColor();
            string? stockInput = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Kategori ID    : ");
            Console.ResetColor();
            string? categoryInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(productName))
            {
                ConsoleRestaurantDesign.WriteError("Ürün adı boş bırakılamaz.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            if (!decimal.TryParse(priceInput, out decimal productPrice) || productPrice <= 0)
            {
                ConsoleRestaurantDesign.WriteError("Geçerli bir ürün fiyatı giriniz.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            if (!int.TryParse(stockInput, out int productStock) || productStock < 0)
            {
                ConsoleRestaurantDesign.WriteError("Geçerli bir stok miktarı giriniz.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            if (!int.TryParse(categoryInput, out int categoryId) || categoryId <= 0)
            {
                ConsoleRestaurantDesign.WriteError("Geçerli bir kategori ID değeri giriniz.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Category? selectedCategory = categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (selectedCategory == null)
            {
                ConsoleRestaurantDesign.WriteError("Seçilen kategori bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Product product = new Product
            {
                ProductName = productName.Trim(),
                ProductPrice = productPrice,
                ProductStock = productStock,
                CategoryId = categoryId
            };

            _productService.AddProduct(product);

            ConsoleRestaurantDesign.WaitForKey();
        }
        public void ShowProductDetail()
        {
            ConsoleRestaurantDesign.WriteHeader("Ürün Detayı");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Ürün ID: ");
            Console.ResetColor();

            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int productId) || productId <= 0)
            {
                ConsoleRestaurantDesign.WriteError("Geçerli bir ürün ID değeri giriniz.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Product? product = _productService.GetProductById(productId);

            if (product == null)
            {
                ConsoleRestaurantDesign.WriteError("Belirtilen ID değerine ait ürün bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Category? category = _categoryService.GetCategoryById(product.CategoryId);

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  ------------------------------------------------");
            Console.WriteLine("                    ÜRÜN BİLGİLERİ");
            Console.WriteLine("  ------------------------------------------------");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Ürün ID        : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(product.ProductId);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Ürün Adı       : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(product.ProductName);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Ürün Fiyatı    : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{product.ProductPrice:N2} TL");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Stok Miktarı   : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(product.ProductStock);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Kategori ID    : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(product.CategoryId);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Kategori Adı   : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(category?.CategoryName ?? "Kategori bulunamadı");

            Console.ResetColor();

            Console.WriteLine();

            ConsoleRestaurantDesign.WriteSuccess("Ürün bilgileri başarıyla getirildi.");
            ConsoleRestaurantDesign.WaitForKey();
        }
        public void DeleteProduct()
        {
            ConsoleRestaurantDesign.WriteHeader("Ürün Silme");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Silinecek Ürün ID: ");
            Console.ResetColor();

            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int productId) || productId <= 0)
            {
                ConsoleRestaurantDesign.WriteError("Geçerli bir ürün ID değeri giriniz.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Product? product = _productService.GetProductById(productId);

            if (product == null)
            {
                ConsoleRestaurantDesign.WriteError("Silinecek ürün bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  ---------------------------------------------");
            Console.WriteLine("                SİLİNECEK ÜRÜN");
            Console.WriteLine("  ---------------------------------------------");
            Console.ResetColor();

            Console.WriteLine($"  Ürün ID     : {product.ProductId}");
            Console.WriteLine($"  Ürün Adı    : {product.ProductName}");
            Console.WriteLine($"  Ürün Fiyatı : {product.ProductPrice:N2} TL");
            Console.WriteLine($"  Stok Miktarı: {product.ProductStock}");
            Console.WriteLine($"  Kategori ID : {product.CategoryId}");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  Bu ürünü silmek istediğinize emin misiniz? (E/H): ");
            Console.ResetColor();

            string? confirmation = Console.ReadLine();

            if (!string.Equals(confirmation?.Trim(), "E", StringComparison.OrdinalIgnoreCase))
            {
                ConsoleRestaurantDesign.WriteInfo("Ürün silme işlemi iptal edildi.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            try
            {
                _productService.DeleteProduct(productId);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                ConsoleRestaurantDesign.WriteError("Ürün silinemedi. Ürüne ait sipariş kayıtları bulunuyor olabilir.");
            }

            ConsoleRestaurantDesign.WaitForKey();
        }
        public void UpdateProduct()
        {
            ConsoleRestaurantDesign.WriteHeader("Ürün Güncelleme");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Güncellenecek Ürün ID: ");
            Console.ResetColor();

            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int productId) || productId <= 0)
            {
                ConsoleRestaurantDesign.WriteError("Geçerli bir ürün ID değeri giriniz.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Product? product = _productService.GetProductById(productId);

            if (product == null)
            {
                ConsoleRestaurantDesign.WriteError("Güncellenecek ürün bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Category? currentCategory = _categoryService.GetCategoryById(product.CategoryId);

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  ---------------------------------------------");
            Console.WriteLine("              MEVCUT ÜRÜN BİLGİLERİ");
            Console.WriteLine("  ---------------------------------------------");
            Console.ResetColor();

            Console.WriteLine($"  Ürün ID     : {product.ProductId}");
            Console.WriteLine($"  Ürün Adı    : {product.ProductName}");
            Console.WriteLine($"  Ürün Fiyatı : {product.ProductPrice:N2} TL");
            Console.WriteLine($"  Stok Miktarı: {product.ProductStock}");
            Console.WriteLine($"  Kategori    : {currentCategory?.CategoryName ?? "Bulunamadı"}");

            Console.WriteLine();

            ConsoleRestaurantDesign.WriteInfo("Değiştirmek istemediğiniz alanları boş bırakabilirsiniz.");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Yeni Ürün Adı    : ");
            Console.ResetColor();
            string? name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Yeni Ürün Fiyatı : ");
            Console.ResetColor();
            string? priceInput = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Yeni Stok Miktarı: ");
            Console.ResetColor();
            string? stockInput = Console.ReadLine();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  -------- MEVCUT KATEGORİLER --------");
            Console.ResetColor();

            List<Category> categories = _categoryService.GetAllCategories();

            foreach (Category category in categories)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"  [{category.CategoryId}] ");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(category.CategoryName);
            }

            Console.ResetColor();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Yeni Kategori ID : ");
            Console.ResetColor();
            string? categoryInput = Console.ReadLine();

            // Eski bilgileri saklayalım.
            string oldName = product.ProductName;
            decimal oldPrice = product.ProductPrice;
            int oldStock = product.ProductStock;
            int oldCategoryId = product.CategoryId;

            // Yeni değerleri önce geçici değişkenlere alalım.
            string newName = product.ProductName;
            decimal newPrice = product.ProductPrice;
            int newStock = product.ProductStock;
            int newCategoryId = product.CategoryId;

            if (!string.IsNullOrWhiteSpace(name))
            {
                newName = name.Trim();
            }

            if (!string.IsNullOrWhiteSpace(priceInput))
            {
                if (!decimal.TryParse(priceInput, out newPrice) || newPrice <= 0)
                {
                    ConsoleRestaurantDesign.WriteError("Geçerli bir ürün fiyatı giriniz.");
                    ConsoleRestaurantDesign.WaitForKey();
                    return;
                }
            }

            if (!string.IsNullOrWhiteSpace(stockInput))
            {
                if (!int.TryParse(stockInput, out newStock) || newStock < 0)
                {
                    ConsoleRestaurantDesign.WriteError("Geçerli bir stok miktarı giriniz.");
                    ConsoleRestaurantDesign.WaitForKey();
                    return;
                }
            }

            if (!string.IsNullOrWhiteSpace(categoryInput))
            {
                if (!int.TryParse(categoryInput, out newCategoryId) || newCategoryId <= 0)
                {
                    ConsoleRestaurantDesign.WriteError("Geçerli bir kategori ID değeri giriniz.");
                    ConsoleRestaurantDesign.WaitForKey();
                    return;
                }

                if (!categories.Any(x => x.CategoryId == newCategoryId))
                {
                    ConsoleRestaurantDesign.WriteError("Seçilen kategori bulunamadı.");
                    ConsoleRestaurantDesign.WaitForKey();
                    return;
                }
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  -------------- GÜNCELLEME ÖZETİ --------------");
            Console.ResetColor();

            Console.WriteLine($"  Ürün Adı    : {oldName} -> {newName}");
            Console.WriteLine($"  Ürün Fiyatı : {oldPrice:N2} -> {newPrice:N2} TL");
            Console.WriteLine($"  Stok Miktarı: {oldStock} -> {newStock}");
            Console.WriteLine($"  Kategori ID : {oldCategoryId} -> {newCategoryId}");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  Değişiklikleri kaydetmek istiyor musunuz? (E/H): ");
            Console.ResetColor();

            string? confirmation = Console.ReadLine();

            if (!string.Equals(confirmation?.Trim(), "E", StringComparison.OrdinalIgnoreCase))
            {
                ConsoleRestaurantDesign.WriteInfo("Ürün güncelleme işlemi iptal edildi.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            product.ProductName = newName;
            product.ProductPrice = newPrice;
            product.ProductStock = newStock;
            product.CategoryId = newCategoryId;

            _productService.UpdateProduct(product);

            ConsoleRestaurantDesign.WaitForKey();
        }
        public void ShowLowStockProducts()
        {
            ConsoleRestaurantDesign.WriteHeader("Düşük Stoklu Ürünler");

            List<Product> products = _productService.GetLowStockProducts();

            if (products.Count == 0)
            {
                ConsoleRestaurantDesign.WriteSuccess("Düşük stoklu ürün bulunamadı.");
                ConsoleRestaurantDesign.WaitForKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"  {"ID",-6} {"ÜRÜN ADI",-35} {"FİYAT",-15} {"STOK",-10}");
            Console.WriteLine(new string('-', 75));
            Console.ResetColor();

            foreach (Product product in products)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"  {product.ProductId,-6}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{product.ProductName,-35}");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{product.ProductPrice,-15:N2}");

                if (product.ProductStock == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                Console.WriteLine($"{product.ProductStock,-10}");
            }

            Console.ResetColor();

            Console.WriteLine(new string('-', 75));
            Console.WriteLine();

            int outOfStockCount = products.Count(x => x.ProductStock == 0);
            ConsoleRestaurantDesign.WriteInfo($"Düşük stoklu ürün sayısı: {products.Count}");
            ConsoleRestaurantDesign.WriteError($"Stoğu tükenen ürün sayısı: {outOfStockCount}");
            ConsoleRestaurantDesign.WaitForKey();
        }



        public void ShowPlaceholder(string title)
        {
            ConsoleRestaurantDesign.WriteHeader(title);
            ConsoleRestaurantDesign.WriteInfo("Bu işlem daha sonra geliştirilecek.");
            ConsoleRestaurantDesign.WaitForKey();
        }
    }
}
