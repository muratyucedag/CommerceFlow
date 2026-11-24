
using CommerceFlow.Business.Results;
using CommerceFlow.Entities.Entities;

namespace CommerceFlow.Business.Abstract
{
    public interface ICategoryService
    {
        ServiceResult AddCategory(Category category);
        ServiceResult UpdateCategory(Category category);
        void DeleteCategory(int id);
        List<Category> GetAllCategories();
        Category? GetCategoryById(int id);
    }
}
