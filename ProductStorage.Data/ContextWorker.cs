using System.Threading.Tasks;
using ProductStorage.Core;
using ProductStorage.Core.Repositories.Products;
using ProductStorage.Data.Repositories.Products;

namespace ProductStorage.Data
{
    public class ContextWorker : IContextWorker
    {
        private readonly StorageContextMySql _storageContext;

        private ProductRepository _productRepository;
        public IProductRepository Products
            => _productRepository = _productRepository ?? new ProductRepository(_storageContext);

        public ContextWorker()
        {
            _storageContext = new StorageContextMySql();
        }

        public async Task<int> CommitAsync()
        {
            return await _storageContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _storageContext.Dispose();
        }
    }
}
