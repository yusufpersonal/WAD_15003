using Microsoft.EntityFrameworkCore;
using NewspaperApp15003.Data;
using NewspaperApp15003.Models;

namespace NewspaperApp15003.Repositories
{
    public class NewspapersRepository : INewspapersRepository
    {
        private readonly NewspaperDbContext _dbContext;

        public NewspapersRepository(NewspaperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Newspaper>> GetAllNewspapers()
        {
            var newspapers  =  await _dbContext.Newspapers.Include(n => n.Category).ToListAsync(); 
            return newspapers;
        }
        public async Task CreateNewspaper(Newspaper newspaper)
        {
            await _dbContext.Newspapers.AddAsync(newspaper);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteNewspaper(int id)
        {
            var newspaper = await _dbContext.Newspapers.FirstOrDefaultAsync(b => b.Id == id);
            if (newspaper != null)
            {
                _dbContext.Newspapers.Remove(newspaper);
                await _dbContext.SaveChangesAsync();
            }
        } 

        public async Task<Newspaper> GetSingleNewspaper(int id)
        {
            return await _dbContext.Newspapers.Include(n => n.Category).FirstOrDefaultAsync(b =>b.Id ==id);
        }

        public async Task UpdateNewspaper(Newspaper newspaper)
        {
            _dbContext.Entry(newspaper).State = EntityState.Modified; 
            await _dbContext.SaveChangesAsync(); 
        }

    }
}
