using System;

namespace Raspored.Models.DTOs
{
    public class ShiftDTO
    {
        public DateTime Date { get; set; }
        public string ShiftTypeName { get; set; }
        public string ShiftTypeDescription { get; set; }
    }
}
