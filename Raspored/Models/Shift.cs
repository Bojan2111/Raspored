using System;

namespace Raspored.Models
{
    public class Shift
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ShiftTypeId { get; set; }
        public ShiftType ShiftType { get; set; }
        public int TeamMemberId { get; set; }
        public TeamMember TeamMember { get; set; }
    }
}
