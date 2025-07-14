using production.service.api.Models;
using System.Runtime.InteropServices;

namespace production.service.api.Interfaces
{
    public interface IProductService
    {
        void Create(Product product );
        IEnumerable<Product> GetAll();
        Product GetById(Guid id);
        bool Update(Product product,Guid productId );
        void Delete(Guid Id );
    }
}
