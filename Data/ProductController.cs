using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Object;

namespace Data
{
    public class ProductController
    {
        Product productInstance = new Product();
        List<Product> productList = new List<Product>();
        string cs = "Data Source=DESKTOP-NA8GVVS;Initial Catalog=WebScop;Integrated Security=True";

        public List<Product> GetProducts()
        {
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GET_PRODUCTS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ID = (int)reader["ID"];
                    product.Name = reader["TITLE"].ToString();
                    product.ProductNumber = reader["PRODUCT_NUMBER"].ToString();
                    product.Price = reader["PRICE"].ToString();

                    productList.Add(product);
                }
                con.Close();
            }
            return productList;
        }

        public Product GetProductById(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("GET_PRODUCT_BY_ID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataReader reader = cmd.ExecuteReader();                
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ID = (int)reader["ID"];
                    product.Name = reader["TITLE"].ToString();
                    product.ProductNumber = reader["PRODUCT_NUMBER"].ToString();
                    product.Price = reader["PRICE"].ToString();

                    productInstance = product;
                }                
            }
            return productInstance;
        }

        public void CreateProduct(Product product)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("CREATE_PRODUCTS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@PRODUCT_NUMBER", Convert.ToInt32(product.ProductNumber));
                cmd.Parameters.AddWithValue("@TITLE", product.Name);
                cmd.Parameters.AddWithValue("@PRICE", product.Price);
                cmd.ExecuteNonQuery();                
            }
        }

        public void EditProduct(Product product)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("UPDATE_PRODUCTS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@ID", product.ID);
                cmd.Parameters.AddWithValue("@PRODUCT_NUMBER", Convert.ToInt32(product.ProductNumber));
                cmd.Parameters.AddWithValue("@TITLE", product.Name);
                cmd.Parameters.AddWithValue("@PRICE", product.Price);
                cmd.ExecuteNonQuery();                
            }
        }

        public void DeleteProduct(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("DELETE_PRODUCTS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();               
            }
        }
    }
}
