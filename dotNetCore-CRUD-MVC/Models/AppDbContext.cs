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

		// 'Create Time' and 'Update Time' for New record and Updated records
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

		// 'Create Time' and 'Update Time' for New record and Updated records
		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			var insertedEntries = this.ChangeTracker.Entries()
								   .Where(x => x.State == EntityState.Added)
								   .Select(x => x.Entity);

			foreach (var insertedEntry in insertedEntries)
			{
				var auditableEntity = insertedEntry as TimeEntity;
				if (auditableEntity != null)
				{
					auditableEntity.CreatedTime = DateTime.Now;
				}
			}

			var modifiedEntries = this.ChangeTracker.Entries()
					   .Where(x => x.State == EntityState.Modified)
					   .Select(x => x.Entity);

			foreach (var modifiedEntry in modifiedEntries)
			{
				var auditableEntity = modifiedEntry as TimeEntity;
				if (auditableEntity != null)
				{
					auditableEntity.UpdatedTime = DateTime.Now;
				}
			}

			return base.SaveChangesAsync(cancellationToken);
		}
	}
}
