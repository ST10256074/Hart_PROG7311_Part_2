using Hart_PROG7311_Part_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Hart_PROG7311_Part_2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<FarmerModel> Farmers { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }

        /// <summary>
        /// On AppDBContext creation, configure the connection string
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=Hart_PROG7311_Part_2_Database;Trusted_Connection=True"
            );
        }
        public AppDbContext()
        {

        }
        public DbSet<Hart_PROG7311_Part_2.Models.LoginModel> LoginModel { get; set; } = default!;
    }
}
