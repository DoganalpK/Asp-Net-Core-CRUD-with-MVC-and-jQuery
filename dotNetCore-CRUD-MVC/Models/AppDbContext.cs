using Microsoft.EntityFrameworkCore;

namespace dotNetCore_CRUD_MVC.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserModel> UserModel { get; set; }
    }
}
