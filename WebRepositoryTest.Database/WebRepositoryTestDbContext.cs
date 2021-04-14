using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebRepositoryTest.Database
{
    public class WebRepositoryTestDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Car> Cars { get; set; }

        public WebRepositoryTestDbContext (DbContextOptions<WebRepositoryTestDbContext> options) 
            : base(options)
        {
            
        }
    }
}
