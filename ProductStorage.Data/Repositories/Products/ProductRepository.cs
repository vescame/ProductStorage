using System.Collections.Generic;
using System.Threading.Tasks;
using ProductStorage.Core.Models.Products;
using ProductStorage.Core.Repositories.Products;

namespace ProductStorage.Data.Repositories.Products
{
    class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(StorageContextMySql context)
            : base(context) { }

        public Task<IEnumerable<Product>> GetAllByCategory(string category)
        {
            throw new System.NotImplementedException();
        }
    }
}
