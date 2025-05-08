using Hart_PROG7311_Part_2.Data;
using Hart_PROG7311_Part_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hart_PROG7311_Part_2.Repository
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRepository : ControllerBase
    {
        AppDbContext db = new AppDbContext();
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public EmployeeModel? Get(int id)
        {
            EmployeeModel em = db.Employees.Where(e => e.EmployeeModelID == id).FirstOrDefault();
            return em;
        }

        // GET: api/<ValuesController>/username and password
        [HttpGet("login/{username}/{password}")]
        public EmployeeModel? Get(string username, string password)
        {
            EmployeeModel em = db.Employees.Where(e => e.Username == username && e.Password == password).FirstOrDefault();
            return em;
        }

        // GET: api/<ValuesController>/all
        [HttpGet("all")]
        public List<EmployeeModel> GetAll()
        {
            List<EmployeeModel> em = db.Employees.ToList();
            return em;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] EmployeeModel employee)
        {
            try
            {
                db.Employees.Add(employee);
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
                EmployeeModel? em = db.Employees.Where(e => e.EmployeeModelID == id).FirstOrDefault();
                if (em == null)
                {
                    Console.WriteLine("Employee not found");
                    return;
                }
                db.Employees.Remove(em);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
