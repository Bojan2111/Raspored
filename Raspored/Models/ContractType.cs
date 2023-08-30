using System.ComponentModel.DataAnnotations;

namespace Raspored.Models
{
    public class ContractType
    {
        public int Id { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Contract type should be between 2 and 60 characters long")]
        public string Name { get; set; }
    }
}
