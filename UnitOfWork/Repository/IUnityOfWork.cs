namespace UnitOfWork.Repository
{
    public interface IUnityOfWork
    {
        IProductRepository ProducyRepository { get; }
        ICategoryRepository Category { get; }
        void Commit();
    }
}
