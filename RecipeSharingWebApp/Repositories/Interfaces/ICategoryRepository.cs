using RecipesSharingWebApp.Areas.Admin.Models;

namespace RecipesSharingWebApp.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(string id);
        Task<Category> CreateCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task DeleteCategory(string id);
        Task<IEnumerable<Category>> GetAllCategory();
    }
}
