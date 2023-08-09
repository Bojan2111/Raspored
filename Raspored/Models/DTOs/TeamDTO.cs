using System.Collections.Generic;

namespace Raspored.Models.DTOs
{
    public class TeamDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TeamMemberDTO> TeamMembers { get; set;}
    }
}
