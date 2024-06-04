using NewspaperApp15003.Models;

namespace NewspaperApp15003.Repositories
{
    public interface INewspapersRepository
    { 
        Task<IEnumerable<Newspaper>> GetAllNewspapers(); 
        Task<Newspaper> GetSingleNewspaper (int id); 
        Task CreateNewspaper (Newspaper newspaper); 
        Task UpdateNewspaper (Newspaper newspaper); 
        Task DeleteNewspaper (int id);
    }
}
