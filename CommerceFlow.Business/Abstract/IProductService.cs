using CommerceFlow.Entities.Entities;

namespace CommerceFlow.Business.Abstract
{
    public interface IProductService
    {
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        List<Product> GetAllProducts();
        Product? GetProductById(int id);
        List<Product> GetLowStockProducts();
    }
}
