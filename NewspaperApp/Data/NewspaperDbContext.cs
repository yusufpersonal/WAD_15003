using Microsoft.EntityFrameworkCore;
using NewspaperApp.Models;

namespace NewspaperApp.Data
{
    public class NewspaperDbContext : DbContext
    { 
        public NewspaperDbContext(DbContextOptions<NewspaperDbContext> options) : base(options) { } 
        public DbSet<Newspaper> Newspapers { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
 }
