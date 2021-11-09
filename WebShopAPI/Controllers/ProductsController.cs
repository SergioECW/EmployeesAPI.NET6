using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Data;
using Object;
using Business;

namespace WebShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        ProductController productController = new ProductController();
        Product productInstance = new Product();
        List<Product> products = new List<Product>();
        
        [HttpGet]
        [Route("GetProducts")]
        public IActionResult GetProducts()
        {
            products = productController.GetProducts();
            if(products == null || products.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(products);
            }            
        }

        [HttpPost]
        [Route("CreateProduct")]
        public IActionResult CreateProduct(Product product)
        {
            try
            {
                productController.CreateProduct(product);
                return Ok("Creado");
            }
            catch(Exception ex)
            {
                return ValidationProblem(ex.Message.ToString());
            }

        }

        [HttpPost]
        [Route("GetProductById")]
        public IActionResult GetProductById(int id)
        {
            productInstance = productController.GetProductById(id);
            if(productInstance == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(productInstance);
            }
        }

        [HttpPut]
        [Route("EditProduct")]
        public IActionResult EditProduct(Product product)
        {
            try
            {
              productController.EditProduct(product);
                return Ok("Editado");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
            

        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                productController.DeleteProduct(id);
                return Ok("Eliminado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
