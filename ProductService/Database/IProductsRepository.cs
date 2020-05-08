using ProductService.Database.Entities;

namespace ProductService.Database
{
    public interface IProductsRepository
    {
        Product GetByID(object id);
    }
}