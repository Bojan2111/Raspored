using Microsoft.AspNetCore.Identity;

namespace Raspored.Models
{
    public class RoleFeatureMapping
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public IdentityRole Role { get; set; }
        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
    }
}
