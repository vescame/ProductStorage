using ProductStorage.Core.Repositories.Products;
using System;
using System.Threading.Tasks;

namespace ProductStorage.Core
{
    public interface IContextWorker : IDisposable
    {
        IProductRepository Products { get; }
        Task<int> CommitAsync();
    }
}
