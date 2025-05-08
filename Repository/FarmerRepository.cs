using Hart_PROG7311_Part_2.Data;
using Hart_PROG7311_Part_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hart_PROG7311_Part_2.Repository
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerRepository : ControllerBase
    {
        AppDbContext db = new AppDbContext();
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public FarmerModel? Get(int id)
        {
            FarmerModel em = db.Farmers.Where(f => f.FarmerModelID == id).FirstOrDefault();
            return em;
        }

        // GET: api/<ValuesController>/username and password
        [HttpGet("login/{username}/{password}")]
        public FarmerModel? Get(string username, string password)
        {
            FarmerModel em = db.Farmers.Where(f => f.Username == username && f.Password == password).FirstOrDefault();
            return em;
        }

        // GET: api/<ValuesController>/all
        [HttpGet("all")]
        public List<FarmerModel> GetAll()
        {
            List<FarmerModel> em = db.Farmers.ToList();
            return em;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] FarmerModel farmer)
        {
            try
            {
                db.Farmers.Add(farmer);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                FarmerModel? fm = db.Farmers.Where(f => f.FarmerModelID == id).FirstOrDefault();
                if (fm == null)
                {
                    Console.WriteLine("Employee not found");
                    return;
                }
                db.Farmers.Remove(fm);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
