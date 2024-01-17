using UnitOfWork.Models;

namespace UnitOfWork.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProductById();

    }
}
