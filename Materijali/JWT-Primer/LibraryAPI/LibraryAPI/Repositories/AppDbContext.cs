using LibraryAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repositories
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Book> Books { get; set; }
    
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
