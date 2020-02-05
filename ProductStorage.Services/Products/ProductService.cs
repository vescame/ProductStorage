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

        public ProductService()
        {
            _worker = new ContextWorker();
        }

        public async Task<Product> Create(Product product)
        {
            _worker.Products.Add(product);
            await _worker.CommitAsync();
            return product;
        }

        public async Task<Product> Delete(long id)
        {
            Product p;
            try
            {
                p = await _worker.Products.GetByIdAsync(id);
                _worker.Products.Remove(p);
                await _worker.CommitAsync();
            }
            catch (Exception e)
            {
                throw new Exception("ProductNotFoundException");
            }
            return p;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _worker.Products.GetAllAsync();
        }

        public async Task<Product> GetById(long id)
        {
            return await _worker.Products.GetByIdAsync(id);
        }

        public async Task<Product> Update(Product product)
        {
            Product p;
            try
            {
                p = await _worker.Products.GetByIdAsync(product.Id);
                p = product;
                await _worker.CommitAsync();
            }
            catch (Exception)
            {
                throw new Exception("ProductNotUpdatableException");
            }

            return p;
        }
    }
}
