using Hart_PROG7311_Part_2.Data;
using Hart_PROG7311_Part_2.Models;
using Microsoft.Data.SqlClient;

namespace Hart_PROG7311_Part_2.Repository
{
    public class ProductRepository
    {
        // get connecio string
        //public static string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Hart_PROG7311_Part_2_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        //public SqlConnection con = new SqlConnection(ConnectionString);
        public List<ProductModel> FetchProducts()
        {
            using AppDbContext db = new AppDbContext();
            List<ProductModel> products = db.Products.ToList();
            return products;
        }
        public ProductModel FetchProductByID(int id)
        {
            try
            {
                using AppDbContext db = new AppDbContext();
                ProductModel product = (ProductModel)db.Products.Where(e => e.ProductModelID == id).FirstOrDefault();
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public List<ProductModel> FetchProductsByFarmerID(int id)
        {
            try
            {
                using AppDbContext db = new AppDbContext();
                List<ProductModel> products = (List<ProductModel>)db.Products.Where(e => e.FarmerId == id).ToList();
                return products;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public void Create(ProductModel p)
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

        public void Update(ProductModel p) {

            try
            {
                using AppDbContext db = new AppDbContext();
                db.Products.Update(p);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Delete(int id)
        {
            try
            {
                using AppDbContext db = new AppDbContext();
                ProductModel product = (ProductModel)db.Products.Where(e => e.ProductModelID == id).FirstOrDefault();
                db.Products.Remove(product);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
