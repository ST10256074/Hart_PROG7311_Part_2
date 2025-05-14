using Hart_PROG7311_Part_2.Data;
using Hart_PROG7311_Part_2.Models;
using Microsoft.Data.SqlClient;

namespace Hart_PROG7311_Part_2.Repository
{
    public class ProductRepository
    {
        // GET: api/<ValuesController>/
        public List<ProductModel> FetchProducts()
        {
            using AppDbContext db = new AppDbContext();
            List<ProductModel> products = db.Products.ToList();
            return products;
        }
        // GET: api/<ValuesController>/id
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
        // GET: api/<ValuesController>/id
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
        // CREATE: api/<ValuesController>/product
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
        // UPDATE: api/<ValuesController>/product
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
        // DELETE api/<ValuesController>/5
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
