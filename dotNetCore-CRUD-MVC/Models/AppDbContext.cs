using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace dotNetCore_CRUD_MVC.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UsersModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>()
                .ToTable("AspNetUsers", t => t.ExcludeFromMigrations());
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(o => o.Entity is TimeEntity &&
                (o.State == EntityState.Added || o.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((TimeEntity)entityEntry.Entity).UpdatedTime = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((TimeEntity)entityEntry.Entity).CreatedTime = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}
