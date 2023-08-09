using System;

namespace Raspored.Models.DTOs
{
    public class TeamSchedule
    {
        public int Id { get; set; }
        public DateTime Month { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
