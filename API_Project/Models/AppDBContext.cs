using Microsoft.EntityFrameworkCore;

namespace API_Project.Models
{
    public class AppDBContext : DbContext
    {
        public DbSet<Product> products {  get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {
            
        }

    }
    
}
