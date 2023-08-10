using System;
using System.ComponentModel.DataAnnotations;

namespace Raspored.Models.Login
{
    public class RegistrationDTO
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Year of employment is required")]
        [Range(1958,2064)]
        public int YearOfEmployment { get; set; }

        [Required(ErrorMessage = "License number is required")]
        public string LicenseNumber { get; set; }
        public int? ContractTypeId { get; set; }
        //public ContractType ContractType { get; set; }
        public int? PositionId { get; set; }
        //public Position Position { get; set; }

        public string Role { get; set; }
        public DateTime RegistrationDate { get; set; }


    }
}
