using CRUD_Smartstore.Models;

namespace CRUD_Smartstore.Repository.Base
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll(string search);
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
