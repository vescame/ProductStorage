using ProductStorage.Core.Models.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductStorage.Core.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(long id);
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<Product> Delete(long id);
    }
}
