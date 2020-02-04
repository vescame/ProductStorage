using ProductStorage.Core.Models.Products;
using System;
using System.Data.Entity;

namespace ProductStorage.Data
{
    public class StorageContextMySql : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public StorageContextMySql() : base("StorageConnString")
        {
        }
    }
}
