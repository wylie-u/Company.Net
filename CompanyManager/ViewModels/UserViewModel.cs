using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CompanyManager.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Username")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Email Address")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DisplayName("Confirm Password")]
        [PasswordPropertyText]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}

