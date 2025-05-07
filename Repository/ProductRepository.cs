using Hart_PROG7311_Part_2.Data;
using System.Security.Claims;
using Hart_PROG7311_Part_2.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace Hart_PROG7311_Part_2.Repository
{
    public class ProductRepository
    {
        // get connecio string
        public static string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hart_PROG7311_Part_2_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public SqlConnection con = new SqlConnection(ConnectionString);
        public List<ProductModel> FetchProducts()
        {
            //try
            //{
            //    using AppDbContext db = new AppDbContext();
            //    db.Products.Add(p);
            //    db.SaveChanges();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}
            using AppDbContext db = new AppDbContext();
            List<ProductModel> products = db.Products.ToList();
            return products;
        }

        public void Create(ProductModel p )
        {
            try
            {
                using AppDbContext db = new AppDbContext();
                db.Products.Add(p);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public ProductModel FetchProductByID(int id)
        {
            try
            {
                using AppDbContext db = new AppDbContext();
                ProductModel product = (ProductModel) db.Products.Where(e => e.ProductModelID == id).FirstOrDefault();
                return product;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                return null;
            } 
        }
    }
}
