using System.ComponentModel.DataAnnotations;

namespace Raspored.Models
{
    public class FeatureType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        public string Description { get; set; }

    }
}
