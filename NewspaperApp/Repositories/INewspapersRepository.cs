using NewspaperApp.Models;

namespace NewspaperApp.Repositories
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
