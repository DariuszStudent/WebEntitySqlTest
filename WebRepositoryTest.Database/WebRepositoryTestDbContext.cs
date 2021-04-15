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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Car>(options =>
            {
                options.HasOne(x => x.User);
            });

            builder.Entity<ApplicationUser>(options =>
            {
                options.Property(x => x.FirstName).HasMaxLength(27);
                options.Property(x => x.PhoneNumber).IsRequired();
            });
        }
    }
}
