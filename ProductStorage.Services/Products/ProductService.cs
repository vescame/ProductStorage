using ProductStorage.Core;
using ProductStorage.Core.Models.Products;
using ProductStorage.Core.Services.Products;
using ProductStorage.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductStorage.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IContextWorker _worker;

        public ProductService(IContextWorker worker)
        {
            _worker = worker;
        }

        public async Task<Product> Create(Product product)
        {
            _worker.Products.Add(product);
            await _worker.CommitAsync();
            return product;
        }

        public Task<Product> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _worker.Products.GetAllAsync();
        }

        public Task<Product> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
