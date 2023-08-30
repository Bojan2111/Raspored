using System.ComponentModel.DataAnnotations;

namespace Raspored.Models
{
    public class ShiftType
    {
        public int Id { get; set; }

        [StringLength(3, MinimumLength = 1)]
        public string Name { get; set; }

        [StringLength (50, MinimumLength = 3)]
        public string Description { get; set; }
    }
}
