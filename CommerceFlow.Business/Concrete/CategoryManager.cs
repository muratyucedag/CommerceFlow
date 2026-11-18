using CommerceFlow.Business.Abstract;
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

        public void AddCategory(Category category)
        {
            if (category == null)
            {
                Console.WriteLine("Kategori bilgisi bulunamadı.");
                return;
            }

            if (string.IsNullOrWhiteSpace(category.CategoryName))
            {
                Console.WriteLine("Kategori adı boş olamaz.");
                return;
            }

            if (category.CategoryName.Length < 3)
            {
                Console.WriteLine("Kategori adı en az 3 karakter olmalıdır.");
                return;
            }

            var categories = _categoryRepository.GetAll();

            bool categoryExists = categories.Any(x => x.CategoryName.ToLower() == category.CategoryName.Trim().ToLower());

            if (categoryExists)
            {
                Console.WriteLine("Bu isimde bir kategori zaten mevcut.");
                return;
            }

            category.CategoryName = category.CategoryName.Trim();

            _categoryRepository.Insert(category);

            Console.WriteLine("Kategori başarıyla eklendi.");
        }

        public void UpdateCategory(Category category)
        {
            if (category == null || category.CategoryId <= 0)
            {
                Console.WriteLine("Kategori bilgileri geçersiz.");
                return;
            }

            if (string.IsNullOrWhiteSpace(category.CategoryName))
            {
                Console.WriteLine("Kategori adı boş olamaz.");
                return;
            }

            if (category.CategoryName.Trim().Length < 3)
            {
                Console.WriteLine("Kategori adı en az 3 karakter olmalıdır.");
                return;
            }

            Category? existingCategory = _categoryRepository.GetById(category.CategoryId);

            if (existingCategory == null)
            {
                Console.WriteLine("Güncellenecek kategori bulunamadı.");
                return;
            }

            var categories = _categoryRepository.GetAll();

            bool categoryExists = categories.Any(x => x.CategoryId != category.CategoryId && x.CategoryName.ToLower() == category.CategoryName.Trim().ToLower());

            if (categoryExists)
            {
                Console.WriteLine("Bu isim başka bir kategoride kullanılıyor.");
                return;
            }

            category.CategoryName = category.CategoryName.Trim();

            _categoryRepository.Update(category);

            Console.WriteLine("Kategori başarıyla güncellendi.");
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
