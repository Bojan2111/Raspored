using System;

namespace Raspored.Models.DTOs
{
    public class ShiftDTO
    {
        public DateTime ShiftDate { get; set; }
        public int TeamMemberId { get; set; }
        public string ShiftTypeName { get; set; }
        public string ShiftTypeDescription { get; set; }
    }
}
