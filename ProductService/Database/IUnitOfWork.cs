namespace ProductService.Database
{
    using ProductService.Database.Entities;

    public interface IUnitOfWork
    {
        IRepository<Product> Products { get; }
        IRepository<Category> Categories { get; }
        IAuthRepository Users { get; }
        void Commit();
    }
}
