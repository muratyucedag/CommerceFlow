
using CommerceFlow.Entities.Entities;

namespace CommerceFlow.Business.Abstract
{
    public interface ICategoryService
    {
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
        List<Category> GetAllCategories();
        Category? GetCategoryById(int id);
    }
}
