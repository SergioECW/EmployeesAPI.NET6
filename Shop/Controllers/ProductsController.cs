using Microsoft.AspNetCore.Mvc;
using Shop.Model;
using Newtonsoft.Json;
using System.Text;

namespace Shop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        Product productInstance = new Product();
        List<Product> products = new List<Product>();
        static HttpClient client = new HttpClient();
        HttpResponseMessage response = new HttpResponseMessage();

        [HttpGet]
        public async Task<List<Product>> GetProducts()
        {           
           response = await client.GetAsync("https://localhost:7082/api/Products/GetProducts");
            if (response.IsSuccessStatusCode)
            {
               string result = await response.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<List<Product>>(result);
            }

            return products;
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async void CreateProduct(Product product)
        {
            var message = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            try
            {
                await client.PostAsync(new Uri("https://localhost:7082/api/Products/CreateProduct"), message);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                
            }

        }

        //[HttpPost]
        //[Route("GetProductById")]
        //public IActionResult GetProductById(int id)
        //{
        //    productInstance = productController.GetProductById(id);
        //    if (productInstance == null)
        //    {
        //        return NoContent();
        //    }
        //    else
        //    {
        //        return Ok(productInstance);
        //    }
        //}

        [HttpPut]
        [Route("EditProduct")]
        public async void EditProduct(Product product)
        {
            var message = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            try
            {
                await client.PostAsync(new Uri("https://localhost:7082/api/Products/EditProduct"), message);
            }
            catch (Exception ex)
            {
                
            }


        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public async void DeleteProduct(int id)
        {
            try
            {
                response = await client.DeleteAsync("https://localhost:7082/api/Products/DeleteProduct/"+id);
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
