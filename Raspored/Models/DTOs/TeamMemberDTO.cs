namespace Raspored.Models.DTOs
{
    public class TeamMemberDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public int YearOfEmployment { get; set; }
        public string TeamName { get; set; }
        public string Position { get; set; }
        public string Role { get; set; }
    }
}
