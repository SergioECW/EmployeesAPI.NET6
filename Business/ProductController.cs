using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Object;
using Data;
using System.Data;

namespace Business
{
    public class ProductController
    {
        Product productInstance = new Product();
        List<Product> productList = new List<Product>();
        Data.ProductController DataProductController = new Data.ProductController();
        public List<Product> GetProducts()
        {
            productList = DataProductController.GetProducts();
            return productList;
        }

        public Product GetProductById(int id)
        {
            productInstance = DataProductController.GetProductById(id);
            return productInstance;
        }
        
        public void CreateProduct(Product product)
        {
            DataProductController.CreateProduct(product);
        }

        public void EditProduct(Product product)
        {
            DataProductController.EditProduct(product);
        }

        public void DeleteProduct(int id)
        {
            DataProductController.DeleteProduct(id);
        }
    }
}
