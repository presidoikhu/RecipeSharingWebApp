using RecipesSharingWebApp.Areas.Admin.Models;
using RecipesSharingWebApp.Data;
using RecipesSharingWebApp.Repositories.Interfaces;

namespace RecipesSharingWebApp.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Category> CreateCategory(Category Category)
        {
            _dbContext.Categories.Add(Category);
            await _dbContext.SaveChangesAsync();
            return Category;
        }

        public async Task DeleteCategory(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
            {
                throw new NotImplementedException(nameof(id));
            }
            var Category = _dbContext.Categories.FirstOrDefault(p => p.Id == id);
            if (Category != null)
            {
                _dbContext.Categories.Remove(Category);
            }
        }

        public Task<IEnumerable<Category>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            var category = _dbContext.Categories.ToList();
            return category;
        }

        public async Task<Category> GetCategoryById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            return _dbContext.Categories.FirstOrDefault(x => x.Id == id) ?? throw new ArgumentNullException();
        }

        public async Task<Category> UpdateCategory(Category Category)
        {
            _dbContext.Categories.Update(Category);
            await _dbContext.SaveChangesAsync();
            return Category;
        }
    }
}