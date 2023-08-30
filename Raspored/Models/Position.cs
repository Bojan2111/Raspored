using System.ComponentModel.DataAnnotations;

namespace Raspored.Models
{
    public class Position
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
