using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Raspored.Models
{
    public class Feature
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(256)]
        public string Description { get; set; }
    }
}
