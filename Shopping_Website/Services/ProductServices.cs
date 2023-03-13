using Shopping_Website.IServices;
using Shopping_Website.Models;

namespace Shopping_Website.Services
{
    public class ProductServices : IProductServices
    {
        ShopDbContext context;
        public ProductServices() // Tạo constructor
        {
            context = new ShopDbContext();
        }
        public bool CreateProduct(Product p)
        {
            try
            {
                context.Products.Add(p); // Add vào Dbset
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProduct(Guid id)
        {
            try
            {
                var product = context.Products.Find(id);
                context.Products.Remove(product); // Xóa khỏi Dbset
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        public Product GetProductById(Guid id)
        {
            return context.Products.FirstOrDefault(p => p.Id == id);
            // return context.Products.SingleOrDefault(p => p.Id == id);
        }

        public List<Product> GetProductsByName(string name)
        {
            return context.Products.Where(p => p.Name == name).ToList();
        }

        public bool UpdateProduct(Product p)
        {
            try
            {
                var product = context.Products.Find(p.Id);
                product.Name = p.Name;
                product.Description = p.Description;
                product.Price = p.Price;
                product.Supplier = p.Supplier;
                context.Update(product);    
                context.SaveChanges(); return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
