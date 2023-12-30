using WebApplication_Exemple.Models;

namespace WebApplication_Exemple.Services.Interfaces
{
    public interface IServiceProduct
    {
        Task<List<Product>> GetAllProducts();
        Task<bool> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
        Task<Product> GetProductById(int id);

    }
}
