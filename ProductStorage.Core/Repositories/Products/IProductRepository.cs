using ProductStorage.Core.Models.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductStorage.Core.Repositories.Products
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllByCategory(string category);
    }
}
