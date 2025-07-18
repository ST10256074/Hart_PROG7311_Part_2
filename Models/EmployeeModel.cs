﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [NotMapped]
        public string ProfilePictureFile { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreateedAt { get; set; }
        public EmployeeModel() { }

        public EmployeeModel(string name, string username, string password, string address, string profilePicture, string phoneNumber)
        {
            Name = name;
            Username = username;
            Password = password;
            Address = address;
            ProfilePicture = profilePicture;
            PhoneNumber = phoneNumber;
            CreateedAt = DateTime.Now;
        }
    }
}
