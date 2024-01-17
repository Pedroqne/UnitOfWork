using UnitOfWork.DataContext;
using UnitOfWork.Models;

namespace UnitOfWork.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Product> GetProductById()
        {
            return Get().OrderBy(p => p.Price).ToList();
        }

 
    }
}
