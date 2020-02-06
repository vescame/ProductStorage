using ProductStorage.Core.Models.Products;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ProductStorage.Data
{
    public class StorageContextMySql : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public StorageContextMySql() : base("StorageConnString")
        {
        }

        public override async Task<int> SaveChangesAsync()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => 
                    e.Entity is Product &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((Product)entityEntry.Entity).UpdateDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((Product)entityEntry.Entity).CreateDate = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync();
        }
    }
}
