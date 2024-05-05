using Microsoft.EntityFrameworkCore;
using Nerdnest.Model;

namespace Nerdnest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        
        }
        public DbSet<Category> Category { get; set; }
    }
}
