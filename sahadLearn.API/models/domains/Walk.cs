using System.ComponentModel.DataAnnotations.Schema;

namespace sahadLearn.API.models.domains
{
    public class Walk
    {
        public Guid id { get; set; }
        public String name { get; set; }
        public String discription { get; set; }
        public double LegthInKm { get; set; }
        public String? WalkImageUrl { get; set; }

        // Foreign keys
        public Guid difficaltyId { get; set; }
        public Guid RegionID { get; set; }

        // Navigation properties
        [ForeignKey("difficaltyId")]
        public Difficulty Defficalty { get; set; }

        [ForeignKey("RegionID")]
        public Region Rigion { get; set; }
    }
}