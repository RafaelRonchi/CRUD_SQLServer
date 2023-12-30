using Microsoft.EntityFrameworkCore;
using WebApplication_Exemple.Data;
using WebApplication_Exemple.Models;
using WebApplication_Exemple.Services.Interfaces;

namespace WebApplication_Exemple.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly DataContext _context;

        public ServiceProduct(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                var existProduct = _context.Products.FirstOrDefault(p => p.Id == id);
                if (existProduct is null) return false;
                
                _context.Products.Remove(existProduct);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                var products = _context.Products.ToListAsync();
                return await products;
            }
            catch (Exception e)
            {
                throw new Exception();

            }
        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                var products = await _context.Products.FindAsync(id);
                return products;
            }
            catch (Exception e)
            {
                throw new Exception();

            }
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            try
            {
                var productExist = await _context.Products.FindAsync(product.Id);
                if (productExist is null) return false;

                productExist.PName = product.PName;
                productExist.Description = product.Description;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;

            }
        }
    }
}
