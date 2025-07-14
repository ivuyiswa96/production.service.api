using production.service.api.Interfaces;
using production.service.api.Models;
using production.service.api.Models.Dto;

namespace production.service.api.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new List<Product>();
        public void Create(Product product)

        {
            product.ProductID = Guid.NewGuid();
            _products.Add(product);
        }

        public void Delete(Guid Id)
        {
            var product = _products.FirstOrDefault(p => p.ProductID==Id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(Guid id)
        {
            return _products.FirstOrDefault(p => p.ProductID==id);
        }

        public bool Update(Product product, Guid productId)
        {
            var existing = _products.FirstOrDefault(p => p.ProductID==productId);
            if (existing == null)
                return false;

            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Price = product.Price;

            return true;
        }

    }
}
