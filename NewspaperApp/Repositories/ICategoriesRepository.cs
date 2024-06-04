using NewspaperApp15003.Models;

namespace NewspaperApp15003.Repositories
{
    public interface ICategoriesRepository
    { 
        Task<IEnumerable<Category>> GetAllCategories(); 
        Task<Category> GetSingleCategory (int id); 
        Task CreateCategory(Category category); 
        Task UpdateCategory(Category category); 
        Task DeleteCategory(int id);
    }
}
