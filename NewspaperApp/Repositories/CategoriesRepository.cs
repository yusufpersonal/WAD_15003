using Microsoft.EntityFrameworkCore;
using NewspaperApp15003.Data;
using NewspaperApp15003.Models;

namespace NewspaperApp15003.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly NewspaperDbContext _dbContext;

        public CategoriesRepository(NewspaperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var categories =  await _dbContext.Categories.ToListAsync(); 
            return categories;
        }
        public async Task CreateCategory(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCategory(int id)
        {
            var newspaper = await _dbContext.Categories.FirstOrDefaultAsync(b => b.Id == id);
            if (newspaper != null)
            {
                _dbContext.Categories.Remove(newspaper);
                await _dbContext.SaveChangesAsync();
            }
        } 

        public async Task<Category> GetSingleCategory(int id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(b =>b.Id ==id);
        }

        public async Task UpdateCategory(Category newspaper)
        {
            _dbContext.Entry(newspaper).State = EntityState.Modified; 
            await _dbContext.SaveChangesAsync(); 
        }

    }
}
