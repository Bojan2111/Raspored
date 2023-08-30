using System.ComponentModel.DataAnnotations;

namespace Raspored.Models
{
    public class TeamMemberRole
    {
        public int Id { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "Team member role should be between 1 and 3 characters!")]
        [RegularExpression(@"^[A-Z0-9]{1,3}$", ErrorMessage = "Use only UPPERCASE letters and numbers!")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Team member role description should be between 2 and 100 characters!")]
        [RegularExpression(@"^[a-zA-Z0-9\-\s]{2,100}$", ErrorMessage = "Use only letters, characters, spaces and hyphen(s)!")]
        public string Description { get; set; }
    }
}
