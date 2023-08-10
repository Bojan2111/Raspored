using System;
using System.Collections.Generic;

namespace Raspored.Models.DTOs
{
    public class PersonalSchedule
    {
        public int TeamMemberId { get; set; }
        public string TeamName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TeamMemberRoleName { get; set; }
        public string TeamMemberRoleDescription { get; set; }
        public string MonthName { get; set; }
        public List<ShiftDTO> Shifts { get; set; }
    }
}
