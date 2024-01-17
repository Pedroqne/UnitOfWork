using Microsoft.EntityFrameworkCore;
using UnitOfWork.DataContext;
using UnitOfWork.Models;

namespace UnitOfWork.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Category> GetCategoryProducts()
        {
            return Get().Include(c => c.Products);
        }
    }
}
