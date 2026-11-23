
using CommerceFlow.Business.Abstract;
using CommerceFlow.DataAccess.Interfaces;
using CommerceFlow.Entities.Entities;

namespace CommerceFlow.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.ProductName))
            {
                Console.WriteLine("Ürün adı boş olamaz.");
                return;
            }

            if (product.ProductPrice <= 0)
            {
                Console.WriteLine("Ürün fiyatı sıfırdan büyük olmalıdır.");
                return;
            }

            if (product.ProductStock < 0)
            {
                Console.WriteLine("Ürün stok miktarı negatif olamaz.");
                return;
            }

            if (product.CategoryId <= 0)
            {
                Console.WriteLine("Geçerli bir kategori seçilmelidir.");
                return;
            }

            _productRepository.Insert(product);

            Console.WriteLine("Ürün başarıyla eklendi.");
        }

        public void UpdateProduct(Product product)
        {
            if (product.ProductId <= 0)
            {
                Console.WriteLine("Geçersiz ürün ID değeri.");
                return;
            }

            if (string.IsNullOrWhiteSpace(product.ProductName) || product.ProductPrice <= 0 || product.ProductStock < 0 || product.CategoryId <= 0)
            {
                Console.WriteLine("Ürün bilgileri geçersiz.");
                return;
            }

            Product? existingProduct = _productRepository.GetById(product.ProductId);

            if (existingProduct == null)
            {
                Console.WriteLine("Güncellenecek ürün bulunamadı.");
                return;
            }

            _productRepository.Update(product);

            Console.WriteLine("Ürün başarıyla güncellendi.");
        }

        public void DeleteProduct(int id)
        {
            Product? product = _productRepository.GetById(id);

            if (product == null)
            {
                Console.WriteLine("Silinecek ürün bulunamadı.");
                return;
            }

            _productRepository.Delete(product);

            Console.WriteLine("Ürün başarıyla silindi.");
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public Product? GetProductById(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return _productRepository.GetById(id);
        }

        public List<Product> GetLowStockProducts()
        {
            return _productRepository.GetLowStockProducts();
        }
    }
}
