using CRUD_Smartstore.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Smartstore.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
