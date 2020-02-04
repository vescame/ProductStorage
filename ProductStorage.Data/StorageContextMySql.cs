using ProductStorage.Core.Models.Products;
using System;
using System.Data.Entity;

namespace ProductStorage.Data
{
    class StorageContextMySql : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected StorageContextMySql() : base("StorageConnString")
        {
        }
    }
}
