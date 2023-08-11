using Raspored.Models.Login;

namespace Raspored.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int TeamMemberRoleId { get; set; }
        public TeamMemberRole TeamMemberRole { get; set; }
    }
}
