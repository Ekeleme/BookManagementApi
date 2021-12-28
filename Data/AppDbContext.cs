using Microsoft.EntityFrameworkCore;
using BookManagementApi.Model;

namespace BookManagementApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options):base(options){ }

        public DbSet<BookItems> BookItems { get; set; }
    }
}