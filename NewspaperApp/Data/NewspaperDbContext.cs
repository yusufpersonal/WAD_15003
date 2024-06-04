using Microsoft.EntityFrameworkCore;
using NewspaperApp15003.Models;

namespace NewspaperApp15003.Data
{
    public class NewspaperDbContext : DbContext
    { 
        public NewspaperDbContext(DbContextOptions<NewspaperDbContext> options) : base(options) { } 
        public DbSet<Newspaper> Newspapers { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
 }
