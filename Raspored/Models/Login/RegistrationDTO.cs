using System;
using System.ComponentModel.DataAnnotations;

namespace Raspored.Models.Login
{
    public class RegistrationDTO
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name should be up to 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name should be up to 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Username should be between 3 and 60 characters long!")]
        [RegularExpression(@"^(?=.{3,32}$)(?![_.-])(?!.*[_.]{2})[a-zA-Z0-9._-]+(?<![_.])$", ErrorMessage = "Incorrect username format!")]
        public string UserName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$", ErrorMessage = "Incorrect email format!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password should be between 6 and 20 characters long!")]
        [RegularExpression(@"^(?=(?:.*[A-Z]){1,})(?=(?:.*[a-z]){1,})(?=(?:.*\d){1,})(?=(?:.*[!@#$%^&*()\-_=+{};:,<.>]){1,})(?!.*(.)\1{})([A-Za-z0-9!@#$%^&*()\-_=+{};:,<.>]{6,20})$", ErrorMessage = "Incorrect password format!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Year of employment is required")]
        [Range(1975,2023)] // This should be changed every year because of retirement conditions.
        public int YearOfEmployment { get; set; }

        [Required(ErrorMessage = "License number is required")]
        public string LicenseNumber { get; set; }
        public int? ContractTypeId { get; set; }
        public int? PositionId { get; set; }

        public string Role { get; set; }
        public DateTime RegistrationDate { get; set; }


    }
}
