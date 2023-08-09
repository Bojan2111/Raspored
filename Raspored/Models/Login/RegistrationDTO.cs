using System;
using System.ComponentModel.DataAnnotations;

namespace Raspored.Models.Login
{
    public class RegistrationDTO
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public string Role { get; set; }
        public DateTime RegistrationDate { get; set; }


    }
}
