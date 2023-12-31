﻿using System;

namespace Raspored.Models.Login
{
    public class UserProfileDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int YearOfEmployment { get; set; }
        public string LicenseNumber { get; set; }
        public int ContractTypeId { get; set; }
        public int PositionId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string ReligiousHoliday { get; set; }
    }
}
