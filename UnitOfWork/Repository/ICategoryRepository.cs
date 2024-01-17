using UnitOfWork.Models;

namespace UnitOfWork.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategoryProducts();
    }
}
