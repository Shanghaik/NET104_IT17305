using Shopping_Website.Models;

namespace Shopping_Website.IServices
{
    public interface IProductServices
    {
        public bool CreateProduct(Product p);
        public bool UpdateProduct(Product p);
        public bool DeleteProduct(Guid id);
        public Product GetProductById(Guid id);
        public List<Product> GetProductsByName(string name);
        public List<Product> GetAllProducts();

    }
}
