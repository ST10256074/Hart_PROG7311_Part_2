using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Hart_PROG7311_Part_2.Models
{
    public class FarmerModel
    {
        public FarmerModel() { }
        public FarmerModel(string name, string username, string password, string address, string profilePicture, string phoneNumber, DateTime createdAt)
        {
            Name = name;
            Username = username;
            Password = password;
            Address = address;
            ProfilePicture = profilePicture;
            PhoneNumber = phoneNumber;
            CreateedAt = createdAt;
        }

        [Key]
        public int FarmerModelID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string ProfilePicture { get; set; }
        [NotMapped]
        [AllowNull]
        public IFormFile ProfilePictureFile { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreateedAt { get; set; }
    }
}
