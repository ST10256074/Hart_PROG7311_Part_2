using System.ComponentModel.DataAnnotations;

namespace Hart_PROG7311_Part_2.Models
{
    public class LoginModel
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
