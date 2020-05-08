namespace ProductService.Database
{
    using ProductService.Database.Entities;

    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseContext _dbContext;
        private IRepository<Product> _products;
        private BaseRepository<Category> _categories;
        private IAuthRepository _users;

        public UnitOfWork(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<Product> Products => _products ??= new ProductsRepository(_dbContext);

        public IRepository<Category> Categories => _categories ??= new BaseRepository<Category>(_dbContext);

        public IAuthRepository Users => _users ??= new AuthRepository(_dbContext);

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
