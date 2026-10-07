using System.ComponentModel.DataAnnotations;

namespace sahadLearn.API.models.domains
{
    public class Region
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code must be at least 3 characters long.")]
        [MaxLength(3, ErrorMessage = "Code cannot exceed 3 characters.")]
        public Guid id { get; set; }
        public String Code { get; set; }
        public String name { get; set; }
        public String? RegionImage { get; set; }

    }
}
