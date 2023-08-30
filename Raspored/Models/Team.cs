using System.ComponentModel.DataAnnotations;

namespace Raspored.Models
{
    public class Team
    {
        public int Id { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Team name should be between 2 and 40 characters long!")]
        [RegularExpression(@"^[a-zA-Z0-9\-\s]{2,40}$", ErrorMessage = "Use only letters, characters, spaces and hyphen(s)!")]
        public string Name { get; set; }
    }
}
