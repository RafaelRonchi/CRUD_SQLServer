using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Exemple.Models;
using WebApplication_Exemple.Services.Interfaces;

namespace WebApplication_Exemple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controller : ControllerBase
    {
        private readonly IServiceProduct _serviceProduct;

        public Controller(IServiceProduct serviceProduct)
        {
            _serviceProduct = serviceProduct;
        }

        [HttpGet]
        [Route("/product")]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var products = await _serviceProduct.GetAllProducts();
            if (products == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(products);
            }
            
        }
        [HttpGet]
        [Route("/product/{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            var product = await _serviceProduct.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }

        }
        [HttpPut]
        [Route("/product")]
        public async Task<ActionResult<Product>> PutProduct(Product product)
        {
            var response = await _serviceProduct.UpdateProduct(product);
            if (response == false)
            {
                return NotFound("No one product found!");
            }
            else
            {
                return Ok("Product updated");
            }

        }
        [HttpDelete]
        [Route("/product/{id}")]
        public async Task<ActionResult<string>> DeleteProduct(int id)
        {
            var response = await _serviceProduct.DeleteProduct(id);
            if (response == false)
            {
                return NotFound("No one product found!");
            }
            else
            {
                return Ok("Product updated");
            }

        }
        [HttpPost]
        [Route("/product")]
        public async Task<ActionResult<string>> CreateProduct(Product product)
        {
            var response = await _serviceProduct.CreateProduct(product);
            if (response == false)
            {
                return NotFound("Error!");
            }
            else
            {
                return Ok("Product created");
            }

        }
    }
}
