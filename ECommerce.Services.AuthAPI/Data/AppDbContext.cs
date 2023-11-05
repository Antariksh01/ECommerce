using ECommerce.Services.AuthAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Services.AuthAPI.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
        
            base.OnModelCreating(modelBuilder);

           
        }
    }
}
