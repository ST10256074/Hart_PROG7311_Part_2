using System.ComponentModel.DataAnnotations;

namespace Hart_PROG7311_Part_2.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeModelID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string ProfilePicture { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreateedAt { get; set; }
    }
}
