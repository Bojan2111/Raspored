using Microsoft.AspNetCore.Identity;
using System;

namespace Raspored.Models.Login
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int YearOfEmployment { get; set; }
        public string LicenseNumber { get; set; }
        public int? ContractTypeId { get; set; }
        public ContractType ContractType { get; set; }
        public int? PositionId { get; set; }
        public Position Position { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public DateTime ReligiousHoliday { get; set; }
        public double Rating { get; set; }
        public bool Deleted { get; set; } = false;
    }
}
