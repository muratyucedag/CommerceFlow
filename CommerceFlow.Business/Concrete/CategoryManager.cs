using CommerceFlow.Business.Abstract;
using CommerceFlow.Business.Results;
using CommerceFlow.DataAccess.Interfaces;
using CommerceFlow.Entities.Entities;

namespace CommerceFlow.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ServiceResult AddCategory(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.CategoryName))
            {
                return new ServiceResult
                {
                    IsSuccess = false,
                    Message = "Kategori adı boş bırakılamaz."
                };
            }

            string categoryName = category.CategoryName.Trim();

            if (categoryName.Length < 3)
            {
                return new ServiceResult
                {
                    IsSuccess = false,
                    Message = "Kategori adı en az 3 karakter olmalıdır."
                };
            }

            bool categoryExists = _categoryRepository.GetAll().Any(x => string.Equals(x.CategoryName?.Trim(), categoryName, StringComparison.OrdinalIgnoreCase));

            if (categoryExists)
            {
                return new ServiceResult
                {
                    IsSuccess = false,
                    Message = "Bu kategori zaten kayıtlı."
                };
            }

            category.CategoryName = categoryName;

            _categoryRepository.Insert(category);

            return new ServiceResult
            {
                IsSuccess = true,
                Message = "Kategori başarıyla eklendi."
            };
        }


        public ServiceResult UpdateCategory(Category category)
        {
            Category? existingCategory = _categoryRepository.GetById(category.CategoryId);

            if (existingCategory == null)
            {
                return new ServiceResult
                {
                    IsSuccess = false,
                    Message = "Güncellenecek kategori bulunamadı."
                };
            }

            if (string.IsNullOrWhiteSpace(category.CategoryName))
            {
                return new ServiceResult
                {
                    IsSuccess = false,
                    Message = "Kategori adı boş bırakılamaz."
                };
            }

            string categoryName = category.CategoryName.Trim();

            if (categoryName.Length < 3)
            {
                return new ServiceResult
                {
                    IsSuccess = false,
                    Message = "Kategori adı en az 3 karakter olmalıdır."
                };
            }

            bool categoryExists = _categoryRepository.GetAll()
                .Any(x =>
                    x.CategoryId != category.CategoryId &&
                    string.Equals(
                        x.CategoryName?.Trim(),
                        categoryName,
                        StringComparison.OrdinalIgnoreCase));

            if (categoryExists)
            {
                return new ServiceResult
                {
                    IsSuccess = false,
                    Message = "Bu kategori adı başka bir kategoride kullanılıyor."
                };
            }

            existingCategory.CategoryName = categoryName;

            _categoryRepository.Update(existingCategory);

            return new ServiceResult
            {
                IsSuccess = true,
                Message = "Kategori başarıyla güncellendi."
            };
        }


        public void DeleteCategory(int id)
        {
            if (id <= 0)
            {
                Console.WriteLine("Geçersiz kategori ID değeri.");
                return;
            }

            Category? category = _categoryRepository.GetById(id);

            if (category == null)
            {
                Console.WriteLine("Silinecek kategori bulunamadı.");
                return;
            }

            _categoryRepository.Delete(category);

            Console.WriteLine("Kategori başarıyla silindi.");
        }

        public List<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll();
        }

        public Category? GetCategoryById(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return _categoryRepository.GetById(id);
        }
    }
}
