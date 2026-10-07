using System.ComponentModel.DataAnnotations;

namespace sahadLearn.API.models.DTO
{
    public class RegionDTO
    {

        public Guid id { get; set; }
        public String Code { get; set; }
        public String name { get; set; }
      


    }

    public class SignleRegionDTO
    {

        public Guid id { get; set; }
        public String Code { get; set; }
        public String name { get; set; }
        public String? RegionImage { get; set; }


    }

    public class CreateRegionDTO
    {

        [MinLength(3, ErrorMessage = "Code must be at least 3 characters long.")]
        [MaxLength(3, ErrorMessage = "Code cannot exceed 3 characters.")]
        public String Code { get; set; }
        public String name { get; set; }
        public String? RegionImage { get; set; }


    }
}
