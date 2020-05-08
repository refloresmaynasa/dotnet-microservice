
namespace ProductService.Database
{
    using Microsoft.EntityFrameworkCore;
    using ProductService.Database.Entities;
    using System.Linq;

    public class ProductsRepository : BaseRepository<Product>, IRepository<Product>
    {
        public ProductsRepository(DatabaseContext context) : base(context)
        {
        }

        public override Product GetByID(object id)
        {
            return dbSet.Include(p => p.Category).SingleOrDefault(p => p.ProductId == (int)id);
        }
    }
}
